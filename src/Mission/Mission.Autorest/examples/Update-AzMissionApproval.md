### Example 1: Patch an approval's ticket reference
```powershell
Update-AzMissionApproval -Name 'contoso-approval' -ResourceUri 'subscriptions/<subscriptionId>/resourceGroups/mission-rg/providers/Microsoft.Mission/enclaveConnections/contoso-connection' -TicketId 'INC0067890'
```

```output
Name             RequestMetadataApprovalStatus RequestMetadataResourceAction
----             ----------------------------- -----------------------------
contoso-approval Pending                       Create
```

Updates only the tracking ticket on the existing `contoso-approval` approval, leaving its status and action unchanged (PATCH semantics).
