using Azure;
using Azure.Data.Tables;
using SnigdhaBeautyStudio.Models;

namespace SnigdhaBeautyStudio.Services
{
    public class DocTableService : IDocTableService
    {
        private IConfiguration _configuration;
        private readonly string TableName = "documentstore";
        public DocTableService(IConfiguration configuration) {
            _configuration = configuration;
        }    
        public async Task Delete(string partitionKey, string Id)
        {
            var tblClient = await this.GetTableClient();

            await tblClient.DeleteEntityAsync(partitionKey, Id);
        }

        public async Task<List<DocumentStoreEntity>> GetDocs()
        {
            var tblClient = await this.GetTableClient();

            Pageable<DocumentStoreEntity> docEntities = tblClient.Query<DocumentStoreEntity>();

            return docEntities.ToList();
        }

        public async Task<DocumentStoreEntity> GetDoc(string partitionKey, string Id)
        {
            var tblClient = await this.GetTableClient();

            return await tblClient.GetEntityAsync<DocumentStoreEntity>(partitionKey, Id);
        }

        public async Task UpsetData(DocumentStoreEntity entity)
        {
            var tblClient = await this.GetTableClient();
            await tblClient.UpsertEntityAsync(entity);

        }

        private async Task<TableClient> GetTableClient()
        {
            var tableServiceClient = new TableServiceClient(this._configuration["StorageAccountConnectionString"]);

            var tableClient = tableServiceClient.GetTableClient(TableName);
            await tableClient.CreateIfNotExistsAsync();

            return tableClient;
        }
    }
}
