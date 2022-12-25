using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OpdrachtFrameworks.Models
{
    public class Facture
    {
        
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string naam { get; set; }
        public int prijs { get; set; }
        public bool diseappear { get; set; } = false;

        [Display(Name = "Klant")]
        public int KlantId { get; set; }
        [ForeignKey("KlantId")]
        public Klant? Klant { get; set; }

        [Display(Name = "Immo")]
        public int ImmoId { get; set; }
        [ForeignKey("ImmoId")]
        public Immo? Immo { get; set; }

    }
}
