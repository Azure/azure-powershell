### Example 1: Add a Data Disk to a Virtual Machine
```powershell
PS C:\> Add-AzStackHCIVmVirtualMachineDataDisk  -Name "testVm" -ResourceGroupName "test-rg"  -DataDiskName "testVhd"
```
This command attaches a data disk to the virtual machine in the specified resource group. 

