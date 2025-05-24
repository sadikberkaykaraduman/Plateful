using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Restorant.WebUI.Dtos.MailDtos;
using MailKit.Net.Smtp;

namespace Restorant.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Mail")]
    public class MailController : Controller
    {
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Index")]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Restorant Rezervation", "");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createMailDto.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = createMailDto.Subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("Mail Address", "Google Mail App Password");

            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        }
    }
}