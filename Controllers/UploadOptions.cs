using System.Collections.Generic;

public class UploadOptions
{
    public string BucketName { get; set; }
    public string Region { get; set; } = "us-east-1";
    public string UploadDirectory { get; set; }
    public int MaxConcurrentUploads { get; set; } = 5;
    public Dictionary<string, string> Metadata { get; set; } = new();
    public bool EnableVersioning { get; set; } = false;
    public string StorageClass { get; set; } = "STANDARD";
    public bool EnableEncryption { get; set; } = true;
}
