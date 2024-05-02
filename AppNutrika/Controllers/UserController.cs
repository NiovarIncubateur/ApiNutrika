using AppNutrika.Models.Entities;
using AppNutrika.Models;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppNutrika.Dto;
using Microsoft.AspNetCore.Identity;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace AppNutrika.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly AppNutrika.Models.DataContext dataContext;
        private readonly TokenService tokenService;
        private readonly IConfiguration configuration;
        private static IWebHostEnvironment _webHostEnvironment;

        public UserController(AppNutrika.Models.DataContext dataContext, IWebHostEnvironment webHostEnvironment, IConfiguration configuration, TokenService tokenService)
        {
            this.dataContext = dataContext;
            this.configuration = configuration;
            this.tokenService = tokenService;
            _webHostEnvironment = webHostEnvironment;
        }


        //Api for add a Manager of application
        [HttpPost]
        [Route("AddManagerUser")]
        public async Task<ActionResult<User>> AddManagerUser([FromForm] UserDto userDto)
        {
            RoleOfUser roleOfUser = dataContext.roleOfUsers.Where(h => h.archived == 1 && h.libelle == "Admin").FirstOrDefault();
           
            string save = Path.Combine(_webHostEnvironment.ContentRootPath, "Profiles");
            var userData = dataContext.users.Where(h => h.email == userDto.email && h.archived == 1).FirstOrDefault();
            if (userData != null)
            {
                return new JsonResult(new { StatusCode = -1, message = "Ce compte existe deja dans le systeme" });

            }

            User manager = new User();

            String passwordSend = Constante.GenerationPassword();
            string filepath = Path.Combine(save, userDto.profile.FileName);
            using (Stream filestream = new FileStream(filepath, FileMode.Create))
            {
                await userDto.profile.CopyToAsync(filestream);
            }
            manager.name = userDto.name;
            manager.email = userDto.email;
            manager.phone = userDto.phone;
            manager.profile = userDto.profile.FileName;
            manager.password = Constante.hashPassword(passwordSend);
            manager.roleOfUserid = userDto.roleId;
            manager.status = 1;
            manager.etat = 1;
            manager.createdAt = DateTime.Now;
            manager.archived = 1;

            var subject = " Mot de Passe";
            var nomUser = manager.name;

            var mailTitle = manager.name;

            var map = new Dictionary<String, String>();
            var mailFooter = @"<p style='font-size: 17px;'>Ceci est un courriel automatique. Merci de ne pas <br />
                    répondre.<br /></p>";
            var mailBodyOpen = "<p style='font-size: 17px;'>";
            var mailBodyClose = "</p>";
            var mailBody = mailBodyOpen + "Votre compte a été enregistrer en tant que gestionnaire. Votre  mot de passe est:   " + passwordSend + " </ span > " + mailBodyClose;
            map.Add("@ViewBag.title", mailTitle);
            map.Add("@ViewBag.body", mailBody);
            map.Add("@ViewBag.nomUser", nomUser);
            map.Add("@ViewBag.annee", DateTime.Now.Year + "");
            //map.Add("@ViewBag.nomentreprise", settingsEnterprise.name);
            //map.Add("@ViewBag.emailentreprise", settingsEnterprise.courriel);
            //map.Add("@ViewBag.telentreprise", settingsEnterprise.telephone);
            //map.Add("@ViewBag.adresseentreprise", settingsEnterprise.adresse);
            map.Add("@ViewBag.mailFooter", mailFooter);
            MsMail mail1 = new MsMail();
            String body = MsMail.BuldBodyTemplate(@"./Models/TemplateEmail/UserSendMail.cshtml", map);

            //BackgroundJob.Enqueue(() => mail1.Send(userDto.email, subject, body, null, null, null));

            dataContext.users.Add(manager);
            dataContext.SaveChanges();

            return new JsonResult(new { StatusCode = 1, message = "Vous avez ajouter l'utilisateur", user = manager }); ;


        }

        // Suppression d'un Compte par l'administrateur
        [HttpGet]
        [Route("DeleteUser")]
        public async Task<ActionResult<List<User>>> DeleteUser(int Id)
        {

            var userData = dataContext.users.Where(p => p.id == Id && p.archived == 1).FirstOrDefault();
            if (userData == null) return new JsonResult(new { StatusCode = -1, message = "Ce compte n'exite pas" });
            userData.archived = 0;
            dataContext.users.Update(userData);
            dataContext.SaveChanges();
            return new JsonResult(new { StatusCode = 1, message = "Ce compte a été Supprimer  avec succes" });

        }

        //cette fonction va permettre de modifier les informations d'un compte
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<ActionResult<List<User>>> UpdateUser([FromForm] UpdateUserDto updateUserDto)
        {
            string save = Path.Combine(_webHostEnvironment.ContentRootPath, "Profiles");
            var userData = dataContext.users.Where(h => h.id == updateUserDto.id && h.archived == 1).FirstOrDefault();
            if (userData == null) return new JsonResult(new { StatusCode = -1, message = "Aucun compte trouver" });


            userData.name = updateUserDto.name;
            userData.phone = updateUserDto.phone;
            string filepath = Path.Combine(save, updateUserDto.profile.FileName);
            using (Stream filestream = new FileStream(filepath, FileMode.Create))
            {
                await updateUserDto.profile.CopyToAsync(filestream);
            }
            userData.profile = updateUserDto.profile.FileName;
            userData.archived = 1;
            dataContext.users.Update(userData);
            dataContext.SaveChanges();
            return new JsonResult(new { StatusCode = 1, message = "Vos informations ont été  Modifier  avec succes" });
        }

        [HttpGet]
        [Route("BlockOrDeblockUser")]
        public async Task<ActionResult<List<User>>> BlockOrDeblockUser(int Id)
        {
           
            var userData = dataContext.users.Where(p => p.id == Id && p.archived == 1).FirstOrDefault();
            if (userData.etat == 1)

            {
                userData.etat = 0;
                dataContext.users.Update(userData);
                dataContext.SaveChangesAsync();
                // Informations devant etre dans le fichier envoyer par mail
                var nomUser1 = userData.name;
                var annee1 = DateTime.Now.Year.ToString();
                var mailTitle1 = userData.name;


                var map1 = new Dictionary<String, String>();
                var subject = "Votre Compte a été bloqué";
                var mailFooter1 = @"<p style='font-size: 17px;'>Ceci est un courriel automatique. Merci de ne pas <br />
                    répondre.<br /></p>";
                var mailBodyOpen1 = "<p style='font-size: 17px;'>";
                var mailBodyClose1 = "</p>";
                var mailBody1 = mailBodyOpen1 + "Pour des raisons de non respect de notre confidentialité votre compte a été <br/> <span style='font-size: 20px; font-weight: bold; '> Bloqué </span> ." +
                    " <br/>Une examination de votre compte sera fait afin de le Debloquer" + mailBodyClose1;
                map1.Add("@ViewBag.title", mailTitle1);
                map1.Add("@ViewBag.body", mailBody1);
                map1.Add("@ViewBag.nomUser", nomUser1);
                map1.Add("@ViewBag.annee", annee1);
                //map1.Add("@ViewBag.nomentreprise", settingsEnterprise.name);
                //map1.Add("@ViewBag.emailentreprise", settingsEnterprise.courriel);
                //map1.Add("@ViewBag.telentreprise", settingsEnterprise.telephone);
                //map1.Add("@ViewBag.adresseentreprise", settingsEnterprise.adresse);
                map1.Add("@ViewBag.mailFooter", mailFooter1);
                MsMail mail = new MsMail();
                string body = MsMail.BuldBodyTemplate(@"./SendMailHtml/UserSendMail.cshtml", map1);
                // string body = BackgroundJob.Enqueue(() => MsMail.BuldBodyTemplate(@"./MesHtml/UserSendMail.cshtml", map1));
                //BackgroundJob.Enqueue(() => mail.Send(userData.email, subject, body, null, null, null));
                return new JsonResult(new { StatusCode = 1, message = " Compte bloqué" });
            }
            userData.etat = 1;
            dataContext.users.Update(userData);
            dataContext.SaveChanges();


            var nomUser = userData.name;
            var annee = DateTime.Now.Year.ToString();
            var mailTitle = userData.name;


            var map = new Dictionary<String, String>();
            var subject1 = " Votre Compte a été debloquer ";
            var mailFooter = @"<p style='font-size: 17px;'>Ceci est un courriel automatique. Merci de ne pas <br />
                    répondre.<br /></p>";
            var mailBodyOpen = "<p style='font-size: 17px;'>";
            var mailBodyClose = "</p>";
            var mailBody = mailBodyOpen + "Apres examination de votre compte,  il a été <br/> <span style='font-size: 20px; font-weight: bold; '> Débloqué </span>.<br/> Nous vous remercions pour votre patience " + mailBodyClose;
            map.Add("@ViewBag.title", mailTitle);
            map.Add("@ViewBag.body", mailBody);
            map.Add("@ViewBag.nomUser", nomUser);
            map.Add("@ViewBag.annee", annee);
            //map.Add("@ViewBag.nomentreprise", settingsEnterprise.name);
            //map.Add("@ViewBag.emailentreprise", settingsEnterprise.courriel);
            //map.Add("@ViewBag.telentreprise", settingsEnterprise.telephone);
            //map.Add("@ViewBag.adresseentreprise", settingsEnterprise.adresse);
            map.Add("@ViewBag.mailFooter", mailFooter);
            MsMail mail1 = new MsMail();
            string body1 = MsMail.BuldBodyTemplate(@"./SendMailHtml/UserSendMail.cshtml", map);
            // string body1 = BackgroundJob.Enqueue(() => MsMail.BuldBodyTemplate(@"./MesHtml/UserSendMail.cshtml", map));
            //BackgroundJob.Enqueue(() => mail1.Send(userData.email, subject1, body1, null, null, null));

            return new JsonResult(new { StatusCode = 1, message = "Votre Compte a été debloquer" });

        }

        // fonction permettant d'obtenir la liste des utilisateurs
        [HttpGet]
        [Route("ListOfUser")]
        public async Task<ActionResult<List<User>>> ListOfUser()
        {

            var listOfUser = dataContext.users.Where(p => p.archived == 1 && p.roleOfUser.archived == 1).Include(p => p.roleOfUser).OrderByDescending(p => p.createdAt).ToList();
            if (listOfUser == null)
                return new JsonResult(new
                {
                    StatusCode = -1,
                    message = "Ce  role n'existe pas !",
                });
            return new JsonResult(new { StatusCode = 1, message = "Voici la liste des roles ", mot = listOfUser });
        }



        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<string>> Login(LoginDto loginDto)
        {
            //Recuperation des informations de l'entreprise
          
            var hashpwd = Constante.hashPassword(loginDto.password);
             
            var user = dataContext.users.Where(h => h.email == loginDto.email && h.password == hashpwd && h.archived == 1).FirstOrDefault();
           // String codeVerification = Constante.GenerateCodeVerification();

            if (user == null)
            {
                return new JsonResult(new { statusCode = -1, message = "Email ou mot de passe Incorrect" });
            }
            else if (user.etat == 0)
            {
                return new JsonResult(new { statusCode = -1, message = " Votre a été bloqué" });

            }
            IdentityUser u = new IdentityUser();
            u.UserName = user.name;
            u.Id = user.id + "";
            u.Email = user.email;
            u.PasswordHash = user.password;
            //string token = CreateToken(user);
            var accessToken = this.tokenService.CreateToken(u);
            return new JsonResult(new
            {
                httpStatusCode = HttpStatusCode.Created,
                statusCode = 1,
                message = "Bienvenue ",
                User = user,
                token = accessToken
            });


        }

    }
}
