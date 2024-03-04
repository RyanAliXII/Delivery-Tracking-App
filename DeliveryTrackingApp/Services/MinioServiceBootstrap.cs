using Microsoft.IdentityModel.Tokens;
using Minio;
using Minio.DataModel.Args;
using Newtonsoft.Json;
namespace DeliveryTrackingApp.Services;
public static class MinioServiceBootstrap {
    public async static void CreateDefaultBucketAndPolicy(IMinioClient minio, IConfiguration config){
       
       var minioConfig =  config.GetSection("Minio");
       var DefaultBucket = minioConfig.GetValue<string>("DefaultBucket", "");
       if(DefaultBucket.IsNullOrEmpty()){
            throw new Exception("Invalid bucket name");
       }
       var bea = new BucketExistsArgs();
       bea.WithBucket(DefaultBucket);
       var isBucketExists =  await minio.BucketExistsAsync(bea);
       if(!isBucketExists){
            var mba = new MakeBucketArgs();
            mba.WithBucket(DefaultBucket);
            await minio.MakeBucketAsync(mba);
       }
       CreateBucketPolicy(minio, DefaultBucket ?? "");
    }
    private static async void CreateBucketPolicy(IMinioClient minio, string bucket){
            var spa = new SetPolicyArgs();
              Policy policy = new Policy
                {
                    Version = "2012-10-17",
                    Statement = new List<Statement>
                    {
                        new Statement
                        {
                            Effect = "Allow",
                            Principal = new Principal
                            {
                                AWS = new List<string> { "*" }
                            },
                            Action = new List<string> { "s3:GetObject" },
                            Resource = new List<string>
                            {
                                $"arn:aws:s3:::{bucket}/driver-licenses/*",
                            }
                        }
                    }
                };
            string jsonPolicy = JsonConvert.SerializeObject(policy, Formatting.Indented);    
            spa.WithBucket(bucket);
            spa.WithPolicy(jsonPolicy);
            await minio.SetPolicyAsync(spa);
    }
    public static IMinioClient BuildDefaultMinioClient(IMinioClient client, IConfiguration config){

        var minioConfig =  config.GetSection("Minio");
        var minioAccessKey = minioConfig.GetValue<string>("AccessKey", "");
        var minioSecretKey = minioConfig.GetValue<string>("SecretKey", "");
        var endpoint = minioConfig.GetValue<string>("Endpoint", "");
        if(minioAccessKey.IsNullOrEmpty()){
            throw new Exception("Minio access key is required.");
        }
        if(minioSecretKey.IsNullOrEmpty()){
            throw new Exception("Minio secret key is required.");
        }
        if(endpoint.IsNullOrEmpty()){
            throw new Exception("Minio endpoint is required.");
        }
        client.WithCredentials(minioAccessKey, minioSecretKey).WithEndpoint(endpoint).WithSSL(false);
        return client;
    }
}

public class Principal
{
    [JsonProperty("AWS")]
    public List<string> AWS { get; set; } = [];
}

public class Statement
{
    [JsonProperty("Effect")]
    public string Effect { get; set; } = "";

    [JsonProperty("Principal")]
    public Principal Principal { get; set; } = new Principal();

    [JsonProperty("Action")]
    public List<string> Action { get; set; } = [];

    [JsonProperty("Resource")]
    public List<string> Resource { get; set; } = [];
}

public class Policy
{
    [JsonProperty("Version")]
    public string Version { get; set; } = "";

    [JsonProperty("Statement")]
    public List<Statement> Statement { get; set; } = [];
}
