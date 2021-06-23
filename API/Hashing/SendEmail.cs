using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using API.Models;

namespace API.Hashing
{
    public class SendEmail
    {
        public static void Receive(Account account, string GUID)
        {

            var fromAddress = new MailAddress("pandanaran1000@gmail.com");
            var fromPassword = "!23456Qwerty";
            var toAddress = new MailAddress(account.Employee.Email);

            string subject = "Reset Kata Sandi";
            string body = FormatText(account, GUID);
                

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            })

                smtp.Send(message);

        }

        public static string FormatText(Account account, string GUID)
        {
            return "<div style='border - style:solid; border - width:thin; border - color:#dadce0;border-radius:8px;padding:40px 20px' align='center'" +
                $"<h1>Halo { account.Employee.FirstName}</h1><br>" +
                $"<h3>Anda Telah melakukan permintaan reset kata sandi pada {DateTime.Now}<br>" +
                $"Berikut Kata sandi baru anda : {GUID}</h3></div>";
            }
    }
}
