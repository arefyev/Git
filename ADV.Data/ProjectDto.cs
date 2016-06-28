using ADV.Common;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ADV.Data
{
    [XmlRoot("Project")]
    public class ProjectDto
    {
        [XmlElement("Title")]
        public string Title { get; set; }
        [XmlElement("Logo")]
        public string Logo { get; set; }
        
        [XmlIgnore]
        public DateTime StartDate { get; set; }

        [XmlElement("StartDate")]
        public string _StartDate
        {
            set { StartDate = value.GetDeserializedDateTime("dd-MM-yyyy").Value; }
            get { return default(string); }
        }

        [XmlElement("EndDate")]
        public string _EndDate
        {
            set { EndDate = value.GetDeserializedDateTime("dd-MM-yyyy"); }
            get { return default(string); }
        }

        [XmlIgnore]
        public DateTime? EndDate { get; set; }
        [XmlElement("Company")]
        public string Company { get; set; }

        [XmlElement("ShortDescription")]
        public string ShortDescription { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("Favorite")]
        public bool Favorite { get; set; }

        [XmlArray("Tags")]
        [XmlArrayItem("Tag")]
        public List<string> Tag { get; set; }
    }

    [XmlRoot("List", Namespace = "")]
    [XmlInclude(typeof(ProjectDto))]
    public class ProjectDtoCollection
    {
        public ProjectDtoCollection() { Items = new List<ProjectDto>(); }

        [XmlElement("Project")]
        public List<ProjectDto> Items { get; set; }
    }
}
