#pragma checksum "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Departments\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe95084f8aa94bcdf4bec4b8ba872e78053f3e05"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Departments_Details), @"mvc.1.0.view", @"/Views/Departments/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\_ViewImports.cshtml"
using LMS_Demo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\_ViewImports.cshtml"
using LMS_Demo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\_ViewImports.cshtml"
using System.Web.Optimization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\_ViewImports.cshtml"
using System.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe95084f8aa94bcdf4bec4b8ba872e78053f3e05", @"/Views/Departments/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d2bcdd8fc08353438d43240261eaaa1c0873ff7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Departments_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LMS_Demo.Models.Department>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Departments\Details.cshtml"
  
    ViewBag.Title = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2>Details</h2>\n\n<div>\n    <h4>Department</h4>\n    <hr />\n    <dl class=\"dl-horizontal\">\n        <dt>\n            ");
#nullable restore
#line 15 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Departments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n\n        <dd>\n            ");
#nullable restore
#line 19 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Departments\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n\n    </dl>\n</div>\n<p>\n    ");
#nullable restore
#line 25 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Departments\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.SysId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\n    ");
#nullable restore
#line 26 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Departments\Details.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</p>\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LMS_Demo.Models.Department> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
