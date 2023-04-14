using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace Microsoft.Azure.Commands.CodeSigning.Helpers
{
    internal static class XmlUtil
    {
        /// <summary>
        /// Creates an <see cref="XDocument"/> from an XML string per SDL 7.0 guidance.
        /// </summary>
        public static XDocument SafeLoadXDocument(byte[] xmlFile)
        {
            var settings = new XmlReaderSettings()
            {
                DtdProcessing = DtdProcessing.Prohibit,
                IgnoreProcessingInstructions = true,
                XmlResolver = null
            };

            using (var reader = XmlReader.Create(new MemoryStream(xmlFile), settings))
            {
                return XDocument.Load(reader);
            }
        }

        /// <summary>
        /// Creates an <see cref="XmlDocument"/> from an XML string per SDL 7.0 guidance.
        /// </summary>
        public static XmlDocument SafeLoadXmlDocument(string xml)
        {
            XmlDocument document = new XmlDocument()
            {
                XmlResolver = null
            };

            var settings = new XmlReaderSettings()
            {
                DtdProcessing = DtdProcessing.Prohibit,
                IgnoreProcessingInstructions = true,
                XmlResolver = null
            };

            using (var reader = XmlReader.Create(new StringReader(xml), settings))
            {
                document.Load(reader);
            }

            return document;
        }
    }
}
