---
external help file:
Module Name: Az.Dashboard
online version: https://learn.microsoft.com/powershell/module/az.dashboard/get-azgrafana
schema: 2.0.0
---

# Get-AzGrafana

## SYNOPSIS
Get the properties of a specific workspace for Grafana resource.

## SYNTAX

### List (Default)
```
Get-AzGrafana [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzGrafana -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzGrafana -InputObject <IDashboardIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzGrafana -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the properties of a specific workspace for Grafana resource.

## EXAMPLES

### Example 1: List the specific workspace.
```powershell
Get-AzGrafana
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azpstest-grafana      azpstest-gp
```

List the specific workspace.

### Example 2: Get the properties of a specific workspace for Resource Group.
```powershell
Get-AzGrafana -ResourceGroupName azpstest-gp
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azpstest-grafana      azpstest-gp
```

Get the properties of a specific workspace for Resource Group.

### Example 3: Get the properties of a specific workspace for Grafana resource.
```powershell
Get-AzGrafana -ResourceGroupName azpstest-gp -GrafanaName azpstest-grafana
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azpstest-grafana      azpstest-gp
```

Get the properties of a specific workspace for Grafana resource.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

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
The workspace name of Azure Managed Grafana.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: GrafanaName

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

### Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.Api20220801.IManagedGrafana

## NOTES

## RELATED LINKS

