using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using ServiceHub.Room.Context.Models;

namespace ServiceHub.Room.Context.Repository
{
    public class RoomsRepository: IRoomsRepository
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
        public void Insert(Models.Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room));
            }
            _collection.InsertOne(room);
        }

        /// <summary>
        /// Gets all rooms from the Mongo database.
        /// </summary>
        /// <returns>Returns a list of all the Models.Room within the database. If no rooms are found it returns an ArgumentNullException.</returns>
        public List<Models.Room> Get()
        {
            if (_collection == null)
            {
                throw new ArgumentNullException(nameof(_collection));
            }

            return _collection.AsQueryable().ToList();

        }

        /// <summary>
        /// Gets all rooms from the Mongo database based on the Guid passed in.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a Models.Room object from the database. Returns an ArgumentNullException is the room exists based on the id.</returns>
        public Models.Room GetById(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            Models.Room room = _collection.Find(x => x.RoomId == id).Single();
            return room;

        }

        /// <summary>
        /// Updates a Models.Room object in the database based on the RoomId.
        /// If a room object is not passed in an ArgumentNullException is thrown.
        /// If no room object corresponds with the passed in room, no room is updated.
        /// </summary>
        /// <param name="room"></param>
        public void Update(Models.Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room));
            }

            _collection.FindOneAndReplace(x => x.RoomId == room.RoomId, room);
        }

        /// <summary>
        /// Deletes a Models.Room object in the database based on the RoomId.
        /// If the RoomId is not found an ArgumentNullException is thrown.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            _collection.DeleteOne(x => x.RoomId == id);
        }
    }
}