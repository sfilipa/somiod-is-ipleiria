using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SomiodWebApplication
{
    class HandlerSomiod
    {
        public HandlerSomiod(string xmlFile)
        {
            XmlFilePath = xmlFile;
        }

        public HandlerSomiod(string xmlFile, string xsdFile)
        {
            XmlFilePath = xmlFile;
            XsdFilePath = xsdFile;
        }

        public string XmlFilePath { get; set; }
        public string XsdFilePath { get; set; }

        private bool isValid = true;
        private string validationMessage;
        public string ValidationMessage
        {
            get { return validationMessage; }
        }
    }
}