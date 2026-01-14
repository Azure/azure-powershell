$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFunctionApp.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

$env:FunctionsTestMode = $true

Describe 'New-AzFunctionApp' {

    It 'CustomDockerImage' {

        $appName = $env.functionNameContainer
        Write-Verbose "App name: $appName" -Verbose

        $resourceGroupName = $env.resourceGroupNameLinuxPremium
        Write-Verbose "Resource group name: $resourceGroupName" -Verbose

        $planName = $env.planNameWorkerTypeLinux
        Write-Verbose "Plan name: $planName" -Verbose

        $storageAccountName = $env.storageAccountLinux
        Write-Verbose "Storage account name: $storageAccountName" -Verbose

        $expectedLinuxFxVersion = "DOCKER|divyag2411/test:customcontainer"

        try
        {
            Write-Verbose "Creating function app with a custom docker image" -Verbose
            New-AzFunctionApp -Name $appName `
                              -ResourceGroupName $resourceGroupName `
                              -PlanName $planName `
                              -StorageAccount $storageAccountName `
                              -DockerImageName "divyag2411/test:customcontainer"

            Write-Verbose "Validating function app properties..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName
            $functionApp.OSType | Should -Be "Linux"
            $functionApp.Runtime | Should -Be "Custom Image"
            $functionApp.SiteConfig.LinuxFxVersion | Should -Be $expectedLinuxFxVersion

            # For a custom container image, the app setting `FUNCTIONS_EXTENSION_VERSION` should not be set.
            # TODO: Uncomment this line once https://msazure.visualstudio.com/Antares/_workitems/edit/6386493 has been fixed.
            # $functionApp.ApplicationSettings.ContainsKey("FUNCTIONS_EXTENSION_VERSION") | Should -Be $false
        }
        finally
        {
            Write-Verbose "Delete the function app..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Write-Verbose "Removing function app $appName using -InputObject" -Verbose
                Remove-AzFunctionApp -InputObject $functionApp -Force #-ErrorAction SilentlyContinue
            }
        }
    }

    $LinuxRuntimes = @("DotNet", "DotNet-Isolated", "Node", "Java", "Python", "Custom")
    $WindowsRuntimes = @("DotNet", "DotNet-Isolated","Node", "Java", "PowerShell", "Custom")

    $LinuxTestData = @{
        "PlanName" = $env.planNameWorkerTypeLinux
        "Runtimes" = $LinuxRuntimes
        "StorageAccountName" = $env.storageAccountLinux
        "resourceGroupName" = $env.resourceGroupNameLinuxPremium
        "Location" = $env.location
    }
    $WindowsTestData = @{
        "PlanName" = $env.planNameWorkerTypeWindows
        "Runtimes" = $WindowsRuntimes
        "StorageAccountName" = $env.storageAccountWindows
        "resourceGroupName" = $env.resourceGroupNameWindowsPremium
        "Location" = $env.location
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

    $testCases = @(
        @{
            "Runtime" = "Custom"
            "RuntimeVersion" = $null
            "StorageAccountName" = $env.storageAccountWindows
            "ResourceGroupName" = $env.resourceGroupNameWindowsPremium
            "Location" = $env.location
            "ExpectedOSType" = "Windows"
        },
        @{
            "Runtime" = "DotNet-Isolated"
            "RuntimeVersion" = "9"
            "StorageAccountName" = $env.storageAccountWindows
            "ResourceGroupName" = $env.resourceGroupNameWindowsPremium
            "Location" = $env.location
            "ExpectedOSType" = "Windows"
        },
        @{
            "Runtime" = "PowerShell"
            "RuntimeVersion" = "7.4"
            "StorageAccountName" = $env.storageAccountWindows
            "ResourceGroupName" = $env.resourceGroupNameWindowsPremium
            "Location" = $env.location
            "ExpectedOSType" = "Windows"
        },
        @{
            "Runtime" = "Java"
            "RuntimeVersion" = "21"
            "StorageAccountName" = $env.storageAccountWindows
            "ResourceGroupName" = $env.resourceGroupNameWindowsPremium
            "Location" = $env.location
            "ExpectedOSType" = "Windows"
        },
        @{
            "Runtime" = "Node"
            "RuntimeVersion" = "22"
            "StorageAccountName" = $env.storageAccountWindows
            "ResourceGroupName" = $env.resourceGroupNameWindowsPremium
            "Location" = $env.location
            "ExpectedOSType" = "Windows"
        }
    )

    $filePath = Join-Path $PSScriptRoot "verboseOutput.log"

    foreach ($testCase in $testCases)
    {
        $runtime = $testCase["Runtime"]
        $runtimeVersion = $testCase["RuntimeVersion"]
        $resourceGroupName = $testCase["ResourceGroupName"]
        $location = $testCase["Location"]
        $storageAccountName = $testCase["StorageAccountName"]

        $expectedOSType = $testCase["ExpectedOSType"]
        $expectedFunctionsVersion = "4"

        It "Validate New-AzFunctionApp default OSType and FunctionsVersion for $runtime" {

            try
            {
                $appName =  $env.functionNameTestApp
                Write-Verbose "App name: $appName" -Verbose
                Write-Verbose "Resource group name: $resourceGroupName" -Verbose
                Write-Verbose "Storage account name: $storageAccountName" -Verbose
                Write-Verbose "Location: $location" -Verbose
                Write-Verbose "Runtime: $runtime" -Verbose
                Write-Verbose "RuntimeVersion: $runtimeVersion" -Verbose

                & {
                    # We use -WhatIf which performs all the inputs validation for the function app creation, and we return right before sending the request to the backend
                    if ($runtimeVersion)
                    {
                        Write-Verbose "Create function app with runtime version" -Verbose
                        New-AzFunctionApp -Name $appName `
                                          -ResourceGroupName $resourceGroupName `
                                          -Location $location `
                                          -StorageAccountName $storageAccountName `
                                          -Runtime $runtime `
                                          -RuntimeVersion $runtimeVersion `
                                          -WhatIf
                    }
                    else
                    {
                        Write-Verbose "Create function app without runtime version" -Verbose
                        New-AzFunctionApp -Name $appName `
                                          -ResourceGroupName $resourceGroupName `
                                          -Location $location `
                                          -StorageAccountName $storageAccountName `
                                          -Runtime $runtime `
                                          -WhatIf
                    }

                } 3>&1 2>&1 > $filePath

                $logFileContent = Get-Content -Path $filePath -Raw

                Write-Verbose "Validate the default FunctionsVersion and OSType" -Verbose
                $expectectedFunctionsVersionWarning = "FunctionsVersion not specified. Setting default value to '$expectedFunctionsVersion'."
                $expectectedOSTypeWarning = "OSType not specified. Setting default value to '$expectedOSType'."

                $logFileContent | Should Match $expectectedFunctionsVersionWarning
                $logFileContent | Should Match $expectectedOSTypeWarning

            }
            finally
            {
                Write-Verbose "Cleaning up the verbose output log file..." -Verbose
                if (Test-Path $filePath)
                {
                    Remove-Item $filePath -Force -ErrorAction SilentlyContinue
                }
            }
        }
    }

    # Test cases for runtime version not supported.
    # For these scenarios, the runtime is supported for the os type, but the runtime version is invalid.
    $runtimeVersionNotSupported = @{
        "Linux" = @{
            "4" =  @{
                "Python" = "3.6"
            }
        }
        "Windows" = @{
            "4" =  @{
                "PowerShell" = "6.2"
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
                $appName = $env.functionNameTestApp
                $runtimeVersion = $runtimeVersionNotSupported[$OSType][$functionsVersion][$runtime]
                Write-Verbose "App name: $appName" -Verbose
                Write-Verbose "Resource group name: $resourceGroupName" -Verbose
                Write-Verbose "Storage account name: $storageAccountName" -Verbose
                Write-Verbose "Plan name: $planName" -Verbose
                Write-Verbose "Runtime: $runtime" -Verbose
                Write-Verbose "RuntimeVersion: $runtimeVersion" -Verbose
                Write-Verbose "OSType: $OSType" -Verbose
                Write-Verbose "FunctionsVersion: $functionsVersion" -Verbose

                $expectedErrorMessage = "Runtime '$runtime' version '$runtimeVersion' in Functions version '$functionsVersion' on '$OSType' is not supported."
                $errorId = "RuntimeVersionNotSupported"

                It "New-AzFunctionApp should throw InvalidRuntimeVersion for $runtime $runtimeVersion in $OSType for Functions version $functionsVersion" {

                    $myError = $null
                    try
                    {
                        New-AzFunctionApp -Name $appName `
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
                        Write-Verbose "Catch the expected exception" -Verbose
                        $myError = $_
                    }

                    Write-Verbose "Validate FullyQualifiedErrorId" -Verbose
                    $myError.FullyQualifiedErrorId | Should Be $errorId
                    Write-Verbose "Validate Exception.Message" -Verbose
                    $myError.Exception.Message | Should Match $expectedErrorMessage
                }
            }
        }
    }

    It "New-AzFunctionApp should throw RuntimeNotSupported when trying to create a function app for an invalid runtime" {

        $myError = $null
        $errorId = "RuntimeNotSupported"
        $expectedErrorMessage = "Runtime 'Go' is not supported. Currently supported runtimes: 'Custom', 'DotNet', 'DotNet-Isolated', 'Java', 'Node', 'PowerShell', 'Python'."
        try
        {
            Write-Verbose "Create function app with an invalid runtime" -Verbose
            New-AzFunctionApp -Name $env.functionNameTestApp `
                              -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                              -PlanName $env.planNameWorkerTypeWindows `
                              -StorageAccount $env.storageAccountWindows  `
                              -Runtime Go
        }
        catch
        {
             Write-Verbose "Catch the expected exception" -Verbose
            $myError = $_
        }

        Write-Verbose "Validate FullyQualifiedErrorId" -Verbose
        $myError.FullyQualifiedErrorId | Should Be $errorId
        Write-Verbose "Validate Exception.Message" -Verbose
        $myError.Exception.Message | Should Match $expectedErrorMessage
    }

    It "Linux functions apps should not set the 'WEBSITE_NODE_DEFAULT_VERSION' app setting" {

        $appName = $env.functionNamePython
        Write-Verbose "App name: $appName" -Verbose

        $resourceGroupName = $env.resourceGroupNameLinuxPremium
        Write-Verbose "Resource group name: $resourceGroupName" -Verbose

        $storageAccountName = $env.storageAccountLinux
        Write-Verbose "Storage account name: $storageAccountName" -Verbose

        $planName = $env.planNameWorkerTypeLinux
        Write-Verbose "Plan name: $planName" -Verbose

        $runtime = "python"
        Write-Verbose "runtime: $runtime" -Verbose

        $runtimeVersion = "3.13"
        Write-Verbose "Runtime version: $runtimeVersion" -Verbose

        try
        {
            Write-Verbose "Creating Linux function app with Python runtime" -Verbose
            New-AzFunctionApp -Name $appName `
                              -ResourceGroupName $resourceGroupName  `
                              -PlanName $planName `
                              -StorageAccount $storageAccountName `
                              -Runtime $runtime `
                              -RuntimeVersion $runtimeVersion `
                              -FunctionsVersion 4

            Write-Verbose "Validating function app properties..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName 
            $functionApp.OSType | Should -Be "Linux"
            $functionApp.Runtime | Should -Be $runtime
            $functionApp.SiteConfig.LinuxFxVersion | Should -Be "$runtime|$runtimeVersion"

            Write-Verbose "Validating app settings..." -Verbose
            $applicationSettings = Get-AzFunctionAppSetting -Name $appName -ResourceGroupName $resourceGroupName 
            $applicationSettings.ContainsKey("WEBSITE_NODE_DEFAULT_VERSION") | Should -Be $false
        }
        finally
        {
            Write-Verbose "Cleaning up the function app..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Write-Verbose "Removing function app $appName using -InputObject" -Verbose
                Remove-AzFunctionApp -InputObject $functionApp -Force #-ErrorAction SilentlyContinue
            }
        }
    }

    It "Create Windows Consumption app and validiate app properties: 1) Location 2) App settings 3) Connection string suffix" {

        # Validate the following:
        #    - Location parameter supports passing a region with no spaces, e.g., `centralus` for Central US.
        #    - Allow empty app settings
        #    - App settings:
        #      - WEBSITE_CONTENTSHARE
        #      - AzureWebJobsStorage, AzureWebJobsDashboard, and WEBSITE_CONTENTAZUREFILECONNECTIONSTRING (these should include a suffix)
        #    - Tag values
        #

        $appName = $env.functionNamePowerShell
        $resourceGroupName = $env.resourceGroupNameWindowsConsumption
        $storageAccountName = $env.storageAccountWindows
        $location = 'centralus'
        $tags = @{
            "MyTag1" = "MyTag1Value1"
            "MyTag2" = "MyTag1Value2"
        }

        $appSetting = @{
            "AppSetting1" = "Value1"
            "AppSetting2" = $null
            "AppSetting3" = ""
        }

        Write-Verbose "App name: $appName" -Verbose
        Write-Verbose "Resource group name: $resourceGroupName" -Verbose
        Write-Verbose "Storage account name: $storageAccountName" -Verbose
        Write-Verbose "Location: $location" -Verbose
        Write-Verbose "Tags: $($tags | Out-String)" -Verbose

        try
        {
            New-AzFunctionApp -Name $appName `
                              -ResourceGroupName $resourceGroupName `
                              -Location $location `
                              -StorageAccount $storageAccountName `
                              -OSType "Windows" `
                              -Runtime "PowerShell" `
                              -RuntimeVersion "7.4" `
                              -FunctionsVersion 4 `
                              -Tag $tags `
                              -AppSetting $appSetting

            Write-Verbose "Validating function app properties..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"
            $functionApp.Location | Should -Be "Central US"

            Write-Verbose "Validating tags..." -Verbose
            foreach ($tagName in $tags.Keys)
            {
                $functionApp.Tag.AdditionalProperties[$tagName] | Should Be $tags[$tagName]
            }

            Write-Verbose "Validating app settings..." -Verbose
            $applicationSettings = Get-AzFunctionAppSetting -Name $appName -ResourceGroupName $env.resourceGroupNameWindowsConsumption
            foreach ($appSettingName in $appSetting.Keys)
            {
                $expectedValue = $appSetting[$appSettingName]
                if ($expectedValue -eq $null)
                {
                    # null app settings are created as an empty string.
                    $expectedValue = ""
                }

                $applicationSettings[$appSettingName] | Should Be $expectedValue
            }

            Write-Verbose "Validating 'WEBSITE_CONTENTSHARE' app setting..." -Verbose
            $applicationSettings["WEBSITE_CONTENTSHARE"] | Should Match $appName

            Write-Verbose "Validating storage account connection string suffix..." -Verbose
            $expectedSuffix = GetStorageAccountEndpointSuffix
            foreach ($appSettingName in @("AzureWebJobsStorage", "WEBSITE_CONTENTAZUREFILECONNECTIONSTRING"))
            {
                $applicationSettings[$appSettingName] | Should Match $expectedSuffix
            }
        }
        finally
        {
            Write-Verbose "Cleaning up the function app..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Write-Verbose "Removing function app $appName using -InputObject" -Verbose
                Remove-AzFunctionApp -InputObject $functionApp -Force #-ErrorAction SilentlyContinue
            }
        }
    }

    It "Create a function app with 'UserAssigned' managed identity " {

        $appName = $env.functionNamePowerShell
        $identityInfo = $env.identityInfo
        $resourceGroupName = $env.resourceGroupNameWindowsPremium
        $storageAccountName = $env.storageAccountWindows
        $planName = $env.planNameWorkerTypeWindows
        $runtime = "PowerShell"
        $runtimeVersion = 7.4

        Write-Verbose "App name: $appName" -Verbose
        Write-Verbose "IdentityInfo id: $($identityInfo.Id)" -Verbose
        Write-Verbose "Resource group name: $resourceGroupName" -Verbose
        Write-Verbose "Storage account name: $storageAccountName" -Verbose
        Write-Verbose "Plan name: $planName" -Verbose
        Write-Verbose "Tags: $($tags | Out-String)" -Verbose

        try
        {
            Write-Verbose "Creating function app with a UserAssigned managed identity" -Verbose
            New-AzFunctionApp -Name $appName `
                              -ResourceGroupName $resourceGroupName `
                              -PlanName $planName `
                              -StorageAccount $storageAccountName  `
                              -Runtime $runtime `
                              -RuntimeVersion $runtimeVersion `
                              -FunctionsVersion 4 `
                              -IdentityType UserAssigned `
                              -IdentityID $identityInfo.Id `
                              -OSType Windows

            Write-Verbose "Validating function app properties..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be $runtime
            $functionApp.IdentityType | Should -Be "UserAssigned"
        }
        finally
        {
            Write-Verbose  "Cleaning up the function app..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Write-Verbose "Removing function app $appName using -InputObject" -Verbose
                Remove-AzFunctionApp -InputObject $functionApp -Force #-ErrorAction SilentlyContinue
            }
        }
    }

    It "Create a function app with custom app settings and 'SystemAssigned' managed identity " {

        $appName = $env.functionNamePowerShell
        Write-Verbose "App name: $appName" -Verbose

        $resourceGroupName = $env.resourceGroupNameWindowsPremium
        Write-Verbose "Resource group name: $resourceGroupName" -Verbose

        $planName = $env.planNameWorkerTypeWindows
        Write-Verbose "Plan name: $planName" -Verbose

        $storageAccountName = $env.storageAccountWindows
        Write-Verbose "Storage account name: $storageAccountName" -Verbose

        $runtime = "PowerShell"
        Write-Verbose "Runtime: $runtime" -Verbose

        $runtimeVersion = 7.4
        Write-Verbose "RuntimeVersion: $runtimeVersion" -Verbose

        $appSetting = @{}
        $appSetting.Add("MyAppSetting1", 98765)
        $appSetting.Add("MyAppSetting2", "FooBar")

        try
        {
            Write-Verbose "Creating function app with a SystemAssigned managed identity" -Verbose
            New-AzFunctionApp -Name $appName `
                              -ResourceGroupName $resourceGroupName `
                              -PlanName $planName `
                              -StorageAccount  $storageAccountName  `
                              -Runtime $runtime `
                              -RuntimeVersion $runtimeVersion `
                              -FunctionsVersion 4 `
                              -IdentityType SystemAssigned `
                              -AppSetting $appSetting

            Write-Verbose "Validating function app properties..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be $runtime
            $functionApp.IdentityType | Should -Be "SystemAssigned"

            # Get app settings
            Write-Verbose "Validating app settings..." -Verbose
            $applicationSettings = Get-AzFunctionAppSetting -Name $appName -ResourceGroupName $env.resourceGroupNameWindowsPremium

            foreach ($appSettingName in $appSetting.Keys)
            {
                $applicationSettings[$appSettingName] | Should Be $appSetting[$appSettingName]
            }
        }
        finally
        {
            Write-Verbose "Cleaning up the function app..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $env.resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Write-Verbose "Removing function app $appName using -InputObject" -Verbose
                Remove-AzFunctionApp -InputObject $functionApp -Force #-ErrorAction SilentlyContinue
            }
        }
    }

    It "Creating a function app with 'UserAssigned' managed identity should throw if IdentityID is not provided " {

        # Make sure user identiy is available
        $expectedErrorId = "IdentityIDIsRequiredForUserAssignedIdentity"

        $appName = $env.functionNamePowerShell
        Write-Verbose "App name: $appName" -Verbose

        $resourceGroupName = $env.resourceGroupNameWindowsPremium
        Write-Verbose "Resource group name: $resourceGroupName" -Verbose

        $planName = $env.planNameWorkerTypeWindows
        Write-Verbose "Plan name: $planName" -Verbose

        $storageAccountName = $env.storageAccountWindows
        Write-Verbose "Storage account name: $storageAccountName" -Verbose

        $runtime = "PowerShell"
        Write-Verbose "Runtime: $runtime" -Verbose

        $runtimeVersion = 7.4
        Write-Verbose "RuntimeVersion: $runtimeVersion" -Verbose

        $scriptblock = {
            Write-Verbose "Creating function app with a UserAssigned managed identity but without IdentityID" -Verbose
            New-AzFunctionApp -Name $appName `
                              -ResourceGroupName $resourceGroupName `
                              -PlanName $planName `
                              -StorageAccount $storageAccountName  `
                              -Runtime $runtime `
                              -RuntimeVersion $runtimeVersion `
                              -FunctionsVersion 4 `
                              -IdentityType UserAssigned
        }
        Write-Verbose "Validate that the expected expetedErrorId is thrown" -Verbose
        $scriptblock | Should -Throw -ErrorId $expectedErrorId
    }

    It "Validate that creating a DotNet function app in consumption for Linux sets the LinuxFxVersion property" {

        $appName = $env.functionNameDotNet
        Write-Verbose "App name: $appName" -Verbose

        $resourceGroupName = $env.resourceGroupNameLinuxConsumption
        Write-Verbose "Resource group name: $resourceGroupName" -Verbose

        $storageAccountName = $env.storageAccountLinux
        Write-Verbose "Storage account name: $storageAccountName" -Verbose

        $location = $env.location
        Write-Verbose "Location: $location" -Verbose

        $runtime = "dotnet"
        Write-Verbose "Runtime: $runtime" -Verbose

        $runtimeVersion = 8
        Write-Verbose "RuntimeVersion: $runtimeVersion" -Verbose

        $expectedLinuxFxVersion = "DOTNET|8.0"

        try
        {
            Write-Verbose "Creating a DotNet function app in consumption for Linux" -Verbose
            New-AzFunctionApp -Name $appName `
                              -ResourceGroupName  $resourceGroupName `
                              -Location $location `
                              -StorageAccount $storageAccountName  `
                              -Runtime $runtime `
                              -RuntimeVersion $runtimeVersion `
                              -FunctionsVersion 4 `
                              -OSType Linux

            Write-Verbose "Validating function app properties..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName
            $functionApp.OSType | Should -Be "Linux"
            $functionApp.Runtime | Should -Be $runtime
            $functionApp.SiteConfig.LinuxFxVersion | Should -Be $expectedLinuxFxVersion
        }
        finally
        {
            Write-Verbose "Cleaning up the function app..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName  $resourceGroupName -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Write-Verbose "Removing function app $appName using -InputObject" -Verbose
                Remove-AzFunctionApp -InputObject $functionApp -Force #-ErrorAction SilentlyContinue
            }
        }
    }

    It "Validate that creating a function app with -DisableApplicationInsights does not create an Application Insights project." {

        $appName = $env.functionNamePowerShell
        Write-Verbose "App name: $appName" -Verbose

        $resourceGroupName = $env.resourceGroupNameWindowsPremium
        Write-Verbose "Resource group name: $resourceGroupName" -Verbose

        $planName = $env.planNameWorkerTypeWindows
        Write-Verbose "Plan name: $planName" -Verbose

        $storageAccountName = $env.storageAccountWindows
        Write-Verbose "Storage account name: $storageAccountName" -Verbose

        $runtime = "PowerShell"
        Write-Verbose "Runtime: $runtime" -Verbose

        $runtimeVersion = 7.4
        Write-Verbose "RuntimeVersion: $runtimeVersion" -Verbose

        $appSettingName = "APPLICATIONINSIGHTS_CONNECTION_STRING"

        try
        {
            Write-Verbose "Creating function app with -DisableApplicationInsights" -Verbose
            New-AzFunctionApp -Name $appName `
                              -ResourceGroupName $resourceGroupName `
                              -PlanName $planName `
                              -StorageAccount $storageAccountName  `
                              -Runtime $runtime `
                              -RuntimeVersion $runtimeVersion `
                              -FunctionsVersion 4 `
                              -DisableApplicationInsights

            Write-Verbose "Validating function app properties..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"

            Write-Verbose "Validating that the app setting '$appSettingName' does not exist..." -Verbose
            $applicationSettings = Get-AzFunctionAppSetting -Name $appName -ResourceGroupName $resourceGroupName
            $applicationSettings.ContainsKey($appSettingName) | Should -Be $false
        }
        finally
        {
            Write-Verbose "Cleaning up the function app..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Write-Verbose "Removing function app $appName using -InputObject" -Verbose
                Remove-AzFunctionApp -InputObject $functionApp -Force #-ErrorAction SilentlyContinue
            }
        }
    }

    # These is the list of function apps to be created
    $functionAppCreationTestCases = @(
        # Consumption apps
        @{
            "Name" = $env.functionNameJava
            "Runtime" = "Java"
            "RuntimeVersion" = "21"
            "StorageAccountName" = $env.storageAccountLinux
            "ResourceGroupName" = $env.resourceGroupNameLinuxConsumption
            "Location" = $env.location
            "OSType" = "Linux"
            "ExpectedSiteConfig" = @{
                "LinuxFxVersion" = "Java|21"
            }
        },
        @{
            "Name" = $env.functionNameNode
            "Runtime" = "Node"
            "RuntimeVersion" = "22"
            "StorageAccountName" = $env.storageAccountLinux
            "ResourceGroupName" = $env.resourceGroupNameLinuxConsumption
            "Location" = $env.location
            "OSType" = "Linux"
            "ExpectedSiteConfig" = @{
                "LinuxFxVersion" = "Node|22"
            }
        }
        # Premium function app service plan
        @{
            "Name" = $env.functionNameDotNetIsolated
            "Runtime" = "DotNet-Isolated"
            "RuntimeVersion" = "9"
            "StorageAccountName" = $env.storageAccountWindows
            "ResourceGroupName" = $env.resourceGroupNameWindowsPremium
            "PlanName" = $env.planNameWorkerTypeWindows
            "OSType" = "Windows"
            "ExpectedSiteConfig" = @{
                "NetFrameworkVersion" = "v9.0"
            }
            "ExpectedAppSettings" = @{
                "FUNCTIONS_WORKER_RUNTIME" = "dotnet-isolated"
            }
        }
        @{
            "Name" = $env.functionNameCustomHandler
            "Runtime" = "Custom"
            "RuntimeVersion" = $null
            "StorageAccountName" = $env.storageAccountWindows
            "ResourceGroupName" = $env.resourceGroupNameWindowsPremium
            "PlanName" = $env.planNameWorkerTypeWindows
            "OSType" = "Windows"
            "ExpectedSiteConfig" = @{
                "netFrameworkVersion" = "v6.0"
            }
            "ExpectedAppSettings" = @{
                "FUNCTIONS_WORKER_RUNTIME" = "custom"
            }
        }
    )

    foreach ($testCase in $functionAppCreationTestCases)
    {
        $functionsVersion = 4
        $appName =  $testCase["Name"]
        $runtime = $testCase["Runtime"]
        $runtimeVersion = $testCase["RuntimeVersion"]
        $resourceGroupName = $testCase["ResourceGroupName"]
        $storageAccountName = $testCase["StorageAccountName"]
        $OSType = $testCase["OSType"]

        Write-Verbose "App name: $appName" -Verbose
        Write-Verbose "Resource group name: $resourceGroupName" -Verbose
        Write-Verbose "Storage account name: $storageAccountName" -Verbose
        Write-Verbose "Runtime: $runtime" -Verbose
        Write-Verbose "RuntimeVersion: $runtimeVersion" -Verbose
        Write-Verbose "OSType: $OSType" -Verbose
        Write-Verbose "FunctionsVersion: $functionsVersion" -Verbose

        $planType = $null
        $location = $null
        $planName = $null

        if ($testCase.ContainsKey("location"))
        {
            $location = $testCase["Location"]
            $planType = "Consumption"
        }
        else
        {
            $planType = "Premium"
            $planName = $testCase["PlanName"]
        }

        Write-Verbose "PlanType: $planType" -Verbose
        if ($planName) { Write-Verbose "PlanName: $planName" -Verbose }
        if ($location) { Write-Verbose "Location: $location" -Verbose }

        It "Create v4 $OSType $runtime $runtimeVersion Function App hosted in a $planType plan." {

            try
            {
                if ($planType -eq "Consumption")
                {
                    if ($runtimeVersion)
                    {
                        New-AzFunctionApp -Name $appName `
                                          -ResourceGroupName $resourceGroupName `
                                          -Location $location `
                                          -StorageAccountName $storageAccountName `
                                          -FunctionsVersion $functionsVersion `
                                          -OSType $OSType `
                                          -Runtime $runtime `
                                          -RuntimeVersion $runtimeVersion
                    }
                    else
                    {
                        New-AzFunctionApp -Name $appName `
                                          -ResourceGroupName $resourceGroupName `
                                          -Location $location `
                                          -StorageAccountName $storageAccountName `
                                          -FunctionsVersion $functionsVersion `
                                          -OSType $OSType `
                                          -Runtime $runtime
                    }
                }
                else
                {
                    if ($runtimeVersion)
                    {
                        New-AzFunctionApp -Name $appName `
                                          -ResourceGroupName $resourceGroupName `
                                          -PlanName $planName `
                                          -StorageAccountName $storageAccountName `
                                          -FunctionsVersion $functionsVersion `
                                          -OSType $OSType `
                                          -Runtime $runtime `
                                          -RuntimeVersion $runtimeVersion
                    }
                    else
                    {
                        New-AzFunctionApp -Name $appName `
                                          -ResourceGroupName $resourceGroupName `
                                          -PlanName $planName `
                                          -StorageAccountName $storageAccountName `
                                          -FunctionsVersion $functionsVersion `
                                          -OSType $OSType `
                                          -Runtime $runtime
                    }
                }

                Write-Verbose "Validating function app properties..." -Verbose
                $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName
                $functionApp.OSType | Should -Be $OSType
                $functionApp.Runtime | Should -Be $runtime

                Write-Verbose "Validating FUNCTIONS_EXTENSION_VERSION and app settings..." -Verbose
                $applicationSettings = Get-AzFunctionAppSetting -Name $appName -ResourceGroupName $resourceGroupName
                $applicationSettings.FUNCTIONS_EXTENSION_VERSION | Should -Be "~$functionsVersion"

                Write-Verbose "Validating that APPLICATIONINSIGHTS_CONNECTION_STRING is set..." -Verbose
                $applicationSettings.APPLICATIONINSIGHTS_CONNECTION_STRING | Should -Not -BeNullOrEmpty

                if ($testCase.ContainsKey("ExpectedSiteConfig"))
                {
                    Write-Verbose "Validating SiteConfig properties..." -Verbose
                    $expectedSiteConfig = $testCase["ExpectedSiteConfig"]
                    foreach ($propertyName in $expectedSiteConfig.Keys)
                    {
                        $expectedValue = $expectedSiteConfig[$propertyName]
                        $functionApp.SiteConfig.$propertyName | Should -Be $expectedValue
                    }
                }

                if ($testCase.ContainsKey("ExpectedAppSettings"))
                {
                    Write-Verbose "Validating custom app settings..." -Verbose
                    $expectedAppSettings = $testCase["ExpectedAppSettings"]
                    foreach ($appSettingName in $expectedAppSettings.Keys)
                    {
                        $expectedAppSettingValue = $expectedAppSettings[$appSettingName]
                        $applicationSettings[$appSettingName] | Should -Be $expectedAppSettingValue
                    }
                }
            }
            finally
            {
                Write-Verbose "Cleaning up the function app..." -Verbose
                $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
                if ($functionApp)
                {
                    Write-Verbose "Removing function app $appName using -InputObject" -Verbose
                    Remove-AzFunctionApp -InputObject $functionApp -Force #-ErrorAction SilentlyContinue
                }
            }
        }
    }

    foreach ($functionsVersion in @(1, 2))
    {
        It "New-AzFunctionApp throws FunctionsVersionNotSupported when trying to create a function app with FunctionsVersion set to $functionsVersion " {

            $myError = $null
            $errorId = "FunctionsVersionNotSupported"
            $expectedErrorMessage = "Functions version not supported. Currently supported version are:"
            try
            {
                Write-Verbose "Create function app with an invalid FunctionsVersion: $functionsVersion" -Verbose
                # Use valid parameters for other properties
                New-AzFunctionApp -Name $env.functionNameTestApp `
                                  -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                                  -PlanName $env.planNameWorkerTypeWindows `
                                  -StorageAccount $env.storageAccountWindows  `
                                  -Runtime PowerShell `
                                  -FunctionsVersion $functionsVersion `
                                  -ErrorAction Stop
            }
            catch
            {
                Write-Verbose "Catch the expected exception" -Verbose
                $myError = $_
            }

            Write-Verbose "Validate FullyQualifiedErrorId" -Verbose
            $myError.FullyQualifiedErrorId | Should Be $errorId
            $myError.Exception.Message | Should Match $expectedErrorMessage
        }
    }
}
