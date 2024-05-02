using AppNutrika.Dto;
using AppNutrika.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppNutrika.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionController : ControllerBase
    {
        private readonly AppNutrika.Models.DataContext dataContext;
        public ProductionController(AppNutrika.Models.DataContext dataContext)
        {
            this.dataContext = dataContext;

        }





        // fonction permettant d'obtenir la liste des roles
        [HttpGet]
        [Route("ListAllProduction")]
        public async Task<ActionResult<List<Production>>> ListAllProduction()
        {

            var listProduction = dataContext.production.Where(p => p.archived == 1 && p.status == 1).OrderByDescending(p => p.createdAt).ToList();
            if (listProduction == null)
                return new JsonResult(new
                {
                    StatusCode = -1,
                    message = "Aucune production en cours !",
                });
            return new JsonResult(new { StatusCode = 1, message = "Voici la liste des production en cours ", mot = listProduction });
        }
        //  Affichage des

        // Ajout d'une Bande 
        [HttpPost]
        [Route("AddProduction")]
        public async Task<ActionResult<Production>> AddProduction(AddProductionDto addProductionDto)
        {


            // Ajout d'une nouvelle production
            Production production = new Production(); 
            production.age = addProductionDto.age;
            production.date = DateTime.Now.Date;
            production.effectifDepart = addProductionDto.effectifDepart;
            production.effectifFin = addProductionDto.effectifFin;
            production.effectifMort = addProductionDto.effectifDepart - addProductionDto.effectifFin;
            production.poids = addProductionDto.poids;
            // Eau 
            production.apportEau = addProductionDto.apportEau;
            production.eauUtilise = addProductionDto.eauUtilise;
            production.eauRestant = addProductionDto.apportEau - addProductionDto.eauUtilise;
            // Provende
            production.apportProvende = addProductionDto.apportProvende;
            production.provendeUtilise = addProductionDto.provendeUtilise;
            production.provendeRestant = addProductionDto.apportProvende - addProductionDto.provendeUtilise;

            // Traitement 
            production.libelleTraitement = addProductionDto.libelleTraitement;
            //Observation
            production.observation = addProductionDto.observation;

            production.createdAt = DateTime.Now;
            production.status = 1; 
            production.archived = 1;
            dataContext.production.Add(production);
            dataContext.SaveChanges();

           /* var IdProduction = production.id;
            // Enregistrement de la consommation
           
            SaveConsommation(
                addProductionDto.consommation, 
                IdProduction, 
                addProductionDto.categorieOfConsommationategoryid

                 );

            // Enregistrement des traitements
            SaveTraitement(
                addProductionDto.traitement, 
                IdProduction

                );
            // Enregistrement des observations
            SaveObservation(addProductionDto.observation,  IdProduction);*/

            // Reponse de l'API
            return new JsonResult(new { statusCode = 1, message = "Production enregistrée" }); 

        }




        private string SaveConsommation(ConsommationDto[] consommations, int IdProduction,  int IdCategorie )
        {

            try
            {
                foreach (var item in consommations)
                {
                   

                    Consommation consommation = new Consommation();
                    consommation.createdAt = DateTime.Now;
                    consommation.archived = 1;
                    consommation.qteServie = item.qteServie;
                    consommation.qteUtilise =item.qteUtilise;
                    consommation.qteRestant =item.qteServie - item.qteUtilise;
                    consommation.categorieOfConsommationid = IdCategorie;
                    consommation.productionid = IdProduction; 


                    dataContext.consommation.Add(consommation);
                    dataContext.SaveChanges();

                }

                return "Ok";
            }
            catch (Exception e)
            {
                return "Erreur";

            }

        }

        private string SaveObservation(string observation, int IdProduction )
        {

            try
            {
                    Observation observations = new Observation();
                    observations.createdAt = DateTime.Now;
                    observations.archived = 1;
                    observations.observation = observation;
                    observations.productionid = IdProduction;


                    dataContext.observation.Add(observations);
                    dataContext.SaveChanges();

                return "Ok";
            }
            catch (Exception e)
            {
                return "Erreur";

            }

        }
        private string SaveTraitement(TraitementDto[] traitements, int IdProduction)
        {

            try
            {
                foreach(var item in traitements)
                {

                    Traitement traitement = new Traitement();
                    traitement.createdAt = DateTime.Now;
                    traitement.archived = 1;
                    traitement.debut = item.debut;
                    traitement.fin = item.fin;
                    traitement.description = item.descriptionTraitement;
                    traitement.libelleTraitement = item.libelleTraitement;
                    traitement.productionid = IdProduction;

                    dataContext.traitement.Add(traitement);
                    dataContext.SaveChanges();
                }

                

                return "Ok";
            }
            catch (Exception e)
            {
                return "Erreur";
            }
       
        }


    }
}
