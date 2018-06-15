using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ServiceHub.Room.Service.Controllers;
using ServiceHub.Room.Context.Repository;
using ServiceHub.Room.Context.Utilities;
using Xunit;
using StatusCodeResult = Microsoft.AspNetCore.Mvc.StatusCodeResult;

namespace ServiceHub.Room.Testing.Service
{
    public class RoomControllerTest
    {
        private Room.Library.Models.Address address;
        private Room.Library.Models.Room room;
        private RoomRepositoryMemory context;

        public RoomControllerTest()
        {
            context = new RoomRepositoryMemory();
            address = new Room.Library.Models.Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            room = new Room.Library.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Address = address,
                Location = "Tampa",
                Vacancy = 1,
                Occupancy = 2,
                Gender = "M"
            };
        }

        [Fact]
        public async void TestControllerGet()
        {
            //Arrange
            room.Address = address;
            Guid id = room.RoomId;
            context.Insert(ModelMapper.LibraryToContext(room));
            RoomController roomController = new RoomController(new LoggerFactory(), context);

            //Act
            var myTask = Task.Run(() => roomController.Get());
            var result = await myTask;
            var contentResult = result as OkObjectResult;


            var list = contentResult.Value as List<Room.Library.Models.Room>;
            Guid id1 = list[0].RoomId;

            Assert.Equal(id,id1);

        }

        [Fact]
        public async void TestControllerGetById()
        {
            //Arrange
            room.Address = address;
            Guid id = room.RoomId;
            context.Insert(ModelMapper.LibraryToContext(room));
            RoomController roomController = new RoomController(new LoggerFactory(), context);

            var myTask = Task.Run(() => roomController.Get(id));
            var result = await myTask;
            var contentResult = result as OkObjectResult;

            var roomReturned = contentResult.Value as Room.Library.Models.Room;

            Assert.Equal(id,roomReturned.RoomId);
        }

        [Fact]
        public async void TestControllerGetByIdWithInvalidArgument()
        {
            //Arrange
            room.Address = address;
            Guid id = room.RoomId;
            context.Insert(ModelMapper.LibraryToContext(room));
            RoomController roomController = new RoomController(new LoggerFactory(), context);

            var myTask = Task.Run(() => roomController.Get(Guid.Empty));
            var result = await myTask;
           

            var contentResult = result as BadRequestObjectResult;
            
            Assert.NotNull(contentResult);
            int code = (int)contentResult.StatusCode;
            Assert.InRange(code, 400, 499);
        }

        [Fact]
        public async void TestControllerPost()
        {
            //Arrange
            room.Address = address;
            RoomController roomController = new RoomController(new LoggerFactory(), context);

            //Act
            var myTask = Task.Run(() => roomController.Post(room));
            var result = await myTask;

            var contentResult = result as StatusCodeResult;
            Assert.NotNull(contentResult);
            int code = (int)contentResult.StatusCode;
            Assert.InRange(code,200,300);
        }

        [Fact]
        public async void TestPostwithInValidModel()
        {
            room.Address = address;
            var roomController = new RoomController(new LoggerFactory(), context);
            // make Room model invalid
            room.Location = null;

            //Act
            var myTask = Task.Run(() => roomController.Post(room));
            var result = await myTask;

            var contentResult = result as BadRequestObjectResult;
            Assert.NotNull(contentResult);
            var code = (int)contentResult.StatusCode;
            //Invalid input is a client side fault which should yeild a 4xx status code
            Assert.InRange(code, 400, 499);
        }

        [Fact]
        public async void TestControllerPut()
        {
            //Arrange
            RoomController roomController = new RoomController(new LoggerFactory(), context);
            room.Address = address;
            context.Insert(ModelMapper.LibraryToContext(room));
            room.Location = "Dallas";

            var myTask = Task.Run(() => roomController.Put(room));
            var result = await myTask;

            //var contentResult = result as StatusCodeResult;
            var contentResult = result as OkObjectResult;
            Assert.NotNull(contentResult);
            int code = (int)contentResult.StatusCode;
            Assert.InRange(code, 200, 299);
            Room.Context.Models.Room room1 = context.GetById(room.RoomId);
            Assert.Equal("Dallas", room1.Location);
        }

        [Fact]
        public async void TestControllerPutWithTwoArguments()
        {
            //Arrange
            RoomController roomController = new RoomController(new LoggerFactory(), context);
            room.Address = address;
            context.Insert(ModelMapper.LibraryToContext(room));
            room.Location = "Dallas";

            var myTask = Task.Run(() => roomController.Put(room.RoomId,room));
            var result = await myTask;
            
            var contentResult = result as OkObjectResult;
            Assert.NotNull(contentResult);
            int code = (int)contentResult.StatusCode;
            Assert.InRange(code, 200, 299);
            Room.Context.Models.Room room1 = context.GetById(room.RoomId);
            Assert.Equal("Dallas", room1.Location);
        }

        [Fact]
        public async void TestPutwithInValidModel()
        {
            room.Address = address;
            var roomController = new RoomController(new LoggerFactory(), context);
            // make Room model invalid
            room.RoomId = Guid.Empty;

            //Act
            var myTask = Task.Run(() => roomController.Put(room));
            var result = await myTask;
            
            var contentResult = result as BadRequestObjectResult;
            Assert.NotNull(contentResult);
            var code = (int)contentResult.StatusCode;
            //Invalid input is a client side fault which should yeild a 4xx status code
            Assert.InRange(code, 400, 499);
        }

        [Fact]
        public async void TestControllerDelete()
        {
            //Arrange
            RoomController roomController = new RoomController(new LoggerFactory(), context);
            room.Address = address;
            context.Insert(ModelMapper.LibraryToContext(room));
            
            Assert.NotEmpty(context.roomList);
            var myTask = Task.Run(() => roomController.Delete(room.RoomId));
            var result = await myTask;

            var contentResult = result as StatusCodeResult;
            Assert.NotNull(contentResult);
            int code = (int)contentResult.StatusCode;            
            Assert.InRange(code, 200, 300);
            Assert.Empty(context.roomList);
        }
        [Fact]
        public async void TestControllerDeleteWithNullModel()
        {
            //Arrange
            RoomController roomController = new RoomController(new LoggerFactory(), context);
            room.Address = address;
            context.Insert(ModelMapper.LibraryToContext(room));

            Assert.NotEmpty(context.roomList);
            var badId = Guid.Empty;
            var myTask = Task.Run(() => roomController.Delete(badId));
            var result = await myTask;

            var contentResult = result as BadRequestObjectResult;
            Assert.NotNull(contentResult);
            int code = (int)contentResult.StatusCode;
            //Invalid input is a client side fault which should yeild a 4xx status code
            Assert.InRange(code, 400, 499);
        }
        [Fact]
        public async void TestControllerDeleteWithModelNotInData()
        {
            //Arrange
            RoomController roomController = new RoomController(new LoggerFactory(), context);
            room.Address = address;
            context.Insert(ModelMapper.LibraryToContext(room));

            Assert.NotEmpty(context.roomList);
            var badId = Guid.NewGuid();
            var myTask = Task.Run(() => roomController.Delete(badId));
            var result = await myTask;

            var contentResult = result as BadRequestObjectResult;
            Assert.NotNull(contentResult);
            int code = (int)contentResult.StatusCode;
            //Invalid input is a client side fault which should yeild a 4xx status code
            Assert.InRange(code, 400, 499);
        }

    }
}
