using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using ServiceHub.Room.Context.Utilities;
using ServiceHub.Room.Library.Models;
using Xunit;

namespace ServiceHub.Room.Testing.Context {
    
    public class LibToContextRoomTests {

        [Fact]
        public void NullParameter() {
            Room.Library.Models.Room nullRoom = null;

            var actual = ModelMapper.LibraryToContext(nullRoom);

            Assert.Null(actual);
        }

        [Fact]
        public void EmptyModelInput() {
            var invalidModel = new Room.Library.Models.Room();

            var actual = ModelMapper.LibraryToContext(invalidModel);

            Assert.Null(actual);
        }

        [Fact]
        public void NulledModel() {
            var nulledModel = new Room.Library.Models.Room() {
                RoomId = Guid.Empty,
                Location = null,
                Address = new Address() {
                    AddressId = Guid.Empty,
                    Address1 = null,
                    Address2 = null,
                    City = null,
                    State = null,
                    PostalCode = null,
                    Country = null
                },
                Vacancy = null,
                Occupancy = null,
                Gender = null
            };

            var actual = ModelMapper.LibraryToContext(nulledModel);

            Assert.Null(actual);
        }

        [Fact]
        public void InvalidModelInput() {
            var invalidModel = new Room.Library.Models.Room() {
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                Address = new Address() {
                    AddressId = Guid.NewGuid(),
                    Address1 = "123 Street Ln",
                    Address2 = "",
                    City = "Lutz",
                    State = "FL",
                    PostalCode = "33412",
                    Country = "US"
                },
                Vacancy = -4,
                Occupancy = 6,
                Gender = "M"
            };

            var actual = ModelMapper.LibraryToContext(invalidModel);

            Assert.Null(actual);
        }

        [Fact]
        public void IntsAreNull() {
            var nulledInts = new Room.Library.Models.Room() {
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                Address = new Address() {
                    AddressId = Guid.NewGuid(),
                    Address1 = "123 Street Ln",
                    Address2 = "",
                    City = "Lutz",
                    State = "FL",
                    PostalCode = "33412",
                    Country = "US"
                },
                Vacancy = null,
                Occupancy = null,
                Gender = "M"
            };

            var actual = ModelMapper.LibraryToContext(nulledInts);

            Assert.Null(actual);
        }

        [Fact]
        public void ValidModelInput() {
            var validModel = new Room.Library.Models.Room() {
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                Address = new Address() {
                    AddressId = Guid.NewGuid(),
                    Address1 = "123 Street Ln",
                    Address2 = "",
                    City = "Lutz",
                    State = "FL",
                    PostalCode = "33412",
                    Country = "US"
                },
                Vacancy = 4,
                Occupancy = 6,
                Gender = "M"
            };

            var actual = ModelMapper.LibraryToContext(validModel);

            Assert.Equal(validModel.RoomId, actual.RoomId);
            Assert.Equal(validModel.Location, actual.Location);
            Assert.Equal(validModel.Address.AddressId, actual.Address.AddressId);
            Assert.Equal(validModel.Address.Address1, actual.Address.Address1);
            Assert.Equal(validModel.Address.Address2, actual.Address.Address2);
            Assert.Equal(validModel.Address.City, actual.Address.City);
            Assert.Equal(validModel.Address.State, actual.Address.State);
            Assert.Equal(validModel.Address.PostalCode, actual.Address.PostalCode);
            Assert.Equal(validModel.Address.Country, actual.Address.Country);
            Assert.Equal(validModel.Vacancy, actual.Vacancy);
            Assert.Equal(validModel.Occupancy, actual.Occupancy);
            Assert.Equal(validModel.Gender, actual.Gender);
        }
    }
    
    public class RoomContextToLibTests {

        [Fact]
        public void NullParameter() {
            Room.Context.Models.Room nullRoom = null;

            var actual = ModelMapper.ContextToLibrary(nullRoom);

            Assert.Null(actual);
        }

        [Fact]
        public void EmptyModelInput() {
            Room.Context.Models.Room emptyRoom = new Room.Context.Models.Room();

            var actual = ModelMapper.ContextToLibrary(emptyRoom);

            Assert.Null(actual);
        }

        [Fact]
        public void InvalidModelInput() {
            var invalidModel = new Room.Context.Models.Room() {
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                Address = new Room.Context.Models.Address() {
                    AddressId = Guid.NewGuid(),
                    Address1 = "123 Street Ln",
                    Address2 = "",
                    City = "Lutz",
                    State = "FL",
                    PostalCode = "33412",
                    Country = "US"
                },
                Vacancy = -4,
                Occupancy = 6,
                Gender = "M"
            };

            var actual = ModelMapper.ContextToLibrary(invalidModel);

            Assert.Null(actual);
        }

