#pragma checksum "E:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\BusinessListing.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1731f66b6c1b62e0a217fc212897d8c48a4e488b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home_BusinessListing), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/BusinessListing.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\_ViewImports.cshtml"
using plathora;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\_ViewImports.cshtml"
using plathora.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1731f66b6c1b62e0a217fc212897d8c48a4e488b", @"/Areas/Admin/Views/Home/BusinessListing.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"396188bb9b5a5b30811f4f1a58a7e68134b9e9d4", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Home_BusinessListing : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<plathora.Models.BusinessListingViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "BusinessListing", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Subscribe", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\BusinessListing.cshtml"
  
    ViewData["Title"] = "BusinessListing";
    Layout = "~/Views/Shared/_front.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    #myScroll {
        border: 1px solid #999;
    }

    p {
        border: 1px solid #ccc;
        padding: 50px;
        text-align: center;
    }

    .loading {
        color: red;
    }

    .dynamic {
        background-color: #ccc;
        color: #000;
    }
</style>
<!--Topbar-->
<!--Sliders Section-->
<div>

    <input type=""text"" id=""businessid1""");
            BeginWriteAttribute("value", " value=\"", 578, "\"", 606, 1);
#nullable restore
#line 31 "E:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\BusinessListing.cshtml"
WriteAttributeValue("", 586, ViewBag.businessIdd, 586, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"display:none;\" />\r\n    <input type=\"text\" id=\"productid1\"");
            BeginWriteAttribute("value", " value=\"", 672, "\"", 699, 1);
#nullable restore
#line 32 "E:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\BusinessListing.cshtml"
WriteAttributeValue("", 680, ViewBag.productidd, 680, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"display:none;\" />\r\n\r\n\r\n</div>\r\n<!--/Sliders Section-->\r\n<!--Breadcrumb-->\r\n");
            WriteLiteral("<!--/Breadcrumb-->\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 49 "E:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\BusinessListing.cshtml"
  
    if (Model.objSlider != null)
    {
        await Html.RenderPartialAsync("_advertiseSlider", Model.objSlider);
    }


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("<!--Add listing-->\r\n<section class=\"sptb\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-xl-3 col-lg-3 col-md-12\">\r\n");
            WriteLiteral("                <div class=\"card mb-0\">\r\n                    <div class=\"card-header\">\r\n                        <h3 class=\"card-title\">Product</h3>\r\n                    </div>\r\n                    <div class=\"card-body\">\r\n                        <div");
            BeginWriteAttribute("class", " class=\"", 2274, "\"", 2282, 0);
            EndWriteAttribute();
            WriteLiteral(" id=\"container\">\r\n                            <div class=\"filter-product-checkboxs\">\r\n");
#nullable restore
#line 82 "E:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\BusinessListing.cshtml"
                                 foreach (var item in Model.objProductIndexViewModel)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <label class=\"custom-control  mb-3\">\r\n");
            WriteLiteral("                                        <span class=\"custom-control-label\">\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1731f66b6c1b62e0a217fc212897d8c48a4e488b8657", async() => {
#nullable restore
#line 88 "E:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\BusinessListing.cshtml"
                                                                                                                                                                                                       Write(item.productName);

#line default
#line hidden
#nullable disable
                WriteLiteral("<span class=\"label label-primary float-right\"></span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-businessid", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 88 "E:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\BusinessListing.cshtml"
                                                                                                                             WriteLiteral(item.businessid);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["businessid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-businessid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["businessid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 88 "E:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\BusinessListing.cshtml"
                                                                                                                                                                    WriteLiteral(item.id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </span>\r\n                                    </label>\r\n");
#nullable restore
#line 91 "E:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\BusinessListing.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
            WriteLiteral("                </div>\r\n            </div>\r\n\r\n            <!--Right Side Content-->\r\n            <div class=\"col-xl-9 col-lg-9 col-md-12\">\r\n                <!--Add lists-->\r\n                <div class=\" mb-lg-0\">\r\n                    <div");
            BeginWriteAttribute("class", " class=\"", 5357, "\"", 5365, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <div class=\"item2-gl business-list-01\">\r\n\r\n");
            WriteLiteral("\r\n\r\n                            <div class=\"tab-content\">\r\n");
            WriteLiteral(@"                                <div class=""tab-pane active"" id=""businesslist"">


                                </div>
                                <button id=""btnPreviouspage"" class=""btn btn-secondary mb-0"">
                                    Previous
                                </button>
                                <button id=""btnNextpage"" class=""btn btn-secondary mb-0"">
                                    Next
                                </button>



                            </div>

                        </div>
                        <div class=""center-block text-center"" style=""display:none;"">
                            <ul class=""pagination mb-5"">
                                <li class=""page-item page-prev disabled"">
                                    <a class=""page-link"" href=""#"" tabindex=""-1"">Prev</a>
                                </li>
                                <li class=""page-item active""><a class=""page-link"" href=""#"">1</a></li>
              ");
            WriteLiteral(@"                  <li class=""page-item""><a class=""page-link"" href=""#"">2</a></li>
                                <li class=""page-item""><a class=""page-link"" href=""#"">3</a></li>
                                <li class=""page-item page-next"">
                                    <a class=""page-link"" href=""#"">Next</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <!--/Add lists-->
            </div>
            <!--/Right Side Content-->
        </div>
    </div>
</section>
<!--/Add Listings-->
<!-- Newsletter-->
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1731f66b6c1b62e0a217fc212897d8c48a4e488b15537", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n<!--/Newsletter-->\r\n<!--Footer Section-->\r\n<!--Footer Section-->\r\n<!-- Message Modal -->\r\n");
            WriteLiteral("\r\n<!-- Home Video Modal -->\r\n");
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1731f66b6c1b62e0a217fc212897d8c48a4e488b16859", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<script type=\"text/javascript\">\r\n    var finaldata;\r\n    var rows = \'\';\r\n    var RecordCount = ");
#nullable restore
#line 361 "E:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\BusinessListing.cshtml"
                 Write(ViewBag.RecordCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ;\r\n\r\n    var datatable;\r\n    var counter = 0;\r\n    $(document).ready(function () {\r\n\r\n        rows = \'\';\r\n        appendData(counter);\r\n\r\n        //LoadSlider();\r\n            //loaddata();\r\n    });\r\n    function loaddata() {\r\n\r\n");
            WriteLiteral(@"
        var businessIdd = $(""#businessid1"").val();
        var productidd = $(""#productid1"").val();



        //alert(businessIdd);
        //alert(productidd);
        $.ajax({

            type: ""GET"",
            url: '/Admin/Home/BusinessListingGetALL',
           // url: '/Admin/Home/BusinessListingGetALL?businessid=' + businessIdd + ' & productidd=' + productidd,
          //  data: ""businessid="" + businessIdd + ""&productidd ="" + productidd,
            data: { ""businessid"": businessIdd, ""productidd"": productidd },
            contentType: ""application/json; charset=utf-8"",
            dataType: ""json"",
            success: function (data) {
                finaldata = data;
                appendData();
//                //alert(JSON.stringify(data));
//                $(""#businesslist"").html('');
//                var DIV = '';
//                var rows = '';
//                $.each(data, function (i, item) {
//                      rows += `
//                        <di");
            WriteLiteral(@"v class=""card overflow-hidden"">

//    <div class=""d-md-flex"">
//        <div class=""item-card9-img"">
//            <div class=""item-card9-imgs"">
//                <a asp-area=""Admin"" asp-controller=""Home"" asp-action=""business"" asp-route-id=""`+item.id+`""></a>

//                    <img src=""`+ item.sliderimg1 +`"" style=""width:300px;height:212px;"" alt=""img"" class=""cover-image"">



//            </div>
//            <div class=""item-card9-icons"" style=""display:none;"">
//                <a href=""#"" class=""item-card9-icons1 wishlist""> <i class=""fa fa fa-heart-o""></i></a>
//            </div>
//            <div style=""display:none;"" class=""item-cardreview-absolute bg-secondary"">RealEstate</div>
//        </div>
//        <div class=""card border-0 mb-0"">
//            <div class=""card-body"">
//                <div class=""item-card9"">

//                    <a asp-area=""Admin"" asp-controller=""Home"" asp-action=""business"" asp-route-id=""`+ item.id +`"" class=""text-dark"">
//                        ");
            WriteLiteral(@"<h4 class=""font-weight-semibold mt-1 mb-1"">
//                            `+ item.companyName+`

//                        </h4>
//                    </a>
//                    <div class=""rating-stars d-flex mr-5"">
//                        <input type=""number"" readonly=""readonly"" class=""rating-value star"" name=""rating-stars-value"" value="" `+ item.rating +`"">
//                        <div class=""rating-stars-container mr-2"">
//                            <div class=""rating-star sm"">
//                                <i class=""fa fa-star""></i>
//                            </div>
//                            <div class=""rating-star sm"">
//                                <i class=""fa fa-star""></i>
//                            </div>
//                            <div class=""rating-star sm"">
//                                <i class=""fa fa-star""></i>
//                            </div>
//                            <div class=""rating-star sm"">
//                                <i class=""");
            WriteLiteral(@"fa fa-star""></i>
//                            </div>
//                            <div class=""rating-star sm"">
//                                <i class=""fa fa-star""></i>
//                            </div>
//                        </div> <a class=""fs-13 leading-tight mt-1"" href=""#"">`+ item.review +` Reviews</a>
//                    </div>
//                    <div class=""mt-2 mb-2"">
//                        <a asp-area=""Admin"" asp-controller=""Home"" asp-action=""business"" asp-route-id=""`+ item.Id +`"" class=""mt-1 mb-1 mr-3 text-dark""><i class=""fa fa-globe mr-1""></i>
//   `+ item.landmark +`</a>
//                        <a asp-area=""Admin"" asp-controller=""Home"" asp-action=""business"" asp-route-id=""`+ item.Id +`"" class=""mt-1 mb-1 mr-1 text-muted"">
//                            <i class=""fa fa-map-marker mr-1""></i>
//                    `+ item.house +`




//                        </a>
//                    </div>
//                    <p class=""mb-0 leading-tight""><span class=""font-we");
            WriteLiteral(@"ight-semibold text-dark""> Timings : </span>  10am - 10pm</p>
//                </div>
//            </div>
//            <div class=""card-footer pt-2 pb-2"">
//                <div class=""item-card9-footer d-sm-flex"">
//                    <div class=""item-card9-cost"">
//                        <div class=""text-dark font-weight-normal mb-0 mt-0 item-card2-desc"">
//                            <a class="""" asp-area=""Admin"" asp-controller=""Home"" asp-action=""business"" asp-route-id="" `+ item.Id + ` "" data-toggle=""modal"" data-target=""#contact""><i class=""fa fa-envelope""></i> ` + item.email +`</a>
//                            <a class="""" asp-area=""Admin"" asp-controller=""Home"" asp-action=""business"" asp-route-id="" `+ item.Id + `"" data-toggle=""modal"" data-target=""#contact""><i class=""fa fa-phone""></i> ` + item.phoneNumber +`</a>




//                        </div>
//                    </div>
//                    <div class=""ml-auto mt-3 mt-sm-0"" style=""display:none;"">
//                        <div clas");
            WriteLiteral(@"s=""text-dark font-weight-normal mb-0 mt-0 item-card2-desc""><a href=""#""><i class=""fa fa-map-signs""></i>  Get Directions</a></div>
//                    </div>
//                </div>
//            </div>
//        </div>
//    </div>
//</div>
//                    `;

//                    //var rows = ""<tr>"" +
//                    //    ""<td id='RegdNo'>"" + item.companyName + ""</td>"" +
//                    //    ""<td id='Name'>"" + item.id + ""</td>"" +

//                    //    ""</tr>"";
//                    //console.log(rows);
//                    //$('#Table').append(rows);
//                }); //End of foreach Loop
//                $(""#businesslist"").html(rows);
//                console.log(rows);
//                console.log(data);

            }, //End of AJAX Success function

            failure: function (data) {
                alert(data.responseText);
            }, //End of AJAX failure function
            error: function (data) {
                alert(data.re");
            WriteLiteral(@"sponseText);
            } //End of AJAX error function

        });
    }


    var cnt = 0;
    //$(window).scroll(function () {

    //    if ($(window).scrollTop() == $(document).height() - $(window).height() && counter < 16) {
    //    //if ($(window).scrollTop() <= $(document).height() - $(window).height() && counter < 16) {
    //       // alert(counter);
    //        appendData(counter);
    //    }
    //});
    function appendData(cnt) {


        if (counter === 0) {
            $(""#btnPreviouspage"").hide();
        }
        else {
            $(""#btnPreviouspage"").show();
        }

        var cnt2 = RecordCount / 10;
        var cnt1 = parseInt(cnt);

        if (cnt1 < cnt2) {
            cnt1++;
        }
        else {

        }
        if (counter < cnt1) {
            $(""#btnNextpage"").show();
        }
        else {
            $(""#btnNextpage"").hide();
        }



        rows = '';
        var businessIdd = $(""#businessid1"").val();
    ");
            WriteLiteral(@"    var productidd = $(""#productid1"").val();
        $.ajax({

            type: ""GET"",
            url: '/Admin/Home/BusinessListingGetALL',

            data: {
                ""businessid"": businessIdd, ""productidd"": productidd, ""pageno"": cnt},
            contentType: ""application/json; charset=utf-8"",
            dataType: ""json"",
            success: function (data) {
                finaldata = data;
                var html = '';
                var iindex = 0;
                //var iindex = (counter+1);
                for (iindex = 0; iindex < finaldata.length; iindex++) {
                    cnt++;
                    var item = finaldata[iindex];
                    console.log('---------------------------');
                    console.log(item);
                    console.log('---------------------------');

                    rows += `
                        <div class=""card overflow-hidden"">

    <div class=""d-md-flex"">
        <div class=""item-card9-img"">
       ");
            WriteLiteral(@"     <div class=""item-card9-imgs"">
                <a href=""/Admin/Home/business?id=`+ item.id + `""></a>

                    <img src=""`+ item.sliderimg1 + `"" style=""width:300px;height:212px;"" alt=""img"" class=""cover-image"">



            </div>
            <div class=""item-card9-icons"" style=""display:none;"">
                <a href=""#"" class=""item-card9-icons1 wishlist""> <i class=""fa fa fa-heart-o""></i></a>
            </div>
            <div style=""display:none;"" class=""item-cardreview-absolute bg-secondary"">RealEstate</div>
        </div>
        <div class=""card border-0 mb-0"">
            <div class=""card-body"">
                <div class=""item-card9"">

                    <a href=""/Admin/Home/business?id=`+ item.id + `"" class=""text-dark"">
                        <h4 class=""font-weight-semibold mt-1 mb-1"">
                            `+ item.companyName + `

                        </h4>
                    </a>
                    <div class=""rating-stars d-flex mr-5"">
         ");
            WriteLiteral(@"               <input type=""number"" readonly=""readonly"" class=""rating-value star"" name=""rating-stars-value"" value="" `+ item.rating + `"">
                        <div class=""rating-stars-container mr-2"">
                            <div class=""rating-star sm"">
                                <i class=""fa fa-star""></i>
                            </div>
                            <div class=""rating-star sm"">
                                <i class=""fa fa-star""></i>
                            </div>
                            <div class=""rating-star sm"">
                                <i class=""fa fa-star""></i>
                            </div>
                            <div class=""rating-star sm"">
                                <i class=""fa fa-star""></i>
                            </div>
                            <div class=""rating-star sm"">
                                <i class=""fa fa-star""></i>
                            </div>
                        </div> <a class=""fs-13 le");
            WriteLiteral(@"ading-tight mt-1"" href=""#"">`+ item.review + ` Reviews</a>
                    </div>
                    <div class=""mt-2 mb-2"">
                        <a href=""/Admin/Home/business?id=`+ item.id + `"" class=""mt-1 mb-1 mr-3 text-dark""><i class=""fa fa-globe mr-1""></i>
   `+ item.landmark + `</a>
                        <a href=""/Admin/Home/business?id=`+ item.id + `"" class=""mt-1 mb-1 mr-1 text-muted"">
                            <i class=""fa fa-map-marker mr-1""></i>
                    `+ item.house + `




                        </a>
                    </div>
                  Timings `+ item.businesstime + `

                </div>
            </div>
            <div class=""card-footer pt-2 pb-2"">
                <div class=""item-card9-footer d-sm-flex"">
                    <div class=""item-card9-cost"">
                        <div class=""text-dark font-weight-normal mb-0 mt-0 item-card2-desc"">
                            <a class="""" href=""/Admin/Home/business?id=`+ item.id + `""  data");
            WriteLiteral(@"-toggle=""modal"" data-target=""#contact""><i class=""fa fa-envelope""></i> ` + item.email + `</a>
                            <a class="""" href=""/Admin/Home/business?id=`+ item.id + `"" data-toggle=""modal"" data-target=""#contact""><i class=""fa fa-phone""></i> ` + item.phoneNumber + `</a>




                        </div>
                    </div>
                    <div class=""ml-auto mt-3 mt-sm-0"" style=""display:none;"">
                        <div class=""text-dark font-weight-normal mb-0 mt-0 item-card2-desc""><a href=""#""><i class=""fa fa-map-signs""></i>  Get Directions</a></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
                    `;
                    //html += '<p class=""dynamic"">Dynamic Data :' + item.id + '  This is test data.<br />Next line.</p>';
                }
                console.log(rows);
                $('#businesslist').html(rows);

              //  counter++;

            }, //End of AJAX Success funct");
            WriteLiteral(@"ion

            failure: function (data) {
                alert(data.responseText);
            }, //End of AJAX failure function
            error: function (data) {
                alert(data.responseText);
            } //End of AJAX error function

        });






        //if (counter == 2)
        //    $('#myScroll').append('<button id=""uniqueButton"" style=""margin-left: 50%; background-color: powderblue;"">Click</button><br /><br />');
    }



    $(""#btnPreviouspage"").click(function () {


            counter--;
            appendData(counter);
    });

    $(""#btnNextpage"").click(function () {
        //var cnt = RecordCount / 10;
        //var cnt1 = parseInt(cnt);

        //if (cnt1 < cnt) {
        //    cnt1++;
        //}
        //else {

        //}

            counter++;
            //alert(counter);
            appendData(counter);


    });




");
            WriteLiteral("</script>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<plathora.Models.BusinessListingViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
