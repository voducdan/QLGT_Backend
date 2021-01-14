using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using QLGT_API.Commands;
using QLGT_API.Constants;
using QLGT_API.Model;
using QLGT_API.Repository;
using QLGT_API.Services;
using QLGT_API.Utils;
using QLGT_API.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // Khai bao cac service va repository su dung 
        private UserService userService;
        private UserRepository userRepository;
        private KhachHangRepository khachHangRepository;
        private KhachHangService khachHangService;
        private JWTService jWTService;
        private AuthSettings authSettings;

        public AuthController(UserService userService, UserRepository userRepository, KhachHangRepository khachHangRepository, KhachHangService khachHangService, JWTService jWTService, IOptions<AuthSettings> authSettings) :base()
        {
            this.userService = userService;
            this.userRepository = userRepository;
            this.khachHangRepository = khachHangRepository;
            this.khachHangService = khachHangService;
            this.jWTService = jWTService;
            this.authSettings = authSettings.Value;
        }

        private string ProcessLogin(UserModel user)
        {
            // Time died
            var accessTokenExpiration = DateTime.Now.AddMinutes(ExpiredTime.AccessTokenExpirationTime);
            // ceate accessToken
            var accessToken = jWTService.GenerateAccessToken(authSettings.AuthSecret, user, accessTokenExpiration);

            return accessToken;
        }


        [Route("login")]

        [HttpPost]
        public LoginView Login([FromBody] LoginCommand command)
        {
            LoginView loginView = new LoginView();
            var account = userService.GetUser(command.Username);
            if (account != null && HashHelper.Verify(command.Password, account.PASS_WORD))
            {
                loginView.code = 200;
                loginView.AccessToken = ProcessLogin(account);
                loginView.message = "Login Sucessful";
                loginView.MaKH = account.MA_KHACH_HANG;
            }
            else
            {
                loginView.code = 400;
                loginView.AccessToken = null;
                loginView.message = "Login Fail";
                loginView.MaKH = 0;
            }
            return loginView;
        }

        [Route("loginToken")]
        [HttpPost]
        public LoginView LoginToken([FromQuery] string token)
        {
            LoginView loginView = new LoginView();
            var user = jWTService.GetUser(token);
            if (user == null)
            {
                loginView.code = 400;
                loginView.AccessToken = null;
                loginView.message = "Login Fail";
                loginView.MaKH = 0;
            }
            if (user != null)
            {   
                loginView.code = 200;
                loginView.AccessToken = token;
                loginView.message = "Login Sucessful";
                loginView.MaKH = user.MA_KHACH_HANG;
            }

            return loginView;
        }




         // create new user
        [Route("register")]
        [HttpPost]
        public RegisterView register([FromBody] CreateUserCommand command)
        {            
            RegisterView registerView = new RegisterView();
            // Lay ra Khach Hang co CMND
            var user = khachHangService.GetKhachHang(command.Username);
            if (user != null)
            {
              
                UserModel userModel = new UserModel();
                UserModel userModel_temp = new UserModel();

                userModel_temp = this.userService.GetUser(command.Username);
                if (userModel_temp == null)
                {
                    userModel.CMND = command.Username;
                    userModel.PASS_WORD = HashHelper.Hash(command.Password);
                    userModel.IS_ADMIN = 0;
                    userModel.MA_KHACH_HANG = user.MA_KHACH_HANG;


                    this.userRepository.Create(userModel);
                    registerView.code = 200;
                    registerView.message = "create user successfully";
                    return registerView;
                }
                else
                {
                    registerView.code = 4001;
                    registerView.message = "User is exists";
                    return registerView;

                }             
                
            }
            else
            {
                registerView.code = 400;
                registerView.message = "CMND is not exists or user Failed";
                return registerView;
            }                    
            
        }
    }
}
