using Contact.API.Infrastructure.Contacts;
using Contact.API.Model;
using Contact.API.Test;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Report.API.Test
{
    public class ContactApiTest
    {
        IServiceProvider services;
        private readonly IContactRepository _contactRepository;

        public ContactApiTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMock<IContactRepository>();
            services = serviceCollection.BuildServiceProvider();
            _contactRepository = services.GetService<IContactRepository>();
        }

        [Theory]
        [InlineData("625bde1b3e26d37f227081ff")]
        public async Task Generate_Successfully(string contactId)
        {
            var response = Setup_Model();
            services.GetMock<IContactRepository>()
                .Setup(x => x.Get(It.IsAny<string>()))
                .Returns(Task.FromResult(response));

            await _contactRepository.Get(contactId);
        }

        private ContactModel Setup_Model()
        {
            return new ContactModel
            {
                UUID = "625bde1b3e26d37f227081ff",
                CreatedOn = DateTime.UtcNow,
                Name = "Halil Koca",
                Firm = "Setur"
            };
        }
    }
}
