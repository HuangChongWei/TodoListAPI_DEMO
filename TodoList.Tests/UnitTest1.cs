using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Claims;
using TodoListAPI.Controllers;
using TodoListAPI.Models;
using TodoListAPI.Services;

namespace TodoList.Tests
{
    public class TodoListApiControllerTests
    {
        private Mock<ITodoListService> _serviceMock;
        private TodoListApiController _controller;

        [SetUp]
        public void Setup()
        {
            _serviceMock = new Mock<ITodoListService>();
            _controller = new TodoListApiController(_serviceMock.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
            }));

            _controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };
        }

        [Test]
        public void Get_ReturnsExpectedResult()
        {
            // Arrange
            var expected = new List<TodoItemAPIModel>();
            _serviceMock.Setup(s => s.GetAll(It.IsAny<int>())).Returns(expected);

            // Act
            var result = _controller.Get();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}