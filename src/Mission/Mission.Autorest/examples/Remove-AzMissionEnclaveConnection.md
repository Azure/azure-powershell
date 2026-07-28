### Example 1: Delete an enclave connection
```powershell
Remove-AzMissionEnclaveConnection -Name 'contoso-connection' -ResourceGroupName 'mission-rg'
```

Deletes the `contoso-connection` enclave connection from the `mission-rg` resource group. Use `-PassThru` to return `$true` on success.
