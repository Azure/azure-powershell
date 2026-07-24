### Example 1: Delete a workload
```powershell
Remove-AzMissionWorkload -Name 'contoso-workload' -ResourceGroupName 'mission-rg' -VirtualEnclaveName 'contoso-enclave'
```

Deletes the `contoso-workload` workload from the `contoso-enclave` virtual enclave. Use `-PassThru` to return `$true` on success.
