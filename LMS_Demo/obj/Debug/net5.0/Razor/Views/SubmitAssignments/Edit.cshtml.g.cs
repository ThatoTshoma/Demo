#pragma checksum "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\SubmitAssignments\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e1721817a4ef12772912784c1741abc894ee762"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SubmitAssignments_Edit), @"mvc.1.0.view", @"/Views/SubmitAssignments/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e1721817a4ef12772912784c1741abc894ee762", @"/Views/SubmitAssignments/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d2bcdd8fc08353438d43240261eaaa1c0873ff7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_SubmitAssignments_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LMS_Demo.Models.SubmitAssignment>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\SubmitAssignments\Edit.cshtml"
  
    ViewBag.Title = "Edit";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2>Edit</h2>\n\n\n");
#nullable restore
#line 11 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\SubmitAssignments\Edit.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\SubmitAssignments\Edit.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-horizontal\">\n        <h4>SubmitAssignment</h4>\n        <hr />\n        ");
#nullable restore
#line 18 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\SubmitAssignments\Edit.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        ");
#nullable restore
#line 19 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\SubmitAssignments\Edit.cshtml"
   Write(Html.HiddenFor(model => model.SysId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n        <div class=\"form-group\">\n            ");
#nullable restore
#line 22 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\SubmitAssignments\Edit.cshtml"
       Write(Html.LabelFor(model => model.StudentId, "StudentId", htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
#nullable restore
#line 24 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\SubmitAssignments\Edit.cshtml"
           Write(Html.DropDownList("StudentId", null, htmlAttributes: new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 25 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\SubmitAssignments\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.StudentId, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n\n        <div class=\"form-group\">\n            ");
#nullable restore
#line 30 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\SubmitAssignments\Edit.cshtml"
       Write(Html.LabelFor(model => model.AssesmentId, "AssesmentId", htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
#nullable restore
#line 32 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\SubmitAssignments\Edit.cshtml"
           Write(Html.DropDownList("AssesmentId", null, htmlAttributes: new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 33 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\SubmitAssignments\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.AssesmentId, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n\n        <div class=\"form-group\">\n            ");
#nullable restore
#line 38 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\SubmitAssignments\Edit.cshtml"
       Write(Html.LabelFor(model => model.FilePath, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
#nullable restore
#line 40 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\SubmitAssignments\Edit.cshtml"
           Write(Html.EditorFor(model => model.FilePath, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 41 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\SubmitAssignments\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.FilePath, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n\n        <div class=\"form-group\">\n            ");
#nullable restore
#line 46 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\SubmitAssignments\Edit.cshtml"
       Write(Html.LabelFor(model => model.SubmissionDate, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
#nullable restore
#line 48 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\SubmitAssignments\Edit.cshtml"
           Write(Html.EditorFor(model => model.SubmissionDate, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 49 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\SubmitAssignments\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.SubmissionDate, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n\n        <div class=\"form-group\">\n            <div class=\"col-md-offset-2 col-md-10\">\n                <input type=\"submit\" value=\"Save\" class=\"btn btn-default\" />\n            </div>\n        </div>\n    </div>\n");
#nullable restore
#line 59 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\SubmitAssignments\Edit.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div>\n    ");
#nullable restore
#line 62 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\SubmitAssignments\Edit.cshtml"
Write(Html.ActionLink("Back to List", "Index", new { }, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</div>\n\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n     ");
#nullable restore
#line 66 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\SubmitAssignments\Edit.cshtml"
Write(await RenderSectionAsync("~/bundles/jqueryval"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LMS_Demo.Models.SubmitAssignment> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
