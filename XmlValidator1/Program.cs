using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.IO;

namespace XmlValidator1
{
    class Program
    {
        static int errorCounter = 0;

        static void Main(string[] args)
        {


            // Set the validation settings.
            XmlReaderSettings settings = new XmlReaderSettings();

            settings.XmlResolver = new XmlUrlResolver();

            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
            settings.IgnoreWhitespace = true;

            // Create the XmlReader object.
            XmlReader reader = XmlReader.Create("Engine.xml", settings);

            // Parse the file.
            while (reader.Read())
            {
                //System.Console.WriteLine("Node Type:{0} | Name:{1} | Value ~ {2} ", reader.NodeType, reader.Name, reader.Value.ToString());
                //if (reader.AttributeCount > 0)
                   // System.Console.WriteLine("\tAtt:" + reader.GetAttribute(0).ToString());
            }
            Console.WriteLine("end of validation.");
            Console.WriteLine("total error(s):" + errorCounter.ToString() + ".");
            Console.Read();
        }

        // Display any validation errors.
        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (e.Severity == XmlSeverityType.Warning)
                Console.WriteLine("Warning: Matching schema not found.  No validation occurred." + e.Message);
            else // Error
                Console.WriteLine("\tValidation error: " + e.Message);
            errorCounter++;
            System.Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
