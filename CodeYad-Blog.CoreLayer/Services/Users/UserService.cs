﻿using System;
using System.Linq;
using Codeyad_Blog4.CoreLayer.DTOs.Users;
using Codeyad_Blog4.CoreLayer.Utilities;
using Codeyad_Blog4.DataLayer.Context;
using Codeyad_Blog4.DataLayer.Entities;

namespace Codeyad_Blog4.CoreLayer.Services.Users
{
    public class UserService : IUserService
    {
        private readonly BlogContext _context;

        public UserService(BlogContext context)
        {
            _context = context;
        }

        public OperationResult RegisterUser(UserRegisterDto registerDto)
        {
            var isUserNameExist = _context.Users.Any(u => u.UserName == registerDto.UserName);

            if (isUserNameExist)
                return OperationResult.Error("نام کاربری تکراری است");

            var passwordHash = registerDto.Password.EncodeToMd5();
            _context.Users.Add(new User()
            {
                FullName = registerDto.Fullname,
                IsDelete = false,
                UserName = registerDto.UserName,
                Role = UserRole.User,
                CreationDate = DateTime.Now,
                Password = passwordHash
            });
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public UserDto LoginUser(LoginUserDto loginDto)
        {
            var passwordHashed = loginDto.Password.EncodeToMd5();
            var user = _context.Users
                .FirstOrDefault(u => u.UserName == loginDto.UserName && u.Password == passwordHashed);

            if (user == null)
                return null;

            var userDto = new UserDto()
            {
                FullName = user.FullName,
                Password = user.Password,
                Role = user.Role,
                UserName = user.UserName,
                RegisterDate = user.CreationDate,
                UserId = user.Id
            };
            return userDto;
        }
    }
}