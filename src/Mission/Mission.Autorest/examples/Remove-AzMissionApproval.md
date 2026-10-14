### Example 1: Delete an approval
```powershell
Remove-AzMissionApproval -Name 'contoso-approval' -ResourceUri 'subscriptions/<subscriptionId>/resourceGroups/mission-rg/providers/Microsoft.Mission/enclaveConnections/contoso-connection'
```

Deletes the `contoso-approval` approval from the `contoso-connection` enclave connection. Use `-PassThru` to return `$true` on success.
