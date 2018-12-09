﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using AutoMapper;
//using BestLibrary.Models;
//using LibBusinessLayer.BIL.DTO;
//using LibBusinessLayer.BIL.Interfaces;

//namespace BestLibrary.Controllers
//{
//    public class UserController : ApiController
//    {
//        private readonly IUserService _userService;

//        public UserController(IUserService serv)
//        {
//            _userService = serv;
//        }

//        // GET: api/User 
//        [HttpGet]
//        public UserViewModel GetUsers()
//        {
//            IEnumerable<ClientProfileDto> bookDtos = _userService.GetUsers();
//            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientProfileDto, UserViewModel>()).CreateMapper();
//            var users = mapper.Map<IEnumerable<ClientProfileDto>, List<UserViewModel>>(bookDtos);
//            var user = users.ToArray().First();
//            return user;
//        }

//        // GET: api/User/5
//        public ClientProfileDto GetUser(int id)
//        {
//            var user = _userService.GetUser(id);
//            return user;
//        }

//        // POST: api/User
//        public void Post([FromBody]string value)
//        {
//        }

//        // PUT: api/User/5
//        public void Put(int id, [FromBody]string value)
//        {
//        }

//        // DELETE: api/User/5
//        public void Delete(int id)
//        {
//        }

//        protected override void Dispose(bool disposing)
//        {
//            _userService.Dispose();
//            base.Dispose(disposing);
//        }
//    }
//}
