using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpdrachtFrameworks.Models
{
    public class Immo
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string naam { get; set; }
        [Display(Name = "Street")]
        public string straat { get; set; }

        [Display(Name = "Omschrijving")]
        public string description { get; set; }
        public int huisnummer { get; set; }
        public int gemeente { get; set; }
        public double prijs { get; set; }
        public int bouwjaar { get; set; }
        public int kamers { get; set; }
        public int grootte { get; set; }
        public string tuin { get; set; }
        public string type { get; set; }
        public bool diseappear { get; set; } = false;


    }
}
