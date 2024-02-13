using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SnigdhaBeautyStudio.Models;

namespace SnigdhaBeautyStudio.Data
{
    public class SnigdhaBeautyStudioContext : DbContext
    {
        public SnigdhaBeautyStudioContext (DbContextOptions<SnigdhaBeautyStudioContext> options)
            : base(options)
        {
        }

        public DbSet<SnigdhaBeautyStudio.Models.EnquiryViewModel> EnquiryViewModel { get; set; } = default!;
    }
}
