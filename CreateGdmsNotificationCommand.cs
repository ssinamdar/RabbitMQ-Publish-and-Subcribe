using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RabbitMqServiceBus;

namespace CMG.Wholesale.Api.Controllers.Appraisal
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