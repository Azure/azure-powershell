---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azactiongroupitsmreceiverobject
schema: 2.0.0
---

# New-AzActionGroupItsmReceiverObject

## SYNOPSIS
Create an in-memory object for ItsmReceiver.

## SYNTAX

```
New-AzActionGroupItsmReceiverObject -ConnectionId <String> -Name <String> -Region <String>
 -TicketConfiguration <String> -WorkspaceId <String> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ItsmReceiver.

## EXAMPLES

### Example 1: create action group IT service management receiver
```powershell
New-AzActionGroupItsmReceiverObject -ConnectionId a3b9076c-ce8e-434e-85b4-aff10cb3c8f1 -Name "sample itsm" -Region "westcentralus" -TicketConfiguration "{ 'PayloadRevision':0, 'WorkItemType':'Incident', 'UseTemplate':false,'WorkItemData':'{}','CreateOneWIPerCI':false}" -WorkspaceId "5def922a-3ed4-49c1-b9fd-05ec533819a3|55dfd1f8-7e59-4f89-bf56-4c82f5ace23c"
```

```output
ConnectionId        : a3b9076c-ce8e-434e-85b4-aff10cb3c8f1
Name                : sample itsm
Region              : westcentralus
TicketConfiguration : { 'PayloadRevision':0, 'WorkItemType':'Incident', 'UseTemplate':false,'WorkItemData':'{}','CreateOneWIPerCI':false}
WorkspaceId         : 5def922a-3ed4-49c1-b9fd-05ec533819a3|55dfd1f8-7e59-4f89-bf56-4c82f5ace23c
```

This command creates action group IT Service Management receiver object.

## PARAMETERS

### -ConnectionId
Unique identification of ITSM connection among multiple defined in above workspace.

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

### -Name
The name of the Itsm receiver.
Names must be unique across all receivers within an action group.

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

### -Region
Region in which workspace resides.
Supported values:'centralindia','japaneast','southeastasia','australiasoutheast','uksouth','westcentralus','canadacentral','eastus','westeurope'.

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

### -TicketConfiguration
JSON blob for the configurations of the ITSM action.
CreateMultipleWorkItems option will be part of this blob as well.

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

### -WorkspaceId
OMS LA instance identifier.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.ItsmReceiver

## NOTES

## RELATED LINKS

