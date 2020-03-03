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
$planNameWorkerTypeLinux = "Func99-West-Europe-Linux-Premium"
$planNameWorkerTypeWindows = "Func99-West-Europe-Windows-Premium"
$storageAccountWindows = "functionswinstorage999"
$storageAccountLinux = "functionslinuxstorage999"

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
            RuntimeVersion = 6
            Name = "Func99-Windows-Premium-PowerShell-6"
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
        Write-Warning "Wait time in seconds: $($tries*$WaitTimeInSeconds)"
        Start-Sleep -Seconds $WaitTimeInSeconds
        $result = Get-Job -Id $JobId
        Write-Warning "JobState: $($result.State)"

        if (($tries -ge $maxNumberOfTries) -or ($result.State -ne "Running"))
        {
            Write-Warning "JobState: $($result.State)"
            return $result
        }

        $tries++
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

        $expectedRegions = @(
            'North Europe'
            'West Europe'
            'Southeast Asia'
            'West US'
            'East US'
            'Japan East'
            'South Central US'
            'Australia Southeast'
            'Central US EUAP'
        )

        $actualRegions = @(Get-AzFunctionAppAvailableLocation -PlanType Premium -OSType Linux | ForEach-Object{$_.Name})
        
        foreach ($region in $expectedRegions)
        {
            $actualRegions | Should -Contain $region
        }
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
        )

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

        $functionApp = Get-AzfunctionApp -Name "Func99-Windows-Premium-PowerShell-6" -ResourceGroupName $resourceGroupNameWindowsPremium
        $functionApp.Status | Should -Be "Running"

        $functionApp | Stop-AzFunctionApp -Force
        $functionApp = Get-AzfunctionApp -Name "Func99-Windows-Premium-PowerShell-6" -ResourceGroupName $resourceGroupNameWindowsPremium
        $functionApp.Status | Should -Be "Stopped"

        $functionApp | Start-AzFunctionApp
        $functionApp = Get-AzfunctionApp -Name "Func99-Windows-Premium-PowerShell-6" -ResourceGroupName $resourceGroupNameWindowsPremium
        $functionApp.Status | Should -Be "Running"
    }

    It "Validate New-AzFunctionApp and Remove-AzFunctionApp -Force" {

        $functionName = "Func99-Windows-Node-" + (Get-Random).ToString()
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

    It "Validate New-AzFunctionAppPlan -AsJob, New-AzFunctionApp -AsJob and Remove-AzFunctionApp -Force" {

        $planName = "Func99-Windows-Premium" + (Get-Random).ToString()
        $functionName = "Func99-Windows-PowerShell-6-" + (Get-Random).ToString()

        try
        {
            # Create a service plan
            Write-Warning "Creating service plan"
            $functionAppPlanJob = New-AzFunctionAppPlan -Name $planName `
                                                        -ResourceGroupName $resourceGroupNameWindowsPremium `
                                                        -WorkerType "Windows" `
                                                        -MinimumWorkerCount 1 `
                                                        -MaximumWorkerCount 10 `
                                                        -Location $premiumPlanLocation `
                                                        -Sku EP1 `
                                                        -AsJob

            Write-Warning "Job started."
            $result = WaitForJobToComplete -JobId $functionAppPlanJob.Id
            $result.State | Should -Be "Completed"
            $result | Receive-Job -ErrorAction SilentlyContinue |  Remove-Job  -ErrorAction SilentlyContinue

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupNameWindowsPremium
            $plan.WorkerType | Should -Be "Windows"
            $plan.SkuTier | Should -Be "ElasticPremium"
            $plan.SkuName | Should -Be "EP1"

            Write-Warning "Creating service plan -AsJob"
            $functionAppPlan = New-AzFunctionApp -Name $functionName `
                                                 -ResourceGroupName $resourceGroupNameWindowsPremium `
                                                 -PlanName $planName `
                                                 -StorageAccount $storageAccountWindows `
                                                 -OSType "Windows" `
                                                 -Runtime "PowerShell" `
                                                 -RuntimeVersion 6 `
                                                 -FunctionsVersion 3 `
                                                 -AsJob

            Write-Warning "Job completed. Validating result"
            $result = WaitForJobToComplete -JobId $functionAppPlan.Id
            $result.State | Should -Be "Completed"
            $result | Receive-Job -ErrorAction SilentlyContinue |  Remove-Job -ErrorAction SilentlyContinue

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"
        }
        finally
        {
            Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue | Remove-AzFunctionApp -Force -ErrorAction SilentlyContinue
        }
    }

    It "Create new AzFunctionApp using a custom container image" {

        $functionName = "Func99-Linux-Dedicated-CentralU-" + (Get-Random).ToString()
        New-AzFunctionApp -Name $functionName `
                          -ResourceGroupName $resourceGroupNameLinuxPremium `
                          -PlanName $planNameWorkerTypeLinux `
                          -StorageAccount $storageAccountLinux `
                          -DockerImageName "divyag2411/test:customcontainer"

        $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameLinuxPremium
        $functionApp.OSType | Should -Be "Linux"
        $functionApp.Runtime | Should -Be "Custom Image"

        $result = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameLinuxPremium | Remove-AzFunctionApp -PassThru -Force
        $result | Should -Be $true

        $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupNameWindowsPremium
        $functionApp | Should -Be $null
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
                "PowerShell" = "6"
                "Java" = "8"
            }
            "3" =  @{
                "Node" = "10"
                "DotNet" = "3"
                "PowerShell" = "6"
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

    $filePath = Join-Path $PSScriptRoot "warningOutput.log"
    $null = New-Item -Path $filePath -ItemType File -Force

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

                    try
                    {
                        $functionName = "Func99-$OSType-$runtime-" + (Get-Random).ToString()
                        &{
                            New-AzFunctionApp -Name $functionName `
                                              -ResourceGroupName $resourceGroupName `
                                              -Location $location `
                                              -StorageAccountName $storageAccountName `
                                              -OSType $OSType `
                                              -Runtime $runtime `
                                              -FunctionsVersion $functionsVersion `
                                              -WhatIf

                        } 3>&1 2>&1 > $filePath

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
            "RuntimeVersion" = "6"
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
                $functionName = "Func99-$expectedOSType-$runtime-" + (Get-Random).ToString()

                &{
                    New-AzFunctionApp -Name $functionName `
                                      -ResourceGroupName $resourceGroupName `
                                      -Location $location `
                                      -StorageAccountName $storageAccountName `
                                      -Runtime $runtime `
                                      -RuntimeVersion $runtimeVersion `
                                      -WhatIf

                } 3>&1 2>&1 > $filePath

                $logFileContent = Get-Content -Path $filePath -Raw

                $expectectedFunctionsVersionWarning = "FunctionsVersion not specified. Setting default FunctionsVersion to '$expectedFunctionsVersion'."
                $expectectedOSTypeWarning = "OSType not specified. Setting default OSType for $runtime to '$expectedOSType'."

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
                "PowerShell" = "6"
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
                $functionName = "Func99-$OSType-$runtime-" + (Get-Random).ToString()
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
}
