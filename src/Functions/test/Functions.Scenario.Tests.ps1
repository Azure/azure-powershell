$TestRecordingFile = Join-Path $PSScriptRoot 'Functions.Tests.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

# Test variables
$testSubscriptionId = "07308f04-ea00-494b-b320-690df74b1ce6"

$resourceGroupNameWindowsPremium = "Func99-West-Europe-Win-Premium"
$resourceGroupNameLinuxPremium = "Func99-West-Europe-Linux-Premium"
$resourceGroupNameLinuxConsumption = "Func99-Southeast-Asia-Linux-Consumption"
$resourceGroupNameWindowsConsumption = "Func99-Central-US-Windows-Consumption"
$resourceGroupNameLinuxConsumptionDotNet = "Func99-Central-US-Linux-Consumption"

$premiumPlanLocation = "West Europe"
$linuxConsumptionLocation = "Southeast Asia"
$linuxConsumptionDotNetLocation ="Central US"
$windowsConsumptionLocation = "Central US"
$planNameWorkerTypeLinux = "Func99-West-Europe-Linux-Premium"
$planNameWorkerTypeWindows = "Func99-West-Europe-Windows-Premium"
$storageAccountWindows = "functionswinstorage888"
$storageAccountLinux = "functionslinuxstorage888"
$userIdentityId = "/subscriptions/07308f04-ea00-494b-b320-690df74b1ce6/resourcegroups/Func99-West-Europe-Win-Premium/providers/Microsoft.ManagedIdentity/userAssignedIdentities/ID1"

function CreateFunctionApps
{
    # Create resource groups
    <#

    Write-Host "Creating resource groups" -ForegroundColor Green
    New-AzResourceGroup -Name $resourceGroupNameWindowsPremium -Location $premiumPlanLocation -Force
    New-AzResourceGroup -Name $resourceGroupNameLinuxPremium -Location $premiumPlanLocation -Force
    New-AzResourceGroup -Name $resourceGroupNameLinuxConsumption -Location $linuxConsumptionLocation  -Force
    New-AzResourceGroup -Name $resourceGroupNameWindowsConsumption -Location $windowsConsumptionLocation -Force
    New-AzResourceGroup -Name $resourceGroupNameLinuxConsumptionDotNet -Location $linuxConsumptionDotNetLocation -Force

    # Create storage accounts
    Write-Host "Creating storage accounts" -ForegroundColor Green
    New-AzStorageAccount -ResourceGroupName $resourceGroupNameWindowsPremium -AccountName $storageAccountWindows -Location $premiumPlanLocation -SkuName Standard_GRS
    New-AzStorageAccount -ResourceGroupName $resourceGroupNameLinuxPremium -AccountName $storageAccountLinux -Location $premiumPlanLocation -SkuName Standard_GRS

    # Create user assigned identity
    New-AzUserAssignedIdentity -ResourceGroupName $resourceGroupNameWindowsPremium  -Name ID1 -location "WestEurope"
    #>

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
        New-AzFunctionAppPlan @servicePlanDefinition
    }

    # Create function apps
    $functionAppsToCreate = @(
        @{
            ResourceGroupName = $resourceGroupNameWindowsPremium
            PlanName = $planNameWorkerTypeWindows
            StorageAccountName = $storageAccountWindows
            OSType = "Windows"
            Runtime = "PowerShell"
            RuntimeVersion = 6.2
            Name = "Func99-Windows-Premium-PowerShell-6-2"
            FunctionsVersion = 3
        },
        @{
            ResourceGroupName = $resourceGroupNameLinuxPremium
            PlanName = $planNameWorkerTypeLinux
            StorageAccountName = $storageAccountLinux
            OSType = "Linux"
            Runtime = "Node"
            RuntimeVersion = 10
            Name = "Func99-Linux-Premium-Node-10"
            FunctionsVersion = 3
        },
        @{
            ResourceGroupName = $resourceGroupNameWindowsConsumption
            Location = $windowsConsumptionLocation
            StorageAccountName = $storageAccountWindows
            OSType = "Windows"
            Runtime = "DotNet"
            RuntimeVersion = 3
            Name = "Func99-Windows-Consumption-DoNet-3"
            FunctionsVersion = 3
        },
        @{
            ResourceGroupName = $resourceGroupNameLinuxConsumption      
            StorageAccountName = $storageAccountLinux
            Location = $linuxConsumptionLocation
            OSType = "Linux"
            Runtime = "Python"
            RuntimeVersion = 3.8
            Name = "Func99-Linux-Consumption-Python-3-8"
            FunctionsVersion = 3
        }
    )

    foreach ($fuctionAppDefinition in  $functionAppsToCreate)
    {
        Write-Host "Creating function app $($fuctionAppDefinition.Name)" -ForegroundColor Yellow
        New-AzFunctionApp @fuctionAppDefinition
    }
}

function RemoveFunctionApps
{
    foreach ($resourceGroupName in @($resourceGroupNameWindowsPremium, $resourceGroupNameLinuxPremium, $resourceGroupNameLinuxConsumption, $resourceGroupNameWindowsConsumption, $resourceGroupNameLinuxConsumptionDotNet))
    {
        # Get all the functions apps in the test resource groups. This operation automatically deletes the service plans assigned to the function app.
        Get-AzFunctionApp -ResourceGroupName $resourceGroupName | Remove-AzFunctionApp -Force -PassThru
        
        # Delete the storage account 
        #Get-AzStorageAccount -ResourceGroupName $resourceGroupName | Remove-AzStorageAccount -Force

        # Delete the resouce group name
        #Remove-AzResourceGroup -ResourceGroupName $resourceGroupName -Force
    }
}

function WaitForJobToComplete
{
    Param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [int]
        $JobId,

        $WaitTimeInSeconds = 3,

        $MaxNumberOfTries = 100
    )

    # Wait for the job to complete. Max timeout is 5 minutes
    $result = $null
    $maxNumberOfTries = 100
    $waitTimeinSeconds = 3

    $tries = 1
    while ($true)
    {
        Write-Verbose "Wait time in seconds: $($tries*$WaitTimeInSeconds)" -Verbose
        Start-Sleep -Seconds $WaitTimeInSeconds
        $result = Get-Job -Id $JobId
        Write-Verbose "JobState: $($result.State)" -Verbose

        if (($tries -ge $maxNumberOfTries) -or ($result.State -ne "Running"))
        {
            Write-Verbose "JobState: $($result.State)" -Verbose
            return $result
        }

        $tries++
    }
}

