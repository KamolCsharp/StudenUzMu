#pragma checksum "C:\Users\Eshpo'latov Kamol\source\repos\StudenUzMu\StudenUzMu\Views\Uqituvchi\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41c05aed63a45a240f187093f8de188868ea27d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Uqituvchi_About), @"mvc.1.0.view", @"/Views/Uqituvchi/About.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Uqituvchi/About.cshtml", typeof(AspNetCore.Views_Uqituvchi_About))]
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
#line 1 "C:\Users\Eshpo'latov Kamol\source\repos\StudenUzMu\StudenUzMu\Views\_ViewImports.cshtml"
using StudenUzMu;

#line default
#line hidden
#line 2 "C:\Users\Eshpo'latov Kamol\source\repos\StudenUzMu\StudenUzMu\Views\_ViewImports.cshtml"
using StudenUzMu.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41c05aed63a45a240f187093f8de188868ea27d8", @"/Views/Uqituvchi/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed7899061d26142ec300a9487b3e11de96243bcd", @"/Views/_ViewImports.cshtml")]
    public class Views_Uqituvchi_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StudenUzMu.Models.Uqituvchi>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(36, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Eshpo'latov Kamol\source\repos\StudenUzMu\StudenUzMu\Views\Uqituvchi\About.cshtml"
  
    ViewData["Title"] = "About";

#line default
#line hidden
            BeginContext(79, 111, true);
            WriteLiteral("\r\n<div class=\"container\" >\r\n    <hr />\r\n    <div class=\"row\">\r\n        <div class=\"col-md-4\">\r\n            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 190, "\"", 233, 1);
#line 11 "C:\Users\Eshpo'latov Kamol\source\repos\StudenUzMu\StudenUzMu\Views\Uqituvchi\About.cshtml"
WriteAttributeValue("", 196, Html.DisplayFor(model => model.Rasm), 196, 37, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(234, 132, true);
            WriteLiteral(" style=\"width:80%\">\r\n        </div>\r\n        <div class=\"col-md-4\" style=\"font-size:20px\">\r\n            <p><b>Familiyasi: </b><span>");
            EndContext();
            BeginContext(367, 42, false);
#line 14 "C:\Users\Eshpo'latov Kamol\source\repos\StudenUzMu\StudenUzMu\Views\Uqituvchi\About.cshtml"
                                   Write(Html.DisplayFor(model => model.Familiyasi));

#line default
#line hidden
            EndContext();
            BeginContext(409, 48, true);
            WriteLiteral(" </span></p>\r\n            <p><b>Ismi: </b><span>");
            EndContext();
            BeginContext(458, 36, false);
#line 15 "C:\Users\Eshpo'latov Kamol\source\repos\StudenUzMu\StudenUzMu\Views\Uqituvchi\About.cshtml"
                             Write(Html.DisplayFor(model => model.Ismi));

#line default
#line hidden
            EndContext();
            BeginContext(494, 51, true);
            WriteLiteral(" </span></p>\r\n            <p><b>Sharifi: </b><span>");
            EndContext();
            BeginContext(546, 39, false);
#line 16 "C:\Users\Eshpo'latov Kamol\source\repos\StudenUzMu\StudenUzMu\Views\Uqituvchi\About.cshtml"
                                Write(Html.DisplayFor(model => model.Sharifi));

#line default
#line hidden
            EndContext();
            BeginContext(585, 51, true);
            WriteLiteral(" </span></p>\r\n            <p><b>Pasport: </b><span>");
            EndContext();
            BeginContext(637, 39, false);
#line 17 "C:\Users\Eshpo'latov Kamol\source\repos\StudenUzMu\StudenUzMu\Views\Uqituvchi\About.cshtml"
                                Write(Html.DisplayFor(model => model.Pasport));

#line default
#line hidden
            EndContext();
            BeginContext(676, 49, true);
            WriteLiteral(" </span></p>\r\n            <p><b>Email: </b><span>");
            EndContext();
            BeginContext(726, 37, false);
#line 18 "C:\Users\Eshpo'latov Kamol\source\repos\StudenUzMu\StudenUzMu\Views\Uqituvchi\About.cshtml"
                              Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(763, 49, true);
            WriteLiteral(" </span></p>\r\n            <p><b>Parol: </b><span>");
            EndContext();
            BeginContext(813, 37, false);
#line 19 "C:\Users\Eshpo'latov Kamol\source\repos\StudenUzMu\StudenUzMu\Views\Uqituvchi\About.cshtml"
                              Write(Html.DisplayFor(model => model.Parol));

#line default
#line hidden
            EndContext();
            BeginContext(850, 48, true);
            WriteLiteral(" </span></p>\r\n    </div>\r\n\r\n</div>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StudenUzMu.Models.Uqituvchi> Html { get; private set; }
    }
}
#pragma warning restore 1591
