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

    # Validate RuntimeVersion default values
    $expectedDefaultRuntimeVersion = @{
        "Linux" = @{
            "2"= @{
                "Node" = "10"
                "DotNet"= "2"
                "Python" = "3.7"
            }
            "3" =  @{
                "Node" = "12"
                "DotNet" = "3"
                "Python" = "3.8"
                "Java" = "8"
            }
        }
        "Windows" = @{
            "2"= @{
                "Node" = "10"
                "DotNet"= "2"
                "Java" = "8"
            }
            "3" =  @{
                "Node" = "12"
                "DotNet" = "3"
                "PowerShell" = "7.0"
                "Java" = "8"
            }
        }
    }

    $LinuxRuntimes = @("DotNet", "Node", "Java", "Python")
    $WindowsRuntimes = @("DotNet", "Node", "Java", "PowerShell")

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

    $filePath = Join-Path $PSScriptRoot "verboseOutput.log"

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

                if (($functionsVersion -eq "2") -and ($OSType -eq "Windows") -and ($runtime -eq "PowerShell"))
                {
                    # PowerShel 7.0 is not supported in Windows for Functions V2.
                    continue
                }

                It "Validate New-AzFunctionApp default runtime version for $runtime in Functions version $functionsVersion for $OSType" {

                    # Note: These set of tests are for consumptions function apps. We do this for two things:
                    # 1) Test case is faster, we do not need to validate the service plan name
                    # 2) Validate the -Location code path
                    # We use -WhatIf which performs all the inputs validation for the function app creation, and we return right before sending the request to the backend

                    try
                    {
                        $functionName = $env.functionNameTestApp
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

                        if ($runtime -eq "DotNet")
                        {
                            $expectedMessage = "'DotNet' runtime version is specified by FunctionsVersion. The value of the -RuntimeVersion will be set to '$expectectedRuntimeVersion'."
                        }
                        else
                        {
                            $expectedMessage = "RuntimeVersion not specified. Setting default runtime version for '$runtime' to '$expectectedRuntimeVersion'."
                        }

                        $logFileContent | Should Match $expectedMessage
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

    It "New-AzFunctionApp Should throw MissingFunctionsVersionValue for DotNet function apps if the FunctionsVersion parameter is not specified." {

        $myError = $null
        $expectedErrorMessage = "For 'DotNet' function apps, the runtime version is specified by the FunctionsVersion parameter. Please specify this value and try again."
        $expectedErrorId = "MissingFunctionsVersionValue"
        try
        {
            New-AzFunctionApp -Name $env.functionNameTestApp `
                              -ResourceGroupName $env.storageAccountWindows `
                              -Location  $env.location `
                              -StorageAccountName $env.storageAccountWindows `
                              -Runtime DotNet `
                              -ErrorAction Stop `
                              -WhatIf
        }
        catch
        {
            $myError = $_
        }

        $myError.FullyQualifiedErrorId | Should Be $expectedErrorId
        $myError.Exception.Message | Should Match $expectedErrorMessage
    }

    $testCases = @(
        @{
            "Runtime" = "PowerShell"
            "RuntimeVersion" = "7.0"
            "StorageAccountName" = $env.storageAccountWindows
            "ResourceGroupName" = $env.resourceGroupNameWindowsPremium
            "Location" = $env.location
            "ExpectedOSType" = "Windows"
        },
        @{
            "Runtime" = "Java"
            "RuntimeVersion" = "8"
            "StorageAccountName" = $env.storageAccountWindows
            "ResourceGroupName" = $env.resourceGroupNameWindowsPremium
            "Location" = $env.location
            "ExpectedOSType" = "Windows"
        },
        @{
            "Runtime" = "Node"
            "RuntimeVersion" = "12"
            "StorageAccountName" = $env.storageAccountWindows
            "ResourceGroupName" = $env.resourceGroupNameWindowsPremium
            "Location" = $env.location
            "ExpectedOSType" = "Windows"
        },
        @{
            "Runtime" = "Python"
            "RuntimeVersion" = "3.8"
            "StorageAccountName" = $env.storageAccountLinux
            "ResourceGroupName" = $env.resourceGroupNameLinuxPremium
            "Location" = $env.location
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
                $functionName =  $env.functionNameTestApp

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

    # Test cases for runtime version not supported.
    # For these scenarios, the runtime is supported for the os type, but the runtime version is invalid.
    $runtimeVersionNotSupported = @{
        "Linux" = @{
            "2"= @{
                "Python" = "3.9"
                "Java" = "8"
            }
            "3" =  @{
                "Node" = "8"
            }
        }
        "Windows" = @{
            "2"= @{
                "Node" = "12"
                "PowerShell" = "7.0"
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
                $functionName = $env.functionNameTestApp
                $runtimeVersion = $runtimeVersionNotSupported[$OSType][$functionsVersion][$runtime]

                #$expectedErrorMessage = "$runtime version $runtimeVersion in Functions version $functionsVersion for $OSType is not supported."
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
        $expectedErrorMessage = "Runtime 'Go' is not supported. Currently supported runtimes: 'DotNet', 'Java', 'Node', 'PowerShell', 'Python'."
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
                              -Runtime Python

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

    It "New-AzFunctionApp -Location supports locations with no spaces, e.g., 'centralus'" {

        $functionName = $env.functionNamePowerShell
        $location = 'centralus'
        $tags = @{
            "MyTag1" = "MyTag1Value1"
            "MyTag2" = "MyTag1Value2"
        }

        try
        {
            New-AzFunctionApp -Name $functionName `
                              -ResourceGroupName $env.resourceGroupNameWindowsConsumption `
                              -Location $location `
                              -StorageAccount $env.storageAccountWindows `
                              -OSType "Windows" `
                              -Runtime "PowerShell" `
                              -FunctionsVersion 3 `
                              -Tag $tags


            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsConsumption
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
                              -IdentityType UserAssigned `
                              -IdentityID $identityInfo.Id

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium
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
                              -FunctionsVersion 3 `
                              -OSType Linux

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameLinuxConsumption
            $functionApp.OSType | Should -Be "Linux"
            $functionApp.Runtime | Should -Be "DotNet"
            $functionApp.SiteConfig.LinuxFxVersion | Should -Be "dotnet|3.1"
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
                              -FunctionsVersion 3 `
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

    $functionAppCreationTestCases = @(
        @{
            "Name" = $env.functionNameJava
            "Runtime" = "Java"
            "RuntimeVersion" = "11"
            "StorageAccountName" = $env.storageAccountLinux
            "ResourceGroupName" = $env.resourceGroupNameLinuxConsumption
            "Location" = $env.location
            "FunctionsVersion" = 3
            "OSType" = "Linux"
            "ExpectedVersion" = @{
                "LinuxFxVersion" = "Java|11"
            }
        },
        @{
            "Name" = $env.functionNamePowerShell
            "Runtime" = "PowerShell"
            "RuntimeVersion" = "7.0"
            "StorageAccountName" = $env.storageAccountWindows
            "ResourceGroupName" = $env.resourceGroupNameWindowsConsumption
            "Location" = $env.location
            "FunctionsVersion" = 3
            "OSType" = "Windows"
            "ExpectedVersion" = @{
                "PowerShellVersion" = "~7"
            }
        },
        @{
            "Name" = $env.functionNameJava
            "Runtime" = "Java"
            "RuntimeVersion" = "11"
            "StorageAccountName" = $env.storageAccountWindows
            "ResourceGroupName" = $env.resourceGroupNameWindowsPremium
            "PlanName" = $env.planNameWorkerTypeWindows
            "FunctionsVersion" = 3
            "OSType" = "Windows"
            "ExpectedVersion" = @{
                "JavaVersion" = "11"
            }
        },
        @{
            "Name" = $env.functionNamePowerShell
            "Runtime" = "PowerShell"
            "RuntimeVersion" = "7.0"
            "StorageAccountName" = $env.storageAccountWindows
            "ResourceGroupName" = $env.resourceGroupNameWindowsPremium
            "PlanName" = $env.planNameWorkerTypeWindows
            "FunctionsVersion" = 3
            "OSType" = "Windows"
            "ExpectedVersion" = @{
                "PowerShellVersion" = "~7"
            }
        }
    )

    foreach ($testCase in $functionAppCreationTestCases)
    {
        $functionName =  $testCase["Name"]
        $functionsVersion = $testCase["FunctionsVersion"]
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

        It "Create $OSType $runtime $runtimeVersion function app hosted in a $planType plan" {

            try
            {
                if ($planType -eq "Consumption")
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
                                      -PlanName $planName `
                                      -StorageAccountName $storageAccountName `
                                      -FunctionsVersion $functionsVersion `
                                      -OSType $OSType `
                                      -Runtime $runtime `
                                      -RuntimeVersion $runtimeVersion
                }

                $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $resourceGroupName
                $functionApp.OSType | Should -Be $OSType
                $functionApp.Runtime | Should -Be $runtime

                if ($testCase.ContainsKey("ExpectedVersion"))
                {
                    $expectedVersion = $testCase["ExpectedVersion"]
                    foreach ($propertyName in $expectedVersion.Keys)
                    {
                        $expectedVersion = $expectedVersion[$propertyName]
                        $functionApp.SiteConfig.$propertyName | Should -Be $expectedVersion
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
}
