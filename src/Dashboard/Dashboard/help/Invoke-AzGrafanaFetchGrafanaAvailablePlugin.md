---
external help file: Az.Dashboard-help.xml
Module Name: Az.Dashboard
online version: https://learn.microsoft.com/powershell/module/az.dashboard/invoke-azgrafanafetchgrafanaavailableplugin
schema: 2.0.0
---

# Invoke-AzGrafanaFetchGrafanaAvailablePlugin

## SYNOPSIS
A synchronous resource action.

## SYNTAX

### Fetch (Default)
```
Invoke-AzGrafanaFetchGrafanaAvailablePlugin -ResourceGroupName <String> [-SubscriptionId <String>]
 -WorkspaceName <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### FetchViaIdentity
```
Invoke-AzGrafanaFetchGrafanaAvailablePlugin -InputObject <IDashboardIdentity> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
A synchronous resource action.

## EXAMPLES

### Example 1: Fetch available Grafana plugins for a workspace
```powershell
Invoke-AzGrafanaFetchGrafanaAvailablePlugin -ResourceGroupName azpstest-gp -WorkspaceName azpstest-grafana
```

```output
Name                     Version   Description
----                     -------   -----------
grafana-azure-monitor    1.0.0     Azure Monitor data source
grafana-image-renderer   3.0.0     Image rendering plugin
...
```

Fetches the list of available Grafana plugins that can be installed in the specified Azure Managed Grafana workspace.

### Example 2: Fetch available plugins using pipeline input
```powershell
Get-AzGrafana -ResourceGroupName azpstest-gp -Name azpstest-grafana | Invoke-AzGrafanaFetchGrafanaAvailablePlugin
```

```output
Name                     Version   Description
----                     -------   -----------
grafana-azure-monitor    1.0.0     Azure Monitor data source
grafana-image-renderer   3.0.0     Image rendering plugin
...
```

Fetches available Grafana plugins by piping a Grafana workspace object from Get-AzGrafana.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IDashboardIdentity
Parameter Sets: FetchViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Fetch
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Fetch
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
The workspace name of Azure Managed Grafana.

```yaml
Type: System.String
Parameter Sets: Fetch
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IDashboardIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IGrafanaAvailablePluginListResponse

## NOTES

## RELATED LINKS
