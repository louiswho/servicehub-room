﻿using System;
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

        /// <inheritdoc />
        /// <summary>
        /// Creates a room within the MongoDatabase. If the room is null an ArgumentNullException is thrown.
        /// </summary>
        /// <param name="room"></param>
        public async Task InsertAsync(Models.Room room)
        {
            RoomCheck(room);

            await _collection.InsertOneAsync(room);
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets all rooms from the Mongo database.
        /// </summary>
        /// <returns>Returns a list of all the Models.Room within the database. If no rooms are found it returns an ArgumentNullException.</returns>
        public async Task<List<Models.Room>> GetAsync()
        {
            if (_collection == null)
            {
                return new List<Models.Room>();
            }

            return await _collection.AsQueryable().ToListAsync();
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets all rooms from the Mongo database based on the Guid passed in.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a Models.Room object from the database. Returns an ArgumentNullException is the room exists based on the id.</returns>
        public async Task<Models.Room> GetByIdAsync(Guid id)
        {
            GuidCheck(id);

            return await _collection.FindAsync(x => x.RoomId == id).Result.SingleAsync();
        }

        /// <inheritdoc />
        /// <summary>
        /// Updates a Models.Room object in the database based on the RoomId.
        /// If a room object is not passed in an ArgumentNullException is thrown.
        /// If no room object corresponds with the passed in room, no room is updated.
        /// </summary>
        /// <param name="room"></param>
        public async Task UpdateAsync(Models.Room room)
        {
            RoomCheck(room);

            var filter = Builders<Models.Room>.Filter.Eq(x => x.RoomId, room.RoomId);

            var update = Builders<Models.Room>.Update
                .Set(x => x.Location, room.Location)
                .Set(x => x.Gender, room.Gender)
                .Set(x => x.Vacancy, room.Vacancy);

            await _collection.UpdateOneAsync(filter, update);
        }

        /// <inheritdoc />
        /// <summary>
        /// Deletes a Models.Room object in the database based on the RoomId.
        /// If the RoomId is not found an ArgumentNullException is thrown.
        /// </summary>
        /// <param name="id"></param>
        public async Task DeleteAsync(Guid id)
        {
            GuidCheck(id);

            await _collection.DeleteOneAsync(x => x.RoomId == id);
        }

        private void RoomCheck(Models.Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room));
            }
        }

        private void GuidCheck(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException(nameof(id));
            }
        }
    }

}