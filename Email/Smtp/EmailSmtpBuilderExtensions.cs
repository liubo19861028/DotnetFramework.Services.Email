using Dotnet.Services.Email.Core.Interfaces;
using FluentEmail.Smtp;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EmailSmtpBuilderExtensions
    {
        public static EmailServicesBuilder AddSmtpSender(this EmailServicesBuilder builder, SmtpClient smtpClient)
        {
            builder.Services.TryAdd(ServiceDescriptor.Scoped<ISender>(x => new SmtpSender(smtpClient)));
            return builder;
        }

        public static EmailServicesBuilder AddSmtpSender(this EmailServicesBuilder builder, string host, int port) => AddSmtpSender(builder, new SmtpClient(host, port));

        public static EmailServicesBuilder AddSmtpSender(this EmailServicesBuilder builder, Func<SmtpClient> clientFactory)
        {
            builder.Services.TryAdd(ServiceDescriptor.Scoped<ISender>(x => new SmtpSender(clientFactory)));
            return builder;
        }
    }
}
