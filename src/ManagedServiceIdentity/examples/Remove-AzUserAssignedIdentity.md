### Example 1: Deletes an user assigned identity
```powershell
Remove-AzUserAssignedIdentity -ResourceGroupName azure-rg-test -Name uai-pwsh01
```

This command deletes an user assigned identity.

### Example 2: Deletes an user assigned identity by pipeline
```powershell
Get-AzUserAssignedIdentity -ResourceGroupName azure-rg-test -Name uai-pwsh01 | Remove-AzUserAssignedIdentity
```

This command deletes an user assigned identity by pipeline.

