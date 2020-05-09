### Example 1: Create a consumption PowerShell function app in Central US.

To create a consumption app, use 'Get-AzFunctionAppAvailableLocation -PlanType Consumption' to see available consumption locations.

Note that the storage account must exist before this operation. For a PowerShell function app, by default, -RuntimeVersion is set to '6.2', -FunctionsVersion is set '3', and -OSType is set to 'Windows'. There are different defaults for each Runtime. For more information, please see 'https://docs.microsoft.com/en-us/azure/azure-functions/functions-versions#languages'


```powershell
PS C:\> New-AzFunctionApp -Name MyUniqueFunctionAppName `
                          -ResourceGroupName MyResourceGroupName `
                          -Location centralUS `
                          -StorageAccount MyStorageAccountName `
                          -Runtime PowerShell
```

### Example 2: Create a PowerShell function app which will be hosted in a service plan.

Note that the service plan and storage account must exist before this operation. By default, for a PowerShell function app, -RuntimeVersion is set to '6.2', -FunctionsVersion is set '3', and -OSType is set to 'Windows'. There are different defaults for each Runtime. For more information, please see 'https://docs.microsoft.com/en-us/azure/azure-functions/functions-versions#languages'

```powershell
PS C:\> New-AzFunctionApp -Name MyUniqueFunctionAppName `
                          -ResourceGroupName MyResourceGroupName `
                          -PlanName MyPlanName `
                          -StorageAccount MyStorageAccountName `
                          -Runtime PowerShell
```

### Example 3: Create a function app using a using a private ACR image.

Note that the service plan and storage account must exist before this operation.

```powershell
PS C:\> New-AzFunctionApp -Name MyUniqueFunctionAppName `
                          -ResourceGroupName MyResourceGroupName `
                          -PlanName MyPlanName `
                          -StorageAccount MyStorageAccountName `
                          -DockerImageName myacr.azurecr.io/myimage:tag

```
