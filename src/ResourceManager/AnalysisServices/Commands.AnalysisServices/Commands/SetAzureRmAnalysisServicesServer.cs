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

using System;
using System.Collections;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.AnalysisServices.Models;
using Microsoft.Azure.Commands.AnalysisServices.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Analysis.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.AnalysisServices
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AnalysisServicesServer", SupportsShouldProcess = true, DefaultParameterSetName = ParamSetDefault), OutputType(typeof(AzureAnalysisServicesServer))]
    [Alias("Set-" + ResourceManager.Common.AzureRMConstants.AzurePrefix + "As")]
    public class SetAzureAnalysisServicesServer : AnalysisServicesCmdletBase
    {
        private const string ParamSetDefault = "Default";
        private const string ParamSetDisableBackup = "DisableBackup";
        private const string ParamSetDisassociatGateway = "DisassociateGateway";

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Name of the server.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = false,
            HelpMessage = "Name of resource group under which you want to update the server.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = false,
            HelpMessage = "Name of the Sku used to create the server")]
        [ValidateNotNullOrEmpty]
        public string Sku { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage = "A string,string dictionary of tags associated with this server")]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            HelpMessage = "A comma separated server names to set as administrators on the server")]
        [ValidateNotNull]
        public string Administrator { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 5, Mandatory = false,
            ParameterSetName = ParamSetDefault,
            HelpMessage = "The Uri of blob container for backing up the server")]
        [ValidateNotNullOrEmpty]
        public string BackupBlobContainerUri { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 5, Mandatory = true,
            ParameterSetName = ParamSetDisableBackup,
            HelpMessage = "The switch to turn off backup of the server.")]
        public SwitchParameter DisableBackup { get; set; }


        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "The replica count of readonly pool")]
        [ValidateRange(0, 7)]
        public int ReadonlyReplicaCount
        { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "The default connection mode to query server")]
        [ValidateSet("All", "Readonly", IgnoreCase = true)]
        public string DefaultConnectionMode { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "Firewall configuration")]
        public PsAzureAnalysisServicesFirewallConfig FirewallConfig { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            ParameterSetName = ParamSetDefault,
            HelpMessage = "Gateway resource ID")]
        public string GatewayResourceId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            ParameterSetName = ParamSetDisassociatGateway,
            HelpMessage = "Disassociate current gateway")]
        public SwitchParameter DisassociateGateway { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(Name))
            {
                WriteExceptionError(new PSArgumentNullException("Name", "Name of server not specified"));
            }

            if (ShouldProcess(Name, Resources.UpdatingAnalysisServicesServer))
            {
                AnalysisServicesServer currentServer = null;
                if (!AnalysisServicesClient.TestServer(ResourceGroupName, Name, out currentServer))
                {
                    throw new InvalidOperationException(string.Format(Properties.Resources.ServerDoesNotExist, Name));
                }

                var availableSkus = AnalysisServicesClient.ListSkusForExisting(ResourceGroupName, Name);
                if (Sku != null && !availableSkus.Value.Any(v => v.Sku.Name == Sku))
                {
                    throw new InvalidOperationException(string.Format(Resources.InvalidSku, Sku, String.Join(",", availableSkus.Value.Select(v => v.Sku.Name))));
                }

                var location = currentServer.Location;
                if (Tag == null && currentServer.Tags != null)
                {
                    Tag = TagsConversionHelper.CreateTagHashtable(currentServer.Tags);
                }

                if (DisableBackup.IsPresent)
                {
                    BackupBlobContainerUri = "-";
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
                    ReadonlyReplicaCount = -1;
                }

                if (DisassociateGateway.IsPresent)
                {
                    GatewayResourceId = AnalysisServicesClient.DissasociateGateway;
                }

                AnalysisServicesServer updatedServer = AnalysisServicesClient.CreateOrUpdateServer(ResourceGroupName, Name, location, Sku, Tag, Administrator, currentServer, BackupBlobContainerUri, ReadonlyReplicaCount, DefaultConnectionMode, setting, GatewayResourceId);

                if(PassThru.IsPresent)
                {
                    WriteObject(AzureAnalysisServicesServer.FromAnalysisServicesServer(updatedServer));
                }
            }
        }
    }
}
