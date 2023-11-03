### Example 1: Get a specified Application Gateway for Containers resource
```powershell
Get-AzAlb -Name test-alb -ResourceGroupName test-rg
```

```output
Name                       ResourceGroupName Location       ProvisioningState
----                       ----------------- --------       -----------------
test-alb                   1bcdr             NorthCentralUS Succeeded
```

This command shows a specific Application Gateway for Containers resource.

### Example 2: List Application Gateway for Containers resources for a resource group
```powershell
Get-AzAlb -ResourceGroupName test-rg
```

```output
Name                         ResourceGroupName Location       ProvisioningState
----                         ----------------- --------       -----------------
AGfC                         test-rg           northcentralus Succeeded
```

This command lists all Application Gateway for Containers resources belonging to a specific resource group.

### Example 3: List Application Gateway for Containers resources for a subscription
```powershell
Get-AzAlb
```

```output
Name                         ResourceGroupName Location       ProvisioningState
----                         ----------------- --------       -----------------
AGfC                         agfc-aks          northcentralus Succeeded
test-alb                     00                westeurope     Succeeded
```

This command lists all Application Gateway for Containers resources belonging to the current subscription context.