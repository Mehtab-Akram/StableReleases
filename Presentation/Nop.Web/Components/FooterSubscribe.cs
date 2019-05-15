using Microsoft.AspNetCore.Mvc;
using Nop.Web.Factories;
using Nop.Web.Framework.Components;

namespace Nop.Web.Components
{
    public class FooterSubscribeViewComponent : NopViewComponent
    {
        private readonly ICommonModelFactory _commonModelFactory;

        public FooterSubscribeViewComponent(ICommonModelFactory commonModelFactory)
        {
            this._commonModelFactory = commonModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            //var model = _commonModelFactory.PrepareFooterSubscribeModel();
            //return View(model);
            return View();
        }
    }
}
