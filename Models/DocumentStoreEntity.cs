using Azure;
using Azure.Data.Tables;

namespace SnigdhaBeautyStudio.Models
{
    public class DocumentStoreEntity : ITableEntity
    {
        public string Id { get; set; }  

        public string DocumentName { get; set; }

        public string DocumentType { get; set; }

        public string DocumentPath { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
