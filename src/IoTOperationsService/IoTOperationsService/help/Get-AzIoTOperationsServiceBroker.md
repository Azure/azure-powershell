---
external help file: Az.IoTOperationsService-help.xml
Module Name: Az.IoTOperationsService
online version: https://learn.microsoft.com/powershell/module/az.iotoperationsservice/get-aziotoperationsservicebroker
schema: 2.0.0
---

# Get-AzIoTOperationsServiceBroker

## SYNOPSIS
Get a BrokerResource

## SYNTAX

### List (Default)
```
Get-AzIoTOperationsServiceBroker -InstanceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzIoTOperationsServiceBroker -InstanceName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityInstance
```
Get-AzIoTOperationsServiceBroker -Name <String> -InstanceInputObject <IIoTOperationsServiceIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzIoTOperationsServiceBroker -InputObject <IIoTOperationsServiceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a BrokerResource

## EXAMPLES

### Example 1: List Broker
```powershell
Get-AzIoTOperationsServiceBroker -InstanceName "aio-3lrx4" -ResourceGroupName "aio-validation-117026523"
```

```output
AdvancedEncryptInternalTraffic : Enabled
BackendChainPartition          : 2
BackendChainRedundancyFactor   : 2
BackendChainWorker             : 2
ClientMaxKeepAliveSecond       :
ClientMaxMessageExpirySecond   :
ClientMaxPacketSizeByte        :
ClientMaxReceiveMaximum        :
ClientMaxSessionExpirySecond   :
DiskBackedMessageBuffer        : {
                                 }
ExtendedLocationName           : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117026523/providers/Mi
                                 crosoft.ExtendedLocation/customLocations/location-3lrx4
ExtendedLocationType           : CustomLocation
FrontendReplica                : 2
FrontendWorker                 : 2
GenerateResourceLimitCpu       : Disabled
Id                             : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117026523/providers/Mi
                                 crosoft.IoTOperations/instances/aio-3lrx4/brokers/default
InternalCertDuration           :
InternalCertRenewBefore        :
LogLevel                       : info
MemoryProfile                  : Medium
MetricPrometheusPort           : 9600
Name                           : default
PrivateKeyAlgorithm            :
PrivateKeyRotationPolicy       :
ProvisioningState              : Succeeded
ResourceGroupName              : aio-validation-117026523
SelfCheckIntervalSecond        : 30
SelfCheckMode                  : Enabled
SelfCheckTimeoutSecond         : 15
SelfTracingIntervalSecond      : 30
SelfTracingMode                : Enabled
SubscriberQueueLimitLength     :
SubscriberQueueLimitStrategy   :
SystemDataCreatedAt            : 3/5/2025 5:07:34 PM
SystemDataCreatedBy            : 739f5293-922a-4616-b106-3662530ef99f
SystemDataCreatedByType        : Application
SystemDataLastModifiedAt       : 3/5/2025 6:28:37 PM
SystemDataLastModifiedBy       : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType   : Application
TraceCacheSizeMegabyte         : 16
TraceMode                      : Enabled
TraceSpanChannelCapacity       : 1000
Type                           : microsoft.iotoperations/instances/brokers
```

This command gets a list of brokers

## PARAMETERS

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity
Parameter Sets: GetViaIdentityInstance
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceName
Name of instance.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of broker.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityInstance
Aliases: BrokerName

Required: True
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
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IBrokerResource

## NOTES

## RELATED LINKS
