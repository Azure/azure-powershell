### Example 1:  Get a Network Interface
```powershell
Get-AzStackHCIVMNetworkInterface -Name 'testNic' -ResourceGroupName 'test-rg' 
```
```output
Name            ResourceGroupName
----            -----------------
testNic       test-rg
```

This command gets a specific network interface in the specified resource group. 

### Example 2: List all Logical Networks in a Resource Group  
```powershell
Get-AzStackHCIVMNetworkInterface -ResourceGroupName 'test-rg'
```
```output
Name            ResourceGroupName
----            -----------------
testNic       test-rg
```
This command lists all network interfaces in the specified resource group. 