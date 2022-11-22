using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EjemploSIST.View_Component
{
    public class IdiomaViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult>

        InvokeAsync()
        {
            var idiomas = new List<SelectListItem>();
            idiomas.Add(new SelectListItem()
            {
                Value = "en-US",
                Text = "Ingles"
            }
                );
            idiomas.Add(new SelectListItem()
            {
                Value = "es-PE",
                Text = "Español"
            }
                );
            idiomas.Add(new SelectListItem()
            {
                Value = "fr_FR",
                Text = "Frances"
            });

            var currentCulture = HttpContext.Features.Get<RequestCultureFeature>();
            ViewBag.IdiomeSel = currentCulture.RequestCulture.UICulture.Name;
            return View(idiomas);
        }
    }
}
