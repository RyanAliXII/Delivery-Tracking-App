using System.Net.Mime;
using Microsoft.Extensions.Options;
using Minio;
using Minio.DataModel;
using Minio.DataModel.Args;
using Minio.DataModel.Response;

namespace DeliveryTrackingApp.Services;
class MinioObjectStorage : IMinioObjectStorage{
    private readonly IMinioClient _minio;
    private readonly IConfiguration _config;
    public MinioObjectStorage(IMinioClient minio, IConfiguration config){
        _minio = minio;
        _config = config;
    }
    public IMinioClient GetClient(){
        return _minio;
    }
    public async Task<PutObjectResponse> Upload(Stream File, string ContentType, string? Bucket = null , string Folder = "" ){
        var objectName = $"{Folder}/{Guid.NewGuid()}";
        var putObjectArgs = new PutObjectArgs();
        var bucket =  Bucket ?? _config.GetSection("Minio").GetValue("DefaultBucket", "");
        putObjectArgs.WithBucket(bucket);
        putObjectArgs.WithObject(objectName);
        putObjectArgs.WithStreamData(File);
        putObjectArgs.WithObjectSize(File.Length);
        putObjectArgs.WithContentType(ContentType);
        return await _minio.PutObjectAsync(putObjectArgs);
    }
    
}

public interface IMinioObjectStorage {
     public Task<PutObjectResponse> Upload(Stream File, string ContentType, string? Bucket = null , string Folder = "" );
}
