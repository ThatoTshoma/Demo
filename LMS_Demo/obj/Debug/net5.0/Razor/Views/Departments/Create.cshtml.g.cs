#pragma checksum "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Departments\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17ccdbe8ebf67b3332965fabf8a40db817c29522"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Departments_Create), @"mvc.1.0.view", @"/Views/Departments/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17ccdbe8ebf67b3332965fabf8a40db817c29522", @"/Views/Departments/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d2bcdd8fc08353438d43240261eaaa1c0873ff7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Departments_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LMS_Demo.Models.Department>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Departments\Create.cshtml"
  
    ViewBag.Title = "Create";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2>Create</h2>\n\n\n");
#nullable restore
#line 11 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Departments\Create.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Departments\Create.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-horizontal\">\n        <h4>Department</h4>\n        <hr />\n        ");
#nullable restore
#line 18 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Departments\Create.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        <div class=\"form-group\">\n            ");
#nullable restore
#line 20 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Departments\Create.cshtml"
       Write(Html.LabelFor(model => model.Name, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
#nullable restore
#line 22 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Departments\Create.cshtml"
           Write(Html.EditorFor(model => model.Name, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 23 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Departments\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n\n        <div class=\"form-group\">\n            <div class=\"col-md-offset-2 col-md-10\">\n                \n            </div>\n        </div>\n    </div>\n");
            WriteLiteral("    <div style=\"padding-bottom:2%; margin-left:40%\">\n        <button type=\"submit\" class=\"btn btn-success\"> <i class=\"fa fa-check\"></i> Create</button>\n        ");
#nullable restore
#line 36 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Departments\Create.cshtml"
   Write(Html.ActionLink("Back", "Index", new { }, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </div>\n");
#nullable restore
#line 38 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Departments\Create.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div>\n    \n</div>\n\n");
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
