### Example 1: Replace an approval definition (PUT)
```powershell
Set-AzMissionApproval -Name 'contoso-approval' -ResourceUri 'subscriptions/<subscriptionId>/resourceGroups/mission-rg/providers/Microsoft.Mission/enclaveConnections/contoso-connection' -RequestMetadataApprovalStatus 'Approved' -RequestMetadataResourceAction 'Create' -TicketId 'INC0012345'
```

```output
Name             RequestMetadataApprovalStatus RequestMetadataResourceAction
----             ----------------------------- -----------------------------
contoso-approval Approved                      Create
```

Replaces the full definition of the `contoso-approval` approval, marking the tracked `Create` request as `Approved`.
