### Example 1: Remove a monitor log analytics solution by name
```powershell
<<<<<<< HEAD
Remove-AzMonitorLogAnalyticsSolution  -ResourceGroupName azureps-manual-test -Name 'Containers(monitoringworkspace-2vob7n)'
=======
PS C:\> Remove-AzMonitorLogAnalyticsSolution  -ResourceGroupName azureps-manual-test -Name 'Containers(monitoringworkspace-2vob7n)'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command removes a monitor log analytics solution by name.

### Example 2: Remove a monitor log analytics solution by object
```powershell
<<<<<<< HEAD
$monitor = Get-AzMonitorLogAnalyticsSolution -ResourceGroupName azureps-manual-test -Name 'Containers(monitoringworkspace-pevful)'
Remove-AzMonitorLogAnalyticsSolution -InputObject $monitor
=======
PS C:\> $monitor = Get-AzMonitorLogAnalyticsSolution -ResourceGroupName azureps-manual-test -Name 'Containers(monitoringworkspace-pevful)'
PS C:\> Remove-AzMonitorLogAnalyticsSolution -InputObject $monitor

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command removes a monitor log analytics solution by object.

### Example 3: Remove a monitor log analytics solution by pipeline
```powershell
<<<<<<< HEAD
$monitor = Get-AzMonitorLogAnalyticsSolution -ResourceGroupName azureps-manual-test -Name 'Containers(monitoringworkspace-asdehu)' | Remove-AzMonitorLogAnalyticsSolution
=======
PS C:\> $monitor = Get-AzMonitorLogAnalyticsSolution -ResourceGroupName azureps-manual-test -Name 'Containers(monitoringworkspace-asdehu)' | Remove-AzMonitorLogAnalyticsSolution

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command removes a monitor log analytics solution by pipeline.

