namespace PozemkoveUpravy.Models
{
    public class Pozemek
    {
        public int Id { get; set; }
        public int VlastnikId { get; set; }
        public int List_vlastnictvi { get; set; }
        public string Cislo_pozemku { get; set; }
        public string Druh_pozemku { get; set; }
        public string Zpusob_vyuziti_nemovitosti { get; set; }
        public string Zpusob_ochrany_nemovitosti { get; set; }
        public float Vymera_v_m2 { get; set; }
        public float Vzdalenost_v_m { get; set; }

        public Vlastnik? Vlastnici { get; set; }

        public ICollection<OceneniPozemku>? OceneniPozemkuA { get; set; }
        public ICollection<OceneniPorostu>? OceneniPorostuA { get; set; }
    }
}
