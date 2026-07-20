### Example 1: Handle a virtual enclave creation-approval callback
```powershell
Invoke-AzMissionHandleVirtualEnclaveApprovalCreation -VirtualEnclaveName 'contoso-enclave' -ResourceGroupName 'mission-rg' -ApprovalStatus 'Approved' -ResourceRequestAction 'Create'
```

```output
Message
-------
Approval state change handled successfully.
```

Notifies the `Microsoft.Mission` provider that the pending **create** request for the `contoso-enclave` virtual enclave has been `Approved`, allowing provisioning to proceed.
