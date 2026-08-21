### Example 1: Handle an enclave connection creation-approval callback
```powershell
Invoke-AzMissionHandleEnclaveConnectionApprovalCreation -EnclaveConnectionName 'contoso-connection' -ResourceGroupName 'mission-rg' -ApprovalStatus 'Approved' -ResourceRequestAction 'Create'
```

```output
Message
-------
Approval state change handled successfully.
```

Notifies the `Microsoft.Mission` provider that the pending **create** request for the `contoso-connection` enclave connection has been `Approved`.
