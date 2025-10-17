
using MailKit.Net.Smtp;
using MimeKit;

namespace Email
{
    public class EmailService
    {

        public void SendEmail(string accountName, string accountEmail)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Anime List Account", "do-not-reply@anime.com"));
            message.To.Add(new MailboxAddress("Account Owner", accountEmail)); 
            message.Subject = "Account Creation";

            var htmlBody = $@"
            <html>
                <body style='font-family: Arial, sans-serif; background-color: #f9f9f9; color: #333;'>
                    <div style='max-width: 500px; margin: 30px auto; background: #fff; padding: 20px; border-radius: 8px; box-shadow: 0 2px 8px rgba(0,0,0,0.1);'>
                        <h2 style='color: #4a90e2;'>Anime List Manager</h2>
                        <p>Hello, <strong>{accountName}</strong>!</p>
                        <p>Your account has been successfully created.</p>
                        <p><strong>Account Name:</strong> {accountName}<br>
                           <strong>Email:</strong> {accountEmail}<br>
                           <strong>Created On:</strong> {DateTime.Now}</p>
                        <p style='margin-top: 20px;'>Regards,<br><strong>Anime List Manager</strong></p>
                    </div>
                </body>
            </html>";

            message.Body = new TextPart("html") { Text = htmlBody };
            //message.Body = new TextPart("plain")
            //{
            //    Text = $"Hello, " + accountName + "\n\nA new account has been created.\nAccount Name: " + accountName + "\nAccount Email: " + accountEmail + "\nCreation Time:" + DateTime.Now + "\n\nRegards,\nAnime Manager",
            //};
            using (var client = new SmtpClient())
            {
                var smtpHost = "sandbox.smtp.mailtrap.io";
                var smtpPort = 2525;
                var tls = MailKit.Security.SecureSocketOptions.StartTls;
                client.Connect(smtpHost, smtpPort, tls);
                var userName = "e4cc4a33c8f7f7";
                var password = "7cafac45ebbe50";
                client.Authenticate(userName, password);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}