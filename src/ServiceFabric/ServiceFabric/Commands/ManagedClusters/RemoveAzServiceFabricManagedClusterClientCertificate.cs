// ----------------------------------------------------------------------------------
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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Sku = Microsoft.Azure.Management.ServiceFabric.Models.Sku;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedClusterClientCertificate", SupportsShouldProcess = true), OutputType(typeof(PSManagedCluster))]
    public class RemoveAzServiceFabricManagedClusterClientCertificate : ServiceFabricCommonCmdletBase
    {
        protected const string ClientCertByTp = "ClientCertByTp";
        protected const string ClientCertByCn = "ClientCertByCn";

        #region Params

        #region Common params

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter(Constants.ManagedClustersFullType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterName")]
        public string Name { get; set; }

        #endregion

        [Parameter(Mandatory = true, ParameterSetName = ClientCertByTp,
                   HelpMessage = "Client certificate thumbprint.")]
        [ValidateNotNullOrEmpty()]
        public string Thumbprint { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ClientCertByCn,
                   HelpMessage = "Client certificate common name.")]
        [ValidateNotNullOrEmpty()]
        public string CommonName { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: this.Name, action: string.Format("Remove client cert '{0}' from cluster {1}", ParameterSetName == ClientCertByTp ? this.Thumbprint : this.CommonName, this.Name)))
            {
                try
                {
                    ManagedCluster updatedCluster = this.GetClusterWithRemovedClientCert();
                    var beginRequestResponse = this.SFRPClient.ManagedClusters.BeginCreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.Name, updatedCluster)
                        .GetAwaiter().GetResult();

                    var cluster = this.PollLongRunningOperation(beginRequestResponse);

                    WriteObject(new PSManagedCluster(cluster), false);
                }
                catch (Exception ex)
                {
                    PrintSdkExceptionDetail(ex);
                    throw;
                }
            }
        }

        private ManagedCluster GetClusterWithRemovedClientCert()
        {
            ManagedCluster currentCluster = this.SFRPClient.ManagedClusters.Get(this.ResourceGroupName, this.Name);

            if (currentCluster.Clients == null || currentCluster.Clients.Count() == 0)
            {
                throw new InvalidOperationException("The cluster has no client certifices registered.");
            }

            int initialSize = currentCluster.Clients.Count();
            switch (ParameterSetName)
            {
                case ClientCertByTp:
                    currentCluster.Clients = currentCluster.Clients.Where(cert => !string.Equals(cert.Thumbprint, this.Thumbprint, StringComparison.OrdinalIgnoreCase)).ToList();
                    break;
                case ClientCertByCn:
                    currentCluster.Clients = currentCluster.Clients.Where(cert => !string.Equals(cert.CommonName, this.CommonName, StringComparison.OrdinalIgnoreCase)).ToList();
                    break;
                default:
                    throw new ArgumentException("Invalid parameter set {0}", ParameterSetName);
            }

            if(initialSize == currentCluster.Clients.Count())
            {
                throw new InvalidOperationException(string.Format(
                    "Client certificate '{0}' is not registered on the cluster.",
                    ParameterSetName == ClientCertByTp ? this.Thumbprint : this.CommonName));
            }

            return currentCluster;
        }
    }
}
