#pragma checksum "D:\huxing\HuxingMvc\HuxingMvc\Views\Community\GetSellAtlasList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02b01f1eeb03b29d881aae0f74ada9f09d51e57f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Community_GetSellAtlasList), @"mvc.1.0.view", @"/Views/Community/GetSellAtlasList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Community/GetSellAtlasList.cshtml", typeof(AspNetCore.Views_Community_GetSellAtlasList))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02b01f1eeb03b29d881aae0f74ada9f09d51e57f", @"/Views/Community/GetSellAtlasList.cshtml")]
    public class Views_Community_GetSellAtlasList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HuxingModel.PageReturnModel<HuxingModel.Transaction.SellAtlasModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/css.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(76, 35, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            EndContext();
            BeginContext(111, 302, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "02b01f1eeb03b29d881aae0f74ada9f09d51e57f3907", async() => {
                BeginContext(117, 63, true);
                WriteLiteral("\r\n    <meta charset=\"UTF-8\">\r\n    <title>Document</title>\r\n    ");
                EndContext();
                BeginContext(180, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "02b01f1eeb03b29d881aae0f74ada9f09d51e57f4356", async() => {
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
                BeginContext(224, 182, true);
                WriteLiteral("\r\n    <style>\r\n        body {\r\n            background-color: rgb(246,246,246);\r\n        }\r\n\r\n        div {\r\n            background-color: rgb(255,255,255);\r\n        }\r\n    </style>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(413, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(415, 1369, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "02b01f1eeb03b29d881aae0f74ada9f09d51e57f6686", async() => {
                BeginContext(421, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(934, 230, true);
                WriteLiteral("    <div style=\"width: 800px;height: 40px;background-color: rgb(52,54,58);color:white;line-height: 40px;margin-left: 20px;margin-top: 100px;\">\r\n        <span style=\"margin-left: 10px;font-size: : 15px;\">图集交易列表</span>\r\n    </div>\r\n");
                EndContext();
#line 32 "D:\huxing\HuxingMvc\HuxingMvc\Views\Community\GetSellAtlasList.cshtml"
     foreach (var item in Model.DateList)
    {

#line default
#line hidden
                BeginContext(1214, 93, true);
                WriteLiteral("        <div class=\"image-main\">\r\n            <div class=\"introduce\">\r\n                <span>");
                EndContext();
                BeginContext(1308, 11, false);
#line 36 "D:\huxing\HuxingMvc\HuxingMvc\Views\Community\GetSellAtlasList.cshtml"
                 Write(item.Titile);

#line default
#line hidden
                EndContext();
                BeginContext(1319, 87, true);
                WriteLiteral("</span>\r\n            </div>\r\n            <div class=\"image-left\">\r\n                <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 1406, "\"", 1425, 1);
#line 39 "D:\huxing\HuxingMvc\HuxingMvc\Views\Community\GetSellAtlasList.cshtml"
WriteAttributeValue("", 1412, item.ShowUrl, 1412, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1426, 113, true);
                WriteLiteral(" alt=\"\">\r\n            </div>\r\n            <div class=\"image-right\">\r\n                <span>\r\n                    ");
                EndContext();
                BeginContext(1540, 11, false);
#line 43 "D:\huxing\HuxingMvc\HuxingMvc\Views\Community\GetSellAtlasList.cshtml"
               Write(item.Detail);

#line default
#line hidden
                EndContext();
                BeginContext(1551, 109, true);
                WriteLiteral("\r\n                </span>\r\n            </div>\r\n            <div class=\"sale-img\">\r\n                <span>价格： ");
                EndContext();
                BeginContext(1661, 10, false);
#line 47 "D:\huxing\HuxingMvc\HuxingMvc\Views\Community\GetSellAtlasList.cshtml"
                     Write(item.Price);

#line default
#line hidden
                EndContext();
                BeginContext(1671, 97, true);
                WriteLiteral(" 元</span>\r\n                <span class=\"sale-btn\">购买</span>\r\n            </div>\r\n        </div>\r\n");
                EndContext();
#line 51 "D:\huxing\HuxingMvc\HuxingMvc\Views\Community\GetSellAtlasList.cshtml"
    }

#line default
#line hidden
                BeginContext(1775, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1784, 13, true);
            WriteLiteral("\r\n</html>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HuxingModel.PageReturnModel<HuxingModel.Transaction.SellAtlasModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591