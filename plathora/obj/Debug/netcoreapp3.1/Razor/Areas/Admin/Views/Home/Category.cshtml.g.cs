#pragma checksum "F:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\Category.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e5ea4f955ab60a42faf9c60bbcf0bd581b728f7d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home_Category), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/Category.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5ea4f955ab60a42faf9c60bbcf0bd581b728f7d", @"/Areas/Admin/Views/Home/Category.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"396188bb9b5a5b30811f4f1a58a7e68134b9e9d4", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Home_Category : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<plathora.Models.Dtos.selectallSectorWithBusinessCount>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/uploads/blank1.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "businessDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\Category.cshtml"
  
    ViewData["Title"] = "Category";
    Layout = "~/Views/Shared/_front.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!--Breadcrumb-->
<section>

    <div class=""bannerimg cover-image bg-background3 sptb-2"" data-image-src=""../assets/images/banners/banner2.jpg"">
        <div class=""header-text mb-0"">
            <div class=""container"">
                <div class=""text-center text-white "">
                    <h1");
            BeginWriteAttribute("class", " class=\"", 471, "\"", 479, 0);
            EndWriteAttribute();
            WriteLiteral(@">Sector</h1>
                    <ol class=""breadcrumb text-center"">
                        <li class=""breadcrumb-item""><a href=""#"">Home</a></li>
                        <li class=""breadcrumb-item active text-white"" aria-current=""page"">Sector</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>
</section>
<!--/Breadcrumb-->
<section class=""sptb bg-white"">
    <div class=""container"">
");
            WriteLiteral("        <div class=\"row\">\r\n");
#nullable restore
#line 31 "F:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\Category.cshtml"
             foreach (var obj in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-xl-2 col-lg-3 col-md-3 col-sm-6\">\r\n                    <div class=\"card\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e5ea4f955ab60a42faf9c60bbcf0bd581b728f7d6536", async() => {
                WriteLiteral("\r\n\r\n                            <div class=\"card-body\">\r\n                                <div class=\"cat-item text-center\">\r\n\r\n                                    <div class=\"cat-img category-svg\">\r\n");
#nullable restore
#line 43 "F:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\Category.cshtml"
                                         if (obj.img == null || obj.img == "")
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e5ea4f955ab60a42faf9c60bbcf0bd581b728f7d7361", async() => {
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
                WriteLiteral("\r\n");
#nullable restore
#line 46 "F:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\Category.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <img");
                BeginWriteAttribute("src", " src=\"", 2191, "\"", 2205, 1);
#nullable restore
#line 49 "F:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\Category.cshtml"
WriteAttributeValue("", 2197, obj.img, 2197, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" alt=\"img\" >\r\n");
#nullable restore
#line 50 "F:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\Category.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <!--Clothing Icon Svg -->\r\n");
                WriteLiteral(@"                                        <!--Clothing Icon Svg -->
                                    </div>
                                    <div class=""cat-desc"">
                                        <h5 class=""mb-5"">
                                            ");
#nullable restore
#line 61 "F:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\Category.cshtml"
                                       Write(obj.name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                            <br />\r\n\r\n                                            ");
#nullable restore
#line 64 "F:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\Category.cshtml"
                                       Write(obj.businesscount);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n                                        </h5>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-sectorid", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 35 "F:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\Category.cshtml"
                                                                                                       WriteLiteral(obj.id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sectorid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-sectorid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sectorid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                        \r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 79 "F:\yogita 6.8.19\plathora\plathora\Areas\Admin\Views\Home\Category.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</section>\r\n<!--section-->\r\n\r\n<!--/section-->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<plathora.Models.Dtos.selectallSectorWithBusinessCount>> Html { get; private set; }
    }
}
#pragma warning restore 1591
