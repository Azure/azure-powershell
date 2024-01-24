
### Example 1: Get a Windows Virtual Desktop SessionHostManagementOperationStatus by HostPoolName and operationId

```powershell
Get-AzWvdSessionHostManagementOperationStatus -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName -OperationId operationId
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     HostPoolName Microsoft.DesktopVirtualization/hostpools/{hostpoolName}/sessionHostManagements/default/operationStatuses
```

This command gets a Windows Virtual Desktop SessionHostManagementOperationStatus in a Resource Group.

### Example 2: List Windows Virtual Desktop SessionHostManagementOperationStatuses

```powershell
Get-AzWvdSessionHostManagementOperationStatus -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName
```

```output
Location   Name          Type
--------   ----          ----
eastus     HostPoolName1 Microsoft.DesktopVirtualization/hostpools/{hostpoolName}/sessionHostManagements/default/operationStatuses
eastus     HostPoolName2 Microsoft.DesktopVirtualization/hostpools/{hostpoolName}/sessionHostManagements/default/operationStatuses
```

This command lists a Windows Virtual Desktop SessionHostManagementOperationStatuses in a Resource Group.


### Example 3: List Windows Virtual Desktop SessionHostManagementOperationStatuses with filters

```powershell
Get-AzWvdSessionHostManagementOperationStatus -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName -isLatest:$false -isNonTerminal -type Control -action start -isInitiatingOperation:$false 
```

```output
Location   Name          Type
--------   ----          ----
eastus     HostPoolName1 Microsoft.DesktopVirtualization/hostpools/{hostpoolName}/sessionHostManagements/default/operationStatuses
eastus     HostPoolName2 Microsoft.DesktopVirtualization/hostpools/{hostpoolName}/sessionHostManagements/default/operationStatuses
```

This command lists a Windows Virtual Desktop SessionHostManagementOperationStatuses in a Resource Group.
