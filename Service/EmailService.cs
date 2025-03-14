using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Microsoft.Extensions.Options;

//Lecture Code adapted to my usecase
public class EmailService
{
    private readonly EmailSettings _emailSettings;
    public EmailService(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }
    public void SendverificationEmail(string RecipientEmail, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Fast Food Delievery App", _emailSettings.SmtpUsername));
        message.To.Add(new MailboxAddress("", RecipientEmail));
        message.Subject = subject;
        var textPart = new TextPart("plain")
        {
            Text = body
        };
        message.Body = textPart;
        using (var client = new SmtpClient())
        {
            client.Connect(_emailSettings.SmtpServer, _emailSettings.SmtpPort,
           SecureSocketOptions.StartTls);
            client.Authenticate(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword);
            client.Send(message);
            client.Disconnect(true);
        }
    }
}
