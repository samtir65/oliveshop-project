#pragma checksum "C:\Users\Samira\Desktop\Barnamenevisi2020\OliveShop\Views\Shared\_Group.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02116c5d37b8869b60d866f868b95002f788ac0e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Group), @"mvc.1.0.view", @"/Views/Shared/_Group.cshtml")]
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
#line 1 "C:\Users\Samira\Desktop\Barnamenevisi2020\OliveShop\Views\_ViewImports.cshtml"
using OliveShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Samira\Desktop\Barnamenevisi2020\OliveShop\Views\_ViewImports.cshtml"
using OliveShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02116c5d37b8869b60d866f868b95002f788ac0e", @"/Views/Shared/_Group.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb9646e917487c9c7b41fff85a59f632cbdefdc8", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Group : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"
 <li class=""nav-item dropdown"">
    <a class=""nav-link dropdown-toggle"" href=""http://example.com"" id=""dropdown09"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">گروه ها</a>
    <div class=""dropdown-menu"" aria-labelledby=""dropdown09"">
");
#nullable restore
#line 7 "C:\Users\Samira\Desktop\Barnamenevisi2020\OliveShop\Views\Shared\_Group.cshtml"
         foreach (var item in _GroupRepository.GetAllCategories())
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a class=\"dropdown-item\"");
            BeginWriteAttribute("href", " href=\"", 419, "\"", 460, 4);
            WriteAttributeValue("", 426, "/Group/", 426, 7, true);
#nullable restore
#line 9 "C:\Users\Samira\Desktop\Barnamenevisi2020\OliveShop\Views\Shared\_Group.cshtml"
WriteAttributeValue("", 433, item.CategoryId, 433, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 449, "/", 449, 1, true);
#nullable restore
#line 9 "C:\Users\Samira\Desktop\Barnamenevisi2020\OliveShop\Views\Shared\_Group.cshtml"
WriteAttributeValue("", 450, item.Name, 450, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 9 "C:\Users\Samira\Desktop\Barnamenevisi2020\OliveShop\Views\Shared\_Group.cshtml"
                                                                          Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 10 "C:\Users\Samira\Desktop\Barnamenevisi2020\OliveShop\Views\Shared\_Group.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</li> \r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IGroupRepositori _GroupRepository { get; private set; }
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
