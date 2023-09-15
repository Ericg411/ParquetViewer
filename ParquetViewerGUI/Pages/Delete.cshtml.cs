using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ParquetViewer.Controllers;

namespace ParquetViewerGUI.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public string FileName { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            ParquetFileController context = new ParquetFileController();
            await context.Delete(FileName);
            return new RedirectToPageResult("Index");
        }
    }
}
