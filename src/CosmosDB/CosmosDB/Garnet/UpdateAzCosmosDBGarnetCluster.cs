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

using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Models;
using System.Collections.Generic;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.CosmosDB.Exceptions;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using Microsoft.Azure.Commands.CosmosDB.Helpers;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBGarnetCluster", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSGarnetClusterResource))]
    public class UpdateAzCosmosDBGarnetCluster : NewOrUpdateAzGarnetCluster
    {
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.GarnetClusterObjectHelpMessage)]
        [ValidateNotNull]
        public PSGarnetClusterResource InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!ParameterSetName.Equals(NameParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = null;
                if (ParameterSetName.Equals(ResourceIdParameterSet))
                {
                    resourceIdentifier = new ResourceIdentifier(ResourceId);
                }
                else if (ParameterSetName.Equals(ObjectParameterSet))
                {
                    resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                }
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                ClusterName = resourceIdentifier.ResourceName;
            }

            GarnetClusterResource existingCluster = null;
            try
            {
                existingCluster = CosmosDBManagementClient.GarnetClusters.GetWithHttpMessagesAsync(ResourceGroupName, ClusterName).GetAwaiter().GetResult().Body;
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    throw;
                }
                else
                {
                    throw new ResourceNotFoundException(message: string.Format(ExceptionMessage.NotFound, ClusterName), innerException: e);
                }
            }

            IDictionary<string, string> tagsDict;
            if (Tag != null)
            {
                tagsDict = base.PopulateTags(Tag);
            }
            else
            {
                tagsDict = existingCluster.Tags;
            }

            IList<string> extensionsList;
            if (Extensions != null)
            {
                extensionsList = new List<string>(Extensions);
            }
            else
            {
                extensionsList = existingCluster.Properties?.Extensions;
            }

            GarnetClusterResourcePatchProperties patchProperties = new GarnetClusterResourcePatchProperties
            {
                ClusterType = ClusterType ?? existingCluster.Properties?.ClusterType,
                Extensions = extensionsList,
                AuthenticationMethod = AuthenticationMethod ?? existingCluster.Properties?.AuthenticationMethod,
                Persistence = Persistence ?? existingCluster.Properties?.Persistence,
            };

            GarnetClusterResourcePatch patch = new GarnetClusterResourcePatch
            {
                Properties = patchProperties,
                Tags = tagsDict
            };

            if (ShouldProcess(ClusterName, "Updating Garnet Cluster."))
            {
                GarnetClusterResource result = CosmosDBManagementClient.GarnetClusters.UpdateWithHttpMessagesAsync(ResourceGroupName, ClusterName, patch).GetAwaiter().GetResult().Body;
                WriteObject(new PSGarnetClusterResource(result));
            }

            return;
        }
    }
}
