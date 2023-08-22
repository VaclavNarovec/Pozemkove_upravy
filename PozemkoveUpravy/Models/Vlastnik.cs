namespace PozemkoveUpravy.Models
{
    public class Vlastnik
    {
        public int Id { get; set; }
        public int PozemkovaUpravaId { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Email { get; set; }
        public int Telefon { get; set; }
        public string Obec { get; set; }
        public string Ulice { get; set; }
        public int Cislo_popisne { get; set; }
        public int PSC { get; set; }
        public int List_vlastnictvi { get; set; }

        public PozemkovaUprava? PozemkoveUpravy { get; set; }
        public ICollection<Pozemek>? Pozemky { get; set; }
    }
}
