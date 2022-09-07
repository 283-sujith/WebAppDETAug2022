using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppDETAug2022.Pages
{
    public class HellowebModel : PageModel
    {

        public string Message { get;set; }

        public int Discount { get; set; }
        public void OnGet()
        {
            Message = "ASP.NET CORE IS ROCKING!!";
            Discount = 15;
        }
    }
}
