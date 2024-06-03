using AutoMapper;
using System.Security.Cryptography;
using System.Text;
using System;
using TodoListAPI.Entities;
using TodoListAPI.Models;
using TodoListAPI.Repositories;
using System.Linq;
using System.Collections.Generic;
using TodoListAPI.Common;
using TodoListAPI.Repositories.Interface;

namespace TodoListAPI.Services
{
    public class LoginService
    {
        private readonly IRepositories _repository;
        private readonly IMapper _mapper;

        public LoginService(IRepositories repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public UserDto Login(string email, string password)
        {
            var user = _repository.GetUser(email);

            if (user == null)
            {
                return new UserDto() { RtnCode = 0, RtnMsg = "帳號或密碼錯誤!" };
            }

            if (Encryption.SHA256Encrypt(password) != user.Password)
            {
                new UserDto() { RtnCode = 0, RtnMsg = "帳號或密碼錯誤!" };
            }

            var result = _mapper.Map<UserDto>(user);
            result.RtnCode = 1;
            return result;
        }
    }
}
