### Example 1: Deny a connection request by ID
```powershell
Deny-AzDataTransferConnection -PipelineName Pipeline01 -ResourceGroupName ResourceGroup01 -ConnectionId "connection-id-123" -StatusReason "Not authorized" -Confirm:$false
```

This example denies a connection request with the ID `connection-id-123` in the pipeline `Pipeline01` within the resource group `ResourceGroup01` and provides a status reason.

---
