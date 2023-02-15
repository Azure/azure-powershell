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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerScope"), OutputType(typeof(PSNetworkManagerScopes))]
    public class NewAzNetworkManagerScopeCommand : NetworkManagerBaseCmdlet
    {

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Management Group Lists in Network Manager Scope")]
        public string[] ManagementGroup { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Subscription Lists in Network Manager Scope")]
        public string[] Subscription { get; set; }

        public override void Execute()
        {
            base.Execute();
            var psNetworkManagerScopes = new PSNetworkManagerScopes();
            List<string> managementGroups = new List<string>();
            if (this.ManagementGroup != null)
            {
                managementGroups = this.ManagementGroup.ToList();
            }
            List<string> subscriptions = new List<string>();
            if (this.Subscription != null)
            {
                subscriptions = this.Subscription.ToList();
            }
            psNetworkManagerScopes.ManagementGroups = managementGroups;
            psNetworkManagerScopes.Subscriptions = subscriptions;
            WriteObject(psNetworkManagerScopes);
        }
    }
}
