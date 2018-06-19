using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceHub.Room.Context.Models;
using ServiceHub.Room.Context.Repository;

namespace ServiceHub.Room.Service
{

    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<IRoomsRepository>();

            var data = await context.GetAsync();
            if (data != null && data.Count > 0) return;

            var logger = ServiceLogging.Create();

            try
            {
                // Create several unassigned rooms.
                await context.InsertAsync(new Context.Models.Room()
                {
                    RoomId = Guid.Parse("1f18f932-f624-4639-b21f-0c2926e8f757"),
                    Location = "Reston",
                    Gender = "",
                    Occupancy = 6,
                    Vacancy = 6,
                    Address = new Address()
                    {
                        AddressId = Guid.Parse("8670b8c8-ebc7-4413-9f9c-4ae52957a66d"),
                        Address1 = "15920 Berch Ln",
                        Address2 = "Apt 571",
                        City = "Reston",
                        State = "VA",
                        PostalCode = "50755",
                        Country = "US"
                    }
                });

                await context.InsertAsync(new Context.Models.Room()
                {
                    RoomId = Guid.Parse("ab735b8e-d39e-4f17-87ca-e9ed52324b6c"),
                    Location = "Reston",
                    Gender = "",
                    Occupancy = 4,
                    Vacancy = 4,
                    Address = new Address()
                    {
                        AddressId = Guid.Parse("7bd70d37-0ffc-48da-abdc-0a338c79ee87"),
                        Address1 = "15920 Berch Ln",
                        Address2 = "Apt 399",
                        City = "Reston",
                        State = "VA",
                        PostalCode = "50755",
                        Country = "US"
                    }
                });

                await context.InsertAsync(new Context.Models.Room()
                {
                    RoomId = Guid.Parse("563b842b-9c60-4e45-97c2-2c9533d72073"),
                    Location = "Reston",
                    Gender = "",
                    Occupancy = 3,
                    Vacancy = 3,
                    Address = new Address()
                    {
                        AddressId = Guid.Parse("151912d6-e2ab-470c-9c3b-da69d872e3fc"),
                        Address1 = "13700 Miller Dr",
                        Address2 = "Apt 232",
                        City = "Reston",
                        State = "VA",
                        PostalCode = "72826",
                        Country = "US"
                    }
                });

                await context.InsertAsync(new Context.Models.Room()
                {
                    RoomId = Guid.Parse("4aaa394f-9f18-439e-9c49-88b9e8b5da24"),
                    Location = "Tampa",
                    Gender = "",
                    Occupancy = 2,
                    Vacancy = 2,
                    Address = new Address()
                    {
                        AddressId = Guid.Parse("aa3b3ccc-b698-454e-ac99-675117b1cef1"),
                        Address1 = "4356 Fletcher Ave",
                        Address2 = "Apt 159",
                        City = "Tampa",
                        State = "FL",
                        PostalCode = "81533",
                        Country = "US"
                    }
                });

                await context.InsertAsync(new Context.Models.Room()
                {
                    RoomId = Guid.Parse("cc8a7d63-ddfb-4403-a02a-56285e3c037e"),
                    Location = "Tampa",
                    Gender = "",
                    Occupancy = 4,
                    Vacancy = 4,
                    Address = new Address()
                    {
                        AddressId = Guid.Parse("24add615-3fd9-4054-9b08-66ac6fda0db2"),
                        Address1 = "4356 Fletcher Ave",
                        Address2 = "Apt 232",
                        City = "Tampa",
                        State = "FL",
                        PostalCode = "81533",
                        Country = "US"
                    }
                });

                await context.InsertAsync(new Context.Models.Room()
                {
                    RoomId = Guid.Parse("4ab83c4d-155a-4b49-b7b6-bc58c7b26bdb"),
                    Location = "Tampa",
                    Gender = "",
                    Occupancy = 3,
                    Vacancy = 3,
                    Address = new Address()
                    {
                        AddressId = Guid.Parse("57bce240-48ad-4269-9566-9f2fc2761f97"),
                        Address1 = "98422 Smith Ave",
                        Address2 = "Apt 574",
                        City = "Tampa",
                        State = "FL",
                        PostalCode = "36755",
                        Country = "US"
                    }
                });

                await context.InsertAsync(new Context.Models.Room()
                {
                    RoomId = Guid.Parse("243dc991-44c2-4dba-ad68-80c1d538df27"),
                    Location = "Tampa",
                    Gender = "",
                    Occupancy = 6,
                    Vacancy = 6,
                    Address = new Address()
                    {
                        AddressId = Guid.Parse("96ffb98a-b001-46dd-85bd-76e2bd79eb86"),
                        Address1 = "98422 Smith Ave",
                        Address2 = "Apt 261",
                        City = "Tampa",
                        State = "FL",
                        PostalCode = "36755",
                        Country = "US"
                    }
                });

                await context.InsertAsync(new Context.Models.Room()
                {
                    RoomId = Guid.Parse("eff1ad86-f554-41fe-82fe-09ca9953b661"),
                    Location = "Tampa",
                    Gender = "",
                    Occupancy = 4,
                    Vacancy = 4,
                    Address = new Address()
                    {
                        AddressId = Guid.Parse("0a04cf68-a46e-4d17-b1cb-a5eb912f940d"),
                        Address1 = "53531 Crown Street",
                        Address2 = "Apt 258",
                        City = "Tampa",
                        State = "FL",
                        PostalCode = "38197",
                        Country = "US"
                    }
                });

                await context.InsertAsync(new Context.Models.Room()
                {
                    RoomId = Guid.Parse("e9bba566-55f4-4f00-b83b-40ad6286f73a"),
                    Location = "New York",
                    Gender = "",
                    Occupancy = 6,
                    Vacancy = 6,
                    Address = new Address()
                    {
                        AddressId = Guid.Parse("43694605-d2f9-4979-870d-7b31145f3f71"),
                        Address1 = "24608 Horace Court",
                        Address2 = "Apt 620",
                        City = "New York",
                        State = "NY",
                        PostalCode = "53970",
                        Country = "US"
                    }
                });

                await context.InsertAsync(new Context.Models.Room()
                {
                    RoomId = Guid.Parse("4ceab2c8-9ab4-4140-b84c-42b38485795d"),
                    Location = "New York",
                    Gender = "",
                    Occupancy = 4,
                    Vacancy = 4,
                    Address = new Address()
                    {
                        AddressId = Guid.Parse("7621744b-c5d6-4884-9ac0-fee7d2fffcee"),
                        Address1 = "24608 Horace Court",
                        Address2 = "Apt 145",
                        City = "New York",
                        State = "NY",
                        PostalCode = "53970",
                        Country = "US"
                    }
                });

                await context.InsertAsync(new Context.Models.Room()
                {
                    RoomId = Guid.Parse("1fa895d8-f239-4178-b761-c2dc3ba84524"),
                    Location = "New York",
                    Gender = "",
                    Occupancy = 3,
                    Vacancy = 3,
                    Address = new Address()
                    {
                        AddressId = Guid.Parse("97946ec1-16a2-4298-a42e-c9d1be4f5128"),
                        Address1 = "8015 Pine Street",
                        Address2 = "Apt 562",
                        City = "New York",
                        State = "NY",
                        PostalCode = "25472",
                        Country = "US"
                    }
                });

                await context.InsertAsync(new Context.Models.Room()
                {
                    RoomId = Guid.Parse("4b51ff27-1e3d-4f3f-94d6-f6e1b670a588"),
                    Location = "New York",
                    Gender = "",
                    Occupancy = 5,
                    Vacancy = 5,
                    Address = new Address()
                    {
                        AddressId = Guid.Parse("68e51ff8-bddf-410a-8b06-3d967d3f9a17"),
                        Address1 = "96543 Dare Court",
                        Address2 = "Apt 278",
                        City = "New York",
                        State = "NY",
                        PostalCode = "76458",
                        Country = "US"
                    }
                });
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
            }
        }
    }

}