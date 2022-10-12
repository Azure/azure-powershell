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
Updates an EventHub Entity
.Description
Updates an EventHub Entity
#>

function Set-AzEventHubNamespaceName{
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IEhNamespace])]
    [CmdletBinding(DefaultParameterSetName = 'SetExpanded', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
	param(

        [Parameter(ParameterSetName = 'SetExpanded', Mandatory, HelpMessage = "The name of EventHub namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        # The name of EventHub namespace
        ${Name},

        [Parameter(ParameterSetName = 'SetExpanded', Mandatory, HelpMessage = "The name of the resource group. The name is case insensitive.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(ParameterSetName = 'SetExpanded', HelpMessage = "The ID of the target subscription.")]
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
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.Management.Automation.SwitchParameter]
        ${Encryption}, #EncryptionConfig

        [Parameter(HelpMessage = "Type of managed service identity.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.ManagedServiceIdentityType]
        ${IdentityType},

        [Parameter(HelpMessage = "Properties for User Assigned Identities")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.Collections.Hashtable]
        ${IdentityId},#IdentityId

        [Parameter(HelpMessage = "Value that indicates whether AutoInflate is enabled for eventhub namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.Management.Automation.SwitchParameter]
        ${EnableAutoInflate},

        [Parameter(HelpMessage = "Value that indicates whether Kafka is enabled for eventhub namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.Management.Automation.SwitchParameter]
        ${KafkaEnabled},

        [Parameter(HelpMessage = "Location of the resource.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        ${Location},

        [Parameter(HelpMessage = "Upper limit of throughput units when AutoInflate is enabled, value should be within 0 to 20 throughput units. ( '0' if AutoInflateEnabled = true)")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.Int64]
        ${MaximumThroughputUnit},

        [Parameter(HelpMessage = "The minimum TLS version for the cluster to support, e.g. '1.2'")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.TlsVersion]
        ${MinimumTlsVersion},

        [Parameter(HelpMessage = "List of private endpoint connections.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IPrivateEndpointConnection[]]
        ${PrivateEndpointConnection},

        [Parameter(HelpMessage = "This determines if traffic is allowed over public network. By default it is enabled.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.PublicNetworkAccess]
        ${PublicNetworkAccess},

        [Parameter(HelpMessage = "The Event Hubs throughput units for Basic or Standard tiers, where value should be 0 to 20 throughput units. The Event Hubs premium units for Premium tier, where value should be 0 to 10 premium units.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.Int64]
        ${SkuCapacity},

        [Parameter(HelpMessage = "Name of the Sku")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        ${SkuName},

        [Parameter(HelpMessage = "The billing tier of this particular SKU.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.SkuTier]
        ${SkuTier},

        [Parameter(HelpMessage = "Tag of EventHub Namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.Collections.Hashtable]
        ${Tag},

        [Parameter(HelpMessage = "ZeroRedundant")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.Management.Automation.SwitchParameter]
        ${ZoneRedundant},

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
            $hasAlternateName = $PSBoundParameters.Remove('AlternateName')
            $hasClusterArmId = $PSBoundParameters.Remove('ClusterArmId')
            $hasDisableLocalAuth = $PSBoundParameters.Remove('DisableLocalAuth')
            $hasEncryption = $PSBoundParameters.Remove('Encryption')
            $hasIdentityType = $PSBoundParameters.Remove('IdentityType')
            $hasIdentityId = $PSBoundParameters.Remove('IdentityId')
            $hasEnableAutoInflate = $PSBoundParameters.Remove('EnableAutoInflate')
            $hasKafkaEnabled = $PSBoundParameters.Remove('KafkaEnabled')
            $hasLocation = $PSBoundParameters.Remove('Location')
            $hasMaximumThroughputUnit = $PSBoundParameters.Remove('MaximumThroughputUnit')
            $hasMinimumTlsVersion = $PSBoundParameters.Remove('MinimumTlsVersion')
            $hasPrivateEndpointConnection = $PSBoundParameters.Remove('PrivateEndpointConnection')
            $hasPublicNetworkAccess = $PSBoundParameters.Remove('PublicNetworkAccess')
            $hasSkuCapacity = $PSBoundParameters.Remove('SkuCapacity')
            $hasSkuName = $PSBoundParameters.Remove('SkuName')
            $hasSkuTier = $PSBoundParameters.Remove('SkuTier')
            $hasTag = $PSBoundParameters.Remove('Tag')
            $hasZoneRedundant = $PSBoundParameters.Remove('ZoneRedundant')
            $hasDefaultProfile = $PSBoundParameters.Remove('DefaultProfile')
            $hasAsJob = $PSBoundParameters.Remove('AsJob')
            $null = $PSBoundParameters.Remove('WhatIf')
            $null = $PSBoundParameters.Remove('Confirm')

            $eventHubNamespace = Get-AzEventHubNamespace @PSBoundParameters

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
            $hasProperty = $false

            if ($hasAlternateName) {
                $eventHubNamespace.AlternateName = $AlternateName
                $hasProperty = $true
            }

            if ($hasClusterArmId) {
                $eventHubNamespace.ClusterArmId = $ClusterArmId
                $hasProperty = $true
            }
            if ($hasDisableLocalAuth) {
                $eventHubNamespace.DisableLocalAuth = $DisableLocalAuth
                $hasProperty = $true
            }
            if ($hasEncryption) {
                $eventHubNamespace.Encryption = $Encryption
                $hasProperty = $true
            }
            if ($hasIdentityType) {
                $eventHubNamespace.IdentityType = $IdentityType
                $hasProperty = $true
            }
            if ($hasIdentityId) {
                $eventHubNamespace.IdentityId = $IdentityId
                $hasProperty = $true
            }
            if ($hasEnableAutoInflate) {
                $eventHubNamespace.EnableAutoInflate = $EnableAutoInflate
                $hasProperty = $true
            }
            if ($hasKafkaEnabled) {
                $eventHubNamespace.KafkaEnabled = $KafkaEnabled
                $hasProperty = $true
            }
            if ($hasLocation) {
                $eventHubNamespace.Location = $Location
                $hasProperty = $true
            }
            if ($hasMaximumThroughputUnit) {
                $eventHubNamespace.MaximumThroughputUnit = $MaximumThroughputUnit
                $hasProperty = $true
            }
            if ($hasMinimumTlsVersion) {
                $eventHubNamespace.MinimumTlsVersion = $MinimumTlsVersion
                $hasProperty = $true
            }
            if ($hasPrivateEndpointConnection) {
                $eventHubNamespace.PrivateEndpointConnection = $PrivateEndpointConnection
                $hasProperty = $true
            }
            if ($hasPublicNetworkAccess) {
                $eventHubNamespace.PublicNetworkAccess = $PublicNetworkAccess
                $hasProperty = $true
            }
            if ($hasSkuCapacity) {
                $eventHubNamespace.SkuCapacity = $SkuCapacity
                $hasProperty = $true
            }
            if ($hasSkuName) {
                $eventHubNamespace.SkuName = $Skuname
                $hasProperty = $true
            }
            if ($hasSkuTier) {
                $eventHubNamespace.SkuTier= $SkuTier
                $hasProperty = $true
            }
            if ($hasTag) {
                $eventHubNamespace.Tag = $Tag
                $hasProperty = $true
            }
            if ($hasZeroRedundant) {
                $eventHubNamespace.ZeroRedundant = $ZeroRedundant
                $hasProperty = $true
            }
            if ($hasDefaultProfile) {
                $eventHubNamespace.DefaultProfile = $DefaultProfile
                $hasProperty = $true
            }
            if ($PSCmdlet.ShouldProcess("EventHub Consumer Group $($consumerGroup.Name)", "Create or update")) {
                Az.EventHub.private\New-AzEventHubConsumerGroup_CreateViaIdentity -InputObject $eventHubNaespaceName -Parameter $eventHubNamespaeName @PSBoundParameters
            }
		}
		catch{
			throw
		}
	}
}