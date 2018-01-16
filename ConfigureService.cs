using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Autofac;

namespace GdmsNotificationSubscription
{
    internal static class ConfigureService
    {
        internal static void Configure()
        {

            ModuleConfiguration.ConfigureModules();
            HostFactory.Run(configure =>
            {
                configure.UseAutofacContainer(ModuleConfiguration.Container);
                //configure.UseLog4Net();
                configure.Service<GdmsNotificationService>(service =>
                {
                    service.ConstructUsingAutofacContainer();
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });
                //Setup Account that window service use to run.  
                configure.RunAsLocalSystem();
                configure.StartAutomatically();
                configure.SetServiceName("CMGWholesaleGdmsMessageService");
                configure.SetDisplayName("CMG.Wholesale.GdmsMessageService");
                configure.SetDescription("CMG.Wholesale.GdmsMessageService");
                configure.EnableServiceRecovery(rc => rc.RestartService(5));
            });
        }
    }
}
