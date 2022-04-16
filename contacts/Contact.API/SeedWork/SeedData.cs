using Contact.API.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using SharedLibrary.Model;
using System.Collections.Generic;

namespace Contact.API.SeedWork
{

    public static class SeedDataExtension
    {
        public static IHost SeedData(this IHost host)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var client = new MongoClient(config.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(config.GetValue<string>("DatabaseSettings:DatabaseName"));

            var contacts = database.GetCollection<ContactModel>(config.GetValue<string>("DatabaseSettings:ContactCollection"));

            bool existContact = contacts.Find(p => true).Any();
            if (!existContact)
                contacts.InsertManyAsync(GetPreconfiguredContacts());

            var reports = database.GetCollection<LocationReportModel>(config.GetValue<string>("DatabaseSettings:ReportCollection"));
            bool existReport = reports.Find(p => true).Any();
            if (!existReport)
            {
                reports.InsertOneAsync(GetPreconfiguredReport());
            }

            return host;
        }


        private static IEnumerable<ContactModel> GetPreconfiguredContacts()
        {
            return new List<ContactModel>()
            {
                new ContactModel()
                {
                    UUID = "602d2149e773f2a3990b4711",
                    Name = "Halil",
                    LastName = "Koca",
                    Firm = "Setur",
                    CreatedOn = System.DateTime.UtcNow,
                    ContactInformations = new List<ContactInformationModel>
                    {
                        new ContactInformationModel
                        {
                            UUID = "602d2149e773f2a3990b4712",
                            CreatedOn = System.DateTime.UtcNow,
                            Type = InformationType.PhoneNumber,
                            Value = "+905327320230"
                        },
                        new ContactInformationModel
                        {
                            UUID = "602d2149e773f2a3990b4713",
                            CreatedOn = System.DateTime.UtcNow,
                            Type = InformationType.EmailAddress,
                            Value = "ihalilkoca@gmail.com"
                        },
                        new ContactInformationModel
                        {
                            UUID = "602d2149e773f2a3990b4714",
                            CreatedOn = System.DateTime.UtcNow,
                            Type = InformationType.Location,
                            Value = "İstanbul"
                        }
                    }
                },
                new ContactModel()
                {
                    UUID = "602d2149e773f2a3990b4715",
                    Name = "Fatma",
                    LastName = "Acar",
                    Firm = "Setur",
                    CreatedOn = System.DateTime.UtcNow,
                    ContactInformations = new List<ContactInformationModel>
                    {
                        new ContactInformationModel
                        {
                            UUID = "602d2149e773f2a3990b4716",
                            CreatedOn = System.DateTime.UtcNow,
                            Type = InformationType.PhoneNumber,
                            Value = "+905327320231"
                        },
                        new ContactInformationModel
                        {
                            UUID = "602d2149e773f2a3990b4717",
                            CreatedOn = System.DateTime.UtcNow,
                            Type = InformationType.EmailAddress,
                            Value = "fatmaacar@gmail.com"
                        },
                        new ContactInformationModel
                        {
                            UUID = "602d2149e773f2a3990b4718",
                            CreatedOn = System.DateTime.UtcNow,
                            Type = InformationType.Location,
                            Value = "İstanbul"
                        }
                    }
                },
                new ContactModel()
                {
                    UUID = "602d2149e773f2a3990b4719",
                     Name = "Özde",
                    LastName = "Acarkan",
                    Firm = "Setur",
                    CreatedOn = System.DateTime.UtcNow,
                    ContactInformations = new List<ContactInformationModel>
                    {
                        new ContactInformationModel
                        {
                            UUID = "602d2149e773f2a3990b4720",
                            CreatedOn = System.DateTime.UtcNow,
                            Type = InformationType.PhoneNumber,
                            Value = "+905327320233"
                        },
                        new ContactInformationModel
                        {
                            UUID = "602d2149e773f2a3990b4721",
                            CreatedOn = System.DateTime.UtcNow,
                            Type = InformationType.EmailAddress,
                            Value = "ozdeacarkan@gmail.com"
                        },
                        new ContactInformationModel
                        {
                            UUID = "602d2149e773f2a3990b4722",
                            CreatedOn = System.DateTime.UtcNow,
                            Type = InformationType.Location,
                            Value = "Muğla"
                        }
                    }
                },
                new ContactModel()
                {
                    UUID = "602d2149e773f2a3990b4723",
                     Name = "Atahan",
                    LastName = "Adanır",
                    Firm = "Setur",
                    CreatedOn = System.DateTime.UtcNow,
                    ContactInformations = new List<ContactInformationModel>
                    {
                        new ContactInformationModel
                        {
                            UUID = "602d2149e773f2a3990b4724",
                            CreatedOn = System.DateTime.UtcNow,
                            Type = InformationType.PhoneNumber,
                            Value = "+905327320234"
                        },
                        new ContactInformationModel
                        {
                            UUID = "602d2149e773f2a3990b4725",
                            CreatedOn = System.DateTime.UtcNow,
                            Type = InformationType.EmailAddress,
                            Value = "atahanadanir@gmail.com"
                        },
                        new ContactInformationModel
                        {
                            UUID = "602d2149e773f2a3990b4726",
                            CreatedOn = System.DateTime.UtcNow,
                            Type = InformationType.Location,
                            Value = "İzmir"
                        }
                    }
                },
                new ContactModel()
                {
                    UUID = "602d2149e773f2a3990b4727",
                     Name = "Hacı Mehmet",
                    LastName = "Adıgüzel",
                    Firm = "Setur",
                    CreatedOn = System.DateTime.UtcNow,
                    ContactInformations = new List<ContactInformationModel>
                    {
                        new ContactInformationModel
                        {
                            UUID = "602d2149e773f2a3990b4728",
                            CreatedOn = System.DateTime.UtcNow,
                            Type = InformationType.PhoneNumber,
                            Value = "+905327320235"
                        },
                        new ContactInformationModel
                        {
                            UUID = "602d2149e773f2a3990b4729",
                            CreatedOn = System.DateTime.UtcNow,
                            Type = InformationType.EmailAddress,
                            Value = "hacimehmetadiguzel@gmail.com"
                        },
                        new ContactInformationModel
                        {
                            UUID = "602d2149e773f2a3990b4730",
                            CreatedOn = System.DateTime.UtcNow,
                            Type = InformationType.Location,
                            Value = "Ankara"
                        }
                    }
                },
                new ContactModel()
                {
                    UUID = "602d2149e773f2a3990b4731",
                    Name = "Mükerrem Zeynep",
                    LastName = "Ağca",
                    Firm = "Setur",
                    CreatedOn = System.DateTime.UtcNow,
                    ContactInformations = new List<ContactInformationModel>
                    {
                        new ContactInformationModel
                        {
                            UUID = "602d2149e773f2a3990b4732",
                            CreatedOn = System.DateTime.UtcNow,
                            Type = InformationType.PhoneNumber,
                            Value = "+905327320236"
                        },
                        new ContactInformationModel
                        {
                            UUID = "602d2149e773f2a3990b4733",
                            CreatedOn = System.DateTime.UtcNow,
                            Type = InformationType.EmailAddress,
                            Value = "mukerremzeynepagca@gmail.com"
                        },
                        new ContactInformationModel
                        {
                            UUID = "602d2149e773f2a3990b4734",
                            CreatedOn = System.DateTime.UtcNow,
                            Type = InformationType.Location,
                            Value = "Ankara"
                        }
                    }
                }
            };
        }

        private static LocationReportModel GetPreconfiguredReport()
        {
            return new LocationReportModel
            {
                CreatedOn = System.DateTime.UtcNow,
                Status = ReportStatus.Preparing
            };
        }
    }
}
