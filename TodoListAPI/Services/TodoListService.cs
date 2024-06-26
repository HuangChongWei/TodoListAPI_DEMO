﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using TodoListAPI.Entities;
using TodoListAPI.Repositories;
using TodoListAPI.Models;
using System.Security.Claims;
using TodoListAPI.Repositories.Interface;

namespace TodoListAPI.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly IRepositories _repository;
        private readonly IMapper _mapper;

        public TodoListService(IRepositories repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public IEnumerable<TodoItemAPIModel> GetAll(int userId)
        {
            var dbModel = _repository.GetTodoItem(userId);
            var result = _mapper.Map<IEnumerable<TodoItemAPIModel>>(dbModel);

            return result;
        }

        public BaseModel Add(string decription, int userId)
        {
            var result = new BaseModel() { RtnCode = 1 };

            try
            {
                _repository.Add(decription, userId);
            }
            catch (Exception ex)
            {
                //TODO Log
                result.RtnCode = 0;
                result.RtnMsg = ex.Message;
            }
            return result;
        }

        public BaseModel Update(TodoItemAPIModel item)
        {
            var result = new BaseModel() { RtnCode = 1 };
            var dbModel = _mapper.Map<TodoItem>(item);
            dbModel.UpdateDate = DateTime.Now;
            try
            {
                _repository.Update(dbModel);
            }
            catch (Exception ex)
            {
                result.RtnCode = 0;
                result.RtnMsg = ex.Message;
            }
            return result;
        }
        public BaseModel Delete(int id, int userId)
        {
            var result = new BaseModel { RtnCode = 1 };
            try
            {
                _repository.Delete(id, userId);
            }
            catch (Exception ex)
            {
                result.RtnCode = 0;
                result.RtnMsg = ex.Message;
            }
            return result;
        }
    }
}
