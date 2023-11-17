---
external help file:
Module Name: Az.Aks
online version: https://learn.microsoft.com/powershell/module/az.aks/get-azaksmaintenanceconfiguration
schema: 2.0.0
---

# Get-AzAksMaintenanceConfiguration

## SYNOPSIS
Gets the specified maintenance configuration of a managed cluster.

## SYNTAX

### List (Default)
```
Get-AzAksMaintenanceConfiguration -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzAksMaintenanceConfiguration -ConfigName <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAksMaintenanceConfiguration -InputObject <IAksIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the specified maintenance configuration of a managed cluster.

## EXAMPLES

### Example 1: List all maintenance configurations for a managed cluster
```powershell
Get-AzAksMaintenanceConfiguration -ResourceGroupName mygroup -ResourceName myCluster
```

```output
Name
----
aks_maintenance_config1
aks_maintenance_config2
```

List all maintenance configurations for a managed cluster "myCluster".

### Example 2: Get a maintenance configuration with its config name
```powershell
Get-AzAksMaintenanceConfiguration -ResourceGroupName mygroup -ResourceName myCluster -ConfigName 'aks_maintenance_config'
```

```output
Name
----
aks_maintenance_config1
```

Get a maintenance configuration with name "aks_maintenance_config" for a managed cluster "myCluster".

### Example 3: Get a maintenance configuration via identity
```powershell
$TimeSpan = New-AzAksTimeSpanObject -Start (Get-Date -Year 2023 -Month 3 -Day 1) -End (Get-Date -Year 2023 -Month 3 -Day 2)
$TimeInWeek = New-AzAksTimeInWeekObject -Day 'Sunday' -HourSlot 1,2
$MaintenanceConfig = New-AzAksMaintenanceConfiguration -ResourceGroupName mygroup -ResourceName myCluster -ConfigName 'aks_maintenance_config' -TimeInWeek $TimeInWeek -NotAllowedTime $TimeSpan
$MaintenanceConfig | Get-AzAksMaintenanceConfiguration
```

```output
Name
----
aks_maintenance_config
```

Get a maintenance configuration via identity for a managed cluster "myCluster".

## PARAMETERS

### -ConfigName
The name of the maintenance configuration.

```yaml
Type: System.String
Parameter Sets: Get
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAksIdentity
Parameter Sets: GetViaIdentity
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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The name of the managed cluster resource.

```yaml
Type: System.String
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IMaintenanceConfiguration

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IAksIdentity>`: Identity Parameter
  - `[AgentPoolName <String>]`: The name of the agent pool.
  - `[CommandId <String>]`: Id of the command.
  - `[ConfigName <String>]`: The name of the maintenance configuration.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The name of Azure region.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ResourceName <String>]`: The name of the managed cluster resource.
  - `[RoleName <String>]`: The name of the role for managed cluster accessProfile resource.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

