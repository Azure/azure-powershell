### Example 1: Handle an enclave connection deletion-approval callback
```powershell
Invoke-AzMissionHandleEnclaveConnectionApprovalDeletion -EnclaveConnectionName 'contoso-connection' -ResourceGroupName 'mission-rg' -ApprovalStatus 'Approved' -ResourceRequestAction 'Delete'
```

```output
Message
-------
Approval state change handled successfully.
```

Notifies the `Microsoft.Mission` provider that the pending **delete** request for the `contoso-connection` enclave connection has been `Approved`.
