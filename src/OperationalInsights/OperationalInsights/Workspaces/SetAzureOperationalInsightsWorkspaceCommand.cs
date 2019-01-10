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

using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsWorkspace", DefaultParameterSetName = ByName), OutputType(typeof(PSWorkspace))]
    public class SetAzureOperationalInsightsWorkspaceCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, ParameterSetName = ByObject, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = "The workspace.")]
        [ValidateNotNull]
        public PSWorkspace Workspace { get; set; }

        [Parameter(Position = 1, ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 2, ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The workspace name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The service tier of the workspace.")]
        [ValidateSet("free", "standard", "premium", "pernode", "standalone", IgnoreCase = true)]
        public string Sku { get; set; }

        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource tags for the workspace.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The workspace data retention in days. 730 days is the maximum allowed for all other Skus.")]
        [ValidateNotNullOrEmpty]
        public int? RetentionInDays { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ByObject)
            {
                ResourceGroupName = Workspace.ResourceGroupName;
                Name = Workspace.Name;
            }

            UpdatePSWorkspaceParameters parameters = new UpdatePSWorkspaceParameters
            {
                ResourceGroupName = ResourceGroupName,
                WorkspaceName = Name,
                Sku = Sku,
                Tags = Tag,
                RetentionInDays = RetentionInDays
            };

            WriteObject(OperationalInsightsClient.UpdatePSWorkspace(parameters));
        }
    }
}
