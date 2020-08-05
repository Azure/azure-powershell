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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.ServiceFabric;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedCluster", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveServiceFabricManagedCluster : ServiceFabricCommonCmdletBase
    {

        #region Params

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

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: this.ResourceGroupName, action: string.Format("Remove cluster: {0} in resouce group {1}.", this.Name, this.ResourceGroupName)))
            {
                try
                {
                    var beginRequestResponse = this.SFRPClient.ManagedClusters.BeginDeleteWithHttpMessagesAsync(
                                                    this.ResourceGroupName,
                                                    this.Name).GetAwaiter().GetResult();

                    this.PollLongRunningOperation(beginRequestResponse);

                    if (this.PassThru)
                    {
                        WriteObject(true);
                    }
                }
                catch (Exception ex)
                {
                    PrintSdkExceptionDetail(ex);
                    throw;
                }
            }
        }
    }
}
