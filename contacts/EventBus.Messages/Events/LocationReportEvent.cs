using System;

namespace EventBus.Messages.Events
{
    public class LocationReportEvent : IntegrationBaseEvent
    {
        public LocationReportDetail LocationReportDetail { get; set; }
    }

    public class LocationReportDetail
    {
        public Guid Id { get; set; }
    }
}
