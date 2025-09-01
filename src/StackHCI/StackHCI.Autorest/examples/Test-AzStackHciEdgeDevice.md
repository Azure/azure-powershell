### Example 1:
```powershell
Test-AzStackHciEdgeDevice -ResourceUri "subscriptions/<subId>/resourceGroups/<test-rg>/providers/Microsoft.HybridCompute/machines/<test-node>" -Name "default" -EdgeDeviceId @("/subscriptions/<subId>/resourceGroups/<test-rg>/providers/Microsoft.HybridCompute/machines/<test-node>/edgeDevices/default", "/subscriptions/<subId>/resourceGroups/<test-rg>/providers/Microsoft.HybridCompute/machines/<test-node2>/edgeDevices/default") -AdditionalInfo "test"
```

Tests the edge devices for the node