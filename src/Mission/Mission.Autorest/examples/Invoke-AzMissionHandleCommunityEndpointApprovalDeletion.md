### Example 1: Handle a community endpoint deletion-approval callback
```powershell
Invoke-AzMissionHandleCommunityEndpointApprovalDeletion -CommunityEndpointName 'contoso-endpoint' -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg' -ApprovalStatus 'Approved' -ResourceRequestAction 'Delete'
```

```output
Message
-------
Approval state change handled successfully.
```

Notifies the `Microsoft.Mission` provider that the pending **delete** request for the `contoso-endpoint` community endpoint has been `Approved`.
