### Example 1: List placement policy by private cloud cluster
```powershell
Get-AzVMwarePlacementPolicy -ClusterName cluster1 -PrivateCloudName cloud1 -ResourceGroupName group1
```
```output
Name    ResourceGroupName
----    -----------------
policy1 group1
policy2 group1
```

List placement policy by private cloud cluster

### Example 2: Get a placement policy by name in a private cloud cluster
```powershell
Get-AzVMwarePlacementPolicy -ClusterName cluster1 -Name policy1 -PrivateCloudName cloud1 -ResourceGroupName group1
```
```output
Name    ResourceGroupName
----    -----------------
policy1 group1
```

Get a placement policy by name in a private cloud cluster