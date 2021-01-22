using Dapper;
//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using plathora.Entity;
using plathora.Models;
using plathora.Models.Dtos;
using plathora.Persistence;
using plathora.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using plathora.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.Data.SqlClient;
using SectorRegistrationIndexViewModel = plathora.Models.SectorRegistrationIndexViewModel;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text.Encodings.Web;
using System.Text;
using System.Net.Mail;
using Microsoft.AspNetCore.Hosting;

namespace plathora.Controllers
{
    [Area("Admin")]
    // [Authorize(Roles = SD.Role_Admin)]
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;
        private readonly ISP_Call _sP_Call;
        private IConfiguration Configuration;
        private ISectorRegistrationServices _SectorRegistrationServices;
        private IBusinessRegistrationServieces _BusinessRegistrationServieces;
        private IProductMasterServices _productMasterServices;
        private IAboutUsServices _aboutUsServices;
        private IContactUsServices _ContactUsServices;
        private IbusinessratingsServices _businessratingsServices;
        private IBusinessOwnerRegiServices _businessOwnerRegiServices;
        private INewsServices _newsServices;
        private readonly ApplicationDbContext _db;
        private readonly Iratingsservices _ratingsservices;
       private readonly UserManager<IdentityUser> _usermanager;
        private readonly ICityRegistrationservices _cityRegistrationservices;
        private readonly IBusinessContactUsservices _businessContactUsservices;
        private readonly IEmailSender _emailSender;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public HomeController(ILogger<HomeController> logger, ISP_Call sP_Call, IConfiguration _Configuration, ISectorRegistrationServices SectorRegistrationServices, IBusinessRegistrationServieces BusinessRegistrationServieces, IProductMasterServices productMasterServices, IAboutUsServices aboutUsServices, IContactUsServices ContactUsServices, IbusinessratingsServices businessratingsServices, IBusinessOwnerRegiServices businessOwnerRegiServices, INewsServices newsServices, ApplicationDbContext db, Iratingsservices ratingsservices, UserManager<IdentityUser> usermanager, ICityRegistrationservices cityRegistrationservices, IBusinessContactUsservices businessContactUsservices, IEmailSender emailSender, IWebHostEnvironment hostingEnvironment)//, UserManager<ApplicationUser> usermanager
        {
            //_logger = logger;
            _sP_Call = sP_Call;
            Configuration = _Configuration;
            _SectorRegistrationServices = SectorRegistrationServices;
            _BusinessRegistrationServieces = BusinessRegistrationServieces;
            _productMasterServices = productMasterServices;
            _aboutUsServices = aboutUsServices;
            _ContactUsServices = ContactUsServices;
            _businessratingsServices = businessratingsServices;
            _businessOwnerRegiServices = businessOwnerRegiServices;
            _newsServices = newsServices;
           _usermanager = usermanager;
             _db = db;
            _ratingsservices = ratingsservices;
            _cityRegistrationservices = cityRegistrationservices;
            _businessContactUsservices = businessContactUsservices;
            _emailSender = emailSender;
            _hostingEnvironment = hostingEnvironment;
        }
      
