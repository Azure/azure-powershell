### Example 1: Delete a virtual enclave
```powershell
Remove-AzMissionVirtualEnclave -Name 'contoso-enclave' -ResourceGroupName 'mission-rg'
```

Deletes the `contoso-enclave` virtual enclave from the `mission-rg` resource group. Use `-PassThru` to return `$true` on success.
