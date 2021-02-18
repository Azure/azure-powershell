. ("$PSScriptRoot\helper.ps1")
function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
function setupEnv() {

    <#
    $localEnvFilePath = Join-Path $PSScriptRoot 'localEnv.json'
    if (Test-Path $localEnvFilePath)
    {
        write-verbose "Local 'localEnv.json' found" -Verbose
        $env = Get-Content -Raw -Path $localEnvFilePath | ConvertFrom-Json
        return
    }
    #>

    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id

    # For any resources you created for test, you should add it to $env here.
    $resourceGroupNameWindowsPremium = "Functions-Test-Windows-Premium-" + (RandomString -len 6)
    $resourceGroupNameLinuxPremium = "Functions-Test-Linux-Premium-" + (RandomString -len 6)
    $resourceGroupNameWindowsConsumption = "Functions-Test-Windows-Consumption-" + (RandomString -len 6)
    $resourceGroupNameLinuxConsumption = "Functions-Test-Linux-Consumption-" + (RandomString -len 6)
    $location = "central us"
    $planNameWorkerTypeLinux = "Functions-Linux-Premium-" + (RandomString -len 6)
    $planNameWorkerTypeWindows = "Functions-Windows-Premium-" + (RandomString -len 6)
    $storageAccountWindows = "functionswinstorage" + (RandomString -len 3)
    $storageAccountLinux = "functionslinuxstorage" + (RandomString -len 3)
    
    # Create resource groups
    Write-Host "Creating resource groups" -ForegroundColor Green
    New-AzResourceGroup -Name $resourceGroupNameWindowsPremium -Location $location | Out-Null
    New-AzResourceGroup -Name $resourceGroupNameLinuxPremium -Location $location | Out-Null
    New-AzResourceGroup -Name $resourceGroupNameWindowsConsumption -Location $location | Out-Null
    New-AzResourceGroup -Name $resourceGroupNameLinuxConsumption -Location $location | Out-Null

    # Create storage accounts
    Write-Host "Creating storage accounts" -ForegroundColor Green
    $storageAccountsToCreate = @(
        @{
            Name = $storageAccountWindows
            ResourceGroupName = $resourceGroupNameWindowsPremium
            Location = $location
            SkuName = "Standard_GRS"
        },
        @{
            Name = $storageAccountLinux
            ResourceGroupName = $resourceGroupNameLinuxPremium
            Location = $location
            SkuName = "Standard_GRS"
        }
    )

    $storageAccountsToCreate | ForEach-Object {
        Write-Host "Creating storage account $($psitem.Name)" -ForegroundColor Yellow
        New-AzStorageAccount @psitem | Out-Null
    }

    $env.add('resourceGroupNameWindowsPremium', $resourceGroupNameWindowsPremium) | Out-Null
    $env.add('resourceGroupNameLinuxPremium', $resourceGroupNameLinuxPremium) | Out-Null
    $env.add('resourceGroupNameWindowsConsumption', $resourceGroupNameWindowsConsumption) | Out-Null
    $env.add('resourceGroupNameLinuxConsumption', $resourceGroupNameLinuxConsumption) | Out-Null
    $env.add('location', $location) | Out-Null
    $env.add('planNameWorkerTypeLinux', $planNameWorkerTypeLinux) | Out-Null
    $env.add('planNameWorkerTypeWindows', $planNameWorkerTypeWindows) | Out-Null
    $env.add('storageAccountWindows', $storageAccountWindows) | Out-Null
    $env.add('storageAccountLinux', $storageAccountLinux) | Out-Null

    # Create service plans
    $servicePlansToCreate = @(
        @{
            Name = $planNameWorkerTypeWindows
            ResourceGroupName = $resourceGroupNameWindowsPremium
            Location = $location
            MinimumWorkerCount = 1
            MaximumWorkerCount = 10
            Sku = "EP1"
            WorkerType = "Windows"
        },
        @{
            Name = $planNameWorkerTypeLinux
            ResourceGroupName = $resourceGroupNameLinuxPremium
            Location = $location
            MinimumWorkerCount = 1
            MaximumWorkerCount = 10
            Sku = "EP1"
            WorkerType = "Linux"
        }
    )

    $env.add('servicePlansToCreate', $servicePlansToCreate) | Out-Null

    $servicePlansToCreate | ForEach-Object {
        Write-Host "Creating service plan $($psitem.Name)" -ForegroundColor Yellow
        New-AzFunctionAppPlan @psitem | Out-Null
    }

    # Create function apps
    $functionAppsToCreate = @(
        @{
            ResourceGroupName = $resourceGroupNameWindowsPremium
            PlanName = $planNameWorkerTypeWindows
            StorageAccountName = $storageAccountWindows
            OSType = "Windows"
            Runtime = "PowerShell"
            RuntimeVersion = '7.0'
            Name = "Functions-PowerShell-7-" + (RandomString -len 6)
            FunctionsVersion = 3
        },
        @{
            ResourceGroupName = $resourceGroupNameLinuxPremium
            PlanName = $planNameWorkerTypeLinux
            StorageAccountName = $storageAccountLinux
            OSType = "Linux"
            Runtime = "Node"
            RuntimeVersion = 10
            Name = "Functions-Node-10-" + (RandomString -len 6)
            FunctionsVersion = 3
        },
        @{
            ResourceGroupName = $resourceGroupNameWindowsConsumption
            Location = $location
            StorageAccountName = $storageAccountWindows
            OSType = "Windows"
            Runtime = "DotNet"
            RuntimeVersion = 3
            Name = "Functions-DoNet-3-" + (RandomString -len 6)
            FunctionsVersion = 3
        },
        @{
            ResourceGroupName = $resourceGroupNameLinuxConsumption      
            StorageAccountName = $storageAccountLinux
            Location = $location
            OSType = "Linux"
            Runtime = "Python"
            RuntimeVersion = 3.8
            Name = "Functions-Python-3-8-" + (RandomString -len 6)
            FunctionsVersion = 3
        }
    )

    $env.add('functionAppsToCreate', $functionAppsToCreate) | Out-Null

    $functionAppsToCreate | ForEach-Object {
        Write-Host "Creating function app $($psitem.Name)" -ForegroundColor Yellow
        New-AzFunctionApp @psitem | Out-Null
    }

    # Create names to be used in the tests
    $functionNamePowerShell = "Functions-PowerShell-" + (RandomString -len 10)
    $functionNameContainer = "Functions-CustomImage-" + (RandomString -len 10)
    $functionNameTestApp = "Functions-TestAppName-" + (RandomString -len 10)
    $functionNameDotNet = "Functions-DotNet-" + (RandomString -len 10)
    $functionNameNode = "Functions-Node-" + (RandomString -len 10)
    $functionNameJava = "Functions-Java-" + (RandomString -len 10)
    $functionNamePython = "Functions-Python-" + (RandomString -len 10)
    $functionAppPlanName= "Functions-MyPlan-" + (RandomString -len 10)

    $env.add('functionNamePowerShell', $functionNamePowerShell) | Out-Null
    $env.add('functionNameContainer', $functionNameContainer) | Out-Null
    $env.add('functionNameTestApp', $functionNameTestApp) | Out-Null
    $env.add('functionNameDotNet', $functionNameDotNet) | Out-Null
    $env.add('functionNameNode', $functionNameNode) | Out-Null
    $env.add('functionNameJava', $functionNameJava) | Out-Null
    $env.add('functionNamePython', $functionNamePython) | Out-Null
    $env.add('functionAppPlanName', $functionAppPlanName) | Out-Null

    # Create user assigned identity
    $identityInfo = New-AzUserAssignedIdentity -ResourceGroupName $env.resourceGroupNameWindowsPremium -Name ID1 -Location $env.location
    $env.add('identityInfo', $identityInfo) | Out-Null

    # Create new ApplInsights project
    $newApplInsightsName = $functionNamePowerShell + "-new"
    $newApplInsights = New-AzApplicationInsights -ResourceGroupName $env.resourceGroupNameWindowsPremium -Name $newApplInsightsName -Location $location
    $env.add('newApplInsights', $newApplInsights) | Out-Null

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}

function cleanupEnv() {
    # Clean test resources
    Remove-AzResourceGroup -Name $env.resourceGroupNameWindowsPremium
    Remove-AzResourceGroup -Name $env.resourceGroupNameLinuxPremium
    Remove-AzResourceGroup -Name $env.resourceGroupNameWindowsConsumption
    Remove-AzResourceGroup -Name $env.resourceGroupNameLinuxConsumption
}

