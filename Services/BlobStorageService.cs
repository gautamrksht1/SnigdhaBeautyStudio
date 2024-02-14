using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs;
using System.Text;

namespace SnigdhaBeautyStudio.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        string blobUri = "https://gautamstorage1.blob.core.windows.net/blob-container1/selectAllCustomer.sql";
        
        public async Task<string> ReadBlobContent()
        {
            TokenCredential tokenCredential = new DefaultAzureCredential();

            BlobClient blobClient = new BlobClient(new Uri(blobUri), tokenCredential);

            var response = await blobClient.DownloadAsync();
            StringBuilder sb = new StringBuilder();
            using (var streamReader = new StreamReader(response.Value.Content))
            {
                while (!streamReader.EndOfStream)
                {
                    sb.Append(await streamReader.ReadLineAsync());
                }
            }
            return sb.ToString();
        }
    }
}
