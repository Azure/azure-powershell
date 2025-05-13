### Example 1: List all pending flows for a specific connection

```powershell
$pendingFlows = Get-AzDataTransferListPendingFlow -ResourceGroupName ResourceGroup01 -ConnectionName Connection01
```

```output
Id                : pending-flow-id-123
ConnectionName    : Connection01
ResourceGroupName : ResourceGroup01
Status            : Pending
Requestor         : user@example.com

Id                : pending-flow-id-456
ConnectionName    : Connection01
ResourceGroupName : ResourceGroup01
Status            : Pending
Requestor         : admin@example.com
```

This example lists all pending flows for the connection `Connection01` within the resource group `ResourceGroup01`.

---
