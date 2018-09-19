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
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.BaseCommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations
{
    internal class AzureHDInsightStorageHandler : IAzureHDInsightStorageHandler
    {
        private const string ProductionStorageAccountEndpointUriTemplate = "http://{0}.blob.core.windows.net/";
        private const string WabsProtocol = "wasb";
        private readonly WabStorageAccountConfiguration storageAccountConfiguration;

        public AzureHDInsightStorageHandler(WabStorageAccountConfiguration storageAccountConfiguration)
        {
            this.storageAccountConfiguration = storageAccountConfiguration;
        }

        public Uri GetStoragePath(Uri httpPath)
        {
            return GetWasbStoragePath(httpPath);
        }

        public void UploadFile(Uri path, Stream contents)
        {
            CloudBlobClient client = this.GetStorageClient();
            CloudBlobContainer container = client.GetContainerReference(this.storageAccountConfiguration.Container);
            CloudBlockBlob blobReference = container.GetBlockBlobReference(path.OriginalString);
            blobReference.UploadFromStream(contents);
        }

        internal static Uri GetWasbStoragePath(Uri httpPath)
        {
            httpPath.ArgumentNotNull("httpPath");

            if (
                !(string.Equals(httpPath.Scheme, Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) ||
                  string.Equals(httpPath.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("httpPath should have a uri scheme of http", "httpPath");
            }

            int segmentTakeCount = 1;
            string containerName = httpPath.Segments.First();
            if (containerName == "/" && httpPath.Segments.Length > segmentTakeCount)
            {
                containerName = httpPath.Segments.Skip(segmentTakeCount).FirstOrDefault();
                segmentTakeCount++;
            }

            string asvPath = string.Format(
                CultureInfo.InvariantCulture,
                "{0}://{1}@{2}/{3}",
                WabsProtocol,
                containerName.TrimEnd('/'),
                httpPath.Host,
                string.Join(string.Empty, httpPath.Segments.Skip(segmentTakeCount)));
            return new Uri(asvPath);
        }

        private CloudBlobClient GetStorageClient()
        {
            string storageRoot = this.storageAccountConfiguration.Name;
            if (storageRoot.Contains("."))
            {
                storageRoot = string.Format(CultureInfo.InvariantCulture, "http://{0}", storageRoot);
            }
            else
            {
                storageRoot = string.Format(CultureInfo.InvariantCulture, ProductionStorageAccountEndpointUriTemplate, storageRoot);
            }
            var storageCredentials = new StorageCredentials(
                this.storageAccountConfiguration.Name.Split('.').First(), this.storageAccountConfiguration.Key);
            var storageAccountUri = new Uri(storageRoot);
            var blobClient = new CloudBlobClient(storageAccountUri, storageCredentials);
            return blobClient;
        }
    }
}
