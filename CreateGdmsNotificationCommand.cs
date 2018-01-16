using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using RabbitMqServiceBus;

namespace GdmsNotificationSubscription
{
    [CommandMetaData("CMGGdmsNotificationEndPoint")]
    public class CreateGdmsNotificationCommand : BaseCommand
    {
        public CreateGdmsNotificationCommand(Guid applicationId, Guid commandId, Guid busId)
            : base(applicationId, commandId, busId)
        {
        }

        public override string ToString()
        {
            return $"ApplicationId:{ApplicationId} commandId:{CommandId} busId:{BusId}";
        }
    }
}
