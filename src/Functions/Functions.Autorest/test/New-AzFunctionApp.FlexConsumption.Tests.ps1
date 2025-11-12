$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFunctionApp.FlexConsumption.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

$env:FunctionsTestMode = $true

Describe 'New-AzFunctionApp - Flex Consumption' {

    BeforeAll {

        # Save current enviroment variable
        $oldFunctionsTestMode = $env:FunctionsTestMode

        # Set environment variables for Flex Consumption tests
        $env:FunctionsTestMode = $true
        $env:FunctionsUseFlexStackTestData = $true

        # Set Flex Consumption test variables
        # $flexTestRunId = 111125
        # $flexLocation = 'East Asia'
        # $flexResourceGroupName = "Functions-Flex-RG-" + $flexTestRunId        

        # # Create resource group and storage accounts for Flex Consumption tests
        # Write-Verbose "Creating resource group: $flexResourceGroupName in location: $flexLocation" -Verbose
        # New-AzResourceGroup -Name $flexResourceGroupName -Location $flexLocation | Out-Null

        $flexTestRunId = $env['flexTestRunId']
        $flexLocation = $env['flexLocation']
        $flexResourceGroupName = $env['flexResourceGroupName']
        $flexIdentityInfo = $env['flexIdentityInfo']

        # Helper function to validate core Flex Consumption properties
        function Test-FlexConsumptionProperties {
            param(
                [Parameter(Mandatory=$true)]
                $FunctionApp,
                
                [Parameter(Mandatory=$true)]
                [hashtable]$ExpectedProperties,
                
                [Parameter(Mandatory=$true)]
                [string]$Runtime,
                
                [Parameter(Mandatory=$true)]
                [string]$Location
            )

            # Validate basic properties
            $FunctionApp.Runtime | Should -Be $Runtime
            $FunctionApp.Location | Should -Be $Location
            $FunctionApp.Kind | Should -Match "functionapp"
            $FunctionApp.State | Should -Be "Running"
            $FunctionApp.AppServicePlan | Should -Not -BeNullOrEmpty

            # Validate expected properties
            foreach ($propertyName in $ExpectedProperties.Keys)
            {
                Write-Verbose "Checking property: $propertyName" -Verbose
                $expectedValue = $ExpectedProperties[$propertyName]
                $actualValue = $FunctionApp.$propertyName

                if ($expectedValue -eq $null) {
                    $actualValue | Should -Be $null
                }
                else {
                    $actualValue | Should -Be $expectedValue
                }
            }
        }

        # Helper function to validate app service plan SKU, WorkerType, and SkuTier
        function Test-FlexConsumptionPlan {
            param(
                [Parameter(Mandatory=$true)]
                [string]$PlanName,
                
                [Parameter(Mandatory=$true)]
                [string]$ResourceGroupName
            )

            Write-Verbose "Validating app service plan SkuName, WorkerType, and SkuTier." -Verbose
            $plan = Get-AzFunctionAppPlan -Name $PlanName -ResourceGroupName $ResourceGroupName
            $plan.SkuName | Should -Be "FC1"
            $plan.WorkerType | Should -Be "Linux"
            $plan.SkuTier | Should -Be "FlexConsumption"
        }

        # Helper function to validate app settings
        function Test-FlexConsumptionAppSettings {
            param(
                [Parameter(Mandatory=$true)]
                [string]$AppName,
                
                [Parameter(Mandatory=$true)]
                [string]$ResourceGroupName,
                
                [Parameter(Mandatory=$true)]
                [string[]]$ExpectedSettings
            )

            Write-Verbose "Validating app settings..." -Verbose
            $applicationSettings = Get-AzFunctionAppSetting -Name $AppName -ResourceGroupName $ResourceGroupName

            foreach ($settingName in $ExpectedSettings)
            {
                Write-Verbose "Checking app setting: $settingName" -Verbose
                $applicationSettings[$settingName] | Should -Not -BeNullOrEmpty
            }

            return $applicationSettings
        }

        # Helper function to cleanup function app
        function Remove-TestFunctionApp {
            param(
                [Parameter(Mandatory=$true)]
                [string]$AppName,
                
                [Parameter(Mandatory=$true)]
                [string]$ResourceGroupName
            )

            Write-Verbose "Cleaning up function app: $AppName" -Verbose
            $functionApp = Get-AzFunctionApp -Name $AppName -ResourceGroupName $ResourceGroupName -ErrorAction SilentlyContinue
            if ($functionApp) {
                Remove-AzFunctionApp -Name $AppName -ResourceGroupName $ResourceGroupName -Force -ErrorAction SilentlyContinue
            }
        }
    }

    AfterAll {
        # Restore original environment variable
        $env:FunctionsTestMode = $oldFunctionsTestMode
        $env:FunctionsUseFlexStackTestData = $null
    }

    $expectedAppSettings = @('AzureWebJobsStorage', 'APPLICATIONINSIGHTS_CONNECTION_STRING', 'DEPLOYMENT_STORAGE_CONNECTION_STRING')

    # Test Flex Consumption basic creation for each supported runtime (using default versions)
    $flexConsumptionTestCases = @(
        @{
            "Name" = "Functions-Flex-DotNetIsolated-" + $flexTestRunId
            "Runtime" = "DotNet-Isolated"
            "RuntimeVersion" = $null  # Use default
            "StorageAccountName" = $env['flexStorageAccountDotNetIsolated']
            "ExpectedSku" = "FC1"
            "ExpectedAppSettings" = $expectedAppSettings
            "ExpectedProperties" = @{
                "RuntimeVersion" = "8.0"
                "RuntimeName" = "dotnet-isolated"
                "ScaleAndConcurrencyInstanceMemoryMb" = 2048
                "ScaleAndConcurrencyMaximumInstanceCount" = 100
                "ScaleAndConcurrencyHttpPerInstanceConcurrency" = $null
                "ScaleAndConcurrencyAlwaysReady" = $null
                "StorageType" = "blobcontainer"
                "AuthenticationStorageAccountConnectionStringName" = "DEPLOYMENT_STORAGE_CONNECTION_STRING"
                "AuthenticationType" = "storageaccountconnectionstring"
                "Location" = $flexLocation
                "OSType" = "Linux"
            }
        },
        @{
            "Name" = "Functions-Flex-Node-" + $flexTestRunId
            "Runtime" = "Node"
            "RuntimeVersion" = $null  # Use default
            "StorageAccountName" = $env['flexStorageAccountNode']
            "ExpectedSku" = "FC1"
            "ExpectedAppSettings" = $expectedAppSettings
            "ExpectedProperties" = @{
                "RuntimeVersion" = "22"
                "RuntimeName" = "node"
                "ScaleAndConcurrencyInstanceMemoryMb" = 2048
                "ScaleAndConcurrencyMaximumInstanceCount" = 100
                "ScaleAndConcurrencyHttpPerInstanceConcurrency" = $null
                "ScaleAndConcurrencyAlwaysReady" = $null
                "StorageType" = "blobcontainer"
                "AuthenticationStorageAccountConnectionStringName" = "DEPLOYMENT_STORAGE_CONNECTION_STRING"
                "AuthenticationType" = "storageaccountconnectionstring"
                "Location" = $flexLocation
            }
        },
        @{
            "Name" = "Functions-Flex-Python-" + $flexTestRunId
            "Runtime" = "Python"
            "RuntimeVersion" = $null  # Use default
            "StorageAccountName" = $env['flexStorageAccountPython']
            "ExpectedSku" = "FC1"
            "ExpectedAppSettings" = $expectedAppSettings
            "ExpectedProperties" = @{
                "RuntimeVersion" = "3.12"
                "RuntimeName" = "python"
                "ScaleAndConcurrencyInstanceMemoryMb" = 2048
                "ScaleAndConcurrencyMaximumInstanceCount" = 100
                "ScaleAndConcurrencyHttpPerInstanceConcurrency" = $null
                "ScaleAndConcurrencyAlwaysReady" = $null
                "StorageType" = "blobcontainer"
                "AuthenticationStorageAccountConnectionStringName" = "DEPLOYMENT_STORAGE_CONNECTION_STRING"
                "AuthenticationType" = "storageaccountconnectionstring"
                "Location" = $flexLocation
            }
        },
        @{
            "Name" = "Functions-Flex-Java-" + $flexTestRunId
            "Runtime" = "Java"
            "RuntimeVersion" = $null  # Use default
            "StorageAccountName" = $env['flexStorageAccountJava']
            "ExpectedSku" = "FC1"
            "ExpectedAppSettings" = $expectedAppSettings
            "ExpectedProperties" = @{
                "RuntimeVersion" = "17"
                "RuntimeName" = "java"
                "ScaleAndConcurrencyInstanceMemoryMb" = 2048
                "ScaleAndConcurrencyMaximumInstanceCount" = 100
                "ScaleAndConcurrencyHttpPerInstanceConcurrency" = $null
                "ScaleAndConcurrencyAlwaysReady" = $null
                "StorageType" = "blobcontainer"
                "AuthenticationStorageAccountConnectionStringName" = "DEPLOYMENT_STORAGE_CONNECTION_STRING"
                "AuthenticationType" = "storageaccountconnectionstring"
                "Location" = $flexLocation
            }
        },
        @{
            "Name" = "Functions-Flex-PowerShell-" + $flexTestRunId
            "Runtime" = "PowerShell"
            "RuntimeVersion" = $null  # Use default
            "StorageAccountName" = $env['flexStorageAccountPowerShell']
            "ExpectedSku" = "FC1"
            "ExpectedAppSettings" = $expectedAppSettings
            "ExpectedProperties" = @{
                "RuntimeVersion" = "7.4"
                "RuntimeName" = "powershell"
                "ScaleAndConcurrencyInstanceMemoryMb" = 2048
                "ScaleAndConcurrencyMaximumInstanceCount" = 100
                "ScaleAndConcurrencyHttpPerInstanceConcurrency" = $null
                "ScaleAndConcurrencyAlwaysReady" = $null
                "StorageType" = "blobcontainer"
                "AuthenticationStorageAccountConnectionStringName" = "DEPLOYMENT_STORAGE_CONNECTION_STRING"
                "AuthenticationType" = "storageaccountconnectionstring"
                "Location" = $flexLocation
            }
        },
        @{
            "Name" = "Functions-Flex-Custom-" + $flexTestRunId
            "Runtime" = "Custom"
            "RuntimeVersion" = $null  # Use default
            "StorageAccountName" = $env['flexStorageAccountCustom']
            "ExpectedSku" = "FC1"
            "ExpectedAppSettings" = $expectedAppSettings
            "ExpectedProperties" = @{
                "RuntimeVersion" = "1.0"
                "RuntimeName" = "custom"
                "ScaleAndConcurrencyInstanceMemoryMb" = 2048
                "ScaleAndConcurrencyMaximumInstanceCount" = 100
                "ScaleAndConcurrencyHttpPerInstanceConcurrency" = $null
                "ScaleAndConcurrencyAlwaysReady" = $null
                "StorageType" = "blobcontainer"
                "AuthenticationStorageAccountConnectionStringName" = "DEPLOYMENT_STORAGE_CONNECTION_STRING"
                "AuthenticationType" = "storageaccountconnectionstring"
                "Location" = $flexLocation
            }
        }
    )

    foreach ($testCase in $flexConsumptionTestCases) {

        $appName = $testCase["Name"]
        $runtime = $testCase["Runtime"]
        $runtimeVersion = $testCase["RuntimeVersion"]
        $storageAccountName = $testCase["StorageAccountName"]
        $expectedSku = $testCase["ExpectedSku"]
        $expectedAppSettings = $testCase["ExpectedAppSettings"]
        $expectedProperties = $testCase["ExpectedProperties"]

        It "Create $runtime Function App with default runtime version and scaling settings hosted in Flex Consumption" {
            try {
                Write-Verbose "Creating Flex Consumption function app: $appName" -Verbose
                Write-Verbose "Runtime: $runtime" -Verbose
                Write-Verbose "Location: $flexLocation" -Verbose
                Write-Verbose "Storage account name: $storageAccountName" -Verbose

                $createParams = @{
                    Name = $appName
                    ResourceGroupName = $flexResourceGroupName
                    StorageAccountName = $storageAccountName
                    Runtime = $runtime
                    FlexConsumptionLocation = $flexLocation
                }

                # Add RuntimeVersion if specified
                if ($runtimeVersion) {
                    $createParams['RuntimeVersion'] = $runtimeVersion
                }

                New-AzFunctionApp @createParams

                Write-Verbose "Validating function app properties..." -Verbose
                $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $flexResourceGroupName
                
                # Use helper function to validate properties
                Test-FlexConsumptionProperties -FunctionApp $functionApp `
                                               -ExpectedProperties $expectedProperties `
                                               -Runtime $runtime `
                                               -Location $flexLocation
                
                # Validate app service plan SKU
                Test-FlexConsumptionPlan -PlanName $functionApp.AppServicePlan `
                                         -ResourceGroupName $flexResourceGroupName

                # Validate app settings
                Test-FlexConsumptionAppSettings -AppName $appName `
                                                -ResourceGroupName $flexResourceGroupName `
                                                -ExpectedSettings $expectedAppSettings
            }
            finally {
                Remove-TestFunctionApp -AppName $appName -ResourceGroupName $flexResourceGroupName
            }
        }
    }

    It "Create Python Flex Consumption app with custom scaling settings and Always Ready configuration" {

        # Use the Python test case as base
        $baseTestCase = $flexConsumptionTestCases | Where-Object { $_.Runtime -eq "Python" }
        
        $appName = "Functions-Python-Flex-Scaling-" + $flexTestRunId
        $storageAccountName = $baseTestCase.StorageAccountName
        $runtime = $baseTestCase.Runtime
        $runtimeVersion = "3.11"

        $maxInstances = 100
        $instanceMemory = 4096
        $httpConcurrency = 16
        $alwaysReady = @(
            @{
                "name"  = "http"
                "instanceCount" = 2
            }
        )

        Write-Verbose "Creating Flex Consumption app with custom scaling settings" -Verbose
        Write-Verbose "Function app name: $appName" -Verbose
        Write-Verbose "Runtime: $runtime" -Verbose

        try {
            New-AzFunctionApp -Name $appName `
                              -ResourceGroupName $flexResourceGroupName `
                              -StorageAccountName $storageAccountName `
                              -Runtime $runtime `
                              -RuntimeVersion $runtimeVersion `
                              -FlexConsumptionLocation $flexLocation `
                              -AlwaysReady $alwaysReady `
                              -MaximumInstanceCount $maxInstances `
                              -InstanceMemoryMB $instanceMemory `
                              -HttpPerInstanceConcurrency $httpConcurrency

            Write-Verbose "Validating scaling configuration..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $flexResourceGroupName
            
            # Validate core properties using base test case
            $functionApp.Runtime | Should -Be $runtime
            $functionApp.RuntimeVersion | Should -Be $runtimeVersion
            $functionApp.RuntimeName | Should -Be $baseTestCase.ExpectedProperties.RuntimeName
            $functionApp.ScaleAndConcurrencyInstanceMemoryMb | Should -Be 4096
            $functionApp.ScaleAndConcurrencyMaximumInstanceCount | Should -Be 100
            $functionApp.ScaleAndConcurrencyHttpPerInstanceConcurrency | Should -Be $null
            $functionApp.ScaleAndConcurrencyAlwaysReady[0].InstanceCount | Should -Be 2
            $functionApp.ScaleAndConcurrencyAlwaysReady[0].Name | Should -Be "http"
            $functionApp.StorageType | Should -Be "blobcontainer"
            $functionApp.AuthenticationStorageAccountConnectionStringName | Should -Be "DEPLOYMENT_STORAGE_CONNECTION_STRING"
            $functionApp.AuthenticationType | Should -Be "storageaccountconnectionstring"
            $functionApp.Location | Should -Be $flexLocation
            $functionApp.OSType | Should -Be "Linux"
            $functionApp.State | Should -Be "Running"

            # Validate app service plan and settings
            Test-FlexConsumptionPlan -PlanName $functionApp.AppServicePlan `
                                     -ResourceGroupName $flexResourceGroupName

            Test-FlexConsumptionAppSettings -AppName $appName `
                                            -ResourceGroupName $flexResourceGroupName `
                                            -ExpectedSettings $expectedAppSettings
        }
        finally {
            Remove-TestFunctionApp -AppName $appName -ResourceGroupName $flexResourceGroupName
        }
    }

    It "Create Node ZoneRedundant Flex Consumption app with SystemAssigned managed identity for deployment storage" {
        
        # Use the Node test case as base
        $baseTestCase = $flexConsumptionTestCases | Where-Object { $_.Runtime -eq "Node" }
        
        $appName = "Functions-Node-SystemIdentity-" + $flexTestRunId
        $storageAccountName = $baseTestCase.StorageAccountName
        $runtime = $baseTestCase.Runtime
        $expectedSku = "FC1"  # ZoneRedundant SKU

        Write-Verbose "Creating ZoneRedundant Flex Consumption app with SystemAssigned identity for deployment storage" -Verbose

        try {

            Write-Verbose "Creating ZoneRedundant Flex Consumption app with UserAssigned identity for deployment storage" -Verbose
            Write-Verbose "Function app name: $appName" -Verbose
            Write-Verbose "Resource group name: $flexResourceGroupName" -Verbose
            Write-Verbose "Storage account name: $storageAccountName" -Verbose
            Write-Verbose "Runtime: $runtime" -Verbose

            New-AzFunctionApp -Name $appName `
                              -ResourceGroupName $flexResourceGroupName `
                              -StorageAccountName $storageAccountName `
                              -Runtime $runtime `
                              -FlexConsumptionLocation $flexLocation `
                              -DeploymentStorageAuthType "SystemAssignedIdentity" `
                              -IdentityType "SystemAssigned" `
                              -EnableZoneRedundancy

            Write-Verbose "Validating SystemAssigned identity configuration..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $flexResourceGroupName
            
            # Validate basic properties using base test case expectations
            $functionApp.Runtime | Should -Be $runtime
            $functionApp.RuntimeVersion | Should -Be $baseTestCase.ExpectedProperties.RuntimeVersion
            $functionApp.RuntimeName | Should -Be $baseTestCase.ExpectedProperties.RuntimeName
            $functionApp.ScaleAndConcurrencyInstanceMemoryMb | Should -Be $baseTestCase.ExpectedProperties.ScaleAndConcurrencyInstanceMemoryMb
            $functionApp.ScaleAndConcurrencyMaximumInstanceCount | Should -Be $baseTestCase.ExpectedProperties.ScaleAndConcurrencyMaximumInstanceCount
            $functionApp.ScaleAndConcurrencyHttpPerInstanceConcurrency | Should -Be $null
            $functionApp.ScaleAndConcurrencyAlwaysReady | Should -Be $null
            $functionApp.StorageType | Should -Be "blobcontainer"
            $functionApp.Location | Should -Be $flexLocation
            $functionApp.OSType | Should -Be "Linux"
            $functionApp.State | Should -Be "Running"
            
            # Validate deployment storage authentication type
            $functionApp.AuthenticationType | Should -Be "systemassignedidentity"
            
            # Validate managed identity
            $functionApp.IdentityType | Should -Be "SystemAssigned"
            $functionApp.IdentityPrincipalId | Should -Not -BeNullOrEmpty

            # Validate app service plan
            Write-Verbose "Validating app service plan SKU and zone redundancy..." -Verbose
            $plan = Get-AzFunctionAppPlan -Name $functionApp.AppServicePlan -ResourceGroupName $flexResourceGroupName
            $plan.SkuName | Should -Be $expectedSku
            $plan.ZoneRedundant | Should -Be $true
            # This is the default value when the Flex Consumption plan is created
            $plan.MaximumElasticWorkerCount | Should -Be 3

            # Validate app settings (should NOT have DEPLOYMENT_STORAGE_CONNECTION_STRING for SystemAssigned)
            Write-Verbose "Validating app settings..." -Verbose
            $applicationSettings = Get-AzFunctionAppSetting -Name $appName -ResourceGroupName $flexResourceGroupName
            $applicationSettings['AzureWebJobsStorage'] | Should -Not -BeNullOrEmpty
            $applicationSettings['APPLICATIONINSIGHTS_CONNECTION_STRING'] | Should -Not -BeNullOrEmpty
            $applicationSettings.ContainsKey('DEPLOYMENT_STORAGE_CONNECTION_STRING') | Should -Be $false
        }
        finally {
            Remove-TestFunctionApp -AppName $appName -ResourceGroupName $flexResourceGroupName
        }
    }

    It "Create PowerShell Flex Consumption app with UserAssigned managed identity for deployment storage" {

        # Use the PowerShell test case as base
        $baseTestCase = $flexConsumptionTestCases | Where-Object { $_.Runtime -eq "PowerShell" }

        $appName = "Functions-Pwsh-UserAssignedIdentity-" + $flexTestRunId
        $storageAccountName = $baseTestCase.StorageAccountName
        $runtime = $baseTestCase.Runtime
        $flexIdentityInfo = $env['flexIdentityInfo']

        try {
            Write-Verbose "Creating Flex Consumption app with UserAssigned identity for deployment storage" -Verbose
            Write-Verbose "Function app name: $appName" -Verbose
            Write-Verbose "Resource group name: $flexResourceGroupName" -Verbose
            Write-Verbose "Identity resource ID: $($flexIdentityInfo.Id)" -Verbose
            Write-Verbose "Storage account name: $storageAccountName" -Verbose
            Write-Verbose "Runtime: $runtime" -Verbose

            New-AzFunctionApp -Name $appName `
                              -ResourceGroupName $flexResourceGroupName `
                              -StorageAccountName $storageAccountName `
                              -Runtime $runtime `
                              -FlexConsumptionLocation $flexLocation `
                              -DeploymentStorageAuthType "UserAssignedIdentity" `
                              -DeploymentStorageAuthValue $flexIdentityInfo.Id `
                              -IdentityType "UserAssigned" `
                              -IdentityID $flexIdentityInfo.Id

            # Validate basic properties using base test case expectations
            Write-Verbose "Validating Flex function app basic properties..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $flexResourceGroupName

            $functionApp.Runtime | Should -Be $runtime
            $functionApp.RuntimeVersion | Should -Be $baseTestCase.ExpectedProperties.RuntimeVersion
            $functionApp.RuntimeName | Should -Be $baseTestCase.ExpectedProperties.RuntimeName
            $functionApp.ScaleAndConcurrencyInstanceMemoryMb | Should -Be $baseTestCase.ExpectedProperties.ScaleAndConcurrencyInstanceMemoryMb
            $functionApp.ScaleAndConcurrencyMaximumInstanceCount | Should -Be $baseTestCase.ExpectedProperties.ScaleAndConcurrencyMaximumInstanceCount
            $functionApp.ScaleAndConcurrencyHttpPerInstanceConcurrency | Should -Be $null
            $functionApp.ScaleAndConcurrencyAlwaysReady | Should -Be $null
            $functionApp.StorageType | Should -Be "blobcontainer"
            $functionApp.Location | Should -Be $flexLocation
            $functionApp.OSType | Should -Be "Linux"
            $functionApp.State | Should -Be "Running"
            
            # Validate deployment storage and authentication type
            Write-Verbose "Validating deployment storage authentication for user assigned identity..." -Verbose
            $functionApp.AuthenticationType | Should -Be "userassignedidentity"
            $functionApp.AuthenticationUserAssignedIdentityResourceId | Should -Match $flexIdentityInfo.Id

            # Validate app user assigned identity
            $functionApp.IdentityType | Should -Be "UserAssigned"
            $userAssignedIdentity = $functionApp.IdentityUserAssignedIdentity.AdditionalProperties
            $userAssignedIdentity.ContainsKey($flexIdentityInfo.Id) | Should -Be $true

            # Validate app service plan
            Test-FlexConsumptionPlan -PlanName $functionApp.AppServicePlan `
                                     -ResourceGroupName $flexResourceGroupName

            # Validate app settings (should NOT have DEPLOYMENT_STORAGE_CONNECTION_STRING for SystemAssigned)
            $applicationSettings = Get-AzFunctionAppSetting -Name $appName -ResourceGroupName $flexResourceGroupName
            $applicationSettings['AzureWebJobsStorage'] | Should -Not -BeNullOrEmpty
            $applicationSettings['APPLICATIONINSIGHTS_CONNECTION_STRING'] | Should -Not -BeNullOrEmpty
            $applicationSettings.ContainsKey('DEPLOYMENT_STORAGE_CONNECTION_STRING') | Should -Be $false
        }
        finally {
            Remove-TestFunctionApp -AppName $appName -ResourceGroupName $flexResourceGroupName
        }
    }

    It "Create PowerShell Flex Consumption app with custom tags and app settings" {
        
        # Use the PowerShell test case as base
        $baseTestCase = $flexConsumptionTestCases | Where-Object { $_.Runtime -eq "PowerShell" }
        
        $appName = "Functions-PS-CustomConfig-" + $flexTestRunId
        $storageAccountName = $baseTestCase.StorageAccountName
        $runtime = $baseTestCase.Runtime
        
        $customTags = @{
            "Environment" = "Test"
            "Project" = "FlexConsumption"
            "Owner" = "PowerShell"
        }
        $customAppSettings = @{
            "CustomSetting1" = "Value1"
            "CustomSetting2" = "Value2"
        }

        Write-Verbose "Creating Flex Consumption app with custom configuration" -Verbose

        try {
            New-AzFunctionApp -Name $appName `
                              -ResourceGroupName $flexResourceGroupName `
                              -StorageAccountName $storageAccountName `
                              -Runtime $runtime `
                              -FlexConsumptionLocation $flexLocation `
                              -Tag $customTags `
                              -AppSetting $customAppSettings

            Write-Verbose "Validating custom tags and settings..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $flexResourceGroupName
            
            # Validate basic properties using helper and base test case
            Test-FlexConsumptionProperties -FunctionApp $functionApp `
                                           -ExpectedProperties $baseTestCase.ExpectedProperties `
                                           -Runtime $runtime `
                                           -Location $flexLocation

            # Validate custom tags
            foreach ($tagName in $customTags.Keys) {
                $functionApp.Tag.AdditionalProperties[$tagName] | Should -Be $customTags[$tagName]
            }

            # Validate app settings
            $applicationSettings = Test-FlexConsumptionAppSettings -AppName $appName `
                                                                   -ResourceGroupName $flexResourceGroupName `
                                                                   -ExpectedSettings $expectedAppSettings

            # Validate custom app settings
            foreach ($settingName in $customAppSettings.Keys) {
                $applicationSettings[$settingName] | Should -Be $customAppSettings[$settingName]
            }

            # Validate app service plan
            Test-FlexConsumptionPlan -PlanName $functionApp.AppServicePlan `
                                     -ResourceGroupName $flexResourceGroupName
        }
        finally {
            Remove-TestFunctionApp -AppName $appName -ResourceGroupName $flexResourceGroupName
        }
    }

    It "Create Java Flex Consumption app with disabled Application Insights" {
        
        # Use the Java test case as base
        $baseTestCase = $flexConsumptionTestCases | Where-Object { $_.Runtime -eq "Java" }
        
        $appName = "Functions-Java-NoAppInsights-" + $flexTestRunId
        $storageAccountName = $baseTestCase.StorageAccountName
        $runtime = $baseTestCase.Runtime

        Write-Verbose "Creating Flex Consumption app with disabled Application Insights" -Verbose

        try {
            New-AzFunctionApp -Name $appName `
                              -ResourceGroupName $flexResourceGroupName `
                              -StorageAccountName $storageAccountName `
                              -Runtime $runtime `
                              -FlexConsumptionLocation $flexLocation `
                              -DisableApplicationInsights

            Write-Verbose "Validating Application Insights is disabled..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $flexResourceGroupName
            
            # Validate basic properties using helper and base test case
            Test-FlexConsumptionProperties -FunctionApp $functionApp `
                                           -ExpectedProperties $baseTestCase.ExpectedProperties `
                                           -Runtime $runtime `
                                           -Location $flexLocation

            # Validate Application Insights connection string is not set
            $applicationSettings = Get-AzFunctionAppSetting -Name $appName -ResourceGroupName $flexResourceGroupName
            $applicationSettings.ContainsKey("APPLICATIONINSIGHTS_CONNECTION_STRING") | Should -Be $false
            
            # Validate other app settings are present (excluding APPLICATIONINSIGHTS_CONNECTION_STRING)
            $applicationSettings['AzureWebJobsStorage'] | Should -Not -BeNullOrEmpty
            $applicationSettings['DEPLOYMENT_STORAGE_CONNECTION_STRING'] | Should -Not -BeNullOrEmpty

            # Validate app service plan
            Test-FlexConsumptionPlan -PlanName $functionApp.AppServicePlan `
                                     -ResourceGroupName $flexResourceGroupName
        }
        finally {
            Remove-TestFunctionApp -AppName $appName -ResourceGroupName $flexResourceGroupName
        }
    }

    # Test WhatIf scenarios for Flex Consumption
    It "Validate New-AzFunctionApp -WhatIf works for DotNet-Isolated Flex Consumption" {
        
        # Use the DotNet-Isolated test case as base
        $baseTestCase = $flexConsumptionTestCases | Where-Object { $_.Runtime -eq "DotNet-Isolated" }
        
        $appName = "Functions-DotNet-WhatIf-" + $flexTestRunId
        $storageAccountName = $baseTestCase.StorageAccountName
        $runtime = $baseTestCase.Runtime

        Write-Verbose "Testing WhatIf for Flex Consumption" -Verbose
        
        # This should not throw and should not create actual resources
        {
            New-AzFunctionApp -Name $appName `
                              -ResourceGroupName $flexResourceGroupName `
                              -StorageAccountName $storageAccountName `
                              -Runtime $runtime `
                              -FlexConsumptionLocation $flexLocation `
                              -WhatIf
        } | Should -Not -Throw

        # Verify no function app was actually created
        $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $flexResourceGroupName -ErrorAction SilentlyContinue
        $functionApp | Should -BeNull
    }
}