        public void LoginUserDetails()
        {
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (customerId == null)
            {
                TempData["userName"] = "";
                TempData["profilephoto"] = "/uploads/blaankCustomer.png";

                 
            }
            else
            {
                var objfromdb = _db.applicationUsers.FirstOrDefault(u => u.Id == customerId);
                if (objfromdb.name == null)
                {

                    TempData["userName"] = "";
                }
                else
                {

                    TempData["userName"] = objfromdb.name;
                }
               
                
                if (objfromdb.profilephoto == null)
                {

                    TempData["profilephoto"] = "/uploads/blaankCustomer.png";
                }
                else
                {

                    TempData["profilephoto"] = objfromdb.profilephoto;
                }
            }
            TempData.Keep("userName");
            TempData.Keep("profilephoto");
        }
        [HttpGet]
        public IActionResult Index()
        {
            LoginUserDetails();
            try
            {

               




                IEnumerable<SelectListItem> cities = _cityRegistrationservices.GetAllCities();
                ViewData["cities"] = cities;
                frontwebsiteModel objmodel = new frontwebsiteModel();
                var parameter = new DynamicParameters();
                objmodel.objBusinessDetails = _sP_Call.List<selectallBusinessDetailsDtos>("selectallBusinessDetails", null);
                
                objmodel.objSectorRegistration = _SectorRegistrationServices.GetAll().Take(15).Select(x => new plathora.Models.SectorRegistrationIndexViewModel
                {
                    id = x.id,
                    name = x.name,
                    img = x.img,
                    photo = x.photo

                }).ToList();
                 

              
               
                 
                //objmodel.objSectorRegistration = _SectorRegistrationServices.GetAll().Take(15).Select(x => new plathora.Models.SectorRegistrationIndexViewModel
                //{
                //    id = x.id,
                //    name = x.name,
                //    img = x.img,
                //    photo = x.photo

                //}).ToList();

                objmodel.objNews = _newsServices.GetAll().Where(x => x.isdeleted == false).OrderByDescending(x => x.id).Select(x => new NewIndexViewModel
                {
                    id = x.id,
                    title = x.title,
                    img = x.img,
                    description = x.description,
                    isdeleted = x.isdeleted,
                    isactive = x.isactive,
                    date1 = x.date1,
                    createddate = x.createddate

                }).ToList();
               // ViewBag.sectorListt = objmodel.objSectorRegistration.ToList();
                //ViewBag.StockList = JsonConvert.SerializeObject(objmodel.objSectorRegistration);
                return View(objmodel);
            }
            catch (Exception obj)
            {
            }
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public IActionResult Index1(string txtsearch,int cityid)
        {
            try
            {
                IEnumerable<SelectListItem> cities = _cityRegistrationservices.GetAllCities();
                ViewData["cities"] = cities;
                //ViewBag.cities = _cityRegistrationservices.GetAll().Where(x => x.isdeleted == false).ToList();
                ViewBag.search = txtsearch;
                frontwebsiteModel objmodel = new frontwebsiteModel();
                //  ViewBag.search = txtsearch;                var parameter = new DynamicParameters();
                //IEnumerable<selectallBusinessDetailsDtos> obj = _sP_Call.List<selectallBusinessDetailsDtos>("selectallBusinessDetails", null);
                objmodel.objBusinessDetails = _sP_Call.List<selectallBusinessDetailsDtos>("selectallBusinessDetails", null);
                //if (txtsearch == null || txtsearch.Trim() == "")
                //{
                //    objmodel.objSectorRegistration = _SectorRegistrationServices.GetAll().OrderByDescending(x => x.id).Where(x => x.isdeleted == false).Select(x => new plathora.Models.SectorRegistrationIndexViewModel
                //    {
                //        id = x.id,
                //        name = x.name,
                //        img = x.img,
                //        photo = x.photo

                //    }).ToList();
                //}
                //else
                //{
                //    objmodel.objSectorRegistration = _SectorRegistrationServices.GetAll().Where(x => x.name.Contains(txtsearch) && x.isdeleted == false).Select(x => new plathora.Models.SectorRegistrationIndexViewModel
                //    {
                //        id = x.id,
                //        name = x.name,
                //        img = x.img,
                //        photo = x.photo

                //    }).ToList();
                //}
                objmodel.objNews = _newsServices.GetAll().Where(x => x.isdeleted == false).Select(x => new NewIndexViewModel
                {
                    id = x.id,
                    title = x.title,
                    img = x.img,
                    description = x.description,
                    isdeleted = x.isdeleted,
                    isactive = x.isactive,
                    date1 = x.date1,
                    createddate = x.createddate

                });
                //------------------------------------------------------------------------------------
                DataSet ds = new DataSet();

                string connString = this.Configuration.GetConnectionString("DefaultConnection");
                SqlConnection con = new SqlConnection(connString);
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    //cmd.CommandText = "searchquery";
                    cmd.CommandText = "searchqueryFrontWebsite";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@searchkeyword", txtsearch);
                    cmd.Parameters.AddWithValue("@Latitude", 0);
                    cmd.Parameters.AddWithValue("@Longitude", 0);
                    cmd.Parameters.AddWithValue("@cityid",cityid);
                    
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    

                    


                    if (ds != null)
                    {
                        try
                        {


                            if (ds.Tables[0].Rows[0]["type"].ToString().ToLower().Trim() == "sector".ToString().ToLower().Trim())
                            {
                                objmodel.SearchModelType = "sector".ToString().ToLower().Trim();
                                objmodel.objSectorRegistration = ds.Tables[0].AsEnumerable().Select(row => new SectorRegistrationIndexViewModel
                                {
                                    id = Convert.ToInt32(row["id"].ToString()),
                                    name = row["name"].ToString(),
                                    img = row["img"].ToString()
                                });

                                // public IEnumerable<SectorRegistrationIndexViewModel> objSectorRegistration { get; set; }
                            }
                            else if (ds.Tables[0].Rows[0]["type"].ToString().ToLower().Trim() == "business".ToString().ToLower().Trim())
                            {
                                objmodel.SearchModelType = "business".ToString().ToLower().Trim();
                                //   public IEnumerable<search_BusinessRegistrationIndexViewModel> objsearch_BusinessRegistrationIndexViewModel { get; set; }
                                objmodel.objsearch_BusinessRegistrationIndexViewModel = ds.Tables[0].AsEnumerable().Select(row => new search_BusinessRegistrationIndexViewModel
                                {
                                    id = Convert.ToInt32(row["id"].ToString()),
                                    name = row["name"].ToString(),
                                    img = row["img"].ToString(),
                                    sectorid = Convert.ToInt32(row["sectorid"].ToString()),
                                    type = row["type"].ToString()
                                });

                            }
                            else if (ds.Tables[0].Rows[0]["type"].ToString().ToLower().Trim() == "product".ToString().ToLower().Trim())
                            {
                                objmodel.SearchModelType = "product".ToString().ToLower().Trim();
                                // public IEnumerable<search_ProductIndexViewModel> objsearch_ProductIndexViewModel { get; set; }
                                objmodel.objsearch_ProductIndexViewModel = ds.Tables[0].AsEnumerable().Select(row => new search_ProductIndexViewModel
                                {
                                    id = Convert.ToInt32(row["id"].ToString()),
                                    businessid = Convert.ToInt32(row["businessid"].ToString()),
                                    productName = row["productName"].ToString(),
                                    img = row["img"].ToString(),

                                    type = row["type"].ToString()
                                });

                            }
                            else if (ds.Tables[0].Rows[0]["type"].ToString().ToLower().Trim() == "businessowner".ToString().ToLower().Trim())
                            {
                                // selectallBusinessDetailsDtos
                                //objmodel.objBusinessDetails = _sP_Call.List<selectallBusinessDetailsDtos>("selectallBusinessDetails", null);

                                objmodel.objBusinessDetails = ds.Tables[0].AsEnumerable().Select(row => new selectallBusinessDetailsDtos
                                {         //                        

                                    Id = Convert.ToString(row["Id"].ToString()),
                                    name = Convert.ToString(row["name"].ToString()),
                                    description = row["description"].ToString(),
                                    profilephoto = row["profilephoto"].ToString(),
                                    mobileno2 = Convert.ToString(row["mobileno2"].ToString()),
                                    PhoneNumber = Convert.ToString(row["PhoneNumber"].ToString()),
                                    rating = Convert.ToInt32(row["rating"].ToString()),
                                    cityname = row["cityname"].ToString(),
                                    businesstime = Convert.ToString(row["businesstime"].ToString()),
                                    Email = Convert.ToString(row["Email"].ToString()),


                                });


                                //objmodel.SearchModelType = "businessowner".ToString().ToLower().Trim();
                                ////public IEnumerable<search_BusinessOwnerRegistrationDtos> objsearch_BusinessOwnerRegistrationDtos { get; set; }
                                //objmodel.objsearch_BusinessOwnerRegistrationDtos = ds.Tables[0].AsEnumerable().Select(row => new search_BusinessOwnerRegistrationDtos
                                //{
                                //    id = Convert.ToString(row["id"].ToString()),
                                //    name = Convert.ToString(row["name"].ToString()),
                                //    profilephoto = row["profilephoto"].ToString(),
                                //    mobileno1 = row["mobileno1"].ToString(),
                                //    mobileno2 = Convert.ToString(row["mobileno2"].ToString()),
                                //    emailid1 = Convert.ToString(row["emailid1"].ToString()),
                                //    emailid2 = row["emailid2"].ToString(),
                                //    adharcardno = row["adharcardno"].ToString(),
                                //    adharcardphoto = Convert.ToString(row["adharcardphoto"].ToString()),
                                //    pancardno = Convert.ToString(row["pancardno"].ToString()),
                                //    pancardphoto = row["pancardphoto"].ToString(),
                                //    gender = row["gender"].ToString(),
                                //    DOB = Convert.ToDateTime(row["DOB"].ToString()),
                                //    house = Convert.ToString(row["house"].ToString()),
                                //    landmark = row["landmark"].ToString(),
                                //    street = row["street"].ToString(),

                                //    cityid = row["cityid"].ToString(),
                                //    zipcode = row["zipcode"].ToString(),
                                //    latitude = Convert.ToString(row["latitude"].ToString()),
                                //    longitude = Convert.ToString(row["longitude"].ToString()),
                                //    companyName = row["companyName"].ToString(),
                                //    designation = row["designation"].ToString(),
                                //    gstno = Convert.ToString(row["gstno"].ToString()),
                                //    Website = Convert.ToString(row["Website"].ToString()),
                                //    Regcertificate = row["Regcertificate"].ToString(),
                                //    businessid = row["businessid"].ToString(),
                                //    productid = Convert.ToString(row["productid"].ToString()),
                                //    lic = row["lic"].ToString(),
                                //    registerbyAffilateID = row["registerbyAffilateID"].ToString(),

                                //    deviceid = Convert.ToString(row["deviceid"].ToString()),
                                //    type = row["type"].ToString(),

                                //});



                            }
                            else
                            {

                            }
                        }
                        catch (Exception obj)
                        {
                            objmodel.SearchModelType = "NotFound";
                        }
                    }
                    else
                    {
                        objmodel.SearchModelType = "NotFound";
                    }

                }
                catch(Exception obj)
                {
                    objmodel.SearchModelType = "Record Not Found";
                    //string myJson2 = "{\"Message\": " + "\"Not Found\"" + "}";
                    //return NotFound(myJson2);
                }
                finally { con.Close(); }


                //--------------------------------------------------------------------------------------
                return View(objmodel);
            }
            catch (Exception obj)
            {

            }
            return View();
            //try
            //{
            //    ViewBag.search = txtsearch;

            //    var parameter = new DynamicParameters();
            //    //  parameter.Add("@businessid", businessid);
            //    // var obj = _sP_Call.List<selectallBusinessDetailsDtos>("selectallBusinessDetails", null );
            //    IEnumerable<selectallBusinessDetailsDtos> obj = _sP_Call.List<selectallBusinessDetailsDtos>("selectallBusinessDetails", null);

            //    return View(obj);


            //}
            //catch (Exception obj)
            //{

            //}
            //return View();
        }
        //private Task<IdentityUser> GetCurrentUserAsync() =>  _usermanager.GetUserAsync(this.User);
        
