using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoDealer.Web.ViewModels
{
    public class ImgModel
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
    }
    public class BannerAutoModel
    {
        [Required]
        public int AutoId { get; set; }
        [Required]
        public string Brand { get; set; }
        public string Maker { get; set; }

        public int? Year { get; set; }
        public int? Mileage { get; set; }
        public string Style { get; set; }
        public int? Sort { get; set; }
        public double? Price { get; set; }
        public ImgModel img { get; set; }
    }
    public class SliderAutoModel
    {
        [Required]
        public int AutoId { get; set; }
        [Required]
        public string Brand { get; set; }

        public int? Year { get; set; }
        public int? Mileage { get; set; }
        public string Style { get; set; }
        public int? Sort { get; set; }
        public double? Price { get; set; }
        public ImgModel img { get; set; }
    }
    public class AutoDetailModel
    {
        [Required]
        public int AutoId { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Maker { get; set; }
        public string Desc { get; set; }
        public string Engine { get; set; }
        public string Trans { get; set; }

        public int? Year { get; set; }
        public int? Mileage { get; set; }
        public string Style { get; set; }
        public int? Sort { get; set; }
        public double? Price { get; set; }
        public List<ImgModel> img { get; set; }
    }
    public class QuickSearchModel
    {
        [StringLength(maximumLength: 64)]
        public string Maker { get; set; }
        [StringLength(maximumLength:64)]
        public string Brand { get; set; }
        public DateTime? MaxYear { get; set; }
        public DateTime? MinYear { get; set; }
        public int? MaxMileage { get; set; }
        [StringLength(maximumLength: 64)]
        public string Style { get; set; }
        [StringLength(maximumLength: 64)]
        public string Transmission { get; set; }
        public int? Sort { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public int PageTotal { get; set; }
    }
}