using System;

public class UploadResult
{
    public string Key { get; set; }
    public string ETag { get; set; }
    public long FileSizeBytes { get; set; }
    public DateTime UploadedAt { get; set; }
    public string VersionId { get; set; }
    public bool Success { get; set; }
    public string ErrorMessage { get; set; }

    public UploadResult(string key)
    {
        Key = key;
        UploadedAt = DateTime.UtcNow;
    }
}
