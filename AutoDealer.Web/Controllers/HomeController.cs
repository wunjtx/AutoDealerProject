using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Xml;
using System.Web.UI.WebControls;
using AutoDealer.Web.ViewModels;
using System.Xml.Serialization;
using AutoDealer.Service;
using AutoDealer.Web.Const;
using AutoDealer.Core.Domain;
using System.Data.Entity;
using AutoDealer.Core.Serialize;

namespace AutoDealer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAutoService AutoService;
        private OptionsModel _options;
        public OptionsModel options
        {
            get
            {
                if (_options == null)
                {
                    _options = ReadXml();
                }
                return _options;
            }
        }
        public HomeController(IAutoService autoService)
        {
            this.AutoService = autoService;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Options = this.options;
            var bannerCars = AutoService.GetCars(1,6).ToList();
            var sliderCars = AutoService.GetCars(1,3).ToList();
            List<BannerAutoModel> banners = new List<BannerAutoModel>();
            List<SliderAutoModel> sliders = new List<SliderAutoModel>();
            bannerCars.ForEach(b =>
            {
                var banner = new BannerAutoModel();
                banner.AutoId = b.ID;
                banner.Brand = b.Brand.Name;
                banner.Maker = b.Maker.Name;
                banner.Mileage = b.Mileage;
                banner.img.Url = b.Img.FirstOrDefault(i => i.Type == ImgType.Banner).Address;
                banner.Price = b.Price;
                banner.Sort = b.Sort;
                banner.Style = b.BodyStyle;
                banners.Add(banner);
            });
            sliderCars.ForEach(b =>
            {
                var slider = new SliderAutoModel();
                slider.AutoId = b.ID;
                slider.Brand = b.Brand.Name;
                slider.Mileage = b.Mileage;
                slider.img.Url = b.Img.FirstOrDefault(i => i.Type == ImgType.Slider).Address;
                slider.Price = b.Price;
                slider.Sort = b.Sort;
                slider.Style = b.BodyStyle;
                sliders.Add(slider);
            });
            ViewBag.Banners = banners;
            ViewBag.Sliders = sliders;

            return View();
        }

        public ActionResult Search(string content)
        {
            return View();
        }
        [HttpGet]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult BrowseBy(int? pageIndex)
        {
            HttpCookie cookies = Request.Cookies["QuickSearchModel"];
            int index = pageIndex ?? 1;
            if (cookies!=null )
            {
                List<BannerAutoModel> lists = new List<BannerAutoModel>();
                var value = cookies.Values["Options"];
                var model = SerializerHelper.DeserializeToObject<QuickSearchModel>(value);
                if (!string.IsNullOrEmpty(value) && model !=null)
                {

                    var result = AutoService.GetSet().AsQueryable();
                    if (!string.IsNullOrEmpty(model.Brand))
                    {
                        result = result.Where(r => r.Brand.Name == model.Brand);
                    }
                    if (!string.IsNullOrEmpty(model.Brand))
                    {
                        result = result.Where(r => r.Brand.Name == model.Brand);
                    }
                    if (model.MinYear != null && model.MinYear <= model.MaxYear)
                    {
                        result = result.Where(r => r.Year > model.MinYear);
                    }
                    if (model.MaxYear != null && model.MaxYear >= model.MinYear)
                    {
                        result = result.Where(r => r.Year <= model.MaxYear);
                    }
                    if (!string.IsNullOrEmpty(model.Style))
                    {
                        result = result.Where(r => r.BodyStyle == model.Style);
                    }
                    if (!string.IsNullOrEmpty(model.Transmission))
                    {
                        result = result.Where(r => r.Transmission == model.Transmission);
                    }
                    var list = result.ToList();
                    model.PageTotal = list.Count();
                    model.PageIndex = index;
                    model.PageCount = 6;
                    HttpCookie cookie = new HttpCookie("QuickSearchModel");
                    DateTime dt = DateTime.Now;
                    TimeSpan ts = new TimeSpan(0, 1, 0, 0, 0);
                    cookie.Expires = dt.Add(ts);

                    cookie.Values.Add("Options", SerializerHelper.SerializerToString(model));
                    Response.AppendCookie(cookie);

                    var cars = result.Skip(index).Take(9).ToList();
                    ViewBag.SearchModel = model;
                    return View(lists);
                }
            }
            var bannerCars = AutoService.GetCars(index, 6).ToList();
            List<BannerAutoModel> banners = new List<BannerAutoModel>();
            bannerCars.ForEach(b =>
            {
                var banner = new BannerAutoModel();
                banner.AutoId = b.ID;
                banner.Brand = b.Brand.Name;
                banner.Maker = b.Maker.Name;
                banner.Mileage = b.Mileage;
                banner.img.Url = b.Img.FirstOrDefault(i => i.Type == ImgType.Banner).Address;
                banner.Price = b.Price;
                banner.Sort = b.Sort;
                banner.Style = b.BodyStyle;
                banners.Add(banner);
            });
            
            return View(banners);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult BrowseBy(int? pageIndex,QuickSearchModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            int index = pageIndex ?? 1;
            var result = AutoService.GetSet().AsQueryable();
            if (!string.IsNullOrEmpty(model.Brand))
            {
                result = result.Where(r => r.Brand.Name == model.Brand);
            }
            if (!string.IsNullOrEmpty(model.Brand))
            {
                result = result.Where(r => r.Brand.Name == model.Brand);
            }
            if (model.MinYear !=null  && model.MinYear <= model.MaxYear)
            {
                result = result.Where(r => r.Year > model.MinYear);
            }
            if (model.MaxYear!=null && model.MaxYear >= model.MinYear)
            {
                result = result.Where(r => r.Year <= model.MaxYear);
            }
            if (!string.IsNullOrEmpty(model.Style))
            {
                result = result.Where(r => r.BodyStyle == model.Style);
            }
            if (!string.IsNullOrEmpty( model.Transmission))
            {
                result = result.Where(r => r.Transmission == model.Transmission);
            }
            var list = result.ToList();
            model.PageTotal = list.Count();
            model.PageIndex = index;
            model.PageCount = 6;
            HttpCookie cookie = new HttpCookie("QuickSearchModel");
            DateTime dt = DateTime.Now;
            TimeSpan ts = new TimeSpan(0, 1, 0, 0, 0);
            cookie.Expires = dt.Add(ts);

            cookie.Values.Add("Options",SerializerHelper.SerializerToString( model));
            Response.AppendCookie(cookie);
            ViewBag.SearchModel = model;
            var cars = result.Skip(index).Take(9).ToList();

            return View(cars);
        }
        public ActionResult Detail(int Id)
        {
            var auto = AutoService.GetCar(Id);
            AutoDetailModel detail = new AutoDetailModel();
            List<ImgModel> imgs = new List<ImgModel>();
            var imglist = auto.Img.Where(i => i.Type == ImgType.Temp).ToList();
            imglist.ForEach(i =>
            {
                var img = new ImgModel();
                img.Id = i.ID;
                img.Name = i.Name;
                img.Url = i.Address;
                img.Type = i.Type;
            });
            detail.AutoId = auto.ID;
            detail.Brand = auto.Brand.Name;
            detail.Maker = auto.Maker.Name;
            detail.Mileage = auto.Mileage;
            detail.img = imgs;
            detail.Price = auto.Price;
            detail.Sort = auto.Sort;
            detail.Style = auto.BodyStyle;
            detail.Desc = auto.Description;
            detail.Engine = auto.Engine;
            detail.Trans = auto.Transmission;
            return View(detail);
        }

        private OptionsModel ReadXml()
        {
            string xmlPath = Server.MapPath(@"~/App_Data/AutoOptions.xml");

            using (StreamReader sr = new StreamReader(xmlPath))
            {
                XmlSerializer xz = new XmlSerializer(typeof(OptionsModel));// Do not use other constructor other than XmlSerializer(Type) and XmlSerializer.XmlSerializer(Type, String) 
                var options = (OptionsModel)xz.Deserialize(sr);
                return options;
            }
        }
    }
}