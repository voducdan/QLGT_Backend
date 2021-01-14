using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLGT_API.Commands;
using QLGT_API.Model;
using QLGT_API.Models;
using QLGT_API.Repository;
using QLGT_API.Utils;
using QLGT_API.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private UserRepository userRepository;
        private UserService userService;

        public UserController(UserRepository userRepository, UserService userService)
        {
            this.userRepository = userRepository;
            this.userService = userService;
        }

        [HttpGet]

        public IActionResult GetAll([FromQuery] PageCommand pageCommand)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                ListView<UserModel> user = this.userRepository.GetList(pageCommand.PageIndex, pageCommand.PageSize, m =>m.CMND != null);
                if (user == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Could not find any user"
                    });
                }
                return Ok(new
                {
                    success = true,
                    user
                });
            }
            catch 
            {
                return NotFound(new
                {
                    success = false,
                    error = "faile"
                });
            }
        }


        // update pasword
        [HttpPut]
        public IActionResult Update([FromBody] UpdatePasswordCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var account = this.userService.GetUser(command.Cmnd);
                if (command.CurrPassWord == command.NewPassWord)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "New Password and Old Password is the same"
                    });
                }
                if (account== null)
                {                    
                    return NotFound(new
                    {
                        success = false,
                        error = "User is not exits"
                    });
                    
                }

                if (account != null && HashHelper.Verify(command.CurrPassWord, account.PASS_WORD) == false)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Old PassWord is fail "
                    });
                }
                if (account != null && HashHelper.Verify(command.CurrPassWord, account.PASS_WORD)== true)
                {
                    account.PASS_WORD = HashHelper.Hash(command.NewPassWord);
                    userRepository.Update(account);                    
                }
                return Ok(new
                {
                    success = true

                });

            }
            catch
            {
                return NotFound(new
                {
                    success = false,
                    error = "Fail"
                });
            }
        }
    }
}
