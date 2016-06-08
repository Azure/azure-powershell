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
using System.Data.Services.Client;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common
{
    /// <summary>
    /// Connection-level utilities.
    /// </summary>
    public static class DataConnectionUtility
    {
        /// <summary>
        /// An array of all relevant entity names in the metadata document.
        /// </summary>
        private static readonly string[] RelevantEntities =
        {
            "Server",
            "Database"
        };

        /// <summary>
        /// An array of all relevant associations in the metadata document.
        /// </summary>
        private static readonly string[] RelevantAssociations =
        {
            "Server_Databases_Database_Server"
        };

        /// <summary>
        /// Gets the default management service <see cref="Uri"/> for the given manageUri.
        /// </summary>
        /// <param name="manageUrl">The host <see cref="Uri"/></param>
        /// <returns>The web service <see cref="Uri"/></returns>
        public static Uri GetManagementServiceUri(Uri manageUrl)
        {
            if (manageUrl == null)
            {
                throw new ArgumentNullException("manageUrl");
            }

            return GetWebServiceUri(manageUrl, DataServiceConstants.ManagementServiceUri);
        }

        /// <summary>
        /// Gets the web service <see cref="Uri"/> for the given manageUri and the relative
        /// service Uri.
        /// </summary>
        /// <param name="manageUrl">The host <see cref="Uri"/></param>
        /// <param name="relativeServiceUri">The service name</param>
        /// <returns>The web service <see cref="Uri"/></returns>
        public static Uri GetWebServiceUri(Uri manageUrl, string relativeServiceUri)
        {
            if (manageUrl == null)
            {
                throw new ArgumentNullException("manageUrl");
            }

            if (string.IsNullOrEmpty(relativeServiceUri))
            {
                throw new ArgumentException("relativeServiceUri");
            }

            return new Uri(manageUrl, relativeServiceUri);
        }

        /// <summary>
        /// Gets the access token service <see cref="Uri"/> for the given host <see cref="Uri"/>.
        /// </summary>
        /// <param name="managementServiceUri">The management service <see cref="System.Uri"/>.</param>
        /// <returns>The acceess token <see cref="Uri"/> for the given management service.</returns>
        public static Uri GetAccessTokenUri(Uri managementServiceUri)
        {
            if (managementServiceUri == null)
            {
                throw new ArgumentNullException("managementServiceUri");
            }

            return new Uri(managementServiceUri, DataServiceConstants.AccessTokenOperation);
        }

        /// <summary>
        /// Get the metadata for the given data service context.
        /// </summary>
        /// <param name="context">The data service context.</param>
        /// <param name="enhanceRequest">The action delegate to enhance the request prior to sending.</param>
        /// <typeparam name="T">The <see cref="DataServiceContext"/> type.</typeparam>
        /// <returns>The metadata <see cref="XDocument"/>.</returns>
        public static XDocument GetMetadata<T>(T context, Action<T, HttpWebRequest> enhanceRequest)
            where T : DataServiceContext
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            HttpWebRequest request = HttpWebRequest.Create(context.GetMetadataUri()) as HttpWebRequest;
            request.Method = "GET";

            // Enhance the request such as adding an auth token or certificate to the header
            // Usually this is the same event hook added for processing all WCF requests
            if (enhanceRequest != null)
            {
                enhanceRequest(context, request);
            }

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                XDocument xmlDocument = XDocument.Load(reader);
                return xmlDocument;
            }
        }

        /// <summary>
        /// Gets the hash for the metadata document.
        /// </summary>
        /// <param name="metadata">The metadata document to calculate hash for.</param>
        /// <returns>The hex string representation of the metadata hash.</returns>
        public static string GetDocumentHash(XDocument metadata)
        {
            string metadataString = metadata.ToString(SaveOptions.DisableFormatting);

            using (SHA1 sha = new SHA1CryptoServiceProvider())
            {
                byte[] result = sha.ComputeHash(Encoding.UTF8.GetBytes(metadataString));
                return BitConverter.ToString(result).Replace("-", string.Empty);
            }
        }

        /// <summary>
        /// Filter a given metadata document to contain only relevant entities.
        /// </summary>
        /// <param name="metadata">The metadata document to calculate hash for.</param>
        /// <returns>A filtered document containing only relevant entities.</returns>
        public static XDocument FilterMetadataDocument(XDocument metadata)
        {
            // Clone the input metadata document.
            XDocument filteredDoc = XDocument.Parse(metadata.ToString());

            // Filter out the EntityContainer.
            XElement entityContainer = filteredDoc.Root.Descendants()
                .Where(n => n.Name.LocalName == "EntityContainer")
                .SingleOrDefault();
            if (entityContainer != null)
            {
                entityContainer.Remove();
            }

            // Remove any entities that's not relevant to the Cmdlets.
            XElement[] entitiesToRemove = filteredDoc.Root.Descendants()
                .Where(n => n.Name.LocalName == "EntityType")
                .Where(n => !RelevantEntities.Contains(n.Attribute("Name").Value))
                .ToArray();
            XElement[] associationsToRemove = filteredDoc.Root.Descendants()
                .Where(n => n.Name.LocalName == "Association")
                .Where(n => !RelevantAssociations.Contains(n.Attribute("Name").Value))
                .ToArray();
            foreach (XElement elementToRemove in entitiesToRemove.Concat(associationsToRemove))
            {
                elementToRemove.Remove();
            }

            return filteredDoc;
        }
    }
}
