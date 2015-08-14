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

using Microsoft.WindowsAzure.Commands.Common.Properties;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Newtonsoft.Json;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public static class DiagnosticsHelper
    {
        private static string XmlNamespace = "http://schemas.microsoft.com/ServiceHosting/2010/10/DiagnosticsConfiguration";
        private static string EncodedXmlCfg = "xmlCfg";
        private static string StorageAccount = "storageAccount";
        private static string Path = "path";
        private static string ExpandResourceDirectory = "expandResourceDirectory";
        private static string LocalResourceDirectory = "localResourceDirectory";
        private static string StorageAccountNameTag = "storageAccountName";
        private static string StorageAccountKeyTag = "storageAccountKey";
        private static string StorageAccountEndPointTag = "storageAccountEndPoint";

        public static string GetJsonSerializedPublicDiagnosticsConfigurationFromFile(string configurationPath,
            string storageAccountName)
        {
            return
                JsonConvert.SerializeObject(
                    DiagnosticsHelper.GetPublicDiagnosticsConfigurationFromFile(configurationPath, storageAccountName));
        }

        public static Hashtable GetPublicDiagnosticsConfigurationFromFile(string configurationPath, string storageAccountName)
        {
            using (StreamReader reader = new StreamReader(configurationPath))
            {
                return GetPublicDiagnosticsConfiguration(reader.ReadToEnd(), storageAccountName);
            }
        }

        public static Hashtable GetPublicDiagnosticsConfiguration(string config, string storageAccountName)
        {
            // find the <WadCfg> element and extract it
            int wadCfgBeginIndex = config.IndexOf("<WadCfg>");
            if (wadCfgBeginIndex == -1)
            {
                throw new ArgumentException(Resources.IaasDiagnosticsBadConfigNoWadCfg);
            }

            int wadCfgEndIndex = config.IndexOf("</WadCfg>");
            if (wadCfgEndIndex == -1)
            {
                throw new ArgumentException(Resources.IaasDiagnosticsBadConfigNoEndWadCfg);
            }

            if (wadCfgEndIndex <= wadCfgBeginIndex)
            {
                throw new ArgumentException(Resources.IaasDiagnosticsBadConfigNoMatchingWadCfg);
            }

            string encodedConfiguration = Convert.ToBase64String(
                Encoding.UTF8.GetBytes(
                    config.Substring(
                        wadCfgBeginIndex, wadCfgEndIndex + "</WadCfg>".Length - wadCfgBeginIndex).ToCharArray()));

            // Now extract the local resource directory element
            XmlDocument doc = new XmlDocument();
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", XmlNamespace);
            doc.LoadXml(config);
            var node = doc.SelectSingleNode("//ns:LocalResourceDirectory", ns);
            string localDirectory = (node != null && node.Attributes != null) ? node.Attributes[Path].Value : null;
            string localDirectoryExpand = (node != null && node.Attributes != null)
                ? node.Attributes["expandEnvironment"].Value
                : null;
            if (localDirectoryExpand == "0")
            {
                localDirectoryExpand = "false";
            }
            if (localDirectoryExpand == "1")
            {
                localDirectoryExpand = "true";
            }

            var hashTable = new Hashtable();
            hashTable.Add(EncodedXmlCfg, encodedConfiguration);
            hashTable.Add(StorageAccount, storageAccountName);
            if (!string.IsNullOrEmpty(localDirectory))
            {
                var localDirectoryHashTable = new Hashtable();
                localDirectoryHashTable.Add(Path, localDirectory);
                localDirectoryHashTable.Add(ExpandResourceDirectory, localDirectoryExpand);
                hashTable.Add(LocalResourceDirectory, localDirectoryHashTable);
            }

            return hashTable;
        }

        public static string GetJsonSerializedPrivateDiagnosticsConfiguration(string storageAccountName,
            string storageKey, string endpoint)
        {
            return JsonConvert.SerializeObject(GetPrivateDiagnosticsConfiguration( storageAccountName, storageKey, endpoint));
        }

        public static Hashtable GetPrivateDiagnosticsConfiguration(string storageAccountName, string storageKey, string endpoint)
        {
            var hashTable = new Hashtable();
            hashTable.Add(StorageAccountNameTag, storageAccountName);
            hashTable.Add(StorageAccountKeyTag, storageKey);
            hashTable.Add(StorageAccountEndPointTag, endpoint);
            return hashTable;
        }
    }
}
