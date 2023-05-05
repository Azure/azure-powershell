---
external help file:
Module Name: Az.Aks
online version: https://learn.microsoft.com/powershell/module/az.aks/get-azakssnapshot
schema: 2.0.0
---

# Get-AzAksSnapshot

## SYNOPSIS
Gets a snapshot.

## SYNTAX

### List (Default)
```
Get-AzAksSnapshot [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzAksSnapshot -ResourceGroupName <String> -ResourceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAksSnapshot -InputObject <IAksIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzAksSnapshot -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a snapshot.

## EXAMPLES

### Example 1: List all AKS snapshots
```powershell
Get-AzAksSnapshot
```

```output
Location Name      SystemDataCreatedAt   SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
-------- ----      -------------------   -------------------  ----------------------- ------------------------ ------------------------ ----------------------------
eastus   snapshot1 3/30/2023 10:09:35 AM user1@microsoft.com User                    3/30/2023 10:09:35 AM    user1@microsoft.com     User
eastus   snapshot2 3/30/2023 10:09:38 AM user1@microsoft.com User                    3/30/2023 10:09:38 AM    user1@microsoft.com     User
eastus   snapshot3 3/30/2023 10:11:24 AM user1@microsoft.com User                    3/30/2023 10:11:24 AM    user1@microsoft.com     User
```



### Example 2: List all AKS snapshots in a resource group
```powershell
Get-AzAksSnapshot -ResourceGroupName mygroup
```

```output
Location Name      SystemDataCreatedAt   SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
-------- ----      -------------------   -------------------  ----------------------- ------------------------ ------------------------ ----------------------------
eastus   snapshot1 3/30/2023 10:09:35 AM user1@microsoft.com User                    3/30/2023 10:09:35 AM    user1@microsoft.com     User
eastus   snapshot2 3/30/2023 10:09:38 AM user1@microsoft.com User                    3/30/2023 10:09:38 AM    user1@microsoft.com     User
```



### Example 3: Get an AKS snapshot
```powershell
Get-AzAksSnapshot -ResourceGroupName mygroup -ResourceName 'snapshot1'
```

```output
Location Name      SystemDataCreatedAt   SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
-------- ----      -------------------   -------------------  ----------------------- ------------------------ ------------------------ ----------------------------
eastus   snapshot1 3/30/2023 10:09:35 AM user1@microsoft.com User                    3/30/2023 10:09:35 AM    user1@microsoft.com     User
```



### Example 4: Get an AKS snapshot via identity
```powershell
$pool = Get-AzAksNodePool -ResourceGroupName mygroup -ClusterName mycluster -Name default
$Snapshot = New-AzAksSnapshot -ResourceGroupName mygroup -ResourceName 'snapshot1' -Location eastus -SnapshotType 'NodePool' -CreationDataSourceResourceId $pool.Id
$Snapshot | Get-AzAksSnapshot
```

```output
Location Name      SystemDataCreatedAt   SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
-------- ----      -------------------   -------------------  ----------------------- ------------------------ ------------------------ ----------------------------
eastus   snapshot1 3/30/2023 10:09:35 AM user1@microsoft.com User                    3/30/2023 10:09:35 AM    user1@microsoft.com     User
```



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
Parameter Sets: Get, List1
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
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.ISnapshot

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