        [HttpPost]
        public async Task<string> AddReview(string rating, int bussinessid, string review)
        {
            var customerId =User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(customerId!=null)
            {
                // var businessId = _businessOwnerRegiServices.GetAll().Where(x => x.customerid == bussinessid).FirstOrDefault();
                businessrating obj = new businessrating();
                obj.id = 0;
                obj.CustomerId = customerId;
                //obj.BusinessOwnerId =(int)businessId.id;
                obj.BusinessOwnerId = (int)bussinessid;
                obj.rating = rating;
                obj.comment = review;
                obj.isdeleted = false;
                await _businessratingsServices.CreateAsync(obj);
                return "complete";
            }
            else
            {
                return "Login";
            }

              
          
        }
        [HttpPost]    

        public async Task<string> businessContactus(string name, string  email, string mobileno,string msg,int bussinessid)
        {
            //var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var webRootPath = _hostingEnvironment.WebRootPath;

            string businesspath = "http://tingtongindia.com/Admin/Home/business/" + bussinessid;

            string imagepath = "http://tingtongindia.com/uploads/tingtong.png";
            // var businessId = _businessOwnerRegiServices.GetAll().Where(x => x.customerid == bussinessid).FirstOrDefault();
            BusinessContactUs obj = new BusinessContactUs();
            obj.Id = 0;
            obj.businessid = bussinessid;
            //obj.BusinessOwnerId =(int)businessId.id;
            obj.Name  = name;
            obj.Email = email;
            obj.Mobileno  = mobileno;
            obj.Message  = msg;
            await _businessContactUsservices.CreateAsync(obj);

            var businessdetails = _businessOwnerRegiServices.GetById(bussinessid);
            var BusinsssOwnerDetails = _db.applicationUsers.Where(x => x.Id == businessdetails.customerid).FirstOrDefault();


            #region "Email Sent To Business Owner"
            string pancardphotopath = _hostingEnvironment.WebRootPath + ("~/uploads/tingtong logo.png".Replace('/', '\\'));

            StringBuilder str = new StringBuilder();
            str = str.Append("<div>Hello ,</div>");
            str = str.Append("<br />");
            //str = str.Append("<div><img src="+ pancardphotopath + "/> </div>");
            //str = str.Append("<br />");
            str = str.Append("<div><h1>"+ businessdetails.companyName+ "</h1></div>");
            str = str.Append("<br />");
            str = str.Append("<div><h1>" + name+ " has sent you a message from your Business Profile.</div>");
            str = str.Append("<br />");

            

            str = str.Append(@"            

                   <table class='table table - condensed'>
                    <tr>  
                        <td> " + "Details  " + @" 
                        </td>  

                        
                    </tr>
                       <tr>  
                        <td> " + " Name : "+name + @"  
                        </td>                         
                    </tr>
                    <tr>  
                        <td> " + " Email : " + email + @"  
                        </td>                         
                    </tr>
                       <tr>  
                        <td> " + " Mobile No : " + mobileno + @"  
                        </td>                         
                    </tr> 
<tr>  
                        <td> " + " Message : " + msg  + @"  
                        </td>                         
                    </tr> 
               </table> 

                ");
            str = str.Append("<div>Thank you.</div>");

            StringBuilder sb = new StringBuilder();
            sb.Append("<div style = 'margin:0 auto;padding:0px' bgcolor = '#ffffff'>" + 
         //"<p style = 'padding-top:0;font-size:0px;line-height:0px;color:#ffffff' align = 'center'></p> "+
          "<table border = '0' cellpadding = '0' cellspacing = '0' width = '100%' align = 'center' >" +

                       "<tbody>" +
                           "<tr>" +

                               "<td align = 'center' valign = 'top' bgcolor = '#ffffff' >" +




                                        "<table border = '0' cellpadding = '0' cellspacing = '0' width = '800' align = 'center' >" +


                        "<tbody>" +
                            "<tr>" +
                                "<td align = 'center' valign='top' bgcolor='#ffffff'>" +
                                    "<table border = '0' cellpadding='0' cellspacing='0' width='100%' align='center'>" +

                                        "<tbody>" +
                                            "<tr>" +
                                                "<td align = 'center' valign='top' style='border-bottom:1px solid #cccfd2'>" +
                                                    "<table border = '0' cellpadding='0' cellspacing='0' width='100%' align='center'>" +
                                                        "<tbody>" +
                                                            "<tr>" +
                                                                "<td align = 'center' valign='top'>" +
                                                                    "<table border = '0' cellpadding='0' cellspacing='0' align='center'>" +
                                                                        "<tbody>" +
                                                                            "<tr>" +
                                                                                "<td class='m_-2128789134426773361pad_bot_4' align='center' valign='top' style='padding-top:24px;padding-bottom:31px'>" +
                                                                                    "<a href = '"+ businesspath + "' style='text-decoration:none' target='_blank' >" +
                                                                                        "<img src = '"+ imagepath + "' width='192' alt='Visit My Business' title='Google My Business' style='display:block;height:auto' >" +
                                                                                    "</a>" +
                                                                                "</td>" +
                                                                            "</tr>" +

                                                                        "</tbody>" +
                                                                    "</table>" +
                                                                "</td>" +
                                                            "</tr>" +
                                                            "<tr>" +
                                                                "<td class='m_-2128789134426773361font_32' align='center' width='100%' style='color:#4a4a4a;font-family:Google Sans,Roboto,Helvetica,Arial,sans-serif;font-size:38px;font-weight:normal;line-height:44px;padding:0 0 8px 0;text-align:center'>" +
                                                                    businessdetails.companyName+
                                                                "</td>" +
                                                            "</tr>" +
                                                            "<tr>" +
                                                                "<td class='m_-2128789134426773361font_22' align='center' width='100%' style='color:#80868b;font-family:Google Sans,Roboto,Helvetica,Arial,sans-serif;font-size:26px;font-weight:normal;line-height:33px;padding:0 20px 25px 20px;text-align:center'>" +
                                                                    "<a href = '#m_-2128789134426773361_' style='color:#80868b;text-decoration:none'>" + businessdetails.house+"</a>" +
                                                                "</td>" +
                                                            "</tr>" +
                                                        "</tbody>" +
                                                    "</table>" +
                                                "</td>" +
                                            "</tr>" +


                                            "<tr>" +
                                                "<td align = 'center' valign='top'>" +
                                                    "<table width = '530' border='0' cellspacing='0' cellpadding='0' class='m_-2128789134426773361table-main-gmail'>" +
                                                        "<tbody>" +
                                                            "<tr>" +
                                                                "<td align = 'center' valign='top' style='padding-top:24px'>" +
                                                                    "<a href = '#m_-2128789134426773361_' style='display:block;width:422px'>" +
                                                                        "<img src = 'https://ci4.googleusercontent.com/proxy/WFMv2KGZ3Y1zuZFXIE-AFa9wz6ov5p_iJake0vtWudwsg6g9KpQzQt6uC7c7Y4BpRjSVK0f6CUw-ku1LAwUUTfEMFqYoryi8tx6V5JajNFvMXAtHtqZxlnHBlYmd4PnZ1UYcYH8lGnW2lBLv=s0-d-e1-ft#https://services.google.com/fh/files/emails/new_message_notification_hero_image_final.png' alt='SHASWAT SHETI ?????? ???? has sent you a message from your Business Profile.' title='SHASWAT SHETI ?????? ???? has sent you a message from your Business Profile.' width='422' style='display:block;width:422px;width:100%' class='CToWUd'>" +
                                                                    "</a>" +
                                                                "</td>" +
                                                            "</tr>" +
                                                            "<tr>" +
                                                                "<td align = 'center' valign='top'>" +
                                                                    "<table class='m_-2128789134426773361width_85' align='center' cellpadding='0' cellspacing='0' border='0' width='100%'>" +
                                                                        "<tbody>" +
                                                                            "<tr>" +
                                                                                "<td class='m_-2128789134426773361head_font' align='center' style='color:#3c4043;font-family:Google Sans,Roboto,Helvetica,Arial,sans-serif;font-size:24px;line-height:32px;padding:17px 0 25px 0;text-align:center'>"
                                                                                +    name +" has sent you a message from your Business Profile. </td>" +
                                                                            "</tr>" +
                                                                        "</tbody>" +
                                                                    "</table>" +
                                                                "</td>" +
                                                            "</tr>" +

                                                            "<tr>" +
                                                                "<td align = 'center' valign='top'>" +
                                                                    "<table class='m_-2128789134426773361but' width='100%' border='0' cellspacing='0' cellpadding='0'>" +
                                                                        "<tbody>" +
                                                                            "<tr>" +
                                                                                "<td align = 'center' valign='middle' background='https://ci4.googleusercontent.com/proxy/03SIZpyYwBiobCVXMYJdcvJ-60g-PuuRLUpFhU7ngwK8STiK6jblC-GqxqMGodeqYjFssq7RbjhYLeDYQn5CmSKvmbkRuraMTSfqdE6agel7Bhh3LMP7kw=s0-d-e1-ft#https://services.google.com/fh/files/emails/cta_bg_for_outlook_2x.png' style='background-image:url(https://ci4.googleusercontent.com/proxy/03SIZpyYwBiobCVXMYJdcvJ-60g-PuuRLUpFhU7ngwK8STiK6jblC-GqxqMGodeqYjFssq7RbjhYLeDYQn5CmSKvmbkRuraMTSfqdE6agel7Bhh3LMP7kw=s0-d-e1-ft#https://services.google.com/fh/files/emails/cta_bg_for_outlook_2x.png);background-position:top left;background-repeat:no-repeat;height:46px;vertical-align:middle;background-size:cover' height='46'>" +

                                                                                    "<table cellspacing = '0' cellpadding='0' align='center'>" +
                                                                                        "<tbody>" +
                                                                                            "<tr>" +
                                                                                                "<td style = 'border-radius:2px;background-color:#1a73e8;color:#ffffff!important;text-align:center;vertical-align:middle' align='center'>" +
                                                                                                    //"<a style = 'display:block;border-radius:2px;color:#ffffff;text-decoration:none;font-family:Google Sans,Roboto,Helvetica Neue,Helvetica,Arial,sans-serif;font-size:14px;line-height:16px;font-weight:500;border-top:15px solid #1a73e8;white-space:nowrap;border-right:23px solid #1a73e8;border-bottom:15px solid #1a73e8;border-left:23px solid #1a73e8;text-align:center' href='https://business.google.com/messaging/l/09174996291137165437?msgId=250F36F2-D45F-45B1-8470-10EDF6CF3B84&amp;webGroupId=%2B1-dec30638-367d-4b25-90ee-087c4f43ccdd&amp;lid=15407764329372838650&amp;trk=https%3A%2F%2Fwww.google.com%2Fappserve%2Fmkt%2Fp%2FAD-FnEx_oUVkJjYOn9o5dMJ2MdvoED3rAq0ZXYe7xq1j2agh68UJF5u78G1oTCAw7AKoFi6X_dvQDuLcu4EUsHzJ' target='_blank' data-saferedirecturl='https://www.google.com/url?q=https://business.google.com/messaging/l/09174996291137165437?msgId%3D250F36F2-D45F-45B1-8470-10EDF6CF3B84%26webGroupId%3D%252B1-dec30638-367d-4b25-90ee-087c4f43ccdd%26lid%3D15407764329372838650%26trk%3Dhttps%253A%252F%252Fwww.google.com%252Fappserve%252Fmkt%252Fp%252FAD-FnEx_oUVkJjYOn9o5dMJ2MdvoED3rAq0ZXYe7xq1j2agh68UJF5u78G1oTCAw7AKoFi6X_dvQDuLcu4EUsHzJ&amp;source=gmail&amp;ust=1611206143522000&amp;usg=AFQjCNHJtpW20MFA6KA_nnd3uyOcjfdJZg'> Respond</a>" +
                                                                                                "</td>" +
                                                                                            "</tr>" +
                                                                                        "</tbody>" +
                                                                                    "</table>" +

                                                                                "</td>" +
                                                                            "</tr>" +
                                                                        "</tbody>" +
                                                                    "</table>" +
                                                                "</td>" +
                                                            "</tr>" +
                                                        "</tbody>" +
                                                    "</table>" +
                                                "</td>" +
                                            "</tr>" +


                                            "<tr>" +
                                                "<td class='m_-2128789134426773361block' height='32' style='line-height:32px'>" +
                                                    "<img src = 'https://ci3.googleusercontent.com/proxy/Zre1fAeZon4GoBOJld1BwQBOoDp_nPvbMfWpo_oz1aUl9pMZintgHpbeOa_lM19isQUdBIWybtskSbQzO011QdafXFOEgtL5DEZ2dw=s0-d-e1-ft#https://services.google.com/fh/files/emails/spacer_11.gif' width='1' height='1' border='0' alt='' style='display:block' class='CToWUd'>" +
                                                "</td>" +
                                            "</tr>" +



                                            "<tr>" +
                                                "<td align = 'center' valign='top'>" +
                                                    "<table width = '496' border='0' cellspacing='0' cellpadding='0' class='m_-2128789134426773361width_445'>" +
                                                        "<tbody>" +
                                                            "<tr>" +
                                                                "<td align = 'center' valign='top' style='border:#dfdfdf 1px solid;border-radius:10px;padding-bottom:11px'>" +
                                                                    "<table width = '100%' border='0' cellspacing='0' cellpadding='0'>" +
                                                                        "<tbody>" +
                                                                            "<tr>" +
                                                                                "<td align = 'center' valign='top' width=''>" +
                                                                                    "<table width = '100%' cellpadding='0' cellspacing='0' border='0'>" +
                                                                                        "<tbody>" +
                                                                                            "<tr>" +
                                                                                                "<td align = 'center' valign='top'>" +
                                                                                                    "<table border = '0' cellspacing='0' cellpadding='0' bgcolor='#F5F5F5' style='max-width:496px;width:100%;border-top-left-radius:10px;border-top-right-radius:10px;border-bottom:#dfdfdf 1px solid'>" +
                                                                                                        "<tbody>" +
                                                                                                            "<tr>" +
                                                                                                                "<td align = 'center' valign='top' style='color:#3c4043;font-family:Google Sans,Roboto,Helvetica,Arial,sans-serif;font-size:16px;line-height:20px;padding:5px 0 5px 0;text-align:center'>" +
                                                                                                                    "Details"+
                                                                                                                "</td>" +
                                                                                                            "</tr>" +
                                                                                                        "</tbody>" +
                                                                                                    "</table>" +
                                                                                                "</td>" +
                                                                                            "</tr>" +
                                                                                        "</tbody>" +
                                                                                    "</table>" +
                                                                                "</td>" +
                                                                            "</tr>" +
                                                                            "<tr>" +
                                                                                "<td align = 'center' valign='top' width=''>" +
                                                                                    "<table width = '100%' cellpadding='0' cellspacing='0' border='0'>" +
                                                                                        "<tbody>" +
                                                                                            "<tr>" +
                                                                                                "<td class='m_-2128789134426773361width_445' align='center' valign='top' width='496'>" +
                                                                                                    "<table class='m_-2128789134426773361width_445' border='0' cellspacing='0' cellpadding='0' bgcolor='#ffffff' width='496' style='max-width:496px;width:100%'>" +
                                                                                                        "<tbody>" +
                                                                                                            "<tr>" +
                                                                                                                "<td class='m_-2128789134426773361block' height='27' style='line-height:27px'>" +
                                                                                                                    "<img src = 'https://ci3.googleusercontent.com/proxy/Zre1fAeZon4GoBOJld1BwQBOoDp_nPvbMfWpo_oz1aUl9pMZintgHpbeOa_lM19isQUdBIWybtskSbQzO011QdafXFOEgtL5DEZ2dw=s0-d-e1-ft#https://services.google.com/fh/files/emails/spacer_11.gif' width='1' height='1' border='0' alt='' style='display:block' class='CToWUd'>" +
                                                                                                                "</td>" +
                                                                                                            "</tr>" +
                                                                                                            "<tr>" +
                                                                                                                "<td style = 'color:#3c4043;font-family:Roboto,Helvetica,Arial,sans-serif;font-size:14px;font-weight:500;line-height:20px;text-align:left;padding-bottom:15px;padding-left:40px;padding-right:40px' align='left'>" +
                                                                                                                    "Name: <span style = 'color:#3c4043;font-size:14px;line-height:20px;text-align:center;font-weight:400' align='center'>" +name +"</span>" +
                                                                                                                "</td>" +
                                                                                                            "</tr>" +
                                                                                                            "<tr>" +
                                                                                                                "<td style = 'color:#3c4043;padding-bottom:4px;font-family:Roboto,Helvetica,Arial,sans-serif;font-size:14px;font-weight:500;line-height:20px;text-align:left;padding-left:40px;padding-right:40px' align='left'>" +
                                                                                                                    "Mobile No. :" +
                                                                                                                "</td>" +
                                                                                                            "</tr>" +
                                                                                                            "<tr>" +
                                                                                                                "<td class='m_-2128789134426773361padd28' style='color:#3c4043;padding-bottom:28px;font-family:Roboto,Helvetica,Arial,sans-serif;font-size:14px;line-height:14px;margin:0 auto;padding-left:40px;padding-right:40px' align='left'>" +
                                                                                                                    mobileno +
                                                                                                                "</td>" +
                                                                                                            "<tr>" +
                                                                                                                "<td style = 'color:#3c4043;padding-bottom:4px;font-family:Roboto,Helvetica,Arial,sans-serif;font-size:14px;font-weight:500;line-height:20px;text-align:left;padding-left:40px;padding-right:40px' align='left'>" +
                                                                                                                    "Message:"+
                                                                                                                "</td>" +
                                                                                                            "</tr>" +
                                                                                                            "<tr>" +
                                                                                                                "<td class='m_-2128789134426773361padd28' style='color:#3c4043;padding-bottom:28px;font-family:Roboto,Helvetica,Arial,sans-serif;font-size:14px;line-height:14px;margin:0 auto;padding-left:40px;padding-right:40px' align='left'>" +
                                                                                                                    msg+
                                                                                                                "</td>" +
                                                                                                            "</tr>" +
                                                                                                            "<tr>" +
                                                                                                                "<td style = 'color:#4a4a4a;padding-bottom:18px;font-family:Roboto,Helvetica,Arial,sans-serif;font-size:10px;font-style:italic;line-height:14px;padding-left:40px;padding-right:40px' align='left'>" +
                                                                                                                    "<em>" + "*This information has been supplied directly by the customer.</em>" +
                                                                                                                "</td>" +
                                                                                                            "</tr>" +
                                                                                                        "</tbody>" +
                                                                                                    "</table>" +
                                                                                                "</td>" +
                                                                                            "</tr>" +
                                                                                        "</tbody>" +
                                                                                    "</table>" +
                                                                                "</td>" +
                                                                            "</tr>" +
                                                                        "</tbody>" +
                                                                    "</table>" +
                                                                "</td>" +
                                                            "</tr>" +
                                                        "</tbody>" +
                                                    "</table>" +
                                                "</td>" +
                                            "</tr>" +






                                        "</tbody>" +
                                    "</table>" +
                                "</td>" +
                            "</tr>" +



                        "</tbody>" +
                    "</table>" +
                "</td>" +
            "</tr>" +
        "</tbody>" +
    "</table>" +




"</div>");







            #endregion
            await _emailSender.SendEmailAsync(
                   BusinsssOwnerDetails.Email,
                   "Message from "+name,
                 sb.ToString()
                  );

            return "complete";
        }
        [HttpGet]
        public IActionResult business(string id)
        {
          //  LoginUserDetails();
            businessDetailsViewModel obj = new businessDetailsViewModel();


            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);

            obj.objgetBusinessAllInfo = _sP_Call.OneRecord<getBusinessAllInfo>("selectallBusinessDetailsAllInfo", parameter);

            obj.objBusinessSliderModel = _sP_Call.List<BusinessSliderModel>("getBusinessSliderImagebyBusinessId", parameter);



            //var parameter1 = new DynamicParameters();
            //parameter1.Add("@BusinessOwnerId", id);
            obj.objbusinessrating = _sP_Call.List<selectallBusinessRatingViewModel>("selectallBusinessRating", parameter);


            //------------
            string markers = "[";
            markers += "{";
            markers += string.Format("'title': '{0}',", obj.objgetBusinessAllInfo.companyName);
            markers += string.Format("'lat': '{0}',", obj.objgetBusinessAllInfo.latitude);
            markers += string.Format("'lng': '{0}',", obj.objgetBusinessAllInfo.longitude);
            markers += string.Format("'description': '{0}'", obj.objgetBusinessAllInfo.description);
            markers += "}";
            markers += "];";
            ViewBag.Markers = markers;
            if (obj == null)
            {
                return View();
            }
            else
            {
                return View(obj);

            }



        }

