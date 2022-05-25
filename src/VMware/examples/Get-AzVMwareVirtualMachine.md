### Example 1: List virtual machine in a private cloud cluster
```powershell
Get-AzVMwareVirtualMachine -ClusterName cluster1 -PrivateCloudName cloud1 -ResourceGroupName group1
```
```output
Name   ResourceGroupName
----   -----------------
vm-209 group1
vm-128 group1
```

List virtual machine in a private cloud cluster

### Example 2: Get a virtual machine by id in a private cloud cluster
```powershell
Get-AzVMwareVirtualMachine -Id vm-209 -ClusterName cluster1 -PrivateCloudName cloud1 -ResourceGroupName group1
```
```output
Name   ResourceGroupName
----   -----------------
vm-209 group1
```

Get a virtual machine by id in a private cloud cluster