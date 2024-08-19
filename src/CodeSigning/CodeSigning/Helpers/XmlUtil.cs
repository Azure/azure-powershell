// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.IO;
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