        [HttpGet]
        public IActionResult businessDetails(int sectorid)
        {
          //  LoginUserDetails();
            //var obj = _BusinessRegistrationServieces.GetAll().Where(x => x.sectorid == sectorid && x.isdeleted == false).Select(x => new BusinessRegistrationIndexViewModel
            //{
            //    id = x.id,
            //    sectorid = x.sectorid,
            //    name = x.name,
            //    SectorRegistration = _SectorRegistrationServices.GetById(x.sectorid),
            //    img = x.img,
            //    photo = x.photo

            //}).ToList();
            //return View(obj);
            var obj = _BusinessRegistrationServieces.GetAll().Where(x => x.sectorid == sectorid && x.isdeleted == false).ToList();
            return View(obj);
        }
        [HttpGet]
        public IActionResult productDetails(int businessid)
        {
           // LoginUserDetails();
            var obj = _productMasterServices.GetAll().Where(x => x.businessid == businessid && x.isdeleted == false).Select(x => new ProductIndexViewModel
            {


                id = x.id,
                //sectorid = x.se,
                businessid = x.businessid,
                productName = x.productName,
                BusinessRegistration = _BusinessRegistrationServieces.GetById(x.businessid),
                SectorRegistration = _SectorRegistrationServices.GetById(_BusinessRegistrationServieces.GetById(x.businessid).sectorid),
                img = x.img

            }).ToList();
            return View(obj);
        }


