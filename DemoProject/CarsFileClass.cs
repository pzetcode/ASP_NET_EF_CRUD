using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace DemoProject
{
    [XmlRoot("car")]
    public class Car
    {
        [XmlAttribute("factory")]
        private string _factory;
        [XmlAttribute("model")]
        private string _model;
        [XmlAttribute("warranty")]
        private int _warranty;
        [XmlAttribute("modelyear")]
        DateTime _modelyear;

        public Car() { }
        public Car(string factory, string model, int warranty, DateTime modelyear)
        {
            _factory = factory;
            _model = model;
            _warranty = warranty;
            _modelyear = modelyear;
        }

        public string Factory { get => _factory; set => _factory = value; }
        public string Model { get => _model; set => _model = value; }
        public int Warranty { get => _warranty; set => _warranty = value; }
        public DateTime Modelyear { get => _modelyear; set => _modelyear = value; }
    }
}