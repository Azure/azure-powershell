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
    public class NewOrUpdateAzManagedCassandraCluster : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ManagedCassandraClusterNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedCassandraIdentityHelpMessage)]
        public ManagedServiceIdentity Identity { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedCassandraTagsHelpMessage)]
        [ValidateNotNull]
        public Hashtable Tags { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedCassandraExternalGossipCertificatesHelpMessage)]
        public string[] ExternalGossipCertificates { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedCassandraClientCertificatesHelpMessage)]
        public string[] ClientCertificates { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedCassandraRepairEnabledHelpMessage)]
        public bool? RepairEnabled { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedCassandraHoursBetweenBackupsHelpMessage)]
        public int? HoursBetweenBackups { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedCassandraAuthenticationMethodHelpMessage)]
        public string AuthenticationMethod { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedCassandraCassandraVersionHelpMessage)]
        public string CassandraVersion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedCassandraExternalSeedNodesHelpMessage)]
        public string[] ExternalSeedNodes { get; set; }


        public Dictionary<string, string> PopulateTags(Hashtable Tag)
        {
            Dictionary<string, string> tags = new Dictionary<string, string>();
            foreach (string key in Tag.Keys)
            {
                tags.Add(key, Tag[key].ToString());
            }
            return tags;
        }

        public IList<Certificate> PopulateCertificates(string[] certificates)
        {
            IList<Certificate> certificateList = new List<Certificate>();
            foreach (string certificate in certificates)
            {
                certificateList.Add(new Certificate(certificate));
            }
            return certificateList;
        }

        public IList<SeedNode> PopulateSeedNodes(string[] seedNodes)
        {
            IList<SeedNode> seedNodeList = new List<SeedNode>();
            foreach (string seedNode in seedNodes)
            {
                seedNodeList.Add(new SeedNode(seedNode));
            }
            return seedNodeList;
        }
    }
}
