using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using Xunit;
using ServiceHub.Room.Context.Repository;
using ServiceHub.Room.Context.Models;

namespace ServiceHub.Room.Testing.Service
{
    public class TestSuite
    {
        private RoomRepositoryMemory context;
        private Address address;
        private Room.Context.Models.Room room;

        public TestSuite()
        {
            address = address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            room = new Room.Context.Models.Room
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
        public void TestModelProperties()
        {
            Address address1 = new Address();
            address1.AddressId = address.AddressId;
            address1.Address1 = address1.Address1;
            address1.Address2 = address.Address2;
            address1.City = address.City;
            address1.State = address1.State;
            address1.Country = address.Country;
            address1.PostalCode = address.PostalCode;

            Room.Context.Models.Room room1 = new Room.Context.Models.Room();
            room1.RoomId = room.RoomId;
            room1.Address = room.Address;
            room1.Location = room.Location;
            room1.Occupancy = room.Occupancy;
            room1.Vacancy = room.Vacancy;
            room1.Gender = room.Gender;
            
            var obj1ToJSON = room.ToJson();
            var obj2ToJSON = room.ToJson();
            Assert.Equal(obj1ToJSON,obj2ToJSON);
        }

        [Fact]
        public async void TestContextInsert()
        {
            context = new RoomRepositoryMemory();
            Address address = new Address
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

            await context.InsertAsync(room);

            Assert.Equal(room.RoomId, context.GetAsync().Result.First().RoomId);
        }
        
        [Fact]
        public async void TestGetAll()
        {
            context = new RoomRepositoryMemory();
            List<Room.Context.Models.Room> results;
            Address address = new Address
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

            Address address1 = new Address
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

            await context.InsertAsync(room);
            await context.InsertAsync(room1);
            results = context.GetAsync().Result;
            Assert.Equal(2,results.Count);
        }

        [Fact]
        public async void TestGetByID()
        {
            context = new RoomRepositoryMemory();
            Address address = new Address
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
            await context.InsertAsync(room);
            Room.Context.Models.Room result = context.GetByIdAsync(room.RoomId).Result;

            Assert.Equal(room.RoomId,result.RoomId);
        }

        [Fact]
        public async void TestUpdate()
        {
            context = new RoomRepositoryMemory();
            Address address = new Address
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
            await context.InsertAsync(room);

            room.Location = "Dallas";
            await context.UpdateAsync(room);

            Assert.Equal("Dallas",context.GetByIdAsync(room.RoomId).Result.Location);
        }

        [Fact]
        public async void TestDelete()
        {
            context = new RoomRepositoryMemory();
            Address address = new Address
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
            await context.InsertAsync(room);
            
            await context.DeleteAsync(room.RoomId);

            Assert.Empty(context.roomList);
        }
    }
}