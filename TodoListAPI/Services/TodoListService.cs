using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using TodoListAPI.Entities;
using TodoListAPI.Repositories;
using TodoListAPI.Models;

namespace TodoListAPI.Services
{
    public class TodoListService
    {
        private readonly DapperRepositories _repository;
        private readonly IMapper _mapper;

        public TodoListService(DapperRepositories repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public IEnumerable<TodoItemAPIModel> GetAll()
        {
            var dbModel = _repository.GetAll();
            var result = _mapper.Map<IEnumerable<TodoItemAPIModel>>(dbModel);
            return result;
        }

        public BaseModel Add(string decription)
        {
            var result = new BaseModel() { RtnCode = 1 };

            try
            {
                _repository.Add(decription);
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
        public BaseModel Delete(int id)
        {
            var result = new BaseModel { RtnCode = 1 };
            try
            {
                _repository.Delete(id);
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
