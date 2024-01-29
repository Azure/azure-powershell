### Example 1: Get a Azure Virtual Desktop SessionHostManagementOperationStatus by HostPoolName and operationId
```powershell
Get-AzWvdSessionHostManagementsOperationStatus -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName -OperationId operationId
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     operationId Microsoft.DesktopVirtualization/hostpools/sessionhostmanagements/operationstatuses
```

This command gets a Azure Virtual Desktop SessionHostManagementOperationStatus in a Resource Group.

### Example 2: List Azure Virtual Desktop SessionHostManagementOperationStatuses

```powershell
Get-AzWvdSessionHostManagementsOperationStatus -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName
```

```output
Location   Name          Type
--------   ----          ----
eastus     operationId1 Microsoft.DesktopVirtualization/hostpools/sessionhostmanagements/operationstatuses
eastus     operationId2 Microsoft.DesktopVirtualization/hostpools/sessionhostmanagements/operationstatuses
```

This command lists a Azure Virtual Desktop SessionHostManagementOperationStatuses in a Resource Group.


### Example 3: List Azure Virtual Desktop SessionHostManagementOperationStatuses with filters

```powershell
Get-AzWvdSessionHostManagementsOperationStatus -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName -isLatest:$false -isNonTerminal -type Control -action start -isInitiatingOperation:$false 
```

```output
Location   Name          Type
--------   ----          ----
eastus     operationId1 Microsoft.DesktopVirtualization/hostpools/sessionhostmanagements/operationstatuses
eastus     operationId2 Microsoft.DesktopVirtualization/hostpools/sessionhostmanagements/operationstatuses
```

This command lists a Azure Virtual Desktop SessionHostManagementOperationStatuses in a Resource Group.
