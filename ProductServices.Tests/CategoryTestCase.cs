using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ProductServices.Controllers;
using ProductServices.Models.DTOs;
using ProductServices.Repositories;
using System;
using System.Threading.Tasks;

namespace ProductServices.Tests
{
    [TestFixture]
    public class CategoriesControllerTests
    {
        private Mock<ICategoryRepository> _mockCategoryRepository;
        private Mock<IMapper> _mockMapper;
        private Mock<ILogger<CategoriesController>> _mockLogger;
        private CategoriesController _controller;

        [SetUp]
        public void Setup()
        {
            _mockCategoryRepository = new Mock<ICategoryRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<CategoriesController>>();

            _controller = new CategoriesController(_mockCategoryRepository.Object, _mockMapper.Object, _mockLogger.Object);
        }

        [Test]
        public async Task Get_ValidCategory_ReturnsOkResult()
        {
            // Arrange
            var categoryId = 1;
            _mockCategoryRepository.Setup(repo => repo.GetCategoryAsync(categoryId));

            // Act
            var result = await _controller.Get(categoryId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        // Other test methods...
    }
}
