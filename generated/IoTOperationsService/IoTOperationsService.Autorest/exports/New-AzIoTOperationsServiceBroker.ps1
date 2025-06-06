
# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# Code generated by Microsoft (R) AutoRest Code Generator.Changes may cause incorrect behavior and will be lost if the code
# is regenerated.
# ----------------------------------------------------------------------------------

<#
.Synopsis
create a BrokerResource
.Description
create a BrokerResource
.Example
New-AzIoTOperationsServiceBroker -InstanceName "aio-instance-name" -Name "my-broker" -ResourceGroupName "aio-validation-116116143" -ExtendedLocationName  "/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-116116143/providers/Microsoft.ExtendedLocation/customLocations/location-116116143" 

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IBrokerResource
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

DISKBACKEDMESSAGEBUFFER <IDiskBackedMessageBuffer>: Settings of Disk Backed Message Buffer.
  MaxSize <String>: The max size of the message buffer on disk. If a PVC template is specified using one of ephemeralVolumeClaimSpec or persistentVolumeClaimSpec, then this size is used as the request and limit sizes of that template. If neither ephemeralVolumeClaimSpec nor persistentVolumeClaimSpec are specified, then an emptyDir volume is mounted with this size as its limit. See <https://kubernetes.io/docs/concepts/storage/volumes/#emptydir> for details.
  [EphemeralVolumeClaimSpecAccessMode <List<String>>]: AccessModes contains the desired access modes the volume should have. More info: https://kubernetes.io/docs/concepts/storage/persistent-volumes#access-modes-1
  [EphemeralVolumeClaimSpecDataSourceApiGroup <String>]: APIGroup is the group for the resource being referenced. If APIGroup is not specified, the specified Kind must be in the core API group. For any other third-party types, APIGroup is required.
  [EphemeralVolumeClaimSpecDataSourceKind <String>]: Kind is the type of resource being referenced
  [EphemeralVolumeClaimSpecDataSourceName <String>]: Name is the name of resource being referenced
  [EphemeralVolumeClaimSpecDataSourceRefApiGroup <String>]: APIGroup is the group for the resource being referenced. If APIGroup is not specified, the specified Kind must be in the core API group. For any other third-party types, APIGroup is required.
  [EphemeralVolumeClaimSpecDataSourceRefKind <String>]: Kind is the type of resource being referenced
  [EphemeralVolumeClaimSpecDataSourceRefName <String>]: Name is the name of resource being referenced
  [EphemeralVolumeClaimSpecDataSourceRefNamespace <String>]: Namespace is the namespace of the resource being referenced. This field is required when the resource has a namespace.
  [EphemeralVolumeClaimSpecResourcesLimit <IVolumeClaimResourceRequirementsLimits>]: Limits describes the maximum amount of compute resources allowed. More info: https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/
    [(Any) <String>]: This indicates any property can be added to this object.
  [EphemeralVolumeClaimSpecResourcesRequest <IVolumeClaimResourceRequirementsRequests>]: Requests describes the minimum amount of compute resources required. If Requests is omitted for a container, it defaults to Limits if that is explicitly specified, otherwise to an implementation-defined value. More info: https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/
    [(Any) <String>]: This indicates any property can be added to this object.
  [EphemeralVolumeClaimSpecSelectorMatchExpression <List<IVolumeClaimSpecSelectorMatchExpressions>>]: MatchExpressions is a list of label selector requirements. The requirements are ANDed.
    Key <String>: key is the label key that the selector applies to.
    Operator <String>: operator represents a key's relationship to a set of values. Valid operators are In, NotIn, Exists and DoesNotExist.
    [Value <List<String>>]: values is an array of string values. If the operator is In or NotIn, the values array must be non-empty. If the operator is Exists or DoesNotExist, the values array must be empty. This array is replaced during a strategic merge patch.
  [EphemeralVolumeClaimSpecSelectorMatchLabel <IVolumeClaimSpecSelectorMatchLabels>]: MatchLabels is a map of {key,value} pairs. A single {key,value} in the matchLabels map is equivalent to an element of matchExpressions, whose key field is "key", the operator is "In", and the values array contains only "value". The requirements are ANDed.
    [(Any) <String>]: This indicates any property can be added to this object.
  [EphemeralVolumeClaimSpecStorageClassName <String>]: Name of the StorageClass required by the claim. More info: https://kubernetes.io/docs/concepts/storage/persistent-volumes#class-1
  [EphemeralVolumeClaimSpecVolumeMode <String>]: volumeMode defines what type of volume is required by the claim. Value of Filesystem is implied when not included in claim spec. This is a beta feature.
  [EphemeralVolumeClaimSpecVolumeName <String>]: VolumeName is the binding reference to the PersistentVolume backing this claim.
  [PersistentVolumeClaimSpecAccessMode <List<String>>]: AccessModes contains the desired access modes the volume should have. More info: https://kubernetes.io/docs/concepts/storage/persistent-volumes#access-modes-1
  [PersistentVolumeClaimSpecDataSourceApiGroup <String>]: APIGroup is the group for the resource being referenced. If APIGroup is not specified, the specified Kind must be in the core API group. For any other third-party types, APIGroup is required.
  [PersistentVolumeClaimSpecDataSourceKind <String>]: Kind is the type of resource being referenced
  [PersistentVolumeClaimSpecDataSourceName <String>]: Name is the name of resource being referenced
  [PersistentVolumeClaimSpecDataSourceRefApiGroup <String>]: APIGroup is the group for the resource being referenced. If APIGroup is not specified, the specified Kind must be in the core API group. For any other third-party types, APIGroup is required.
  [PersistentVolumeClaimSpecDataSourceRefKind <String>]: Kind is the type of resource being referenced
  [PersistentVolumeClaimSpecDataSourceRefName <String>]: Name is the name of resource being referenced
  [PersistentVolumeClaimSpecDataSourceRefNamespace <String>]: Namespace is the namespace of the resource being referenced. This field is required when the resource has a namespace.
  [PersistentVolumeClaimSpecResourcesLimit <IVolumeClaimResourceRequirementsLimits>]: Limits describes the maximum amount of compute resources allowed. More info: https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/
  [PersistentVolumeClaimSpecResourcesRequest <IVolumeClaimResourceRequirementsRequests>]: Requests describes the minimum amount of compute resources required. If Requests is omitted for a container, it defaults to Limits if that is explicitly specified, otherwise to an implementation-defined value. More info: https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/
  [PersistentVolumeClaimSpecSelectorMatchExpression <List<IVolumeClaimSpecSelectorMatchExpressions>>]: MatchExpressions is a list of label selector requirements. The requirements are ANDed.
  [PersistentVolumeClaimSpecSelectorMatchLabel <IVolumeClaimSpecSelectorMatchLabels>]: MatchLabels is a map of {key,value} pairs. A single {key,value} in the matchLabels map is equivalent to an element of matchExpressions, whose key field is "key", the operator is "In", and the values array contains only "value". The requirements are ANDed.
  [PersistentVolumeClaimSpecStorageClassName <String>]: Name of the StorageClass required by the claim. More info: https://kubernetes.io/docs/concepts/storage/persistent-volumes#class-1
  [PersistentVolumeClaimSpecVolumeMode <String>]: volumeMode defines what type of volume is required by the claim. Value of Filesystem is implied when not included in claim spec. This is a beta feature.
  [PersistentVolumeClaimSpecVolumeName <String>]: VolumeName is the binding reference to the PersistentVolume backing this claim.
