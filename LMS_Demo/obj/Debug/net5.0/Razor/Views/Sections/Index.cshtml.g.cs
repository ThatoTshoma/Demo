#pragma checksum "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Sections\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b7c9c649cbbb4e0260f914bd221793fbc1e4d9a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sections_Index), @"mvc.1.0.view", @"/Views/Sections/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b7c9c649cbbb4e0260f914bd221793fbc1e4d9a", @"/Views/Sections/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d2bcdd8fc08353438d43240261eaaa1c0873ff7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Sections_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LMS_Demo.Models.Section>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Sections\Index.cshtml"
  
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2>Index</h2>\n\n<p>\n    ");
#nullable restore
#line 11 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Sections\Index.cshtml"
Write(Html.ActionLink("Create New", "Create", new { }, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</p>\n<table class=\"table\">\n    <tr>\n        <th>\n            Section\n        </th>\n        <th>\n            ");
#nullable restore
#line 19 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Sections\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.CreatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </th> \n        <th>\n            ");
#nullable restore
#line 22 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Sections\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Year));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </th>\n        <th></th>\n    </tr>\n\n");
#nullable restore
#line 27 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Sections\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\n        <td>\n            ");
#nullable restore
#line 30 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Sections\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.Value));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </td>\n        <td>\n            ");
#nullable restore
#line 33 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Sections\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.CreatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </td> \n        <td>\n            ");
#nullable restore
#line 36 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Sections\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.Year.Value));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </td>\n        <td>\n            ");
#nullable restore
#line 39 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Sections\Index.cshtml"
       Write(Html.ActionLink(" ", "Edit", new { id=item.SysId },new { @class= "btn btn-primary li fa fa-pen" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \n            ");
#nullable restore
#line 40 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Sections\Index.cshtml"
       Write(Html.ActionLink(" ", "Details", new { id=item.SysId }, new {@class= "btn  btn-success li fa fa-eye" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \n            ");
#nullable restore
#line 41 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Sections\Index.cshtml"
       Write(Html.ActionLink(" ", "Delete", new { id=item.SysId }, new { @class = "btn btn-danger li js-delete fa fa-trash" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </td>\n    </tr>\n");
#nullable restore
#line 44 "C:\Users\THATO TSHOMA\Pictures\LMS_Demo\LMS_Demo\Views\Sections\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</table>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LMS_Demo.Models.Section>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
