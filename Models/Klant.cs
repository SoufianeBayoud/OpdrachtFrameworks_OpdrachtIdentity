using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OpdrachtFrameworks.Models
{
    public class Klant
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public String naam { get; set; }
        [Display(Name = "Street")]
        public String straat { get; set; }
        public int huisnummer { get; set; }
        [Display(Name = "mail")]
        public String email { get; set; }
        public bool diseappear { get; set; } = false;

    }
}
