﻿using System;
using System.Linq;
using System.Runtime.Serialization;

namespace ServiceHub.Room.Library.Models
{
    ///<summary> Room model. </summary>
    ///<remarks>This model is for the library and has validation.</remarks>
    public class Room
    {
        /// <summary>
        /// List of valid genders.
        /// </summary>
        /// <remarks>
        /// Empty string means unassigned.
        /// Values are upper case for case insensitivity.
        /// </remarks>
        [IgnoreDataMember]
        private static readonly string[] Genders = { "M", "F", "" };

        ///<summary> Key. Used to uniquely identify this Room model. </summary>
        public Guid RoomId { get; set; }

        ///<summary> Name of the training location where this room is
        ///located.  Example: "Reston", "Tampa" or, "Dallas".
        ///</summary>
        public string Location { get; set; }

        ///<summary> This Address model for this room. </summary>
        public Address Address { get; set; }

        ///<summary> Number of unassigned beds in this room. </summary>
        public int? Vacancy { get; set; }

        ///<summary> Total number of beds in this room weather assigned or not</summary>
        public int? Occupancy { get; set; }

        ///<summary> Sex that this room accommodates. </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Initialize a Room with invalid properties.
        /// </summary>
        public Room() {
            RoomId = Guid.Empty;
            Location = null;
            Address = null;
            Vacancy = null;
            Occupancy = null;
            Gender = null;
        }

        ///<summary> Checks if state of model is valid </summary>
        /// <returns>True if the model is valid, false otherwise.</returns>
        public bool IsValidState()
        {
            if (RoomId == Guid.Empty) { return false; }
            if (string.IsNullOrEmpty(Location) || Location?.Length > 255 || Location?.Length <= 0) { return false; }
            if (Address == null || !Address.IsValidState()) { return false; }
            if (Occupancy == null || Occupancy <= 0) { return false; }
            if (Vacancy == null || Vacancy > Occupancy || Vacancy < 0) { return false; }
            if (Gender == null || !Genders.Contains(Gender.ToUpper())) { return false; }
            
            return true;
        }
    }
}