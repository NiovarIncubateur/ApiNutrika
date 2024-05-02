using AppNutrika.Dto;
using AppNutrika.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static AppNutrika.Dto.RoleOfUserDto;

namespace AppNutrika.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleOfUserController : ControllerBase
    {
        private readonly AppNutrika.Models.DataContext dataContext;
        public RoleOfUserController(AppNutrika.Models.DataContext dataContext)
        {
            this.dataContext = dataContext;
            
        }






        // fonction permettant d'obtenir la liste des roles
        [HttpGet]
        [Route("ListRoleOfUser")]
        public async Task<ActionResult<List<RoleOfUser>>> ListRoleOfUser()
        {

            var listRoleOfUser = dataContext.roleOfUsers.Where(p => p.archived == 1).OrderByDescending(p => p.creatAt).ToList();
            if (listRoleOfUser == null)
                return new JsonResult(new
                {
                    StatusCode = -1,
                    message = "Ce  role n'existe pas !",
                });
            return new JsonResult(new { StatusCode = 1, message = "Voici la liste des roles ", mot = listRoleOfUser });
        }


        // cette fonction permet l'ajout d'un role
        [HttpPost]
        [Route("AddRoleOfUser")]
        public async Task<ActionResult> AddRoleOfUser(AddRoleOfUserDto addRoleOfUserDto)
        {

            var roleData = dataContext.roleOfUsers.Where(h => h.libelle == addRoleOfUserDto.libelle && h.archived == 1).FirstOrDefault();
            if (roleData != null)
            {
                return new JsonResult(new { StatusCode = -1, message = "Ce libelle existe deja " });

            }
            RoleOfUser roleOfUser = new RoleOfUser();

            roleOfUser.libelle = addRoleOfUserDto.libelle;
            roleOfUser.description = addRoleOfUserDto.description;
            roleOfUser.archived = 1;
            dataContext.roleOfUsers.Add(roleOfUser);
            dataContext.SaveChanges();

            return new JsonResult(new { statusCode = 1, message = " Ce role a été ajouter !" });
        }

        // cette fonction permet la modification d'un role
        [HttpPut]
        [Route("UpdateRoleOfUser"),  Authorize]
        public async Task<ActionResult<RoleOfUser>> UpdateRoleOfUser(UpdateRoleOfUserDto updateRoleOfUserDto)
        {

            var roleOfUserData = dataContext.roleOfUsers.Where(h => h.id == updateRoleOfUserDto.id && h.archived == 1).FirstOrDefault();

            if (roleOfUserData == null) return new JsonResult(new { StatusCode = -1, message = "Aucun element trouver" });

            roleOfUserData.libelle = updateRoleOfUserDto.libelle;
            roleOfUserData.description = updateRoleOfUserDto.description;
            dataContext.roleOfUsers.Update(roleOfUserData);
            dataContext.SaveChanges();


            return new JsonResult(new { StatusCode = 1, message = "Ce role  a été modifier" });

        }


        // cette fonction va permettre de supprimer un role
        [HttpGet]
        [Route("DeleteRoleOfUser")]
        public async Task<ActionResult> DeleteRoleOfUser(int id)
        {

            var roleOfUserData = dataContext.roleOfUsers.Where(h => h.id == id && h.archived == 1).FirstOrDefault();
            if (roleOfUserData == null) return new JsonResult(new { StatusCode = -1, message = "Ce role a déja été supprimer" });
            roleOfUserData.archived = 0;
            dataContext.roleOfUsers.Update(roleOfUserData);
            dataContext.SaveChanges();

            return new JsonResult(new { StatusCode = 1, message = " Ce role a été supprimer" });
        }
    }
}
