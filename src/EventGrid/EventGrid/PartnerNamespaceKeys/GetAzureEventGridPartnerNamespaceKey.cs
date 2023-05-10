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
using System.Text;
using System.Management.Automation;
using Microsoft.Azure.Commands.EventGrid.Models;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Azure.Commands.EventGrid.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.EventGrid
{
    /// <summary>
    /// 'Get-AzureEventGridPartnerNamespace' Cmdlet gives the details of a / List of EventGrid partner registration(s)
    /// <para> If PartnerNamespace name provided, a single PartnerNamespace details will be returned</para>
    /// <para> If PartnerNamespace name not provided, list of PartnerNamespaces will be returned</para>
    /// </summary>

    [Cmdlet(
        "Get",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridPartnerNamespaceKey",
        DefaultParameterSetName = PartnerNamespaceNameParameterSet),
    OutputType(typeof(PSPartnerNamespaceListInstance), typeof(PSPartnerNamespace))]

    public class GetAzureEventGridPartnerNamespaceKey : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = PartnerNamespaceNameParameterSet)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PartnerNamespaceNameHelp,
            ParameterSetName = PartnerNamespaceNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/partnerNamespaces", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string PartnerNamespaceName { get; set; }


        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PartnerNamespaceInputObjectHelp,
            ParameterSetName = PartnerNamespaceInputObjectParameterSet)]
        public PSPartnerNamespace InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            string resourceGroupName = string.Empty;
            string partnerNamespaceName = string.Empty;

            if (this.InputObject != null)
            {
                resourceGroupName = this.InputObject.ResourceGroupName;
                partnerNamespaceName = this.InputObject.PartnerNamespaceName;
            }
            else
            {
                resourceGroupName = this.ResourceGroupName;
                partnerNamespaceName = this.PartnerNamespaceName;
            }

            // Get details of a partner namespace shared access key
            PartnerNamespaceSharedAccessKeys partnerNamespaceSharedAccessKeys = this.Client.ListPartnerNamespaceKeys(resourceGroupName, partnerNamespaceName);
            PSPartnerNamespaceSharedAccessKeys psPartnerNamespaceSharedAccessKeys = new PSPartnerNamespaceSharedAccessKeys(partnerNamespaceSharedAccessKeys);
            this.WriteObject(psPartnerNamespaceSharedAccessKeys);
        }
    }

}