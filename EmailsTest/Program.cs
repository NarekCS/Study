using MailKit.Net.Smtp;
using MimeKit;
using System;


namespace EmailsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Admin",
            "narekavanesyancs@gmail.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("User",
            "hayqpoghosyan@gmail.com");
            message.To.Add(to);

            message.Subject = "This is email subject";
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<h1>Hello World!</h1>";
            bodyBuilder.TextBody = "Hello World!";
            message.Body = bodyBuilder.ToMessageBody();
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 465, true);
            client.Authenticate("narekavanesyancs@gmail.com", "NarekCS2018");

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
            Console.WriteLine("sent");
        }
    }
}
