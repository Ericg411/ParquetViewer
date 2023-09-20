using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParquetViewer.Controllers;
using System.ComponentModel.DataAnnotations;

namespace ParquetViewerGUI.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        [Required]
        public string FileName { get; set; }
        [BindProperty]
        [Required]
        public string Length { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            ParquetFileController context = new ParquetFileController();
            await context.Create(FileName, Int32.Parse(Length));
            return new RedirectToPageResult("Index");
        }
    }
}
