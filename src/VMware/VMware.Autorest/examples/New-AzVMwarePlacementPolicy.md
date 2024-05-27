### Example 1: Create or update a placement policy in a private cloud cluster
```powershell
$abc = New-AzVMwareVMPlacementPolicyPropertyObject -AffinityType 'Affinity' -VMMember @{"test"="test"}
New-AzVMwarePlacementPolicy -ClusterName cluster1 -Name policy1 -PrivateCloudName cloud1 -ResourceGroupName group1 -Property $abc
```
```output
Name    ResourceGroupName
----    -----------------
policy1 group1
```

Create or update a placement policy in a private cloud cluster

### Example 2: Create or update a placement policy in a private cloud cluster
```powershell
$abc = New-AzVMwareVmHostPlacementPolicyPropertyObject -AffinityType 'AntiAffinity' -HostMember @{"test"="test"} -VMMember @{"test"="test"}
New-AzVMwarePlacementPolicy -ClusterName cluster1 -Name policy1 -PrivateCloudName cloud1 -ResourceGroupName group1 -Property $abc
```
```output
Name    ResourceGroupName
----    -----------------
policy1 group1
```

Create or update a placement policy in a private cloud cluster