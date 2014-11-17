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
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions
{
    internal static class PsCmdletExtensions
    {
        public static AzureHDInsightClusterConnection AssertValidConnection(this PSCmdlet cmdlet)
        {
            IAzureHDInsightConnectionSessionManager sessionManager =
                ServiceLocator.Instance.Locate<IAzureHDInsightConnectionSessionManagerFactory>().Create(cmdlet.SessionState);
            AzureHDInsightClusterConnection currentConnection = sessionManager.GetCurrentCluster();
            if (currentConnection == null)
            {
                cmdlet.ThrowTerminatingError(
                    new ErrorRecord(
                        new NotSupportedException("Please connect to a valid Azure HDInsight cluster before calling this cmdlet."),
                        "1024",
                        ErrorCategory.ConnectionError,
                        cmdlet));
            }

            return currentConnection;
        }
    }
}
