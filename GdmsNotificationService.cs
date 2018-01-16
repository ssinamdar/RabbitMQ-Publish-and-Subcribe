using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GdmsNotificationSubscription
{
    public class GdmsNotificationService
    {
        private readonly IGdmsNotificationCoreHandler _gdmsNotificationCoreHandler;

        public GdmsNotificationService(IGdmsNotificationCoreHandler alertMessageCoreHandler)
        {
            _gdmsNotificationCoreHandler = alertMessageCoreHandler;
        }

        public void Start()
        {
            var gdmsCommandHandler = new GdmsNotificationCommandHandler("CMGGdmsNotificationEndPoint", _gdmsNotificationCoreHandler);
            gdmsCommandHandler.Handle<CreateGdmsNotificationCommand>();
            // _gdmsNotificationCoreHandler.RunTask();
        }
      

        public void Stop()
        {
            string abc = "";
        }
    }
}
