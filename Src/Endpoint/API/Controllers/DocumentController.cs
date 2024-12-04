using Application.DocumentAggregates;
using Application.ServicesContracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDocument([FromBody] DocumentViewModel document)
        {
            try
            {
                var createdOrder = await _documentService.CreateAsync(document);
                return Ok(createdOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
