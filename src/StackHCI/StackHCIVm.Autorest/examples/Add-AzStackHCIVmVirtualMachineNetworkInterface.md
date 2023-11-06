### Example 1: Add a Network Interface to a Virtual Machine
```powershell
PS C:\> Add-AzStackHCIVmVirtualMachineNetworkInterface  -Name "testVm" -ResourceGroupName "test-rg"  -DataDiskNames "testNic"
Name            ResourceGroupName
----            -----------------
testVm          test-rg
```
This command attaches a network interface to the virtual machine in the specified resource group. 

