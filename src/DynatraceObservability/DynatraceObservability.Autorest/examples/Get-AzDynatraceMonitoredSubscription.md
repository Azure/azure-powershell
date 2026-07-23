### Example 1: List monitored subscriptions for a monitor
```powershell
$rg = "myResourceGroup"
$monitor = "myDynatraceMonitor"
$subs = Get-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor
$subs | Select-Object Id, Name, Type
```

```output
Id                                                                                                                    Name    Type
--                                                                                                                    ----    ----
/subscriptions/b16e4b4e-2ed8-4f32-bac1-0e3eb56bef5c/resourceGroups/dyobrg45en7g/providers/Dynatrace.Observability/monitors/dyob83ctr7/monitoredSubscriptions/default  default Dynatrace.Observability/monitors/monitoredSubscriptions
```

Displays monitored subscription entries attached to the specified monitor. (Sample output based on recording.)

### Example 2: Use identity pipeline (monitor object)
```powershell
$monitorObj = Get-AzDynatraceMonitor -ResourceGroupName "myResourceGroup" -Name "myDynatraceMonitor" | Select-Object -First 1
$monitorObj | Get-AzDynatraceMonitoredSubscription | Select-Object -First 1 -Property Id, Name
```

```output
Id                                                                                                                    Name
--                                                                                                                    ----
/subscriptions/b16e4b4e-2ed8-4f32-bac1-0e3eb56bef5c/resourceGroups/dyobrg45en7g/providers/Dynatrace.Observability/monitors/dyob83ctr7/monitoredSubscriptions/default  default
```

Pipes the monitor object (identity) to retrieve its monitored subscriptions.

### Example 3: Retrieve a single monitored subscription (Get parameter set)
```powershell
$rg = "myResourceGroup"; $monitor = "myDynatraceMonitor"
$all = Get-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor
($all[0] | Get-AzDynatraceMonitoredSubscription) | Format-List Id, Name, Type, Properties
```

```output
Id    : /subscriptions/b16e4b4e-2ed8-4f32-bac1-0e3eb56bef5c/resourceGroups/dyobrg45en7g/providers/Dynatrace.Observability/monitors/dyob83ctr7/monitoredSubscriptions/default
Name  : default
Type  : Dynatrace.Observability/monitors/monitoredSubscriptions
Properties : @{operation=AddBegin; monitoredSubscriptionList=} 
```

Selects the first monitored subscription and re-fetches it for detailed inspection (properties show operation AddBegin).

### Example 4: Filter for current subscription
```powershell
$rg = "myResourceGroup"; $monitor = "myDynatraceMonitor"; $currentSub = (Get-AzContext).Subscription.Id
$subs = Get-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor | Where-Object { $_.Id -like "/subscriptions/$currentSub/*" }
$subs | Select-Object Id, Name
```

```output
Id                                                                                                                    Name
--                                                                                                                    ----
/subscriptions/b16e4b4e-2ed8-4f32-bac1-0e3eb56bef5c/resourceGroups/dyobrg45en7g/providers/Dynatrace.Observability/monitors/dyob83ctr7/monitoredSubscriptions/default  default
```

Filters results to the current subscription scope.

### Example 5: Count monitored subscriptions
```powershell
$count = (Get-AzDynatraceMonitoredSubscription -ResourceGroupName "myResourceGroup" -MonitorName "myDynatraceMonitor").Count
Write-Host "Total monitored subscriptions: $count"
```

```output
Total monitored subscriptions: 1
```

Outputs a simple count for reporting or validation.

### Example 6: Graceful handling when none exist
```powershell
$rg = "myResourceGroup"; $monitor = "myDynatraceMonitor"
$subs = Get-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor -ErrorAction SilentlyContinue
if (-not $subs -or $subs.Count -eq 0) { Write-Warning "No monitored subscriptions found." } else { $subs | Select-Object -First 5 }
```

```output
WARNING: No monitored subscriptions found.
```

Demonstrates defensive pattern when list may be empty.

### Example 7: Format output for auditing
```powershell
Get-AzDynatraceMonitoredSubscription -ResourceGroupName "myResourceGroup" -MonitorName "myDynatraceMonitor" | 
	Select-Object Id,@{n='SubscriptionGuid';e={ ($_).Id.Split('/')[2] }}, Name | Export-Csv -Path monitoredSubs.csv -NoTypeInformation
```

```output
"Id","SubscriptionGuid","Name"
"/subscriptions/b16e4b4e-2ed8-4f32-bac1-0e3eb56bef5c/resourceGroups/dyobrg45en7g/providers/Dynatrace.Observability/monitors/dyob83ctr7/monitoredSubscriptions/default","b16e4b4e-2ed8-4f32-bac1-0e3eb56bef5c","default"
```

Prepares a CSV of monitored subscriptions with extracted subscription GUIDs for audit or inventory.

