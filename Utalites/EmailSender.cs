using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;

using System.ComponentModel.DataAnnotations;


namespace Utalites
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}