### Example 1: Link a pending connection by ID

```powershell
Invoke-AzDataTransferLinkPendingConnection -ResourceGroupName ResourceGroup01 -ConnectionName Connection01 -PendingConnectionId "pending-connection-id-123" -StatusReason "Linking approved" -Confirm:$false
```

This example links a pending connection with the ID `pending-connection-id-123` to the connection `Connection01` within the resource group `ResourceGroup01` and provides a status reason.

---
