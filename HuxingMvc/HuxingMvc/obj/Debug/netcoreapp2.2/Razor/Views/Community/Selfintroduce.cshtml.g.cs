#pragma checksum "C:\Task\HuxingMvc\HuxingMvc\Views\Community\Selfintroduce.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05ea729e4b320bb91b0235bbe27aaeb77eeadbdb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Community_Selfintroduce), @"mvc.1.0.view", @"/Views/Community/Selfintroduce.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Community/Selfintroduce.cshtml", typeof(AspNetCore.Views_Community_Selfintroduce))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05ea729e4b320bb91b0235bbe27aaeb77eeadbdb", @"/Views/Community/Selfintroduce.cshtml")]
    public class Views_Community_Selfintroduce : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HuxingModel.User.UserModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/photo/defaultHead.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("200px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("200px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Task\HuxingMvc\HuxingMvc\Views\Community\Selfintroduce.cshtml"
  
    ViewData["Title"] = "个人简介";
    Layout = "~/Views/Shared/Community.cshtml";

#line default
#line hidden
            BeginContext(126, 342, true);
            WriteLiteral(@"<div style=""background-color: rgb(246,246,246)"">
    <div style=""width: 800px;height: 40px;background-color: rgb(52,54,58);color:white;line-height: 40px;margin-left: 20px;margin-top: 100px;"">
        <span style=""margin-left:10px;font-size: : 15px;"">个人简介</span>
    </div>
    <div class=""self-main"">
        <div class=""header-img"">

");
            EndContext();
#line 14 "C:\Task\HuxingMvc\HuxingMvc\Views\Community\Selfintroduce.cshtml"
             if (string.IsNullOrEmpty(Model.HeadUrl))
            {

#line default
#line hidden
            BeginContext(538, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(554, 71, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "05ea729e4b320bb91b0235bbe27aaeb77eeadbdb5154", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(625, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 17 "C:\Task\HuxingMvc\HuxingMvc\Views\Community\Selfintroduce.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(675, 20, true);
            WriteLiteral("                <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 695, "\"", 715, 1);
#line 20 "C:\Task\HuxingMvc\HuxingMvc\Views\Community\Selfintroduce.cshtml"
WriteAttributeValue("", 701, Model.HeadUrl, 701, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(716, 39, true);
            WriteLiteral(" alt=\"\" width=\"200px\" height=\"200px\">\r\n");
            EndContext();
#line 21 "C:\Task\HuxingMvc\HuxingMvc\Views\Community\Selfintroduce.cshtml"
            }

#line default
#line hidden
            BeginContext(770, 91, true);
            WriteLiteral("        </div>\r\n        <div class=\"information\">\r\n            <span class=\"first-span\">姓名：");
            EndContext();
            BeginContext(862, 14, false);
#line 24 "C:\Task\HuxingMvc\HuxingMvc\Views\Community\Selfintroduce.cshtml"
                                   Write(Model.NickName);

#line default
#line hidden
            EndContext();
            BeginContext(876, 30, true);
            WriteLiteral("</span>\r\n            <span>性别：");
            EndContext();
            BeginContext(907, 15, false);
#line 25 "C:\Task\HuxingMvc\HuxingMvc\Views\Community\Selfintroduce.cshtml"
                Write(Model.SixString);

#line default
#line hidden
            EndContext();
            BeginContext(922, 30, true);
            WriteLiteral("</span>\r\n            <span>积分：");
            EndContext();
            BeginContext(953, 14, false);
#line 26 "C:\Task\HuxingMvc\HuxingMvc\Views\Community\Selfintroduce.cshtml"
                Write(Model.Integral);

#line default
#line hidden
            EndContext();
            BeginContext(967, 60, true);
            WriteLiteral("</span>\r\n        </div>\r\n        <div class=\"introduce\">\r\n\r\n");
            EndContext();
#line 30 "C:\Task\HuxingMvc\HuxingMvc\Views\Community\Selfintroduce.cshtml"
             if (string.IsNullOrEmpty(Model.Description))
            {

#line default
#line hidden
            BeginContext(1101, 43, true);
            WriteLiteral("                <span> 这里没有任何的简介  </span>\r\n");
            EndContext();
#line 33 "C:\Task\HuxingMvc\HuxingMvc\Views\Community\Selfintroduce.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(1192, 23, true);
            WriteLiteral("                <span> ");
            EndContext();
            BeginContext(1216, 17, false);
#line 36 "C:\Task\HuxingMvc\HuxingMvc\Views\Community\Selfintroduce.cshtml"
                  Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(1233, 10, true);
            WriteLiteral(" </span>\r\n");
            EndContext();
#line 37 "C:\Task\HuxingMvc\HuxingMvc\Views\Community\Selfintroduce.cshtml"
            }

#line default
#line hidden
            BeginContext(1258, 89, true);
            WriteLiteral("           <a class=\"btn btn-default\" href=\"/Community/UpdateUser\" role=\"button\">修改</a>\r\n");
            EndContext();
            BeginContext(1407, 40, true);
            WriteLiteral("        </div>\r\n\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HuxingModel.User.UserModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
