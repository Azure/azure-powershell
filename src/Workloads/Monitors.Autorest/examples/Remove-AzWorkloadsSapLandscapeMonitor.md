### Example 1: Delete SAP Landscape Monitor
```powershell
Remove-AzWorkloadsSapLandscapeMonitor -MonitorName suha-160323-ams7 -ResourceGroupName suha-0802-rg1 -SubscriptionId 49d64d54-e966-4c46-a868-1999802b762c
```

Delete SAP Landscape Monitor for a specific AMS Instance

### Example 2: Delete SAP Landscape Monitor by Id
```powershell
Remove-AzWorkloadsSapLandscapeMonitor -InputObject "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/suha-0802-rg1/providers/Microsoft.Workloads/monitors/suha-0202-ams9/sapLandscapeMonitor/default"
```

Delete SAP Landscape Monitor for a specific AMS Instance by ArmId

