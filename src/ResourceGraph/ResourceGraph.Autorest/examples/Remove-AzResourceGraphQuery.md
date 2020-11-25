### Example 1: Remove a resource graph query by name
```powershell
PS C:\> Remove-AzResourceGraphQuery -ResourceGroupName azure-rg-test -Name query-t03

```

This command removes a resource graph query by name.

### Example 2: Remove a resource graph query by object
```powershell
PS C:\> $query = Get-AzResourceGraphQuery -ResourceGroupName azure-rg-test -Name query-t02
PS C:\> Remove-AzResourceGraphQuery -InputObject $query 

```

This command removes a resource graph query by object.

