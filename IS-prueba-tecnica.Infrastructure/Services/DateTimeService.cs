using IS_prueba_tecnica.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS_prueba_tecnica.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        private readonly string TimeZoneId;

        public DateTimeService()
        {
            TimeZoneId = "Romance Standard Time";
        }

        public DateTime UtcNow => DateTime.UtcNow;

        public DateTime Now => GetDateTime();

        private DateTime GetDateTime()
        {
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(UtcNow, TimeZoneId);
        }
    }
}
