#pragma checksum "C:\Users\ntduong3\source\repos\WebApiExercise\WebApiExercise\Views\Videos\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53b0f9e59677913713058e0676cab1dec310f352"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Videos_Create), @"mvc.1.0.view", @"/Views/Videos/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53b0f9e59677913713058e0676cab1dec310f352", @"/Views/Videos/Create.cshtml")]
    public class Views_Videos_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApiExercise.Models.Video>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\ntduong3\source\repos\WebApiExercise\WebApiExercise\Views\Videos\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Create</h1>

<h4>Video</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Create"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""VideoName"" class=""control-label""></label>
                <input asp-for=""VideoName"" class=""form-control"" />
                <span asp-validation-for=""VideoName"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Status"" class=""control-label""></label>
                <input asp-for=""Status"" class=""form-control"" />
                <span asp-validation-for=""Status"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""UploadDate"" class=""control-label""></label>
                <input asp-for=""UploadDate"" class=""form-control"" />
                <span asp-validation-for=""UploadDate"" class=""text-danger""></");
            WriteLiteral(@"span>
            </div>
            <div class=""form-group"">
                <label asp-for=""PublishDate"" class=""control-label""></label>
                <input asp-for=""PublishDate"" class=""form-control"" />
                <span asp-validation-for=""PublishDate"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Create"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to List</a>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 47 "C:\Users\ntduong3\source\repos\WebApiExercise\WebApiExercise\Views\Videos\Create.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApiExercise.Models.Video> Html { get; private set; }
    }
}
#pragma warning restore 1591