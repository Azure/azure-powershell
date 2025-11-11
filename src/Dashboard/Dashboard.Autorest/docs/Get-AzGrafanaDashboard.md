---
external help file:
Module Name: Az.Dashboard
online version: https://learn.microsoft.com/powershell/module/az.dashboard/get-azgrafanadashboard
schema: 2.0.0
---

# Get-AzGrafanaDashboard

## SYNOPSIS
Get the properties of a specific dashboard for grafana resource.

## SYNTAX

### List (Default)
```
Get-AzGrafanaDashboard [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzGrafanaDashboard -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzGrafanaDashboard -InputObject <IDashboardIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzGrafanaDashboard -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the properties of a specific dashboard for grafana resource.

## EXAMPLES

### Example 1: List all Grafana dashboards in a subscription.
```powershell
Get-AzGrafanaDashboard
```

```output
Name                     Location ResourceGroupName
----                     -------- -----------------
dashboard-01             eastus   azpstest-gp
dashboard-02             eastus   azpstest-gp
```

Lists all Azure Managed Grafana dashboards in the current subscription.

### Example 2: List all Grafana dashboards in a resource group
```powershell
Get-AzGrafanaDashboard -ResourceGroupName azpstest-gp
```

```output
Name                     Location ResourceGroupName
----                     -------- -----------------
dashboard-01             eastus   azpstest-gp
dashboard-02             eastus   azpstest-gp
```

Lists all Azure Managed Grafana dashboards in the specified resource group.

### Example 3: Get a specific Grafana dashboard
```powershell
Get-AzGrafanaDashboard -ResourceGroupName azpstest-gp -Name dashboard-01
```

```output
Name                     Location ResourceGroupName
----                     -------- -----------------
dashboard-01             eastus   azpstest-gp
```

Gets the properties of a specific Azure Managed Grafana dashboard.

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
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Azure Managed Dashboard.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: DashboardName

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
Parameter Sets: Get, List1
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
Type: System.String[]
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IDashboardIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IManagedDashboard

## NOTES

## RELATED LINKS

