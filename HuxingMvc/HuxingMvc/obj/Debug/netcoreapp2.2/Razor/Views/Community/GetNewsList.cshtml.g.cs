#pragma checksum "C:\Task\Photo\HuxingMvc\HuxingMvc\Views\Community\GetNewsList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90d887d6368b0e4f4054852d905871bf9f01154c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Community_GetNewsList), @"mvc.1.0.view", @"/Views/Community/GetNewsList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Community/GetNewsList.cshtml", typeof(AspNetCore.Views_Community_GetNewsList))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90d887d6368b0e4f4054852d905871bf9f01154c", @"/Views/Community/GetNewsList.cshtml")]
    public class Views_Community_GetNewsList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HuxingModel.PageReturnModel<HuxingModel.Community.NewsModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/iconfont/iconfont.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/iconfont2/iconfont2/iconfont.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Task\Photo\HuxingMvc\HuxingMvc\Views\Community\GetNewsList.cshtml"
  
    ViewData["Title"] = "GetNewsList";
    Layout = "~/Views/Shared/Community.cshtml";

#line default
#line hidden
            BeginContext(167, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(171, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "90d887d6368b0e4f4054852d905871bf9f01154c4239", async() => {
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
            EndContext();
            BeginContext(225, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(231, 65, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "90d887d6368b0e4f4054852d905871bf9f01154c5496", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(296, 934, true);
            WriteLiteral(@"
    <style>
       

        .add-btn {
            position: absolute;
            width: 113px;
            height: 40px;
            line-height: 40px;
            text-align: center;
            font-size: 18px;
            background-color: rgb(52,54,58);
            color: #fff;
            outline: none;
            margin-top: 10px;
        }
    </style>

<div>
    <div style=""width: 800px;height: 40px;background-color: rgb(52,54,58);color:white;line-height: 40px;margin-left: 20px;margin-top: 100px;"">
        <span style=""margin-left: 10px;font-size:  15px;"">图文列表</span>
        <span style=""float: right;margin-right: 5px;"">
            <a href=""javascript:location.replace(location.href);""><i class=""iconfont"">&#xe607</i></a>
        </span>
    </div>
    <div class=""newadd"">
        <a href=""AddNews"" class=""add-btn"" target=""_blank"">添加图文</a>
    </div>


    <div class=""new-mian"">
");
            EndContext();
#line 39 "C:\Task\Photo\HuxingMvc\HuxingMvc\Views\Community\GetNewsList.cshtml"
         foreach (var item in Model.DateList)
        {

#line default
#line hidden
            BeginContext(1288, 126, true);
            WriteLiteral("            <div class=\"image-main\" onclick=\"NewsDetail\">\r\n                <div class=\"introduce\">\r\n                    <span>");
            EndContext();
            BeginContext(1415, 10, false);
#line 43 "C:\Task\Photo\HuxingMvc\HuxingMvc\Views\Community\GetNewsList.cshtml"
                     Write(item.Titie);

#line default
#line hidden
            EndContext();
            BeginContext(1425, 99, true);
            WriteLiteral("</span>\r\n                </div>\r\n                <div class=\"image-left\">\r\n                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=", 1524, "", 1538, 1);
#line 46 "C:\Task\Photo\HuxingMvc\HuxingMvc\Views\Community\GetNewsList.cshtml"
WriteAttributeValue("", 1529, item.Url, 1529, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1538, 129, true);
            WriteLiteral(" alt=\"\">\r\n                </div>\r\n                <div class=\"image-right\">\r\n                    <span>\r\n                        ");
            EndContext();
            BeginContext(1668, 12, false);
#line 50 "C:\Task\Photo\HuxingMvc\HuxingMvc\Views\Community\GetNewsList.cshtml"
                   Write(item.Summary);

#line default
#line hidden
            EndContext();
            BeginContext(1680, 75, true);
            WriteLiteral("\r\n                    </span>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 54 "C:\Task\Photo\HuxingMvc\HuxingMvc\Views\Community\GetNewsList.cshtml"
        }

#line default
#line hidden
            BeginContext(1766, 28, true);
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n");
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
