using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbEntity
{
    public class Entity
    {
        public int Id { get; set; }
        public required string TableName { get; set; }
    }
}
