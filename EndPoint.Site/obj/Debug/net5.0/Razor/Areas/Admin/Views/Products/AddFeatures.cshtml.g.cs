#pragma checksum "D:\فروشگاهی متی کالا\MetiKala\EndPoint.Site\Areas\Admin\Views\Products\AddFeatures.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3974fceea7e5c0bdd42588416fce50edc1fc61d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Products_AddFeatures), @"mvc.1.0.view", @"/Areas/Admin/Views/Products/AddFeatures.cshtml")]
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
#line 1 "D:\فروشگاهی متی کالا\MetiKala\EndPoint.Site\Areas\Admin\Views\_ViewImports.cshtml"
using EndPoint.Site;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\فروشگاهی متی کالا\MetiKala\EndPoint.Site\Areas\Admin\Views\_ViewImports.cshtml"
using EndPoint.Site.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3974fceea7e5c0bdd42588416fce50edc1fc61d5", @"/Areas/Admin/Views/Products/AddFeatures.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87685c89e84078b3e134b89a928accf3d0f04a39", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Products_AddFeatures : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Sweetalert2/sweetalert2.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Sweetalert2/sweetalert2.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\فروشگاهی متی کالا\MetiKala\EndPoint.Site\Areas\Admin\Views\Products\AddFeatures.cshtml"
  
    ViewData["Title"] = "AddFeatures";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    
<div class=""col-xl-2 col-lg-6 col-md-12 mb-1"">
    <fieldset class=""form-group"">
        <label for=""basicInput""> نام ویژگی </label>
        <input type=""text""  id=""txtDisplayName"" placeholder=""نام ویژگی"" />
    </fieldset>
</div>

<div class=""col-xl-2 col-lg-6 col-md-12 mb-1"">
    <fieldset class=""form-group"">
        <label for=""basicInput""> مقدار ویژگی </label>
        <input type=""text""  id=""txtValue"" placeholder=""مقدار ویژگی"" />
    </fieldset>
</div>
<div class=""col-xl-2 col-lg-6 col-md-12 mb-1"">
    <fieldset class=""form-group"">
        <br />
        <a class=""btn btn-success"" id=""btnAddFeatures"">افزودن</a>
    </fieldset>
</div>



<br class=""clear"" />

<table id=""tbl_Features"" class=""col-md-12 table table-bordered table-hover  table-condensed table-responsive"">
    <thead>
        <tr>
            <th>
                نام ویژگی
            </th>
            <th>
                مقدار ویژگی
            </th>
            <th>

            </th>
        </tr>");
            WriteLiteral("\r\n    </thead>\r\n    <tbody></tbody>\r\n</table>\r\n\r\n\r\n<div class=\"col-12\">\r\n\r\n    <button id=\"btnAddProduct\"  class=\"btn\">ذخیره تغییرات</button>\r\n</div>\r\n                \r\n\r\n\r\n\r\n     \r\n<!-- Your Profile Views Chart END-->\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3974fceea7e5c0bdd42588416fce50edc1fc61d56031", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3974fceea7e5c0bdd42588416fce50edc1fc61d57209", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script>



        $(""#btnAddFeatures"").on(""click"", function () {

            var txtDisplayName = $(""#txtDisplayName"").val();
            var txtValue = $(""#txtValue"").val();

            if (txtDisplayName == """" || txtValue == """") {
                swal.fire(
                    'هشدار!',
                    ""نام و مقدار را باید وارد کنید"",
                    'warning'
                );
            }
            else {
                $('#tbl_Features tbody').append('<tr> <td>' + txtDisplayName + '</td>  <td>' + txtValue + '</td> <td> <a class=""idFeatures btnDelete btn btn-danger""> حذف </a> </td> </tr>');
                $(""#txtDisplayName"").val('');
                $(""#txtValue"").val('');
            }
        });

        $(""#tbl_Features"").on('click', '.idFeatures', function () {
            $(this).closest('tr').remove();
        });

</script>
   
    <script>


        $('#btnAddProduct').on('click', function () {

            var data = new FormData();


                WriteLiteral(@"

            //دریافت ویژگی های محصول از جدول
            var dataFeaturesViewModel = $('#tbl_Features tr:gt(0)').map(function () {
                return {
                    DisplayName: $(this.cells[0]).text(),
                    Value: $(this.cells[1]).text(),
                };
            }).get();

            $.each(dataFeaturesViewModel, function (i, val) {
                data.append('[' + i + '].DisplayName', val.DisplayName);
                data.append('[' + i + '].Value', val.Value);

            });





            // ارسال اطلاعات به کنترلر
            var ajaxRequest = $.ajax({
                type: ""POST"",
                url: ""/admin/products/AddFeatures/");
#nullable restore
#line 125 "D:\فروشگاهی متی کالا\MetiKala\EndPoint.Site\Areas\Admin\Views\Products\AddFeatures.cshtml"
                                             Write(Model);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                contentType: false,
                processData: false,
                data: data,
                success: function (msg) {
                    console.log(msg);
                    console.log("";lk3ehrl'4rhh4"");

                },
                error: function (req, status, error) {
                    console.log(msg);
                }
            }).then(function (isConfirm) {
                window.location.href = ""/Admin/Products/"";
            });

        });
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591