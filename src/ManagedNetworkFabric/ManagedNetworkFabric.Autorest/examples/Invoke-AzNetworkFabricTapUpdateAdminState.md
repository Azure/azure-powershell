### Example 1: Enable/Disable a Network Tap
```powershell
$state="Enable"
Invoke-AzNetworkFabricTapUpdateAdminState -NetworkTapName $name -ResourceGroupName $resourceGroupName -State $state
```

This command Enable/Disable a network tap


