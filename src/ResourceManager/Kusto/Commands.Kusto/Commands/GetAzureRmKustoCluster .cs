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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Kusto.Models;
using Microsoft.Azure.Commands.Kusto.Utilities;

namespace Microsoft.Azure.Commands.Kusto
{
    [Cmdlet(VerbsCommon.Get, "AzureRmKustoCluster", DefaultParameterSetName = ParameterSet),
        OutputType(typeof(List<PSKustoCluster>))]
    public class GetAzureRmKustoCluster : KustoCmdletBase
    {
        protected const string ParameterSet = "ByClusterOrResourceGroupOrSubscription";
        protected const string ResourceIdParameterSet = "ByResourceId";

        [Parameter(
            ParameterSetName = ParameterSet,
            Mandatory = false,
            HelpMessage = "Name of resource group under which the user wants to retrieve the cluster.")]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ParameterSet,
            Mandatory = false,
            HelpMessage = "Name of a specific cluster.")]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Kusto cluster ResourceID.")]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            string resourceGroupName = ResourceGroupName;
            string clusterName = Name;

            if (!string.IsNullOrEmpty(ResourceId))
            {
                KustoUtils.GetResourceGroupNameAndClusterName(ResourceId, out resourceGroupName, out clusterName);
            }

            if (!string.IsNullOrEmpty(clusterName))
            {
                // Get for single cluster
                var capacity = KustoClient.GetCluster(resourceGroupName, clusterName);
                WriteObject(capacity);
            }
            else
            {
                // List all capacities in given resource group if available otherwise all capacities in the subscription
                var list = KustoClient.ListClusters(resourceGroupName);
                WriteObject(list, true);
            }
        }
    }
}