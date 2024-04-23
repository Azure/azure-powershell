---
external help file: Az.Dashboard-help.xml
Module Name: Az.Dashboard
online version: https://learn.microsoft.com/powershell/module/az.dashboard/new-azgrafanamonitorworkspaceintegrationobject
schema: 2.0.0
---

# New-AzGrafanaMonitorWorkspaceIntegrationObject

## SYNOPSIS
Create an in-memory object for AzureMonitorWorkspaceIntegration.

## SYNTAX

```
New-AzGrafanaMonitorWorkspaceIntegrationObject [-AzureMonitorWorkspaceResourceId <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureMonitorWorkspaceIntegration.

## EXAMPLES

### Example 1: Create an AzureMonitorWorkspaceIntegration for Grafana.
```powershell
New-AzGrafanaMonitorWorkspaceIntegrationObject -AzureMonitorWorkspaceResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myResourceGroup/providers/microsoft.monitor/accounts/myAzureMonitorWorkspace"
```

```output
AzureMonitorWorkspaceResourceId
-------------------------------
/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myResourceGroup/providers/microsoft.monitor/accounts/myAzureMonitorWorkspace
```

Create an AzureMonitorWorkspaceIntegration for Grafana.

## PARAMETERS

### -AzureMonitorWorkspaceResourceId
The resource Id of the connected Azure Monitor Workspace.

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

### Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.Api20220801.AzureMonitorWorkspaceIntegration

## NOTES

## RELATED LINKS
