### Example 1: Handle a community endpoint creation-approval callback
```powershell
Invoke-AzMissionHandleCommunityEndpointApprovalCreation -CommunityEndpointName 'contoso-endpoint' -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg' -ApprovalStatus 'Approved' -ResourceRequestAction 'Create'
```

```output
Message
-------
Approval state change handled successfully.
```

Notifies the `Microsoft.Mission` provider that the pending **create** request for the `contoso-endpoint` community endpoint has been `Approved`.
