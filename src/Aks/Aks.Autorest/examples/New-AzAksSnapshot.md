### Example 1: Creates or updates a snapshot
```powershell
$pool = Get-AzAksNodePool -ResourceGroupName mygroup -ClusterName mycluster -Name default
New-AzAksSnapshot -ResourceGroupName mygroup -ResourceName 'snapshot1' -Location eastus -SnapshotType 'NodePool' -CreationDataSourceResourceId $pool.Id
```

```output
Location Name      SystemDataCreatedAt   SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
-------- ----      -------------------   -------------------  ----------------------- ------------------------ ------------------------ ----------------------------
eastus   snapshot1 3/30/2023 10:24:43 AM user1@microsoft.com User                    3/30/2023 10:24:43 AM    user1@microsoft.com     User

```

Creates or updates a snapshot for a nodepool "default" of a managed cluster "mycluster".


