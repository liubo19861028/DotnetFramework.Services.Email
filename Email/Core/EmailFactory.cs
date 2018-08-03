using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnet.Services.Email.Core
{
    public class EmailFactory : IEmailFactory
    {
        private IServiceProvider services;

        public EmailFactory(IServiceProvider services) => this.services = services;

        public IEmail Create() => services.GetService<IEmail>();
    }
}
