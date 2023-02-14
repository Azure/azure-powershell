### Example 1: Get a monitor log analytics solution by name
```powershell
<<<<<<< HEAD
Get-AzMonitorLogAnalyticsSolution -ResourceGroupName azureps-monitor -Type "Microsoft.OperationsManagement/solutions" -Location "West US 2" -WorkspaceResourceId workspaceResourceId
```

```output
=======
PS C:\> Get-AzMonitorLogAnalyticsSolution -ResourceGroupName azureps-monitor -Name 'Containers(azureps-monitor)'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                      Type                                     Location
----                      ----                                     --------
Containers(azureps-monitor) Microsoft.OperationsManagement/solutions West US 2
```

This command gets a monitor log analytics solution by name.

### Example 2: Get a monitor log analytics solution by resource id
```powershell
<<<<<<< HEAD
@{Id = "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/azureps-manual-test/providers/Microsoft.OperationsManagement/solutions/Containers(monitoringworkspace-t01)"} | Get-AzMonitorLogAnalyticsSolution
```

```output
=======
PS C:\> @{Id = "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/azureps-manual-test/providers/Microsoft.OperationsManagement/solutions/Containers(monitoringworkspace-t01)"} | Get-AzMonitorLogAnalyticsSolution

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                                Type                                     Location
----                                ----                                     --------
Containers(monitoringworkspace-t01) Microsoft.OperationsManagement/solutions East US
```

This command gets a monitor log analytics solution by resource id.

### Example 3: Get a monitor log analytics solution by object
```powershell
<<<<<<< HEAD
$monitor = New-AzMonitorLogAnalyticsSolution -ResourceGroupName azureps-monitor -Name 'Containers(azureps-monitor)'
Get-AzMonitorLogAnalyticsSolution -InputObject $monitor
```

```output
=======

PS C:\> $monitor = New-AzMonitorLogAnalyticsSolution -ResourceGroupName azureps-monitor -Name 'Containers(azureps-monitor)'
PS C:\> Get-AzMonitorLogAnalyticsSolution -InputObject $monitor
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                      Type                                     Location
----                      ----                                     --------
Containers(azureps-monitor) Microsoft.OperationsManagement/solutions West US 2
```

This command gets a monitor log analytics solution by object.

### Example 4: Get all monitor log analytics solutions under a resource group
```powershell
<<<<<<< HEAD
Get-AzMonitorLogAnalyticsSolution -ResourceGroupName azureps-monitor
```

```output
=======
PS C:\> Get-AzMonitorLogAnalyticsSolution -ResourceGroupName azureps-monitor

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                      Type                                     Location
----                      ----                                     --------
Containers(azureps-monitor) Microsoft.OperationsManagement/solutions West US 2
```

This command gets all monitor log analytics solutions under a resource group.

### Example 5: Get all monitor log analytics solutions under a subscription
```powershell
<<<<<<< HEAD
Get-AzMonitorLogAnalyticsSolution 
```

```output
=======
PS C:\> Get-AzMonitorLogAnalyticsSolution 

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                                Type                                     Location
----                                ----                                     --------
Containers(monitoringworkspace-t01) Microsoft.OperationsManagement/solutions East US
Containers(azureps-monitor)           Microsoft.OperationsManagement/solutions West US 2
```

This command gets all monitor log analytics solutions under a subscription.


