$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFunctionApp.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName


# Test variables
$testSubscriptionId = ""

$resourceGroupNameWindowsPremium = "Func99-West-Europe-Win-Premium"
$resourceGroupNameLinuxPremium = "Func99-West-Europe-Linux-Premium"
$resourceGroupNameLinuxConsumption = "Func99-Southeast-Asia-Linux-Consumption"
$resourceGroupNameWindowsConsumption = "Func99-Central-US-Windows-Consumption"

$premiumPlanLocation = "West Europe"
$linuxConsumptionLocation = "Southeast Asia"
$windowsConsumptionLocation = "Central US"
$planNameWorkerTypeLinux = "Functions-West-Europe-Linux"
$planNameWorkerTypeWindows = "Functions-West-Europe-Windows"
$storageAccountWindows = "functionswinstorage"
$storageAccountLinux = "functionslinuxstorage"

function CreateFunctionApps
{
    # Create resource groups
    Write-Host "Creating resource groups" -ForegroundColor Green
    New-AzResourceGroup -Name $resourceGroupNameWindowsPremium -Location $premiumPlanLocation -Force
    New-AzResourceGroup -Name $resourceGroupNameLinuxPremium -Location $premiumPlanLocation -Force
    New-AzResourceGroup -Name $resourceGroupNameLinuxConsumption -Location $linuxConsumptionLocation  -Force
    New-AzResourceGroup -Name $resourceGroupNameWindowsConsumption -Location $windowsConsumptionLocation -Force

    # Create storage accounts
    Write-Host "Creating storage accounts" -ForegroundColor Green
    New-AzStorageAccount -ResourceGroupName $resourceGroupNameWindowsPremium -AccountName $storageAccountWindows -Location $premiumPlanLocation -SkuName Standard_GRS
    New-AzStorageAccount -ResourceGroupName $resourceGroupNameLinuxPremium -AccountName $storageAccountLinux -Location $premiumPlanLocation -SkuName Standard_GRS

    # Create service plans
    $servicePlansToCreate = @(
        @{
            Name = $planNameWorkerTypeWindows
            ResourceGroupName = $resourceGroupNameWindowsPremium      
            Location = $premiumPlanLocation
            MinimumWorkerCount = 1
            MaximumWorkerCount = 10
            Sku = "EP1"
            WorkerType = "Windows"
        },
        @{
            Name = $planNameWorkerTypeLinux
            ResourceGroupName = $resourceGroupNameLinuxPremium        
            Location = $premiumPlanLocation
            MinimumWorkerCount = 1
            MaximumWorkerCount = 10
            Sku = "EP1"
            WorkerType = "Linux"
        }
    )

    Write-Host "Creating service plans" -ForegroundColor Green
    foreach ($servicePlanDefinition in $servicePlansToCreate)
    {
        Write-Host "Creating service plan '$($servicePlanDefinition.Name)'"
        New-AzFunctionAppPlan -ResourceGroupName $servicePlanDefinition.ResourceGroupName `
                            -Name $servicePlanDefinition.Name `
                            -Location $servicePlanDefinition.Location `
                            -MinInstances $servicePlanDefinition.MinimumWorkerCount `
                            -MaxBurst $servicePlanDefinition.MaximumWorkerCount `
                            -Sku $servicePlanDefinition.Sku `
                            -WorkerType $servicePlanDefinition.WorkerType
    }

    # Create function apps
    $functionAppsToCreate = @(
        @{
            FunctionAppHostingPlan = "ServicePlan"
            ResourceGroupName = $resourceGroupNameWindowsPremium
            PlanName = $planNameWorkerTypeWindows
            StorageAccountName = $storageAccountWindows
            OSType = "Windows"
            Runtime = "PowerShell"
            Name = "Func99-Windows-Premium-PowerShell"
        },<#
        @{
            FunctionAppHostingPlan = "ServicePlan"
            ResourceGroupName = $resourceGroupNameLinuxPremium
            PlanName = $planNameWorkerTypeLinux
            StorageAccountName = $storageAccountLinux
            OSType = "Linux"
            Runtime = "Node"
            Name = "Func99-Linux-Premium-Node"
        },
        @{
            FunctionAppHostingPlan = "Consumption"
            ResourceGroupName = $resourceGroupNameWindowsConsumption
            Location = $windowsConsumptionLocation
            StorageAccountName = $storageAccountWindows
            OSType = "Windows"
            Runtime = "DotNet"
            Name = "Func99-Windows-Consumption-DoNet"
        },#>        
        @{
            FunctionAppHostingPlan = "Consumption"
            ResourceGroupName = $resourceGroupNameLinuxConsumption      
            StorageAccountName = $storageAccountLinux
            Location = $linuxConsumptionLocation
            OSType = "Linux"
            Runtime = "Python"
            Name = "Func99-Linux-Consumption-Python"
        }        
    )

    foreach ($fuctionAppDefinition in  $functionAppsToCreate)
    {
        Write-Host "Creating function app $($fuctionAppDefinition.Name)"
        if ($fuctionAppDefinition.FunctionAppHostingPlan -eq "ServicePlan")
        {
            New-AzFunctionApp -Name $fuctionAppDefinition.Name `
                            -ResourceGroupName $fuctionAppDefinition.ResourceGroupName `
                            -PlanName $fuctionAppDefinition.PlanName `
                            -StorageAccount $fuctionAppDefinition.StorageAccountName `
                            -OSType $fuctionAppDefinition.OSType `
                            -Runtime $fuctionAppDefinition.Runtime `
                            -NoWait
        }
        else 
        {
            # Consumption
            New-AzFunctionApp -Name $fuctionAppDefinition.Name `
                            -ResourceGroupName $fuctionAppDefinition.ResourceGroupName `
                            -Location $fuctionAppDefinition.Location  `
                            -StorageAccount $fuctionAppDefinition.StorageAccountName `
                            -OSType $fuctionAppDefinition.OSType `
                            -Runtime $fuctionAppDefinition.Runtime `
                            -NoWait
        }
    }
}

