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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.ServiceFabricManagedClusters;
using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedClusterNetworkSecurityRule", DefaultParameterSetName = ByObj, SupportsShouldProcess = true), OutputType(typeof(PSManagedCluster))]
	public class AddAzServiceFabricManagedClusterNetworkSecurityRule : ServiceFabricManagedCmdletBase
	{   
		protected const string ByName = "ByName";
		protected const string ByObj = "ByObj";
		protected const string AnyTrueValue = "*";

		#region Params

		#region Common params

		[Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByName,
			HelpMessage = "Specify the name of the resource group.")]
		[ResourceGroupCompleter]
		[ValidateNotNullOrEmpty()]
		public string ResourceGroupName { get; set; }

		[Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ByName,
			HelpMessage = "Specify the name of the cluster.")]
		[ResourceNameCompleter(Constants.ManagedClustersFullType, nameof(ResourceGroupName))]
		[ValidateNotNullOrEmpty()]
		public string ClusterName { get; set; }

		[Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = ByObj,
			HelpMessage = "Cluster resource")]
		[ValidateNotNull]
		public PSManagedCluster InputObject { get; set; }

		#endregion

		[Parameter(Mandatory = true, HelpMessage = "Gets or sets the network traffic is allowed or denied. Possible values include: Allow, Deny ")]
		public NetworkSecurityAccess Access { get; set; }

		[Parameter(Mandatory = false, HelpMessage = "Gets or sets network security rule description.")]
		public string Description { get; set; }

		[Parameter(Mandatory = true, HelpMessage = "Gets or sets the destination address prefixes. CIDR or destination IP ranges.")]
		public string[] DestinationAddressPrefix { get; set; }

		[Parameter(Mandatory = true, HelpMessage = "Gets or sets the destination port ranges.")]
		public string[] DestinationPortRange { get; set; }

		[Parameter(Mandatory = true, HelpMessage = "Gets or sets network security rule direction. Possible values include: Inbound, Outbound ")]
		public NetworkSecurityDirection Direction { get; set; }

		[Parameter(Mandatory = true, HelpMessage = "network security rule name.")]
		[Alias("NetworkSecurityRuleName")]
		public string Name { get; set; }

		[Parameter(Mandatory = true, HelpMessage = "Gets or sets the priority of the rule. The value can be in the range 1000 to 3000. Values outside this range are reserved for Service Fabric ManagerCluster Resource Provider. The priority number must be unique for each rule in the collection. The lower the priority number, the higher the priority of the rule.")]
		public int Priority { get; set; }

		[Parameter(Mandatory = true, HelpMessage = "Gets or sets network protocol this rule applies to. Possible values include: http, https, tcp, udp, icmp, ah, esp, any ")]
		public NetworkSecurityProtocol Protocol { get; set; }

		[Parameter(Mandatory = true, HelpMessage = "Gets or sets the CIDR or source IP ranges.")]
		public string[] SourceAddressPrefix { get; set;}

		[Parameter(Mandatory = true, HelpMessage = "Gets or sets the source port ranges.")]
		public string[] SourcePortRange { get;set; }

		[Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background and return a Job to track progress.")]
		public SwitchParameter AsJob { get; set; }

		#endregion

		public override void ExecuteCmdlet()
		{
			this.SetParams();
			if (ShouldProcess(target: this.Name, action: string.Format("Add NetworkSecurityRule {0} to {1} cluster", this.Name, this.ClusterName)))
			{
				try
				{
					ManagedCluster updatedCluster = this.GetClusterWithNewNetworkSecurityRule();
					var beginRequestResponse = this.SfrpMcClient.ManagedClusters.BeginCreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.ClusterName, updatedCluster)
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

		private ManagedCluster GetClusterWithNewNetworkSecurityRule()
		{
			ManagedCluster currentCluster = this.SfrpMcClient.ManagedClusters.Get(this.ResourceGroupName, this.ClusterName);

			if (currentCluster.NetworkSecurityRules == null)
			{
				currentCluster.NetworkSecurityRules = new List<NetworkSecurityRule>();
			}

			currentCluster.NetworkSecurityRules.Add(new NetworkSecurityRule()
			{
				Access = this.Access.ToString(),
				Description = this.Description,
				DestinationAddressPrefixes = this.DestinationAddressPrefix,
				DestinationPortRanges = this.DestinationPortRange,
				Direction = this.Direction.ToString(),
				Name = this.Name,
				Priority = this.Priority,
				Protocol = this.Protocol == NetworkSecurityProtocol.any? AnyTrueValue : this.Protocol.ToString(),
				SourceAddressPrefixes = this.SourceAddressPrefix,
				SourcePortRanges = this.SourcePortRange
			});

			return currentCluster;
		}

		private void SetParams()
		{
			switch (ParameterSetName)
			{
				case ByObj:
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
			this.ClusterName = resourceName;
		}
	}
}