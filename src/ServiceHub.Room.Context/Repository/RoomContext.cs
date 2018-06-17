using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task Insert(Models.Room room)
        {
            await _roomRepository.Insert(room);
        }

        /// <summary>
        /// Gets all Models.Room objects from a data source.
        /// </summary>
        /// <returns>Returns all Models.Room objects from the give data source.</returns>
        public async Task<List<Models.Room>> Get()
        {
            return await _roomRepository.Get();
        }

        /// <summary>
        /// Gets a Models.Room objects from a data source.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>>Returns Models.Room objects from the give data source based on the Guid.</returns>
        public async Task<Models.Room> GetById(Guid id)
        {
            return await  _roomRepository.GetById(id);
        }

        /// <summary>
        /// Updates a Models.Room object within the data source.
        /// </summary>
        /// <param name="room"></param>
        public async Task Update(Models.Room room)
        {
            await _roomRepository.Update(room);
        }

        /// <summary>
        /// Deletes a Models.Room object from the data source based on a Guid.
        /// </summary>
        /// <param name="id"></param>
        public async Task Delete(Guid id)
        {
            await _roomRepository.Delete(id);
        }
    }
}