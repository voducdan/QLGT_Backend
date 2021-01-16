using NUnit.Framework;
using QLGT_API.Repository;
using QLGT_API.Data;
using QLGT_API.Controllers;
using System.Collections.Generic;
using QLGT_API.Models;
using QLGT_API.Services;
using QLGT_API.Constants;
using Moq;
using System.Linq;
using System;
using QLGT_API.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace UnitTests
{
    class AuthControllerTests
    {
        IOptions<AuthSettings> authSetting;
        UserService user_service;
         
        AuthSettings auth = new AuthSettings();
        Key key = new Key();
        ExpiredTime expired = new ExpiredTime();
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
            .UseInMemoryDatabase("UserList")
            .Options;
            using (var context = new QLGTDBContext(options))
            {
                context.ACCOUNT.Add(new QLGT_API.Model.UserModel()
                {
                    ID_ACCOUNT = 1,
                    CMND = "1231",
                    PASS_WORD = "abcd",
                    IS_ADMIN = 0,
                    MA_KHACH_HANG = 1
                });
                context.ACCOUNT.Add(new QLGT_API.Model.UserModel()
                {
                    ID_ACCOUNT = 2,
                    CMND = "1232",
                    PASS_WORD = "abcd",
                    IS_ADMIN = 0,
                    MA_KHACH_HANG = 2
                });
                context.ACCOUNT.Add(new QLGT_API.Model.UserModel()
                {
                    ID_ACCOUNT = 3,
                    CMND = "1233",
                    PASS_WORD = "abcd",
                    IS_ADMIN = 0,
                    MA_KHACH_HANG = 3
                });
                context.SaveChangesAsync();
            }
        }
        [Test]
        [TestCase("1231", "abcd")]
        [TestCase("1232", "abcd")]
        public void LoginTest_WithValidUser_ReturnMessage(string username, string password)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
            .UseInMemoryDatabase("UserList")
            .Options;
            using (var context = new QLGTDBContext(options))
            {
                user_service = new UserService(context);
                JWTService jwt_service = new JWTService(user_service);
                
                UserRepository user_repo = new UserRepository(context);
                KhachHangRepository cus_repo = new KhachHangRepository(context);
                KhachHangService cus_service = new KhachHangService(context);
                

                AuthController auth_controller = new AuthController(user_service, user_repo, cus_repo, cus_service, jwt_service, authSetting);
               
                var dt = DateTime.Now.AddMinutes(120);
                LoginCommand command = new LoginCommand();
                command.Username = username;
                command.Password = password;
                var result = auth_controller.Login(command);
                Assert.AreEqual("Login Sucessful", result.message);
            }
        }
    }
}
