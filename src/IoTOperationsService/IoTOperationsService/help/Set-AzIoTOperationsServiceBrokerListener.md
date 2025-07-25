---
external help file: Az.IoTOperationsService-help.xml
Module Name: Az.IoTOperationsService
online version: https://learn.microsoft.com/powershell/module/az.iotoperationsservice/set-aziotoperationsservicebrokerlistener
schema: 2.0.0
---

# Set-AzIoTOperationsServiceBrokerListener

## SYNOPSIS
update a BrokerListenerResource

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzIoTOperationsServiceBrokerListener -BrokerName <String> -InstanceName <String> -ListenerName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -ExtendedLocationName <String>
 [-Port <IListenerPort[]>] [-ServiceName <String>] [-ServiceType <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Set-AzIoTOperationsServiceBrokerListener -BrokerName <String> -InstanceName <String> -ListenerName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Set-AzIoTOperationsServiceBrokerListener -BrokerName <String> -InstanceName <String> -ListenerName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
update a BrokerListenerResource

## EXAMPLES

### Example 1: Update a Broker Listener
```powershell
Set-AzIoTOperationsServiceBrokerListener -BrokerName "my-broker" -InstanceName "aio-instance-name" -ListenerName my-listener -ResourceGroupName "aio-validation-116116143" -ExtendedLocationName  "/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-116116143/providers/Microsoft.ExtendedLocation/customLocations/location-116116143"  -Port @(@{ port = 1883 })
```

```output
ExtendedLocationName         : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/reso
                               urceGroups/aio-validation-116116143/providers/Microsoft.
                               ExtendedLocation/customLocations/location-116116143
ExtendedLocationType         : CustomLocation
Id                           : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/reso
                               urceGroups/aio-validation-116116143/providers/Microsoft.
                               IoTOperations/instances/aio-instance-name/brokers/my-bro
                               ker/listeners/my-listener
Name                         : my-listener
Port                         : {{
                                 "port": 1883,
                                 "protocol": "Mqtt"
                               }}
ProvisioningState            : Succeeded
ResourceGroupName            : aio-validation-116116143
ServiceName                  :
ServiceType                  : ClusterIp
SystemDataCreatedAt          : 3/5/2025 10:23:16 PM
SystemDataCreatedBy          : henrymorales@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/5/2025 10:23:21 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Type                         : microsoft.iotoperations/instances/brokers/listeners
```

Update a broker listener

## PARAMETERS

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

### -BrokerName
Name of broker.

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

### -ExtendedLocationName
The name of the extended location.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
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

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
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
Parameter Sets: (All)
Aliases:

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

### -Port
Ports on which this listener accepts client connections.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IListenerPort[]
Parameter Sets: UpdateExpanded
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

### -ServiceName
Kubernetes Service name of this listener.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceType
Kubernetes Service type of this listener.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IBrokerListenerResource

## NOTES

## RELATED LINKS
