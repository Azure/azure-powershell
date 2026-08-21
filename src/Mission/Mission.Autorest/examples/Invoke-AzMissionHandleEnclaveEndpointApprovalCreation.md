### Example 1: Handle an enclave endpoint creation-approval callback
```powershell
Invoke-AzMissionHandleEnclaveEndpointApprovalCreation -EnclaveEndpointName 'contoso-enclave-endpoint' -VirtualEnclaveName 'contoso-enclave' -ResourceGroupName 'mission-rg' -ApprovalStatus 'Approved' -ResourceRequestAction 'Create'
```

```output
Message
-------
Approval state change handled successfully.
```

Notifies the `Microsoft.Mission` provider that the pending **create** request for the `contoso-enclave-endpoint` enclave endpoint has been `Approved`.
