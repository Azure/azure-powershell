### Example 1: Removes a Network Interface from a  Virtual Machine
```powershell
Remove-AzStackHCIVmVirtualMachineNetworkInterface  -Name "testVm" -ResourceGroupName "test-rg"  -NicName 'testNic'

```
```output
Name            ResourceGroupName
----            -----------------
testVm          test-rg
```
This command removes a network interface from the virtual machine in the specified resource group. 
