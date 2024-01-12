### Example 1: Add a Network Interface to a Virtual Machine
```powershell
Add-AzStackHCIVMVirtualMachineNetworkInterface  -Name 'testVm' -ResourceGroupName 'test-rg'  -NicName 'testNic'

```
```output
Name            ResourceGroupName
----            -----------------
testVm          test-rg
```
This command attaches a network interface to the virtual machine in the specified resource group. 

