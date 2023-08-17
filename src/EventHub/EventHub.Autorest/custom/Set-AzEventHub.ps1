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

function Set-AzEventHub{

    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.IEventHub])]
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

        [Parameter(ParameterSetName = 'SetViaIdentityExpanded', Mandatory, ValueFromPipeline, HelpMessage = "Identity parameter. To construct, see NOTES section for INPUTOBJECT properties and create a hash table.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},

        [Parameter(HelpMessage = "A value that indicates whether capture description is enabled.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # A value that indicates whether capture description is enabled.
        ${CaptureEnabled},

        [Parameter(HelpMessage = "Enumerates the possible values for the encoding format of capture description. Note: 'AvroDeflate' will be deprecated in New API Version")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.EncodingCaptureDescription]
        #Enumerates the possible values for the encoding format of capture description. Note: 'AvroDeflate' will be deprecated in New API Version
        ${Encoding},

        [Parameter(HelpMessage = "The time window allows you to set the frequency with which the capture to Azure Blobs will happen, value should between 60 to 900 seconds")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [System.Int32]
        # The time window allows you to set the frequency with which the capture to Azure Blobs will happen, value should between 60 to 900 seconds
        ${IntervalInSeconds},

        [Parameter(HelpMessage = "The size window defines the amount of data built up in your Event Hub before an capture operation, value should be between 10485760 to 524288000 bytes")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [System.Int32]
        # The size window defines the amount of data built up in your Event Hub before an capture operation, value should be between 10485760 to 524288000 bytes
        ${SizeLimitInBytes},

        [Parameter(HelpMessage = "A value that indicates whether to Skip Empty Archives")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # A value that indicates whether to Skip Empty Archives
        ${SkipEmptyArchive},

        [Parameter(HelpMessage = "Number of hours to retain the events for this Event Hub. This value is only used when cleanupPolicy is Delete. If cleanupPolicy is Compaction the returned value of this property is Long.MaxValue")]
		[Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
		[System.Int64]
		# Number of hours to retain the events for this Event Hub. This value is only used when cleanupPolicy is Delete. If cleanupPolicy is Compaction the returned value of this property is Long.MaxValue
		${RetentionTimeInHour},

        [Parameter(HelpMessage = "Number of hours to retain the tombstone markers of a compacted Event Hub. This value is only used when cleanupPolicy is Compaction. Consumer must complete reading the tombstone marker within this specified amount of time if consumer begins from starting offset to ensure they get a valid snapshot for the specific key described by the tombstone marker within the compacted Event Hub")]
		[Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
		[System.Int32]
        ${TombstoneRetentionTimeInHour},

        [Parameter(HelpMessage = "Enumerates the possible values for the status of the Event Hub.")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.EntityStatus]
        # Enumerates the possible values for the status of the Event Hub.
        ${Status},

        [Parameter(HelpMessage = "Name for capture destination")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [System.String]
        # Name for capture destination
        ${DestinationName},

        [Parameter(HelpMessage = "Resource id of the storage account to be used to create the blobs")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [System.String]
        # Resource id of the storage account to be used to create the blobs
        ${StorageAccountResourceId},
        
        [Parameter(HelpMessage = "Blob naming convention for archive, e.g. {Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}. Here all the parameters (Namespace,EventHub .. etc) are mandatory irrespective of order")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [System.String]
        # Blob naming convention for archive, e.g. {Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}. Here all the parameters (Namespace,EventHub .. etc) are mandatory irrespective of order
        ${ArchiveNameFormat},

        [Parameter(HelpMessage = "Blob container Name")]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Body')]
        [System.String]
        # Blob container Name
        ${BlobContainer},

        [Parameter(HelpMessage = "The credentials, account, tenant, and subscription used for communication with Azure.")]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
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

        [Parameter(HelpMessage = "Run the command asynchronously")]
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
            $hasCaptureEnabled = $PSBoundParameters.Remove('CaptureEnabled')
            $hasEncoding = $PSBoundParameters.Remove('Encoding')
            $hasIntervalInSeconds = $PSBoundParameters.Remove('IntervalInSeconds')
            $hasSizeLimitInBytes = $PSBoundParameters.Remove('SizeLimitInBytes')
            $hasSkipEmptyArchive = $PSBoundParameters.Remove('SkipEmptyArchive')
            $hasRetentionTimeInHour = $PSBoundParameters.Remove('RetentionTimeInHour')
            $hasTombstoneRetentionTimeInHour = $PSBoundParameters.Remove('TombstoneRetentionTimeInHour')
            $hasStatus = $PSBoundParameters.Remove('Status')
            $hasDestinationName = $PSBoundParameters.Remove('DestinationName')
            $hasStorageAccountResourceId = $PSBoundParameters.Remove('StorageAccountResourceId')
            $hasArchiveNameFormat = $PSBoundParameters.Remove('ArchiveNameFormat')
            $hasBlobContainer = $PSBoundParameters.Remove('BlobContainer')
            $hasAsJob = $PSBoundParameters.Remove('AsJob')
            $null = $PSBoundParameters.Remove('WhatIf')
            $null = $PSBoundParameters.Remove('Confirm')

            $eventHub = Get-AzEventHub @PSBoundParameters

            # 2. PUT
            $null = $PSBoundParameters.Remove('InputObject')
            $null = $PSBoundParameters.Remove('ResourceGroupName')
            $null = $PSBoundParameters.Remove('NamespaceName')
            $null = $PSBoundParameters.Remove('Name')
            $null = $PSBoundParameters.Remove('SubscriptionId')

            $hasProperty = $false

            if ($hasCaptureEnabled) {
                $eventHub.CaptureEnabled = $CaptureEnabled
                $hasProperty = $true
            }

            if ($hasEncoding) {
                $eventHub.Encoding = $Encoding
                $hasProperty = $true
            }

            if ($hasIntervalInSeconds) {
                $eventHub.IntervalInSeconds = $IntervalInSeconds
                $hasProperty = $true
            }

            if ($hasSizeLimitInBytes) {
                $eventHub.SizeLimitInBytes = $SizeLimitInBytes
                $hasProperty = $true
            }

            if ($hasSkipEmptyArchive) {
                $eventHub.SkipEmptyArchive = $SkipEmptyArchive
                $hasProperty = $true
            }

            if($hasTombstoneRetentionTimeInHour) {
                $eventHub.TombstoneRetentionTimeInHour = $TombstoneRetentionTimeInHour
                $hasProperty = $true
            }

            if ($hasRetentionTimeInHour) {
                $eventHub.RetentionTimeInHour = $RetentionTimeInHour
                $hasProperty = $true
            }

            if ($hasStatus) {
                $eventHub.Status = $Status
                $hasProperty = $true
            }

            if ($hasDestinationName) {
                $eventHub.DestinationName = $DestinationName
                $hasProperty = $true
            }

            if ($hasStorageAccountResourceId) {
                $eventHub.StorageAccountResourceId = $StorageAccountResourceId
                $hasProperty = $true
            }

            if ($hasArchiveNameFormat) {
                $eventHub.ArchiveNameFormat = $ArchiveNameFormat
                $hasProperty = $true
            }

            if ($hasBlobContainer) {
                $eventHub.BlobContainer = $BlobContainer
                $hasProperty = $true
            }

            if (($hasProperty -eq $false) -and ($PSCmdlet.ParameterSetName -eq 'SetViaIdentityExpanded')){
                throw 'Please specify the property you want to update on the -InputObject. Refer https://go.microsoft.com/fwlink/?linkid=2204690#behavior-of--inputobject for example.'
            }

            if ($hasAsJob) {
                $PSBoundParameters.Add('AsJob', $true)
            }

            if ($PSCmdlet.ShouldProcess("EventHub Entity $($eventHub.Name)", "Create or update")) {
                Az.EventHub.private\New-AzEventHub_CreateViaIdentity -InputObject $eventHub -Parameter $eventHub @PSBoundParameters
            }
		}
		catch{
			throw
		}
	}
}
