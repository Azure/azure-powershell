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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    public class NewOrUpdateAzGarnetCluster : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.GarnetClusterNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.TagsHelpMessage)]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.GarnetClusterAuthenticationMethodHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AuthenticationMethod { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.GarnetClusterClusterTypeHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ClusterType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.GarnetClusterExtensionsHelpMessage)]
        public string[] Extensions { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.GarnetClusterPersistenceHelpMessage)]
        public bool? Persistence { get; set; }

        public Dictionary<string, string> PopulateTags(Hashtable Tag)
        {
            Dictionary<string, string> tags = new Dictionary<string, string>();
            foreach (string key in Tag.Keys)
            {
                tags.Add(key, Tag[key].ToString());
            }
            return tags;
        }
    }
}
