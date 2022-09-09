using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppDETAug2022.Services;

namespace WebAppDETAug2022.Pages
{
    public class HelloPageModel : PageModel
    {
        public Helo2 ob { get; set; }

        public string Message { get; set; }
        
        public void OnGet()
        {
            ob = new Helo2();
            Message = ob.SayHelo("sujith");
        }

        
        
    }
}
