using System;

public class AwsS3Config
{
    public string Region { get; set; } = "us-east-1";
    public int ConnectionTimeoutMs { get; set; } = 30000;
    public int MaxRetryAttempts { get; set; } = 3;
    public long MaxFileSizeBytes { get; set; } = 5368709120; // 5 GB
    public bool ValidateObjects { get; set; } = true;
    public string CloudFrontDistributionId { get; set; }

    public void Validate()
    {
        if (ConnectionTimeoutMs <= 0)
            throw new ArgumentException("ConnectionTimeoutMs must be positive");
        if (MaxRetryAttempts < 0)
            throw new ArgumentException("MaxRetryAttempts cannot be negative");
        if (MaxFileSizeBytes <= 0)
            throw new ArgumentException("MaxFileSizeBytes must be positive");
    }
}
