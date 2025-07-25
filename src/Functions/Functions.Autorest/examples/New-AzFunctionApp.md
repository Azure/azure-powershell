### Example 1: Create a consumption PowerShell function app in Central US.

```powershell
New-AzFunctionApp -Name MyUniqueFunctionAppName `
                  -ResourceGroupName MyResourceGroupName `
                  -Location centralUS `
                  -StorageAccountName MyStorageAccountName `
                  -Runtime PowerShell
```

This command creates a consumption PowerShell function app in Central US.

### Example 2: Create a PowerShell function app which will be hosted in a service plan.


```powershell
New-AzFunctionApp -Name MyUniqueFunctionAppName `
                  -ResourceGroupName MyResourceGroupName `
                  -PlanName MyPlanName `
                  -StorageAccountName MyStorageAccountName `
                  -Runtime PowerShell
```

This command creates a PowerShell function app which will be hosted in a service plan.

### Example 3: Create a function app using a using a private ACR image.

Note that the service plan and storage account must exist before this operation.

```powershell
New-AzFunctionApp -Name MyUniqueFunctionAppName `
                  -ResourceGroupName MyResourceGroupName `
                  -PlanName MyPlanName `
                  -StorageAccountName MyStorageAccountName `
                  -DockerImageName myacr.azurecr.io/myimage:tag
```

This command creates a function app using a using a private ACR image.

### Example 4: Create a function app on container app.

```powershell
New-AzFunctionApp -Name MyUniqueFunctionAppName `
                  -ResourceGroupName MyResourceGroupName `
                  -StorageAccountName MyStorageAccountName `
                  -Environment MyEnvironment `
                  -WorkloadProfileName MyWorkloadProfileName
```

This command create a function app on container app using the default .Net image.