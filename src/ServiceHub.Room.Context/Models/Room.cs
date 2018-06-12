using System;
using MongoDB.Bson.Serialization.Attributes;

namespace ServiceHub.Room.Context.Models
{
    /// <summary>
    /// Room model.
    /// </summary>
    /// <remarks>
    /// This model is for the context and is assumed to be valid.
    /// </remarks>
    public class Room
    {
        ///<summary> Key. Used to uniquely identify this Room model. </summary>
        [BsonId]
        public Guid RoomId { get; set; }

        ///<summary> Name of the training location where this room is
        ///located.  Example: "Reston", "Tampa" or, "Dallas".
        ///</summary>
        public string Location { get; set; }

        ///<summary> This Address model for this room. </summary>
        public Address Address { get; set; }

        ///<summary> Number of unassigned beds in this room. </summary>
        public int Vacancy { get; set; }

        ///<summary> Total number of beds in this room weather assigned or not</summary>
        public int Occupancy { get; set; }

        ///<summary> Sex that this room accommodates. </summary>
        public string Gender { get; set; }
    }
}