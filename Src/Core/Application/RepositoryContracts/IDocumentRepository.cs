using Application.ProductAggregates;
using Domain.DocumentAggregates;
using Domain.OrderAggregates;
using Domain.ProductAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.RepositoryContracts
{
    public interface IDocumentRepository : IGenericRepository<Document>
    {
    }
}
