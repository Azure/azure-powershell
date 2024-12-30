---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridresourcemovechangehistoryobject
schema: 2.0.0
---

# New-AzEventGridResourceMoveChangeHistoryObject

## SYNOPSIS
Create an in-memory object for ResourceMoveChangeHistory.

## SYNTAX

```
New-AzEventGridResourceMoveChangeHistoryObject [-AzureSubscriptionId <String>] [-ChangedTimeUtc <DateTime>]
 [-ResourceGroupName <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ResourceMoveChangeHistory.

## EXAMPLES

### Example 1: Create an in-memory object for ResourceMoveChangeHistory.
```powershell
New-AzEventGridResourceMoveChangeHistoryObject -AzureSubscriptionId "{subId}" -ChangedTimeUtc "2023-12-10T11:06:13.109Z" -ResourceGroupName azps_test_group_eventgrid
```

```output
AzureSubscriptionId ChangedTimeUtc         ResourceGroupName
------------------- --------------         -----------------
{subId}             2023-12-10 07:06:13 PM azps_test_group_eventgrid2
```

Create an in-memory object for ResourceMoveChangeHistory.

## PARAMETERS

### -AzureSubscriptionId
Azure subscription ID of the resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChangedTimeUtc
UTC timestamp of when the resource was changed.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Azure Resource Group of the resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ResourceMoveChangeHistory

## NOTES

## RELATED LINKS
