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
$resourceGroupName = "MyTestRGName"
$location = "eastus"
$storageAccountName = "mystorageacctname123"
$workSpaceName = "workspace-testname1"
$environmentName = "azps-test-env1"
$functionAppName = "mydotnet8acaapp1"

# Create resource group and storage account
New-AzResourceGroup -Name $resourceGroupName -Location $location
New-AzStorageAccount -Name $storageAccountName -ResourceGroupName $resourceGroupName -Location $location -SkuName "Standard_GRS"

# Create Log Analytics workspace
New-AzOperationalInsightsWorkspace -ResourceGroupName $resourceGroupName `
                                    -Name $workSpaceName `
                                    -Sku PerGB2018 `
                                    -Location $location `
                                    -PublicNetworkAccessForIngestion "Enabled" `
                                    -PublicNetworkAccessForQuery "Enabled"

$customId = (Get-AzOperationalInsightsWorkspace -ResourceGroupName $resourceGroupName -Name $workSpaceName).CustomerId
$sharedKey = (Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName $resourceGroupName -Name $workSpaceName).PrimarySharedKey
$workloadProfile = New-AzContainerAppWorkloadProfileObject -Name "Consumption" -Type "Consumption"

# Create managed environment
New-AzContainerAppManagedEnv -Name $environmentName `
                             -ResourceGroupName $resourceGroupName `
                             -Location $location `
                             -AppLogConfigurationDestination "log-analytics" `
                             -LogAnalyticConfigurationCustomerId $CustomId `
                             -LogAnalyticConfigurationSharedKey $SharedKey `
                             -VnetConfigurationInternal:$false `
                             -WorkloadProfile $workloadProfile

# Create function app on container app
New-AzFunctionApp -Name MyUniqueFunctionAppName `
                  -ResourceGroupName $resourceGroupName `
                  -StorageAccountName $storageAccountName `
                  -Environment $environmentName `
                  -WorkloadProfileName $workloadProfile.Name
```

This command create a function app on container app using the default .Net image.