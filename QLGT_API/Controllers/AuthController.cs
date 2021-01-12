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
        private JWTService jWTService;
        private AuthSettings authSettings;

        public AuthController(UserService userService, UserRepository userRepository, JWTService jWTService, IOptions<AuthSettings> authSettings) : base()
        {
            this.userService = userService;
            this.userRepository = userRepository;
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
            var user = userService.GetUser(command.Username);
            if (HashHelper.Verify(command.Password, user.Password))
            {
                loginView.code = 200;
                loginView.AccessToken = ProcessLogin(user);
                loginView.message = "Login Sucessful";


            }
            else
            {
                loginView.code = 400;
                loginView.AccessToken = null;
                loginView.message = "Login Fail";

            }
            return loginView;
        }


        // create new user
        [Route("register")]
        [HttpPost]
        public RegisterView register([FromBody] CreateUserCommand command)
        {
            RegisterView registerView = new RegisterView();
            UserModel userModel = new UserModel();
            //user.id = command.id;
            userModel.Username = command.Username;
            userModel.Email = command.Email;
            userModel.Password = HashHelper.Hash(command.Password);
            //user.isadmin = false;
            //user.isadmin = command.isadmin;
            try
            {
                userRepository.Create(userModel);
                registerView.code = 200;
                registerView.message = "create user successfully";
            }
            catch (System.Exception)
            {

                registerView.code = 400;
                registerView.message = "create user Failed";
            }
            return registerView;
        }
    }
}
