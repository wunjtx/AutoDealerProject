using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace AutoDealer.Web.ViewModels
{
    [XmlRoot("Options")]
    public class OptionsModel
    {
        [XmlArray("Makers"),XmlArrayItem("Maker")]
        public List<MakerModel> Makers { get; set; }
        [XmlElement("Years")]
        public List<YearModel> Years { get; set; }
        [XmlElement("ExteriorColors")]
        public List<ExteriorColorModel> ExColors { get; set; }
        [XmlElement("InteriorColors")]
        public List<InteriorColorModel> InColors { get; set; }
        [XmlElement("BodyStyles")]
        public List<BodyStyleModel> BodyModel { get; set; }
        [XmlElement("Transmissions")]
        public List<TransmissionModel> Trans { get; set; }
        [XmlElement("DriveTypes")]
        public List<DriveTypeModel> DriveTypes { get; set; }
        [XmlElement("Engines")]
        public List<EngineModel> Engines { get; set; }
        [XmlElement("Conditions")]
        public List<ConditionModel> Conds { get; set; }
    }
    [XmlRoot("Makers")]
    public class MakerModel
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlArray("Brands"),XmlArrayItem("Brand")]
        public List<BrandModel> Brands { get; set; }
    }
    [XmlRoot("Brands")]
    public class BrandModel
    {
        [XmlElement("Brand")]
        public List<string> Brand { get; set; }
    }
    [XmlRoot("Options")]
    public class YearModel
    {
        [XmlElement("Year")]
        public List<string> Year { get; set; }
    }
    [XmlRoot("Options")]
    public class ExteriorColorModel
    {
        [XmlElement("ExteriorColor")]
        public List<string> ExteriorColor { get; set; }
    }
    [XmlRoot("Options")]
    public class InteriorColorModel
    {
        [XmlElement("InteriorColor")]
        public List<string> InteriorColor { get; set; }
    }
    [XmlRoot("Options")]
    public class BodyStyleModel
    {
        [XmlElement("BodyStyle")]
        public List<string> BodyStyle { get; set; }
    }
    [XmlRoot("Options")]
    public class TransmissionModel
    {
        [XmlElement("Transmission")]
        public List<string> Transmission { get; set; }
    }
    [XmlRoot("Options")]
    public class ConditionModel
    {
        [XmlElement("Condition")]
        public List<string> Condition { get; set; }
    }
    [XmlRoot("Options")]
    public class EngineModel
    {
        [XmlElement("Engine")]
        public List<string> Engine { get; set; }
    }
    [XmlRoot("Options")]
    public class DriveTypeModel
    {
        [XmlElement("DriveType")]
        public List<string> DriveType { get; set; }
    }
}