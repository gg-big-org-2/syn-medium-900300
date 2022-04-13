using System;
using System.Collections.Generic;

public class EmailMessage
{
    public string ToAddress { get; set; }
    public string ToName { get; set; }
    public string Subject { get; set; }
    public string PlainTextBody { get; set; }
    public string HtmlBody { get; set; }
    public Dictionary<string, string> CustomHeaders { get; set; }
    public DateTime? ScheduledSendTime { get; set; }

    public EmailMessage()
    {
        CustomHeaders = new Dictionary<string, string>();
    }

    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(ToAddress) &&
               !string.IsNullOrWhiteSpace(Subject) &&
               (!string.IsNullOrWhiteSpace(PlainTextBody) || !string.IsNullOrWhiteSpace(HtmlBody));
    }
}
