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
Gets the SASKey of a ServiceBus namespace, queue or topic.
.Description
Gets the SASKey of a ServiceBus namespace, queue or topic.
#>

function Set-AzServiceBusNamespaceV2{
	[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbNamespace])]
    [CmdletBinding(DefaultParameterSetName = 'SetExpanded', PositionalBinding = $false, ConfirmImpact = 'Medium')]
	param(
        [Parameter(ParameterSetName = 'SetExpandedNamespace', Mandatory, HelpMessage = "The name of ServiceBusNamespace")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        ${Name},

        [Parameter(ParameterSetName = 'SetExpandedNamespace', Mandatory, HelpMessage = "The name of the ResourceGroupName.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        ${ResourceGroupName},

        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(ParameterSetName = 'SetExpandedNamespace', Mandatory, HelpMessage = "Resource Location.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.String]
        ${Location},

        [Parameter(HelpMessage = "Alternate name for namespace")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.String]
        ${AlternateName},
        
        [Parameter(HelpMessage = "This property disables SAS authentication for the Service Bus namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${DisableLocalAuth},
		
        [Parameter(HelpMessage = "Properties of KeyVault")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IKeyVaultProperties[]]
        ${KeyVaultProperty},

        [Parameter(HelpMessage = "Enable Infrastructure Encryption (Double Encryption)")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${RequireInfrastructureEncryption},

        [Parameter(HelpMessage = "Type of managed service identity.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Support.ManagedServiceIdentityType]
        ${IdentityType},

        [Parameter(HelpMessage = "Properties for User Assigned Identities")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Collections.Hashtable]
        ${UserAssignedIdentity},

        [Parameter(HelpMessage = "The minimum TLS version for the cluster to support, e.g. '1.2'")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Support.TlsVersion]
        ${MinimumTlsVersion},

        [Parameter(HelpMessage = "This determines if traffic is allowed over public network. By default it is enabled.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Support.PublicNetworkAccess]
        ${PublicNetworkAccess},

        [Parameter(HelpMessage = "Name of this SKU.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Support.SkuName]
        ${SkuName},

        [Parameter(HelpMessage = "The Event Hubs throughput units for Basic or Standard tiers, where value should be 0 to 20 throughput units. The Event Hubs premium units for Premium tier, where value should be 0 to 10 premium units.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Int32]
        ${SkuCapacity},

        [Parameter(HelpMessage = "Value that indicates whether AutoInflate is enabled for ServiceBus namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${EnableAutoInflate},

        [Parameter(HelpMessage = "Upper limit of throughput units when AutoInflate is enabled, value should be within 0 to 20 throughput units. ( '0' if AutoInflateEnabled = true)")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Int32]
        ${MaximumThroughputUnits},

        [Parameter(HelpMessage = "Resource tags.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Collections.Hashtable]
        ${Tag},

        [Parameter(HelpMessage = "The credentials, account, tenant, and subscription used for communication with Azure.")]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Azure')]
        [System.Management.Automation.PSObject]
        ${DefaultProfile},

        [Parameter(HelpMessage = "Run the command as a job")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(HelpMessage = "Run the command asynchronously")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
	)
	process{
		try{
            $hasAlternateName = $PSBoundParameters.Remove('AlternateName')
            $hasDisableLocalAuth = $PSBoundParameters.Remove('DisableLocalAuth')
            $hasKeyVaultProperty = $PSBoundParameters.Remove('KeyVaultProperty')
            $hasUserAssignedIdentity = $PSBoundParameters.Remove('UserAssignedIdentity')
            $hasIdentityType = $PSBoundParameters.Remove('IdentityType')
            $hasEnableAutoInflate = $PSBoundParameters.Remove('EnableAutoInflate')
            $hasMaximumThroughputUnits = $PSBoundParameters.Remove('MaximumThroughputUnits')
            $hasMinimumTlsVersion = $PSBoundParameters.Remove('MinimumTlsVersion')
            $hasRequireInfrastructureEncryption = $PSBoundParameters.Remove('RequireInfrastructureEncryption') 
            $hasPublicNetworkAccess = $PSBoundParameters.Remove('PublicNetworkAccess')
            $hasSkuCapacity = $PSBoundParameters.Remove('SkuCapacity')
            $hasTag = $PSBoundParameters.Remove('Tag')
            $hasDefaultProfile = $PSBoundParameters.Remove('DefaultProfile')
            $hasAsJob = $PSBoundParameters.Remove('AsJob')
            $null = $PSBoundParameters.Remove('WhatIf')
            $null = $PSBoundParameters.Remove('Confirm')
            
            $serviceBusNamespace = Get-ServiceBusNamespaceV2 @PSBoundParameters

            # 2. PUT
            $null = $PSBoundParameters.Remove('InputObject')
            $null = $PSBoundParameters.Remove('ResourceGroupName')
            $null = $PSBoundParameters.Remove('NamespaceName')
            $null = $PSBoundParameters.Remove('EventHubName')
            $null = $PSBoundParameters.Remove('Name')
            $null = $PSBoundParameters.Remove('SubscriptionId')

            if ($hasAsJob) {
                $PSBoundParameters.Add('AsJob', $true)
            }

            if ($hasAlternateName) {
                $serviceBusNamespace.AlternateName = $AlternateName
            }

            if ($hasDisableLocalAuth) {
                $serviceBusNamespace.DisableLocalAuth = $DisableLocalAuth
            }
            if ($hasKeyVaultProperty) {
                $serviceBusNamespace.KeyVaultProperty = $KeyVaultProperty
                $serviceBusNamespace.KeySource = 'Microsoft.KeyVault'
            }
            if ($hasIdentityType) {
                $serviceBusNamespace.IdentityType = $IdentityType
            }
            if($hasRequireInfrastructureEncryption){
                $serviceBusNamespace.RequireInfrastructureEncryption = $RequireInfrastructureEncryption
            }
            if ($hasUserAssignedIdentity) {
                $serviceBusNamespace.UserAssignedIdentity = $UserAssignedIdentity
            }
            if ($hasEnableAutoInflate) {
                $serviceBusNamespace.EnableAutoInflate = $EnableAutoInflate
            }
            if ($hasMaximumThroughputUnits) {
                $serviceBusNamespace.MaximumThroughputUnits = $MaximumThroughputUnits
            }
            if ($hasMinimumTlsVersion) {
                $serviceBusNamespace.MinimumTlsVersion = $MinimumTlsVersion
            }
            if ($hasPublicNetworkAccess) {
                $serviceBusNamespace.PublicNetworkAccess = $PublicNetworkAccess
            }
            if ($hasSkuCapacity) {
                $serviceBusNamespace.SkuCapacity = $SkuCapacity
            }
            if ($hasTag) {
                $serviceBusNamespace.Tag = $Tag
            }
            if ($hasDefaultProfile) {
                $serviceBusNamespace.DefaultProfile = $DefaultProfile
            }

            if ($PSCmdlet.ShouldProcess("ServiceBusNamespace $($serviceBusNamespace.Name)", "Create or update")) {
                Az.ServiceBus.private\New-AzServiceBusNamespaceV2_CreateViaIdentity -InputObject $serviceBusNamespace -Parameter $serviceBusNamespace @PSBoundParameters
            }
		}
		catch{
			throw
		}
	}
}