### Example 1: Handle an enclave connection deletion-approval callback
```powershell
Invoke-AzMissionHandleEnclaveConnectionApprovalDeletion -EnclaveConnectionName 'contoso-connection' -ResourceGroupName 'mission-rg' -ResourceRequestAction 'Delete'
```

```output
Message
-------
Approval state change handled successfully.
```

Notifies the `Microsoft.Mission` provider to handle the approved **delete** request for the `contoso-connection` enclave connection (`-ResourceRequestAction Delete`).
