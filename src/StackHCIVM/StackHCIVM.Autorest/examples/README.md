### Example 1: Add a Data Disk to a Virtual Machine
```powershell
 Add-AzStackHCIVMVirtualMachineDataDisk  -Name 'testVm' -ResourceGroupName 'test-rg'  -DataDiskName 'testVhd'

```
```output
Name            ResourceGroupName
----            -----------------
testVm          test-rg
```
This command attaches a data disk to the virtual machine in the specified resource group. 

