﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.EventHub.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.EventHub
{
    /// <summary>
    /// 'Get-AzEventHubCluster' Cmdlet gives the details of a / List of Cluster(s)
    /// <para> If Cluster name provided, a single Cluster detials will be returned</para>
    /// <para> If Cluster name not provided, list of Cluster will be returned</para>
    /// </summary>
    [GenericBreakingChange(message: BreakingChangeNotification + "\n- Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.ICluster'", deprecateByVersion: DeprecateByVersion, changeInEfectByDate: ChangeInEffectByDate)]
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubCluster"), OutputType(typeof(PSEventHubAttributes))]
    public class GetAzureRmEventHubCluster : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [CmdletParameterBreakingChange("Name", ChangeDescription = "The alias of this parameter would change to 'ClusterName'")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Cluster Name")]
        [Alias(AliasEventHubName)]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {

                if (this.IsParameterBound(c => c.Name))
                {
                    // Get a Cluster
                    Cluster cluster = UtilityClient.GetEventHubCluster(ResourceGroupName, Name);
                    WriteObject(new PSEventHubClusterAttributes(cluster));
                }
                else
                {
                    // Get all Clusters
                    IEnumerable<PSEventHubClusterAttributes> clusterList = UtilityClient.ListEventHubCluster(ResourceGroupName);
                    WriteObject(clusterList.ToList(), true);
                }
            }
            catch (Management.EventHub.Models.ErrorResponseException ex)
            {
                WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
            }
        }
    }
}
