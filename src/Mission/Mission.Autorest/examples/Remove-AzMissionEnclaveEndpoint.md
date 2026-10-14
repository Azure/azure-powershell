### Example 1: Delete an enclave endpoint
```powershell
Remove-AzMissionEnclaveEndpoint -Name 'contoso-enclave-endpoint' -VirtualEnclaveName 'contoso-enclave' -ResourceGroupName 'mission-rg'
```

Deletes the `contoso-enclave-endpoint` enclave endpoint from the `contoso-enclave` virtual enclave. Use `-PassThru` to return `$true` on success.
