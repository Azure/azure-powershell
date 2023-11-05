### Example 2: Get a Virtual Machine. 
```powershell
PS C:\> Get-AzStackHCIVmVirtualMachine -Name "testVm" -ResourceGroupName "test-rg"
```
```output
Name            ResourceGroupName
----            -----------------
testVm          test-rg
```

This commnad gets a virtual machine in a specified resource group. 


### Example 2: List Virtual Machines in a Resource Group
```powershell
PS C:\> Get-AzStackHCIVmVirtualMachine -ResourceGroupName "test-rg"
```
```output
Name            ResourceGroupName
----            -----------------
testVm          test-rg
```

This command lists all virtual machines in a resource group.  