using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Hosting.Internal;
using static System.Net.Mime.MediaTypeNames;

namespace AppNutrika.Models
{
    public class MsMail : MailMessage
    {
        private String Email;
        private String Password;


        public String getEmail() { return Email; }

        ///public static String baseUrl = "https://niovar.solutions/";
        //public static String baseUrl = "https://localhost:44324/";

        // public static String baseUrl =  HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/" ;


        public MsMail()
        {
            // developpement
            //this.Email = "cocdog11@gmail.com";
            //this.Password = "havzkiuaeuznvtqt";
            this.Email = "cocdog11@gmail.com";
            this.Password = "bxavorrkorhvguta";
            // production
            /*this.Email = "no-reply@niovarjobs.com";
            this.Password = "VXslc.dm5*U6!";*/

        }
        public MsMail(String email, String password)
        {
            this.Email = email;
            this.Password = password;
        }
        public static String BuldBodyTemplate(String filepath, Dictionary<String, String> map)
        {
            //  string chemin = HostingEnvironment(filepath);
            if (string.IsNullOrEmpty(filepath) || !System.IO.File.Exists(filepath)) return null;

            string body = System.IO.File.ReadAllText(filepath);
            Console.WriteLine("**********map count = " + map.Count);
            if (map.Count > 0)
            {
                foreach (var item in map)
                {
                    Console.WriteLine("**********item " + item);
                    body = body.Replace(item.Key, item.Value);
                }
            }
            return body.ToString();
        }

        public async Task Send(String To, String Subject, String Body, List<String> Bcc = null, List<String> CC = null, List<String> Atachement = null)
        {
            List<String> Tmp = new List<String>();
            Tmp.Add(To);
            await SendGroup(Tmp, Subject, Body, Bcc, CC, Atachement);
        }
        public async Task SendGroup(List<String> To, String Subject, String Body, List<String> Bcc = null, List<String> CC = null, List<String> Atachement = null)
        {
            if (To == null) return;
            foreach (String x in To) this.To.Add(new MailAddress(x));
            if (Bcc != null) foreach (String x in Bcc) this.Bcc.Add(new MailAddress(x));
            if (CC != null) foreach (String x in CC) this.CC.Add(new MailAddress(x));
            if (Atachement != null) foreach (String x in Atachement) this.Attachments.Add(new Attachment(x));
            this.From = new MailAddress(this.Email);
            this.Subject = Subject;
            this.Body = Body;
            this.Priority = MailPriority.High;
            this.IsBodyHtml = true;

            Console.WriteLine("**********this.To " + this.To);
            // production configuration
            /* SmtpClient client = new SmtpClient("mail.niovarjobs.com", 25);
              client.UseDefaultCredentials = false;
              client.Credentials = new System.Net.NetworkCredential(this.Email, this.Password);
              client.EnableSsl = false;*/

            // developpement  configuration
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.DeliveryFormat = SmtpDeliveryFormat.International;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(this.Email, this.Password);
            client.EnableSsl = true;

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            Console.WriteLine("**********this " + this); try
            {
                await client.SendMailAsync(this);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine("********** Source " + ex.Source);
                Console.WriteLine("********** Message " + ex.Message);
                Console.WriteLine("********** Data " + ex.Data);
                throw ex;
            }
            finally
            {
                client.Dispose();
                this.Dispose();
            }
        }

    }
}
