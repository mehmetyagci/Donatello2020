using Donatello2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Donatello2020.Helpers
{
    public class Emails
    {
//        public void SendCardMovedNotification(Models.Card card, Models.Column column)
//        {
//            // send email
//            SmtpClient client = new SmtpClient("someServer");
//            var message = new MailMessage();
//            message.From = new MailAddress("someone@somewhere.com");
//            message.To.Add(column.NotificationEmail);
//            message.Body = $"Hey, {card.Contents} was just moved into {column.Title}, thought you'd
//like to know!";
//message.Subject = "Progress update";
//            client.Send(message);
//        }

        public void SendCardMovedNotification(Card card, Column column)
        {
            //// send email
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("mehmetyagci53@gmail.com", "MyStYeHu_28916");

            var message = new MailMessage();
            message.From = new MailAddress("mehmetyagci53@gmail.com");
            message.To.Add(column.NotificationEmail);
            message.Body = $"Hey, {card.Contents} was just moved into {column.Title}, thought you'd like to know!";
            message.Subject = "Progress update";
            client.Send(message);

            //using (MailMessage mail = new MailMessage())
            //{
            //    mail.From = new MailAddress("mehmetyagci53@gmail.com");
            //    mail.To.Add(column.NotificationEmail);
            //    mail.Subject = "Hello World";
            //    mail.Body = "<h1>Hello</h1>";
            //    mail.IsBodyHtml = true;
            //    //mail.Attachments.Add(new Attachment("C:\\file.zip"));

            //    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            //    {
            //        smtp.Credentials = new NetworkCredential("mehmetyagci53@gmail.com", "MyStYeHu_28916");
            //        smtp.EnableSsl = true;
            //        smtp.Send(mail);
            //    }
            //}
        }
    }
}
