using Microsoft.EntityFrameworkCore;

namespace SnigdhaBeautyStudio.Models
{
    [PrimaryKey(nameof(Id))]
    public class EnquiryViewModel
    {
        
        public int Id { get; set; }
        public string Category { get; set; }

        public string MobileNo { get; set; }

        public string Name { get; set; }

        public DateOnly EventDate { get; set; }

        public int Quantity { get; set; }
    }
}
