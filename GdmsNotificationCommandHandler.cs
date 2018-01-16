using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RabbitMqServiceBus;

namespace GdmsNotificationSubscription
{
    public class GdmsNotificationCommandHandler : BaseCommandHandler
    {
        private readonly IGdmsNotificationCoreHandler _gdmsNotificationCoreHandler;

        public GdmsNotificationCommandHandler(string key, IGdmsNotificationCoreHandler alertMessageCoreHandler)
            : base(key)
        {
            
            _gdmsNotificationCoreHandler = alertMessageCoreHandler;
        }

        public override void ProcessMessage<T>(T command)
        {
            try
            {
                var createLockExpiryAlertMessageCommand = command as CreateGdmsNotificationCommand;
              
             //   _gdmsNotificationCoreHandler.RunTask();
                    if (createLockExpiryAlertMessageCommand != null)
                        this.ProcessPushNotificationRequest(createLockExpiryAlertMessageCommand.Message);
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }
        }

        private void ProcessPushNotificationRequest(string message)
        {
            string url = ConfigurationManager.AppSettings["url"];
            url = url + message;
            HttpClient client = new HttpClient { BaseAddress = new Uri(url) };
            var data = new StringContent(message, //<--Extension method here
             encoding: Encoding.UTF8,
             mediaType: "application/json");
            var httpResponse = client.PostAsync(url, data);

        }
    }
}
