﻿using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Plugin.Widgets.NivoSlider.Infrastructure.Cache;
using Nop.Plugin.Widgets.NivoSlider.Models;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.NivoSlider.Components
{
    [ViewComponent(Name = "WidgetsNivoSlider")]
    public class WidgetsNivoSliderViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly IStaticCacheManager _cacheManager;
        private readonly ISettingService _settingService;
        private readonly IPictureService _pictureService;

        public WidgetsNivoSliderViewComponent(IStoreContext storeContext, 
            IStaticCacheManager cacheManager, 
            ISettingService settingService, 
            IPictureService pictureService)
        {
            this._storeContext = storeContext;
            this._cacheManager = cacheManager;
            this._settingService = settingService;
            this._pictureService = pictureService;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            var nivoSliderSettings = _settingService.LoadSetting<NivoSliderSettings>(_storeContext.CurrentStore.Id);

            var model = new PublicInfoModel
            {
                Picture1Url = GetPictureUrl(nivoSliderSettings.Picture1Id),
                Text1 = nivoSliderSettings.Text1,
                Link1 = nivoSliderSettings.Link1,
                HLarge1 = nivoSliderSettings.HLarge1,
                HSmall1 = nivoSliderSettings.HSmall1,

                Picture2Url = GetPictureUrl(nivoSliderSettings.Picture2Id),
                Text2 = nivoSliderSettings.Text2,
                Link2 = nivoSliderSettings.Link2,
                HLarge2 = nivoSliderSettings.HLarge2,
                HSmall2 = nivoSliderSettings.HSmall2,

                Picture3Url = GetPictureUrl(nivoSliderSettings.Picture3Id),
                Text3 = nivoSliderSettings.Text3,
                Link3 = nivoSliderSettings.Link3,
                HLarge3 = nivoSliderSettings.HLarge3,
                HSmall3 = nivoSliderSettings.HSmall3,

                Picture4Url = GetPictureUrl(nivoSliderSettings.Picture4Id),
                Text4 = nivoSliderSettings.Text4,
                Link4 = nivoSliderSettings.Link4,
                HLarge4 = nivoSliderSettings.HLarge4,
                HSmall4 = nivoSliderSettings.HSmall4,

                Picture5Url = GetPictureUrl(nivoSliderSettings.Picture5Id),
                Text5 = nivoSliderSettings.Text5,
                Link5 = nivoSliderSettings.Link5,
                HLarge5 = nivoSliderSettings.HLarge5,
                HSmall5 = nivoSliderSettings.HSmall5
            };

            if (string.IsNullOrEmpty(model.Picture1Url) && string.IsNullOrEmpty(model.Picture2Url) &&
                string.IsNullOrEmpty(model.Picture3Url) && string.IsNullOrEmpty(model.Picture4Url) &&
                string.IsNullOrEmpty(model.Picture5Url))
                //no pictures uploaded
                return Content("");

            return View("~/Plugins/Widgets.NivoSlider/Views/PublicInfo.cshtml", model);
        }

        protected string GetPictureUrl(int pictureId)
        {
            var cacheKey = string.Format(ModelCacheEventConsumer.PICTURE_URL_MODEL_KEY, pictureId);
            return _cacheManager.Get(cacheKey, () =>
            {
                //little hack here. nulls aren't cacheable so set it to ""
                var url = _pictureService.GetPictureUrl(pictureId, showDefaultPicture: false) ?? "";
                return url;
            });
        }
    }
}
