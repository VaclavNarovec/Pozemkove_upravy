namespace PozemkoveUpravy.Models
{
    public class OceneniPozemku
    {
        public int Id { get; set; }
        public int PozemekId { get; set; }
        public int VlastnikId { get; set; }
        public int BPEJ { get; set; }
        public float Vymera_v_m2 { get; set; }
        public int Cena_v_Kc { get; set; }

        public Pozemek? Pozemky { get; set; }
    }
}
