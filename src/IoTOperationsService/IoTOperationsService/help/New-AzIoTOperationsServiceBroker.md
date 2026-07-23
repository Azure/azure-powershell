---
external help file: Az.IoTOperationsService-help.xml
Module Name: Az.IoTOperationsService
online version: https://learn.microsoft.com/powershell/module/az.iotoperationsservice/new-aziotoperationsservicebroker
schema: 2.0.0
---

# New-AzIoTOperationsServiceBroker

## SYNOPSIS
create a BrokerResource

## SYNTAX

### CreateExpanded (Default)
```
New-AzIoTOperationsServiceBroker -InstanceName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -ExtendedLocationName <String> [-AdvancedEncryptInternalTraffic <String>]
 [-BackendChainPartition <Int32>] [-BackendChainRedundancyFactor <Int32>] [-BackendChainWorker <Int32>]
 [-ClientMaxKeepAliveSecond <Int32>] [-ClientMaxMessageExpirySecond <Int32>] [-ClientMaxPacketSizeByte <Int32>]
 [-ClientMaxReceiveMaximum <Int32>] [-ClientMaxSessionExpirySecond <Int32>]
 [-DiskBackedMessageBuffer <IDiskBackedMessageBuffer>] [-FrontendReplica <Int32>] [-FrontendWorker <Int32>]
 [-GenerateResourceLimitCpu <String>] [-InternalCertDuration <String>] [-InternalCertRenewBefore <String>]
 [-LogLevel <String>] [-MemoryProfile <String>] [-MetricPrometheusPort <Int32>] [-PrivateKeyAlgorithm <String>]
 [-PrivateKeyRotationPolicy <String>] [-SelfCheckIntervalSecond <Int32>] [-SelfCheckMode <String>]
 [-SelfCheckTimeoutSecond <Int32>] [-SelfTracingIntervalSecond <Int32>] [-SelfTracingMode <String>]
 [-SubscriberQueueLimitLength <Int64>] [-SubscriberQueueLimitStrategy <String>]
 [-TraceCacheSizeMegabyte <Int32>] [-TraceMode <String>] [-TraceSpanChannelCapacity <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzIoTOperationsServiceBroker -InstanceName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzIoTOperationsServiceBroker -InstanceName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
create a BrokerResource

## EXAMPLES

### Example 1: Create a Broker
```powershell
New-AzIoTOperationsServiceBroker -InstanceName "aio-instance-name" -Name "my-broker" -ResourceGroupName "aio-validation-116116143" -ExtendedLocationName  "/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-116116143/providers/Microsoft.ExtendedLocation/customLocations/location-116116143"
```

```output
AdvancedEncryptInternalTraffic : Enabled
BackendChainPartition          : 0
BackendChainRedundancyFactor   : 0
BackendChainWorker             :
ClientMaxKeepAliveSecond       :
ClientMaxMessageExpirySecond   :
ClientMaxPacketSizeByte        :
ClientMaxReceiveMaximum        :
ClientMaxSessionExpirySecond   :
DiskBackedMessageBuffer        : {
                                 }
ExtendedLocationName           : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-
                                 116116143/providers/Microsoft.ExtendedLocation/customLocations/location-116116143
ExtendedLocationType           : CustomLocation
FrontendReplica                : 0
FrontendWorker                 :
GenerateResourceLimitCpu       :
Id                             : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-
                                 116116143/providers/Microsoft.IoTOperations/instances/aio-instance-name/brokers/my
                                 -broker
InternalCertDuration           :
InternalCertRenewBefore        :
LogLevel                       : info
MemoryProfile                  : Medium
MetricPrometheusPort           : 9600
Name                           : my-broker
PrivateKeyAlgorithm            :
PrivateKeyRotationPolicy       :
ProvisioningState              : Succeeded
ResourceGroupName              : aio-validation-116116143
SelfCheckIntervalSecond        : 30
SelfCheckMode                  : Enabled
SelfCheckTimeoutSecond         : 15
SelfTracingIntervalSecond      : 30
SelfTracingMode                : Enabled
SubscriberQueueLimitLength     :
SubscriberQueueLimitStrategy   :
SystemDataCreatedAt            : 3/5/2025 10:00:59 PM
SystemDataCreatedBy            : henrymorales@microsoft.com
SystemDataCreatedByType        : User
SystemDataLastModifiedAt       : 3/5/2025 10:01:11 PM
SystemDataLastModifiedBy       : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType   : Application
TraceCacheSizeMegabyte         : 16
TraceMode                      : Enabled
TraceSpanChannelCapacity       : 1000
Type                           : microsoft.iotoperations/instances/brokers
```

Create a Broker

## PARAMETERS

### -AdvancedEncryptInternalTraffic
The setting to enable or disable encryption of internal Traffic.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackendChainPartition
The desired number of physical backend partitions.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackendChainRedundancyFactor
The desired numbers of backend replicas (pods) in a physical partition.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackendChainWorker
Number of logical backend workers per replica (pod).

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientMaxKeepAliveSecond
Upper bound of a client's Keep Alive, in seconds.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientMaxMessageExpirySecond
Upper bound of Message Expiry Interval, in seconds.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientMaxPacketSizeByte
Max message size for a packet in Bytes.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientMaxReceiveMaximum
Upper bound of Receive Maximum that a client can request in the CONNECT packet.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientMaxSessionExpirySecond
Upper bound of Session Expiry Interval, in seconds.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskBackedMessageBuffer
Settings of Disk Backed Message Buffer.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IDiskBackedMessageBuffer
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationName
The name of the extended location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FrontendReplica
The desired number of frontend instances (pods).

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FrontendWorker
Number of logical frontend workers per instance (pod).

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GenerateResourceLimitCpu
The toggle to enable/disable cpu resource limits.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstanceName
Name of instance.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InternalCertDuration
Lifetime of certificate.
Must be specified using a Go time.Duration format (h|m|s).
E.g.
240h for 240 hours and 45m for 45 minutes.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InternalCertRenewBefore
When to begin renewing certificate.
Must be specified using a Go time.Duration format (h|m|s).
E.g.
240h for 240 hours and 45m for 45 minutes.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogLevel
The log level.
Examples - 'debug', 'info', 'warn', 'error', 'trace'.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MemoryProfile
Memory profile of Broker.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetricPrometheusPort
The prometheus port to expose the metrics.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of broker.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: BrokerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateKeyAlgorithm
algorithm for private key.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateKeyRotationPolicy
cert-manager private key rotationPolicy.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SelfCheckIntervalSecond
The self check interval.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SelfCheckMode
The toggle to enable/disable self check.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SelfCheckTimeoutSecond
The timeout for self check.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SelfTracingIntervalSecond
The self tracing interval.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SelfTracingMode
The toggle to enable/disable self tracing.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriberQueueLimitLength
The maximum length of the queue before messages start getting dropped.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriberQueueLimitStrategy
The strategy to use for dropping messages from the queue.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TraceCacheSizeMegabyte
The cache size in megabytes.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TraceMode
The toggle to enable/disable traces.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TraceSpanChannelCapacity
The span channel capacity.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IBrokerResource

## NOTES

## RELATED LINKS
