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