        [Fact]
        public void ValidModelInput() {
            var validModel = new Room.Context.Models.Room() {
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                Address = new Room.Context.Models.Address() {
                    AddressId = Guid.NewGuid(),
                    Address1 = "123 Street Ln",
                    Address2 = "",
                    City = "Lutz",
                    State = "FL",
                    PostalCode = "33412",
                    Country = "US"
                },
                Vacancy = 4,
                Occupancy = 6,
                Gender = "M"
            };

            var actual = ModelMapper.ContextToLibrary(validModel);

            Assert.Equal(validModel.RoomId, actual.RoomId);
            Assert.Equal(validModel.Location, actual.Location);
            Assert.Equal(validModel.Address.AddressId, actual.Address.AddressId);
            Assert.Equal(validModel.Address.Address1, actual.Address.Address1);
            Assert.Equal(validModel.Address.Address2, actual.Address.Address2);
            Assert.Equal(validModel.Address.City, actual.Address.City);
            Assert.Equal(validModel.Address.State, actual.Address.State);
            Assert.Equal(validModel.Address.PostalCode, actual.Address.PostalCode);
            Assert.Equal(validModel.Address.Country, actual.Address.Country);
            Assert.Equal(validModel.Vacancy, actual.Vacancy);
            Assert.Equal(validModel.Occupancy, actual.Occupancy);
            Assert.Equal(validModel.Gender, actual.Gender);
        }
    }

    public class RoomListContextToLibTests {

        [Fact]
        public void NullParameter() {
            List<Room.Context.Models.Room> nullList = null;

            var actual = ModelMapper.ContextToLibrary(nullList);

            Assert.Null(actual);
        }

        [Fact]
        public void EmptyParameter() {
            List<Room.Context.Models.Room> emptyList = new List<Room.Context.Models.Room>();

            var actual = ModelMapper.ContextToLibrary(emptyList);

            Assert.Empty(actual);
        }

        [Fact]
        public void ContainsInvalid() {
            var ctxRooms = new List<Room.Context.Models.Room>() {
                new Room.Context.Models.Room() {
                    RoomId = Guid.NewGuid(),
                    Location = "Tampa",
                    Address = new Room.Context.Models.Address() {
                        AddressId = Guid.NewGuid(),
                        Address1 = "123 Street Ln",
                        Address2 = "apt 1",
                        City = "Lutz",
                        State = "FL",
                        PostalCode = "33412",
                        Country = null
                    },
                    Vacancy = 4,
                    Occupancy = 6,
                    Gender = "M"
                },
                new Room.Context.Models.Room() {
                    RoomId = Guid.NewGuid(),
                    Location = "Tampa",
                    Address = new Room.Context.Models.Address() {
                        AddressId = Guid.NewGuid(),
                        Address1 = "123 Street Ln",
                        Address2 = "apt 2",
                        City = "Lutz",
                        State = "FL",
                        PostalCode = "33412",
                        Country = "US"
                    },
                    Vacancy = 4,
                    Occupancy = 6,
                    Gender = "F"
                }
            };

            var actual = ModelMapper.ContextToLibrary(ctxRooms);

            Assert.Null(actual);
        }

        [Fact]
        public void ValidModels() {
            var ctxRooms = new List<Room.Context.Models.Room>() {
                new Room.Context.Models.Room() {
                    RoomId = Guid.NewGuid(),
                    Location = "Tampa",
                    Address = new Room.Context.Models.Address() {
                        AddressId = Guid.NewGuid(),
                        Address1 = "123 Street Ln",
                        Address2 = "apt 1",
                        City = "Lutz",
                        State = "FL",
                        PostalCode = "33412",
                        Country = "US"
                    },
                    Vacancy = 4,
                    Occupancy = 6,
                    Gender = "M"
                },
                new Room.Context.Models.Room() {
                    RoomId = Guid.NewGuid(),
                    Location = "Tampa",
                    Address = new Room.Context.Models.Address() {
                        AddressId = Guid.NewGuid(),
                        Address1 = "123 Street Ln",
                        Address2 = "apt 2",
                        City = "Lutz",
                        State = "FL",
                        PostalCode = "33412",
                        Country = "US"
                    },
                    Vacancy = 4,
                    Occupancy = 6,
                    Gender = "F"
                }
            };

            var libRoom1 = ModelMapper.ContextToLibrary(ctxRooms[0]);
            var libRoom2 = ModelMapper.ContextToLibrary(ctxRooms[1]);

            var actual = ModelMapper.ContextToLibrary(ctxRooms);
            
            Assert.Contains(libRoom1.ToJson(), actual.Select(r => r.ToJson()));
            Assert.Contains(libRoom2.ToJson(), actual.Select(r => r.ToJson()));
        }
    }
}