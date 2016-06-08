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
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Management.HDInsight.Logging;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.BaseInterfaces
{
    internal interface IAzureHDInsightCommonCommandBase
    {
        /// <summary>
        ///     Gets or sets the certificate File to be used.
        /// </summary>
        X509Certificate2 Certificate { get; set; }

        /// <summary>
        ///     Gets or sets the cloud service name to use (if provided).
        /// </summary>
        string HostedService { get; set; }

        /// <summary>
        ///     Gets or sets the Endpoint URI to use (if provided).
        /// </summary>
        Uri Endpoint { get; set; }

        /// <summary>
        ///     Gets or sets rule for client SSL errors.
        /// </summary>
        bool IgnoreSslErrors { get; set; }

        /// <summary>
        ///     Gets or sets a logger to write log messages to.
        /// </summary>
        ILogWriter Logger { get; set; }

        /// <summary>
        ///     Gets or sets the Azure Subscription to be used.
        /// </summary>
        string Subscription { get; set; }
    }
}
