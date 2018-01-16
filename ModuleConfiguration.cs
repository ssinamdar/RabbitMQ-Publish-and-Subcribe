using System;
using Autofac;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GdmsNotificationSubscription
{
    internal class ModuleConfiguration
    {
        public static IContainer Container { get; private set; }
        public static void ConfigureModules()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<GdmsNotificationCoreHandler>().As<IGdmsNotificationCoreHandler>();
            //builder.RegisterType<AlertsJobHandler>().As<IJobHandler>();
            //builder.RegisterType<ServiceFactory>().As<IServiceFactory>();
            //builder.RegisterType<LockAlertDataAdapter>().As<ILockAlertDataAdapter>();
            //builder.RegisterType<LockAlertExpiryVisitor>().As<ILockAlertVisitor>();
            //builder.RegisterType<LockAlertUserVisitor>().As<ILockAlertVisitor>();
            //builder.RegisterType<LockAlertMessageManager>().As<ILockAlertMessageManager>();
            //builder.RegisterType<HandleJobFailure>().As<IJobFailure>();
            //builder.RegisterType<EncryptionCore>().As<IEncryptionCore>();
            //builder.RegisterType<EncryptionHelper>().As<IEncryptionHelper>();
            //builder.RegisterType<DataProtection>().As<IDataProtection>();
            builder.RegisterType<GdmsNotificationService>();
            Container = builder.Build();
        }
    }
}
