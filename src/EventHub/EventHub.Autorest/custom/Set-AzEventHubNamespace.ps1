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
	    [Parameter(ParameterSetName = 'SetExpanded', Mandatory, HelpMessage = "The name of EventHub Entity.")]
        [Alias('EventHubName')]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        # The name of EventHub Entity.
        ${Name},

        [Parameter(ParameterSetName = 'SetExpanded', Mandatory, HelpMessage = "The name of EventHub namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        # The name of EventHub namespace
        ${NamespaceName},

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

        [Parameter(HelpMessage = "The Alternate Name of Eventhub Namespace")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        ${AlternateName},

        [Parameter(HelpMessage = "The ClusterArmId of Eventhub Namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        ${ClusterArmId},

        [Parameter(HelpMessage = "DisableLocalAuth")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        ${DisableLocalAuth},

        [Parameter(HelpMessage = "EncryptionKeySource")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        ${EncryptionKeySource},

        [Parameter(HelpMessage = "EncryptionKeyVaultProperty.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        ${EncryptionKeyVaultProperty},

        [Parameter(HelpMessage = "EncryptionRequireInfrastructureEncryption")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        ${EncryptionConfig}, #EncryptionConfig

        [Parameter(HelpMessage = "IdentityType of EventHub Namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        ${IdentityType},

        [Parameter(HelpMessage = "IdentityUserAssigneIdentity")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.Collections.Hashtable]
        ${IdentityId},#IdentityId

        [Parameter(HelpMessage = "IsAutoInflateEnabled")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        ${IsAutoInflateEnabled},

        [Parameter(HelpMessage = "KafkaEnabled")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        ${KafkaEnabled},

        [Parameter(HelpMessage = "Location of EventHub Namespace")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        ${Location},

        [Parameter(HelpMessage = "MaximumThroughputUnit of Eventhub Namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.Int64]
        ${MaximumThroughputUnit},

        [Parameter(HelpMessage = "MinimumTlsVersion of Eventhub Namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        ${MinimumTlsVersion},

        [Parameter(HelpMessage = "PrivateEndpointConnectionName.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        ${PrivateEndpointConnection},

        [Parameter(HelpMessage = "PublicNetworkAccess.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        ${PublicNetworkAccess},

        [Parameter(HelpMessage = "The SkuCapacity of EventHub Namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.Int64]
        ${SkuCapacity},

        [Parameter(HelpMessage = "The SkuName Of EventHub Namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        ${SkuName},

        [Parameter(HelpMessage = "SkuTier.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
        ${SkuTier},

        [Parameter(HelpMessage = "Tag of EventHub Namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.Collections.Hashtable]
        ${Tag},

        [Parameter(HelpMessage = "ZeroRedundant")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [System.String]
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
            $hasEncryptionKeySource = $PSBoundParameters.Remove('EncryptionKeySource')
            $hasEncryptionKeyVaultProperty = $PSBoundParameters.Remove('EncryptionKeyVaultProperty')
            $hasEncryptionConfig = $PSBoundParameters.Remove('EncryptionConfig')
            $hasIdentityType = $PSBoundParameters.Remove('IdentityType')
            $hasIdentityId = $PSBoundParameters.Remove('IdentityId')
            $hasIsAutoInflateEnabled = $PSBoundParameters.Remove('IsAutoInflateEnabled')
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
            if ($hasEncryptionKeySource) {
                $eventHubNamespace.EncryptionKeySource = $EncryptionKeySource
                $hasProperty = $true
            }
            if ($hasEncryptionKeyVaultProperty) {
                $eventHubNamespace.EncryptionKeyVaultProperty = $EncryptionKeyVaultProperty
                $hasProperty = $true
            }
            if ($hasEncryptionConfig) {
                $eventHubNamespace.EncryptionConfig = $EncryptionConfig
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
            if ($hasIsAutoInflateEnabled) {
                $eventHubNamespace.IsAutoInflateEnabled = $IsAutoInflateEnabled
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