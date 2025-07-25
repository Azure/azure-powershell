### Example 1:  Remove a Network Security Rule
```powershell
Remove-AzStackHCIVMSecurityRule -Name 'testnsgrule' -ResourceGroupName 'test-rg' -NetworkSecurityGroupName 'testnsg'
```
This command removes a specific network security rule in the specified resource group. 