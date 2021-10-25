using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace SoundsProducer.Utils
{
    class Xml_Reader : XmlDocument
    {
        private String file; //File associated with this XML class instance

        // Constructor to read XMl files
        public Xml_Reader(String filePath)
        {
            this.file = filePath;
            try
            {
                Load(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                String msg = "File load error, check if it have correct format.";
                String tile = "Warning";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(msg, tile, buttons);
            }

        }

        // Returns all the content of the file as a string
        public String GetAllXML(bool formatted)
        {
            if (formatted)
            {
                // Create MemoryStream to store all XML data
                MemoryStream ms = new MemoryStream();
                try
                {
                    // Save data in MemoryStream
                    Save(ms);
                    // Flush and repositioned at startup
                    ms.Flush();
                    ms.Position = 0;
                    // Create StreamReader using the MemoryStream instance
                    StreamReader sReader = new StreamReader(ms);
                    return sReader.ReadToEnd();
                }
                finally
                {
                    // Close MemoryStreamk
                    ms.Close();
                }
            }
            // Returns de XML data in one line as string
            return DocumentElement.OuterXml;
        }

        // Returns a string list of values ​​of a specific node name
        public List<String> GetNodeValues(String nodeName)
        {
            List<String> values = new List<String>();
            XmlNodeList nodeList = GetElementsByTagName(nodeName);

            foreach (XmlNode node in nodeList)
            {
                values.Add(node.InnerText);
            }

            return values;
        }

        // Returns a string list of attributes values from a specific node name
        public List<String> GetNodeAttributesValues(String nodeName)
        {
            List<String> values = new List<String>();
            XmlNodeList nodeList = GetElementsByTagName(nodeName);
            foreach (XmlNode node in nodeList)
            {
                XmlAttributeCollection xmlAttributes = node.Attributes;
                if (xmlAttributes != null)
                {
                    for (int i = 0; i < xmlAttributes.Count; i++)
                    {
                        values.Add(xmlAttributes[i].Value);
                    }
                }
            }

            return values;
        }

        // Returns a lisf of string list of attributes values from a specific node name
        public List<List<String>> GetNodeAttributesValuesList(String nodeName)
        {
            List<List<String>> values = new List<List<String>>();
            XmlNodeList nodeList = GetElementsByTagName(nodeName);
            foreach (XmlNode node in nodeList)
            {
                List<String> attributesValues = new List<String>();
                XmlAttributeCollection xmlAttributes = node.Attributes;
                if (xmlAttributes != null)
                {
                    for (int i = 0; i < xmlAttributes.Count; i++)
                    {
                        attributesValues.Add(xmlAttributes[i].Value);
                    }
                }
                values.Add(attributesValues);
            }

            return values;
        }

        // Returns a string list of values ​​of a specific node attribute name
        public List<String> GetNodeAttributeValues(String nodeName, String attributeName)
        {
            List<String> values = new List<String>();
            XmlNodeList nodeList = GetElementsByTagName(nodeName);

            foreach (XmlNode node in nodeList)
            {
                XmlAttributeCollection xmlAttributes = node.Attributes;
                if (xmlAttributes != null)
                {
                    XmlAttribute xmlAttribute = xmlAttributes[attributeName];
                    if (xmlAttribute != null)
                    {
                        values.Add(xmlAttribute.Value);
                    }
                }
            }

            return values;
        }

        // Returns file path as string
        public String GetXmlFilePath()
        {
            return file;
        }

    }
}