        public IActionResult Privacy()
        {
           // LoginUserDetails();
            return View();
        }
        public IActionResult about()
        {
          //  LoginUserDetails();
            AboutUs obj = _aboutUsServices.GetById(1);
            return View(obj);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        public IActionResult ContactUs()
        {
           // LoginUserDetails();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ContactUs(ContactUsViewModel model)
        {

            if (ModelState.IsValid)
            {
                var obj = new ContactUs
                {
                    id = model.id
       ,
                    name = model.name
       ,
                    Email = model.Email
       ,
                    Mobileno = model.Mobileno
       ,
                    Address = model.Address

                };

                Int32 id = await _ContactUsServices.CreateAsync(obj);
                //var postId = await _CustomerRegistrationservices.CreateAsync(objcustomerRegistration);
                return RedirectToAction(nameof(Index));

            }
            else
            {
                return View();
            }

        }



        public IActionResult SubscribeDetails(Subscribe obj)
        {
            return View();
        }

        //private void AddDetails(EmpModel obj)
        //{
        //    connection();
        //    SqlCommand com = new SqlCommand("AddEmp", con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    com.Parameters.AddWithValue("@Name", obj.Name);
        //    com.Parameters.AddWithValue("@City", obj.City);
        //    com.Parameters.AddWithValue("@Address", obj.Address);
        //    con.Open();
        //    com.ExecuteNonQuery();
        //    con.Close();

        //}


        //public IActionResult BusinessListing(int productid)
        //{
        //   // LoginUserDetails();
        //    BusinessListingViewModel obj = new BusinessListingViewModel();


        //    try
        //    {
        //        int businessid = _productMasterServices.GetById(productid).businessid;
        //        obj.objProductIndexViewModel = _productMasterServices.GetAll().Where(x=>x.businessid==businessid).Select(x => new ProductIndexViewModel
        //        {


        //            id = x.id,
        //            //sectorid = x.se,
        //            businessid = x.businessid,
        //            productName = x.productName,
        //            // BusinessRegistration = _BusinessRegistrationServiecess.GetById(x.businessid),
        //            // SectorRegistration = _SectorRegistrationServices.GetById(_BusinessRegistrationServiecess.GetById(x.businessid).sectorid),
        //            img = x.img

        //        }).ToList();
        //        var parameter = new DynamicParameters();
        //        parameter.Add("@productid", productid);
        //        // parameter.Add("@productid", 4);

        //        //   obj.objgetBusinessAllInfo = _sP_Call.List<getBusinessAllInfo>("selectallBusinessDetailsAllInfo_byyProductId", parameter);

        //        obj.objgetBusinessAllInfo = _sP_Call.List<getBusinessAllInfo>("selectallBusinessDetailsAllInfo_byyProductIdTest", parameter);

        //    }
        //    catch(Exception objmsg)
        //    {
        //        string p = objmsg.Message;
        //    }




        //    return View(obj);
        //    //return View();
        //}
        [HttpGet]
        public IEnumerable<getBusinessAllInfo> BusinessListingGetALL(int  businessid, int productidd,int pageno)
        {

            
            //var parameter = new DynamicParameters();
            //parameter.Add("@productid", 0);
            //parameter.Add("@businessid", 1063);

            // var objgetBusinessAllInfo = _sP_Call.List<getBusinessAllInfo>("selectallBusinessDetailsAllInfo_byyProductIdTest", parameter);

            //return Json(new { data = objgetBusinessAllInfo.ToList() });
            var parameter = new DynamicParameters();
            parameter.Add("@productid", productidd);
            parameter.Add("@businessid", businessid);
            parameter.Add("@pageno", pageno);

            IEnumerable<getBusinessAllInfo> objgetBusinessAllInfo = _sP_Call.List<getBusinessAllInfo>("selectallBusinessDetailsAllInfo_byyProductIdTest", parameter);

            return objgetBusinessAllInfo;

        }


        public IActionResult BusinessListing(int businessid,int productid )
        {
            // LoginUserDetails();
            BusinessListingViewModel obj = new BusinessListingViewModel();


            try
            {
                ViewBag.businessIdd = businessid;
                ViewBag.productidd = productid;
                //int businessid = _productMasterServices.GetById(productid).businessid;
                obj.objProductIndexViewModel = _productMasterServices.GetAll().Where(x => x.businessid == businessid).Select(x => new ProductIndexViewModel
                {


                    id = x.id,
                    //sectorid = x.se,
                    businessid = x.businessid,
                    productName = x.productName,
                    // BusinessRegistration = _BusinessRegistrationServiecess.GetById(x.businessid),
                    // SectorRegistration = _SectorRegistrationServices.GetById(_BusinessRegistrationServiecess.GetById(x.businessid).sectorid),
                    img = x.img

                }).ToList();
                var parameter = new DynamicParameters();
                parameter.Add("@productid", productid);
                parameter.Add("@businessid", businessid);
                // parameter.Add("@productid", 4);

                //   obj.objgetBusinessAllInfo = _sP_Call.List<getBusinessAllInfo>("selectallBusinessDetailsAllInfo_byyProductId", parameter);

                obj.objgetBusinessAllInfo = _sP_Call.List<getBusinessAllInfo>("selectallBusinessDetailsAllInfo_byyProductIdTestCount", parameter);
                ViewBag.RecordCount = obj.objgetBusinessAllInfo.Count();

            }
            catch (Exception objmsg)
            {
                string p = objmsg.Message;
            }




            return View(obj);
            //return View();
        }




        [HttpGet]
        public IActionResult Category()
        {
          //  LoginUserDetails();
            var parameter = new DynamicParameters();
            IEnumerable<selectallSectorWithBusinessCount> obj = _sP_Call.List<selectallSectorWithBusinessCount>("selectallSectorWithBusinessCount", null);

            return View(obj);
        }
        [HttpGet]
        public IActionResult Advertising()
        {
          //  LoginUserDetails();
            return View();
        }


        public IActionResult TermsandConditions()
        {
           // LoginUserDetails();
            return View();
        }
        public IActionResult PrivacyPolicy()
        {
          //  LoginUserDetails();
            return View();
        }


        [HttpGet]
        public async  Task<IActionResult> CommissionCal()
        {
            //BusinessContactUs obj = new BusinessContactUs();
            //obj.Id = 0;
            //obj.businessid = 1;
            ////obj.BusinessOwnerId =(int)businessId.id;
            //obj.Name = "yogita";
            //obj.Email = "test@gmail.com";
            //obj.Mobileno = "999999999999";
            //obj.Message = "hi";
            //await _businessContactUsservices.CreateAsync(obj);

            _sP_Call.Execute("calculatecommissionNightSP", null);
            return View( );
        }
    }
}
