using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Contact.API.EventBusConsumer
{
    public class LocationReportConsumer : IConsumer<LocationReportEventList>
    {
        private readonly IMapper _mapper;

        public LocationReportConsumer(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Consume(ConsumeContext<LocationReportEventList> context)
        {
            // burada generate et ve db ye kaydet
        }
    }
}
