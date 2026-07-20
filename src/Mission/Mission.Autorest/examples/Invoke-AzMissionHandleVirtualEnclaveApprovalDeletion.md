### Example 1: Handle a virtual enclave deletion-approval callback
```powershell
Invoke-AzMissionHandleVirtualEnclaveApprovalDeletion -VirtualEnclaveName 'contoso-enclave' -ResourceGroupName 'mission-rg' -ApprovalStatus 'Approved' -ResourceRequestAction 'Delete'
```

```output
Message
-------
Approval state change handled successfully.
```

Notifies the `Microsoft.Mission` provider that the pending **delete** request for the `contoso-enclave` virtual enclave has been `Approved`, allowing deletion to proceed.
