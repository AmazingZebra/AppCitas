using CloudinaryDotNet.Actions;

namespace AppCitas.Interfaces;

public interface IPhotoService
{
    Task<ImageUploadResult> AddPhotoAsyc(IFormFile file);
    Task<DeletionResult> DeletePhotoAsync(string publicId);


}
