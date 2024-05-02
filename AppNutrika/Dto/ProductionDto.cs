namespace AppNutrika.Dto
{
    public class AddProductionDto
    {
        public int effectifDepart { get; set; }
        public int effectifFin { get; set; }
        public int poids { get; set; }
        //public DateTime date { get; set; }
        public int age { get; set; }
        // les infos ci-dessous doivent entrer dans la table consommation
        //public ConsommationDto[] consommation { get; set; }
        //public TraitementDto[] traitement { get; set; }
        //public int qteUtilise { get; set; }
        //public int qteRestant { get; set; }
        // Eau
        public int apportEau { get; set; }
        public int eauUtilise { get; set; }
       
        // Provende
        public int apportProvende { get; set; }
        public int provendeUtilise { get; set; }
       
        //Observation
        public string observation { get; set; }

        //Traitement
        public string libelleTraitement { get; set; }

        // les infos ci-dessous doivent entrer dans la table observation
       
        // les infos ci-dessous doivent entrer dans la table traitement
       

    }

    public class TraitementDto
    {
        public string libelleTraitement { get; set; }
        public DateTime debut { get; set; }
        public DateTime fin { get; set; }
        public string descriptionTraitement { get; set; }
    }

    public class ConsommationDto
    {
        public int qteServie { get; set; }
        public int qteUtilise { get; set; }
    }
}
