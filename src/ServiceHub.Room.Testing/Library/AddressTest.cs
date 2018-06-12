using System;
using ServiceHub.Room.Library.Models;
using Xunit;

namespace ServiceHub.Room.Testing.Library
{
    public class AddressTest
    {
        [Fact]
        public void TestAddressValidationAll()
        {
            Address address = new Address();
            
            Assert.False(address.isValidState());
        }

        [Fact]
        public void TestAddressValidationAddressId()
        {
            Address address = new Address
            {
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            Assert.False(address.isValidState());
        }

        [Fact]
        public void TestAddressValidationAddress1()
        {
            Address address = new Address
            {
                AddressId = Guid.NewGuid(),
                //Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };
            
            Assert.False(address.isValidState());
        }

        [Fact]
        public void TestAddressValidationAddress2()
        {
            Address address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                //Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };
            
            Assert.True(address.isValidState());
        }

        [Fact]
        public void TestAddressValidationCity()
        {
            Address address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                //City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };
            
            Assert.False(address.isValidState());
        }

        [Fact]
        public void TestAddressValidationState()
        {
            Address address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                //State = "Ca"
            };
            
            Assert.False(address.isValidState());
        }

        [Fact]
        public void TestAddressValidationStateToLong()
        {
            Address address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Cal"
            };
            
            Assert.False(address.isValidState());
        }

        [Fact]
        public void TestAddressValidationStateToShort()
        {
            Address address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "C"
            };

            Assert.False(address.isValidState());
        }

        [Fact]
        public void TestAddressValidationPostalCode()
        {
            Address address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                //PostalCode = "92646",
                State = "Ca"
            };
            
            Assert.False(address.isValidState());
        }

        [Fact]
        public void TestAddressValidationPostalCodeToLong()
        {
            Address address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "926464",
                State = "Ca"
            };
            
            Assert.False(address.isValidState());
        }

        [Fact]
        public void TestAddressValidationPostalCodeToShort()
        {
            Address address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "9264",
                State = "Ca"
            };
            
            Assert.False(address.isValidState());
        }

        [Fact]
        public void TestAddressValidationCountry()
        {
            Address address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                //Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };
            
            Assert.False(address.isValidState());
        }

        [Fact]
        public void TestAddressValidationCountryToLong()
        {
            Address address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "USa",
                PostalCode = "92646",
                State = "Ca"
            };
            
            Assert.False(address.isValidState());
        }

        [Fact]
        public void TestAddressValidationCountryToShort()
        {
            Address address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "U",
                PostalCode = "92646",
                State = "Ca"
            };
            
            Assert.False(address.isValidState());
        }
    }
}