function RemoveFunctionApps
{    
    foreach ($resourceGroupName in @($resourceGroupNameWindowsPremium, $resourceGroupNameLinuxPremium, $resourceGroupNameLinuxConsumption, $resourceGroupNameWindowsConsumption))
    {
        # Get all the functions apps in the test resource groups. This operation automatically deletes the service plans assigned to the function app.
        Get-AzFunctionApp -ResourceGroupName $resourceGroupName | Remove-AzFunctionApp -PassThru
        
        # Delete the storage account 
        Get-AzStorageAccount -ResourceGroupName $resourceGroupName | Remove-AzStorageAccount -Force

        # Delete the resouce group name
        Remove-AzResourceGroup -ResourceGroupName $resourceGroupName -Force
    }
}

Describe 'Functions End to End Tests' {

    BeforeAll {
        #CreateFunctionApps
    }

    AfterAll {
        #RemoveFunctionApps
    }

    It 'Get-AzFunctionAppAvailableLocation -PlanType Premium -OSType Linux' {
        $expectedRegions = @('North Europe','West Europe','Southeast Asia','West US','East US','Japan East','Australia Southeast','Central US EUAP')

        $actualRegions = @(Get-AzFunctionAppAvailableLocation -PlanType Premium -OSType Linux | ForEach-Object{$_.Name})
        
        foreach ($region in $expectedRegions)
        {
            $actualRegions | Should -Contain $region
        }
    }

    It 'Get-AzFunctionAppAvailableLocation -PlanType Premium -OSType Windows' {
        $expectedRegions = @('Central US', 'North Europe', 'West Europe', 'Southeast Asia', 'East Asia', 'West US',
                             'East US', 'Japan West', 'Japan East', 'East US 2', 'North Central US', 'South Central US', 
                             'Brazil South', 'Australia East', 'Australia Southeast', 'East Asia (Stage)', 'West India',
                             'South India', 'Canada Central', 'UK West', 'UK South', 'East US 2 EUAP', 'Central US EUAP',
                             'Korea Central', 'France Central', 'Australia Central 2', 'Australia Central')

        $actualRegions = @(Get-AzFunctionAppAvailableLocation -PlanType Premium -OSType Windows | ForEach-Object{$_.Name})
        
        foreach ($region in $expectedRegions)
        {
            $actualRegions | Should -Contain $region
        }
    }

    It 'Get-AzFunctionApp (GetAll)' {
        $functionApps = @(Get-AzFunctionApp)
        $functionApps.Count | Should -BeGreaterThan 0
    }

    It "Get-AzFunctionApp -Location '$premiumPlanLocation'  (service plan function apps)" {
        $functionApps = @(Get-AzFunctionApp -Location $premiumPlanLocation)
        $functionApps.Count | Should -BeGreaterThan 0
    }

    It "Get-AzFunctionApp -Location '$linuxConsumptionLocation' (consumption function apps)" {
        $functionApps = @(Get-AzFunctionApp -Location $linuxConsumptionLocation )
        $functionApps.Count | Should -BeGreaterThan 0
    }

    It "Get-AzFunctionApp -SubscriptionId $testSubscriptionId (All apps by subscription id)" {
        $functionApps = @(Get-AzFunctionApp -SubscriptionId $testSubscriptionId)
        $functionApps.Count | Should -BeGreaterThan 0
    }

    It "Get-AzFunctionApp -ResourceGroupName '$resourceGroupNameWindowsPremium'  (All apps by resource group name)" {
        $functionApps = @(Get-AzFunctionApp -ResourceGroupName $resourceGroupNameWindowsPremium)
        $functionApps.Count | Should -BeGreaterThan 0
    }

    foreach ($functionDefinition in $functionAppsToCreate)
    {
        It "Get-AzFunctionApp -Name '$($functionDefinition.Name)' and validate properties" {
            $functionApp = Get-AzFunctionApp -Name $functionDefinition.Name `
                                             -ResourceGroupName $functionDefinition.ResourceGroupName `
                                             -SubscriptionId $testSubscriptionId

            $functionApp.OSType | Should -Be $functionDefinition.OSType
            $functionApp.RuntimeName | Should -Be $functionDefinition.Runtime
            $functionApp.ResourceGroupName | Should -Be $functionDefinition.ResourceGroupName
        }
    }

    It 'Get-AzFunctionAppPlan (GetAll)' {
        $functionApps = @(Get-AzFunctionAppPlan)
        $functionApps.Count | Should -BeGreaterThan 0
    }

    It "Get-AzFunctionAppPlan -Location '$premiumPlanLocation' " {
        $functionApps = @(Get-AzFunctionAppPlan -Location $premiumPlanLocation)
        $functionApps.Count | Should -BeGreaterThan 0
    }

    It "Get-AzFunctionAppPlan -SubscriptionId $testSubscriptionId (All service plans by subscription id)" {
        $functionApps = @(Get-AzFunctionAppPlan -SubscriptionId $testSubscriptionId)
        $functionApps.Count | Should -BeGreaterThan 0
    }

    It "Get-AzFunctionAppPlan -ResourceGroupName '$resourceGroupNameWindowsPremium' (All service plans by resource group name)" {
        $functionAppPlans = @(Get-AzFunctionAppPlan -ResourceGroupName $resourceGroupNameWindowsPremium)
        $functionAppPlans.Count | Should -BeGreaterThan 0
    }

    It "Validate Stop-AzFunctionApp and Start-AzFunctionApp" {

        $functionApp = Get-AzfunctionApp -Name "Func99-Windows-Premium-PowerShell" -ResourceGroupName $resourceGroupNameWindowsPremium
        $functionApp.Status | Should -Be "Running"

        $functionApp | Stop-AzFunctionApp
        $functionApp = Get-AzfunctionApp -Name "Func99-Windows-Premium-PowerShell" -ResourceGroupName $resourceGroupNameWindowsPremium
        $functionApp.Status | Should -Be "Stopped"

        $functionApp | Start-AzFunctionApp
        $functionApp = Get-AzfunctionApp -Name "Func99-Windows-Premium-PowerShell" -ResourceGroupName $resourceGroupNameWindowsPremium
        $functionApp.Status | Should -Be "Running"
    }

    It "Validate New-AzFunctionApp and Remove-AzFunctionApp" {

        $functionName = "Func99-Windows-Node-" + (Get-Random).ToString()
         New-AzFunctionApp -Name $functionName `
                                        -ResourceGroupName $resourceGroupNameWindowsPremium `
                                        -PlanName $planNameWorkerTypeWindows `
                                        -StorageAccount $storageAccountWindows `
                                        -OSType "Windows" `
                                        -Runtime "Node" `
                                        -NoWait

        $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium
        $functionApp.OSType | Should -Be "Windows"
        $functionApp.RuntimeName | Should -Be "Node"

        $result = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium | Remove-AzFunctionApp -PassThru
        $result | Should -Be $true

        $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium
        $functionApp | Should -Be $null
    }
}
