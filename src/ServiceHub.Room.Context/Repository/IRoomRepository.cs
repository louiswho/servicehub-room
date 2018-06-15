using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceHub.Room.Context.Repository
{
    public interface IRoomsRepository
    {
        /// <summary>
        /// Interface for the CRUD functionality of the Room repository
        /// </summary>
        /// <param name="room"></param>
        void Insert(Models.Room room);
        List<Models.Room> Get();
        Models.Room GetById(Guid id);
        void Update(Models.Room room);
        void Delete(Guid id);

    }
}