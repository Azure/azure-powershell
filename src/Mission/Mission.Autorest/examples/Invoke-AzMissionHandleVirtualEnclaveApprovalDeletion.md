### Example 1: Handle a virtual enclave deletion-approval callback
```powershell
Invoke-AzMissionHandleVirtualEnclaveApprovalDeletion -VirtualEnclaveName 'contoso-enclave' -ResourceGroupName 'mission-rg' -ResourceRequestAction 'Delete'
```

```output
Message
-------
Approval state change handled successfully.
```

Notifies the `Microsoft.Mission` provider to handle the approved **delete** request for the `contoso-enclave` virtual enclave (`-ResourceRequestAction Delete`), allowing deletion to proceed.
