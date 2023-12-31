using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ParquetViewer.Controllers;

namespace ParquetViewerGUI.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public string FileName { get; set; }
        [BindProperty]
        public string Id { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Value { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            ParquetFileController context = new ParquetFileController();
            await context.Update(FileName, Int32.Parse(Id), Name, Int32.Parse(Value));
            return new RedirectToPageResult("Index");
        }
    }
}
