### Example 1: Get a Azure Virtual Desktop SessionHostConfigurationOperationStatus by HostPoolName and operationId
```powershell
Get-AzWvdSessionHostConfigurationsOperationStatus -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName -OperationId operationId
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     operationId Microsoft.DesktopVirtualization/hostpools/sessionhostconfigurations/operationstatuses
```

This command gets a Azure Virtual Desktop SessionHostConfigurationOperationStatus in a Resource Group.

### Example 2: List Azure Virtual Desktop SessionHostConfigurationOperationStatuses

```powershell
Get-AzWvdSessionHostConfigurationsOperationStatus -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName
```

```output
Location   Name          Type
--------   ----          ----
eastus     operationId1 Microsoft.DesktopVirtualization/hostpools/sessionhostconfigurations/operationstatuses
eastus     operationId2 Microsoft.DesktopVirtualization/hostpools/sessionhostconfigurations/operationstatuses
```

This command lists a Azure Virtual Desktop SessionHostConfigurationOperationStatuses in a Resource Group.

### Example 3: List Azure Virtual Desktop SessionHostConfigurationOperationStatuses with filters

```powershell
Get-AzWvdSessionHostConfigurationsOperationStatus -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName -isLatest:$false -isNonTerminal
```

```output
Location   Name          Type
--------   ----          ----
eastus     operationId1 Microsoft.DesktopVirtualization/hostpools/sessionhostconfigurations/operationstatuses
eastus     operationId2 Microsoft.DesktopVirtualization/hostpools/sessionhostconfigurations/operationstatuses
```

This command lists a Azure Virtual Desktop SessionHostConfigurationOperationStatuses in a Resource Group.