.Link
https://learn.microsoft.com/powershell/module/az.iotoperationsservice/new-aziotoperationsservicebroker
#>
function New-AzIoTOperationsServiceBroker {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IBrokerResource])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Path')]
    [System.String]
    # Name of instance.
    ${InstanceName},

    [Parameter(Mandatory)]
    [Alias('BrokerName')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Path')]
    [System.String]
    # Name of broker.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    # The value must be an UUID.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.String]
    # The name of the extended location.
    ${ExtendedLocationName},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.PSArgumentCompleterAttribute("Enabled", "Disabled")]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.String]
    # The setting to enable or disable encryption of internal Traffic.
    ${AdvancedEncryptInternalTraffic},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.Int32]
    # The desired number of physical backend partitions.
    ${BackendChainPartition},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.Int32]
    # The desired numbers of backend replicas (pods) in a physical partition.
    ${BackendChainRedundancyFactor},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.Int32]
    # Number of logical backend workers per replica (pod).
    ${BackendChainWorker},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.Int32]
    # Upper bound of a client's Keep Alive, in seconds.
    ${ClientMaxKeepAliveSecond},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.Int32]
    # Upper bound of Message Expiry Interval, in seconds.
    ${ClientMaxMessageExpirySecond},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.Int32]
    # Max message size for a packet in Bytes.
    ${ClientMaxPacketSizeByte},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.Int32]
    # Upper bound of Receive Maximum that a client can request in the CONNECT packet.
    ${ClientMaxReceiveMaximum},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.Int32]
    # Upper bound of Session Expiry Interval, in seconds.
    ${ClientMaxSessionExpirySecond},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IDiskBackedMessageBuffer]
    # Settings of Disk Backed Message Buffer.
    ${DiskBackedMessageBuffer},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.Int32]
    # The desired number of frontend instances (pods).
    ${FrontendReplica},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.Int32]
    # Number of logical frontend workers per instance (pod).
    ${FrontendWorker},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.PSArgumentCompleterAttribute("Enabled", "Disabled")]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.String]
    # The toggle to enable/disable cpu resource limits.
    ${GenerateResourceLimitCpu},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.String]
    # Lifetime of certificate.
    # Must be specified using a Go time.Duration format (h|m|s).
    # E.g.
    # 240h for 240 hours and 45m for 45 minutes.
    ${InternalCertDuration},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.String]
    # When to begin renewing certificate.
    # Must be specified using a Go time.Duration format (h|m|s).
    # E.g.
    # 240h for 240 hours and 45m for 45 minutes.
    ${InternalCertRenewBefore},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.String]
    # The log level.
    # Examples - 'debug', 'info', 'warn', 'error', 'trace'.
    ${LogLevel},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.PSArgumentCompleterAttribute("Tiny", "Low", "Medium", "High")]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.String]
    # Memory profile of Broker.
    ${MemoryProfile},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.Int32]
    # The prometheus port to expose the metrics.
    ${MetricPrometheusPort},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.PSArgumentCompleterAttribute("Ec256", "Ec384", "Ec521", "Ed25519", "Rsa2048", "Rsa4096", "Rsa8192")]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.String]
    # algorithm for private key.
    ${PrivateKeyAlgorithm},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.PSArgumentCompleterAttribute("Always", "Never")]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.String]
    # cert-manager private key rotationPolicy.
    ${PrivateKeyRotationPolicy},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.Int32]
    # The self check interval.
    ${SelfCheckIntervalSecond},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.PSArgumentCompleterAttribute("Enabled", "Disabled")]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.String]
    # The toggle to enable/disable self check.
    ${SelfCheckMode},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.Int32]
    # The timeout for self check.
    ${SelfCheckTimeoutSecond},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.Int32]
    # The self tracing interval.
    ${SelfTracingIntervalSecond},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.PSArgumentCompleterAttribute("Enabled", "Disabled")]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.String]
    # The toggle to enable/disable self tracing.
    ${SelfTracingMode},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.Int64]
    # The maximum length of the queue before messages start getting dropped.
    ${SubscriberQueueLimitLength},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.PSArgumentCompleterAttribute("None", "DropOldest")]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.String]
    # The strategy to use for dropping messages from the queue.
    ${SubscriberQueueLimitStrategy},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.Int32]
    # The cache size in megabytes.
    ${TraceCacheSizeMegabyte},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.PSArgumentCompleterAttribute("Enabled", "Disabled")]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.String]
    # The toggle to enable/disable traces.
    ${TraceMode},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.Int32]
    # The span channel capacity.
    ${TraceSpanChannelCapacity},

    [Parameter(ParameterSetName='CreateViaJsonFilePath', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.String]
    # Path of Json file supplied to the Create operation
    ${JsonFilePath},

    [Parameter(ParameterSetName='CreateViaJsonString', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Body')]
    [System.String]
    # Json string supplied to the Create operation
    ${JsonString},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The DefaultProfile parameter is not functional.
    # Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        
        $testPlayback = $false
        $PSBoundParameters['HttpPipelinePrepend'] | Foreach-Object { if ($_) { $testPlayback = $testPlayback -or ('Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.PipelineMock' -eq $_.Target.GetType().FullName -and 'Playback' -eq $_.Target.Mode) } }

        $context = Get-AzContext
        if (-not $context -and -not $testPlayback) {
            Write-Error "No Azure login detected. Please run 'Connect-AzAccount' to log in."
            exit
        }

        if ($null -eq [Microsoft.WindowsAzure.Commands.Utilities.Common.AzurePSCmdlet]::PowerShellVersion) {
            [Microsoft.WindowsAzure.Commands.Utilities.Common.AzurePSCmdlet]::PowerShellVersion = $PSVersionTable.PSVersion.ToString()
        }         
        $preTelemetryId = [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId
        if ($preTelemetryId -eq '') {
            [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId =(New-Guid).ToString()
            [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.module]::Instance.Telemetry.Invoke('Create', $MyInvocation, $parameterSet, $PSCmdlet)
        } else {
            $internalCalledCmdlets = [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets
            if ($internalCalledCmdlets -eq '') {
                [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets = $MyInvocation.MyCommand.Name
            } else {
                [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets += ',' + $MyInvocation.MyCommand.Name
            }
            [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId = 'internal'
        }

        $mapping = @{
            CreateExpanded = 'Az.IoTOperationsService.private\New-AzIoTOperationsServiceBroker_CreateExpanded';
            CreateViaJsonFilePath = 'Az.IoTOperationsService.private\New-AzIoTOperationsServiceBroker_CreateViaJsonFilePath';
            CreateViaJsonString = 'Az.IoTOperationsService.private\New-AzIoTOperationsServiceBroker_CreateViaJsonString';
        }
        if (('CreateExpanded', 'CreateViaJsonFilePath', 'CreateViaJsonString') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId') ) {
            if ($testPlayback) {
                $PSBoundParameters['SubscriptionId'] = . (Join-Path $PSScriptRoot '..' 'utils' 'Get-SubscriptionIdTestSafe.ps1')
            } else {
                $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
            }
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
        if ($null -ne $MyInvocation.MyCommand -and [Microsoft.WindowsAzure.Commands.Utilities.Common.AzurePSCmdlet]::PromptedPreviewMessageCmdlets -notcontains $MyInvocation.MyCommand.Name -and [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.MessageAttributeHelper]::ContainsPreviewAttribute($cmdInfo, $MyInvocation)){
            [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.MessageAttributeHelper]::ProcessPreviewMessageAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
            [Microsoft.WindowsAzure.Commands.Utilities.Common.AzurePSCmdlet]::PromptedPreviewMessageCmdlets.Enqueue($MyInvocation.MyCommand.Name)
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        if ($wrappedCmd -eq $null) {
            $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Function)
        }
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
        throw
    }

    finally {
        $backupTelemetryId = [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId
        $backupInternalCalledCmdlets = [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
    }

}
end {
    try {
        $steppablePipeline.End()

        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId = $backupTelemetryId
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets = $backupInternalCalledCmdlets
        if ($preTelemetryId -eq '') {
            [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.module]::Instance.Telemetry.Invoke('Send', $MyInvocation, $parameterSet, $PSCmdlet)
            [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
        }
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId = $preTelemetryId

    } catch {
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
        throw
    }
} 
}
