#pragma checksum "C:\Users\Administrator\Desktop\Main Folder\Projects\WorkshopWeb\Workshop.Web\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c890d52bca8a66339bca1fb3688a6429474678ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Index), @"mvc.1.0.view", @"/Views/Dashboard/Index.cshtml")]
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
#line 1 "C:\Users\Administrator\Desktop\Main Folder\Projects\WorkshopWeb\Workshop.Web\Views\_ViewImports.cshtml"
using Workshop.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Administrator\Desktop\Main Folder\Projects\WorkshopWeb\Workshop.Web\Views\_ViewImports.cshtml"
using Workshop.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c890d52bca8a66339bca1fb3688a6429474678ee", @"/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"256f1efcfe7aa2a325f1d8692f6e460d4273a9e6", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Workshop.Web.Data.Entities.Mechanic>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Car", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ViewCar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Administrator\Desktop\Main Folder\Projects\WorkshopWeb\Workshop.Web\Views\Dashboard\Index.cshtml"
  
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<link href='https://cdn.jsdelivr.net/npm/fullcalendar@5.11.3/main.min.css' rel='stylesheet' />

<h1>Dashboard</h1>

<div id=""calendar""></div>

<div id=""calendarModal"" class=""modal fade"" role=""dialog"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title""><span id=""eventTitle""></span></h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>
            <div class=""modal-body"">
                <p id=""eventId""></p>
                <p id=""eventDescription""></p>
                <p id=""eventPrice""></p>
                <p id=""eventStartDate""></p>
            </div>
            <div class=""modal-footer"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c890d52bca8a66339bca1fb3688a6429474678ee5734", async() => {
                WriteLiteral("View Car");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <a class=""btn btn-danger"" onclick=""CancelRepair()"">Cancel Repair</a>
            </div>
        </div>
    </div>
</div>

<div id=""confirmModal"" class=""modal fade"" role=""dialog"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title""><span>Confirm Appointment</span></h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>
            <div class=""modal-body"">
                <p id=""eventId""></p>
                <p><b>Mechanic</b></p>
                <select id=""eventMechanic"" name=""Mechanic"" class=""form-control"">
");
#nullable restore
#line 44 "C:\Users\Administrator\Desktop\Main Folder\Projects\WorkshopWeb\Workshop.Web\Views\Dashboard\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c890d52bca8a66339bca1fb3688a6429474678ee8310", async() => {
#nullable restore
#line 46 "C:\Users\Administrator\Desktop\Main Folder\Projects\WorkshopWeb\Workshop.Web\Views\Dashboard\Index.cshtml"
                                                 Write(item.User.FullName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 46 "C:\Users\Administrator\Desktop\Main Folder\Projects\WorkshopWeb\Workshop.Web\Views\Dashboard\Index.cshtml"
                           WriteLiteral(item.User.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 47 "C:\Users\Administrator\Desktop\Main Folder\Projects\WorkshopWeb\Workshop.Web\Views\Dashboard\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </select>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-primary"" onclick=""ConfirmAppointment()"">Yes</button>
                <button type=""button"" data-dismiss=""modal"" class=""btn btn-danger"">No</button>
            </div>
        </div>
    </div>
</div>

<div id=""finishModal"" class=""modal fade"" role=""dialog"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title""><span>Finish Appointment</span></h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>
            <div class=""modal-body"">
                <p id=""eventId""></p>
                <p id=""eventCarId""></p>
                <p><b>Appointment Description</b></p>
                <input id=""repairDescription"" class=""form-control"" />
                <p><b>Appointment Price</b></p>
                <input id=""rep");
            WriteLiteral(@"airPrice"" class=""form-control"" />
                <br />
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-primary"" onclick=""FinishAppointment()"">Confirm</button>
                <button type=""button"" data-dismiss=""modal"" class=""btn btn-danger"">Close</button>
            </div>
        </div>
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""https://cdn.jsdelivr.net/npm/fullcalendar@5.11.3/main.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.29.4/moment.min.js""></script>

    <script>

        var calendar;

        document.addEventListener(""DOMContentLoaded"", function () {
            var calendarEl = document.getElementById(""calendar"");
            calendar = new FullCalendar.Calendar(calendarEl, {
                initialView: ""dayGridMonth"",
                eventClick: function (data){
");
#nullable restore
#line 95 "C:\Users\Administrator\Desktop\Main Folder\Projects\WorkshopWeb\Workshop.Web\Views\Dashboard\Index.cshtml"
                     if (User.IsInRole("Worker"))
                    {
                        

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            if (calendar.getEventById(data.event.id).backgroundColor == ""red""){
                                $(""#confirmModal #eventId"").empty().html(data.event.id);
                                $(""#confirmModal #eventId"").hide();
                                $(""#confirmModal"").modal();
                            } 
                        ");
#nullable restore
#line 103 "C:\Users\Administrator\Desktop\Main Folder\Projects\WorkshopWeb\Workshop.Web\Views\Dashboard\Index.cshtml"
                               
                    }
                    else if (User.IsInRole("Mechanic"))
                    {
                        

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            $(""#finishModal #eventId"").empty().html(data.event.id);
                            $(""#finishModal #eventId"").hide();
                            $(""#finishModal #eventCarId"").empty().html(data.event.extendedProps.carId);
                            $(""#finishModal #eventCarId"").hide();
                            $(""#finishModal"").modal();
                        ");
#nullable restore
#line 113 "C:\Users\Administrator\Desktop\Main Folder\Projects\WorkshopWeb\Workshop.Web\Views\Dashboard\Index.cshtml"
                               
                    }
                    else{
                        

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            $(""#calendarModal #eventId"").empty().html(data.event.id);
                            $(""#calendarModal #eventId"").hide();
                            $(""#calendarModal #eventTitle"").text(data.event.title);
                            $(""#calendarModal #eventDescription"").empty().html(""<b>Description: </b>"" + data.event.extendedProps.description);
                            $(""#calendarModal #eventPrice"").empty().html(""<b>Price: </b>"" + data.event.extendedProps.price + ""€"");
                            $(""#calendarModal #eventStartDate"").empty().html(data.event.extendedProps.startDate);
                            $(""#calendarModal #eventStartDate"").hide();
                            $(""#calendarModal"").modal();
                        ");
#nullable restore
#line 125 "C:\Users\Administrator\Desktop\Main Folder\Projects\WorkshopWeb\Workshop.Web\Views\Dashboard\Index.cshtml"
                               
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                }\r\n            });\r\n\r\n            $.ajax({\r\n                type: \"POST\",\r\n");
#nullable restore
#line 132 "C:\Users\Administrator\Desktop\Main Folder\Projects\WorkshopWeb\Workshop.Web\Views\Dashboard\Index.cshtml"
                 if(User.IsInRole("Worker"))
                {
                    

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        url: \"/API/Schedule/GetWorkerSchedules\",\r\n                    ");
#nullable restore
#line 136 "C:\Users\Administrator\Desktop\Main Folder\Projects\WorkshopWeb\Workshop.Web\Views\Dashboard\Index.cshtml"
                           
                }
                else if(User.IsInRole("Mechanic"))
                {
                    

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        url: \"/API/Schedule/GetMechanicSchedules\",\r\n                    ");
#nullable restore
#line 142 "C:\Users\Administrator\Desktop\Main Folder\Projects\WorkshopWeb\Workshop.Web\Views\Dashboard\Index.cshtml"
                           
                }
                else
                {
                    

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        url: \"/API/Schedule/GetSchedules\",\r\n                    ");
#nullable restore
#line 148 "C:\Users\Administrator\Desktop\Main Folder\Projects\WorkshopWeb\Workshop.Web\Views\Dashboard\Index.cshtml"
                           
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                data: JSON.stringify({ userEmail: \"");
#nullable restore
#line 150 "C:\Users\Administrator\Desktop\Main Folder\Projects\WorkshopWeb\Workshop.Web\Views\Dashboard\Index.cshtml"
                                              Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""" }),
                contentType: ""application/json;"",
                success: function(data){
                    $.each(data, function (i, v){
                        var color;
                      
                        if (v.isConfirmed) {
                            color = ""green"";
                        }
                        else {
                            color = ""red"";
                        }
                        debugger;
                        calendar.addEvent({
                            id: v.id,
                            title: v.car.carName,
                            carId: v.car.id,
                            description: v.description,
                            price: v.price,
                            start: moment(v.startDate).format(),
                            startDate: v.startDate,
                            allDay: true,
                            backgroundColor: color,
                            borderColor: color,
         ");
                WriteLiteral(@"               });
                    })          
                }
            });
            calendar.render();
          
        });

        function CancelRepair() {
            $.ajax({
                type: ""POST"",
                url: ""/API/Schedule/RemoveSchedule"",
                data: JSON.stringify({ Id: $(""#calendarModal #eventId"").text() }),
                contentType: ""application/json;"",
                success: function () {
                    calendar.getEventById($(""#calendarModal #eventId"")).remove();
                    $(""#calendarModal"").modal(""hide"");
                }
            });
        }

        function ConfirmAppointment() {
            $.ajax({
                type: ""POST"",
                url: ""/API/Schedule/ConfirmSchedule"",
                data: JSON.stringify({ Id: $(""#confirmModal #eventId"").text(), UserId: $(""#eventMechanic"").val() }),
                contentType: ""application/json;"",
                success: function () {
            ");
                WriteLiteral(@"        calendar.getEventById($(""#confirmModal #eventId"").text()).setProp(""backgroundColor"", ""green"");
                    calendar.getEventById($(""#confirmModal #eventId"").text()).setProp(""borderColor"", ""green"");
                    $(""#confirmModal"").modal(""hide"");
                }
            });
        }

        function FinishAppointment() {

            $.ajax({
                type: ""POST"",
                url: ""/API/Schedule/FinishSchedule"",
                data: JSON.stringify({ Id: $(""#finishModal #eventId"").text(), Description: $(""#repairDescription"").val(), Price: $(""#repairPrice"").val(), UserId: $(""#eventCarId"").val() }),
                contentType: ""application/json;"",
                success: function () {
                    calendar.getEventById($(""#finishModal #eventId"").text()).remove();
                    $(""#finishModal"").modal(""hide"");
                }
            });
        }

    </script>
");
            }
            );
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Workshop.Web.Data.Entities.Mechanic>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591