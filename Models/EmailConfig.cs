using System;
using Microsoft.Extensions.Configuration;

public class EmailConfig
{
    public string SenderEmail { get; set; }
    public string SenderName { get; set; }
    public int MaxRetries { get; set; }
    public int TimeoutSeconds { get; set; }

    public static EmailConfig LoadFromConfiguration(IConfiguration config)
    {
        var section = config.GetSection("Email");
        return new EmailConfig
        {
            SenderEmail = section["SenderEmail"] ?? "noreply@acme.com",
            SenderName = section["SenderName"] ?? "ACME Notifications",
            MaxRetries = int.Parse(section["MaxRetries"] ?? "3"),
            TimeoutSeconds = int.Parse(section["TimeoutSeconds"] ?? "30")
        };
    }
}
