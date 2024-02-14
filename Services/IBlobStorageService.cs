namespace SnigdhaBeautyStudio.Services
{
    public interface IBlobStorageService
    {
       Task<string> ReadBlobContent();
    }
}
