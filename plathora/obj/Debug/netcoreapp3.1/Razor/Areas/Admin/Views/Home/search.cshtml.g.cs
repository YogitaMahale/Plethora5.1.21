#pragma checksum "E:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "579df027e14340a7ca76967f3391b2a261b9ea55"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home_search), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/search.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"579df027e14340a7ca76967f3391b2a261b9ea55", @"/Areas/Admin/Views/Home/search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"396188bb9b5a5b30811f4f1a58a7e68134b9e9d4", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Home_search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<plathora.Models.frontwebsiteModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/businessListUL.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\search.cshtml"
  


    ViewData["Title"] = "Home Page";
    Layout = "~/Views/Shared/_front.cshtml";
    // Layout = "~/Views/Shared/_front.cshtml";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "579df027e14340a7ca76967f3391b2a261b9ea554522", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n<!--Loader-->\r\n");
            WriteLiteral("<!--Topbar-->\r\n<!--Sliders Section-->\r\n<!--Sliders Section-->\r\n<!-- Categories-->\r\n");
#nullable restore
#line 23 "E:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\search.cshtml"
  
    if (Model.objAdvertisementSlider != null)
    {
        await Html.RenderPartialAsync("_advertiseSlider", Model.objAdvertisementSlider);
    }


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""site-wrapper"">
    <section class=""page-wrapper"">
        <div class=""container"">
            <main class=""gl-main"">
                <div id=""main"">
                    <div class=""gt-homepage"">
                        <div class=""row"">
                            <div class=""col-xl-3 col-lg-3 col-sm-12 col-12"">
                                <div class=""sticky12"">
");
#nullable restore
#line 40 "E:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\search.cshtml"
                                      
                                        if (Model.objSectorRegistration != null)
                                        {


                                            await Html.RenderPartialAsync("_SectorPartialView", Model.objSectorRegistration);
                                        }
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </div>
                            </div>
                            <div class=""col-xl-9 col-lg-9 col-sm-12 col-12"">
                                <div class=""content"">
                                    <div class=""center-block text-center"">
                                        <h2>Latest Listings</h2>

                                    </div>
                                    <div class=""tab-pane active"" id=""businesslistDashboard"">


                                    </div>
                                    <button id=""btnPreviouspage"" class=""btn btn-secondary mb-0"">
                                        Previous
                                    </button>
                                    <button id=""btnNextpage"" class=""btn btn-secondary mb-0"">
                                        Next
                                    </button>









                                </div><!--content-->
                            <");
            WriteLiteral("/div>\r\n\r\n                        </div><!-- -row -->\r\n                    </div><!-- gt-homepage -->\r\n                </div><!-- main -->\r\n            </main>\r\n        </div>\r\n    </section>\r\n    <!--Categories-->\r\n</div>\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "579df027e14340a7ca76967f3391b2a261b9ea558421", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    var finaldata;\r\n    var rows = \'\';\r\n    var cnt = 0;\r\n    var RecordCount = 0;//");
