using Domain.EntityAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DocumentAggregates
{
    public class DocumentViewModel
    {
        public int Id { get; set; }
        public required string FileName { get; set; }
        public required string FilePath { get; set; }
        public int EntityId { get; set; } // ارجاع به موجودیت
        public int RowId { get; set; }    // ارجاع به ردیف موجودیت
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}
