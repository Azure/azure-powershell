### Example 1: Create a Virtual Machine with an Image. 
```powershell
New-AzStackHCIVMVirtualMachine -Name "testVm" -OsType "Linux"  -ImageName "testImage" -VmSize "Standard_K8S_v1"  -AdminUsername "localadmin" -ComputerName "testVm"  -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourcegroups/{resourceGroupName}/providers/microsoft.extendedlocation/customlocations/{customLocationName}"  -Location "eastus"
```
```output
Name            ResourceGroupName
----            -----------------
testVm          test-rg
```

This command creates a virtual machine from a gallery image. 

### Example 2: Create a Virtual Machine with a Disk. 
```powershell
New-AzStackHCIVMVirtualMachine -Name "testVm" -OsType "Linux" -OsDiskName "testOsDisk10" -VmSize "Standard_K8S_v1"  -AdminUsername "localadmin" -ComputerName "testVm" -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourcegroups/{resourceGroupName}/providers/microsoft.extendedlocation/customlocations/{customLocationName}" -Location "eastus"
```
```output
Name            ResourceGroupName
----            -----------------
testVm          test-rg
```
This command creates a virtual machine from a disk. 


