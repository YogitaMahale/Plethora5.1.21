#pragma checksum "F:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Customerprofile\BusinessSuccessAction.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4495922c238325b3ad0934d3479e346ab752e9f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Customerprofile_BusinessSuccessAction), @"mvc.1.0.view", @"/Areas/Admin/Views/Customerprofile/BusinessSuccessAction.cshtml")]
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
#line 1 "F:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\_ViewImports.cshtml"
using plathora;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\_ViewImports.cshtml"
using plathora.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4495922c238325b3ad0934d3479e346ab752e9f4", @"/Areas/Admin/Views/Customerprofile/BusinessSuccessAction.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"396188bb9b5a5b30811f4f1a58a7e68134b9e9d4", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Customerprofile_BusinessSuccessAction : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(" \r\n\r\n");
#nullable restore
#line 3 "F:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Customerprofile\BusinessSuccessAction.cshtml"
  
    ViewData["Title"] = "about";
    Layout = "~/Views/Shared/_front.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section>
    <div class=""bannerimg cover-image bg-background3"" data-image-src=""../assets/images/banners/banner1.jpg"" style=""height:400px;"">
        <div class=""header-text mb-0"">
            <div class=""container"">
                <div class=""text-center text-white "">
                    <h1");
            BeginWriteAttribute("class", " class=\"", 392, "\"", 400, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"margin-top: 130px;\"> ");
#nullable restore
#line 13 "F:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Customerprofile\BusinessSuccessAction.cshtml"
                                                        Write(ViewBag.result);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                    \r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
