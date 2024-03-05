using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using System;

namespace Swarojgaar.Controllers
{
    public class EmailController : Controller
    {
        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMail([FromBody] MailFormData formData)
        {
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress(formData.from_name, "jobs.mysystem@gmail.com"));
                message.To.Add(MailboxAddress.Parse(formData.to_name));
                message.Subject = formData.subject;
                message.Body = new TextPart("html")
                {
                    Text = formData.message
                };

                string emailAddress = "jobs.mysystem@gmail.com";
                string password = "kgkb skmf zjln ljbt";

                using (SmtpClient client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate(emailAddress, password);
                    client.Send(message);
                    client.Disconnect(true);
                }

                return Json(new { message = "Email sent successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { message = "Error sending email: " + ex.Message });
            }
        }
    }

    public class MailFormData
    {
        public string from_name { get; set; }
        public string to_name { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
    }
}