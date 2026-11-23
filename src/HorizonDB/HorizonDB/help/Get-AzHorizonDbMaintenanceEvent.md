---
external help file: Az.HorizonDB-help.xml
Module Name: Az.HorizonDB
online version: https://learn.microsoft.com/powershell/module/az.horizondb/get-azhorizondbmaintenanceevent
schema: 2.0.0
---

# Get-AzHorizonDbMaintenanceEvent

## SYNOPSIS
Gets information about a maintenance event for a HorizonDB pool.

## SYNTAX

### List (Default)
```
Get-AzHorizonDbMaintenanceEvent -ClusterName <String> -PoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzHorizonDbMaintenanceEvent -ClusterName <String> -Id <String> -PoolName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityPool
```
Get-AzHorizonDbMaintenanceEvent -Id <String> -PoolInputObject <IHorizonDbIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityCluster
```
Get-AzHorizonDbMaintenanceEvent -Id <String> -PoolName <String> -ClusterInputObject <IHorizonDbIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzHorizonDbMaintenanceEvent -InputObject <IHorizonDbIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets information about a maintenance event for a HorizonDB pool.

## EXAMPLES

### Example 1: List pool maintenance events
```powershell
Get-AzHorizonDbMaintenanceEvent -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -PoolName 'example-pool-01' | Format-List -Property Name, MaintenanceType, Status, StartTimeUtc, EndTimeUtc
```

```output
Name            : ABCD-123
MaintenanceType : PlannedMaintenance
Status          : Planned
StartTimeUtc    : 08/12/2026 07:00:00
EndTimeUtc      : 08/12/2026 08:00:00

Name            : EFGH-456
MaintenanceType : PlannedMaintenance
Status          : Planned
StartTimeUtc    : 08/19/2026 07:00:00
EndTimeUtc      : 08/19/2026 08:00:00
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Get a maintenance event
```powershell
Get-AzHorizonDbMaintenanceEvent -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -PoolName 'example-pool-01' -Id 'ABCD-123' | Format-List -Property Name, MaintenanceType, Status, StartTimeUtc, EndTimeUtc
```

```output
Name            : ABCD-123
MaintenanceType : PlannedMaintenance
Status          : Planned
StartTimeUtc    : 08/12/2026 07:00:00
EndTimeUtc      : 08/12/2026 08:00:00
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 3: Filter maintenance events by status
```powershell
Get-AzHorizonDbMaintenanceEvent -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -PoolName 'example-pool-01' -Filter "properties/status eq 'Planned' or properties/status eq 'InProgress'" | Format-List -Property Name, MaintenanceType, Status, StartTimeUtc, EndTimeUtc
```

```output
Name            : ABCD-123
MaintenanceType : PlannedMaintenance
Status          : Planned
StartTimeUtc    : 08/12/2026 07:00:00
EndTimeUtc      : 08/12/2026 08:00:00
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

## PARAMETERS

### -ClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: GetViaIdentityCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterName
The name of the HorizonDB cluster.

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

### -Filter
The OData filter expression to apply to the list operation.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The identifier of the maintenance event.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityPool, GetViaIdentityCluster
Aliases: MaintenanceEventId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PoolInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: GetViaIdentityPool
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PoolName
The name of the HorizonDB pool.

```yaml
Type: System.String
Parameter Sets: List, Get, GetViaIdentityCluster
Aliases:

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
The value must be an UUID.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IMaintenanceEvent

## NOTES

## RELATED LINKS
