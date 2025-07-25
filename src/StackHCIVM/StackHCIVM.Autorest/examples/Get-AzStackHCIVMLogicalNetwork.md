### Example 1:  Get a Logical Network
```powershell
Get-AzStackHCIVMLogicalNetwork -Name 'testLnet' -ResourceGroupName 'test-rg' 
```
```output
Name            ResourceGroupName
----            -----------------
testLnet       test-rg
```

This command gets a specific logical network in the specified resource group. 

### Example 2: List all Logical Networks in a Resource Group  
```powershell
Get-AzStackHCIVMLogicalNetwork -ResourceGroupName 'test-rg'
```
```output
Name            ResourceGroupName
----            -----------------
testLnet       test-rg
```
This command lists all logical networks in the specified resource group. 

