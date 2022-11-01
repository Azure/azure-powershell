### Example 1: Create or update a placement policy in a private cloud cluster
```powershell
$abc = New-AzVMwareVMPlacementPolicyPropertiesObject -AffinityType 'Affinity' -Type 'VmVm' -VMMember @{"test"="test"}
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
$abc = New-AzVMwareVmHostPlacementPolicyPropertiesObject -AffinityType 'AntiAffinity' -HostMember @{"test"="test"}  -Type 'VmHost' -VMMember @{"test"="test"}
New-AzVMwarePlacementPolicy -ClusterName cluster1 -Name policy1 -PrivateCloudName cloud1 -ResourceGroupName group1 -Property $abc
```
```output
Name    ResourceGroupName
----    -----------------
policy1 group1
```

Create or update a placement policy in a private cloud cluster