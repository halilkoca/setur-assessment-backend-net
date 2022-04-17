using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;

namespace Contact.API.Test
{
    public static class MockExtension
    {
        public static Mock<T> AddMock<T>(this IServiceCollection services, bool callbase = false) where T : class
        {
            var mock = new Mock<T>
            {
                CallBase = callbase,
            };
            services.AddSingleton(mock);
            services.AddSingleton(mock.Object);
            return mock;
        }

        public static Mock<T> GetMock<T>(this IServiceProvider serviceProvider) where T : class
        {
            return serviceProvider.GetService<Mock<T>>();
        }
    }
}
