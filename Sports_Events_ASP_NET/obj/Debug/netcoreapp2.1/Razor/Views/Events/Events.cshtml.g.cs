#pragma checksum "/Users/Domin/Projects/Sports_Events_ASP_NET/Sports_Events_ASP_NET/Views/Events/Events.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "515395733cb8e98314d8bc02f700c58853053acb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Events_Events), @"mvc.1.0.view", @"/Views/Events/Events.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Events/Events.cshtml", typeof(AspNetCore.Views_Events_Events))]
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
#line 1 "/Users/Domin/Projects/Sports_Events_ASP_NET/Sports_Events_ASP_NET/Views/_ViewImports.cshtml"
using Sports_Events_ASP_NET.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"515395733cb8e98314d8bc02f700c58853053acb", @"/Views/Events/Events.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc65ccede35167a3d6af85b4014600879efab14d", @"/Views/_ViewImports.cshtml")]
    public class Views_Events_Events : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Event>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "/Users/Domin/Projects/Sports_Events_ASP_NET/Sports_Events_ASP_NET/Views/Events/Events.cshtml"
 foreach (var e in Model)
{

#line default
#line hidden
            BeginContext(57, 23, true);
            WriteLiteral("    <div>\r\n        <h3>");
            EndContext();
            BeginContext(81, 7, false);
#line 5 "/Users/Domin/Projects/Sports_Events_ASP_NET/Sports_Events_ASP_NET/Views/Events/Events.cshtml"
       Write(e.Title);

#line default
#line hidden
            EndContext();
            BeginContext(88, 19, true);
            WriteLiteral("</h3>\r\n        <h4>");
            EndContext();
            BeginContext(108, 7, false);
#line 6 "/Users/Domin/Projects/Sports_Events_ASP_NET/Sports_Events_ASP_NET/Views/Events/Events.cshtml"
       Write(e.Price);

#line default
#line hidden
            EndContext();
            BeginContext(115, 19, true);
            WriteLiteral("</h4>\r\n    </div>\r\n");
            EndContext();
#line 8 "/Users/Domin/Projects/Sports_Events_ASP_NET/Sports_Events_ASP_NET/Views/Events/Events.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Event>> Html { get; private set; }
    }
}
#pragma warning restore 1591
