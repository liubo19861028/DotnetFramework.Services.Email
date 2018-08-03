using Dotnet.Services.Email.Core.Interfaces;
using Dotnet.Services.Email.Razor;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EmailRazorBuilderExtensions
    {
        public static EmailServicesBuilder AddRazorRenderer(this EmailServicesBuilder builder)
        {
            builder.Services.TryAdd(ServiceDescriptor.Singleton<ITemplateRenderer, RazorRenderer>());
            return builder;
        }
    }
}
