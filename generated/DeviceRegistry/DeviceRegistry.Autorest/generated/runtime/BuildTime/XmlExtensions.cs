/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime.PowerShell
{
    internal static class XmlExtensions
    {
        public static string ToXmlString<T>(this T inputObject, bool excludeDeclaration = false)
        {
            var serializer = new XmlSerializer(typeof(T));
            //https://stackoverflow.com/a/760290/294804
            //https://stackoverflow.com/a/3732234/294804
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var xmlSettings = new XmlWriterSettings { OmitXmlDeclaration = excludeDeclaration, Indent = true };
            using (var stringWriter = new StringWriter())
            using (var xmlWriter = XmlWriter.Create(stringWriter, xmlSettings))
            {
                serializer.Serialize(xmlWriter, inputObject, namespaces);
                return stringWriter.ToString();
            }
        }
    }
}
