### Example 1: Validate delete parameters (WhatIf)
```powershell
$rg = "myResourceGroup"
$monitor = "myDynatraceMonitor"
Remove-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor -WhatIf
```

Performs a dry run; this matches the recorded validation step.

### Example 2: Delete monitored subscription (explicit parameters)
```powershell
$rg = "myResourceGroup"
$monitor = "myDynatraceMonitor"
Remove-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor -Confirm:$false
```

Attempts deletion. If the backend is fully provisioned, this should succeed; otherwise you may see `ResourceDeletionFailed`.

### Example 3: Idempotent second delete
```powershell
$rg = "myResourceGroup"
$monitor = "myDynatraceMonitor"
Remove-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor -Confirm:$false -ErrorAction SilentlyContinue
```

Safe to run again; if already deleted, no change occurs.

### Example 4: Handle transient backend errors
```powershell
$rg = "myResourceGroup"; $monitor = "myDynatraceMonitor"
try {
	Remove-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor -Confirm:$false
} catch {
	Write-Warning "Deletion failed: $($_.Exception.Message). Retry after confirming the monitored subscription was fully created." 
}
```

Provides a pattern for handling intermittent service errors gracefully.

