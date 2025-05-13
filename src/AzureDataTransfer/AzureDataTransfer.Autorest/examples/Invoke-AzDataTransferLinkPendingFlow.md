### Example 1: Link a pending flow by ID
```powershell
Invoke-AzDataTransferLinkPendingFlow -ResourceGroupName ResourceGroup01 -ConnectionName Connection01 -FlowName Flow01 -PendingFlowId "pending-flow-id-123" -StatusReason "Linking approved" -Confirm:$false
```

This example links a pending flow with the ID `pending-flow-id-123` to the flow `Flow01` in the connection `Connection01` within the resource group `ResourceGroup01` and provides a status reason.

---
