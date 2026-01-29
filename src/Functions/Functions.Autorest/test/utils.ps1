. ("$PSScriptRoot\helper.ps1")
function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

$env = @{}
function setupEnv() {

    # Set the test mode for the Az.Functions module
    # This is requried to support playback mode (given that we need to have the same values in teh payload for each function app creation)
    # Currently this flag is used to have a constant share name when creation an app
    $env:FunctionsTestMode = $true

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
    $resourceGroupsToCreate = @(
        @{
            Name = $resourceGroupNameWindowsPremium
            Location = $location
        },
        @{
            Name = $resourceGroupNameLinuxPremium
            Location = $location
        },
        @{
            Name = $resourceGroupNameWindowsConsumption
            Location = $location
        },
        @{
            Name = $resourceGroupNameLinuxConsumption
            Location = $location
        }
    )

    Write-Host "Creating resource groups..." -ForegroundColor Green
    $resourceGroupsToCreate | ForEach-Object {
        Write-Host "Resource group: $($psitem.Name)" -ForegroundColor Yellow
        New-AzResourceGroup @psitem | Out-Null
    }

    # Create storage accounts
    Write-Host "Creating storage accounts..." -ForegroundColor Green
    $storageAccountsToCreate = @(
        @{
            Name = $storageAccountWindows
            ResourceGroupName = $resourceGroupNameWindowsPremium
            Location = $location
            SkuName = "Standard_GRS"
            AllowBlobPublicAccess = $false
        },
        @{
            Name = $storageAccountLinux
            ResourceGroupName = $resourceGroupNameLinuxPremium
            Location = $location
            SkuName = "Standard_GRS"
            AllowBlobPublicAccess = $false
        }
    )

    $storageAccountsToCreate | ForEach-Object {
        Write-Host "Storage account: $($psitem.Name)" -ForegroundColor Yellow
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

    Write-Host "Creating function app plans..." -ForegroundColor Green
    $servicePlansToCreate | ForEach-Object {
        Write-Host "Plan: $($psitem.Name)" -ForegroundColor Yellow
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
            RuntimeVersion = '7.4'
            Name = "Functions-PowerShell-74-" + (RandomString -len 6)
            FunctionsVersion = 4
        },
        @{
            ResourceGroupName = $resourceGroupNameLinuxPremium
            PlanName = $planNameWorkerTypeLinux
            StorageAccountName = $storageAccountLinux
            OSType = "Linux"
            Runtime = "Node"
            RuntimeVersion = 22
            Name = "Functions-Node-22-" + (RandomString -len 6)
            FunctionsVersion = 4
        },
        @{
            ResourceGroupName = $resourceGroupNameWindowsConsumption
            Location = $location
            StorageAccountName = $storageAccountWindows
            OSType = "Windows"
            Runtime = "DotNet"
            RuntimeVersion = 8
            Name = "Functions-DotNet-8-" + (RandomString -len 6)
            FunctionsVersion = 4
        },
        @{
            ResourceGroupName = $resourceGroupNameLinuxConsumption
            StorageAccountName = $storageAccountLinux
            Location = $location
            OSType = "Linux"
            Runtime = "Python"
            RuntimeVersion = "3.12"
            Name = "Functions-Python-312-" + (RandomString -len 6)
            FunctionsVersion = 4
        }
    )

    $env.add('functionAppsToCreate', $functionAppsToCreate) | Out-Null

    Write-Host "Creating function apps..." -ForegroundColor Green
    $functionAppsToCreate | ForEach-Object {
        Write-Host "Function app: $($psitem.Name)" -ForegroundColor Yellow
        New-AzFunctionApp @psitem | Out-Null
    }

    # Create names to be used in the tests
    $planNameWorkerTypeWindowsNew = "Func-Windows-Premium-New-" + (RandomString -len 6)
    $planNameWorkerTypeWindowsNew2 = "Func-Windows-Premium-New2-" + (RandomString -len 6)
    $planNameWorkerTypeWindowsNew3 = "Func-Windows-Premium-New3-" + (RandomString -len 6)
    $functionNamePowerShell = "Functions-PowerShellTest-" + (RandomString -len 10)
    $functionNamePowerShellNew1 = "Func-PowerShell-NewTest1-" + (RandomString -len 10)
    $functionNamePowerShellNew2 = "Func-PowerShell-NewTest2-" + (RandomString -len 10)
    $functionNamePowerShellNew3 = "Func-PowerShell-NewTest3-" + (RandomString -len 10)
    $functionNamePowerShellNew4 = "Func-PowerShell-NewTest4-" + (RandomString -len 10)
    $functionNamePowerShellNew5 = "Func-PowerShell-NewTest5-" + (RandomString -len 10)
    $functionNameContainer = "Functions-CustomImage-" + (RandomString -len 10)
    $functionNameTestApp = "Functions-TestAppName-" + (RandomString -len 10)
    $functionNameDotNet = "Functions-DotNet-" + (RandomString -len 10)
    $functionNameNode = "Functions-Node-" + (RandomString -len 10)
    $functionNameJava = "Functions-Java-" + (RandomString -len 10)
    $functionNamePython = "Functions-Python-" + (RandomString -len 10)
    $functionAppPlanName= "Functions-MyPlan-" + (RandomString -len 10)
    $functionAppTestPlanName= "Functions-MyTestPlan1-" + (RandomString -len 10)
    $functionAppTestPlanName2= "Functions-MyTestPlan2-" + (RandomString -len 10)
    $functionNameDotNetIsolated = "Functions-DotNet-Isolated" + (RandomString -len 10)
    $functionNameCustomHandler = "Functions-CustomHandler" + (RandomString -len 10)

    $env.add('planNameWorkerTypeWindowsNew', $planNameWorkerTypeWindowsNew) | Out-Null
    $env.add('planNameWorkerTypeWindowsNew2', $planNameWorkerTypeWindowsNew2) | Out-Null
    $env.add('planNameWorkerTypeWindowsNew3', $planNameWorkerTypeWindowsNew3) | Out-Null
    $env.add('functionNamePowerShell', $functionNamePowerShell) | Out-Null
    $env.add('functionNamePowerShellNew1', $functionNamePowerShellNew1) | Out-Null
    $env.add('functionNamePowerShellNew2', $functionNamePowerShellNew2) | Out-Null
    $env.add('functionNamePowerShellNew3', $functionNamePowerShellNew3) | Out-Null
    $env.add('functionNamePowerShellNew4', $functionNamePowerShellNew4) | Out-Null
    $env.add('functionNamePowerShellNew5', $functionNamePowerShellNew5) | Out-Null
    $env.add('functionNameContainer', $functionNameContainer) | Out-Null
    $env.add('functionNameTestApp', $functionNameTestApp) | Out-Null
    $env.add('functionNameDotNet', $functionNameDotNet) | Out-Null
    $env.add('functionNameNode', $functionNameNode) | Out-Null
    $env.add('functionNameJava', $functionNameJava) | Out-Null
    $env.add('functionNamePython', $functionNamePython) | Out-Null
    $env.add('functionAppPlanName', $functionAppPlanName) | Out-Null
    $env.add('functionAppTestPlanName', $functionAppTestPlanName) | Out-Null
    $env.add('functionAppTestPlanName2', $functionAppTestPlanName2) | Out-Null
    $env.add('functionNameDotNetIsolated', $functionNameDotNetIsolated) | Out-Null
    $env.add('functionNameCustomHandler', $functionNameCustomHandler) | Out-Null

    # Create user assigned identity
    Write-Host "Create user assigned managed identity" -ForegroundColor Yellow
    $identityInfo = New-AzUserAssignedIdentity -ResourceGroupName $resourceGroupNameWindowsPremium -Name ID1 -Location $location
    $env.add('identityInfo', $identityInfo) | Out-Null

    # Create new ApplInsights project
    Write-Host "Create application insights project" -ForegroundColor Yellow
    $newApplInsightsName = $functionNamePowerShell + "-new"
    $newApplInsights = New-AzApplicationInsights -ResourceGroupName $resourceGroupNameWindowsPremium -Name $newApplInsightsName -Location $location
    $env.add('newApplInsights', $newApplInsights) | Out-Null

    # Create resources for Azure Container Apps tests
    Write-Host "Creating resources for Azure Container Apps tests..." -ForegroundColor Green
    $acaTestRunId = RandomString -len 4
    $resourceGroupNameACA = "Functions-ACA-Test-" + $acaTestRunId
    $locationACA = "WestCentralUS"
    $storageAccountNameACA = "funcacastotorage" + $acaTestRunId
    $workSpaceACAName = "workspace-azpstest" + $acaTestRunId
    $environmentACAName = "azps-envtest" + $acaTestRunId

    Write-Host "Create resource group." -ForegroundColor Yellow
    New-AzResourceGroup -Name $resourceGroupNameACA -Location $locationACA | Out-Null
    Write-Host "Create storage account." -ForegroundColor Yellow
    New-AzStorageAccount -Name $storageAccountNameACA `
                         -ResourceGroupName $resourceGroupNameACA `
                         -Location $locationACA `
                         -SkuName Standard_GRS `
                         -Kind StorageV2 `
                         -AllowBlobPublicAccess $false | Out-Null

    $env.add('acaTestRunId', $acaTestRunId) | Out-Null
    $env.add('resourceGroupNameACA', $resourceGroupNameACA) | Out-Null
    $env.add('locationACA', $locationACA) | Out-Null
    $env.add('storageAccountNameACA', $storageAccountNameACA) | Out-Null
    $env.add('workSpaceACAName', $workSpaceACAName) | Out-Null
    $env.add('environmentACAName', $environmentACAName) | Out-Null

    # Create Flex Consumption resources
    Write-Host "Creating Flex Consumption resources..." -ForegroundColor Green
    $flexTestRunId = RandomString -len 4
    $flexLocation = 'East Asia'
    $flexResourceGroupName = "Functions-Flex-RG-" + $flexTestRunId

    # Create resource group for Flex Consumption tests
    Write-Host "Creating resource group: $flexResourceGroupName in location: $flexLocation" -ForegroundColor Yellow
    New-AzResourceGroup -Name $flexResourceGroupName -Location $flexLocation | Out-Null

    # Create one storage account per runtime for Flex Consumption tests.
    # The storage account name must be unique and at most 24 characters long.
    Write-Host "Creating storage accounts for Flex Consumption tests" -ForegroundColor Green

    foreach ($runtimeName in @("DotNet-Isolated", "Node", "Java", "PowerShell", "Python", "Custom"))
    {
        # Create unique storage account name: flexapp[runtime]sa[runid]
        $runtimeNameNormalized = $runtimeName.Replace("-", "").ToLower()
        $storageAccountName = "flexapp" + $runtimeNameNormalized + "sa" + $flexTestRunId
        $storageAccountName = $storageAccountName.Substring(0, [Math]::Min($storageAccountName.Length, 24))

        Write-Host "Creating storage account: $storageAccountName in resource group: $flexResourceGroupName" -ForegroundColor Yellow
        New-AzStorageAccount -ResourceGroupName $flexResourceGroupName `
                            -Name $storageAccountName `
                            -Location $flexLocation `
                            -SkuName Standard_GRS `
                            -Kind StorageV2 `
                            -AllowBlobPublicAccess $false | Out-Null

        # Add to $env with a key like 'flexStorageAccountDotNetIsolated', 'flexStorageAccountNode', etc.
        $envKey = "flexStorageAccount" + $runtimeName.Replace("-", "")
        $env.add($envKey, $storageAccountName) | Out-Null

        # Wait between storage account creations to avoid conflicts
        Start-TestSleep -Seconds 2
    }

    Write-Host "Create user assigned managed identity for Flex Consumption tests" -ForegroundColor Yellow
    $flexIdentityName = "my-flex-app-uai-" + $flexTestRunId
    $flexIdentityInfo = New-AzUserAssignedIdentity -ResourceGroupName $flexResourceGroupName -Name $flexIdentityName -Location $flexLocation

    $env.add('flexTestRunId', $flexTestRunId) | Out-Null
    $env.add('flexLocation', $flexLocation) | Out-Null
    $env.add('flexResourceGroupName', $flexResourceGroupName) | Out-Null
    $env.add('flexIdentityInfo', $flexIdentityInfo) | Out-Null

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }

    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}

function cleanupEnv() {

    $env:FunctionsTestMode = $null

    # Clean test resources
    Remove-AzResourceGroup -Name $env.resourceGroupNameWindowsPremium
    Remove-AzResourceGroup -Name $env.resourceGroupNameLinuxPremium
    Remove-AzResourceGroup -Name $env.resourceGroupNameWindowsConsumption
    Remove-AzResourceGroup -Name $env.resourceGroupNameLinuxConsumption
    Remove-AzResourceGroup -Name $env.flexResourceGroupName
    Remove-AzResourceGroup -Name $env.resourceGroupNameACA
}

