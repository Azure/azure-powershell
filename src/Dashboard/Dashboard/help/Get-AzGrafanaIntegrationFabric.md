---
external help file: Az.Dashboard-help.xml
Module Name: Az.Dashboard
online version: https://learn.microsoft.com/powershell/module/az.dashboard/get-azgrafanaintegrationfabric
schema: 2.0.0
---

# Get-AzGrafanaIntegrationFabric

## SYNOPSIS
Get a IntegrationFabric

## SYNTAX

### List (Default)
```
Get-AzGrafanaIntegrationFabric -ResourceGroupName <String> [-SubscriptionId <String[]>] -WorkspaceName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityGrafana
```
Get-AzGrafanaIntegrationFabric -Name <String> -GrafanaInputObject <IDashboardIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzGrafanaIntegrationFabric -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -WorkspaceName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzGrafanaIntegrationFabric -InputObject <IDashboardIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a IntegrationFabric

## EXAMPLES

### Example 1: List all Grafana integration fabrics in a workspace
```powershell
Get-AzGrafanaIntegrationFabric -ResourceGroupName azpstest-gp -WorkspaceName azpstest-grafana
```

```output
Name                Location ResourceGroupName
----                -------- -----------------
fabric-integration1 eastus   azpstest-gp
fabric-integration2 eastus   azpstest-gp
```

Lists all integration fabrics for the specified Azure Managed Grafana workspace.

### Example 2: Get a specific Grafana integration fabric
```powershell
Get-AzGrafanaIntegrationFabric -Name fabric-integration1 -ResourceGroupName azpstest-gp -WorkspaceName azpstest-grafana
```

```output
Name                Location ResourceGroupName
----                -------- -----------------
fabric-integration1 eastus   azpstest-gp
```

Gets the properties of a specific integration fabric in an Azure Managed Grafana workspace.

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

### -GrafanaInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IDashboardIdentity
Parameter Sets: GetViaIdentityGrafana
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
The integration fabric name of Azure Managed Grafana.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityGrafana, Get
Aliases: IntegrationFabricName

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

### -WorkspaceName
The workspace name of Azure Managed Grafana.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IDashboardIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IIntegrationFabric

## NOTES

## RELATED LINKS
