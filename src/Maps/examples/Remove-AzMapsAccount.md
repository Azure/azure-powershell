### Example 1: Delete a Maps Account
```powershell
PS C:\> Remove-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount01

```

This command deletes a Maps Account.

### Example 2: Delete a Maps Account by pipeline
```powershell
PS C:\> Get-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount02 | Remove-AzMapsAccount

```

This command deletes a Maps Account by pipeline.

