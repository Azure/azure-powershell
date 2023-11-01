### Example 1: Removes a Network Interface from a  Virtual Machine
```powershell
Remove-AzStackHCIVMVirtualMachineNic  -Name "testVm" -ResourceGroupName "test-rg"  -NicNames "testNic"

```
```output
Name            ResourceGroupName
----            -----------------
testVm          test-rg
```
This command removes a network interface from the virtual machine in the specified resource group. 
