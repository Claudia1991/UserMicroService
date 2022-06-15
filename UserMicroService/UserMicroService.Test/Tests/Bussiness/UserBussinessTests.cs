using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UserMicroService.Bussiness.Bussiness.Users;
using UserMicroService.EntitiesProvider.DomainEntities;
using UserMicroService.EntitiesProvider.Interfaces.DataAccess;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using UserMicroService.EntitiesProvider.ModelEntities.Response;
using UserMicroService.EntitiesProvider.Enums;
using UserMicroService.EntitiesProvider.ModelEntities.Request;

namespace UserMicroService.Test.Tests.Bussiness
{
    [TestClass]
    public class UserBussinessTests
    {
        private Mock<IBaseRepository<User>> _baseRepositoryMock;
        private UserBussiness _userBussiness;

        [TestInitialize]
        public void Inicialize()
        {
            _baseRepositoryMock = new Mock<IBaseRepository<User>>();
            _userBussiness = new UserBussiness(_baseRepositoryMock.Object);
        }

        [TestMethod]
        public void Execute_Get()
        {
            ///Arrange
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Name= "Sapo pepe",
                    Birthdate = System.DateTime.Now,
                    Active = true
                },
                new User
                {
                    Id = 2,
                    Name= "Sapo pepe 2",
                    Birthdate = System.DateTime.Now,
                    Active = false
                }
            };

            var usersResponse = users.Select(x => new UserResponse
            {
                Id = x.Id,
                Name = x.Name,
                Birthdate = x.Birthdate.ToString("dd/MM/yyyy")
            })
                                            .ToList();

            var response = ResponseBase<IEnumerable<UserResponse>>.FromSuccess(Messages.OK, usersResponse);

            _baseRepositoryMock.Setup(x => x.Get()).Returns(users);

            ///Action
            ///
            var result = _userBussiness.GetAllUsers();

            ///Assert
            ///
            result.Success.Should().BeTrue();
        }

        [TestMethod]
        public void Execute_Create_Request_OK()
        {
            ///Arrange
            var userAddRequest = new UserAddRequest
            {
                Name = "Sapo pepe",
                Birthday = System.DateTime.Now
            };

            var entity = new User()
            {
                Name = userAddRequest.Name,
                Birthdate = userAddRequest.Birthday,
                Active = true
            };

            var response = ResponseBase.FromSuccess(Messages.OK);

            _baseRepositoryMock.Setup(x => x.Add(It.Is<User>(u => u != null))).Verifiable();

            ///Action
            ///
            var result = _userBussiness.CreatNewUser(userAddRequest);

            ///Assert
            ///
            _baseRepositoryMock.Verify(x => x.Add(It.Is<User>(u => u != null)), Times.Once);

        }

        [TestMethod]
        public void Execute_Delete_Request_OK()
        {
            ///Arrange
            var userDeleteRequest = new UserDeleteRequest
            {
                Id = 1
            };

            var entity = new User()
            {       
            };

            var response = ResponseBase.FromSuccess(Messages.OK);

            _baseRepositoryMock.Setup(x => x.GetById(It.Is<int>(u => u > 0))).Returns(entity).Verifiable();
            _baseRepositoryMock.Setup(x => x.Delete(It.Is<User>(u => u != null))).Verifiable();

            ///Action
            ///
            var result = _userBussiness.DeleteUser(userDeleteRequest);

            ///Assert
            ///
            _baseRepositoryMock.Verify(x => x.GetById(It.Is<int>(u => u > 0)), Times.Once);
            _baseRepositoryMock.Verify(x => x.Delete(It.Is<User>(u => u != null)), Times.Once);
            result.Success.Should().BeTrue();

        }

        [TestMethod]
        public void Execute_Delete_Request_NO_OK()
        {
            ///Arrange
            var userDeleteRequest = new UserDeleteRequest
            {
                Id = 1
            };

            User entity = null;

            var response = ResponseBase.FromSuccess(Messages.OK);

            _baseRepositoryMock.Setup(x => x.GetById(It.Is<int>(u => u > 0))).Returns(entity).Verifiable();
            _baseRepositoryMock.Setup(x => x.Delete(It.Is<User>(u => u != null))).Verifiable();

            ///Action
            ///
            var result = _userBussiness.DeleteUser(userDeleteRequest);

            ///Assert
            ///
            _baseRepositoryMock.Verify(x => x.GetById(It.Is<int>(u => u > 0)), Times.Once);
            _baseRepositoryMock.Verify(x => x.Delete(It.Is<User>(u => u != null)), Times.Never);
            result.Success.Should().BeFalse();

        }

        [TestMethod]
        public void Execute_Update_Request_OK()
        {
            ///Arrange
            var userUpdateRequest = new UserUpdateRequest
            {
                Id = 1,
                Active = false
            };

            var entity = new User()
            {
                Active = userUpdateRequest.Active
            };

            var response = ResponseBase.FromSuccess(Messages.OK);

            _baseRepositoryMock.Setup(x => x.GetById(It.Is<int>(u => u > 0))).Returns(entity).Verifiable();
            _baseRepositoryMock.Setup(x => x.Update(It.Is<User>(u => u != null))).Verifiable();

            ///Action
            ///
            var result = _userBussiness.UpdateUser(userUpdateRequest);

            ///Assert
            ///
            _baseRepositoryMock.Verify(x => x.GetById(It.Is<int>(u => u > 0)), Times.Once);
            _baseRepositoryMock.Verify(x => x.Update(It.Is<User>(u => u != null)), Times.Once);
            result.Success.Should().BeTrue();

        }

        [TestMethod]
        public void Execute_Update_Request_NO_OK()
        {
            ///Arrange
            var userUpdateRequest = new UserUpdateRequest
            {
                Id = 1,
                Active = false
            };

            User entity = null;

            var response = ResponseBase.FromSuccess(Messages.NO_OK);

            _baseRepositoryMock.Setup(x => x.GetById(It.Is<int>(u => u > 0))).Returns(entity).Verifiable();
            _baseRepositoryMock.Setup(x => x.Update(It.Is<User>(u => u != null))).Verifiable();

            ///Action
            ///
            var result = _userBussiness.UpdateUser(userUpdateRequest);

            ///Assert
            ///
            _baseRepositoryMock.Verify(x => x.GetById(It.Is<int>(u => u > 0)), Times.Once);
            _baseRepositoryMock.Verify(x => x.Update(It.Is<User>(u => u != null)), Times.Never);
            result.Success.Should().BeFalse();

        }
    }
}
