### Example 1: Approve a connection request by ID

```powershell
Approve-AzDataTransferConnection -PipelineName Pipeline01 -ResourceGroupName ResourceGroup01 -ConnectionId "connection-id-123" -StatusReason "Approved for processing" -Confirm:$false
```

This example approves a connection request with the ID `connection-id-123` in the pipeline `Pipeline01` within the resource group `ResourceGroup01` and provides a status reason.

---
