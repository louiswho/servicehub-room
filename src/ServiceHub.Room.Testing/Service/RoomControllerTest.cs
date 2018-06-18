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
        private readonly Room.Library.Models.Address _address;
        private readonly Room.Library.Models.Room _room;
        private readonly RoomRepositoryMemory _context;

        public RoomControllerTest()
        {
            _context = new RoomRepositoryMemory();
            _address = new Room.Library.Models.Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            _room = new Room.Library.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Address = _address,
                Location = "Tampa",
                Vacancy = 1,
                Occupancy = 2,
                Gender = "M"
            };
        }

        [Fact]
        public async Task TestControllerGet()
        {
            //Arrange

            _room.Address = _address;
            var id = _room.RoomId;
            await _context.InsertAsync(ModelMapper.LibraryToContext(_room));
            var roomController = new RoomController(new LoggerFactory(), _context);


            //Act
            var myTask = roomController.Get();
            var result = await myTask;
            var contentResult = result as OkObjectResult;


            var list = contentResult.Value as List<Room.Library.Models.Room>;
            var id1 = list[0].RoomId;

            Assert.Equal(id,id1);

        }

        [Fact]
        public async Task TestControllerGetById()
        {
            //Arrange

            _room.Address = _address;
            var id = _room.RoomId;
            await _context.InsertAsync(ModelMapper.LibraryToContext(_room));
            var roomController = new RoomController(new LoggerFactory(), _context);


            var myTask = roomController.Get(id);
            var result = await myTask;
            var contentResult = result as OkObjectResult;

            var roomReturned = contentResult.Value as Room.Library.Models.Room;

            Assert.Equal(id,roomReturned.RoomId);
        }

        [Fact]
        public async Task TestControllerGetByIdWithInvalidArgument()
        {
            //Arrange

            _room.Address = _address;
            await _context.InsertAsync(ModelMapper.LibraryToContext(_room));
            var roomController = new RoomController(new LoggerFactory(), _context);

            var myTask = roomController.Get(Guid.Empty);
            var result = await myTask;
           

            var contentResult = result as BadRequestObjectResult;
            
            Assert.NotNull(contentResult);
            var code = (int)contentResult.StatusCode;
            Assert.InRange(code, 400, 499);
        }

        [Fact]
        public async Task TestControllerPost()
        {
            //Arrange
            _room.Address = _address;
            var roomController = new RoomController(new LoggerFactory(), _context);

            //Act

            var myTask = roomController.Post(_room);

            var result = await myTask;

            var contentResult = result as CreatedAtRouteResult;
            Assert.NotNull(contentResult);
            var code = (int)contentResult.StatusCode;
            Assert.InRange(code,200,299);
        }

        [Fact]
        public async Task TestPostwithInValidModel()
        {
            _room.Address = _address;
            var roomController = new RoomController(new LoggerFactory(), _context);
            // make Room model invalid
            _room.Location = null;

            //Act

            var myTask = roomController.Post(_room);

            var result = await myTask;

            var contentResult = result as BadRequestObjectResult;
            Assert.NotNull(contentResult);
            var code = (int)contentResult.StatusCode;
            //Invalid input is a client side fault which should yeild a 4xx status code
            Assert.InRange(code, 400, 499);
        }

        [Fact]
        public async Task TestControllerPut()
        {
            //Arrange

            var roomController = new RoomController(new LoggerFactory(), _context);
            _room.Address = _address;
            await _context.InsertAsync(ModelMapper.LibraryToContext(_room));
            _room.Location = "Dallas";

            var myTask = roomController.Put(_room);
            var result = await myTask;
            
            var contentResult = result as NoContentResult;
            Assert.NotNull(contentResult);
            var code = contentResult.StatusCode;
            Assert.InRange(code, 200, 299);

            var room1 = _context.GetByIdAsync(_room.RoomId).Result;

            Assert.Equal("Dallas", room1.Location);
        }

        [Fact]
        public async Task TestControllerPutWithTwoArguments()
        {
            //Arrange

            var roomController = new RoomController(new LoggerFactory(), _context);
            _room.Address = _address;
            await _context.InsertAsync(ModelMapper.LibraryToContext(_room));
            _room.Location = "Dallas";

            var myTask = roomController.Put(_room.RoomId,_room);

            var result = await myTask;
            
            var contentResult = result as NoContentResult;
            Assert.NotNull(contentResult);
            var code = contentResult.StatusCode;
            Assert.InRange(code, 200, 299);

            var room1 = _context.GetByIdAsync(_room.RoomId).Result;

            Assert.Equal("Dallas", room1.Location);
        }

        [Fact]
        public async Task TestPutwithInValidModel()
        {
            _room.Address = _address;
            var roomController = new RoomController(new LoggerFactory(), _context);
            // make Room model invalid
            _room.RoomId = Guid.Empty;

            //Act

            var myTask = roomController.Put(_room);

            var result = await myTask;
            
            var contentResult = result as BadRequestObjectResult;
            Assert.NotNull(contentResult);
            var code = (int)contentResult.StatusCode;
            //Invalid input is a client side fault which should yeild a 4xx status code
            Assert.InRange(code, 400, 499);
        }

        [Fact]
        public async Task TestControllerDelete()
        {
            //Arrange

            var roomController = new RoomController(new LoggerFactory(), _context);
            _room.Address = _address;
            await _context.InsertAsync(ModelMapper.LibraryToContext(_room));
            
            Assert.NotEmpty(_context.RoomList);
            var myTask = roomController.Delete(_room.RoomId);

            var result = await myTask;

            var contentResult = result as StatusCodeResult;
            Assert.NotNull(contentResult);
            var code = contentResult.StatusCode;            

            Assert.InRange(code, 200, 299);
            Assert.Empty(_context.RoomList);

        }
        [Fact]
        public async Task TestControllerDeleteWithNullModel()
        {
            //Arrange
            var roomController = new RoomController(new LoggerFactory(), _context);
            _room.Address = _address;
            await _context.InsertAsync(ModelMapper.LibraryToContext(_room));

            Assert.NotEmpty(_context.RoomList);
            var badId = Guid.Empty;
            var myTask = roomController.Delete(badId);
            var result = await myTask;

            var contentResult = result as BadRequestObjectResult;
            Assert.NotNull(contentResult);
            var code = (int)contentResult.StatusCode;
            //Invalid input is a client side fault which should yeild a 4xx status code
            Assert.InRange(code, 400, 499);
        }
        [Fact]
        public async Task TestControllerDeleteWithModelNotInData()
        {
            //Arrange
            var roomController = new RoomController(new LoggerFactory(), _context);
            _room.Address = _address;
            await _context.InsertAsync(ModelMapper.LibraryToContext(_room));

            Assert.NotEmpty(_context.RoomList);
            var badId = Guid.NewGuid();
            var myTask = roomController.Delete(badId);
            var result = await myTask;

            var contentResult = result as NotFoundObjectResult;
            Assert.NotNull(contentResult);
            var code = (int)contentResult.StatusCode;
            //Invalid input is a client side fault which should yeild a 4xx status code
            Assert.InRange(code, 400, 499);
        }

    }
}