### Example 1: Create a node pool with a custom OS disk size
```powershell
$subnetId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.Network/virtualNetworks/customer-vnet/subnets/customer-subnet-1"

New-AzRedHatOpenShiftHcpNodePool -ResourceGroupName myResourceGroup -HcpOpenShiftClusterName myCluster `
  -Name mynodepool -Location eastus `
  -VersionId '4.22.18' -VersionChannelGroup 'stable' `
  -PlatformVMSize 'Standard_D8s_v3' -Replica 2 `
  -PlatformSubnetId $subnetId `
  -OSDiskSizeGiB 128 -OSDiskStorageAccountType StandardSSD_LRS -OSDiskType Managed -AutoRepair
```

```output
Name        Location ProvisioningState Replica PlatformVMSize   OSDiskSizeGiB OSDiskStorageAccountType VersionId
----        -------- ----------------- ------- --------------   ------------- ------------------------ ---------
mynodepool  eastus   Succeeded         2       Standard_D8s_v3  128           StandardSSD_LRS          4.22.18
```

Creates a node pool named `mynodepool` on cluster `myCluster` with 2 replicas, `Standard_D8s_v3` VMs, and a 128 GiB managed OS disk. The node pool `-VersionId` must be a concrete `X.Y.Z` patch version (the RP does not resolve a bare `X.Y` for node pools).

### Example 2: Create an autoscaling node pool
```powershell
$subnetId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.Network/virtualNetworks/customer-vnet/subnets/customer-subnet-1"

New-AzRedHatOpenShiftHcpNodePool -ResourceGroupName myResourceGroup -HcpOpenShiftClusterName myCluster `
  -Name mynodepool -Location eastus `
  -VersionId '4.22.18' -VersionChannelGroup 'stable' `
  -PlatformVMSize 'Standard_D8s_v3' `
  -AutoScalingMin 2 -AutoScalingMax 6 `
  -PlatformSubnetId $subnetId `
  -OSDiskSizeGiB 64 -OSDiskStorageAccountType StandardSSD_LRS -OSDiskType Managed -AutoRepair
```

```output
Name        Location ProvisioningState AutoScalingMin AutoScalingMax PlatformVMSize   OSDiskSizeGiB VersionId
----        -------- ----------------- -------------- -------------- --------------   ------------- ---------
mynodepool  eastus   Succeeded         2              6              Standard_D8s_v3  64            4.22.18
```

Creates an autoscaling node pool that scales between 2 and 6 nodes. `-AutoScalingMin`/`-AutoScalingMax` are mutually exclusive with the fixed `-Replica` parameter.
