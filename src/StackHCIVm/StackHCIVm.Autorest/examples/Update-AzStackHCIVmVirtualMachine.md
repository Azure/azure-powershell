### Example 1: Update the Size of the Virtual Machine. 
```powershell
Update-AzStackHCIVMVirtualMachine  -Name "testVm" -ResourceGroupName "test-rg" -VmMemoryInMB "4"
```
```output
Name            ResourceGroupName
----            -----------------
testVm          test-rg
```

This command updates an existing virtual machine in the specified resource group. 

