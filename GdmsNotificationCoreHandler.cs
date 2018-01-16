using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GdmsNotificationSubscription
{
    class GdmsNotificationCoreHandler : IGdmsNotificationCoreHandler
    {
        public async Task RunTask()
        {
            await GetScheduledTask();
        }

        private Task GetScheduledTask()
        {
            throw new NotImplementedException();
        }
    }
}
