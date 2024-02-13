using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using SnigdhaBeautyStudio.Models;

namespace SnigdhaBeautyStudio.Services
{
    public interface IDocTableService
    {
        public Task<DocumentStoreEntity> GetDoc(string partitionKey, string Id);

        public Task<List<DocumentStoreEntity>> GetDocs();

        public Task UpsetData(DocumentStoreEntity entity);

        public Task Delete(string partitionKey, string Id);    
            
    }
}
