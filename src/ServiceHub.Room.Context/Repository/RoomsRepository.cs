using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace ServiceHub.Room.Context.Repository
{

    public class RoomsRepository : IRoomsRepository
    {
        private readonly IMongoCollection<Models.Room> _collection;

        /// <summary>
        /// Instantiates the IMongoCollection and sets the readonly _collection property
        /// to the returned Mongo Collection object.
        /// </summary>
        /// <param name="collection"></param>
        public RoomsRepository(IMongoCollection<Models.Room> collection)
        {
            _collection = collection;
        }

        /// <summary>
        /// Creates a room within the MongoDatabase. If the room is null an ArgumentNullException is thrown.
        /// </summary>
        /// <param name="room"></param>
        public async Task InsertAsync(Models.Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room));
            }

            await _collection.InsertOneAsync(room);
        }

        /// <summary>
        /// Gets all rooms from the Mongo database.
        /// </summary>
        /// <returns>Returns a list of all the Models.Room within the database. If no rooms are found it returns an ArgumentNullException.</returns>
        public async Task<List<Models.Room>> GetAsync()
        {
            if (_collection == null)
            {
                throw new ArgumentNullException(nameof(_collection));
            }

            return await _collection.AsQueryable().ToListAsync();
        }

        /// <summary>
        /// Gets all rooms from the Mongo database based on the Guid passed in.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a Models.Room object from the database. Returns an ArgumentNullException is the room exists based on the id.</returns>
        public async Task<Models.Room> GetByIdAsync(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await _collection.FindAsync(x => x.RoomId == id).Result.SingleAsync();
        }

        /// <summary>
        /// Updates a Models.Room object in the database based on the RoomId.
        /// If a room object is not passed in an ArgumentNullException is thrown.
        /// If no room object corresponds with the passed in room, no room is updated.
        /// </summary>
        /// <param name="room"></param>
        public async Task UpdateAsync(Models.Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room));
            }

            var filter = Builders<Models.Room>.Filter.Eq(x => x.RoomId, room.RoomId);

            var update = Builders<Models.Room>.Update
                .Set(x => x.Location, room.Location)
                .Set(x => x.Gender, room.Gender)
                .Set(x => x.Vacancy, room.Vacancy);

            await _collection.UpdateOneAsync(filter, update);
        }

        /// <summary>
        /// Deletes a Models.Room object in the database based on the RoomId.
        /// If the RoomId is not found an ArgumentNullException is thrown.
        /// </summary>
        /// <param name="id"></param>
        public async Task DeleteAsync(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            await _collection.DeleteOneAsync(x => x.RoomId == id);
        }
    }

}