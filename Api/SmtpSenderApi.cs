using Dotnet.Services.Base;
using Dotnet.Services.Email.Core;
using Dotnet.Services.Email.Core.Models;
using Dotnet.Utility;
using FluentEmail.Smtp;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.Services.Email.Api
{
    [Route("SmtpSenderApi")]
    public class SmtpSenderApiController : BaseApiController
    {
        public void Initialize(SendRequest sendRequest)
        {
            if(sendRequest.NetworkCredential==null)
            {
                sendRequest.NetworkCredential = new System.Net.NetworkCredential(AppSettingsUtil.GetString("email.username"), AppSettingsUtil.GetString("email.password"));
            }

            var sender = new SmtpSender(() => new SmtpClient(sendRequest.SmtpClientHost)
            {
                EnableSsl = sendRequest.EnableSsl,
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                Credentials= sendRequest.NetworkCredential
            });

            EmailSend.DefaultSender = sender;
        }


        [HttpPost]
        [Route("Send")]
        public async Task<IActionResult> Send(SendRequest sendRequest)
        {
            //初使化
            Initialize(sendRequest);

            var email = EmailSend
               .From(sendRequest.FromEmail)
               .To(sendRequest.ToEmail)
               .Body(sendRequest.Body, true);

            //使用模板发送
            if(sendRequest.TemplateModel!=null && !string.IsNullOrEmpty(sendRequest.Template))
            {
                email.UsingTemplate(sendRequest.Template, sendRequest.TemplateModel);
            }

            //发送附件
            if(sendRequest.Attachment!=null)
            {
                email.Attach(sendRequest.Attachment);
            }

            var response = await email.SendAsync();

            return new JsonResult(response);
        }



        
    }
}
