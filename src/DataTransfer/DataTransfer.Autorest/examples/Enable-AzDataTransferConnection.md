### Example 1: Enable a single connection
```powershell
Enable-AzDataTransferConnection -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -ConnectionId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection01"
```

Enables a single connection.

### Example 2: Enable multiple connections
```powershell
$connectionIds = @(
    "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection01",
    "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/Connection02"
)
Enable-AzDataTransferConnection -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -ConnectionId $connectionIds
```

Enables multiple connections.

