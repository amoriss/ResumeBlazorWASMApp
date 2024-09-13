using Microsoft.AspNetCore.Mvc;

namespace ResumeAPI.Controllers;
public class PdfController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
