using System.Collections.Generic;

namespace EventBus.Messages.Events
{
    public class LocationReportEventList : IntegrationBaseEvent
    {
        public List<LocationReportEvent> LocationReportEvents { get; set; }
    }

    public class LocationReportEvent
    {
        public string Location { get; set; }
        public int PeopleCount { get; set; }
        public int PhoneNumberCount { get; set; }
    }
}
