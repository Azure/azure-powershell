---
external help file: Microsoft.Azure.PowerShell.Cmdlets.IotHub.dll-Help.xml
Module Name: Az.IotHub
<<<<<<< HEAD
online version: https://docs.microsoft.com/en-us/powershell/module/az.iothub/get-aziothubeventhubconsumergroup
=======
online version: https://docs.microsoft.com/powershell/module/az.iothub/get-aziothubeventhubconsumergroup
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# Get-AzIotHubEventHubConsumerGroup

## SYNOPSIS
Gets all the eventhub consumergroups.

## SYNTAX

```
Get-AzIotHubEventHubConsumerGroup [-ResourceGroupName] <String> [-Name] <String>
<<<<<<< HEAD
 [-EventHubEndpointName] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
=======
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
```

## DESCRIPTION
Gets all the eventhub consumergroups for the different EventHubs used by IotHub.

## EXAMPLES

### Example 1 Gets all the eventhub consumergroups for the telemetry eventhub
```
<<<<<<< HEAD
PS C:\> Get-AzIotHubEventHubConsumerGroup -ResourceGroupName "myresourcegroup" -Name "myiothub" -EventHubEndpointName "events"
=======
PS C:\> Get-AzIotHubEventHubConsumerGroup -ResourceGroupName "myresourcegroup" -Name "myiothub"
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
```

Gets all the eventhub consumergroups for the telemetry eventhub for the iothub named myiothub

<<<<<<< HEAD
### Example 2 Gets all the eventhub consumergroups for the operationsmonitoring eventhub
```
PS C:\> Get-AzIotHubEventHubConsumerGroup -ResourceGroupName "myresourcegroup" -Name "myiothub" -EventHubEndpointName "operationsMonitoringEvents"
```

Gets all the eventhub consumergroups for the operationsMonitoringEvents eventhub for the iothub named myiothub

=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

<<<<<<< HEAD
### -EventHubEndpointName
Name of the Event Hub endpoint.
Possible values events, operationsMonitoringEvents

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: events, operationsMonitoringEvents

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
### -Name
Name of the IotHub

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Management.IotHub.Models.PSEventHubConsumerGroupInfo

## NOTES

## RELATED LINKS
