﻿// ----------------------------------------------------------------------------------
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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.ServiceFabricManagedClusters;
using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedClusterClientCertificate", DefaultParameterSetName = ClientCertByTpByObj, SupportsShouldProcess = true), OutputType(typeof(PSManagedCluster))]
    public class RemoveAzServiceFabricManagedClusterClientCertificate : ServiceFabricManagedCmdletBase
    {
        protected const string ClientCertByTpByName = "ClientCertByCnTpName";
        protected const string ClientCertByCnByName = "ClientCertByCnByName";
        protected const string ClientCertByTpByObj = "ClientCertByTpByObj";
        protected const string ClientCertByCnByObj = "ClientCertByCnByObj";

        #region Params

        #region Common params

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ClientCertByTpByName,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ClientCertByCnByName,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ClientCertByTpByName,
            HelpMessage = "Specify the name of the cluster.")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ClientCertByCnByName,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter(Constants.ManagedClustersFullType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = ClientCertByTpByObj,
            HelpMessage = "Managed cluster resource")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = ClientCertByCnByObj,
            HelpMessage = "Managed cluster resource")]
        [ValidateNotNull]
        public PSManagedCluster InputObject { get; set; }

        #endregion

        [Parameter(Mandatory = true, ParameterSetName = ClientCertByTpByName,
                   HelpMessage = "Client certificate thumbprint.")]
        [Parameter(Mandatory = true, ParameterSetName = ClientCertByTpByObj,
                   HelpMessage = "Client certificate thumbprint.")]
        [ValidateNotNullOrEmpty()]
        public string Thumbprint { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ClientCertByCnByName,
                   HelpMessage = "Client certificate common name.")]
        [Parameter(Mandatory = true, ParameterSetName = ClientCertByCnByObj,
                   HelpMessage = "Client certificate common name.")]
        [ValidateNotNullOrEmpty()]
        public string CommonName { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background and return a Job to track progress.")]
        public SwitchParameter AsJob { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            this.SetParams();
            if (ShouldProcess(target: this.Name, action: string.Format("Remove client cert '{0}' from cluster {1}",
                (ParameterSetName == ClientCertByTpByName || ParameterSetName == ClientCertByTpByObj) ? this.Thumbprint : this.CommonName, this.Name)))
            {
                try
                {
                    ManagedCluster updatedCluster = this.GetClusterWithRemovedClientCert();
                    var beginRequestResponse = this.SfrpMcClient.ManagedClusters.BeginCreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.Name, updatedCluster)
                        .GetAwaiter().GetResult();

                    var cluster = this.PollLongRunningOperation(beginRequestResponse);

                    if (this.PassThru)
                    {
                        WriteObject(true);
                    }
                    else
                    {
                        WriteObject(new PSManagedCluster(cluster), false);
                    }
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
            ManagedCluster currentCluster = this.SfrpMcClient.ManagedClusters.Get(this.ResourceGroupName, this.Name);

            if (currentCluster.Clients == null || currentCluster.Clients.Count() == 0)
            {
                throw new InvalidOperationException("The cluster has no client certifices registered.");
            }

            int initialSize = currentCluster.Clients.Count();
            switch (ParameterSetName)
            {
                case ClientCertByTpByName:
                case ClientCertByTpByObj:
                    currentCluster.Clients = currentCluster.Clients.Where(cert => !string.Equals(cert.Thumbprint, this.Thumbprint, StringComparison.OrdinalIgnoreCase)).ToList();
                    break;
                case ClientCertByCnByName:
                case ClientCertByCnByObj:
                    currentCluster.Clients = currentCluster.Clients.Where(cert => !string.Equals(cert.CommonName, this.CommonName, StringComparison.OrdinalIgnoreCase)).ToList();
                    break;
                default:
                    throw new ArgumentException("Invalid parameter set", ParameterSetName);
            }

            if(initialSize == currentCluster.Clients.Count())
            {
                throw new InvalidOperationException(string.Format(
                    "Client certificate '{0}' is not registered on the cluster.",
                    (ParameterSetName == ClientCertByCnByObj || ParameterSetName == ClientCertByTpByObj) ? this.Thumbprint : this.CommonName));
            }

            return currentCluster;
        }

        private void SetParams()
        {
            switch (ParameterSetName)
            {
                case ClientCertByCnByObj:
                case ClientCertByTpByObj:
                    if (string.IsNullOrEmpty(this.InputObject?.Id))
                    {
                        throw new ArgumentException("ResourceId is null.");
                    }

                    SetParametersByResourceId(this.InputObject.Id);
                    break;

            }
        }

        private void SetParametersByResourceId(string resourceId)
        {
            this.GetParametersByResourceId(resourceId, Constants.ManagedClusterProvider, out string resourceGroup, out string resourceName);
            this.ResourceGroupName = resourceGroup;
            this.Name = resourceName;
        }
    }
}
