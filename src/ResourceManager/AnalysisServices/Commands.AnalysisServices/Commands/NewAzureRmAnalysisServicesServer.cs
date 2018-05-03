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
using System.Collections;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.AnalysisServices.Models;
using Microsoft.Azure.Commands.AnalysisServices.Properties;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Analysis.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.AnalysisServices
{
    [Cmdlet(VerbsCommon.New, "AzureRmAnalysisServicesServer", SupportsShouldProcess = true), OutputType(typeof(AzureAnalysisServicesServer))]
    [Alias("New-AzureAs")]
    public class NewAnalysisServicesServer : AnalysisServicesCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Name of resource group under which you want to create the server.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "Name of the server to create.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = true,
            HelpMessage = "Azure region where the server should be created.")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.AnalysisServices/servers")]
        public string Location { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = true,
            HelpMessage =
                "Name of the Sku used to create the server"
            )]
        [ValidateNotNullOrEmpty]
        public string Sku { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            HelpMessage = "A string,string dictionary of tags associated with this server")]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 5, Mandatory = false,
            HelpMessage = "A comma separated server names to set as administrators on the server")]
        [ValidateNotNull]
        public string Administrator { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 6, Mandatory = false,
            HelpMessage = "The Uri of blob container for backing up the server")]
        [ValidateNotNullOrEmpty]
        public string BackupBlobContainerUri { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "The replica count of readonly pool")]
        [ValidateRange(0, 7)]
        public int ReadonlyReplicaCount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "The default connection mode to query server")]
        [ValidateSet("All", "Readonly", IgnoreCase = true)]
        public string DefaultConnectionMode { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "Firewall configuration")]
        public PsAzureAnalysisServicesFirewallConfig FirewallConfig { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Resources.CreateNewAnalysisServicesServer))
            {
                try
                {
                    if (AnalysisServicesClient.GetServer(ResourceGroupName, Name) != null)
                    {
                        throw new CloudException(string.Format(Resources.AnalysisServerExists, Name));
                    }
                }
                catch (CloudException ex)
                {
                    if (ex.Body != null && !string.IsNullOrEmpty(ex.Body.Code) && ex.Body.Code == "ResourceNotFound" ||
                        ex.Message.Contains("ResourceNotFound"))
                    {
                        // server does not exists so go ahead and create one
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

                var availableSkus = AnalysisServicesClient.ListSkusForNew();
                if (!availableSkus.Value.Any(v => v.Name == Sku))
                {
                    throw new InvalidOperationException(string.Format(Resources.InvalidSku, Sku, String.Join(",", availableSkus.Value.Select(v => v.Name))));
                }

                IPv4FirewallSettings setting = null;
                if (FirewallConfig != null)
                {
                    setting = new IPv4FirewallSettings(new List<IPv4FirewallRule>(), "False");

                    setting.EnablePowerBIService = FirewallConfig.EnablePowerBIService.ToString();

                    if (FirewallConfig.FirewallRules != null)
                    {
                        foreach (var rule in FirewallConfig.FirewallRules)
                        {
                            setting.FirewallRules.Add(new IPv4FirewallRule()
                            {
                                FirewallRuleName = rule.FirewallRuleName,
                                RangeStart = rule.RangeStart,
                                RangeEnd = rule.RangeEnd
                            });
                        }
                    }
                }

                if (!MyInvocation.BoundParameters.ContainsKey("ReadonlyReplicaCount"))
                {
                    ReadonlyReplicaCount = 0;
                }

                var createdServer = AnalysisServicesClient.CreateOrUpdateServer(ResourceGroupName, Name, Location, Sku, Tag, Administrator, null, BackupBlobContainerUri, ReadonlyReplicaCount, DefaultConnectionMode, setting);
                WriteObject(AzureAnalysisServicesServer.FromAnalysisServicesServer(createdServer));
            }
        }
    }
}