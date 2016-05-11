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

using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Management.Storage.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Newtonsoft.Json;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Common
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

        public static string DiagnosticsConfigurationElemStr = "DiagnosticsConfiguration";
        public static string PublicConfigElemStr = "PublicConfig";
        public static string PrivateConfigElemStr = "PrivateConfig";
        public static string StorageAccountElemStr = "StorageAccount";
        public static string PrivConfNameAttr = "name";
        public static string PrivConfKeyAttr = "key";
        public static string PrivConfEndpointAttr = "endpoint";

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
                throw new ArgumentException(Properties.Resources.DiagnosticsExtensionXmlConfigNoWadCfgStartTag);
            }

            int wadCfgEndIndex = config.IndexOf("</WadCfg>");
            if (wadCfgEndIndex == -1)
            {
                throw new ArgumentException(Properties.Resources.DiagnosticsExtensionXmlConfigNoWadCfgEndTag);
            }

            if (wadCfgEndIndex <= wadCfgBeginIndex)
            {
                throw new ArgumentException(Properties.Resources.DiagnosticsExtensionXmlConfigWadCfgTagNotMatch);
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
            return JsonConvert.SerializeObject(GetPrivateDiagnosticsConfiguration(storageAccountName, storageKey, endpoint));
        }

        public static Hashtable GetPrivateDiagnosticsConfiguration(string storageAccountName, string storageKey, string endpoint)
        {
            var hashTable = new Hashtable();
            hashTable.Add(StorageAccountNameTag, storageAccountName);
            hashTable.Add(StorageAccountKeyTag, storageKey);
            hashTable.Add(StorageAccountEndPointTag, endpoint);
            return hashTable;
        }

        public static XElement GetPublicConfigElement(string configurationPath)
        {
            XElement publicConfig = null;

            if (!string.IsNullOrEmpty(configurationPath))
            {
                var xmlConfig = XElement.Load(configurationPath);

                if (xmlConfig.Name.LocalName == PublicConfigElemStr)
                {
                    // The passed in config file is public config
                    publicConfig = xmlConfig;
                }
                else if (xmlConfig.Name.LocalName == DiagnosticsConfigurationElemStr)
                {
                    // The passed in config file is .wadcfgx file
                    publicConfig = xmlConfig.Elements().FirstOrDefault(ele => ele.Name.LocalName == PublicConfigElemStr);
                }
            }

            return publicConfig;
        }

        public static string GetStorageAccountInfoFromPrivateConfig(string configurationPath, string attributeName)
        {
            string value = null;

            if (!string.IsNullOrEmpty(configurationPath))
            {
                var xmlConfig = XElement.Load(configurationPath);

                if (xmlConfig.Name.LocalName == DiagnosticsConfigurationElemStr)
                {
                    var privateConfigElem = xmlConfig.Elements().FirstOrDefault(ele => ele.Name.LocalName == PrivateConfigElemStr);
                    var storageAccountElem = privateConfigElem == null ? null : privateConfigElem.Elements().FirstOrDefault(ele => ele.Name.LocalName == StorageAccountElemStr);
                    var attribute = storageAccountElem == null ? null : storageAccountElem.Attributes().FirstOrDefault(a => string.Equals(a.Name.LocalName, attributeName));
                    value = attribute == null ? null : attribute.Value;
                }
            }

            return value;
        }

        /// <summary>
        /// Initialize the storage account name if it's not specified.
        /// It can be defined in multiple places, we only take the one with higher precedence. And the precedence is:
        /// 1. The one get from StorageContext parameter
        /// 2. The one parsed from the diagnostics configuration file
        /// </summary>
        public static string InitializeStorageAccountName(AzureStorageContext storageContext = null, string configurationPath = null)
        {
            string storageAccountName = null;

            if (storageContext != null)
            {
                storageAccountName = storageContext.StorageAccountName;
            }
            else if (!string.IsNullOrEmpty(configurationPath))
            {
                var publicConfig = GetPublicConfigElement(configurationPath);
                var storageNode = publicConfig == null ? null : publicConfig.Elements().FirstOrDefault(ele => ele.Name.LocalName == StorageAccountElemStr);
                storageAccountName = storageNode == null ? null : storageNode.Value;
            }

            return storageAccountName;
        }

        /// <summary>
        /// Initialize the storage account key if it's not specified.
        /// It can be defined in multiple places, we only take the one with higher precedence. And the precedence is:
        /// 1. The one we try to resolve within current subscription
        /// 2. The one defined in PrivateConfig in the configuration file
        /// </summary>
        public static string InitializeStorageAccountKey(StorageManagementClient storageClient, string storageAccountName = null, string configurationPath = null)
        {
            string storageAccountKey = null;
            StorageAccount storageAccount = null;

            try
            {
                storageAccount = storageClient.StorageAccounts.Get(storageAccountName).StorageAccount;
            }
            catch
            {
            }

            if (storageAccount != null)
            {
                // Help user retrieve the storage account key
                var keys = storageClient.StorageAccounts.GetKeys(storageAccount.Name);
                if (keys != null)
                {
                    storageAccountKey = !string.IsNullOrEmpty(keys.PrimaryKey) ? keys.PrimaryKey : keys.SecondaryKey;
                }
            }
            else
            {
                // Use the one defined in PrivateConfig
                storageAccountKey = GetStorageAccountInfoFromPrivateConfig(configurationPath, PrivConfKeyAttr);
            }

            return storageAccountKey;
        }

        /// <summary>
        /// Initialize the storage account endpoint if it's not specified.
        /// We can get the value from multiple places, we only take the one with higher precedence. And the precedence is:
        /// 1. The one get from StorageContext parameter
        /// 2. The one get from the storage account
        /// 3. The one get from PrivateConfig element in config file
        /// 4. The one get from current Azure Environment
        /// </summary>
        public static string InitializeStorageAccountEndpoint(string storageAccountName, string storageAccountKey, StorageManagementClient storageClient,
            AzureStorageContext storageContext = null, string configurationPath = null, AzureContext defaultContext = null)
        {
            string storageAccountEndpoint = null;

            if (storageContext != null)
            {
                // Get value from StorageContext
                storageAccountEndpoint = GetEndpointFromStorageContext(storageContext);
            }
            else
            {
                // Try get the storage account from current subscription
                StorageAccount storageAccount = null;

                try
                {
                    storageAccount = storageClient.StorageAccounts.Get(storageAccountName).StorageAccount;
                }
                catch
                {
                }

                if (storageAccount != null && storageAccount.Properties.Endpoints.Count >= 4)
                {
                    // Get value from StorageAccount
                    var endpoints = storageAccount.Properties.Endpoints;
                    var context = CreateStorageContext(endpoints[0], endpoints[1], endpoints[2], endpoints[3], storageAccountName, storageAccountKey);
                    storageAccountEndpoint = GetEndpointFromStorageContext(context);
                }
                else if (!string.IsNullOrEmpty(GetStorageAccountInfoFromPrivateConfig(configurationPath, PrivConfEndpointAttr)))
                {
                    // Get value from PrivateConfig
                    storageAccountEndpoint = GetStorageAccountInfoFromPrivateConfig(configurationPath, PrivConfEndpointAttr);
                }
                else if (defaultContext != null && defaultContext.Environment != null)
                {
                    // Get value from default azure environment. Default to use https
                    Uri blobEndpoint = defaultContext.Environment.GetStorageBlobEndpoint(storageAccountName);
                    Uri queueEndpoint = defaultContext.Environment.GetStorageQueueEndpoint(storageAccountName);
                    Uri tableEndpoint = defaultContext.Environment.GetStorageTableEndpoint(storageAccountName);
                    Uri fileEndpoint = defaultContext.Environment.GetStorageFileEndpoint(storageAccountName);
                    var context = CreateStorageContext(blobEndpoint, queueEndpoint, tableEndpoint, fileEndpoint, storageAccountName, storageAccountKey);
                    storageAccountEndpoint = GetEndpointFromStorageContext(context);
                }
            }

            return storageAccountEndpoint;
        }

        private static AzureStorageContext CreateStorageContext(Uri blobEndpoint, Uri queueEndpoint, Uri tableEndpoint, Uri fileEndpoint,
            string storageAccountName, string storageAccountKey)
        {
            var credentials = new StorageCredentials(storageAccountName, storageAccountKey);
            var cloudStorageAccount = new CloudStorageAccount(credentials, blobEndpoint, queueEndpoint, tableEndpoint, fileEndpoint);
            return new AzureStorageContext(cloudStorageAccount);
        }

        private static string GetEndpointFromStorageContext(AzureStorageContext context)
        {
            var scheme = context.BlobEndPoint.StartsWith("https://", StringComparison.OrdinalIgnoreCase) ? "https://" : "http://";
            return scheme + context.EndPointSuffix;
        }
    }
}
