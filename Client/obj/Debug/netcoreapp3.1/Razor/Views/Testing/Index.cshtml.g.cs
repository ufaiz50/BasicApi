#pragma checksum "C:\Users\user\source\repos\API\Client\Views\Testing\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b17b8817c6fed82653a239274c8592e38bd93c96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Testing_Index), @"mvc.1.0.view", @"/Views/Testing/Index.cshtml")]
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
#line 1 "C:\Users\user\source\repos\API\Client\Views\_ViewImports.cshtml"
using Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\source\repos\API\Client\Views\_ViewImports.cshtml"
using Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b17b8817c6fed82653a239274c8592e38bd93c96", @"/Views/Testing/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    public class Views_Testing_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\user\source\repos\API\Client\Views\Testing\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"contianer\">\r\n    <div class=\"navbar\">\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 108, "\"", 114, 0);
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 115, "\"", 121, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"logo\" />\r\n        <nav>\r\n            <ul>\r\n                <li>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 217, "\"", 224, 0);
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 225, "\"", 233, 0);
            EndWriteAttribute();
            WriteLiteral("></a>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 263, "\"", 270, 0);
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 271, "\"", 279, 0);
            EndWriteAttribute();
            WriteLiteral("></a>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 309, "\"", 316, 0);
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 317, "\"", 325, 0);
            EndWriteAttribute();
            WriteLiteral("></a>\r\n                </li>\r\n            </ul>\r\n        </nav>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            WriteLiteral("\r\n<script src=\"https://code.jquery.com/jquery-3.6.0.min.js\"></script>\r\n<script>\r\n\r\n   $.ajax({\r\n       url: \"https://localhost:5001/Api/Employees\",\r\n       success: function (result) {\r\n           console.log(result);\r\n        }\r\n    })\r\n</script>");
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
