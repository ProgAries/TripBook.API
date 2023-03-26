using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TripBook.BLL.Interfaces;
using TripBook.DAL.Configurations.Mail;
using TripBook.Mailer.IL.Messages;

namespace TripBook.Mailer.IL.Services
{
    public class MailService : IMailService
    {
        private MailConfig _config;
        private SmtpClient _client;
        string AdminMail = "makerhub.antonio@gmail.com";

        public MailService(MailConfig config, SmtpClient client)
        {
            _config = config;
            _client = client;

            client.Host = config.Host;
            client.Port = config.Port;
            client.Credentials = new NetworkCredential(
                config.Email, config.Password
            );
            _client.EnableSsl = true;
        }

        public void SendConfirmationMail(string memberMail)
        {

            //create a confirmation mail
            MailMessenger msg = new MailMessenger();
            MailMessage message = new MailMessage();
            message.From = new MailAddress(_config.Email);
            message.To.Add(memberMail);
            message.Subject = msg.Subject();
            message.Body = msg.Content(); ;
            _client.Send(message);

        }
    }
}
