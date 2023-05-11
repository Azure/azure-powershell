# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Creates an EventHub Namespace
.Description
Creates an EventHub Namespace
#>

function New-AzEventHubNamespace{
    [Alias("New-AzEventHubNamespaceV2")]
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.IEhNamespace])]
    [CmdletBinding(PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(

        [Parameter(Mandatory, HelpMessage = "The name of EventHub namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        # The name of EventHub namespace
        ${Name},

        [Parameter(Mandatory, HelpMessage = "The name of the resource group. The name is case insensitive.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(HelpMessage = "The ID of the target subscription.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(HelpMessage = "Alternate name specified when alias and namespace names are same")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [System.String]
        ${AlternateName},

        [Parameter(HelpMessage = "Cluster ARM ID of the Namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [System.String]
        ${ClusterArmId},

        [Parameter(HelpMessage = "This property disables SAS authentication for the Event Hubs namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${DisableLocalAuth},

        [Parameter(HelpMessage = "Enable Infrastructure Encryption (Double Encryption)")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${RequireInfrastructureEncryption},

        [Parameter(Mandatory, HelpMessage = "Cluster ARM ID of the Namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [System.String]
        ${Location},

        [Parameter(HelpMessage = "Enabling this property creates a Standard Event Hubs Namespace in regions supported availability zones.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${ZoneRedundant},

        [Parameter(HelpMessage = "Properties to configure Encryption")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.IKeyVaultProperties[]]
        ${KeyVaultProperty},

        [Parameter(HelpMessage = "Type of managed service identity.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.ManagedServiceIdentityType]
        ${IdentityType},

        [Parameter(HelpMessage = "Properties for User Assigned Identities")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [System.String[]]
        # IdentityId
        ${UserAssignedIdentityId},

        [Parameter(HelpMessage = "Value that indicates whether AutoInflate is enabled for eventhub namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${EnableAutoInflate},

        [Parameter(HelpMessage = "Upper limit of throughput units when AutoInflate is enabled, value should be within 0 to 20 throughput units. ( '0' if AutoInflateEnabled = true)")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [System.Int64]
        ${MaximumThroughputUnit},

        [Parameter(HelpMessage = "The minimum TLS version for the cluster to support, e.g. '1.2'")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [System.String]
        ${MinimumTlsVersion},

        [Parameter(HelpMessage = "The minimum TLS version for the cluster to support, e.g. '1.2'")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.SkuName]
        ${SkuName},

        [Parameter(HelpMessage = "This determines if traffic is allowed over public network. By default it is enabled.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.PublicNetworkAccess]
        ${PublicNetworkAccess},

        [Parameter(HelpMessage = "The Event Hubs throughput units for Basic or Standard tiers, where value should be 0 to 20 throughput units. The Event Hubs premium units for Premium tier, where value should be 0 to 10 premium units.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [System.Int64]
        ${SkuCapacity},

        [Parameter(HelpMessage = "Tag of EventHub Namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [System.Collections.Hashtable]
        ${Tag},

        [Parameter(HelpMessage = "The credentials, account, tenant, and subscription used for communication with Azure.")]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Azure')]
        [System.Management.Automation.PSObject]
        ${DefaultProfile},

        [Parameter(HelpMessage = "Run the command as a job")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )
    process{
        try{
       	    $null = $PSBoundParameters.Remove('WhatIf')
            $null = $PSBoundParameters.Remove('Confirm')
            if($PSBoundParameters.ContainsKey('SkuName')){
                $PSBoundParameters.Add('SkuTier', $SkuName)
            }

            if($PSBoundParameters.ContainsKey('KeyVaultProperty')){
                $PSBoundParameters.Add('KeySource', 'Microsoft.KeyVault')
            }
            
            if($PSBoundParameters.ContainsKey('UserAssignedIdentityId')){
                $identityHashTable = @{}

                foreach ($resourceID in $UserAssignedIdentityId){
                    $identityHashTable.Add($resourceID, [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.UserAssignedIdentity]::new())
                }

                $PSBoundParameters.Add("UserAssignedIdentity", $identityHashTable)
                $null = $PSBoundParameters.Remove("UserAssignedIdentityId")
            }
            if ($PSCmdlet.ShouldProcess("EventHub Namespace $($Name)", "Create or update")) {
                Az.EventHub.private\New-AzEventHubNamespace_CreateExpanded @PSBoundParameters
            }
	}
	catch{
	    throw
	}
    }
}
