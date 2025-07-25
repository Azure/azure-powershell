### Example 1:
```powershell
$ValidateRequest = @{
    edgeDeviceIds = @(
        "/subscriptions/<subId>/resourceGroups/<test-rg>/providers/Microsoft.HybridCompute/machines/<test-node>/edgeDevices/default",
        "/subscriptions/<subId>/resourceGroups/<test-rg>/providers/Microsoft.HybridCompute/machines/<test-node2>/edgeDevices/default"
    )
    additionalInfo = "test"
}

Test-AzStackHciEdgeDevice -ResourceUri "subscriptions/<subId>/resourceGroups/<test-rg>/providers/Microsoft.HybridCompute/machines/<test-node>" -Name "default" -ValidateRequest $ValidateRequest
```

Tests the edge devices for the node