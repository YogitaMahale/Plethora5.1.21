using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using plathora.Entity;
using System.Net;
using System.IO;

namespace plathora.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
     
        private readonly IEmailSender _emailSender;

        public ForgotPasswordModel(UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            //[EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(Input.Email);
                //if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                if (user == null)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please 
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { area = "Identity", code },
                    protocol: Request.Scheme);


                //StringBuilder strBul = new StringBuilder("<div>");
                //strBul = strBul.Append("<div>Please reset your password by <a href='{" + HtmlEncoder.Default.Encode(callbackUrl) + "}'>clicking here</a>.</div>");
                
                await _emailSender.SendEmailAsync(
                    user.Email,
                    "Reset Password",
                    $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>."

                    
                   // strBul.ToString()
                   ) ;
               

                //#region "sms"
                //try
                //{


                //    string Msg = strBul.ToString();

                //    string OPTINS = "STRLIT";

                //    string type = "3";
                //    string strUrl = "https://www.bulksmsgateway.in/sendmessage.php?user=ezacus&password=" + "Bingo@5151" + "&message=" + Msg.ToString() + "&sender=" + OPTINS + "&mobile=" + "9021517586"+ "&type=" + 3;

                //    ServicePointManager.Expect100Continue = true;
                //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //    System.Net.WebRequest request = System.Net.WebRequest.Create(strUrl);
                //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //    Stream s = (Stream)response.GetResponseStream();
                //    StreamReader readStream = new StreamReader(s);
                //    string dataString = readStream.ReadToEnd();
                //    response.Close();
                //    s.Close();
                //    readStream.Close();
                //    //    Response.Write("Sent");
                //}

                //catch
                //{ }
                //#endregion


                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            return Page();
        }
    }
}
