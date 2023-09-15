using Microsoft.AspNetCore.Mvc;
using ParquetViewer.Classes;
using ParquetViewer.Controllers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ParquetViewerGUI.Pages
{
    public class CreateModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync(string fileName, string length)
        {
            ParquetFileController context = new ParquetFileController();
            await context.Create(fileName, Int32.Parse(length));
            return new RedirectToPageResult("Index");
        }
    }
}
