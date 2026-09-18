### Example 1: Handle an enclave endpoint deletion-approval callback
```powershell
Invoke-AzMissionHandleEnclaveEndpointApprovalDeletion -EnclaveEndpointName 'contoso-enclave-endpoint' -VirtualEnclaveName 'contoso-enclave' -ResourceGroupName 'mission-rg' -ResourceRequestAction 'Delete'
```

```output
Message
-------
Approval state change handled successfully.
```

Notifies the `Microsoft.Mission` provider to handle the approved **delete** request for the `contoso-enclave-endpoint` enclave endpoint (`-ResourceRequestAction Delete`).
