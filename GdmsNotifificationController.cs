using AutoMapper;
using CMG.Domain.Appraisal.Contracts;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using RabbitMqServiceBus;

namespace CMG.Wholesale.Api.Controllers.Appraisal
{
    [RoutePrefix("api/GdmsNotifification")]
    public class GdmsNotifificationController : ApiController
    {
        private readonly IGdmsNotificationManager _gdmsNotificationManager;
        private readonly IMapper _mapper;
        public GdmsNotifificationController(IGdmsNotificationManager gdmsNotificationManager, IMapper mapper)
        {
            if (gdmsNotificationManager == null) throw new ArgumentNullException(nameof(gdmsNotificationManager));
            _gdmsNotificationManager = gdmsNotificationManager;

            if (mapper == null) throw new ArgumentNullException(nameof(mapper));
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        [ExcludeFromCodeCoverage]
        public async Task<IHttpActionResult> GetUpdatedStatus(HttpRequestMessage httpRequestMessage)
        {
            //Publish RabbitMq queue method()

            await AddPushRequestToQueue("");
            return Ok(HttpStatusCode.OK);

            //Web.Config changes
            /*

             **********Install RabbitMQ and Erlang on the Machine before start coding.**********
             * 
            < section name = "RabbitMqBusConfigurationSection" type = "RabbitMqServiceBus.Configuration.RabbitMqBusConfigurationSection,RabbitMqServiceBus" />


            < RabbitMqBusConfigurationSection >
            < rabbitMqConnection uri = "" vhost = "CMGWholesale" port = "5672" connectionTimeout = "20" userName = "admin" password = "admin" hostname = "blrcswcmgv01" />
            < deadletterexchange exchange = "cmg.exchange.dead" type = "direct" />
            < RabbitMqBusEndPoints >
            < add name = "CMGGdmsNotificationEndPoint" exchange = "cmg.exchange.wholesale" exchangetype = "direct" queue = "cmg-wholesale-CMGGdmsNotification-queue" TTL = "60" durable = "True" routingkey = "GdmsQueue" dead - letter - routing = "True" ></ add >
            < add name = "CMGGdmsNotification-dead-EndPoint" exchange = "cmg.exchange.dead" exchangetype = "direct" queue = "cmg-wholesale-CMGGdmsNotification-dead-queue" TTL = "-1" durable = "True" routingkey = "GdmsQueueDead" dead - letter - routing = "False" ></ add >
            </ RabbitMqBusEndPoints >
            </ RabbitMqBusConfigurationSection > 

                        Dll required to download from the Nuget package in Publish project folder:
                                    RabbitMQ.Client and RabbitMqServiceBus dll (download nuget)


            In Subscribe project install: 
                    Autofac, log4net, RabbitMQ.Client, RabbitMqServerBus, Topshelf and Topshelf.Autofac
                        */
        }

        private async static void AddPushRequestToQueue(string message)
        {
            Guid applicationId = Guid.NewGuid(); //one for an application
            Guid busId = Guid.NewGuid(); //Each instance of publishing bus
            var rmBus = new RabbitMqBus();
            await Task.Run(() => rmBus.SendCommand(new CreateGdmsNotificationCommand(applicationId, Guid.NewGuid(), busId)
            {
                Message = message
            }));
        }
    }
}
