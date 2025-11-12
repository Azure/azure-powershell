### Example 1: Install agent on a VM using expanded parameters
```powershell
$rg = "myResourceGroup"
$monitor = "myDynatraceMonitor"
$vmId = "/subscriptions/$(Get-AzContext).Subscription.Id/resourceGroups/$rg/providers/Microsoft.Compute/virtualMachines/myVm01"
$entry = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentList]::new(); $entry.Id = $vmId
Invoke-AzDynatraceManageMonitorAgentInstallation -ResourceGroupName $rg -MonitorName $monitor -Action Install -ManageAgentInstallationList @($entry) -PassThru
```

Returns True when the install request is accepted.

### Example 2: Uninstall agent via expanded parameters
```powershell
$rg = "myResourceGroup"; $monitor = "myDynatraceMonitor"
$vmId = "/subscriptions/$(Get-AzContext).Subscription.Id/resourceGroups/$rg/providers/Microsoft.Compute/virtualMachines/myVm01"
$entry = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentList]::new(); $entry.Id = $vmId
Invoke-AzDynatraceManageMonitorAgentInstallation -ResourceGroupName $rg -MonitorName $monitor -Action Uninstall -ManageAgentInstallationList @($entry) -PassThru
```

Removes the Dynatrace agent from the specified resource.

### Example 3: Use request object (Manage parameter set)
```powershell
$rg = "myResourceGroup"; $monitor = "myDynatraceMonitor"; $vmId = "/subscriptions/$(Get-AzContext).Subscription.Id/resourceGroups/$rg/providers/Microsoft.Compute/virtualMachines/myVm02"
$listEntry = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentList]::new(); $listEntry.Id = $vmId
$request = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentInstallationRequest]::new()
$request.Action = 'Install'
$request.ManageAgentInstallationList = @($listEntry)
Invoke-AzDynatraceManageMonitorAgentInstallation -ResourceGroupName $rg -MonitorName $monitor -Request $request -PassThru
```

Creates and submits a strongly-typed request object.

### Example 4: Pipeline identity usage (monitor object)
```powershell
$monitorObj = Get-AzDynatraceMonitor -ResourceGroupName "myResourceGroup" -Name "myDynatraceMonitor" | Select-Object -First 1
$vmId = "/subscriptions/$(Get-AzContext).Subscription.Id/resourceGroups/myResourceGroup/providers/Microsoft.Compute/virtualMachines/myVm03"
$entry = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentList]::new(); $entry.Id = $vmId
$monitorObj | Invoke-AzDynatraceManageMonitorAgentInstallation -Action Install -ManageAgentInstallationList @($entry) -PassThru
```

Demonstrates identity parameter set by piping the monitor.

### Example 5: JSON string input
```powershell
$rg = "myResourceGroup"; $monitor = "myDynatraceMonitor"; $vmId = "/subscriptions/$(Get-AzContext).Subscription.Id/resourceGroups/$rg/providers/Microsoft.Compute/virtualMachines/myVm04"
$json = '{"action":"Install","manageAgentInstallationList":[{"id":"' + $vmId + '"}]}'
Invoke-AzDynatraceManageMonitorAgentInstallation -ResourceGroupName $rg -MonitorName $monitor -JsonString $json -PassThru
```

Passes the request as raw JSON.

### Example 6: JSON file path input
```powershell
$rg = "myResourceGroup"; $monitor = "myDynatraceMonitor"; $vmId = "/subscriptions/$(Get-AzContext).Subscription.Id/resourceGroups/$rg/providers/Microsoft.Compute/virtualMachines/myVm05"
$path = Join-Path $PWD 'agent-install.json'
@{ action = 'Install'; manageAgentInstallationList = @(@{ id = $vmId }) } | ConvertTo-Json -Depth 4 | Set-Content -Path $path -Encoding UTF8
Invoke-AzDynatraceManageMonitorAgentInstallation -ResourceGroupName $rg -MonitorName $monitor -JsonFilePath $path -PassThru
```

Reads parameters from a JSON file.

### Example 7: Uninstall using request object and identity pipeline
```powershell
$monitorObj = Get-AzDynatraceMonitor -ResourceGroupName "myResourceGroup" -Name "myDynatraceMonitor" | Select-Object -First 1
$vmId = "/subscriptions/$(Get-AzContext).Subscription.Id/resourceGroups/myResourceGroup/providers/Microsoft.Compute/virtualMachines/myVm09"
$entry = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentList]::new(); $entry.Id = $vmId
$req = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentInstallationRequest]::new(); $req.Action = 'Uninstall'; $req.ManageAgentInstallationList = @($entry)
$monitorObj | Invoke-AzDynatraceManageMonitorAgentInstallation -Request $req -PassThru
```

Combines identity pipeline with the -Request parameter set.

