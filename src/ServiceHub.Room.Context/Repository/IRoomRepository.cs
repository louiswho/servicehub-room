using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceHub.Room.Context.Repository
{
    public interface IRoomsRepository
    {
        /// <summary>
        /// Interface for the CRUD functionality of the Room repository
        /// </summary>
        /// <param name="room"></param>
        Task Insert(Models.Room room);
        Task<List<Models.Room>> Get();
        Task<Models.Room> GetById(Guid id);
        Task Update(Models.Room room);
        Task Delete(Guid id);
    }
}