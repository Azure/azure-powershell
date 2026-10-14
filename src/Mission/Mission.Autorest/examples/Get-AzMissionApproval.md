### Example 1: List all approvals on a resource
```powershell
Get-AzMissionApproval -ResourceUri 'subscriptions/<subscriptionId>/resourceGroups/mission-rg/providers/Microsoft.Mission/enclaveConnections/contoso-connection'
```

```output
Name             RequestMetadataApprovalStatus
----             -----------------------------
contoso-approval Pending
```

Lists every approval associated with the `contoso-connection` enclave connection (an extension resource addressed by its full resource URI).

### Example 2: Get a single approval by name
```powershell
Get-AzMissionApproval -Name 'contoso-approval' -ResourceUri 'subscriptions/<subscriptionId>/resourceGroups/mission-rg/providers/Microsoft.Mission/enclaveConnections/contoso-connection'
```

```output
Name             RequestMetadataApprovalStatus RequestMetadataResourceAction
----             ----------------------------- -----------------------------
contoso-approval Pending                       Create
```

Retrieves the `contoso-approval` approval on the `contoso-connection` enclave connection, including its status and requested action.
