using Assingment.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Assingment.PL.Helper
{
    public class EmailSettings
    {
       public static void SendEmail(Email email)
       {
            var client = new SmtpClient("smtp.ethereal.email", 587);
            client.EnableSsl = true;

            client.Credentials = new NetworkCredential("matilde.quigley25@ethereal.email", "G7HFaf71KmsgRjyuFe");
            client.Send("ahmed@gmail.com", email.To, email.Title, email.Body);

        }
    }
}
