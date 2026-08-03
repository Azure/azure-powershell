### Example 1: Notify the approval initiator of a decision
```powershell
$resourceUri = 'subscriptions/<subscriptionId>/resourceGroups/mission-rg/providers/Microsoft.Mission/enclaveConnections/contoso-connection'
Send-AzMissionApprovalInitiator -ApprovalName 'contoso-approval' -ResourceUri $resourceUri -ApprovalStatus 'Approved'
```

```output
Message
-------
Approved
```

Notifies the initiator of the `contoso-approval` approval (scoped to the `contoso-connection` enclave connection) that the request has been `Approved`.
