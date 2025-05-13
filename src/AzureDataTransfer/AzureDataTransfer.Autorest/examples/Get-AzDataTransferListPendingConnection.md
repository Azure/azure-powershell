### Example 1: List all pending connections for a specific connection
```powershell
$pendingConnections = Get-AzDataTransferListPendingConnection -ResourceGroupName ResourceGroup01 -ConnectionName Connection01
```

```output
Id                : pending-connection-id-123
ConnectionName    : Connection01
ResourceGroupName : ResourceGroup01
Status            : Pending
Requestor         : user@example.com

Id                : pending-connection-id-456
ConnectionName    : Connection01
ResourceGroupName : ResourceGroup01
Status            : Pending
Requestor         : admin@example.com
```

This example lists all pending connections for the connection `Connection01` within the resource group `ResourceGroup01`.

---
