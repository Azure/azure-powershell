---
external help file: Az.IoTOperationsService-help.xml
Module Name: Az.IoTOperationsService
online version: https://learn.microsoft.com/powershell/module/az.iotoperationsservice/get-aziotoperationsservicebrokerlistener
schema: 2.0.0
---

# Get-AzIoTOperationsServiceBrokerListener

## SYNOPSIS
Get a BrokerListenerResource

## SYNTAX

### List (Default)
```
Get-AzIoTOperationsServiceBrokerListener -BrokerName <String> -InstanceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityInstance
```
Get-AzIoTOperationsServiceBrokerListener -BrokerName <String> -ListenerName <String>
 -InstanceInputObject <IIoTOperationsServiceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzIoTOperationsServiceBrokerListener -BrokerName <String> -InstanceName <String> -ListenerName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityBroker
```
Get-AzIoTOperationsServiceBrokerListener -ListenerName <String>
 -BrokerInputObject <IIoTOperationsServiceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzIoTOperationsServiceBrokerListener -InputObject <IIoTOperationsServiceIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a BrokerListenerResource

## EXAMPLES

### Example 1: List Broker Listeners
```powershell
Get-AzIoTOperationsServiceBrokerListener -BrokerName "default" -InstanceName "aio-3lrx4" -ResourceGroupName "aio-validation-117026523"
```

```output
Name          SystemDataCreatedAt SystemDataCreatedBy                  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastMod
                                                                                                                        ifiedBy
----          ------------------- -------------------                  ----------------------- ------------------------ -----------------
default       3/5/2025 5:08:41 PM 739f5293-922a-4616-b106-3662530ef99f Application             3/5/2025 5:29:55 PM      319f651f-7ddb-4f…
test-listener 3/5/2025 5:17:15 PM 739f5293-922a-4616-b106-3662530ef99f Application             3/5/2025 5:29:55 PM      319f651f-7ddb-4f…
```

This command gets a list of broker listeners

## PARAMETERS

### -BrokerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity
Parameter Sets: GetViaIdentityBroker
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -BrokerName
Name of broker.

```yaml
Type: System.String
Parameter Sets: List, GetViaIdentityInstance, Get
Aliases:

Required: True
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

### -ListenerName
Name of Instance broker listener resource

```yaml
Type: System.String
Parameter Sets: GetViaIdentityInstance, Get, GetViaIdentityBroker
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IBrokerListenerResource

## NOTES

## RELATED LINKS
