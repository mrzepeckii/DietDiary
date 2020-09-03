using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DietDiary.Domain.Common
{
    public class BaseEntity : AuditableModel
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
        [XmlElement("Category")]
        public int Category { get; set; }

    }
}
