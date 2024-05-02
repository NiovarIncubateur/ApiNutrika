using AppNutrika.Dto;
using AppNutrika.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppNutrika.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CataegorieOfConsommationController : ControllerBase
    {
        private readonly AppNutrika.Models.DataContext dataContext;
        public CataegorieOfConsommationController(AppNutrika.Models.DataContext dataContext)
        {
            this.dataContext = dataContext;

        }



        [HttpPost]
        [Route("CategorieOfConsommation"),  Authorize]

        public async Task<ActionResult<CategorieOfConsommation>> CategorieOfConsommation(CategorieOfConsommationDto categorieOfConsommationDto)
        {
            var categoriconsommationData = dataContext.categorieOfConsommation.Where(h => h.archived == 1 && h.libelle == categorieOfConsommationDto.libelle).FirstOrDefault(); 
            if(categoriconsommationData != null)
            {
                return new JsonResult(new { statusCode = -1, message = " Cette categorie existe déja ! " });

            }

            CategorieOfConsommation categorie = new CategorieOfConsommation();
            categorie.libelle = categorieOfConsommationDto.libelle;
            categorie.description = categorieOfConsommationDto.description;
            categorie.archived = 1; ;
            categorie.createdAt = DateTime.Now;

            // Sauvegarde 
            dataContext.categorieOfConsommation.Add(categorie);
            dataContext.SaveChanges();
            return new JsonResult(new { statusCode = 1, message = "Categorie enregistré" }); 
        }

        // Liste des categories de consommation
        [HttpGet]
        [Route("ListAllCategorie")]
        public async Task<ActionResult<List<CategorieOfConsommation>>> ListAllCategorie()
        {
            var listOfCategorie = dataContext.categorieOfConsommation.Where(p => p.archived == 1).OrderByDescending(p => p.createdAt).ToList();
            if (listOfCategorie == null)
                return new JsonResult(new
                {
                    StatusCode = -1,
                    message = "Cette  categorie n'existe pas !",
                });
            return new JsonResult(new { StatusCode = 1, message = "Voici la liste des categories ", mot = listOfCategorie });
        }

        // cette fonction permet la modification d'une category
        [HttpPut]
        [Route("UpdateCategory"), Authorize]
        public async Task<ActionResult<CategorieOfConsommation>> UpdateCategory(CategoryUpdateDto categoryUpdateDto)
        {

            var categoriconsommationData = dataContext.categorieOfConsommation.Where(h => h.id == categoryUpdateDto.id && h.archived == 1).FirstOrDefault();

            if (categoriconsommationData == null) return new JsonResult(new { StatusCode = -1, message = "Aucun element trouver" });

            categoriconsommationData.libelle = categoryUpdateDto.name;
            categoriconsommationData.description = categoryUpdateDto.description;
            dataContext.categorieOfConsommation.Update(categoriconsommationData);
            dataContext.SaveChanges();


            return new JsonResult(new { StatusCode = 1, message = "Cette categorie a été modifier" });

        }

        // cette fonction va permettre de supprimer une categorie
        [HttpGet]
        [Route("DeleteCatagory"), Authorize]
        public async Task<ActionResult> DeleteCatagory(int id)
        {

            var categoriconsommationData = dataContext.categorieOfConsommation.Where(h => h.id == id && h.archived == 1).FirstOrDefault();
            if (categoriconsommationData == null) return new JsonResult(new { StatusCode = -1, message = "Cette categorie a déja été supprimer" });
            categoriconsommationData.archived = 0;
            dataContext.categorieOfConsommation.Update(categoriconsommationData);
            dataContext.SaveChanges();

            return new JsonResult(new { StatusCode = 1, message = " Cette categorie a été supprimer" });
        }


    }
}
