### Example 1: Update a placement policy in a private cloud cluster
```powershell
PS C:\> Update-AzVMwarePlacementPolicy -ClusterName cluster1 -Name policy1 -PrivateCloudName cloud1 -ResourceGroupName group1 -State 'Enabled'

Name    ResourceGroupName
----    -----------------
policy1 group1
```

Update a placement policy in a private cloud cluster

### Example 2: Update a placement policy in a private cloud cluster
```powershell
PS C:\> Get-AzVMwarePlacementPolicy -ClusterName cluster1 -Name policy1 -PrivateCloudName cloud1 -ResourceGroupName group1 | Update-AzVMwarePlacementPolicy -State 'Enabled'

Name    ResourceGroupName
----    -----------------
policy1 group1
```

Update a placement policy in a private cloud cluster