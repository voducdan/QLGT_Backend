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

namespace UnitTests
{
    class LoginServiceTests
    {
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
        [TestCase()]
        [TestCase()]
        public void GetTokenTest_WithValidUser_ReturnString()
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
            .UseInMemoryDatabase("UserList")
            .Options;
            using (var context = new QLGTDBContext(options))
            {
                user_service = new UserService(context);
                JWTService jwt_service = new JWTService(user_service);
                var dt = DateTime.Now.AddMinutes(120);
                var result = jwt_service.GenerateAccessToken("1712197.EMP.HCMUS", context.ACCOUNT.FirstOrDefault(),dt);
                Assert.IsTrue(result != null);
            }
        }
        [Test]
        [TestCase()]
        [TestCase()]
        public void GetUserTest_WithValidToken_ReturnUserModel()
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
            .UseInMemoryDatabase("UserList")
            .Options;
            using (var context = new QLGTDBContext(options))
            {
                user_service = new UserService(context);
                JWTService jwt_service = new JWTService(user_service);
                var dt = DateTime.Now.AddMinutes(120);
                var token = jwt_service.GenerateAccessToken("1712197.EMP.HCMUS", context.ACCOUNT.FirstOrDefault(), dt);
                var result = jwt_service.GetUser(token);
                Assert.IsTrue(result != null);
            }
        }
    }
}
