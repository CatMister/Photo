#pragma checksum "C:\Task\Photo\HuxingMvc\HuxingMvc\Views\Community\NewList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f2fa890df98ca5fcd9d6a4a5dd2195917c4e2625"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Community_NewList), @"mvc.1.0.view", @"/Views/Community/NewList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Community/NewList.cshtml", typeof(AspNetCore.Views_Community_NewList))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2fa890df98ca5fcd9d6a4a5dd2195917c4e2625", @"/Views/Community/NewList.cshtml")]
    public class Views_Community_NewList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HuxingModel.PageReturnModel<HuxingModel.Community.NewsModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Task\Photo\HuxingMvc\HuxingMvc\Views\Community\NewList.cshtml"
  
    Layout = "~/Views/Shared/OutMain.cshtml";

#line default
#line hidden
            BeginContext(54, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "C:\Task\Photo\HuxingMvc\HuxingMvc\Views\Community\NewList.cshtml"
 foreach (var item in Model.DateList)
{

#line default
#line hidden
            BeginContext(167, 83, true);
            WriteLiteral("    <div id=\"gallery-wrapper\">\r\n        <div class=\"white-panel\">\r\n            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 250, "\"", 265, 1);
#line 10 "C:\Task\Photo\HuxingMvc\HuxingMvc\Views\Community\NewList.cshtml"
WriteAttributeValue("", 256, item.Url, 256, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(266, 47, true);
            WriteLiteral(" class=\"thumb\">\r\n\r\n            <h1><a href=\"#\">");
            EndContext();
            BeginContext(314, 10, false);
#line 12 "C:\Task\Photo\HuxingMvc\HuxingMvc\Views\Community\NewList.cshtml"
                       Write(item.Titie);

#line default
#line hidden
            EndContext();
            BeginContext(324, 26, true);
            WriteLiteral("</a></h1>\r\n            <p>");
            EndContext();
            BeginContext(351, 12, false);
#line 13 "C:\Task\Photo\HuxingMvc\HuxingMvc\Views\Community\NewList.cshtml"
          Write(item.Summary);

#line default
#line hidden
            EndContext();
            BeginContext(363, 34, true);
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 16 "C:\Task\Photo\HuxingMvc\HuxingMvc\Views\Community\NewList.cshtml"
}

#line default
#line hidden
            BeginContext(400, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HuxingModel.PageReturnModel<HuxingModel.Community.NewsModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591