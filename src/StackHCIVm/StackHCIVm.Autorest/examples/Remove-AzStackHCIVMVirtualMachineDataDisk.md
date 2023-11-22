### Example 1: Removes a Data Disk from a Virtual Machine
```powershell
Remove-AzStackHCIVMVirtualMachineDataDisk  -Name "testVm" -ResourceGroupName "test-rg"  -DataDiskName "testVhd"

```
```output
Name            ResourceGroupName
----            -----------------
testVm          test-rg
```
This command removes a data disk from the virtual machine in the specified resource group. 

