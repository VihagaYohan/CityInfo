using Microsoft.Extensions.Configuration;
using System;

namespace CityInfo.API.Services
{
    public class LocalMailService : ILocalMainService
    {
        private readonly IConfiguration _configuration;

        public LocalMailService(IConfiguration configuration) {
            this._configuration = configuration;
        }

        public bool SendMail()
        {
            var fromEmail = _configuration["MailSettings:FromEmail"];
            Console.WriteLine($"Mail sent from {fromEmail}");
            return true;
        }
    }
}
