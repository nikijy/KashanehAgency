#pragma checksum "F:\Kashaneh\Kashaneh\Kashaneh.Web\Views\Shared\_MainMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8e121fcd344b9d13be34c332b0f6e04bb63691a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__MainMenu), @"mvc.1.0.view", @"/Views/Shared/_MainMenu.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e121fcd344b9d13be34c332b0f6e04bb63691a5", @"/Views/Shared/_MainMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__MainMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<nav class=""navbar navbar-default navbar-fixed-top"" role=""navigation"">
    <div class=""container"">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class=""navbar-header"">
            <button type=""button"" class=""navbar-toggle"" data-toggle=""collapse"" data-target=""#navbar-top"">
                <span class=""sr-only"">Toggle navigation</span>
                <span class=""icon-bar""></span>
                <span class=""icon-bar""></span>
                <span class=""icon-bar""></span>
            </button>
            <a class=""navbar-brand"" href=""/Home/Index""><span>کاشانه</span></a>
        </div>

        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class=""collapse navbar-collapse"" id=""navbar-top"">
            <ul class=""nav navbar-nav navbar-left"">
                <li class=""active""><a href=""/Home/Index"">صفحه اصلی</a></li>
                <li class=""dropdown"">
                    <a href=""#"" class=""dropdown-toggle"" data-togg");
            WriteLiteral(@"le=""dropdown"">ویژگی <b class=""caret""></b></a>
                    <ul class=""dropdown-menu"">
                        <li class=""dropdown"">
                            <a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"">جستجو <b class=""caret""></b></a>
                            <ul>
                                <li><a>1</a></li>
                                <li><a>2</a></li>
                                <li><a>3</a></li>
                            </ul>
                        </li>
                        <li><a href=""search_list.html"">جستجو پیشرفته</a></li>
                        <li><a href=""category.html"">دسته بندی</a></li>
                        <li><a href=""category_list.html"">دسته بندی پیشرفته</a></li>
                        <li><a href=""single.html"">تک صفحه ای</a></li>
                    </ul>
                </li>
                <li class=""dropdown"">
                    <a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"">صفحه <b class=""caret""></b></a>
  ");
            WriteLiteral(@"                  <ul class=""dropdown-menu"">
                        <li><a href=""blog.html"">آرشیو وبلاگ</a></li>
                        <li><a href=""blog_single.html"">وبلاک تک صفحه ای</a></li>
                        <li><a href=""about.html"">درباره ما</a></li>
                        <li><a href=""contact.html"">تماس با ما</a></li>
                    </ul>
                </li>
                <li><a href=""#modal-signin"" class=""signin"" data-toggle=""modal"" data-target=""#modal-signin"">ورود به سایت</a></li>
                <li><a class=""signup"" data-toggle=""modal"" data-target=""#modal-signup"" onclick=""OpenModal()"">ثبت نام</a></li>
            </ul>
        </div><!-- /.navbar-collapse -->
    </div><!-- /.container -->
</nav>
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"">
</script>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        function OpenModal() {\r\n            $(\"#modal-register\").modal(\'show\');\r\n        }\r\n\r\n    </script> \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591