#nullable restore
#line 94 "E:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\search.cshtml"
                     Write(ViewBag.RecordCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" ;

    var datatable;
    var counter = 0;
    $(document).ready(function () {
        //alert(""call"");
        rows = '';
        $(""#btnPreviouspage"").hide();

        $(""#btnNextpage"").hide();
        appendData(counter);

        //LoadSlider();
            //loaddata();
    });



    function appendData(cnt) {



        rows = '';
        var searchtextt = '';
        //var businessIdd = $(""#businessid1"").val();
        //var productidd = $(""#productid1"").val();
        $.ajax({

            type: ""GET"",
            url: '/Admin/Home/BusinessListingByCityandSearchText',

            data: {
                  ""pageno"": cnt
            },

            contentType: ""application/json; charset=utf-8"",
            dataType: ""json"",
            success: function (data) {
                finaldata = data;
                RecordCount = finaldata[0].totalRecords;
                console.log(""rows :"" + RecordCount);

                //-----------


              //  a");
            WriteLiteral(@"lert(RecordCount);
                if (counter === 0) {
                    $(""#btnPreviouspage"").hide();
                }
                else {
                    $(""#btnPreviouspage"").show();
                }
              //  alert(RecordCount);
                var cnt2 = (RecordCount / 10);
                 //alert(""RecordCount : "" + RecordCount);
                //alert(""cnt2 :"" +cnt2);
                var cnt1 = parseInt(cnt);
               // alert(parseInt(RecordCount / 10));
                var paging = Math.ceil(RecordCount / 10);
               // alert(paging);
                //if (cnt1 < cnt2) {
                //    cnt1++;
                //}
                //else {

                //}
             //   alert(counter + ',' + cnt1);
                //if (counter < cnt1) {
                if (counter < paging-1) {
                    $(""#btnNextpage"").show();
                }
                else {
                    $(""#btnNextpage"").hide();
                ");
            WriteLiteral(@"}


                //if (cnt1 < cnt2) {
                //    cnt1++;
                //}
                //else {

                //}
                //if (counter < cnt1) {
                //    $(""#btnNextpage"").show();
                //}
                //else {
                //    $(""#btnNextpage"").hide();
                //}

                //-----------

              //  console.log(finaldata);

                var html = '';
                var iindex = 0;

                for (iindex = 0; iindex < finaldata.length; iindex++) {
                    cnt++;
                    var item = finaldata[iindex];


                    rows += `
                        <div class=""card overflow-hidden"">

    <div class=""d-md-flex"">
        <div class=""item-card9-img"">
            <div class=""item-card9-imgs"">
                <a href=""/Admin/Home/business?id=`+ item.id + `""></a>

                    <img src=""`+ item.sliderimg1 + `"" style=""width:300px;height:212px;"" alt=");
            WriteLiteral(@"""img"" class=""cover-image"">



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
                        <input type=""number"" readonly=""readonly"" class=""rating-value star"" name=""rating-stars-value"" value="" `+ item.rating + `"">
                        <div class=""rating-stars-container mr-2");
            WriteLiteral(@""">
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
                        </div> <a class=""fs-13 leading-tight mt-1"" href=""#"">`+ item.review + ` Reviews</a>
                    </div>
                    <div class=""mt-2 mb-2"">
                        <a href=""/Admin/Home/business?id=`+ item.id +");
            WriteLiteral(@" `"" class=""mt-1 mb-1 mr-3 text-dark""><i class=""fa fa-globe mr-1""></i>
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
                            <a class="""" href=""/Admin/Home/business?id=`+ item.id + `""  data-toggle=""modal"" data-target=""#contact""><i class=""fa fa-envelope""></i> ` + item.owneremail + `</a>
                            <a class="""" href=""/Admin/Home/business?id=`+ item.id + `"" data-toggle=""mod");
            WriteLiteral(@"al"" data-target=""#contact""><i class=""fa fa-phone""></i> ` + item.ownerPhoneNumber + `</a>




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
                //console.log(rows);
                $('#businesslistDashboard').html(rows);

              //  counter++;

            }, //End of AJAX Success function

            failure: function (data) {
                alert(data.responseText);
            }, //End of AJAX failure function
            error: function (data) {
     ");
            WriteLiteral(@"           alert(data.responseText);
            } //End of AJAX error function

        });



       // alert(RecordCount);
       // if (counter === 0) {
       //     $(""#btnPreviouspage"").hide();
       // }
       // else {
       //     $(""#btnPreviouspage"").show();
       // }
       // alert(RecordCount);
       // var cnt2 = (RecordCount / 10);
       //// alert(""RecordCount : "" + RecordCount);
       // //alert(""cnt2 :"" +cnt2);
       // var cnt1 = parseInt(cnt);

       // if (cnt1 < cnt2) {
       //     cnt1++;
       // }
       // else {

       // }
       // if (counter < cnt1) {
       //     $(""#btnNextpage"").show();
       // }
       // else {
       //     $(""#btnNextpage"").hide();
       // }


    }



    $(""#btnPreviouspage"").click(function () {


            counter--;
            appendData(counter);
    });

    $(""#btnNextpage"").click(function () {
        //var cnt = RecordCount / 10;
        //var cnt1 = parseInt(cnt);

        ");
            WriteLiteral("//if (cnt1 < cnt) {\r\n        //    cnt1++;\r\n        //}\r\n        //else {\r\n\r\n        //}\r\n\r\n            counter++;\r\n            //alert(counter);\r\n            appendData(counter);\r\n\r\n\r\n    });\r\n\r\n\r\n\r\n\r\n\r\n</script>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<plathora.Models.frontwebsiteModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
