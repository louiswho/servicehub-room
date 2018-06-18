using System.Collections.Generic;
using ServiceHub.Room.Context.Models;

namespace ServiceHub.Room.Context.Utilities
{
    /// <summary>
    /// Provides mapping between the context and library models.
    /// </summary>
    public static class ModelMapper
    {
        /// <summary>
        /// Converts a library room to a context room.
        /// </summary>
        /// <param name="libraryRoom">Library model Room</param>
        /// <returns>Converted Room context model. Null if given model is invalid and cannot be mapped.</returns>
        public static Models.Room LibraryToContext(Library.Models.Room libraryRoom) {
            if (libraryRoom == null || !libraryRoom.isValidState()) {
                return null;
            }

            return new Models.Room() {
                RoomId = libraryRoom.RoomId,
                Location = libraryRoom.Location,
                Address = LibraryToContext(libraryRoom.Address),
                Vacancy = libraryRoom.Vacancy.Value,
                Occupancy = libraryRoom.Occupancy.Value,
                Gender = libraryRoom.Gender
            };
        }

        /// <summary>
        /// Converts a context room to a library room.
        /// </summary>
        /// <param name="contextRoom">Context model Room</param>
        /// <returns>Converted Room library model. Null if given model is invalid and cannot be mapped.</returns>
        public static Library.Models.Room ContextToLibrary(Models.Room contextRoom) {
            if (contextRoom == null) {
                return null;
            }

            var libRoom = new Library.Models.Room() {
                RoomId = contextRoom.RoomId,
                Location = contextRoom.Location,
                Address = ContextToLibrary(contextRoom.Address),
                Vacancy = contextRoom.Vacancy,
                Occupancy = contextRoom.Occupancy,
                Gender = contextRoom.Gender
            };

            if (!libRoom.isValidState()) {
                return null;
            }

            return libRoom;
        }

        /// <summary>
        /// Converts a list of context rooms to a list of library rooms.
        /// </summary>
        /// <param name="contextRooms">A list of context model Rooms.</param>
        /// <returns>List of converted Room library models. Null if a model in the list is invalid and cannot be mapped.</returns>
        public static List<Library.Models.Room> ContextToLibrary(List<Models.Room> contextRooms) {
            var result = new List<Library.Models.Room>();

            if (contextRooms == null) {
                return result;
            }
            
            foreach (var room in contextRooms) {
                var libRoom = ContextToLibrary(room);
                if (libRoom == null) {
                    return new List<Library.Models.Room>();
                }

                result.Add(libRoom);
            }

            return result;
        }

        /// <summary>
        /// Converts a library address to a context address.
        /// </summary>
        /// <param name="libraryAddress">A library Address model.</param>
        /// <returns>A converted Address context model. Null if the model is invalid and cannot be mapped.</returns>
        private static Address LibraryToContext(Library.Models.Address libraryAddress) {
            if (libraryAddress == null || !libraryAddress.isValidState()) {
                return null;
            }

            return new Address() {
                AddressId = libraryAddress.AddressId,
                Address1 = libraryAddress.Address1,
                Address2 = libraryAddress.Address2,
                City = libraryAddress.City,
                State = libraryAddress.State,
                PostalCode = libraryAddress.PostalCode,
                Country = libraryAddress.Country
            };
        }

        /// <summary>
        /// Converts a context address to a library address.
        /// </summary>
        /// <param name="contextAddress">A context Address model.</param>
        /// <returns>A converted Address library model. Null if the model is invalid and cannot be mapped.</returns>
        private static Library.Models.Address ContextToLibrary(Address contextAddress) {
            if (contextAddress == null) {
                return null;
            }

            var libAddress = new Library.Models.Address() {
                AddressId = contextAddress.AddressId,
                Address1 = contextAddress.Address1,
                Address2 = contextAddress.Address2,
                City = contextAddress.City,
                State = contextAddress.State,
                PostalCode = contextAddress.PostalCode,
                Country = contextAddress.Country
            };

            if (!libAddress.isValidState()) {
                return null;
            }

            return libAddress;
        }
    }
}