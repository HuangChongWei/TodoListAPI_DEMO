using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TodoListAPI.Controllers;
using TodoListAPI.Models;
using TodoListAPI.Services;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Get_ReturnsAllItems()
        {
            // Arrange
            var mockService = new Mock<TodoListService>();
            mockService.Setup(s => s.GetAll()).Returns(new List<TodoItemAPIModel>
            {
                new TodoItemAPIModel { Id = 1, Description = "Task 1", IsDone = false },
                new TodoItemAPIModel { Id = 2, Description = "Task 2", IsDone = true }
            });

            var controller = new TodoListApiController(mockService.Object);

            // Act
            var result = controller.Get();

            // Assert
            var items = Assert.IsAssignableFrom<IEnumerable<TodoItemAPIModel>>(result);
            Assert.Equal(2, items.Count());
        }

        [Fact]
        public void Post_AddsNewItem()
        {
            // Arrange
            var mockService = new Mock<TodoListService>();
            mockService.Setup(s => s.Add(It.IsAny<string>())).Returns(new BaseModel { RtnCode = 1 }); // 使用 RtnCode = 1 表示成功
            var controller = new TodoListApiController(mockService.Object);
            var newDescription = "New Task";

            // Act
            var result = controller.Post(newDescription);

            // Assert
            var model = Assert.IsType<BaseModel>(result);
            Assert.True(model.IsSuccess); // 檢查 IsSuccess 是否為 true
            mockService.Verify(s => s.Add(newDescription), Times.Once);
        }
    }
}
