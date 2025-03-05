using System;

public class GitHubConfig
{
    public string BaseUrl { get; set; } = "https://api.github.com";
    public string ApiVersion { get; set; } = "2022-11-28";
    public int RequestTimeoutSeconds { get; set; } = 30;
    public string UserAgent { get; set; } = "GitHubIntegration/1.0";

    public void Validate()
    {
        if (string.IsNullOrEmpty(BaseUrl))
            throw new ArgumentException("BaseUrl cannot be null or empty");
    }
}
