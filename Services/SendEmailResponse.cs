using System;

public class SendEmailResponse
{
    public bool IsSuccessful { get; set; }
    public int StatusCode { get; set; }
    public string MessageId { get; set; }
    public string ErrorMessage { get; set; }
    public DateTime SentAt { get; set; }

    public SendEmailResponse()
    {
        IsSuccessful = false;
        SentAt = DateTime.UtcNow;
    }

    public static SendEmailResponse CreateSuccess(int statusCode, string messageId)
    {
        return new SendEmailResponse { IsSuccessful = true, StatusCode = statusCode, MessageId = messageId };
    }

    public static SendEmailResponse CreateError(string errorMessage)
    {
        return new SendEmailResponse { ErrorMessage = errorMessage };
    }
}
