namespace AppNutrika.Models.Entities
{
    public class Production
    {
        public int id { get; set; }
        public int effectifDepart { get; set; }
        public int effectifMort { get; set; }
        public int effectifFin { get; set; }
        public int poids { get; set; }
        public DateTime date { get; set; }
        public int age { get; set; }

        // Eau
        public int apportEau { get; set; }
        public int eauUtilise { get; set; }
        public int eauRestant { get; set; }

        // Provende
        public int apportProvende { get; set; }
        public int provendeUtilise { get; set; }
        public int provendeRestant { get; set; }

        //Observation
        public string observation { get; set; }

        //Traitement
        public string libelleTraitement { get; set; }


        public int archived { get; set; }
        public int  status { get; set; }
        public DateTime createdAt { get; set; }
    }
}
