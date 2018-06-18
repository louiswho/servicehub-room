using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using Xunit;
using ServiceHub.Room.Context.Repository;
using ServiceHub.Room.Context.Models;

namespace ServiceHub.Room.Testing.Service
{
    public class TestSuite
    {
        private RoomRepositoryMemory _context;
        private readonly Address _address;
        private readonly Room.Context.Models.Room _room;

        public TestSuite()
        {
            _address = _address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            _room = new Room.Context.Models.Room
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
        public void TestModelProperties()
        {

            var address1 = new Address
            {
                AddressId = _address.AddressId,
                Address1 = _address.Address1,
                Address2 = _address.Address2,
                City = _address.City,
                State = _address.State,
                Country = _address.Country,
                PostalCode = _address.PostalCode
            };

            var room1 = new Room.Context.Models.Room
            {
                RoomId = _room.RoomId,
                Address = address1,
                Location = _room.Location,
                Occupancy = _room.Occupancy,
                Vacancy = _room.Vacancy,
                Gender = _room.Gender
            };

            var obj1ToJSON =  room1.ToJson();
            var obj2ToJSON = _room.ToJson();

            Assert.Equal(obj1ToJSON,obj2ToJSON);
        }

        [Fact]
        public async Task TestContextInsert()
        {
            _context = new RoomRepositoryMemory();

            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Context.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Address = address,
                Location = "Tampa",
                Vacancy = 1,
                Occupancy = 2,
                Gender = "M"
            };


            await _context.InsertAsync(room);

            Assert.Equal(room.RoomId, _context.GetAsync().Result.First().RoomId);
        }
        
        [Fact]
        public async Task TestGetAll()
        {
            _context = new RoomRepositoryMemory();

            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Context.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Address = address,
                Location = "Tampa",
                Vacancy = 1,
                Occupancy = 2,
                Gender = "M"
            };

            var address1 = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "4321 Tester ava.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            var room1 = new Room.Context.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Address = address1,
                Location = "Tampa",
                Vacancy = 1,
                Occupancy = 2,
                Gender = "M"
            };


            await _context.InsertAsync(room);
            await _context.InsertAsync(room1);
            var results = _context.GetAsync().Result;
            Assert.Equal(2,results.Count);
        }

        [Fact]
        public async Task TestGetById()
        {
            _context = new RoomRepositoryMemory();

            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Context.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Address = address,
                Location = "Tampa",
                Vacancy = 1,
                Occupancy = 2,
                Gender = "M"
            };

            await _context.InsertAsync(room);
            var result = _context.GetByIdAsync(room.RoomId).Result;

            Assert.Equal(room.RoomId,result.RoomId);
        }

        [Fact]
        public async Task TestUpdate()
        {
            _context = new RoomRepositoryMemory();

            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Context.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Address = address,
                Location = "Tampa",
                Vacancy = 1,
                Occupancy = 2,
                Gender = "M"
            };

            await _context.InsertAsync(room);

            room.Location = "Dallas";
            await _context.UpdateAsync(room);

            Assert.Equal("Dallas",_context.GetByIdAsync(room.RoomId).Result.Location);
        }

        [Fact]
        public async Task TestDelete()
        {
            _context = new RoomRepositoryMemory();
            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Context.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Address = address,
                Location = "Tampa",
                Vacancy = 1,
                Occupancy = 2,
                Gender = "M"
            };

            await _context.InsertAsync(room);
            
            await _context.DeleteAsync(room.RoomId);

            Assert.Empty(_context.roomList);
        }
    }
}