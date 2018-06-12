using System;
using MongoDB.Bson.Serialization.Attributes;

namespace ServiceHub.Room.Context.Models
{
    /// <summary>
    /// Address model.
    /// </summary>
    /// <remarks>
    /// This model is for the context and is assumed to be valid.
    /// </remarks>
    public class Address
    {
        ///<summary> Key. Used to uniquely identify this Address model. </summary>
        [BsonId]
        public Guid AddressId { get; set; }

        ///<summary> Steet number and street name of this address. </summary>
        public string Address1 { get; set; }

        ///<summary> Apt/Room number for this address if applicable. </summary>
        public string Address2 { get; set; }

        ///<summary> Name of the city for this address. </summary>
        public string City { get; set; }

        ///<summary> Name of the state for this address. </summary>
        public string State { get; set; }

        ///<summary> 5 digit number specifing region. </summary>
        public string PostalCode { get; set; }

        ///<summary> Name of the country for this address. </summary>
        public string Country { get; set; }
    }
}