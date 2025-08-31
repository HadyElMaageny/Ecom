using Ecom.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace Ecom.Infrastructure.Repositories.Services;

public class ImageManagementService : IImageManagementService
{
    private readonly IFileProvider _fileProvider;

    public ImageManagementService(IFileProvider fileProvider)
    {
        _fileProvider = fileProvider;
    }

    public async Task<List<string>> AddImageAsync(IFormFileCollection files, string src)
    {
        List<string> saveImagePaths = new List<string>();
        var imageDirectory = Path.Combine("wwwroot", "Images", src);

        if (!Directory.Exists(imageDirectory))
            Directory.CreateDirectory(imageDirectory);

        foreach (var file in files)
        {
            var imageName = file.FileName;
            var imageSrc = $"/Images/{src}/{imageName}";
            var root = Path.Combine(imageDirectory, imageName);

            using (FileStream fileStream = new FileStream(root, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            saveImagePaths.Add(imageSrc);
        }

        return saveImagePaths;
    }

    public void DeleteImageAsync(string src)
    {
        var info = _fileProvider.GetFileInfo(src);

        var root = info.PhysicalPath;
        File.Delete(root);
    }
}