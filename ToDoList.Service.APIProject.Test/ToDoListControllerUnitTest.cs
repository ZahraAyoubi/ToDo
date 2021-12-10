using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using ToDoList.Service.APIProject.Controllers;
using ToDoList.Service.APIProject.DTOs;
using ToDoList.Service.APIProject.Repository;

namespace ToDoList.Service.APIProject.Test
{
    [TestClass]
    public class ToDoListControllerUnitTest
    {
        [TestMethod]
        public async Task Get_Test()
        {
            //Arrange
            var repository = new Mock<IToDoListRepository>();
            var controller = new ToDoListController(repository.Object);

            //Act
            var result = await controller.Get();

            //Assert
            result.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetById_Test()
        {
            //Arrange
            var repository = new Mock<IToDoListRepository>();
            var controller = new ToDoListController(repository.Object);

            //Act
            var result = await controller.GetById(1);

            //Assert
            result.Should().NotBeNull();
        }

        [TestMethod]
        public async Task Post_Test()
        {
            //Arrange
            var repository = new Mock<IToDoListRepository>();
            var controller = new ToDoListController(repository.Object);
            var newToDo = new ToDoListDto
            { 
                Id = 1, Name = "ToDo1",
                Description = "Creating a ToDo app",
                IsCompelete = false,
                Date = System.DateTime.UtcNow };

            //Act
            var result = await controller.Post(newToDo);

            //Assert
            result.Should().NotBeNull();
        }

        [TestMethod]
        public async Task Put_Test()
        {
            //Arrange
            var repository = new Mock<IToDoListRepository>();
            var controller = new ToDoListController(repository.Object);
            var newToDo = new ToDoListDto
            {
                Id = 1,
                Name = "ToDo1",
                Description = "Creating a ToDo app",
                IsCompelete = false,
                Date = System.DateTime.UtcNow
            };

            //Act
            var result = await controller.Put(newToDo);

            //Assert
            result.Should().NotBeNull();
        }

        [TestMethod]
        public async Task Delete_Test()
        {
            //Arrange
            var repository = new Mock<IToDoListRepository>();
            var controller = new ToDoListController(repository.Object);

            //Act
            var result = await controller.Delete(1);

            //Assert
            result.Should().NotBeNull();
        }
    }
}