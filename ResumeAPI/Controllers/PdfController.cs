using Microsoft.AspNetCore.Mvc;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace ResumeAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PdfController : Controller
{
    [HttpPost("upload")]
    public async Task<IActionResult> UploadPdf(IFormFile file)
    {
        try
        {
            var stream = new MemoryStream();
            using (PdfDocument document = PdfDocument.Open(stream))
            {
                string pageText = string.Empty;
                foreach (Page page in document.GetPages())
                {
                    pageText += page.Text.ToLower();
                }

                return Ok(pageText);
            }
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Could not process PDF: {e.Message}");
        }
    }
    
    [HttpGet("resume")]
    public IActionResult Index()
    {
        string relativePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "FaceResume.pdf");
        string fullDocument = string.Empty;
        try
        {
            using (PdfDocument document = PdfDocument.Open(relativePath))
            {

                foreach (Page page in document.GetPages())
                {
                    fullDocument += page.Text;
                }
            }
            return View(fullDocument);
        }

        catch
        {
            return NotFound("File Not found");
        }
       
    }
}
