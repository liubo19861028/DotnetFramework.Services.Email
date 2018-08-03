using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnet.Services.Email.Core.Models
{
    public class SendRequest
    {
        public string SmtpClientHost { get; set; }
        public string ToEmail { get; set; }
        public string FromEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        /// <summary>
        /// hi @Model.Name 
        /// </summary>
        public string Template { get; set; }

        public object TemplateModel { get; set; }

        public Attachment Attachment { get; set; }

        public System.Net.NetworkCredential NetworkCredential { get; set; }
        public bool EnableSsl { get; set; }
    }
}
