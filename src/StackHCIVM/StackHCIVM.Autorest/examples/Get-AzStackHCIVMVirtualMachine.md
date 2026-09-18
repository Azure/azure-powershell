### Example 2: Get a Virtual Machine. 
```powershell
Get-AzStackHCIVMVirtualMachine -Name "testVm" -ResourceGroupName "test-rg"
```
```output
Name            ResourceGroupName
----            -----------------
testVm          test-rg
```

This command gets a virtual machine in a specified resource group. 


### Example 2: List Virtual Machines in a Resource Group
```powershell
Get-AzStackHCIVMVirtualMachine -ResourceGroupName "test-rg"
```
```output
Name            ResourceGroupName
----            -----------------
testVm          test-rg
```

This command lists all virtual machines in a resource group.  