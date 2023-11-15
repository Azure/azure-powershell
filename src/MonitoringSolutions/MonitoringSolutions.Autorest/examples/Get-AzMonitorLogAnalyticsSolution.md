### Example 1: Get a monitor log analytics solution by name
```powershell
Get-AzMonitorLogAnalyticsSolution -ResourceGroupName azureps-monitor -Type "Microsoft.OperationsManagement/solutions" -Location "West US 2" -WorkspaceResourceId workspaceResourceId
```

```output
Name                      Type                                     Location
----                      ----                                     --------
Containers(azureps-monitor) Microsoft.OperationsManagement/solutions West US 2
```

This command gets a monitor log analytics solution by name.

### Example 2: Get a monitor log analytics solution by resource id
```powershell
@{Id = "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/azureps-manual-test/providers/Microsoft.OperationsManagement/solutions/Containers(monitoringworkspace-t01)"} | Get-AzMonitorLogAnalyticsSolution
```

```output
Name                                Type                                     Location
----                                ----                                     --------
Containers(monitoringworkspace-t01) Microsoft.OperationsManagement/solutions East US
```

This command gets a monitor log analytics solution by resource id.

### Example 3: Get a monitor log analytics solution by object
```powershell
$monitor = New-AzMonitorLogAnalyticsSolution -ResourceGroupName azureps-monitor -Name 'Containers(azureps-monitor)'
Get-AzMonitorLogAnalyticsSolution -InputObject $monitor
```

```output
Name                      Type                                     Location
----                      ----                                     --------
Containers(azureps-monitor) Microsoft.OperationsManagement/solutions West US 2
```

This command gets a monitor log analytics solution by object.

### Example 4: Get all monitor log analytics solutions under a resource group
```powershell
Get-AzMonitorLogAnalyticsSolution -ResourceGroupName azureps-monitor
```

```output
Name                      Type                                     Location
----                      ----                                     --------
Containers(azureps-monitor) Microsoft.OperationsManagement/solutions West US 2
```

This command gets all monitor log analytics solutions under a resource group.

### Example 5: Get all monitor log analytics solutions under a subscription
```powershell
Get-AzMonitorLogAnalyticsSolution 
```

```output
Name                                Type                                     Location
----                                ----                                     --------
Containers(monitoringworkspace-t01) Microsoft.OperationsManagement/solutions East US
Containers(azureps-monitor)           Microsoft.OperationsManagement/solutions West US 2
```

This command gets all monitor log analytics solutions under a subscription.


