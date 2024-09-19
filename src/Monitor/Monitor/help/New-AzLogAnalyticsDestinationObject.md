---
external help file: Az.DataCollectionRule.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azloganalyticsdestinationobject
schema: 2.0.0
---

# New-AzLogAnalyticsDestinationObject

## SYNOPSIS
Create an in-memory object for LogAnalyticsDestination.

## SYNTAX

```
New-AzLogAnalyticsDestinationObject [-Name <String>] [-WorkspaceResourceId <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for LogAnalyticsDestination.

## EXAMPLES

### Example 1: Create a log analytics destination object
```powershell
New-AzLogAnalyticsDestinationObject -Name centralWorkspace -WorkspaceResourceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/sipstestcx9d03/providers/microsoft.operationalinsights/workspaces/asptest4k37qz
```

```output
Name             WorkspaceId WorkspaceResourceId
----             ----------- -------------------
centralWorkspace             /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/sipstestcx9d03/providers/microsoft.operationalinsights/workspaces/asptest4k…
```

This command creates a log analytics destination object.

## PARAMETERS

### -Name
A friendly name for the destination.
        This name should be unique across all destinations (regardless of type) within the data collection rule.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceResourceId
The resource ID of the Log Analytics workspace.

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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.LogAnalyticsDestination

## NOTES

## RELATED LINKS
