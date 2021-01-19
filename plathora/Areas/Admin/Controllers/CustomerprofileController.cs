using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using plathora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using plathora.DataAccess;
//using plathora.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Microsoft.AspNetCore.Authorization;
using plathora.Utility;
using plathora.Persistence;
using Microsoft.AspNetCore.Authorization;

using plathora.Utility;
using Microsoft.AspNetCore.Identity;
using plathora.Entity;
using plathora.Services;
using plathora.Services.Implementation;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Dapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;

using plathora.Models.Dtos;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace plathora.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Customer)]
    public class CustomerprofileController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        //  private readonly IAffiltateRegistrationService _AffiltateRegistrationService;
        private readonly IMembershipServices _MembershipServices;
        private readonly ICountryRegistrationservices _CountryRegistrationservices;
        private readonly IStateRegistrationService _StateRegistrationService;
        private readonly ICityRegistrationservices _CityRegistrationservices;
        private readonly IAffilatePackageServices _AffilatePackageServices;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ISP_Call _sP_Call;
        private readonly ApplicationDbContext _db;
        private readonly IBusinessOwnerRegiServices _businessOwnerRegiServices;
        //private readonly UserManager<ApplicationUser> _usermanager;
        public CustomerprofileController(ISP_Call sP_Call, ApplicationDbContext db, IMembershipServices MembershipServices, ICountryRegistrationservices CountryRegistrationservices, ICityRegistrationservices CityRegistrationservices, IAffilatePackageServices AffilatePackageServices, IStateRegistrationService StateRegistrationService, IWebHostEnvironment hostingEnvironment, UserManager<IdentityUser> userManager, IBusinessOwnerRegiServices businessOwnerRegiServices)
        {
            _sP_Call = sP_Call;
            _db = db;
            _MembershipServices = MembershipServices;
            _CountryRegistrationservices = CountryRegistrationservices;
            _StateRegistrationService = StateRegistrationService; ;
            _CityRegistrationservices = CityRegistrationservices;
            _AffilatePackageServices = AffilatePackageServices;
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
            _businessOwnerRegiServices = businessOwnerRegiServices;
            //_usermanager = usermanager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult Profile()
        //{
        //    return View();
        //}


        [HttpGet]
        public IActionResult Profile()
        {
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var parameter = new DynamicParameters();
            //parameter.Add("@Id", id);
            //var objrolename = _sP_Call.OneRecord<getRoleName>("getRoleNamebyUserId", parameter);




            var objfromdb = _db.applicationUsers.FirstOrDefault(u => u.Id == customerId);
            ViewBag.Countries = _CountryRegistrationservices.GetAllCountry();
            ViewBag.membershiplist = _MembershipServices.GetAll().ToList();
            int countryiddd = 0, stateid = 0, countryid = 0;


            //get role name
            var userRole = _db.UserRoles.ToList();
            var Roles = _db.Roles.ToList();
            var roleId = userRole.FirstOrDefault(u => u.UserId == customerId).RoleId;
            string rolname = Roles.FirstOrDefault(u => u.Id == roleId).Name;



            if (objfromdb.cityid != null)
            {
                int cityiddd = (int)objfromdb.cityid;
                //  countryiddd = (int)objfromdb.cityid;
                stateid = _CityRegistrationservices.GetById(cityiddd).stateid;
                countryid = _StateRegistrationService.GetById(stateid).countryid;
            }

            if (objfromdb == null)
            {
                return NotFound();
            }
            var model = new EditApplicationUser
            {
                //usertype=objrolename.Rolename,
                Id = objfromdb.Id,
                name = objfromdb.name,
                MiddleName = objfromdb.MiddleName,
                LastName = objfromdb.LastName,
                profilephoto1 = objfromdb.profilephoto,
                PhoneNumber = objfromdb.PhoneNumber,
                mobileno2 = objfromdb.mobileno2,
                Email = objfromdb.Email,
                emailid2 = objfromdb.emailid2,
                adharcardno = objfromdb.adharcardno,
                adharcardphoto1 = objfromdb.adharcardphoto,
                pancardno = objfromdb.pancardno,
                pancardphoto1 = objfromdb.pancardphoto,
                gender = objfromdb.gender,
                DOB = objfromdb.DOB,
                house = objfromdb.house,
                landmark = objfromdb.landmark,
                street = objfromdb.street,

                countryid = countryid,
                stateid = stateid,
                cityid = objfromdb.cityid,
                zipcode = objfromdb.zipcode,

                //latitude = objfromdb.latitude,
                //  longitude = objfromdb.longitude,
                // companyName = objfromdb.companyName,
                // designation = objfromdb.designation,
                //  gstno = objfromdb.gstno,
                //  Website = objfromdb.Website,
                bankname = objfromdb.bankname,
                accountname = objfromdb.accountname,
                accountno = objfromdb.accountno,
                ifsccode = objfromdb.ifsccode,
                branch = objfromdb.branch,
                passbookphoto1 = objfromdb.passbookphoto,
                // Membershipid = objfromdb.Membershipid,
                //  amount = objfromdb.amount,
                rolename = rolname

            };
            ViewBag.States = _StateRegistrationService.GetAllState(countryid);
            ViewBag.Cities = _CityRegistrationservices.GetAllCity(stateid);
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(EditApplicationUser model)
        {
            if (ModelState.IsValid)
            {

                var affilatereg = _db.applicationUsers.FirstOrDefault(u => u.Id == model.Id);
                if (affilatereg == null)
                {
                    return NotFound();
                }



                affilatereg.Id = model.Id;
                affilatereg.name = model.name;
                affilatereg.MiddleName = model.MiddleName;
                affilatereg.LastName = model.LastName;
                //profilephoto,
                affilatereg.PhoneNumber = model.PhoneNumber;
                affilatereg.mobileno2 = model.mobileno2;
                affilatereg.Email = model.Email;
                affilatereg.emailid2 = model.emailid2;
                affilatereg.adharcardno = model.adharcardno;
                //adharcardphoto,
                affilatereg.pancardno = model.pancardno;
                // pancardphoto,

                affilatereg.gender = model.gender;
                affilatereg.DOB = model.DOB;
                //   affilatereg.createddate = model.createddate;
                affilatereg.house = model.house;
                affilatereg.landmark = model.landmark;
                affilatereg.street = model.street;
                affilatereg.zipcode = model.zipcode;
                affilatereg.cityid = model.cityid;
                //affilatereg.companyName = model.companyName;
                //affilatereg.designation = model.designation;
                //affilatereg.gstno = model.gstno;
                //affilatereg.Website = model.Website;
                affilatereg.bankname = model.bankname;
                affilatereg.accountname = model.accountname;

                affilatereg.accountno = model.accountno;
                affilatereg.ifsccode = model.ifsccode;
                affilatereg.branch = model.branch;
                //affilatereg.Membershipid = model.Membershipid;
                //affilatereg.amount = model.amount;



                if (model.profilephoto != null && model.profilephoto.Length > 0)
                {
                    var uploadDir = @"uploads/user/profilephoto";
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    //--------delette 


                    var fileName = Path.GetFileNameWithoutExtension(model.profilephoto.FileName);
                    var extesion = Path.GetExtension(model.profilephoto.FileName);

                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.profilephoto.CopyToAsync(new FileStream(path, FileMode.Create));
                    affilatereg.profilephoto = '/' + uploadDir + '/' + fileName;



                }
                if (model.pancardphoto != null && model.pancardphoto.Length > 0)
                {


                    var uploadDir = @"uploads/user/pancardphoto";
                    var webRootPath = _hostingEnvironment.WebRootPath;


                    var fileName = Path.GetFileNameWithoutExtension(model.pancardphoto.FileName);
                    var extesion = Path.GetExtension(model.pancardphoto.FileName);

                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.pancardphoto.CopyToAsync(new FileStream(path, FileMode.Create));
                    affilatereg.pancardphoto = '/' + uploadDir + '/' + fileName;

                }
                if (model.adharcardphoto != null && model.adharcardphoto.Length > 0)
                {
                    var uploadDir = @"uploads/user/adharcardphoto";
                    var fileName = Path.GetFileNameWithoutExtension(model.adharcardphoto.FileName);
                    var extesion = Path.GetExtension(model.adharcardphoto.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.adharcardphoto.CopyToAsync(new FileStream(path, FileMode.Create));


                    affilatereg.adharcardphoto = '/' + uploadDir + '/' + fileName;

                }
                if (model.passbookphoto != null && model.passbookphoto.Length > 0)
                {
                    var uploadDir = @"uploads/user/passbookphoto";
                    var fileName = Path.GetFileNameWithoutExtension(model.passbookphoto.FileName);
                    var extesion = Path.GetExtension(model.passbookphoto.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.passbookphoto.CopyToAsync(new FileStream(path, FileMode.Create));


                    affilatereg.passbookphoto = '/' + uploadDir + '/' + fileName;

                }
                var result = await _userManager.UpdateAsync(affilatereg);
                // await _AffiltateRegistrationService.UpdateAsync(affilatereg);




                return RedirectToAction(nameof(Profile));

            }
            else
            {
                ViewBag.Countries = _CountryRegistrationservices.GetAllCountry();
                ViewBag.membershiplist = _MembershipServices.GetAll().ToList();
                int countryiddd = 0, stateid = 0, countryid = 0;



                if (model.cityid != null)
                {
                    countryiddd = (int)model.cityid;
                    stateid = _CityRegistrationservices.GetById(countryiddd).stateid;
                    countryid = _StateRegistrationService.GetById(stateid).countryid;
                }
                ViewBag.States = _StateRegistrationService.GetAllState(countryid);
                ViewBag.Cities = _CityRegistrationservices.GetAllCity(stateid);
                return View(model);
            }

        }

        public JsonResult getstatebyid(int id)
        {

            IList<StateRegistration> obj = _StateRegistrationService.GetAll().Where(x => x.countryid == id).ToList();
            obj.Insert(0, new StateRegistration { id = 0, StateName = "select", isactive = false, isdeleted = false });
            return Json(new SelectList(obj, "id", "StateName"));
        }
        public JsonResult getCitybyStateid(int stateid)
        {

            IList<CityRegistration> obj = _CityRegistrationservices.GetAll().Where(x => x.stateid == stateid).ToList();
            obj.Insert(0, new CityRegistration { id = 0, cityName = "select", isactive = false, isdeleted = false });
            return Json(new SelectList(obj, "id", "cityName"));
        }


        public IActionResult BusinessListing()//int productid)
        {


            try
            {
                var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var parameter = new DynamicParameters();
                parameter.Add("@CustomerId", customerId);
                IEnumerable<getbusinessListbyCustomerIdViewModel> businessList = _sP_Call.List<getbusinessListbyCustomerIdViewModel>("getbusinessListbyCustomerId", parameter);
                return View(businessList);
            }
            catch (Exception objmsg)
            {
                string p = objmsg.Message;
            }





            return View();
        }

        
        [HttpGet]
        public IActionResult editBusiness(int id)
        {
            var objfromdb = _businessOwnerRegiServices.GetById(id);
            ViewBag.Countries = _CountryRegistrationservices.GetAllCountry();

            int countryiddd = 0, stateid = 0, countryid = 0;



            if (objfromdb.cityid != null)
            {
                int cityiddd = (int)objfromdb.cityid;
                //  countryiddd = (int)objfromdb.cityid;
                stateid = _CityRegistrationservices.GetById(cityiddd).stateid;
                countryid = _StateRegistrationService.GetById(stateid).countryid;
            }

            if (objfromdb == null)
            {
                return NotFound();
            }
            var model = new EditBusinessDetails
            {


                Id = objfromdb.id,

                facebookLink = objfromdb.facebookLink,
                googleplusLink = objfromdb.googleplusLink,
                instagramLink = objfromdb.instagramLink,
                linkedinLink = objfromdb.linkedinLink,
                twitterLink = objfromdb.twitterLink,
                youtubeLink = objfromdb.youtubeLink,
                lic = objfromdb.lic,
                MondayOpen = objfromdb.MondayOpen,
                MondayClose = objfromdb.MondayClose,
                TuesdayOpen = objfromdb.TuesdayOpen,
                TuesdayClose = objfromdb.TuesdayClose,
                WednesdayOpen = objfromdb.WednesdayOpen,
                WednesdayClose = objfromdb.WednesdayClose,
                ThursdayOpen = objfromdb.ThursdayOpen,
                ThursdayClose = objfromdb.ThursdayClose,
                FridayOpen = objfromdb.FridayOpen,
                FridayClose = objfromdb.FridayClose,
                SaturdayOpen = objfromdb.SaturdayOpen,
                SaturdayClose = objfromdb.SaturdayClose,
                SundayOpen = objfromdb.SundayOpen,
                SundayClose = objfromdb.SundayClose,
                house = objfromdb.house,
                landmark = objfromdb.landmark,
                street = objfromdb.street,

                countryid = countryid,
                stateid = stateid,
                cityid = objfromdb.cityid,
                zipcode = objfromdb.zipcode,

                companyName = objfromdb.companyName,

                gstno = objfromdb.gstno,
                Website = objfromdb.Website,
                description = objfromdb.description,
                organization = objfromdb.organization,


                sliderimg11 = objfromdb.sliderimg1,

                sliderimg21 = objfromdb.sliderimg2,
                sliderimg31 = objfromdb.sliderimg3,
                sliderimg41 = objfromdb.sliderimg4,
                sliderimg51 = objfromdb.sliderimg5



            };
            ViewBag.States = _StateRegistrationService.GetAllState(countryid);
            ViewBag.Cities = _CityRegistrationservices.GetAllCity(stateid);
            return View(model);
            //return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> editBusiness(EditBusinessDetails model)
        {
            if (ModelState.IsValid)
            {

                var obj1 = _businessOwnerRegiServices.GetById(model.Id);
                if (obj1 == null)
                {
                    return NotFound();
                }

                obj1.id = model.Id;
                // obj1.customerid = model.customerid;
                obj1.description = model.description;
                //obj1.Regcertificate = model.Regcertificate;
                //obj1.businessid = model.businessid;
                //obj1.productid = model.productid;
                obj1.lic = model.lic;
                obj1.MondayOpen = model.MondayOpen;
                obj1.MondayClose = model.MondayClose;
                obj1.TuesdayOpen = model.TuesdayOpen;
                obj1.TuesdayClose = model.TuesdayClose;
                obj1.WednesdayOpen = model.WednesdayOpen;
                obj1.WednesdayClose = model.WednesdayClose;
                obj1.ThursdayOpen = model.ThursdayOpen;
                obj1.ThursdayClose = model.ThursdayClose;
                obj1.FridayOpen = model.FridayOpen;
                obj1.FridayClose = model.FridayClose;
                obj1.SaturdayOpen = model.SaturdayOpen;
                obj1.SaturdayClose = model.SaturdayClose;
                obj1.SundayOpen = model.SundayOpen;
                obj1.SundayClose = model.SundayClose;
                //obj1.CallCount = model.CallCount;
                //obj1.SMSCount = model.SMSCount;
                //obj1.WhatssappCount = model.WhatssappCount;
                //obj1.ShareCount = model.ShareCount;

                obj1.facebookLink = model.facebookLink;
                obj1.googleplusLink = model.googleplusLink;
                obj1.instagramLink = model.instagramLink;
                obj1.linkedinLink = model.linkedinLink;
                obj1.twitterLink = model.twitterLink;
                obj1.youtubeLink = model.youtubeLink;

                // obj.MembershipId = model.MembershipId;
                obj1.house = model.house;
                obj1.landmark = model.landmark;
                obj1.street = model.street;
                obj1.cityid = model.cityid;
                obj1.zipcode = model.zipcode;
                //obj1.latitude = model.latitude;
                //obj1.longitude = model.longitude;
                obj1.companyName = model.companyName;
                obj1.gstno = model.gstno;
                obj1.Website = model.Website;
                obj1.organization = model.organization ;
                //obj1.businessOperation = model.businessOperation;
                //obj1.businessType = model.businessType;


                if (model.sliderimg1 != null)
                {

                    var uploadDir = @"uploads/businessowner/slider";
                    var fileName = Path.GetFileNameWithoutExtension(model.sliderimg1.FileName);
                    var extesion = Path.GetExtension(model.sliderimg1.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.sliderimg1.CopyToAsync(new FileStream(path, FileMode.Create));
                    obj1.sliderimg1 = '/' + uploadDir + '/' + fileName;



                }

                if (model.sliderimg2 != null)
                {
                    var uploadDir = @"uploads/businessowner/slider";
                    var fileName = Path.GetFileNameWithoutExtension(model.sliderimg2.FileName);
                    var extesion = Path.GetExtension(model.sliderimg2.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.sliderimg2.CopyToAsync(new FileStream(path, FileMode.Create));
                    obj1.sliderimg2 = '/' + uploadDir + '/' + fileName;

                }
                if (model.sliderimg3 != null)
                {

                    var uploadDir = @"uploads/businessowner/slider";
                    var fileName = Path.GetFileNameWithoutExtension(model.sliderimg3.FileName);
                    var extesion = Path.GetExtension(model.sliderimg3.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.sliderimg3.CopyToAsync(new FileStream(path, FileMode.Create));
                    obj1.sliderimg3 = '/' + uploadDir + '/' + fileName;

                }

                if (model.sliderimg4 != null)
                {

                    var uploadDir = @"uploads/businessowner/slider";
                    var fileName = Path.GetFileNameWithoutExtension(model.sliderimg4.FileName);
                    var extesion = Path.GetExtension(model.sliderimg4.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.sliderimg4.CopyToAsync(new FileStream(path, FileMode.Create));
                    obj1.sliderimg4 = '/' + uploadDir + '/' + fileName;

                }
                if (model.sliderimg5 != null)
                {

                    var uploadDir = @"uploads/businessowner/slider";
                    var fileName = Path.GetFileNameWithoutExtension(model.sliderimg5.FileName);
                    var extesion = Path.GetExtension(model.sliderimg5.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.sliderimg5.CopyToAsync(new FileStream(path, FileMode.Create));
                    obj1.sliderimg5 = '/' + uploadDir + '/' + fileName;

                }
                await _businessOwnerRegiServices.UpdateAsync(obj1);




                return RedirectToAction(nameof(BusinessListing));
            }
            else
            {
                ViewBag.Countries = _CountryRegistrationservices.GetAllCountry();

                int countryiddd = 0, stateid = 0, countryid = 0;



                if (model.cityid != null)
                {
                    countryiddd = (int)model.cityid;
                    stateid = _CityRegistrationservices.GetById(countryiddd).stateid;
                    countryid = _StateRegistrationService.GetById(stateid).countryid;
                }
                ViewBag.States = _StateRegistrationService.GetAllState(countryid);
                ViewBag.Cities = _CityRegistrationservices.GetAllCity(stateid);
                return View(model);
            }

        }


        //
        [HttpGet]
        public async Task<IActionResult> deleteBusiness(int id)
        {
            await _businessOwnerRegiServices.Delete(id);
            return RedirectToAction(nameof(BusinessListing));
        }
    }
}
