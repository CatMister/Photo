#pragma checksum "C:\Task\Photo\HuxingMvc\HuxingMvc\Views\Community\PhotoList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "47b60b9209c67b7e9d24586dc1edac31c55c0028"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Community_PhotoList), @"mvc.1.0.view", @"/Views/Community/PhotoList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Community/PhotoList.cshtml", typeof(AspNetCore.Views_Community_PhotoList))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b60b9209c67b7e9d24586dc1edac31c55c0028", @"/Views/Community/PhotoList.cshtml")]
    public class Views_Community_PhotoList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HuxingModel.PageReturnModel<HuxingModel.Community.PhotoModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Task\Photo\HuxingMvc\HuxingMvc\Views\Community\PhotoList.cshtml"
  
    Layout = "~/Views/Shared/OutMain.cshtml";

#line default
#line hidden
#line 5 "C:\Task\Photo\HuxingMvc\HuxingMvc\Views\Community\PhotoList.cshtml"
 foreach (var item in Model.DateList)
{

#line default
#line hidden
            BeginContext(166, 83, true);
            WriteLiteral("    <div id=\"gallery-wrapper\">\r\n        <div class=\"white-panel\">\r\n            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 249, "\"", 264, 1);
#line 9 "C:\Task\Photo\HuxingMvc\HuxingMvc\Views\Community\PhotoList.cshtml"
WriteAttributeValue("", 255, item.Url, 255, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(265, 47, true);
            WriteLiteral(" class=\"thumb\">\r\n\r\n            <h1><a href=\"#\">");
            EndContext();
            BeginContext(313, 9, false);
#line 11 "C:\Task\Photo\HuxingMvc\HuxingMvc\Views\Community\PhotoList.cshtml"
                       Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(322, 26, true);
            WriteLiteral("</a></h1>\r\n            <p>");
            EndContext();
            BeginContext(349, 11, false);
#line 12 "C:\Task\Photo\HuxingMvc\HuxingMvc\Views\Community\PhotoList.cshtml"
          Write(item.Detail);

#line default
#line hidden
            EndContext();
            BeginContext(360, 34, true);
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 15 "C:\Task\Photo\HuxingMvc\HuxingMvc\Views\Community\PhotoList.cshtml"
}

#line default
#line hidden
            BeginContext(397, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HuxingModel.PageReturnModel<HuxingModel.Community.PhotoModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
