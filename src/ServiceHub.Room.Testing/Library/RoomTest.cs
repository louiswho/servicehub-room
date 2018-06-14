using System;
using ServiceHub.Room.Library.Models;
using Xunit;

namespace ServiceHub.Room.Testing.Library
{
    public class RoomTest
    {
        [Fact]
        public void TestRoomValidationAll()
        {
            Room.Library.Models.Room room = new Room.Library.Models.Room();
            
            Assert.False(room.isValidState());
        }

        [Fact]
        public void TestRoomValidationLocation()
        {
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

            var room = new Room.Library.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Address = address,
                Vacancy = 1,
                Occupancy = 2,
                Gender = ""
            };
            Assert.False(room.isValidState());
        }

        [Fact]
        public void TestRoomValidationPasses()
        {
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

            var room = new Room.Library.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                Address = address,
                Vacancy = 1,
                Occupancy = 2,
                Gender = ""
            };
            
            Assert.True(room.isValidState());
        }

        [Fact]
        public void TestRoomValidationNoAddress()
        {
            var room = new Room.Library.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                //Address = address,
                Vacancy = 1,
                Occupancy = 2,
                Gender = ""
            };
            
            Assert.False(room.isValidState());
        }

        [Fact]
        public void TestRoomValidationWithInvalidAddress()
        {
            Address address = new Address
            {
                AddressId = Guid.NewGuid(),
                //Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Library.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                Address = address,
                Vacancy = 1,
                Occupancy = 2,
                Gender = ""
            };

            Assert.False(room.isValidState());
        }

        [Fact]
        public void TestRoomValidationWithInvalidAddress1()
        {
            Address address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                //City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Library.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                Address = address,
                Vacancy = 1,
                Occupancy = 2,
                Gender = ""
            };

            Assert.False(room.isValidState());
        }

        [Fact]
        public void TestRoomValidationVacancy()
        {
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

            var room = new Room.Library.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                Address = address,
                //Vacancy = 1,
                Occupancy = 2,
                Gender = ""
            };
            
            Assert.False(room.isValidState());
        }

        [Fact]
        public void TestRoomValidationVacancyGreaterThanOccupancy()
        {
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

            var room = new Room.Library.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                Address = address,
                Vacancy = 3,
                Occupancy = 2,
                Gender = ""
            };

            Assert.False(room.isValidState());
        }

        [Fact]
        public void TestRoomValidationOccupancy()
        {
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

            var room = new Room.Library.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                Address = address,
                Vacancy = 1,
                //Occupancy = 2,
                Gender = ""
            };
            
            Assert.False(room.isValidState());
        }

        [Fact]
        public void TestRoomValidationOccupancyLessThanZero()
        {
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

            var room = new Room.Library.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                Address = address,
                Vacancy = 0,
                Occupancy = 0,
                Gender = ""
            };
            
            Assert.False(room.isValidState());
        }

        [Fact]
        public void TestRoomValidationGender()
        {
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

            var room = new Room.Library.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                Address = address,
                Vacancy = 1,
                Occupancy = 2,
                //Gender = "M"
            };
            
            Assert.False(room.isValidState());
        }

        [Fact]
        public void TestRoomValidationLocationLimit()
        {
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

            var room = new Room.Library.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Location = "Lorem ipsum dolor sit amet, nonummy ligula volutpat hac integer nonummy. " +
                           "Suspendisse ultricies, congue etiam tellus, erat libero, nulla eleifend, mauris " +
                           "pellentesque. Suspendisse integer praesent vel, integer gravida mauris, fringilla " +
                           "vehicula lacinia non 1",
                Address = address,
                Vacancy = 1,
                Occupancy = 2,
                Gender = ""
            };
            
            Assert.False(room.isValidState());
        }
    }
}
