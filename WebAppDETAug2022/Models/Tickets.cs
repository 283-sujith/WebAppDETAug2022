using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebAppDETAug2022.Models
{
    public class Tickets
    {
        public int Id { get; set; }
        
        public int Price { get; set; }
        public string Match { get; set; }
    }
}

