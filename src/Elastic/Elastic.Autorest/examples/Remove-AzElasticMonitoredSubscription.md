### Example 1: Remove a specific subscription from Elastic monitoring
```powershell
Remove-AzElasticMonitoredSubscription -ResourceGroupName "myResourceGroup" -MonitorName "myElasticMonitor" -ConfigurationName "12345678-1234-1234-1234-123456789012"
```

This command removes the specified subscription from being monitored by the Elastic monitor. No output is returned upon successful completion.

### Example 2: Remove monitored subscription with confirmation prompt
```powershell
Remove-AzElasticMonitoredSubscription -ResourceGroupName "myResourceGroup" -MonitorName "myElasticMonitor" -ConfigurationName "12345678-1234-1234-1234-123456789012" -Confirm
```

This command removes the monitored subscription but prompts for confirmation before executing the removal operation.

### Example 3: Remove monitored subscription using pipeline from Get-AzElasticMonitoredSubscription
```powershell
Get-AzElasticMonitoredSubscription -ResourceGroupName "myResourceGroup" -MonitorName "myElasticMonitor" -ConfigurationName "12345678-1234-1234-1234-123456789012" | Remove-AzElasticMonitoredSubscription
```

This command gets a specific monitored subscription and pipes it to Remove-AzElasticMonitoredSubscription to remove it from monitoring.

