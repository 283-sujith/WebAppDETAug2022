using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppDETAug2022.Models;
using WebAppDETAug2022.Services;

namespace WebAppDETAug2022.Pages
{
    public class IPLEventsModel : PageModel
    {
       
        
            
        public List<Tickets> Ticket { get; set; }
        public void OnGet()
        {
            Ticket = new List<Tickets>{
            new Tickets{Match= "INDIA VS PAKISTAN "   ,Price=5000,Id=1},
                new Tickets{Match= "Sri Lanka VS INDIA"   ,Price=4000,Id=2},
                new Tickets{Match= " INDIA VS Afghanistan",Price=3000,Id=3}
            };
        }
    }
}
    

