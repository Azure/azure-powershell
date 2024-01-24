
### Example 1: Get a Windows Virtual Desktop SessionHostConfigurationOperationStatus by HostPoolName and operationId

```powershell
Get-AzWvdSessionHostConfigurationOperationStatus -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName -OperationId operationId
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     HostPoolName Microsoft.DesktopVirtualization/hostpools/{hostpoolName}/sessionHostConfigurations/default/operationStatuses
```

This command gets a Windows Virtual Desktop SessionHostConfigurationOperationStatus in a Resource Group.

### Example 2: List Windows Virtual Desktop SessionHostConfigurationOperationStatuses

```powershell
Get-AzWvdSessionHostConfigurationOperationStatus -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName
```

```output
Location   Name          Type
--------   ----          ----
eastus     HostPoolName1 Microsoft.DesktopVirtualization/hostpools/{hostpoolName}/sessionHostConfigurations/default/operationStatuses
eastus     HostPoolName2 Microsoft.DesktopVirtualization/hostpools/{hostpoolName}/sessionHostConfigurations/default/operationStatuses
```

This command lists a Windows Virtual Desktop SessionHostConfigurationOperationStatuses in a Resource Group.


### Example 3: List Windows Virtual Desktop SessionHostConfigurationOperationStatuses with filters

```powershell
Get-AzWvdSessionHostConfigurationOperationStatus -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName -isLatest:$false -isNonTerminal
```

```output
Location   Name          Type
--------   ----          ----
eastus     HostPoolName1 Microsoft.DesktopVirtualization/hostpools/{hostpoolName}/sessionHostConfigurations/default/operationStatuses
eastus     HostPoolName2 Microsoft.DesktopVirtualization/hostpools/{hostpoolName}/sessionHostConfigurations/default/operationStatuses
```

This command lists a Windows Virtual Desktop SessionHostConfigurationOperationStatuses in a Resource Group.
