### Example 1: Delete a placement policy in a private cloud cluster
```powershell
Remove-AzVMwarePlacementPolicy -ClusterName cluster1 -Name policy1 -PrivateCloudName cloud1 -ResourceGroupName group1

```

Delete a placement policy in a private cloud cluster

### Example 2: Delete a placement policy in a private cloud cluster
```powershell
Get-AzVMwarePlacementPolicy -ClusterName cluster1 -Name policy1 -PrivateCloudName cloud1 -ResourceGroupName group1 | Remove-AzVMwarePlacementPolicy

```

Delete a placement policy in a private cloud cluster