function ValidateAppSetting
{
    Param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNull()]
        [Hashtable]
        $ExpectedAppSetting,

        [Parameter(Mandatory=$true)]
        [ValidateNotNull()]
        [Hashtable]
        $ActualAppSetting
    )

    $ExpectedAppSetting.Count | Should Be $ActualAppSetting.Count

    foreach ($appSettingName in $ExpectedAppSetting.Keys)
    {
        $ActualAppSetting[$appSettingName] | Should Be $ExpectedAppSetting[$appSettingName]
    }
}

Describe 'Functions End to End Tests' {

    BeforeAll {
        # Set the test subscription
        Get-AzSubscription -SubscriptionId $testSubscriptionId | Set-AzContext
        CreateFunctionApps
    }

    AfterAll {
        RemoveFunctionApps
    }

    function ValidateAvailableLocation
    {
        Param
        (
            [Parameter(Mandatory=$true)]
            [String[]]
            $ActualRegions,

            [Parameter(Mandatory=$true)]
            [String[]]
            $ExpectedRegions
        )

        foreach ($region in $ExpectedRegions)
        {
            $ActualRegions | Should -Contain $region
        }

    }

    It 'Get-AzFunctionAppAvailableLocation set default paramers for -PlanType and -OSType' {

        try
        {
            $filePath = Join-Path $PSScriptRoot "verboseOutput.log"

            &{ Get-AzFunctionAppAvailableLocation } 4>&1 2>&1 > $filePath

            $logFileContent = Get-Content -Path $filePath -Raw
            $logFileContent | Should Match "PlanType not specified. Setting default PlanType to 'Premium'."
            $logFileContent | Should Match "OSType not specified. Setting default OSType to 'Windows'."
        }
        finally
        {
            if (Test-Path $filePath)
            {
                Remove-Item $filePath -Force -ErrorAction SilentlyContinue
            }
        }
    }

    It 'Get-AzFunctionAppAvailableLocation -PlanType Premium -OSType Linux' {

        $expectedRegions = @(
            'Central US'
            'North Europe'
            'West Europe'
            'Southeast Asia'
            'East Asia'
            'West US'
            'East US'
            'Japan West'
            'Japan East'
            'East US 2'
            'North Central US'
            'South Central US'
            'Brazil South'
            'Australia East'
            'Australia Southeast'
            'West India'
            'Canada Central'
            'West Central US'
            'West US 2'
            'UK West'
            'UK South'
            'Central US EUAP'
            'Korea Central'
            'France Central'
            'Norway East'
        )

        $actualRegions = @(Get-AzFunctionAppAvailableLocation -PlanType Premium -OSType Linux | ForEach-Object{$_.Name})
        ValidateAvailableLocation -ActualRegions $actualRegions -ExpectedRegions $expectedRegions
    }

    It 'Get-AzFunctionAppAvailableLocation -PlanType Premium -OSType Windows' {

        $expectedRegions = @(
            'Central US'
            'North Europe'
            'West Europe'
            'Southeast Asia'
            'East Asia'
            'West US'
            'East US'
            'Japan West'
            'Japan East'
            'East US 2'
            'North Central US'
            'South Central US'
            'Brazil South'
            'Australia East'
            'Australia Southeast'
            'East Asia (Stage)'
            'West India'
            'South India'
            'Canada Central'
            'West US 2'
            'UK West'
            'UK South'
            'East US 2 EUAP'
            'Central US EUAP'
            'Korea Central'
            'France Central'
            'Australia Central 2'
            'Australia Central'
            'Germany West Central'
            'Norway East'
        )

        $actualRegions = @(Get-AzFunctionAppAvailableLocation -PlanType Premium -OSType Windows | ForEach-Object{$_.Name})
        ValidateAvailableLocation -ActualRegions $actualRegions -ExpectedRegions $expectedRegions
    }

    It 'Get-AzFunctionAppAvailableLocation -PlanType Consumption -OSType Linux' {

        $expectedRegions = @(
            'Central US'
            'North Europe'
            'West Europe'
            'Southeast Asia'
            'East Asia'
            'West US'
            'East US'
            'Japan West'
            'Japan East'
            'East US 2'
            'North Central US'
            'South Central US'
            'Brazil South'
            'Australia East'
            'Australia Southeast'
            'Central India'
            'West India'
            'South India'
            'Canada Central'
            'Canada East'
            'West Central US'
            'West US 2'
            'UK West'
            'UK South'
            'East US 2 EUAP'
            'Central US EUAP'
            'Korea South'
            'Korea Central'
            'France Central'
            'Australia Central 2'
            'Australia Central'
            'South Africa North'
            'South Africa West'
            'Switzerland North'
            'Germany West Central'
            'Norway East'
        )

        $actualRegions = @(Get-AzFunctionAppAvailableLocation -PlanType Consumption -OSType Linux | ForEach-Object{$_.Name})
        ValidateAvailableLocation -ActualRegions $actualRegions -ExpectedRegions $expectedRegions
    }

    It 'Get-AzFunctionAppAvailableLocation -PlanType Consumption -OSType Windows' {

        $expectedRegions = @(
            'Central US'
            'North Europe'
            'West Europe'
            'Southeast Asia'
            'East Asia'
            'West US'
            'East US'
            'Japan West'
            'Japan East'
            'East US 2'
            'North Central US'
            'South Central US'
            'Brazil South'
            'Australia East'
            'Australia Southeast'
            'Central India'
            'West India'
            'South India'
            'Canada Central'
            'Canada East'
            'West Central US'
            'West US 2'
            'UK West'
            'UK South'
            'East US 2 EUAP'
            'Central US EUAP'
            'Korea Central'
            'France Central'
            'Australia Central 2'
            'Australia Central'
            'South Africa North'
            'Switzerland North'
            'Germany West Central'
        )

        $actualRegions = @(Get-AzFunctionAppAvailableLocation -PlanType Consumption -OSType Windows | ForEach-Object{$_.Name})
        ValidateAvailableLocation -ActualRegions $actualRegions -ExpectedRegions $expectedRegions
    }

    It 'Get-AzFunctionApp (GetAll)' {
        $functionApps = @(Get-AzFunctionApp)
        $functionApps.Count | Should -BeGreaterThan 0
    }

    It "Get-AzFunctionApp -Location '$premiumPlanLocation'  (service plan function apps)" {

        $functionApps = @(Get-AzFunctionApp -Location $premiumPlanLocation)
        $functionApps.Count | Should -BeGreaterThan 0

        $functionApps | ForEach-Object {
            $_.Location | Should Be $premiumPlanLocation
        }
    }

    It "Get-AzFunctionApp -Location '$linuxConsumptionLocation' (consumption function apps)" {

        $functionApps = @(Get-AzFunctionApp -Location $linuxConsumptionLocation)
        $functionApps.Count | Should -BeGreaterThan 0

        $functionApps | ForEach-Object {
            $_.Location | Should Be $linuxConsumptionLocation
        }
    }

    It "Get-AzFunctionApp -SubscriptionId $testSubscriptionId (All apps by subscription id)" {

        $functionApps = @(Get-AzFunctionApp -SubscriptionId $testSubscriptionId)
        $functionApps.Count | Should -BeGreaterThan 0

        $functionApps | ForEach-Object {
            $_.SubscriptionId | Should Be $testSubscriptionId
        }
    }

    It "Get-AzFunctionApp -ResourceGroupName '$resourceGroupNameWindowsPremium' (All apps by resource group name)" {

        $functionApps = @(Get-AzFunctionApp -ResourceGroupName $resourceGroupNameWindowsPremium)
        $functionApps.Count | Should -BeGreaterThan 0

        $functionApps | ForEach-Object {
            $_.ResourceGroupName | Should Be $resourceGroupNameWindowsPremium
        }
    }

    foreach ($functionDefinition in $functionAppsToCreate)
    {
        It "Get-AzFunctionApp -Name '$($functionDefinition.Name)' and validate properties" {
            $functionApp = Get-AzFunctionApp -Name $functionDefinition.Name `
                                             -ResourceGroupName $functionDefinition.ResourceGroupName `
                                             -SubscriptionId $testSubscriptionId

            $functionApp.OSType | Should -Be $functionDefinition.OSType
            $functionApp.Runtime | Should -Be $functionDefinition.Runtime
            $functionApp.ResourceGroupName | Should -Be $functionDefinition.ResourceGroupName
        }
    }

    It 'Get-AzFunctionAppPlan (GetAll)' {
        $functionAppPlans = @(Get-AzFunctionAppPlan)
        $functionAppPlans.Count | Should -BeGreaterThan 0
    }

    It "Get-AzFunctionAppPlan -Location '$premiumPlanLocation' " {

        $functionAppPlans = @(Get-AzFunctionAppPlan -Location $premiumPlanLocation)
        $functionAppPlans.Count | Should -BeGreaterThan 0

        $functionAppPlans | ForEach-Object {
            $_.Location | Should Be $premiumPlanLocation
        }
    }

    It "Get-AzFunctionAppPlan -SubscriptionId $testSubscriptionId (All service plans by subscription id)" {

        $functionAppPlans = @(Get-AzFunctionAppPlan -SubscriptionId $testSubscriptionId)
        $functionAppPlans.Count | Should -BeGreaterThan 0

        $functionAppPlans | ForEach-Object {
            $_.SubscriptionId | Should Be $testSubscriptionId
        }
    }

    It "Get-AzFunctionAppPlan -ResourceGroupName '$resourceGroupNameWindowsPremium' (All service plans by resource group name)" {

        $functionAppPlans = @(Get-AzFunctionAppPlan -ResourceGroupName $resourceGroupNameWindowsPremium)
        $functionAppPlans.Count | Should -BeGreaterThan 0

        $functionAppPlans | ForEach-Object {
            $_.ResourceGroupName | Should Be $resourceGroupNameWindowsPremium
        }
    }

    It "Validate Stop-AzFunctionApp and Start-AzFunctionApp" {

        $functionApp = Get-AzfunctionApp -Name "Func99-Windows-Premium-PowerShell-6-2" -ResourceGroupName $resourceGroupNameWindowsPremium
        $functionApp.Status | Should -Be "Running"

        $functionApp | Stop-AzFunctionApp -Force
        $functionApp = Get-AzfunctionApp -Name "Func99-Windows-Premium-PowerShell-6-2" -ResourceGroupName $resourceGroupNameWindowsPremium
        $functionApp.Status | Should -Be "Stopped"

        $functionApp | Start-AzFunctionApp
        $functionApp = Get-AzfunctionApp -Name "Func99-Windows-Premium-PowerShell-6-2" -ResourceGroupName $resourceGroupNameWindowsPremium
        $functionApp.Status | Should -Be "Running"
    }

    It "Validate New-AzFunctionApp and Remove-AzFunctionApp -Force" {

        $functionName = "Func99-Windows-Node-535740294"
        New-AzFunctionApp -Name $functionName `
                          -ResourceGroupName $resourceGroupNameWindowsPremium `
                          -PlanName $planNameWorkerTypeWindows `
                          -StorageAccount $storageAccountWindows `
                          -OSType "Windows" `
                          -Runtime "Node" `
                          -RuntimeVersion 12 `
                          -FunctionsVersion 3

        $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium
        $functionApp.OSType | Should -Be "Windows"
        $functionApp.Runtime | Should -Be "Node"

        $result = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium | Remove-AzFunctionApp -PassThru -Force
        $result | Should -Be $true

        $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium
        $functionApp | Should -Be $null
    }

    It "Create new AzFunctionApp using a custom Docker image" {

        $functionName = "Func99-Custom-Docker-Image-359659419"

        try
        {
            New-AzFunctionApp -Name $functionName `
                              -ResourceGroupName $resourceGroupNameLinuxPremium `
                              -PlanName $planNameWorkerTypeLinux `
                              -StorageAccount $storageAccountLinux `
                              -DockerImageName "divyag2411/test:customcontainer"

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameLinuxPremium
            $functionApp.OSType | Should -Be "Linux"
            $functionApp.Runtime | Should -Be "Custom Image"

            # For a custom container image, the app setting `FUNCTIONS_EXTENSION_VERSION` should not be set.
            # TODO: Uncomment this line once https://msazure.visualstudio.com/Antares/_workitems/edit/6386493 has been fixed.
            # $functionApp.ApplicationSettings.ContainsKey("FUNCTIONS_EXTENSION_VERSION") | Should -Be $false
        }
        finally
        {
            Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameLinuxPremium -ErrorAction SilentlyContinue |
                Remove-AzFunctionApp -Force -ErrorAction SilentlyContinue
        }
    }

    It "Linux functions apps should not set the 'WEBSITE_NODE_DEFAULT_VERSION' app setting" {

        $functionName = "Func99-Linux-Python-259908045"

        try
        {
            New-AzFunctionApp -Name $functionName `
                              -ResourceGroupName $resourceGroupNameLinuxPremium `
                              -PlanName $planNameWorkerTypeLinux `
                              -StorageAccount $storageAccountLinux `
                              -Runtime Python

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameLinuxPremium
            $functionApp.OSType | Should -Be "Linux"
            $functionApp.Runtime | Should -Be "Python"
            $functionApp.ApplicationSettings.ContainsKey("WEBSITE_NODE_DEFAULT_VERSION") | Should -Be $false
        }
        finally
        {
            Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameLinuxPremium -ErrorAction SilentlyContinue |
                Remove-AzFunctionApp -Force -ErrorAction SilentlyContinue
        }
    }

    # Validate RuntimeVersion default values
    $expectedDefaultRuntimeVersion = @{
        "Linux" = @{
            "2"= @{
                "Node" = "10"
                "DotNet"= "2"
                "Python" = "3.7"
            }
            "3" =  @{
                "Node" = "10"
                "DotNet" = "3"
                "Python" = "3.7"
                "Java" = "8"
            }
        }
        "Windows" = @{
            "2"= @{
                "Node" = "10"
                "DotNet"= "2"
                "PowerShell" = "6.2"
                "Java" = "8"
            }
            "3" =  @{
                "Node" = "10"
                "DotNet" = "3"
                "PowerShell" = "6.2"
                "Java" = "8"
            }
        }
    }

    $LinuxRuntimes = @("DotNet", "Node", "Java", "Python")
    $WindowsRuntimes = @("DotNet", "Node", "Java", "PowerShell")

    $LinuxTestData = @{
        "PlanName" = $planNameWorkerTypeLinux
        "Runtimes" = $LinuxRuntimes
        "StorageAccountName" = $storageAccountLinux
        "resourceGroupName" = $resourceGroupNameLinuxPremium
        "Location" = $linuxConsumptionLocation
    }
    $WindowsTestData = @{
        "PlanName" = $planNameWorkerTypeWindows
        "Runtimes" = $WindowsRuntimes
        "StorageAccountName" = $storageAccountWindows
        "resourceGroupName" = $resourceGroupNameWindowsPremium
        "Location" = $windowsConsumptionLocation
    }

    function GetTestData($OSType)
    {
        if ($OSType -eq "Linux")
        {
            return $LinuxTestData
        }
        else
        {
            return $WindowsTestData
        }
    }

    $filePath = Join-Path $PSScriptRoot "verboseOutput.log"
    #$null = New-Item -Path $filePath -ItemType File -Force

    foreach ($OSType in @("Linux", "Windows"))
    {
        foreach ($functionsVersion in @("2", "3"))
        {
            $testData = GetTestData -OSType $OSType

            $location = $testData["Location"]
            $storageAccountName = $testData["StorageAccountName"]
            $runtimes = $testData["Runtimes"]
            $resourceGroupName = $testData["resourceGroupName"]

            foreach ($runtime in $runtimes)
            {
                if (($functionsVersion -eq "2") -and ($OSType -eq "Linux") -and ($runtime -eq "Java"))
                {
                    # Java 8 is not supported in Linux for Functions V2.
                    continue
                }

                It "Validate New-AzFunctionApp default runtime version for $runtime in Functions version $functionsVersion for $OSType" {

                    # Note: These set of tests are for consumptions function apps. We do this for two things:
                    # 1) Test case is faster, we do not need to validate the service plan name
                    # 2) Validate the -Location code path
                    # We use -WhatIf which performs all the inputs validation for the function app creation, and we return right before sending the request to the backend

                    try
                    {
                        $functionName = "Func99-$OSType-$runtime-417956238"
                        &{
                            New-AzFunctionApp -Name $functionName `
                                              -ResourceGroupName $resourceGroupName `
                                              -Location $location `
                                              -StorageAccountName $storageAccountName `
                                              -OSType $OSType `
                                              -Runtime $runtime `
                                              -FunctionsVersion $functionsVersion `
                                              -WhatIf

                        } 4>&1 2>&1 > $filePath

                        $logFileContent = Get-Content -Path $filePath -Raw
                        $expectectedRuntimeVersion = $expectedDefaultRuntimeVersion[$OSType][$functionsVersion][$runtime]
                        $expectedWarning = "RuntimeVersion not specified. Setting default runtime version for $runtime to '$expectectedRuntimeVersion'."
                        $logFileContent | Should Match $expectedWarning
                    }
                    finally
                    {
                        if (Test-Path $filePath)
                        {
                            Remove-Item $filePath -Force -ErrorAction SilentlyContinue
                        }
                    }
                }
            }
        }
    }

    $testCases = @(
        @{
            "Runtime" = "PowerShell"
            "RuntimeVersion" = "6.2"
            "StorageAccountName" = $storageAccountWindows
            "ResourceGroupName" = $resourceGroupNameWindowsPremium
            "Location" = $windowsConsumptionLocation
            "ExpectedOSType" = "Windows"
        },
        @{
            "Runtime" = "Java"
            "RuntimeVersion" = "8"
            "StorageAccountName" = $storageAccountWindows
            "ResourceGroupName" = $resourceGroupNameWindowsPremium
            "Location" = $windowsConsumptionLocation
            "ExpectedOSType" = "Windows"
        },
        @{
            "Runtime" = "Node"
            "RuntimeVersion" = "10"
            "StorageAccountName" = $storageAccountWindows
            "ResourceGroupName" = $resourceGroupNameWindowsPremium
            "Location" = $windowsConsumptionLocation
            "ExpectedOSType" = "Windows"
        }
        @{
            "Runtime" = "DotNet"
            "RuntimeVersion" = "10"
            "StorageAccountName" = $storageAccountWindows
            "ResourceGroupName" = $resourceGroupNameWindowsPremium
            "Location" = $windowsConsumptionLocation
            "ExpectedOSType" = "Windows"
        },
        @{
            "Runtime" = "Python"
            "RuntimeVersion" = "3.7"
            "StorageAccountName" = $storageAccountLinux
            "ResourceGroupName" = $resourceGroupNameLinuxPremium
            "Location" = $linuxConsumptionLocation
            "ExpectedOSType" = "Linux"
        }
    )

    foreach ($testCase in $testCases)
    {
        $runtime = $testCase["Runtime"]
        $runtimeVersion = $testCase["RuntimeVersion"]
        $resourceGroupName = $testCase["ResourceGroupName"]
        $location = $testCase["Location"]
        $storageAccountName = $testCase["StorageAccountName"]

        $expectedOSType = $testCase["ExpectedOSType"]
        $expectedFunctionsVersion = "3"

        It "Validate New-AzFunctionApp default OSType and FunctionsVersion for $runtime" {

            try
            {
                $functionName = "Func99-$expectedOSType-$runtime-1684505447"

                &{
                    # We use -WhatIf which performs all the inputs validation for the function app creation, and we return right before sending the request to the backend

                    New-AzFunctionApp -Name $functionName `
                                      -ResourceGroupName $resourceGroupName `
                                      -Location $location `
                                      -StorageAccountName $storageAccountName `
                                      -Runtime $runtime `
                                      -RuntimeVersion $runtimeVersion `
                                      -WhatIf

                } 4>&1 2>&1 > $filePath

                $logFileContent = Get-Content -Path $filePath -Raw

                $expectectedFunctionsVersionWarning = "FunctionsVersion not specified. Setting default FunctionsVersion to '$expectedFunctionsVersion'."
                $expectectedOSTypeWarning = "OSType for $runtime is '$expectedOSType'."

                $logFileContent | Should Match $expectectedFunctionsVersionWarning
                $logFileContent | Should Match $expectectedOSTypeWarning

            }
            finally
            {
                if (Test-Path $filePath)
                {
                    Remove-Item $filePath -Force -ErrorAction SilentlyContinue
                }
            }
        }
    }

    # Test cases for runtime and runtime version not supported
    $runtimeVersionNotSupported = @{
        "Linux" = @{
            "2"= @{
                "PowerShell" = "6.2"
                "Java" = "8"
            }
            "3" =  @{
                "Node" = "8"
            }
        }
        "Windows" = @{
            "2"= @{
                "Node" = "12"
                "PowerShell" = "7"
            }
            "3" =  @{
                "Node" = "8"
            }
        }
    }

    foreach ($OSType in $runtimeVersionNotSupported.Keys)
    {
        foreach ($functionsVersion in $runtimeVersionNotSupported[$OSType].Keys)
        {
            $testData = GetTestData -OSType $OSType
            $planName = $testData["PlanName"]
            $storageAccountName = $testData["StorageAccountName"]
            $resourceGroupName = $testData["resourceGroupName"]

            foreach ($runtime in $runtimeVersionNotSupported[$OSType][$functionsVersion].Keys)
            {
                $functionName = "Func99-$OSType-$runtime-369440691"
                $runtimeVersion = $runtimeVersionNotSupported[$OSType][$functionsVersion][$runtime]

                $expectedErrorMessage = "$runtime version $runtimeVersion in Functions version $functionsVersion for $OSType is not supported."
                $expectedErrorMessage += " For supported languages, please visit 'https://docs.microsoft.com/en-us/azure/azure-functions/functions-versions#languages'."

                $errorId = "InvalidRuntimeVersionFor" + $runtime + "In" + $OSType

                It "New-AzFunctionApp Should throw InvalidRuntimeVersionFor $runtime $runtimeVersion in $OSType for Functions version $functionsVersion" {

                    $myError = $null
                    try
                    {
                        New-AzFunctionApp -Name $functionName `
                                          -ResourceGroupName $resourceGroupName `
                                          -PlanName $planName `
                                          -StorageAccountName $storageAccountName `
                                          -OSType $OSType `
                                          -Runtime $runtime `
                                          -RuntimeVersion $runtimeVersion `
                                          -FunctionsVersion $functionsVersion `
                                          -ErrorAction Stop `
                                          -WhatIf
                    }
                    catch
                    {
                        $myError = $_
                    }

                    $myError.FullyQualifiedErrorId | Should Be $errorId
                    $myError.Exception.Message | Should Match $expectedErrorMessage
                }
            }
        }
    }

    It "Validate 'New-AzFunctionAppPlan -AsJob', 'New-AzFunctionApp -AsJob' and 'Remove-AzFunctionApp -Force'" {

        $planName = "Func99-Windows-Premium-205029017"
        $functionName = "Func99-Windows-PowerShell-6-2-1685589760"

        try
        {
            # Create a service plan
            Write-Verbose "Creating function app plan -AsJob" -Verbose
            $functionAppPlanJob = New-AzFunctionAppPlan -Name $planName `
                                                        -ResourceGroupName $resourceGroupNameWindowsPremium `
                                                        -WorkerType "Windows" `
                                                        -MinimumWorkerCount 1 `
                                                        -MaximumWorkerCount 10 `
                                                        -Location $premiumPlanLocation `
                                                        -Sku EP1 `
                                                        -AsJob

            Write-Verbose "Job started." -Verbose
            $result = WaitForJobToComplete -JobId $functionAppPlanJob.Id
            $result.State | Should -Be "Completed"
            $result | Remove-Job -ErrorAction SilentlyContinue

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupNameWindowsPremium
            $plan.WorkerType | Should -Be "Windows"
            $plan.SkuTier | Should -Be "ElasticPremium"
            $plan.SkuName | Should -Be "EP1"

            Write-Verbose "Creating function app -AsJob" -Verbose
            $createFunctionAppJob = New-AzFunctionApp -Name $functionName `
                                                      -ResourceGroupName $resourceGroupNameWindowsPremium `
                                                      -PlanName $planName `
                                                      -StorageAccount $storageAccountWindows `
                                                      -OSType "Windows" `
                                                      -Runtime "PowerShell" `
                                                      -RuntimeVersion 6.2 `
                                                      -FunctionsVersion 3 `
                                                      -AsJob

            Write-Verbose "Job completed. Validating result" -Verbose
            $result = WaitForJobToComplete -JobId $createFunctionAppJob.Id
            $result.State | Should -Be "Completed"
            $result | Remove-Job -ErrorAction SilentlyContinue

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"

            Write-Verbose "Remove function app -AsJob" -Verbose
            $removeFunctionAppJob = Remove-AzFunctionApp -Name $functionName `
                                                         -ResourceGroupName $resourceGroupNameWindowsPremium `
                                                         -AsJob `
                                                         -Force
            $result = WaitForJobToComplete -JobId $removeFunctionAppJob.Id
            $result.State | Should -Be "Completed"
            $result | Remove-Job -ErrorAction SilentlyContinue

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium
            $functionApp | Should -Be $null
        }
        finally
        {
            Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue |
                Remove-AzFunctionApp -Force -ErrorAction SilentlyContinue
        }
    }

    It "New-AzFunctionApp -Location supports locations with no spaces, e.g., 'centralus'" {

        $functionName = "Func99-Windows-PowerShell-6-2-1685589799"
        $resourceGroupNameWindowsConsumption = "Func99-Central-US-Windows-Consumption"
        $location = 'centralus'
        $tags = @{
            "MyTag1" = "MyTag1Value1"
            "MyTag2" = "MyTag1Value2"
        }

        try
        {
            New-AzFunctionApp -Name $functionName `
                              -ResourceGroupName $resourceGroupNameWindowsConsumption `
                              -Location $location `
                              -StorageAccount $storageAccountWindows `
                              -OSType "Windows" `
                              -Runtime "PowerShell" `
                              -RuntimeVersion 6.2 `
                              -FunctionsVersion 3 `
                              -Tag $tags


            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsConsumption
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"
            $functionApp.Location | Should -Be "Central US"

            # Validate tags
            foreach ($tagName in $tags.Keys)
            {
                $functionApp.Tag.AdditionalProperties[$tagName] | Should Be $tags[$tagName]
            }

        }
        finally
        {
            Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsConsumption -ErrorAction SilentlyContinue |
                Remove-AzFunctionApp -Force -ErrorAction SilentlyContinue
        }
    }

    It "New-AzFunctionAppPlan -Location supports locations with no spaces, e.g., 'westeurope'" {

        $planName = "Func99-Windows-Premium-2130268871"
        $resourceGroupNameWindowsPremium = "Func99-West-Europe-Win-Premium"
        $location = 'westeurope'

        try
        {
            New-AzFunctionAppPlan -Name $planName `
                                  -ResourceGroupName $resourceGroupNameWindowsPremium `
                                  -WorkerType "Windows" `
                                  -MinimumWorkerCount 1 `
                                  -MaximumWorkerCount 10 `
                                  -Location $location `
                                  -Sku EP1

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupNameWindowsPremium
            $plan.WorkerType | Should -Be "Windows"
            $plan.SkuTier | Should -Be "ElasticPremium"
            $plan.SkuName | Should -Be "EP1"
            $plan.Location | Should -Be "West Europe"
        }
        finally
        {
            Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue |
                Remove-AzFunctionAppPlan -Force -ErrorAction SilentlyContinue
        }
    }

    It "Create a function app with custom app settings and 'SystemAssigned' managed identity " {

        $functionName = "Func99-Windows-PowerShell-6-2-546452530"
        $appSetting = @{}
        $appSetting.Add("MyAppSetting1", 98765)
        $appSetting.Add("MyAppSetting2", "FooBar")

        try
        {
            New-AzFunctionApp -Name $functionName `
                              -ResourceGroupName $resourceGroupNameWindowsPremium `
                              -PlanName $planNameWorkerTypeWindows `
                              -StorageAccount $storageAccountWindows  `
                              -Runtime PowerShell `
                              -IdentityType SystemAssigned `
                              -AppSetting $appSetting

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"
            $functionApp.IdentityType | Should -Be "SystemAssigned"

            foreach ($appSettingName in $appSetting.Keys)
            {
                $functionApp.ApplicationSettings[$appSettingName] | Should Be $appSetting[$appSettingName]
            }
        }
        finally
        {
            Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue |
                Remove-AzFunctionApp -Force -ErrorAction SilentlyContinue
        }
    }

    It "Create a function app with 'UserAssigned' managed identity " {

        # Make sure user identiy is available
        $userIdentityId | Should Not Be $null

        $functionName = "Func99-Windows-PowerShell-6-2-1009551322"

        try
        {
            New-AzFunctionApp -Name $functionName `
                              -ResourceGroupName $resourceGroupNameWindowsPremium `
                              -PlanName $planNameWorkerTypeWindows `
                              -StorageAccount $storageAccountWindows  `
                              -Runtime PowerShell `
                              -IdentityType UserAssigned `
                              -IdentityID $userIdentityId

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"
            $functionApp.IdentityType | Should -Be "UserAssigned"

            foreach ($appSettingName in $appSetting.Keys)
            {
                $functionApp.ApplicationSettings[$appSettingName] | Should Be $appSetting[$appSettingName]
            }
        }
        finally
        {
            Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue |
                Remove-AzFunctionApp -Force -ErrorAction SilentlyContinue
        }
    }

    It "Creating a function app with 'UserAssigned' managed identity should throw if IdentityID is not provided " {

        # Make sure user identiy is available
        $expetedErrorId = "IdentityIDIsRequiredForUserAssignedIdentity"

        $functionName = "Func99-Windows-PowerShell-6-2-122405106"

        $scriptblock = {
            New-AzFunctionApp -Name $functionName `
                              -ResourceGroupName $resourceGroupNameWindowsPremium `
                              -PlanName $planNameWorkerTypeWindows `
                              -StorageAccount $storageAccountWindows  `
                              -Runtime PowerShell `
                              -IdentityType UserAssigned
        }
        $scriptblock | Should -Throw -ErrorId $expetedErrorId
    }

    It "Validate Get-AzFunctionAppSetting, Update-AzFunctionAppSetting and Delete-AzFunctionAppSetting" {

        $functionName = "Func99-Windows-PowerShell-6-2-97633970"

        $appSetting1 = @{}
        $appSetting1.Add("MyAppSetting1", 456789)
        $appSetting1.Add("MyAppSetting2", "PowerShellRocks")

        $appSetting2 = @{}
        $appSetting2.Add("MyAppSetting3", 123456)
        $appSetting2.Add("MyAppSetting4", "PowerShellIsAwesome")

        try
        {
            New-AzFunctionApp -Name $functionName `
                              -ResourceGroupName $resourceGroupNameWindowsPremium `
                              -PlanName $planNameWorkerTypeWindows `
                              -StorageAccount $storageAccountWindows  `
                              -Runtime PowerShell

            # We can get the application setting in two different ways:
            # 1) (Get-AzFunctionApp).ApplicationSettings
            # 2) Get-AzFunctionAppSetting
            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium
            $expectedAppSettings = $functionApp.ApplicationSettings

            # App settings via Get-AzFunctionAppSetting
            Write-Verbose "Validate '(Get-AzFunctionApp).ApplicationSettings'" -Verbose
            $appSettingsViaGetAzFunctionAppSetting = Get-AzFunctionAppSetting -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium
            ValidateAppSetting -ExpectedAppSetting $expectedAppSettings -ActualAppSetting $appSettingsViaGetAzFunctionAppSetting

            # App settings via Get-AzFunctionAppSetting
            Write-Verbose "Validate 'Get-AzFunctionAppSetting'" -Verbose
            $appSettingsViaGetAzFunctionAppSettingWithPiping = $functionApp | Get-AzFunctionAppSetting
            ValidateAppSetting -ExpectedAppSetting $expectedAppSettings -ActualAppSetting $appSettingsViaGetAzFunctionAppSettingWithPiping

            # Add new app settings
            Write-Verbose "Validate 'Update-AzFunctionAppSetting'" -Verbose
            $updatedAppSettings = Update-AzFunctionAppSetting -Name $functionName `
                                                              -ResourceGroupName $resourceGroupNameWindowsPremium `
                                                              -AppSetting $appSetting1
            foreach ($appSettingName in $appSetting1.Keys)
            {
                $updatedAppSettings[$appSettingName] | Should Be $appSetting1[$appSettingName]
            }

            # Update app settings using piping
            $updatedAppSettings2 = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium |
                                    Update-AzFunctionAppSetting -AppSetting $appSetting2
            foreach ($appSettingName in $appSetting2.Keys)
            {
                $updatedAppSettings2[$appSettingName] | Should Be $appSetting2[$appSettingName]
            }

            # Delete first set of app settings
            Write-Verbose "Validate 'Remove-AzFunctionAppSetting'" -Verbose
            Remove-AzFunctionAppSetting -Name $functionName `
                                        -ResourceGroupName $resourceGroupNameWindowsPremium `
                                        -AppSettingName $appSetting1.Keys

            $appSettings = Get-AzFunctionAppSetting -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium

            foreach ($appSettingName in $appSetting1.Keys)
            {
                $appSettings.ContainsKey($appSettingName) | Should be $false
            }

            # Delete app settings using piping
            Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium |
                Remove-AzFunctionAppSetting -AppSettingName $appSetting2.Keys
            $appSettings = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium | Get-AzFunctionAppSetting

            foreach ($appSettingName in $appSetting2.Keys)
            {
                $appSettings.ContainsKey($appSettingName) | Should be $false
            }
        }
        finally
        {
            Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue |
                Remove-AzFunctionApp -Force -ErrorAction SilentlyContinue
        }
    }

    It "Validate Update-AzFunctionAppPlan and Remove-AzFunctionAppPlan" {

        $planName = "Func99-Windows-Premium-1440317463"
        $location = 'westeurope'
        $minimumWorkerCount = 1
        $maxBurst = 3
        $sku = "EP1"
        $tags = @{
            "MyTag1" = "MyTag1Value1"
            "MyTag2" = "MyTag1Value2"
        }

        try
        {
            Write-Verbose "Creating function app plan '$planName'"
            New-AzFunctionAppPlan -Name $planName `
                                  -ResourceGroupName $resourceGroupNameWindowsPremium `
                                  -WorkerType "Windows" `
                                  -MinimumWorkerCount $minimumWorkerCount `
                                  -MaximumWorkerCount $maxBurst `
                                  -Location $location `
                                  -Sku $sku `
                                  -Tag $tags

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupNameWindowsPremium
            $plan.WorkerType | Should -Be "Windows"
            $plan.SkuTier | Should -Be "ElasticPremium"
            $plan.SkuName | Should -Be $sku
            $plan.Location | Should -Be "West Europe"
            $plan.Capacity | Should -Be $minimumWorkerCount
            $plan.MaximumElasticWorkerCount | Should -Be $maxBurst

            # Validate tags
            foreach ($tagName in $tags.Keys)
            {
                $plan.Tag.AdditionalProperties[$tagName] | Should Be $tags[$tagName]
            }

            # Update function app plan SKU to EP3,  maxBurst to 5 and Tag
            $sku = "EP3"
            $maxBurst = 5
            $tags = @{
                "MyTag3" = "MyTag1Value3"
                "MyTag4" = "MyTag1Value4"
            }

            Update-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupNameWindowsPremium -Sku $sku -MaximumWorkerCount $maxBurst -Tag $tags

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupNameWindowsPremium
            $plan.WorkerType | Should -Be "Windows"
            $plan.SkuTier | Should -Be "ElasticPremium"
            $plan.SkuName | Should -Be $sku
            $plan.Location | Should -Be "West Europe"
            $plan.Capacity | Should -Be $minimumWorkerCount
            $plan.MaximumElasticWorkerCount | Should -Be $maxBurst

            # Validate tags
            foreach ($tagName in $tags.Keys)
            {
                $plan.Tag.AdditionalProperties[$tagName] | Should Be $tags[$tagName]
            }
        }
        finally
        {
            Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue |
                Remove-AzFunctionApp -Force -ErrorAction SilentlyContinue
        }
    }

    It "Validate Update-AzFunctionAppPlan and Remove-AzFunctionAppPlan with piping" {

        $planName = "Func99-Windows-Premium-185853665"
        $location = 'westeurope'
        $minimumWorkerCount = 1
        $maxBurst = 3
        $sku = "EP1"

        try
        {
            Write-Verbose "Creating function app plan '$planName'"
            New-AzFunctionAppPlan -Name $planName `
                                  -ResourceGroupName $resourceGroupNameWindowsPremium `
                                  -WorkerType "Windows" `
                                  -MinimumWorkerCount $minimumWorkerCount `
                                  -MaximumWorkerCount $maxBurst `
                                  -Location $location `
                                  -Sku $sku

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupNameWindowsPremium
            $plan.WorkerType | Should -Be "Windows"
            $plan.SkuTier | Should -Be "ElasticPremium"
            $plan.SkuName | Should -Be $sku
            $plan.Location | Should -Be "West Europe"
            $plan.Capacity | Should -Be $minimumWorkerCount
            $plan.MaximumElasticWorkerCount | Should -Be $maxBurst

            # Update function app plan SKU to EP2 and maxBurst to 7
            $sku = "EP2"
            $maxBurst = 7
            Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupNameWindowsPremium |
                Update-AzFunctionAppPlan -Sku $sku -MaximumWorkerCount $maxBurst

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupNameWindowsPremium
            $plan.WorkerType | Should -Be "Windows"
            $plan.SkuTier | Should -Be "ElasticPremium"
            $plan.SkuName | Should -Be $sku
            $plan.Location | Should -Be "West Europe"
            $plan.Capacity | Should -Be $minimumWorkerCount
            $plan.MaximumElasticWorkerCount | Should -Be $maxBurst

        }
        finally
        {
            Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue |
                Remove-AzFunctionApp -Force -ErrorAction SilentlyContinue
        }
    }

    It "Validate that creating a DotNet function app in consumption for Linux sets the LinuxFxVersion property" {

        $functionName = "Func99-Linux-Consumption-DotNet-3-1659258951"

        try
        {
            New-AzFunctionApp -Name $functionName `
                              -ResourceGroupName $resourceGroupNameLinuxConsumptionDotNet `
                              -Location $linuxConsumptionDotNetLocation `
                              -StorageAccount $storageAccountLinux  `
                              -Runtime DotNet `
                              -FunctionsVersion 3 `
                              -OSType Linux

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameLinuxConsumptionDotNet
            $functionApp.OSType | Should -Be "Linux"
            $functionApp.Runtime | Should -Be "DotNet"
            $functionApp.SiteConfig.LinuxFxVersion | Should -Be "DOTNET|3.1"
        }
        finally
        {
            Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameLinuxConsumptionDotNet -ErrorAction SilentlyContinue |
                Remove-AzFunctionApp -Force -ErrorAction SilentlyContinue
        }
    }

    It "Validate 'Update-AzFunctionAppPlan -AsJob' and 'Remove-AzFunctionAppPlan -AsJob -Force'" {

        $planName = "Func99-Windows-Premium-1400958451"
        $location = 'westeurope'
        $minimumWorkerCount = 1
        $maxBurst = 3
        $sku = "EP1"
        $tags = @{
            "MyTag1" = "MyTag1Value1"
            "MyTag2" = "MyTag1Value2"
        }

        try
        {
            # Create a service plan
            Write-Verbose "Creating function app plan '$planName'"
            New-AzFunctionAppPlan -Name $planName `
                                  -ResourceGroupName $resourceGroupNameWindowsPremium `
                                  -WorkerType "Windows" `
                                  -MinimumWorkerCount $minimumWorkerCount `
                                  -MaximumWorkerCount $maxBurst `
                                  -Location $location `
                                  -Sku $sku `
                                  -Tag $tags

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupNameWindowsPremium
            $plan.WorkerType | Should -Be "Windows"
            $plan.SkuTier | Should -Be "ElasticPremium"
            $plan.SkuName | Should -Be $sku
            $plan.Location | Should -Be "West Europe"
            $plan.Capacity | Should -Be $minimumWorkerCount
            $plan.MaximumElasticWorkerCount | Should -Be $maxBurst

            # Validate tags
            foreach ($tagName in $tags.Keys)
            {
                $plan.Tag.AdditionalProperties[$tagName] | Should Be $tags[$tagName]
            }

            # Update function app plan SKU to EP2 and maxBurst to 5
            $sku = "EP2"
            $functionAppPlanJob = Update-AzFunctionAppPlan -Name $planName `
                                                           -ResourceGroupName $resourceGroupNameWindowsPremium `
                                                           -Sku $sku `
                                                           -AsJob

            Write-Verbose "Update-AzFunctionAppPlan job started." -Verbose
            $result = WaitForJobToComplete -JobId $functionAppPlanJob.Id
            $result.State | Should -Be "Completed"
            $result | Remove-Job -ErrorAction SilentlyContinue

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupNameWindowsPremium
            $plan.WorkerType | Should -Be "Windows"
            $plan.SkuTier | Should -Be "ElasticPremium"
            $plan.SkuName | Should -Be $sku
            $plan.Location | Should -Be "West Europe"
            $plan.Capacity | Should -Be $minimumWorkerCount
            $plan.MaximumElasticWorkerCount | Should -Be $maxBurst

            $removeFunctionAppPlanJob = Remove-AzFunctionAppPlan -Name $planName `
                                                                 -ResourceGroupName $resourceGroupNameWindowsPremium `
                                                                 -AsJob `
                                                                 -Force

            Write-Verbose "Remove-AzFunctionAppPlan job started." -Verbose
            $result = WaitForJobToComplete -JobId $removeFunctionAppPlanJob.Id
            $result.State | Should -Be "Completed"
            $result | Remove-Job -ErrorAction SilentlyContinue
            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupNameWindowsPremium
            $plan | Should -Be $null
        }
        finally
        {
            Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue |
                Remove-AzFunctionAppPlan -Force -ErrorAction SilentlyContinue
        }
    }
}
