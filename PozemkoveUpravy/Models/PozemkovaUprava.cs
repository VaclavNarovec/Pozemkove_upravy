using System.ComponentModel.DataAnnotations;

namespace PozemkoveUpravy.Models
{
    public class PozemkovaUprava
    {
        public int Id { get; set; }
        
        [Display(Name = "Kraj")]
        [Required(ErrorMessage = "Vyplňte pole")]
        public string Kraj { get; set; }

        [Display(Name = "Okres")]
        [Required(ErrorMessage = "Vyplňte pole")]
        public string Okres { get; set; }

        [Display(Name = "Obec")]
        [Required(ErrorMessage = "Vyplňte pole")]
        public string Obec { get; set; }

        [Display(Name = "Katastrální území")]
        [Required(ErrorMessage = "Vyplňte pole")]
        public string Katastralni_uzemi { get; set; }

        [Display(Name = "Pozemkový úřad")]
        [Required(ErrorMessage = "Vyplňte pole")]
        public string Pozemkovy_urad { get; set; }

        [Display(Name = "Forma pozemkové úpravy")]
        [Required(ErrorMessage = "Vyplňte pole")]
        public string Forma_pozemkove_upravy { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Vyplňte pole")]
        public DateTime Pocatek { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Vyplňte pole")]
        public DateTime Konec { get; set; }

        public ICollection<Vlastnik>? Vlastnici { get; set; }
    }
}
