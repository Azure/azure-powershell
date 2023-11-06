### Example 1:  Get a Network Interface
```powershell
PS C:\> Get-AzStackHCIVmNetworkInterface -Name "testNic" -ResourceGroupName "test-rg" 
```
```output
Name            ResourceGroupName
----            -----------------
testNic       test-rg
```

This command gets a specific network interface in the specified resource group. 

### Example 2: List all Logical Networks in a Resource Group  
```powershell
PS C:\> Get-AzStackHCIVmNetworkInterface -ResourceGroupName 'test-rg'
```
```output
Name            ResourceGroupName
----            -----------------
testNic       test-rg
```
This command lists all network interfaces in the specified resource group. 

