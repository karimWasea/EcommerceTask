//using Microsoft.AspNetCore.Http;
//using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity.UI.Services;

namespace Utailitze
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}