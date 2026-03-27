### Example 1: Begin adding subscription monitoring (AddBegin)
```powershell
$rg = "myResourceGroup"
$monitor = "myDynatraceMonitor"
$subscriptionId = (Get-AzContext).Subscription.Id

# Initiate monitoring relationship (AddBegin)
$subs = @([Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.MonitoredSubscription]::new())
$subs[0].Id = "/subscriptions/$subscriptionId"
New-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor -MonitoredSubscriptionList $subs -Operation AddBegin
```

Starts the monitored subscription onboarding workflow. Some services require a follow-up AddComplete operation.

### Example 2: Complete add workflow (AddComplete)
```powershell
$rg = "myResourceGroup"
$monitor = "myDynatraceMonitor"
$subscriptionId = (Get-AzContext).Subscription.Id
$subs = @([Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.MonitoredSubscription]::new())
$subs[0].Id = "/subscriptions/$subscriptionId"
New-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor -MonitoredSubscriptionList $subs -Operation AddComplete
```

Finalizes the monitoring relationship after an earlier AddBegin.

### Example 3: Create via JSON string
```powershell
$rg = "myResourceGroup"
$monitor = "myDynatraceMonitor"
$subscriptionId = (Get-AzContext).Subscription.Id
$json = '{"monitoredSubscriptionList":[{"id":"/subscriptions/' + $subscriptionId + '"}],"operation":"AddBegin"}'
New-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor -JsonString $json
```

Uses JSON payload rather than typed objects—helpful for automation or external template generation.

### Example 4: Create via JSON file path
```powershell
$rg = "myResourceGroup"
$monitor = "myDynatraceMonitor"
$subscriptionId = (Get-AzContext).Subscription.Id
$path = Join-Path $PWD 'monitored-subscription.json'
@{ monitoredSubscriptionList = @(@{ id = "/subscriptions/$subscriptionId" }); operation = 'AddBegin' } | ConvertTo-Json -Depth 5 | Set-Content -Path $path -Encoding UTF8
New-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor -JsonFilePath $path
```

Reads creation parameters from a JSON file on disk.

### Example 5: Pipeline identity usage with expanded parameters
```powershell
$monitorObj = Get-AzDynatraceMonitor -ResourceGroupName "myResourceGroup" -Name "myDynatraceMonitor"
$subscriptionId = (Get-AzContext).Subscription.Id
$subObj = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.MonitoredSubscription]::new(); $subObj.Id = "/subscriptions/$subscriptionId"
($monitorObj | New-AzDynatraceMonitoredSubscription -MonitoredSubscriptionList @($subObj) -Operation AddBegin)
```

Demonstrates identity parameter set by piping the monitor object.

### Example 6: Dry run with -WhatIf
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
$subObj = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.MonitoredSubscription]::new(); $subObj.Id = "/subscriptions/$subscriptionId"
New-AzDynatraceMonitoredSubscription -ResourceGroupName "myResourceGroup" -MonitorName "myDynatraceMonitor" -MonitoredSubscriptionList @($subObj) -Operation AddBegin -WhatIf
```

Shows the operation details without persisting changes.

### Example 7: JSON validation then completion
```powershell
$rg = "myResourceGroup"; $monitor = "myDynatraceMonitor"; $sid = (Get-AzContext).Subscription.Id
$jsonBegin = '{"monitoredSubscriptionList":[{"id":"/subscriptions/' + $sid + '"}],"operation":"AddBegin"}'
New-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor -JsonString $jsonBegin | Out-Null
$jsonComplete = '{"monitoredSubscriptionList":[{"id":"/subscriptions/' + $sid + '"}],"operation":"AddComplete"}'
New-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor -JsonString $jsonComplete
```

Executes the two-step add workflow entirely via JSON payloads.

### Example 8: Verify monitored subscription list
```powershell
$rg = "myResourceGroup"; $monitor = "myDynatraceMonitor"
Get-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor | Select-Object -First 1 | Format-List Id,Name,Type
```

Retrieves and inspects monitored subscription after creation.

