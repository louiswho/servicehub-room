using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHub.Room.Context.Repository
{
    /// <summary>
    /// Class to save rooms with an in memory data structure
    /// </summary>
    public class RoomRepositoryMemory:IRoomsRepository
    {
        public List<Models.Room> roomList = new List<Models.Room>();

        /// <summary>
        /// Method for inserting rooms into a list
        /// </summary>
        /// <param name="room"></param>
        public async Task Insert(Models.Room room)
        {
            roomList.Add(room);
        }

        /// <summary>
        /// Method to return all rooms from the list
        /// </summary>
        /// <returns>A list with all rooms within it. Returns an empty list of rooms.</returns>
        public async Task<List<Models.Room>> Get()
        {
            return roomList;
        }

        /// <summary>
        /// Method to return a room by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a Models.Room object. If no room exists it returns null</returns>
        public async Task<Models.Room> GetById(Guid id)
        {
            Models.Room room = roomList.Find(x => x.RoomId == id);
            return room;
        }

        /// <summary>
        /// Updates a Models.Room object. If no room exists based on RoomId then no room is updated.
        /// </summary>
        /// <param name="room"></param>
        public async Task Update(Models.Room room)
        {
            int index = roomList.IndexOf(roomList.Single(x => x.RoomId == room.RoomId));
            if (index >= 0)
            roomList[index] = room;
        }

        /// <summary>
        /// Deletes a Models.Room object from the list based on the Guid.
        /// </summary>
        /// <param name="id"></param>
        public async Task Delete(Guid id)
        {
            roomList.Remove(roomList.Find(x => x.RoomId == id));
        }
    }
}