using AutoMapper;
using Contact.API.Infrastructure.Reports;
using EventBus.Messages.Events;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Contact.API.EventBusConsumer
{
    public class LocationReportConsumer : IConsumer<LocationReportEvent>
    {
        private readonly IMapper _mapper;
        private readonly ILocationReportRepository _locationReportRepository;

        public LocationReportConsumer(IMapper mapper, ILocationReportRepository locationReportRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _locationReportRepository = locationReportRepository ?? throw new ArgumentNullException(nameof(locationReportRepository));
        }

        public async Task Consume(ConsumeContext<LocationReportEvent> context)
        {
            await _locationReportRepository.GenerateAndSave(context.Message.LocationReportDetail.Id);
        }
    }
}
