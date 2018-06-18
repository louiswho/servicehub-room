using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHub.Room.Context.Repository
{

    /// <inheritdoc />
    /// <summary>
    /// Class to save rooms with an in memory data structure
    /// </summary>
    public class RoomRepositoryMemory : IRoomsRepository
    {
        public List<Models.Room> roomList = new List<Models.Room>();

        /// <inheritdoc />
        /// <summary>
        /// Method for inserting rooms into a list
        /// </summary>
        /// <param name="room"></param>
        public Task InsertAsync(Models.Room room)
        {
            roomList.Add(room);
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        /// <summary>
        /// Method to return all rooms from the list
        /// </summary>
        /// <returns>A list with all rooms within it. Returns an empty list of rooms.</returns>
        public Task<List<Models.Room>> GetAsync()
        {
            return Task.FromResult(roomList);
        }

        /// <inheritdoc />
        /// <summary>
        /// Method to return a room by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a Models.Room object. If no room exists it returns null</returns>
        public Task<Models.Room> GetByIdAsync(Guid id)
        {
            var room = roomList.Find(x => x.RoomId == id);

            return Task.FromResult(room);
        }

        /// <inheritdoc />
        /// <summary>
        /// Updates a Models.Room object. If no room exists based on RoomId then no room is updated.
        /// </summary>
        /// <param name="room"></param>
        public Task UpdateAsync(Models.Room room)
        {
            var index = roomList.IndexOf(roomList.Single(x => x.RoomId == room.RoomId));
            if (index >= 0)
            {
                roomList[index] = room;
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        /// <summary>
        /// Deletes a Models.Room object from the list based on the Guid.
        /// </summary>
        /// <param name="id"></param>
        public Task DeleteAsync(Guid id)
        {
            roomList.Remove(roomList.Find(x => x.RoomId == id));

            return Task.CompletedTask;
        }
    }

}