using NUnit.Framework;
using QLGT_API.Repository;
using QLGT_API.Data;
using QLGT_API.Controllers;
using System.Collections.Generic;
using QLGT_API.Models;
using Moq;
using System.Linq;
using System;
using QLGT_API.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests
{
    public class UserServiceTests
    {
        UserService user_service;

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
        [TestCase(2)]
        [TestCase(3)]
        public void GetListTest_ReturnList(int number)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
            .UseInMemoryDatabase("UserList")
            .Options;
            using (var context = new QLGTDBContext(options))
            {
                UserRepository user_repo = new UserRepository(context);
                var result = user_repo.GetList(1, context.ACCOUNT.Count(), m => m.IS_ADMIN == 0);
                Assert.AreEqual(result.Data.Count(), number);
            }
        }
        [Test]
        [TestCase("AC")]
        [TestCase("AA")]
        public void GetUserTest_WithInvalidCMND_ReturnInvalid(string CMND)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
            .UseInMemoryDatabase("UserList")
            .Options;
            using (var context = new QLGTDBContext(options))
            {
                try
                {
                    UserRepository user_repo = new UserRepository(context);
                    user_service = new UserService(context);
                    var result = user_service.GetUser(CMND);
                    Assert.AreEqual(CMND, result.CMND);
                }
                catch (AssertionException e)
                {
                    throw e;
                }
            }
        }
        [Test]
        [TestCase("1231")]
        [TestCase("1232")]
        public void GetUserTest_WithValidCMND_ReturnValidUser(string CMND)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
            .UseInMemoryDatabase("UserList")
            .Options;
            using (var context = new QLGTDBContext(options))
            {
                UserRepository user_repo = new UserRepository(context);
                user_service = new UserService(context);
                var result = user_service.GetUser(CMND);
                Assert.AreEqual(CMND, result.CMND);
            }
        }
        [Test]
        [TestCase(44)]
        [TestCase(55)]
        public void GetUserTest_WithInvalidID_ReturnInvalid(int ID)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
            .UseInMemoryDatabase("UserList")
            .Options;
            using (var context = new QLGTDBContext(options))
            {
                UserRepository user_repo = new UserRepository(context);
                user_service = new UserService(context);
                var result = user_service.GetUser_id(ID);
                Assert.AreEqual(ID, result.MA_KHACH_HANG);
            }
        }
        [Test]
        [TestCase(1)]
        [TestCase(3)]
        public void GetUserTest_WithValidID_ReturnValidUser(int ID)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
            .UseInMemoryDatabase("UserList")
            .Options;
            using (var context = new QLGTDBContext(options))
            {
                UserRepository user_repo = new UserRepository(context);
                user_service = new UserService(context);
                var result = user_service.GetUser_id(ID);
                Assert.AreEqual(ID, result.MA_KHACH_HANG);
            }
        }
    }

}