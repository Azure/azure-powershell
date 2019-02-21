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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.Kusto.Models;
using Microsoft.Azure.Commands.Kusto.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Kusto
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KustoCluster", SupportsShouldProcess = true),
        OutputType(typeof(PSKustoCluster))]
    public class NewKustoCluster : KustoCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Name of resource group under which you want to create the cluster.")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Name of the cluster to be created.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure region where the cluster should be created.")]
        [LocationCompleter("Microsoft.Kusto/clusters")]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the Sku used to create the cluster")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("KC8", "KC16", "KS8", "KS16", "L8", "L16", "D14_v2", "D13_v2")]
        public string Sku { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The instance number of the VM.")]
        [ValidateNotNullOrEmpty]
        public int? Capacity { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Name of the Tier used to create the cluster")]
        [PSArgumentCompleter("Standard")]
        public string Tier { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A string,string dictionary of tags associated with this cluster")]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Resources.CreateNewKustoCluster))
            {
                try
                {
                    if (KustoClient.GetCluster(ResourceGroupName, Name) != null)
                    {
                        throw new CloudException(string.Format(Resources.KustoClusterExists, Name));
                    }
                }
                catch (CloudException ex)
                {
                    if (ex.Body != null && !string.IsNullOrEmpty(ex.Body.Code) && ex.Body.Code == "ResourceNotFound" ||
                        ex.Message.Contains("ResourceNotFound"))
                    {
                        // cluster does not exists so go ahead and create one
                    }
                    else if (ex.Body != null && !string.IsNullOrEmpty(ex.Body.Code) &&
                             ex.Body.Code == "ResourceGroupNotFound" || ex.Message.Contains("ResourceGroupNotFound"))
                    {
                        // resource group not found, let create throw error don't throw from here
                    }
                    else
                    {
                        // all other exceptions should be thrown
                        throw;
                    }
                }

                var createdCluster = KustoClient.CreateOrUpdateCluster(ResourceGroupName, Name, Location, Sku, Capacity, Tag, null);
                WriteObject(createdCluster);
            }
        }
    }
}