#pragma checksum "C:\Users\smikm\source\repos\Project1\Project1\Pages\Shared\Components\IssueTable\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1963e5fc26018df3c25cf92c07864f0da520635e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Project1.Pages.Shared.Components.IssueTable.Pages_Shared_Components_IssueTable_Default), @"mvc.1.0.view", @"/Pages/Shared/Components/IssueTable/Default.cshtml")]
namespace Project1.Pages.Shared.Components.IssueTable
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
#line 1 "C:\Users\smikm\source\repos\Project1\Project1\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\smikm\source\repos\Project1\Project1\Pages\_ViewImports.cshtml"
using Project1.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\smikm\source\repos\Project1\Project1\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1963e5fc26018df3c25cf92c07864f0da520635e", @"/Pages/Shared/Components/IssueTable/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3a35e5ff264185196c5b0be13133cc73df2f90d", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_IssueTable_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IReadOnlyList<IssueTableViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Issue", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("pd"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!--<div class=""container-fluid"">
        <table class=""row table-hover"" >
            <thead>

            </thead>
            <tbody class=""container"">


                }
            </tbody>
        </table>
    </div>-->

        <div class=""container-fluid issue-table"" style=""height:500px;"">
            <div class=""row mb-2 issue-prop-names"">
                <div class=""-name"" style=""margin-left:19px;"">
                </div>
                <div class=""col-5 issue-prop-name"">
                    <span>Name</span>
                </div>
                <div class=""col-3 issue-prop-name"">
                    <span>Status</span>
                </div>
                <div class=""col-3 issue-prop-name"">
                    <span>Created</span>
                </div>
                <!--<div class=""col-2 issue-prop-name"">
                    <span>User</span>
                </div>-->
            </div>
");
#nullable restore
#line 32 "C:\Users\smikm\source\repos\Project1\Project1\Pages\Shared\Components\IssueTable\Default.cshtml"
             foreach (var i in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1963e5fc26018df3c25cf92c07864f0da520635e5653", async() => {
                WriteLiteral("\r\n                    <div class=\"row shadow-sm rounded issue-row mb-1\">\r\n                        <div class=\"issue-type pt-1 pb-1\">\r\n                            <span class=\"type-box \"");
                BeginWriteAttribute("title", " title=\"", 1313, "\"", 1333, 1);
#nullable restore
#line 37 "C:\Users\smikm\source\repos\Project1\Project1\Pages\Shared\Components\IssueTable\Default.cshtml"
WriteAttributeValue("", 1321, i.Type.Name, 1321, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("style", " style=\"", 1334, "\"", 1366, 2);
                WriteAttributeValue("", 1342, "background:", 1342, 11, true);
#nullable restore
#line 37 "C:\Users\smikm\source\repos\Project1\Project1\Pages\Shared\Components\IssueTable\Default.cshtml"
WriteAttributeValue("", 1353, i.Type.Color, 1353, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></span>\r\n                        </div>\r\n                        <div class=\"col-5 issue-name\">\r\n                            <span>");
#nullable restore
#line 40 "C:\Users\smikm\source\repos\Project1\Project1\Pages\Shared\Components\IssueTable\Default.cshtml"
                             Write(i.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                        </div>\r\n                        <div class=\"col-3 issue-status \"");
                BeginWriteAttribute("style", " style=\"", 1603, "\"", 1633, 3);
                WriteAttributeValue("", 1611, "color:", 1611, 6, true);
#nullable restore
#line 42 "C:\Users\smikm\source\repos\Project1\Project1\Pages\Shared\Components\IssueTable\Default.cshtml"
WriteAttributeValue("", 1617, i.Status.Color, 1617, 15, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1632, ";", 1632, 1, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n                            <span>");
#nullable restore
#line 43 "C:\Users\smikm\source\repos\Project1\Project1\Pages\Shared\Components\IssueTable\Default.cshtml"
                             Write(i.Status.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                        </div>\r\n                        <div class=\"col-3 issue-date\">\r\n                            <div class=\"container-fluid\">\r\n                                <div class=\"row\">\r\n                                    <span>");
#nullable restore
#line 48 "C:\Users\smikm\source\repos\Project1\Project1\Pages\Shared\Components\IssueTable\Default.cshtml"
                                     Write(i.Created);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 34 "C:\Users\smikm\source\repos\Project1\Project1\Pages\Shared\Components\IssueTable\Default.cshtml"
                                                   WriteLiteral(i.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 54 "C:\Users\smikm\source\repos\Project1\Project1\Pages\Shared\Components\IssueTable\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    ");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAuthorizationService authorizationService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IReadOnlyList<IssueTableViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
