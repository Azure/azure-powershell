### Example 1: Disable a single connection
```powershell
Disable-AzDataTransferConnection -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -ConnectionId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection01"
```

Disables a single connection.

### Example 2: Disable multiple connections
```powershell
$connectionIds = @(
    "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection01",
    "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection02"
)
Disable-AzDataTransferConnection -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -ConnectionId $connectionIds
```

Disables multiple connections.

