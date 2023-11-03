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

Describe 'New-AzFunctionApp' {

    It 'CustomDockerImage' {

        $functionName = $env.functionNameContainer

        try
        {
            New-AzFunctionApp -Name $functionName `
                              -ResourceGroupName $env.resourceGroupNameLinuxPremium `
                              -PlanName $env.planNameWorkerTypeLinux `
                              -StorageAccount $env.storageAccountLinux `
                              -DockerImageName "divyag2411/test:customcontainer"

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameLinuxPremium
            $functionApp.OSType | Should -Be "Linux"
            $functionApp.Runtime | Should -Be "Custom Image"

            # For a custom container image, the app setting `FUNCTIONS_EXTENSION_VERSION` should not be set.
            # TODO: Uncomment this line once https://msazure.visualstudio.com/Antares/_workitems/edit/6386493 has been fixed.
            # $functionApp.ApplicationSettings.ContainsKey("FUNCTIONS_EXTENSION_VERSION") | Should -Be $false
        }
        finally
        {
            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameLinuxPremium -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Remove-AzFunctionApp -InputObject $functionApp -Force -ErrorAction SilentlyContinue
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
            "RuntimeVersion" = "6"
            "StorageAccountName" = $env.storageAccountWindows
            "ResourceGroupName" = $env.resourceGroupNameWindowsPremium
            "Location" = $env.location
            "ExpectedOSType" = "Windows"
        },
        @{
            "Runtime" = "PowerShell"
            "RuntimeVersion" = "7.2"
            "StorageAccountName" = $env.storageAccountWindows
            "ResourceGroupName" = $env.resourceGroupNameWindowsPremium
            "Location" = $env.location
            "ExpectedOSType" = "Windows"
        },
        @{
            "Runtime" = "Java"
            "RuntimeVersion" = "17"
            "StorageAccountName" = $env.storageAccountWindows
            "ResourceGroupName" = $env.resourceGroupNameWindowsPremium
            "Location" = $env.location
            "ExpectedOSType" = "Windows"
        },
        @{
            "Runtime" = "Node"
            "RuntimeVersion" = "18"
            "StorageAccountName" = $env.storageAccountWindows
            "ResourceGroupName" = $env.resourceGroupNameWindowsPremium
            "Location" = $env.location
            "ExpectedOSType" = "Windows"
        },
        @{
            "Runtime" = "Python"
            "RuntimeVersion" = "3.10"
            "StorageAccountName" = $env.storageAccountLinux
            "ResourceGroupName" = $env.resourceGroupNameLinuxPremium
            "Location" = $env.location
            "ExpectedOSType" = "Linux"
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
                $functionName =  $env.functionNameTestApp

                &{
                    # We use -WhatIf which performs all the inputs validation for the function app creation, and we return right before sending the request to the backend
                    if ($runtimeVersion)
                    {
                        New-AzFunctionApp -Name $functionName `
                                          -ResourceGroupName $resourceGroupName `
                                          -Location $location `
                                          -StorageAccountName $storageAccountName `
                                          -Runtime $runtime `
                                          -RuntimeVersion $runtimeVersion `
                                          -WhatIf
                    }
                    else
                    {
                        New-AzFunctionApp -Name $functionName `
                                          -ResourceGroupName $resourceGroupName `
                                          -Location $location `
                                          -StorageAccountName $storageAccountName `
                                          -Runtime $runtime `
                                          -WhatIf
                    }

                } 3>&1 2>&1 > $filePath

                $logFileContent = Get-Content -Path $filePath -Raw

                $expectectedFunctionsVersionWarning = "FunctionsVersion not specified. Setting default value to '$expectedFunctionsVersion'."
                $expectectedOSTypeWarning = "OSType not specified. Setting default value to '$expectedOSType'."

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

    # Test cases for runtime version not supported.
    # For these scenarios, the runtime is supported for the os type, but the runtime version is invalid.
    $runtimeVersionNotSupported = @{
        "Linux" = @{
            "4" =  @{
                "Node" = "10"
                "Python" = "3.6"
            }
        }
        "Windows" = @{
            "4" =  @{
                "Node" = "10"
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
                $functionName = $env.functionNameTestApp
                $runtimeVersion = $runtimeVersionNotSupported[$OSType][$functionsVersion][$runtime]

                $expectedErrorMessage = "Runtime '$runtime' version '$runtimeVersion' in Functions version '$functionsVersion' on '$OSType' is not supported."
                $errorId = "RuntimeVersionNotSupported"

                It "New-AzFunctionApp should throw InvalidRuntimeVersion for $runtime $runtimeVersion in $OSType for Functions version $functionsVersion" {

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

    It "New-AzFunctionApp should throw RuntimeNotSupported when trying to create a function app for an invalid runtime" {

        $myError = $null
        $errorId = "RuntimeNotSupported"
        $expectedErrorMessage = "Runtime 'Go' is not supported. Currently supported runtimes: 'Custom', 'DotNet', 'DotNet-Isolated', 'Java', 'Node', 'PowerShell', 'Python'."
        try
        {
            New-AzFunctionApp -Name $env.functionNameTestApp `
                              -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                              -PlanName $env.planNameWorkerTypeWindows `
                              -StorageAccount $env.storageAccountWindows  `
                              -Runtime Go
        }
        catch
        {
            $myError = $_
        }

        $myError.FullyQualifiedErrorId | Should Be $errorId
        $myError.Exception.Message | Should Match $expectedErrorMessage
    }

    It "Linux functions apps should not set the 'WEBSITE_NODE_DEFAULT_VERSION' app setting" {

        $functionName = $env.functionNamePython

        try
        {
            New-AzFunctionApp -Name $functionName `
                              -ResourceGroupName $env.resourceGroupNameLinuxPremium `
                              -PlanName $env.planNameWorkerTypeLinux `
                              -StorageAccount $env.storageAccountLinux `
                              -Runtime Python `
                              -RuntimeVersion "3.10" `
                              -FunctionsVersion 4

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameLinuxPremium
            $functionApp.OSType | Should -Be "Linux"
            $functionApp.Runtime | Should -Be "Python"
            $functionApp.ApplicationSettings.ContainsKey("WEBSITE_NODE_DEFAULT_VERSION") | Should -Be $false
        }
        finally
        {
            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameLinuxPremium -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Remove-AzFunctionApp -InputObject $functionApp -Force -ErrorAction SilentlyContinue
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

        $functionName = $env.functionNamePowerShell
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

        try
        {
            New-AzFunctionApp -Name $functionName `
                              -ResourceGroupName $env.resourceGroupNameWindowsConsumption `
                              -Location $location `
                              -StorageAccount $env.storageAccountWindows `
                              -OSType "Windows" `
                              -Runtime "PowerShell" `
                              -RuntimeVersion "7.2" `
                              -FunctionsVersion 4 `
                              -Tag $tags `
                              -AppSetting $appSetting

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsConsumption
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"
            $functionApp.Location | Should -Be "Central US"

            # Validate tags
            foreach ($tagName in $tags.Keys)
            {
                $functionApp.Tag.AdditionalProperties[$tagName] | Should Be $tags[$tagName]
            }

            # Validate app settings
            foreach ($appSettingName in $appSetting.Keys)
            {
                $expectedValue = $appSetting[$appSettingName]
                if ($expectedValue -eq $null)
                {
                    # null app settings are created as an empty string.
                    $expectedValue = ""
                }

                $functionApp.ApplicationSettings[$appSettingName] | Should Be $expectedValue
            }

            # Validate WEBSITE_CONTENTSHARE
            $functionApp.ApplicationSettings["WEBSITE_CONTENTSHARE"] | Should Match $functionName

            # Validate the connection string suffix
            $expectedSuffix = GetStorageAccountEndpointSuffix
            foreach ($appSettingName in @("AzureWebJobsStorage", "AzureWebJobsDashboard", "WEBSITE_CONTENTAZUREFILECONNECTIONSTRING"))
            {
                $functionApp.ApplicationSettings[$appSettingName] | Should Match $expectedSuffix
            }

        }
        finally
        {
            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsConsumption -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Remove-AzFunctionApp -InputObject $functionApp -Force -ErrorAction SilentlyContinue
            }
        }
    }

    It "Create a function app with 'UserAssigned' managed identity " {

        $functionName = $env.functionNamePowerShell
        $identityInfo = $env.identityInfo

        try
        {
            New-AzFunctionApp -Name $functionName `
                              -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                              -PlanName $env.planNameWorkerTypeWindows `
                              -StorageAccount $env.storageAccountWindows  `
                              -Runtime PowerShell `
                              -RuntimeVersion "7.2" `
                              -FunctionsVersion 4 `
                              -IdentityType UserAssigned `
                              -IdentityID $identityInfo.Id

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"
            $functionApp.IdentityType | Should -Be "UserAssigned"
        }
        finally
        {
            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Remove-AzFunctionApp -InputObject $functionApp -Force -ErrorAction SilentlyContinue
            }
        }
    }

    It "Create a function app with custom app settings and 'SystemAssigned' managed identity " {

        $functionName = $env.functionNamePowerShell
        $appSetting = @{}
        $appSetting.Add("MyAppSetting1", 98765)
        $appSetting.Add("MyAppSetting2", "FooBar")

        try
        {
            New-AzFunctionApp -Name $functionName `
                              -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                              -PlanName $env.planNameWorkerTypeWindows `
                              -StorageAccount $env.storageAccountWindows  `
                              -Runtime PowerShell `
                              -RuntimeVersion "7.2" `
                              -FunctionsVersion 4 `
                              -IdentityType SystemAssigned `
                              -AppSetting $appSetting

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium
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
            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Remove-AzFunctionApp -InputObject $functionApp -Force -ErrorAction SilentlyContinue
            }
        }
    }

    It "Creating a function app with 'UserAssigned' managed identity should throw if IdentityID is not provided " {

        # Make sure user identiy is available
        $expetedErrorId = "IdentityIDIsRequiredForUserAssignedIdentity"

        $functionName = $env.functionNamePowerShell

        $scriptblock = {
            New-AzFunctionApp -Name $functionName `
                              -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                              -PlanName $env.planNameWorkerTypeWindows `
                              -StorageAccount $env.storageAccountWindows  `
                              -Runtime PowerShell `
                              -RuntimeVersion "7.2" `
                              -FunctionsVersion 4 `
                              -IdentityType UserAssigned
        }
        $scriptblock | Should -Throw -ErrorId $expetedErrorId
    }

    It "Validate that creating a DotNet function app in consumption for Linux sets the LinuxFxVersion property" {

        $functionName = $env.functionNameDotNet

        try
        {
            New-AzFunctionApp -Name $functionName `
                              -ResourceGroupName $env.resourceGroupNameLinuxConsumption `
                              -Location $env.location `
                              -StorageAccount $env.storageAccountLinux  `
                              -Runtime DotNet `
                              -RuntimeVersion 6 `
                              -FunctionsVersion 4 `
                              -OSType Linux

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameLinuxConsumption
            $functionApp.OSType | Should -Be "Linux"
            $functionApp.Runtime | Should -Be "DotNet"
            $functionApp.SiteConfig.LinuxFxVersion | Should -Be "dotnet|6.0"
        }
        finally
        {
            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameLinuxConsumption -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Remove-AzFunctionApp -InputObject $functionApp -Force -ErrorAction SilentlyContinue
            }
        }
    }

    It "Validate that creating a function app with -DisableApplicationInsights does not create an Application Insights project." {

        $functionName = $env.functionNamePowerShell

        try
        {
            New-AzFunctionApp -Name $functionName `
                              -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                              -PlanName $env.planNameWorkerTypeWindows `
                              -StorageAccount $env.storageAccountWindows  `
                              -Runtime PowerShell `
                              -RuntimeVersion 7.2 `
                              -FunctionsVersion 4 `
                              -DisableApplicationInsights

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"
            $functionApp.ApplicationSettings.ContainsKey("APPINSIGHTS_INSTRUMENTATIONKEY") | Should -Be $false
        }
        finally
        {
            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Remove-AzFunctionApp -InputObject $functionApp -Force -ErrorAction SilentlyContinue
            }
        }
    }

    # These is the list of function apps to be created
    $functionAppCreationTestCases = @(
        # Consumption apps
        @{
            "Name" = $env.functionNameDotNet
            "Runtime" = "DotNet"
            "RuntimeVersion" = "6"
            "StorageAccountName" = $env.storageAccountLinux
            "ResourceGroupName" = $env.resourceGroupNameLinuxConsumption
            "Location" = $env.location
            "OSType" = "Linux"
            "ExpectedSiteConfig" = @{
                "LinuxFxVersion" = "DOTNET|6.0"
            }
        },
        @{
            "Name" = $env.functionNameJava
            "Runtime" = "Java"
            "RuntimeVersion" = "17"
            "StorageAccountName" = $env.storageAccountLinux
            "ResourceGroupName" = $env.resourceGroupNameLinuxConsumption
            "Location" = $env.location
            "OSType" = "Linux"
            "ExpectedSiteConfig" = @{
                "LinuxFxVersion" = "Java|17"
                "use32BitWorkerProcess" = $false
            }
        },
        @{
            "Name" = $env.functionNameNode
            "Runtime" = "Node"
            "RuntimeVersion" = "18"
            "StorageAccountName" = $env.storageAccountLinux
            "ResourceGroupName" = $env.resourceGroupNameLinuxConsumption
            "Location" = $env.location
            "OSType" = "Linux"
            "ExpectedSiteConfig" = @{
                "LinuxFxVersion" = "Node|18"
                "use32BitWorkerProcess" = $false
            }
        },
        @{
            "Name" = $env.functionNamePython
            "Runtime" = "Python"
            "RuntimeVersion" = "3.10"
            "StorageAccountName" = $env.storageAccountLinux
            "ResourceGroupName" = $env.resourceGroupNameLinuxConsumption
            "Location" = $env.location
            "OSType" = "Linux"
            "ExpectedSiteConfig" = @{
                "LinuxFxVersion" = "Python|3.10"
                "use32BitWorkerProcess" = $false
            }
        },
        @{
            "Name" = $env.functionNamePowerShell
            "Runtime" = "PowerShell"
            "RuntimeVersion" = "7.2"
            "StorageAccountName" = $env.storageAccountLinux
            "ResourceGroupName" = $env.resourceGroupNameLinuxConsumption
            "Location" = $env.location
            "OSType" = "Linux"
            "ExpectedSiteConfig" = @{
                "LinuxFxVersion" = "PowerShell|7.2"
                "use32BitWorkerProcess" = $false
            }
        }
        # Premium function app service plan
        @{
            "Name" = $env.functionNameDotNetIsolated
            "Runtime" = "DotNet-Isolated"
            "RuntimeVersion" = "6"
            "StorageAccountName" = $env.storageAccountWindows
            "ResourceGroupName" = $env.resourceGroupNameWindowsPremium
            "PlanName" = $env.planNameWorkerTypeWindows
            "OSType" = "Windows"
            "ExpectedSiteConfig" = @{
                "NetFrameworkVersion" = "v6.0"
                "use32BitWorkerProcess" = $true
            }
            "ExpectedAppSettings" = @{
                "FUNCTIONS_WORKER_RUNTIME" = "dotnet-isolated"
            }
        }
        @{
            "Name" = $env.functionNamePython
            "Runtime" = "Python"
            "RuntimeVersion" = "3.9"
            "StorageAccountName" = $env.storageAccountLinux
            "ResourceGroupName" = $env.resourceGroupNameLinuxPremium
            "PlanName" = $env.planNameWorkerTypeLinux
            "OSType" = "Linux"
            "ExpectedSiteConfig" = @{
                "LinuxFxVersion" = "Python|3.9"
                "use32BitWorkerProcess" = $false
            }
        },
        @{
            "Name" = $env.functionNameJava
            "Runtime" = "Java"
            "RuntimeVersion" = "17"
            "StorageAccountName" = $env.storageAccountWindows
            "ResourceGroupName" = $env.resourceGroupNameWindowsPremium
            "PlanName" = $env.planNameWorkerTypeWindows
            "OSType" = "Windows"
            "ExpectedSiteConfig" = @{
                "JavaVersion" = "17"
                "use32BitWorkerProcess" = $true
                "netFrameworkVersion" = "v6.0"
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
                "use32BitWorkerProcess" = $true
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
        $functionName =  $testCase["Name"]
        $runtime = $testCase["Runtime"]
        $runtimeVersion = $testCase["RuntimeVersion"]
        $resourceGroupName = $testCase["ResourceGroupName"]
        $storageAccountName = $testCase["StorageAccountName"]
        $OSType = $testCase["OSType"]

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

        It "Create v4 $OSType $runtime $runtimeVersion Function App hosted in a $planType plan." {

            try
            {
                if ($planType -eq "Consumption")
                {
                    if ($runtimeVersion)
                    {
                        New-AzFunctionApp -Name $functionName `
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
                        New-AzFunctionApp -Name $functionName `
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
                        New-AzFunctionApp -Name $functionName `
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
                        New-AzFunctionApp -Name $functionName `
                                          -ResourceGroupName $resourceGroupName `
                                          -PlanName $planName `
                                          -StorageAccountName $storageAccountName `
                                          -FunctionsVersion $functionsVersion `
                                          -OSType $OSType `
                                          -Runtime $runtime
                    }
                }

                $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupName
                $functionApp.OSType | Should -Be $OSType
                $functionApp.Runtime | Should -Be $runtime

                # Validate FUNCTIONS_EXTENSION_VERSION
                $functionApp.ApplicationSettings.FUNCTIONS_EXTENSION_VERSION | Should be "~$functionsVersion"

                if ($testCase.ContainsKey("ExpectedSiteConfig"))
                {
                    $expectedSiteConfig = $testCase["ExpectedSiteConfig"]
                    foreach ($propertyName in $expectedSiteConfig.Keys)
                    {
                        $expectedValue = $expectedSiteConfig[$propertyName]
                        $functionApp.SiteConfig.$propertyName | Should -Be $expectedValue
                    }
                }

                if ($testCase.ContainsKey("ExpectedAppSettings"))
                {
                    $expectedAppSettings = $testCase["ExpectedAppSettings"]
                    foreach ($appSettingName in $expectedAppSettings.Keys)
                    {
                        $expectedAppSettingValue = $expectedAppSettings[$appSettingName]
                        $functionApp.ApplicationSettings[$appSettingName] | Should -Be $expectedAppSettingValue
                    }
                }
            }
            finally
            {
                $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
                if ($functionApp)
                {
                    Remove-AzFunctionApp -InputObject $functionApp -Force -ErrorAction SilentlyContinue
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
                New-AzFunctionApp -Name $env.functionNameTestApp `
                                  -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                                  -PlanName $env.planNameWorkerTypeWindows `
                                  -StorageAccount $env.storageAccountWindows  `
                                  -Runtime PowerShell `
                                  -FunctionsVersion $functionsVersion
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
