using System;
using System.Collections.Generic;
using System.Text;
using Dotnet.Services.Email.Core;
using Dotnet.Services.Email.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EmailServiceCollectionExtensions
    {
        public static EmailServicesBuilder AddFluentEmail(this IServiceCollection services, string defaultFromEmail, string defaultFromName = "")
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var builder = new EmailServicesBuilder(services);
            services.TryAdd(ServiceDescriptor.Transient<IEmail>(x => 
                new EmailSend(x.GetService<ITemplateRenderer>(), x.GetService<ISender>(), defaultFromEmail, defaultFromName)
            ));

            services.TryAddTransient<IEmailFactory, EmailFactory>();

            return builder;
        }
    }

    public class EmailServicesBuilder
    {
        public IServiceCollection Services { get; private set; }

        internal EmailServicesBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }
}
