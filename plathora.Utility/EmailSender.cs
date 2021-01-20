using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
//using SendGrid;
//using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
namespace plathora.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public EmailSender(IWebHostEnvironment hostingEnvironment)
        {
           
            _hostingEnvironment = hostingEnvironment;
        }
        //public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        //{
        //    StringBuilder strBul = new StringBuilder("<div>");
        //    // strBul = strBul.Append("<div>You can use the following link to reset your password: " + htmlMessage + ",</div>");






        //    string fromemail = "info@tingtongindia.com";
        //    string password = "Plethora@123";

        //    bool send = false;
        //    MailMessage mail = new MailMessage();
        //    mail.To.Add(email);

        //    mail.From = new MailAddress(fromemail, subject);
        //    mail.Subject = subject;

        //    //--------------------------
        //    string pancardphotopath = _hostingEnvironment.WebRootPath + ("~/uploads/tingtong logo.png".Replace('/', '\\'));

        //    LinkedResource LinkedImage = new LinkedResource(@"C:\Users\Admin\Desktop\tingtong logo.png");
        //    LinkedImage.ContentId = "MyPic";

        //    LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

        //    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
        //      "You should see image next to this line. <img width='100' height='100' src=cid:MyPic>",
        //      null, "text/html");

        //    htmlView.LinkedResources.Add(LinkedImage);
        //    mail.AlternateViews.Add(htmlView);
        //    //----------------------------
        //    mail.Body = htmlMessage.ToString();
        //    mail.IsBodyHtml = true;
        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "103.250.184.62";
        //    smtp.Port = 25;
        //    smtp.UseDefaultCredentials = false;
        //    smtp.Credentials = new System.Net.NetworkCredential(fromemail, password);
        //    try
        //    {
        //        smtp.Send(mail);
        //        send = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        send = false;
        //        //  ErrHandler.writeError(ex.Message, ex.StackTrace);
        //    }


        //    //  throw new NotImplementedException();
        //}
        //private AlternateView Mail_Body(string bodytext)
        //{
           
        //    string passbookphotopath = @"C:\Users\Admin\Desktop\tingtong logo.png";
             

        //    LinkedResource passbookphotoImg = new LinkedResource(passbookphotopath, MediaTypeNames.Image.Jpeg);
        //    passbookphotoImg.ContentId = "MyImage1";



        //    //StringBuilder str = new StringBuilder();
        //    //str = str.Append("<div>Hello Team,</div>");
        //    //str = str.Append("<br />");
        //    //str = str.Append("<div>Hope you are doing well, </div>");
        //    //str = str.Append("<br />");
        //    //str = str.Append("<div>We want create label for following account</div>");
        //    //str = str.Append("<br />");
            
          

        //    //str = str.Append("<div>Thank you.</div>");
        //    AlternateView AV =
        //     AlternateView.CreateAlternateViewFromString(bodytext, null, MediaTypeNames.Text.Html);

             
        //    AV.LinkedResources.Add(passbookphotoImg);
        //    return AV;
        //}

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            StringBuilder strBul = new StringBuilder("<div>");
            // strBul = strBul.Append("<div>You can use the following link to reset your password: " + htmlMessage + ",</div>");






            string fromemail = "info@tingtongindia.com";
            string password = "Plethora@123";

            bool send = false;
            MailMessage mail = new MailMessage();
            mail.To.Add(email);

            mail.From = new MailAddress(fromemail, subject);
            mail.Subject = subject;

            //--------------------------
            //string pancardphotopath = _hostingEnvironment.WebRootPath + ("~/uploads/tingtong logo.png".Replace('/', '\\'));

            //LinkedResource LinkedImage = new LinkedResource(@"C:\Users\Admin\Desktop\tingtong logo.png");
            //LinkedImage.ContentId = "MyPic";

            //LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

            //AlternateView htmlView = AlternateView.CreateAlternateViewFromString(""+htmlMessage + " <img width='100' height='100' src=cid:MyPic>",
            //  null, "text/html");

            //htmlView.LinkedResources.Add(LinkedImage);
            //mail.AlternateViews.Add(htmlView);
            //mail.AlternateViews.Add(Mail_Body(htmlMessage.ToString()));
           
            
            //----------------------------
             mail.Body = htmlMessage.ToString();
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "103.250.184.62";
            smtp.Port = 25;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(fromemail, password);
            try
            {
                smtp.Send(mail);
                send = true;
            }
            catch (Exception ex)
            {
                send = false;
                //  ErrHandler.writeError(ex.Message, ex.StackTrace);
            }


            //  throw new NotImplementedException();
        }


    }
}
    