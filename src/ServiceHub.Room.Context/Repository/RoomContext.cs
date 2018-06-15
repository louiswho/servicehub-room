using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceHub.Room.Context.Repository
{
    public class RoomContext
    {
        private readonly IRoomsRepository _roomRepository;

        /// <summary>
        /// Instantiates a IRoomsRepository object for CRUD functionality on a data source.
        /// </summary>
        /// <param name="roomRepository"></param>
        public RoomContext(IRoomsRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        /// <summary>
        /// Creates a Models.Room object in the data source.
        /// </summary>
        /// <param name="room"></param>
        public void Insert(Models.Room room)
        {
            _roomRepository.Insert(room);
        }

        /// <summary>
        /// Gets all Models.Room objects from a data source.
        /// </summary>
        /// <returns>Returns all Models.Room objects from the give data source.</returns>
        public List<Models.Room> Get()
        {
            return _roomRepository.Get();
        }

        /// <summary>
        /// Gets a Models.Room objects from a data source.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>>Returns Models.Room objects from the give data source based on the Guid.</returns>
        public Models.Room GetById(Guid id)
        {
            return _roomRepository.GetById(id);
        }

        /// <summary>
        /// Updates a Models.Room object within the data source.
        /// </summary>
        /// <param name="room"></param>
        public void Update(Models.Room room)
        {
            _roomRepository.Update(room);
        }

        /// <summary>
        /// Deletes a Models.Room object from the data source based on a Guid.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid id)
        {
            _roomRepository.Delete(id);
        }

    }
}