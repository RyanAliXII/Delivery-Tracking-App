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
    public async Task<PutObjectResponse> Upload(Stream? File, string ContentType, string? Bucket = null , string Folder = "" ){
        var extension = MimeTypes.MimeTypeMap.GetExtension(ContentType);
        var filename = $"{Guid.NewGuid()}{extension}";
        var objectName = Path.Combine(Folder, filename).Replace("\\", "/");

        var putObjectArgs = new PutObjectArgs();
        var bucket =  Bucket ?? _config.GetSection("Minio").GetValue("DefaultBucket", "");
        putObjectArgs.WithBucket(bucket);
        putObjectArgs.WithObject(objectName);
        putObjectArgs.WithStreamData(File);
        putObjectArgs.WithObjectSize(File?.Length ?? -1);
        putObjectArgs.WithContentType(ContentType);
        return await _minio.PutObjectAsync(putObjectArgs);
    }
    
}

public interface IMinioObjectStorage {
     public Task<PutObjectResponse> Upload(Stream? File, string ContentType, string? Bucket = null , string Folder = "" );
}
