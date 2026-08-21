### Example 1: Create an approval on a resource
```powershell
New-AzMissionApproval -Name 'contoso-approval' -ResourceUri 'subscriptions/<subscriptionId>/resourceGroups/mission-rg/providers/Microsoft.Mission/enclaveConnections/contoso-connection' -RequestMetadataApprovalStatus 'Pending' -RequestMetadataResourceAction 'Create' -TicketId 'INC0012345'
```

```output
Name             RequestMetadataApprovalStatus RequestMetadataResourceAction
----             ----------------------------- -----------------------------
contoso-approval Pending                       Create
```

Creates an approval named `contoso-approval` on the `contoso-connection` enclave connection, tracking a pending `Create` request under ticket `INC0012345`.
