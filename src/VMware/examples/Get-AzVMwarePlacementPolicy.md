### Example 1: List
```powershell
PS C:\> Get-AzVMwarePlacementPolicy -ClusterName cluster1 -PrivateCloudName cloud1 -ResourceGroupName group1

Name    ResourceGroupName
----    -----------------
policy1 group1
policy2 group1
```

Get a placement policy by name in a private cloud cluster

### Example 2: Get
```powershell
PS C:\> Get-AzVMwarePlacementPolicy -ClusterName cluster1 -Name policy1 -PrivateCloudName cloud1 -ResourceGroupName group1

Name    ResourceGroupName
----    -----------------
policy1 group1
```

Get a placement policy by name in a private cloud cluster