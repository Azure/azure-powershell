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
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations
{
    /// <summary>
    ///     This type generates the gateway Uri for an AzureHDInsight cluster given its DNS Name or Endpoint uri.
    /// </summary>
    internal static class GatewayUriResolver
    {
        private const int AzureGatewayUriPortNumberVersion15AndBelow = 563;
        private const int AzureGatewayUriPortNumberVersion16AndAbove = 443;
        private const string AzureWellKnownClusterSuffix = ".azurehdinsight.net";
        private static readonly Version unknownVersion = new Version(0, 0, 0, 0);
        private static readonly Version version20 = new Version(2, 0, 0, 0);

        /// <summary>
        ///     Gets the Gateway Uri for Http Services accessible on an Azure HDInsight cluster.
        /// </summary>
        /// <param name="clusterDnsNameOrEndpoint">The DNS Name or Endpoint uri of an Azure HDInsight cluster.</param>
        /// <param name="version">The version of the HDInsight cluster.</param>
        /// <returns>The Gateway Uri for Http Services accessible on an Azure HDInsight cluster.</returns>
        public static Uri GetGatewayUri(string clusterDnsNameOrEndpoint, Version version)
        {
            clusterDnsNameOrEndpoint.ArgumentNotNullOrEmpty("clusterDnsNameOrUri");
            string computedEndpoint;
            string originalScheme = string.Empty;
            int index = clusterDnsNameOrEndpoint.IndexOf("://", StringComparison.OrdinalIgnoreCase);
            if (index >= 0)
            {
                computedEndpoint = "http://" + clusterDnsNameOrEndpoint.Substring(index + 3);
                originalScheme = clusterDnsNameOrEndpoint.Substring(0, index);
            }
            else
            {
                computedEndpoint = "http://" + clusterDnsNameOrEndpoint;
                originalScheme = "http";
            }

            Uri tempUri;

            if (!Uri.TryCreate(computedEndpoint, UriKind.Absolute, out tempUri))
            {
                throw new NotSupportedException("Unable to compute Uri for given endpoint");
            }

            if (tempUri.Port == 80)
            {
                if (tempUri.Host == "localhost")
                {
                    return new Uri(originalScheme + "://" + tempUri.Host + ":50111");
                }

                tempUri = new Uri("https://" + tempUri.Host);
            }

            if (tempUri.Host == "localhost")
            {
                tempUri = new Uri(originalScheme + "://" + tempUri.Host + ":" + tempUri.Port);
                return tempUri;
            }

            if (tempUri.Scheme != "https")
            {
                tempUri = new Uri("https://" + tempUri.Host + ":" + tempUri.Port);
            }

            if (!tempUri.Host.Contains("."))
            {
                tempUri = new Uri(tempUri.Scheme + "://" + tempUri.Host + AzureWellKnownClusterSuffix + ":" + tempUri.Port);
            }

            if (version > unknownVersion)
            {
                int gatewayPort = GetGatewayPort(version);
                tempUri = new Uri(tempUri.Scheme + "://" + tempUri.Host + ":" + gatewayPort);
            }

            return tempUri;
        }

        /// <summary>
        ///     Gets the Gateway Uri for Http Services accessible on an Azure HDInsight cluster.
        /// </summary>
        /// <param name="clusterDnsNameOrEndpoint">The DNS Name or Endpoint uri of an Azure HDInsight cluster.</param>
        /// <returns>The Gateway Uri for Http Services accessible on an Azure HDInsight cluster.</returns>
        public static Uri GetGatewayUri(string clusterDnsNameOrEndpoint)
        {
            clusterDnsNameOrEndpoint.ArgumentNotNullOrEmpty("clusterDnsNameOrUri");
            return GetGatewayUri(clusterDnsNameOrEndpoint, unknownVersion);
        }

        private static int GetGatewayPort(Version version)
        {
            if (version.Major == version20.Major && version.Minor == version20.Minor)
            {
                return AzureGatewayUriPortNumberVersion15AndBelow;
            }

            return AzureGatewayUriPortNumberVersion16AndAbove;
        }
    }
}
