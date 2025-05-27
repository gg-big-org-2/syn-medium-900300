// detector: sendgrid
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

public class EmailService
{
    private string sendgridApiKey;

    public EmailService()
    {
        var client = new SendGridClient(sendgridApiKey);
    }

    public async Task SendWelcomeEmailAsync(string recipientEmail, string name)
    {
        var from = new EmailAddress("noreply@acme.com", "ACME Team");
        var to = new EmailAddress(recipientEmail, name);
        var subject = "Welcome to ACME!";
        var plainTextContent = $"Hi {name}, welcome aboard.";
        var htmlContent = $"<strong>Hi {name}, welcome aboard.</strong>";
        var msg = new SendGridMessage()
        {
            From = from,
            Subject = subject,
            PlainTextContent = plainTextContent,
            HtmlContent = htmlContent
        };
        msg.AddTo(to);
        var response = await new SendGridClient(sendgridApiKey).SendEmailAsync(msg);
    }
}
