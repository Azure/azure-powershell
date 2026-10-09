# Copyright Microsoft Corporation. Licensed under the Apache License, Version 2.0.
#Requires -Version 7.3
# Pester 4.10.1 and installed native setup prerequisites; fake helpers, no Azure requests or generation/build.
Import-Module (Join-Path $PSScriptRoot '..' 'EdgeAction.TestRunner.psm1') -Force

InModuleScope EdgeAction.TestRunner {
    Describe 'Test configuration' {
        BeforeEach {
            $configPath = Join-Path $TestDrive 'config.psd1'
            '@{}' | Set-Content $configPath
        }
        It 'provides an importable local example with only supported safe values' {
            $examplePath = Join-Path (Get-Module EdgeAction.TestRunner).ModuleBase 'TestSettings.local.example.psd1'
            $example = Import-PowerShellDataFile $examplePath
            $expected = @{
                SubscriptionId = ''
                EnvironmentName = 'Brazilus'
                ResourceManagerUrl = 'https://brazilus.management.azure.com/'
                Audience = 'https://management.core.windows.net/'
                ResourceGroupName = 'powershelltests'
                ApiVersion = '2026-10-01'
                PesterPath = ''
            }
            $example.Count | Should -Be $expected.Count
            $config = Get-EdgeActionTestConfig $examplePath
            foreach ($key in $expected.Keys) {
                $example.ContainsKey($key) | Should -Be $true
                $example[$key] | Should -Be $expected[$key]
                $config[$key] | Should -Be $expected[$key]
            }
        }
        It 'requires an explicit subscription to use the example for resource changes' {
            $examplePath = Join-Path (Get-Module EdgeAction.TestRunner).ModuleBase 'TestSettings.local.example.psd1'
            $config = Get-EdgeActionTestConfig $examplePath
            { Assert-EdgeActionMutation $config Playback } | Should -Not -Throw
            { Assert-EdgeActionMutation $config Record -AllowResourceChanges } | Should -Throw 'explicit SubscriptionId'
            $config = Get-EdgeActionTestConfig $examplePath '00000000-0000-0000-0000-000000000001'
            { Assert-EdgeActionMutation $config Record -AllowResourceChanges } | Should -Not -Throw
        }
        It 'defaults to Azure public cloud with no subscription for playback' {
            $config = Get-EdgeActionTestConfig $configPath
            $config.SubscriptionId | Should -BeNullOrEmpty
            $config.EnvironmentName | Should -Be 'AzureCloud'
            $config.ResourceManagerUrl | Should -Be 'https://management.azure.com/'
            $config.Audience | Should -Be 'https://management.core.windows.net/'
            $config.ApiVersion | Should -Be '2026-10-01'
            { Assert-EdgeActionMutation $config Playback } | Should -Not -Throw
            { Assert-EdgeActionMutation $config Record -AllowResourceChanges } | Should -Throw 'explicit SubscriptionId'
        }
        It 'rejects unknown keys, non-string values, and subscription names' {
            "@{ Unknown = 'value' }" | Set-Content $configPath
            { Get-EdgeActionTestConfig $configPath } | Should -Throw 'Unknown configuration key'
            '@{ SubscriptionId = 123 }' | Set-Content $configPath
            { Get-EdgeActionTestConfig $configPath } | Should -Throw 'must be a string'
            '@{}' | Set-Content $configPath
            { Get-EdgeActionTestConfig $configPath 'display-name' } | Should -Throw 'must be a GUID'
        }
        It 'allows an explicit subscription argument to override config' {
            "@{ SubscriptionId = '00000000-0000-0000-0000-000000000001' }" | Set-Content $configPath
            (Get-EdgeActionTestConfig $configPath '00000000-0000-0000-0000-000000000002').SubscriptionId |
                Should -Be '00000000-0000-0000-0000-000000000002'
        }
        It 'discovers the ignored sibling override only beside the script' {
            Mock Test-Path { $true } -ParameterFilter { $LiteralPath -like '*TestSettings.local.psd1' }
            Mock Import-PowerShellDataFile {
                @{
                    SubscriptionId = '00000000-0000-0000-0000-000000000003'
                    EnvironmentName = 'Brazilus'
                    ResourceManagerUrl = 'https://brazilus.management.azure.com/'
                }
            } -ParameterFilter { $LiteralPath -like '*TestSettings.local.psd1' }
            $config = Get-EdgeActionTestConfig
            $config.SubscriptionId | Should -Be '00000000-0000-0000-0000-000000000003'
            $config.EnvironmentName | Should -Be 'Brazilus'
            $config.ResourceManagerUrl | Should -Be 'https://brazilus.management.azure.com/'
            $config.Audience | Should -Be 'https://management.core.windows.net/'
            Assert-MockCalled Import-PowerShellDataFile -Scope It -Times 1 -Exactly -ParameterFilter {
                $LiteralPath -eq (Join-Path (Get-Module EdgeAction.TestRunner).ModuleBase 'TestSettings.local.psd1')
            }
            Assert-MockCalled Test-Path -Scope It -Times 1 -Exactly
        }
        It 'uses an explicit file instead of the default sibling' {
            "@{ SubscriptionId = '00000000-0000-0000-0000-000000000004' }" | Set-Content $configPath
            Mock Test-Path { throw 'Default config discovery should not run for an explicit path.' }
            $config = Get-EdgeActionTestConfig $configPath
            $config.SubscriptionId | Should -Be '00000000-0000-0000-0000-000000000004'
            $config.EnvironmentName | Should -Be 'AzureCloud'
            Assert-MockCalled Test-Path -Scope It -Times 0 -Exactly
        }
        It 'rejects <Reason> in configuration' -TestCases @(
            @{ Reason = 'unknown environments'; Data = "@{ EnvironmentName = 'OtherCloud' }"; ExpectedError = 'EnvironmentName must be AzureCloud or Brazilus' }
            @{ Reason = 'Brazilus with the public endpoint'; Data = "@{ EnvironmentName = 'Brazilus' }"; ExpectedError = 'not allowed for Brazilus' }
            @{ Reason = 'AzureCloud with the Brazilus endpoint'; Data = "@{ ResourceManagerUrl = 'https://brazilus.management.azure.com/' }"; ExpectedError = 'not allowed for AzureCloud' }
            @{ Reason = 'arbitrary HTTPS endpoints'; Data = "@{ ResourceManagerUrl = 'https://unexpected.invalid/' }"; ExpectedError = 'not allowed for AzureCloud' }
            @{ Reason = 'unexpected endpoint ports'; Data = "@{ ResourceManagerUrl = 'https://management.azure.com:444/' }"; ExpectedError = 'not allowed for AzureCloud' }
            @{ Reason = 'unexpected endpoint paths'; Data = "@{ ResourceManagerUrl = 'https://management.azure.com/other' }"; ExpectedError = 'not allowed for AzureCloud' }
            @{ Reason = 'the ARM URL as the AzureCloud audience'; Data = "@{ Audience = 'https://management.azure.com/' }"; ExpectedError = 'not allowed for AzureCloud' }
            @{ Reason = 'arbitrary Brazilus endpoints'; Data = "@{ EnvironmentName = 'Brazilus'; ResourceManagerUrl = 'https://unexpected.invalid/' }"; ExpectedError = 'not allowed for Brazilus' }
            @{ Reason = 'unexpected Brazilus audiences'; Data = "@{ EnvironmentName = 'Brazilus'; ResourceManagerUrl = 'https://brazilus.management.azure.com/'; Audience = 'https://unexpected.invalid/' }"; ExpectedError = 'not allowed for Brazilus' }
        ) {
            param($Reason, $Data, $ExpectedError)
            $Data | Set-Content $configPath
            { Get-EdgeActionTestConfig $configPath } | Should -Throw $ExpectedError
        }
        It 'rejects unsafe endpoint URLs' {
            foreach ($url in @('http://example.invalid', 'https://user:secret@example.invalid', 'https://example.invalid/?token=x')) {
                "@{ ResourceManagerUrl = '$url' }" | Set-Content $configPath
                { Get-EdgeActionTestConfig $configPath } | Should -Throw 'absolute HTTPS URL'
            }
        }
        It 'rejects resource group overrides and incompatible API versions' {
            "@{ ResourceGroupName = 'other' }" | Set-Content $configPath
            { Get-EdgeActionTestConfig $configPath } | Should -Throw 'hardcode powershelltests'
            "@{ ApiVersion = '2025-12-01-preview' }" | Set-Content $configPath
            { Get-EdgeActionTestConfig $configPath } | Should -Throw 'expects API 2026-10-01'
        }
    }

    Describe 'Cloud boundaries and harness orchestration' {
        $environments = @(
            @{ Name = 'AzureCloud'; Endpoint = 'https://management.azure.com/' }
            @{ Name = 'Brazilus'; Endpoint = 'https://brazilus.management.azure.com/' }
        )
        # Placeholders ensure that a missing mock cannot accidentally call Azure.
        function Disable-AzContextAutosave { throw 'Unexpected real call' }
        function Get-AzEnvironment { throw 'Unexpected real call' }
        function Add-AzEnvironment { param($Name, $ARMEndpoint, $Scope) throw 'Unexpected real call' }
        function Connect-AzAccount { param($Environment, $Subscription, $Scope) throw 'Unexpected real call' }
        function Get-AzContext { throw 'Unexpected real call' }
        function Invoke-AzRestMethod { param($Method, $Path) throw 'Unexpected real call' }

        BeforeEach {
            $config = @{
                SubscriptionId = '00000000-0000-0000-0000-000000000001'
                EnvironmentName = 'Brazilus'
                ResourceManagerUrl = 'https://brazilus.management.azure.com/'
                Audience = 'https://management.core.windows.net/'
                ResourceGroupName = 'powershelltests'
                ApiVersion = '2026-10-01'
            }
            Mock Initialize-EdgeActionTestModules {}
            Mock Initialize-EdgeActionResources {}
            Mock Confirm-EdgeActionEnvironmentRegistration { throw 'fixture registration not approved' }
            Mock Add-AzEnvironment {}
            Mock Invoke-EdgeActionHarness {}
            Mock Disable-AzContextAutosave {}
            Mock Connect-AzAccount {}
            Mock Get-AzEnvironment {
                @{
                    Name = $config.EnvironmentName; ResourceManagerUrl = $config.ResourceManagerUrl
                    ActiveDirectoryServiceEndpointResourceId = 'https://management.core.windows.net/'
                }
            }
            Mock Get-AzContext {
                @{
                    Subscription = @{ Id = '00000000-0000-0000-0000-000000000001' }
                    Environment = (Get-AzEnvironment)
                }
            }
            Mock Invoke-AzRestMethod { @{ StatusCode = 200 } }
            $script:stepMessages = [Collections.Generic.List[string]]::new()
            Mock Write-Host { param($Object) $script:stepMessages.Add([string]$Object) }
        }
        It 'defaults to playback for <Name> without authentication or resource requests' -TestCases $environments {
            param($Name, $Endpoint)
            $config.EnvironmentName = $Name
            $config.ResourceManagerUrl = $Endpoint
            Invoke-EdgeActionScenario -Config $config -TestName 'Get-AzEdgeAction', 'New-AzEdgeAction'
            Assert-MockCalled Invoke-EdgeActionHarness -Scope It -Times 1 -Exactly -ParameterFilter {
                $Mode -eq 'Playback' -and $TestName.Count -eq 2
            }
            Assert-MockCalled Get-AzContext -Scope It -Times 0 -Exactly
            Assert-MockCalled Invoke-AzRestMethod -Scope It -Times 0 -Exactly
            Assert-MockCalled Connect-AzAccount -Scope It -Times 0 -Exactly
            Assert-MockCalled Get-AzEnvironment -Scope It -Times 0 -Exactly
            Assert-MockCalled Confirm-EdgeActionEnvironmentRegistration -Scope It -Times 0 -Exactly
            Assert-MockCalled Add-AzEnvironment -Scope It -Times 0 -Exactly
            Assert-MockCalled Initialize-EdgeActionResources -Scope It -Times 0 -Exactly
            Assert-MockCalled Disable-AzContextAutosave -Scope It -Times 0 -Exactly
        }
        It 'rejects playback login' {
            { Invoke-EdgeActionScenario $config -Login } | Should -Throw 'only supported for explicit'
            Assert-MockCalled Initialize-EdgeActionTestModules -Scope It -Times 0 -Exactly
        }
        It 'stops before authentication and scenarios when dependency setup fails' {
            Mock Initialize-EdgeActionTestModules { throw 'fixture support setup failed' }
            { Invoke-EdgeActionScenario $config -Mode Record -AllowResourceChanges -Login } | Should -Throw 'fixture support setup failed'
            ($script:stepMessages -join '|') | Should -Be 'Starting test dependency validation and loading.'
            Assert-MockCalled Connect-AzAccount -Scope It -Times 0 -Exactly
            Assert-MockCalled Get-AzContext -Scope It -Times 0 -Exactly
            Assert-MockCalled Invoke-EdgeActionHarness -Scope It -Times 0 -Exactly
        }
        It 'does not announce context completion or harness launch when login fails' {
            Mock Connect-AzAccount { throw 'fixture login failed' }
            { Invoke-EdgeActionScenario $config -Mode Record -AllowResourceChanges -Login } | Should -Throw 'fixture login failed'
            ($script:stepMessages -join '|') | Should -Be (@(
                'Starting test dependency validation and loading.'
                'Completed test dependency validation and loading.'
                'Starting registered-environment verification.'
                'Completed registered-environment verification.'
                'Starting live context and resource-group validation.'
                'Starting process-scoped login.'
            ) -join '|')
        }
        It 'requires consent and subscription for <Name> before module loading' -TestCases $environments {
            param($Name, $Endpoint)
            $config.EnvironmentName = $Name
            $config.ResourceManagerUrl = $Endpoint
            foreach ($mode in 'Record', 'Live') {
                $config.SubscriptionId = '00000000-0000-0000-0000-000000000001'
                { Invoke-EdgeActionScenario $config -Mode $mode } | Should -Throw 'AllowResourceChanges'
                $config.SubscriptionId = ''
                { Invoke-EdgeActionScenario $config -Mode $mode -AllowResourceChanges } | Should -Throw 'explicit SubscriptionId'
            }
            Assert-MockCalled Initialize-EdgeActionTestModules -Scope It -Times 0 -Exactly
            Assert-MockCalled Get-AzEnvironment -Scope It -Times 0 -Exactly
            Assert-MockCalled Initialize-EdgeActionResources -Scope It -Times 0 -Exactly
            Assert-MockCalled Invoke-EdgeActionHarness -Scope It -Times 0 -Exactly
        }
        It 'rejects an unexpected registered environment for <Name> before login' -TestCases $environments {
            param($Name, $Endpoint)
            $config.EnvironmentName = $Name
            $config.ResourceManagerUrl = $Endpoint
            Mock Get-AzEnvironment { @{ Name = 'OtherCloud' } }
            { Invoke-EdgeActionScenario $config -Mode Record -AllowResourceChanges -Login } |
                Should -Throw 'does not match'
            Assert-MockCalled Connect-AzAccount -Scope It -Times 0 -Exactly
            Assert-MockCalled Initialize-EdgeActionResources -Scope It -Times 0 -Exactly
            Assert-MockCalled Disable-AzContextAutosave -Scope It -Times 0 -Exactly
            Assert-MockCalled Invoke-EdgeActionHarness -Scope It -Times 0 -Exactly
        }
        It 'stops on declined missing Brazilus registration before support or login' {
            Mock Get-AzEnvironment { $null }
            { Invoke-EdgeActionScenario $config -Mode Record -AllowResourceChanges -Login } |
                Should -Throw 'fixture registration not approved'
            Assert-MockCalled Confirm-EdgeActionEnvironmentRegistration -Scope It -Times 1 -Exactly
            Assert-MockCalled Add-AzEnvironment -Scope It -Times 0 -Exactly
            Assert-MockCalled Connect-AzAccount -Scope It -Times 0 -Exactly
            Assert-MockCalled Get-AzContext -Scope It -Times 0 -Exactly
            Assert-MockCalled Initialize-EdgeActionResources -Scope It -Times 0 -Exactly
            Assert-MockCalled Disable-AzContextAutosave -Scope It -Times 0 -Exactly
            Assert-MockCalled Invoke-EdgeActionHarness -Scope It -Times 0 -Exactly
            ($script:stepMessages -join '|') | Should -Not -Match 'Starting process-scoped login|Completed live context'
        }
        It 'rejects a subscription mismatch for <Name> before resource access' -TestCases $environments {
            param($Name, $Endpoint)
            $config.EnvironmentName = $Name
            $config.ResourceManagerUrl = $Endpoint
            Mock Get-AzContext {
                @{ Subscription = @{ Id = '00000000-0000-0000-0000-000000000002' }; Environment = (Get-AzEnvironment) }
            }
            { Invoke-EdgeActionScenario $config -Mode Live -AllowResourceChanges } | Should -Throw 'does not match'
            Assert-MockCalled Invoke-AzRestMethod -Scope It -Times 0 -Exactly
            Assert-MockCalled Invoke-EdgeActionHarness -Scope It -Times 0 -Exactly
        }
        It 'rejects context environment, endpoint or audience mismatches for <Name>' -TestCases $environments {
            param($Name, $Endpoint)
            $config.EnvironmentName = $Name
            $config.ResourceManagerUrl = $Endpoint
            $context = Get-AzContext
            foreach ($key in @('Name', 'ResourceManagerUrl', 'ActiveDirectoryServiceEndpointResourceId')) {
                $saved = $context.Environment[$key]
                $context.Environment[$key] = 'https://unexpected.invalid/'
                { Assert-EdgeActionContext $config $context } | Should -Throw 'does not match'
                $context.Environment[$key] = $saved
            }
            { Assert-EdgeActionContext $config $null } | Should -Throw 'Azure context is missing'
        }
        It 'requires an existing readable resource group for <Name>' -TestCases $environments {
            param($Name, $Endpoint)
            $config.EnvironmentName = $Name
            $config.ResourceManagerUrl = $Endpoint
            Mock Invoke-AzRestMethod { @{ StatusCode = 404 } }
            { Invoke-EdgeActionScenario $config -Mode Record -AllowResourceChanges } | Should -Throw 'must already exist'
            Assert-MockCalled Invoke-EdgeActionHarness -Scope It -Times 0 -Exactly
        }
        It 'logs into <Name> and runs the harness in the same session after guards' -TestCases $environments {
            param($Name, $Endpoint)
            $config.EnvironmentName = $Name
            $config.ResourceManagerUrl = $Endpoint
            Invoke-EdgeActionScenario $config -Mode Record -AllowResourceChanges -Login
            (@($script:stepMessages | Where-Object { $_ -match '^(Starting|Completed) ' }) -join '|') | Should -Be (@(
                'Starting test dependency validation and loading.'
                'Completed test dependency validation and loading.'
                'Starting registered-environment verification.'
                'Completed registered-environment verification.'
                'Starting live context and resource-group validation.'
                'Starting process-scoped login.'
                'Completed process-scoped login.'
                'Completed live context and resource-group validation.'
                'Starting Record scenario harness.'
            ) -join '|')
            Assert-MockCalled Connect-AzAccount -Scope It -Times 1 -Exactly -ParameterFilter {
                $Environment -eq $config.EnvironmentName -and $Subscription -eq $config.SubscriptionId -and $Scope -eq 'Process'
            }
            Assert-MockCalled Invoke-AzRestMethod -Scope It -Times 1 -Exactly -ParameterFilter {
                $Method -eq 'GET' -and $Path -like '*/resourcegroups/powershelltests?api-version=2021-04-01'
            }
            Assert-MockCalled Invoke-EdgeActionHarness -Scope It -Times 1 -Exactly -ParameterFilter { $Mode -eq 'Record' }
            Assert-MockCalled Confirm-EdgeActionEnvironmentRegistration -Scope It -Times 0 -Exactly
            Assert-MockCalled Add-AzEnvironment -Scope It -Times 0 -Exactly
        }
        It 'registers missing Brazilus only after confirmation and validates before setup in <Mode>' -TestCases @(
            @{ Mode = 'Record' }
            @{ Mode = 'Live' }
        ) {
            param($Mode)
            $script:registered = $false
            Mock Get-AzEnvironment {
                if ($script:registered) {
                    @{
                        Name = 'Brazilus'; ResourceManagerUrl = $config.ResourceManagerUrl
                        ActiveDirectoryServiceEndpointResourceId = $config.Audience
                    }
                }
            }
            Mock Confirm-EdgeActionEnvironmentRegistration {
                Assert-MockCalled Initialize-EdgeActionResources -Scope It -Times 0 -Exactly
                Assert-MockCalled Connect-AzAccount -Scope It -Times 0 -Exactly
            }
            Mock Add-AzEnvironment {
                Assert-MockCalled Confirm-EdgeActionEnvironmentRegistration -Scope It -Times 1 -Exactly
                $script:registered = $true
            }
            Mock Initialize-EdgeActionResources {
                Assert-MockCalled Get-AzEnvironment -Scope It -Times 2 -Exactly
                ($script:stepMessages -join '|') | Should -Match 'Completed registered-environment verification'
            }
            Invoke-EdgeActionScenario $config -Mode $Mode -AllowResourceChanges -Login
            Assert-MockCalled Add-AzEnvironment -Scope It -Times 1 -Exactly -ParameterFilter {
                $Name -eq 'Brazilus' -and $ARMEndpoint -eq 'https://brazilus.management.azure.com/' -and $Scope -eq 'CurrentUser'
            }
            Assert-MockCalled Invoke-EdgeActionHarness -Scope It -Times 1 -Exactly
        }
        It 'does not offer registration for a missing AzureCloud environment' {
            $config.EnvironmentName = 'AzureCloud'
            $config.ResourceManagerUrl = 'https://management.azure.com/'
            Mock Get-AzEnvironment { $null }
            { Invoke-EdgeActionScenario $config -Mode Live -AllowResourceChanges } |
                Should -Throw "environment 'AzureCloud' is missing"
            Assert-MockCalled Confirm-EdgeActionEnvironmentRegistration -Scope It -Times 0 -Exactly
            Assert-MockCalled Add-AzEnvironment -Scope It -Times 0 -Exactly
            Assert-MockCalled Initialize-EdgeActionResources -Scope It -Times 0 -Exactly
        }
        It 'stops before support when approved registration <Outcome>' -TestCases @(
            @{ Outcome = 'fails'; Message = 'fixture metadata failure' }
            @{ Outcome = 'returns mismatched metadata'; Message = 'ActiveDirectoryServiceEndpointResourceId expected' }
            @{ Outcome = 'remains missing'; Message = "environment 'Brazilus' is missing" }
        ) {
            param($Outcome, $Message)
            $script:registered = $false
            Mock Confirm-EdgeActionEnvironmentRegistration {}
            Mock Get-AzEnvironment {
                if ($script:registered -and $Outcome -ne 'remains missing') {
                    @{
                        Name = 'Brazilus'; ResourceManagerUrl = $config.ResourceManagerUrl
                        ActiveDirectoryServiceEndpointResourceId = 'https://unexpected.invalid/'
                    }
                }
            }
            Mock Add-AzEnvironment {
                if ($Outcome -eq 'fails') { throw 'fixture metadata failure' }
                $script:registered = $true
            }
            { Invoke-EdgeActionScenario $config -Mode Record -AllowResourceChanges -Login } | Should -Throw $Message
            Assert-MockCalled Add-AzEnvironment -Scope It -Times 1 -Exactly
            Assert-MockCalled Initialize-EdgeActionResources -Scope It -Times 0 -Exactly
            Assert-MockCalled Connect-AzAccount -Scope It -Times 0 -Exactly
            Assert-MockCalled Invoke-EdgeActionHarness -Scope It -Times 0 -Exactly
        }
        It 'verifies registration before Resources setup and authentication for <Mode>' -TestCases @(
            @{ Mode = 'Record' }
            @{ Mode = 'Live' }
        ) {
            param($Mode)
            Mock Get-AzEnvironment {
                Assert-MockCalled Initialize-EdgeActionTestModules -Scope It -Times 1 -Exactly
                @{
                    Name = $config.EnvironmentName; ResourceManagerUrl = $config.ResourceManagerUrl
                    ActiveDirectoryServiceEndpointResourceId = $config.Audience
                }
            }
            Mock Initialize-EdgeActionResources {
                Assert-MockCalled Get-AzEnvironment -Scope It -Times 1 -Exactly
                Assert-MockCalled Disable-AzContextAutosave -Scope It -Times 0 -Exactly
                Assert-MockCalled Connect-AzAccount -Scope It -Times 0 -Exactly
                ($script:stepMessages -join '|') | Should -Match 'Completed registered-environment verification'
            }
            Mock Connect-AzAccount {
                Assert-MockCalled Initialize-EdgeActionResources -Scope It -Times 1 -Exactly
            }
            Invoke-EdgeActionScenario $config -Mode $Mode -AllowResourceChanges -Login
            Assert-MockCalled Initialize-EdgeActionResources -Scope It -Times 1 -Exactly
            Assert-MockCalled Invoke-EdgeActionHarness -Scope It -Times 1 -Exactly
        }
        It 'stops on a <Property> preflight mismatch before support or profile changes in <Mode>' -TestCases @(
            @{ Property = 'Name'; Mode = 'Record' }
            @{ Property = 'ResourceManagerUrl'; Mode = 'Live' }
            @{ Property = 'ActiveDirectoryServiceEndpointResourceId'; Mode = 'Record' }
        ) {
            param($Property, $Mode)
            Mock Get-AzEnvironment {
                $environment = @{
                    Name = $config.EnvironmentName; ResourceManagerUrl = $config.ResourceManagerUrl
                    ActiveDirectoryServiceEndpointResourceId = $config.Audience
                }
                $environment[$Property] = 'https://unexpected.invalid/'
                $environment
            }
            { Invoke-EdgeActionScenario $config -Mode $Mode -AllowResourceChanges -Login } |
                Should -Throw "Registered Azure environment does not match: $Property"
            Assert-MockCalled Initialize-EdgeActionResources -Scope It -Times 0 -Exactly
            Assert-MockCalled Confirm-EdgeActionEnvironmentRegistration -Scope It -Times 0 -Exactly
            Assert-MockCalled Add-AzEnvironment -Scope It -Times 0 -Exactly
            Assert-MockCalled Disable-AzContextAutosave -Scope It -Times 0 -Exactly
            Assert-MockCalled Connect-AzAccount -Scope It -Times 0 -Exactly
            Assert-MockCalled Invoke-AzRestMethod -Scope It -Times 0 -Exactly
            Assert-MockCalled Invoke-EdgeActionHarness -Scope It -Times 0 -Exactly
        }
        It 'stops before authentication when support setup fails after successful verification' {
            Mock Initialize-EdgeActionResources { throw 'fixture support setup failed' }
            { Invoke-EdgeActionScenario $config -Mode Record -AllowResourceChanges -Login } | Should -Throw 'fixture support setup failed'
            ($script:stepMessages -join '|') | Should -Match 'Completed registered-environment verification'
            ($script:stepMessages -join '|') | Should -Not -Match 'Starting live context|Starting Record scenario'
            Assert-MockCalled Connect-AzAccount -Scope It -Times 0 -Exactly
            Assert-MockCalled Disable-AzContextAutosave -Scope It -Times 0 -Exactly
            Assert-MockCalled Invoke-EdgeActionHarness -Scope It -Times 0 -Exactly
        }
        It 'rejects unvalidated direct scenario configurations before module loading' {
            foreach ($key in 'EnvironmentName', 'ResourceManagerUrl', 'Audience') {
                $invalid = $config.Clone()
                $invalid[$key] = 'https://unexpected.invalid/'
                { Invoke-EdgeActionScenario $invalid -Mode Record -AllowResourceChanges -Login } | Should -Throw
            }
            Assert-MockCalled Initialize-EdgeActionTestModules -Scope It -Times 0 -Exactly
            Assert-MockCalled Connect-AzAccount -Scope It -Times 0 -Exactly
            Assert-MockCalled Invoke-AzRestMethod -Scope It -Times 0 -Exactly
            Assert-MockCalled Invoke-EdgeActionHarness -Scope It -Times 0 -Exactly
        }
    }

    Describe 'Dependency isolation without installation' {
        BeforeEach {
            $savedModulePath = $env:PSModulePath
            Mock New-Item {}
            Mock Copy-Item {}
            Mock Test-Path { $true }
            Mock Test-Path { $false } -ParameterFilter { $Path -like '*generated*modules*' }
            Mock Test-ModuleManifest {
                [pscustomobject]@{
                    Name = 'Pester'; Version = [version]'4.10.1'
                    ModuleBase = (Join-Path $TestDrive 'shared' 'Pester' '4.10.1')
                }
            }
            Mock Import-Module {}
            Mock Initialize-EdgeActionResources {}
            Mock Get-Module {
                if ($Name -eq 'Pester') {
                    [pscustomobject]@{ Version = [version]'4.10.1' }
                } else {
                    [pscustomobject]@{
                        Version = [version]'5.5.3'
                        ModuleBase = (Join-Path $script:RepoRoot 'artifacts' 'Debug' 'Az.Accounts')
                    }
                }
            }
            Mock Get-Module {
                [pscustomobject]@{
                    Version = [version]'5.5.3'
                    ModuleBase = (Join-Path $script:RepoRoot 'artifacts' 'Debug' 'Az.Accounts')
                }
            } -ParameterFilter { $Name -eq 'Az.Accounts' }
        }
        AfterEach { $env:PSModulePath = $savedModulePath }
        It 'stages only the selected Pester version under a module search root' {
            Initialize-EdgeActionTestModules @{ PesterPath = 'fixture.psd1' } $TestDrive
            ($env:PSModulePath -split [IO.Path]::PathSeparator)[0] | Should -Be ([string]$TestDrive)
            Assert-MockCalled Copy-Item -Scope It -Times 1 -Exactly -ParameterFilter {
                $LiteralPath -eq (Join-Path $TestDrive 'shared' 'Pester' '4.10.1') -and
                $Destination -eq (Join-Path $TestDrive 'Pester')
            }
            Assert-MockCalled Import-Module -Scope It -Times 2 -Exactly
            Assert-MockCalled Initialize-EdgeActionResources -Scope It -Times 0 -Exactly
        }
        It 'rejects missing built artifacts' {
            Mock Test-Path { $false }
            { Initialize-EdgeActionTestModules @{} } | Should -Throw 'Build first'
            { Initialize-EdgeActionTestModules @{} } |
                Should -Throw (Join-Path $script:RepoRoot 'src' 'EdgeAction' 'EdgeAction.Autorest' 'how-to.md')
            Assert-MockCalled Import-Module -Scope It -Times 0 -Exactly
        }
        It 'provides absolute Pester setup guidance from <WorkingFolder>' -TestCases @(
            @{ WorkingFolder = '.' }
            @{ WorkingFolder = (Join-Path 'src' 'EdgeAction' 'EdgeAction.Autorest') }
        ) {
            param($WorkingFolder)
            Mock Get-Module {}
            $howTo = Join-Path $script:RepoRoot 'src' 'EdgeAction' 'EdgeAction.Autorest' 'how-to.md'
            Push-Location (Join-Path $script:RepoRoot $WorkingFolder)
            try {
                { Initialize-EdgeActionTestModules @{} } |
                    Should -Throw "Install Pester 4.10.1 as described in '$howTo'"
            } finally {
                Pop-Location
            }
            Assert-MockCalled Import-Module -Scope It -Times 0 -Exactly
        }
        It 'rejects the wrong Pester version' {
            Mock Test-ModuleManifest { @{ Name = 'Pester'; Version = [version]'5.7.0' } }
            { Initialize-EdgeActionTestModules @{ PesterPath = 'fixture.psd1' } $TestDrive } |
                Should -Throw 'must identify Pester 4.10.1'
        }
        It 'rejects shadowing Accounts modules instead of using them' {
            Mock Get-Module { @{ Version = [version]'99.0'; ModuleBase = 'wrong' } } -ParameterFilter { $Name -eq 'Az.Accounts' }
            { Initialize-EdgeActionTestModules @{ PesterPath = 'fixture.psd1' } $TestDrive } |
                Should -Throw 'different Az.Accounts'
        }
    }

    Describe 'Automatic Resources support with a local dependency-helper fixture' {
        BeforeEach {
            $savedRoot = $script:RepoRoot
            $savedArtifact = $script:Artifact
            $script:RepoRoot = Join-Path $TestDrive ([guid]::NewGuid().ToString())
            $script:Artifact = Join-Path $script:RepoRoot 'artifacts' 'Debug' 'Az.EdgeAction' 'EdgeAction.Autorest'
            $sourceSupport = Join-Path $script:RepoRoot 'src' 'EdgeAction' 'EdgeAction.Autorest' 'tools' 'Resources'
            $fixtureHome = Join-Path $script:RepoRoot 'home'
            Set-Variable HOME -Value $fixtureHome -Scope Script -Force
            $destination = Join-Path $fixtureHome '.PSSharedModules' 'Resources'
            $null = New-Item $script:Artifact, (Join-Path $sourceSupport 'custom'), $fixtureHome -ItemType Directory -Force
            'fixture specification' | Set-Content (Join-Path $sourceSupport 'README.md')
            'fixture customization' | Set-Content (Join-Path $sourceSupport 'custom' 'New-AzDeployment.ps1')
            @'
param([switch]$NotIsolated, [switch]$Pester, [switch]$Resources)
if (-not $NotIsolated -or -not $Pester -or -not $Resources) { throw 'Wrong helper arguments' }
if (-not $RegenerateSupportModule.IsPresent) { throw 'Missing inherited regeneration switch' }
if (-not (Test-Path (Join-Path $PSScriptRoot 'tools' 'Resources' 'README.md'))) { throw 'Missing specification' }
if (-not (Test-Path (Join-Path $PSScriptRoot 'tools' 'Resources' 'custom' 'New-AzDeployment.ps1'))) { throw 'Missing customization' }
@{ Registry = $env:autorest_registry; Sources = $env:RestoreSources; Dotnet = (Get-Command dotnet).Source } |
    ConvertTo-Json | Set-Content (Join-Path $PSScriptRoot 'helper-environment.json')
$behavior = Get-Content (Join-Path $PSScriptRoot 'behavior.txt')
$env:PSModulePath = 'fixture helper changed module path'
Set-Location $HOME
if ($behavior -eq 'throw') { throw 'Fixture dependency failure' }
if ($behavior -eq 'exit') { $global:LASTEXITCODE = 7; return }
$output = Join-Path $HOME '.PSSharedModules' 'Resources'
$null = New-Item (Join-Path $output 'bin') -ItemType Directory -Force
'function Get-SupportFixture { }; Export-ModuleMember Get-SupportFixture' | Set-Content (Join-Path $output 'Az.Resources.TestSupport.psm1')
if ($behavior -eq 'partial') { return }
"@{ RootModule = 'Az.Resources.TestSupport.psm1'; ModuleVersion = '0.0.1' }" | Set-Content (Join-Path $output 'Az.Resources.TestSupport.psd1')
'fixture assembly placeholder' | Set-Content (Join-Path $output 'bin' 'Az.Resources.TestSupport.private.dll')
if ($behavior -eq 'invalid import') { "throw 'Fixture import failure'" | Set-Content (Join-Path $output 'Az.Resources.TestSupport.psm1') }
'@ | Set-Content (Join-Path $script:Artifact 'check-dependencies.ps1')
            'success' | Set-Content (Join-Path $script:Artifact 'behavior.txt')
            $savedEnvironment = @{}
            foreach ($name in @('PATH', 'PSModulePath', 'autorest_registry', 'RestoreSources')) {
                $savedEnvironment[$name] = [Environment]::GetEnvironmentVariable($name)
            }
            $beforeLocation = (Get-Location).Path
            $script:resourceMessages = [Collections.Generic.List[string]]::new()
            Mock Write-Host { param($Object) $script:resourceMessages.Add([string]$Object) }
        }
        AfterEach {
            try {
                (Get-Location).Path | Should -Be $beforeLocation
                foreach ($name in $savedEnvironment.Keys) {
                    [Environment]::GetEnvironmentVariable($name) | Should -Be $savedEnvironment[$name]
                }
            } finally {
                Remove-Module Az.Resources.TestSupport -ErrorAction SilentlyContinue
                Remove-Variable HOME -Scope Script -Force
                $script:RepoRoot = $savedRoot
                $script:Artifact = $savedArtifact
            }
        }
        It 'builds <State> support through the helper with process-local feeds and preserved artifact inputs' -TestCases @(
            @{ State = 'missing' }
            @{ State = 'psm1 only' }
            @{ State = 'missing assembly' }
        ) {
            param($State)
            if ($State -ne 'missing') {
                $null = New-Item $destination -ItemType Directory -Force
                'partial script' | Set-Content (Join-Path $destination 'Az.Resources.TestSupport.psm1')
                if ($State -eq 'missing assembly') { '@{}' | Set-Content (Join-Path $destination 'Az.Resources.TestSupport.psd1') }
            }
            $payload = Join-Path $script:Artifact 'tools' 'Resources'
            $null = New-Item $payload -ItemType Directory -Force
            'retained artifact specification' | Set-Content (Join-Path $payload 'README.md')
            Initialize-EdgeActionResources
            ($script:resourceMessages -join '|') | Should -Be 'Starting Resources test-support setup.|Completed Resources test-support setup.'
            Get-Content (Join-Path $payload 'README.md') | Should -Be 'retained artifact specification'
            Get-Content (Join-Path $payload 'custom' 'New-AzDeployment.ps1') | Should -Be 'fixture customization'
            $child = Get-Content (Join-Path $script:Artifact 'helper-environment.json') -Raw | ConvertFrom-Json
            $child.Registry | Should -Be 'https://packagefeedproxy.microsoft.io/npm/'
            $child.Sources | Should -Be (@(
                (Join-Path $script:RepoRoot 'tools' 'LocalFeed')
                'https://pkgs.dev.azure.com/azclitools/public/_packaging/azure-powershell/nuget/v3/index.json'
                'https://packagefeedproxy.microsoft.io/nuget/v3/index.json'
            ) -join ';')
            $child.Dotnet | Should -Not -Match 'node_modules'
            (Get-Module Az.Resources.TestSupport).ExportedCommands.Count | Should -Be 1
        }
        It 'reuses complete support without inspecting build tools or running the helper' {
            Initialize-EdgeActionResources
            $before = (Get-FileHash (Join-Path $destination 'Az.Resources.TestSupport.psm1')).Hash
            $script:resourceMessages.Clear()
            Remove-Item (Join-Path $sourceSupport 'README.md')
            'throw' | Set-Content (Join-Path $script:Artifact 'behavior.txt')
            $env:PATH = $fixtureHome
            try { Initialize-EdgeActionResources }
            finally { $env:PATH = $savedEnvironment.PATH }
            ($script:resourceMessages -join '|') | Should -Be 'Using installed Resources test support.'
            (Get-FileHash (Join-Path $destination 'Az.Resources.TestSupport.psm1')).Hash | Should -Be $before
        }
        It 'rejects <Behavior> without announcing setup completion' -TestCases @(
            @{ Behavior = 'throw'; Message = 'Fixture dependency failure' }
            @{ Behavior = 'exit'; Message = 'dependency helper failed (exit 7)' }
            @{ Behavior = 'partial'; Message = 'test support is incomplete' }
            @{ Behavior = 'invalid import'; Message = 'Fixture import failure' }
        ) {
            param($Behavior, $Message)
            $Behavior | Set-Content (Join-Path $script:Artifact 'behavior.txt')
            { Initialize-EdgeActionResources } | Should -Throw $Message
            ($script:resourceMessages -join '|') | Should -Be 'Starting Resources test-support setup.'
        }
        It 'rejects missing source inputs before invoking native tools or the helper' {
            Remove-Item (Join-Path $sourceSupport 'README.md')
            { Initialize-EdgeActionResources } | Should -Throw 'Resources setup input is missing'
            Test-Path (Join-Path $script:Artifact 'helper-environment.json') | Should -Be $false
        }
        It 'reports missing build tools without changing artifact payload or invoking the helper' {
            $env:PATH = $fixtureHome
            try {
                { Initialize-EdgeActionResources } | Should -Throw 'node'
                $env:PATH | Should -Be $fixtureHome
            } finally { $env:PATH = $savedEnvironment.PATH }
            Test-Path (Join-Path $script:Artifact 'tools') | Should -Be $false
            ($script:resourceMessages -join '|') | Should -Be 'Starting Resources test-support setup.'
        }
    }

    Describe 'Brazilus registration confirmation' {
        It 'accepts explicit <Answer> approval with persistent-change disclosure' -TestCases @(
            @{ Answer = 'y' }
            @{ Answer = 'YES' }
        ) {
            param($Answer)
            Mock Read-Host { $Answer }
            { Confirm-EdgeActionEnvironmentRegistration -Interactive $true } | Should -Not -Throw
            Assert-MockCalled Read-Host -Scope It -Times 1 -Exactly -ParameterFilter {
                $Prompt -like '*metadata over the network*persistently*CurrentUser*'
            }
        }
        It 'declines <Label> without default consent' -TestCases @(
            @{ Label = 'blank'; Answer = '' }
            @{ Label = 'no'; Answer = 'n' }
            @{ Label = 'unrecognized input'; Answer = 'maybe' }
        ) {
            param($Answer)
            Mock Read-Host { $Answer }
            { Confirm-EdgeActionEnvironmentRegistration -Interactive $true } | Should -Throw 'not approved'
        }
        It 'fails without reading input when noninteractive' {
            Mock Read-Host { throw 'must not prompt' }
            { Confirm-EdgeActionEnvironmentRegistration -Interactive $false } | Should -Throw 'interactive confirmation is unavailable'
            Assert-MockCalled Read-Host -Scope It -Times 0 -Exactly
        }
        It 'reports an unavailable host prompt without approving registration' {
            Mock Read-Host { throw 'fixture host unavailable' }
            { Confirm-EdgeActionEnvironmentRegistration -Interactive $true } |
                Should -Throw 'confirmation failed; no registration was attempted'
        }
    }

    Describe 'Redacted context diagnostics' {
        BeforeEach {
            $config = @{
                SubscriptionId = '00000000-0000-0000-0000-000000000001'
                EnvironmentName = 'Brazilus'
                ResourceManagerUrl = 'https://brazilus.management.azure.com/'
                Audience = 'https://management.core.windows.net/'
            }
            $context = @{
                Subscription = @{ Id = $config.SubscriptionId }
                Environment = @{
                    Name = 'Brazilus'
                    ResourceManagerUrl = $config.ResourceManagerUrl
                    ActiveDirectoryServiceEndpointResourceId = $config.Audience
                }
            }
        }
        It 'identifies the mismatched <Property> without disclosing subscription IDs' -TestCases @(
            @{ Property = 'Name'; Value = 'AzureCloud'; Display = 'AzureCloud' }
            @{ Property = 'ResourceManagerUrl'; Value = 'https://management.azure.com/'; Display = 'https://management.azure.com/' }
            @{ Property = 'ActiveDirectoryServiceEndpointResourceId'; Value = 'https://management.azure.com/'; Display = 'https://management.azure.com/' }
            @{ Property = 'ResourceManagerUrl'; Value = $null; Display = '<missing>' }
            @{ Property = 'ActiveDirectoryServiceEndpointResourceId'; Value = ''; Display = '<missing>' }
        ) {
            param($Property, $Value, $Display)
            $context.Environment[$Property] = $Value
            $message = try { Assert-EdgeActionContext $config $context } catch { $_.Exception.Message }
            $message | Should -Match ([regex]::Escape("Azure context environment does not match: $Property expected"))
            $message | Should -Match ([regex]::Escape("actual '$Display'"))
            $message | Should -Not -Match $config.SubscriptionId
        }
        It 'redacts both subscription IDs while distinguishing a mismatch from missing data' {
            $context.Subscription.Id = '00000000-0000-0000-0000-000000000002'
            $message = try { Assert-EdgeActionContext $config $context } catch { $_.Exception.Message }
            $message | Should -Match 'Subscription.Id expected.*different subscription; IDs redacted'
            $message | Should -Not -Match $context.Subscription.Id
            $message | Should -Not -Match $config.SubscriptionId
            $context.Subscription = $null
            { Assert-EdgeActionContext $config $context } | Should -Throw "actual '<missing>'"
            { Assert-EdgeActionContext $config $null } | Should -Throw 'Azure context is missing'
        }
        It 'does not print sensitive values in an invalid environment endpoint' -TestCases @(
            @{ Url = 'https://example.invalid/?token=fixture-secret' }
            @{ Url = 'https://user:fixture-secret@example.invalid/' }
            @{ Url = 'https://example.invalid/#fixture-secret' }
            @{ Url = 'fixture-secret' }
        ) {
            param($Url)
            $context.Environment.ResourceManagerUrl = $Url
            $message = try { Assert-EdgeActionContext $config $context } catch { $_.Exception.Message }
            $message | Should -Match 'ResourceManagerUrl expected'
            $message | Should -Not -Match 'fixture-secret'
        }
        It 'redacts IDs embedded in endpoint paths' {
            $context.Environment.ResourceManagerUrl = 'https://example.invalid/00000000-0000-0000-0000-000000000003'
            $message = try { Assert-EdgeActionContext $config $context } catch { $_.Exception.Message }
            $message | Should -Match 'https://example.invalid/<redacted-id>'
            $message | Should -Not -Match '00000000-0000-0000-0000-000000000003'
        }
        It 'preserves trailing-slash equivalence without weakening endpoint checks' {
            $context.Environment.ResourceManagerUrl = $config.ResourceManagerUrl.TrimEnd('/')
            $context.Environment.ActiveDirectoryServiceEndpointResourceId = $config.Audience.TrimEnd('/')
            { Assert-EdgeActionContext $config $context } | Should -Not -Throw
        }
    }

    Describe 'Artifact harness working directory' {
        It 'restores cwd after the harness <Outcome>' -TestCases @(
            @{ Outcome = 'returns'; Fail = $false }
            @{ Outcome = 'throws'; Fail = $true }
        ) {
            param($Outcome, $Fail)
            $savedArtifact = $script:Artifact
            $before = (Get-Location).Path
            $script:Artifact = Join-Path $TestDrive ([guid]::NewGuid().ToString())
            $null = New-Item $script:Artifact -ItemType Directory
            @'
param([switch]$NotIsolated, [switch]$Playback, [string[]]$TestName)
if ((Get-Location).Path -ne $PSScriptRoot) { throw 'Wrong harness directory' }
Set-Location $HOME
if ($TestName -contains 'fail') { throw 'Fixture harness failure' }
'@ | Set-Content (Join-Path $script:Artifact 'test-module.ps1')
            try {
                if ($Fail) { { Invoke-EdgeActionHarness Playback 'fail' } | Should -Throw 'Fixture harness failure' }
                else { Invoke-EdgeActionHarness Playback }
                (Get-Location).Path | Should -Be $before
            } finally {
                $script:Artifact = $savedArtifact
                Set-Location $before
            }
        }
    }

    Describe 'Successful Record handoff for source review' {
        BeforeEach {
            $savedRoot = $script:RepoRoot
            $savedArtifact = $script:Artifact
            $script:RepoRoot = Join-Path $TestDrive ([guid]::NewGuid().ToString())
            $script:Artifact = Join-Path $script:RepoRoot 'artifacts' 'Debug' 'Az.EdgeAction' 'EdgeAction.Autorest'
            $artifactTest = Join-Path $script:Artifact 'test'
            $sourceTest = Join-Path $script:RepoRoot 'src' 'EdgeAction' 'EdgeAction.Autorest' 'test'
            $null = New-Item -ItemType Directory -Path $artifactTest, $sourceTest -Force
            $safeRecording = '{"Get-AzEdgeAction++Get+$GET+https://example.invalid/?api-version=2026-10-01+1":{"Request":{"Headers":{"Authorization":["[Filtered]"]},"ContentHeaders":{},"Content":null},"Response":{"Headers":{},"ContentHeaders":{},"Content":"{}"}}}'
            $metadata = '{"SubscriptionId":"00000000-0000-0000-0000-000000000001","Tenant":"00000000-0000-0000-0000-000000000002","ResourceGroupName":"powershelltests"}'
            foreach ($folder in $artifactTest, $sourceTest) {
                Set-Content (Join-Path $folder 'env.json') $metadata
                foreach ($group in 'Get-AzEdgeAction', 'New-AzEdgeAction') {
                    Set-Content (Join-Path $folder "$group.Recording.json") '{}'
                    Set-Content (Join-Path $folder "$group.Tests.ps1") '# fixture test'
                }
            }
            $resultsPath = Join-Path $artifactTest 'Az.EdgeAction-TestResults.xml'
            Set-Content $resultsPath '<test-results failures="0" errors="0"><test-case name="Get-AzEdgeAction.Get" executed="True" success="True" /></test-results>'
            $before = Get-EdgeActionRecordingState
            Set-Content (Join-Path $artifactTest 'Get-AzEdgeAction.Recording.json') $safeRecording
        }
        AfterEach {
            $script:RepoRoot = $savedRoot
            $script:Artifact = $savedArtifact
        }
        It 'copies only changed selected recordings, preserving unrelated and excluded files' {
            Set-Content (Join-Path $artifactTest 'New-AzEdgeAction.Recording.json') $safeRecording
            Set-Content (Join-Path $artifactTest 'localEnv.json') '{"credential":"fixture-secret"}'
            Set-Content (Join-Path $artifactTest 'Get-AzEdgeAction.Tests.ps1') '# must not copy'
            Copy-EdgeActionRecordingsForReview $before $resultsPath
            (Get-FileHash (Join-Path $sourceTest 'Get-AzEdgeAction.Recording.json')).Hash |
                Should -Be (Get-FileHash (Join-Path $artifactTest 'Get-AzEdgeAction.Recording.json')).Hash
            (Get-Content (Join-Path $sourceTest 'New-AzEdgeAction.Recording.json') -Raw).Trim() | Should -Be '{}'
            (Get-Content (Join-Path $sourceTest 'Get-AzEdgeAction.Tests.ps1') -Raw).Trim() | Should -Be '# fixture test'
            Test-Path (Join-Path $sourceTest 'localEnv.json') | Should -Be $false
            Test-Path (Join-Path $sourceTest 'Az.EdgeAction-TestResults.xml') | Should -Be $false
        }
        It 'copies all changed selected groups and matching metadata together' {
            Set-Content $resultsPath '<test-results><test-case name="Get-AzEdgeAction.Get" /><test-case name="New-AzEdgeAction.Create" /></test-results>'
            Set-Content (Join-Path $artifactTest 'New-AzEdgeAction.Recording.json') $safeRecording
            Set-Content (Join-Path $artifactTest 'env.json') ($metadata.Replace('000000000001', '000000000003'))
            Copy-EdgeActionRecordingsForReview $before $resultsPath
            foreach ($name in 'Get-AzEdgeAction.Recording.json', 'New-AzEdgeAction.Recording.json', 'env.json') {
                (Get-FileHash (Join-Path $sourceTest $name)).Hash | Should -Be (Get-FileHash (Join-Path $artifactTest $name)).Hash
            }
        }
        It 'does not copy stale unchanged recordings even when source differs' {
            $before = Get-EdgeActionRecordingState
            Copy-EdgeActionRecordingsForReview $before $resultsPath
            (Get-Content (Join-Path $sourceTest 'Get-AzEdgeAction.Recording.json') -Raw).Trim() | Should -Be '{}'
        }
        It 'copies a selected recording rewritten with identical content during the run' {
            $before = Get-EdgeActionRecordingState
            $recording = Join-Path $artifactTest 'Get-AzEdgeAction.Recording.json'
            [IO.File]::SetLastWriteTimeUtc($recording, $before.ArtifactWriteTime['Get-AzEdgeAction.Recording.json'].AddSeconds(1))
            Copy-EdgeActionRecordingsForReview $before $resultsPath
            (Get-FileHash (Join-Path $sourceTest 'Get-AzEdgeAction.Recording.json')).Hash | Should -Be (Get-FileHash $recording).Hash
        }
        It 'allows normal embedded code and archive payloads for human review' {
            $data = $safeRecording | ConvertFrom-Json -AsHashtable
            $entry = @($data.Values)[0]
            $entry.Response.Content = '{"zipFile":"fixture-encoded-data","code":"fixture code"}'
            $entry.Request.Content = 'Zml4dHVyZQ=='
            $entry.Request.isContentBase64 = $true
            Set-Content (Join-Path $artifactTest 'Get-AzEdgeAction.Recording.json') ($data | ConvertTo-Json -Depth 20)
            Copy-EdgeActionRecordingsForReview $before $resultsPath
            (Get-FileHash (Join-Path $sourceTest 'Get-AzEdgeAction.Recording.json')).Hash |
                Should -Be (Get-FileHash (Join-Path $artifactTest 'Get-AzEdgeAction.Recording.json')).Hash
        }
        It 'rejects incompatible metadata for a partial recording set before any copies' {
            Set-Content (Join-Path $artifactTest 'env.json') ($metadata.Replace('000000000001', '000000000003'))
            { Copy-EdgeActionRecordingsForReview $before $resultsPath } | Should -Throw 'outside this handoff'
            (Get-Content (Join-Path $sourceTest 'Get-AzEdgeAction.Recording.json') -Raw).Trim() | Should -Be '{}'
        }
        It 'preserves a source recording edited during the run' {
            Set-Content (Join-Path $sourceTest 'Get-AzEdgeAction.Recording.json') '{"user":"edit"}'
            { Copy-EdgeActionRecordingsForReview $before $resultsPath } | Should -Throw 'changed during the run'
            (Get-Content (Join-Path $sourceTest 'Get-AzEdgeAction.Recording.json') -Raw).Trim() | Should -Be '{"user":"edit"}'
        }
        It 'rejects unsupported env metadata rather than copying credentials' {
            Set-Content (Join-Path $artifactTest 'env.json') '{"credential":"fixture-secret"}'
            { Copy-EdgeActionRecordingsForReview $before $resultsPath } | Should -Throw 'unsupported metadata'
            (Get-Content (Join-Path $sourceTest 'Get-AzEdgeAction.Recording.json') -Raw).Trim() | Should -Be '{}'
        }
        It 'surfaces copy errors without reporting completion' {
            $script:blockedCopyDestination = Join-Path $sourceTest 'Get-AzEdgeAction.Recording.json'
            Mock Copy-Item { throw 'fixture access denied' } -ParameterFilter { $Destination -eq $script:blockedCopyDestination }
            { Copy-EdgeActionRecordingsForReview $before $resultsPath } | Should -Throw 'Recording handoff failed'
        }
        It 'writes nothing when any selected recording contains a detected credential' {
            Set-Content $resultsPath '<test-results><test-case name="Get-AzEdgeAction.Get" /><test-case name="New-AzEdgeAction.Create" /></test-results>'
            Set-Content (Join-Path $artifactTest 'New-AzEdgeAction.Recording.json') ($safeRecording.Replace('[Filtered]', 'Bearer fixture-secret'))
            { Copy-EdgeActionRecordingsForReview $before $resultsPath } | Should -Throw 'handoff blocked'
            foreach ($name in 'Get-AzEdgeAction.Recording.json', 'New-AzEdgeAction.Recording.json') {
                (Get-Content (Join-Path $sourceTest $name) -Raw).Trim() | Should -Be '{}'
            }
        }
        It 'rejects <Kind> without copying or printing sensitive data' -TestCases @(
            @{ Kind = 'unfiltered authorization'; Bad = '{"Authorization":["Bearer fixture-secret"]}' }
            @{ Kind = 'cookie'; Bad = '{"Cookie":["fixture-secret"]}' }
            @{ Kind = 'API key'; Bad = '{"x-api-key":["fixture-secret"]}' }
        ) {
            param($Bad)
            $unsafe = $safeRecording.Replace('{"Authorization":["[Filtered]"]}', $Bad)
            Set-Content (Join-Path $artifactTest 'Get-AzEdgeAction.Recording.json') $unsafe
            $message = try { Copy-EdgeActionRecordingsForReview $before $resultsPath } catch { $_.Exception.Message }
            $message | Should -Match 'handoff blocked'
            $message | Should -Not -Match 'fixture-secret'
            (Get-Content (Join-Path $sourceTest 'Get-AzEdgeAction.Recording.json') -Raw).Trim() | Should -Be '{}'
        }
        It 'rejects <Kind> in recorded bodies or URLs' -TestCases @(
            @{ Kind = 'token body'; Text = '{"access_token":"fixture-secret"}' }
            @{ Kind = 'signed URL'; Text = '{"url":"https://example.invalid/?sig=fixture-secret"}' }
        ) {
            param($Text)
            $data = $safeRecording | ConvertFrom-Json -AsHashtable
            $entry = @($data.Values)[0]
            $entry.Response.Content = $Text
            { Assert-EdgeActionRecordingReviewInput ($data | ConvertTo-Json -Depth 20) 'fixture.json' } | Should -Throw 'handoff blocked'
        }
        It 'copies through the parent flow only after successful Record with real XML: <Outcome>' -TestCases @(
            @{ Outcome = 'Record passed'; Mode = 'Record'; ExitCode = 0; Failed = $false }
            @{ Outcome = 'nonzero child'; Mode = 'Record'; ExitCode = 1; Failed = $false }
            @{ Outcome = 'failed case'; Mode = 'Record'; ExitCode = 0; Failed = $true }
            @{ Outcome = 'Playback passed'; Mode = 'Playback'; ExitCode = 0; Failed = $false }
            @{ Outcome = 'Live passed'; Mode = 'Live'; ExitCode = 0; Failed = $false }
        ) {
            param($Mode, $ExitCode, $Failed)
            Set-Content (Join-Path $artifactTest 'Get-AzEdgeAction.Recording.json') '{}'
            Mock Get-EdgeActionTestConfig { @{ SubscriptionId = '00000000-0000-0000-0000-000000000001' } }
            Mock Invoke-EdgeActionTestChild {
                Set-Content (Join-Path $artifactTest 'Get-AzEdgeAction.Recording.json') $safeRecording
                $success = if ($Failed) { 'False' } else { 'True' }
                Set-Content $resultsPath "<test-results failures='0' errors='0'><test-case name='Get-AzEdgeAction.Get' executed='True' success='$success' /></test-results>"
                $ExitCode
            }
            if ($Failed -or $ExitCode) {
                { Invoke-EdgeActionTests @{ Mode = $Mode; AllowResourceChanges = $true } } | Should -Throw 'Scenario tests failed'
            } else {
                Invoke-EdgeActionTests @{ Mode = $Mode; AllowResourceChanges = $true }
            }
            if ($Mode -eq 'Record' -and -not $Failed -and -not $ExitCode) {
                (Get-FileHash (Join-Path $sourceTest 'Get-AzEdgeAction.Recording.json')).Hash |
                    Should -Be (Get-FileHash (Join-Path $artifactTest 'Get-AzEdgeAction.Recording.json')).Hash
            } else {
                (Get-Content (Join-Path $sourceTest 'Get-AzEdgeAction.Recording.json') -Raw).Trim() | Should -Be '{}'
            }
        }
    }

    Describe 'Fresh NUnit results' {
        BeforeEach {
            $resultPath = Join-Path $TestDrive 'result.xml'
            $started = [datetime]::UtcNow.AddSeconds(-2)
            '<test-results failures="0" errors="0"><test-case executed="True" success="True" /></test-results>' |
                Set-Content $resultPath
        }
        It 'accepts successful executed tests' {
            { Assert-EdgeActionResults $resultPath $started 0 } | Should -Not -Throw
        }
        It 'rejects missing or stale results' {
            { Assert-EdgeActionResults (Join-Path $TestDrive 'missing.xml') $started 0 } | Should -Throw 'Missing or stale'
            { Assert-EdgeActionResults $resultPath ([datetime]::UtcNow.AddHours(1)) 0 } | Should -Throw 'Missing or stale'
        }
        It 'identifies startup failures before missing results' {
            { Assert-EdgeActionResults (Join-Path $TestDrive 'missing.xml') $started 1 } |
                Should -Throw 'Scenario harness failed before producing fresh results (child exit 1)'
        }
        It 'rejects malformed XML or no executed tests' {
            '<invalid' | Set-Content $resultPath
            { Assert-EdgeActionResults $resultPath $started 0 } | Should -Throw
            '<test-results failures="0" errors="0" />' | Set-Content $resultPath
            { Assert-EdgeActionResults $resultPath $started 0 } | Should -Throw 'No executed'
            '<test-results failures="0" errors="0"><test-case executed="False" /></test-results>' | Set-Content $resultPath
            { Assert-EdgeActionResults $resultPath $started 0 } | Should -Throw 'No executed'
        }
        It 'rejects failed cases and suite errors despite zero process exit' {
            '<test-results failures="1" errors="0"><test-case executed="True" success="False" /></test-results>' | Set-Content $resultPath
            { Assert-EdgeActionResults $resultPath $started 0 } | Should -Throw 'Scenario tests failed'
            '<test-results failures="0" errors="1"><test-case executed="True" success="True" /></test-results>' | Set-Content $resultPath
            { Assert-EdgeActionResults $resultPath $started 0 } | Should -Throw 'Scenario tests failed'
        }
        It 'rejects a nonzero child exit despite passing results' {
            { Assert-EdgeActionResults $resultPath $started 7 } | Should -Throw 'child exit 7'
        }
        It 'returns a real child failure without signing in or running a harness' {
            $options = @{ Config = @{}; Mode = 'Record' }
            Invoke-EdgeActionTestChild $options 2>$null | Should -Not -Be 0
        }
    }
}

Describe 'Isolated runner integration with a local fixture harness' {
    BeforeEach {
        $fixture = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $scripts = Join-Path $fixture 'src' 'EdgeAction' 'tools' 'TestScripts'
        $source = Join-Path $fixture 'src' 'EdgeAction' 'EdgeAction.Autorest'
        $artifact = Join-Path $fixture 'artifacts' 'Debug' 'Az.EdgeAction' 'EdgeAction.Autorest'
        $accounts = Join-Path $fixture 'artifacts' 'Debug' 'Az.Accounts'
        $null = New-Item -ItemType Directory -Path $scripts, (Join-Path $source 'test'), (Join-Path $artifact 'test'), $accounts -Force
        foreach ($file in @('Test-EdgeAction.ps1', 'EdgeAction.TestRunner.psm1', 'TestSettings.psd1')) {
            Copy-Item (Join-Path $PSScriptRoot '..' $file) (Join-Path $scripts $file)
        }
        "@{ ModuleVersion = '1.0.0'; GUID = '00000000-0000-0000-0000-000000000001' }" |
            Set-Content (Join-Path $accounts 'Az.Accounts.psd1')
        $pester = (Join-Path (Get-Module Pester).ModuleBase 'Pester.psd1').Replace("'", "''")
        "@{ PesterPath = '$pester' }" | Set-Content (Join-Path $scripts 'TestSettings.local.psd1')
        $runner = Join-Path $scripts 'Test-EdgeAction.ps1'
        $harness = Join-Path $artifact 'test-module.ps1'
        $resultPath = Join-Path $artifact 'test' 'Az.EdgeAction-TestResults.xml'
        $pwsh = [Environment]::ProcessPath
    }
    It 'propagates noninteractive hosting and refuses missing Brazilus before support setup in <Mode>' -TestCases @(
        @{ Mode = 'Record' }
        @{ Mode = 'Live' }
    ) {
        param($Mode)
        "@{ ModuleVersion = '1.0.0'; RootModule = 'Az.Accounts.psm1' }" |
            Set-Content (Join-Path $accounts 'Az.Accounts.psd1')
        @'
function Get-AzEnvironment {
    param($Name)
    if (-not ([Environment]::GetCommandLineArgs() -match '^-NonI')) { throw 'Noninteractive flag was not propagated' }
    'verified' | Set-Content (Join-Path $PSScriptRoot 'preflight.txt')
}
function Add-AzEnvironment { throw 'Unexpected registration' }
function Connect-AzAccount { throw 'Unexpected login' }
Export-ModuleMember -Function Get-AzEnvironment, Add-AzEnvironment, Connect-AzAccount
'@ | Set-Content (Join-Path $accounts 'Az.Accounts.psm1')
        @"
@{
    PesterPath = '$pester'
    EnvironmentName = 'Brazilus'
    ResourceManagerUrl = 'https://brazilus.management.azure.com/'
    SubscriptionId = '00000000-0000-0000-0000-000000000001'
}
"@ | Set-Content (Join-Path $scripts 'TestSettings.local.psd1')
        "throw 'Unexpected harness invocation'" | Set-Content $harness
        "throw 'Unexpected support setup'" | Set-Content (Join-Path $artifact 'check-dependencies.ps1')
        $output = & $pwsh -NonInteractive -NoProfile -File $runner -Mode $Mode -AllowResourceChanges -Login 2>&1
        $LASTEXITCODE | Should -Not -Be 0
        ($output -join "`n") | Should -Match 'interactive confirmation is unavailable'
        Get-Content (Join-Path $accounts 'preflight.txt') | Should -Be 'verified'
        ($output -join "`n") | Should -Not -Match 'Unexpected |Starting Resources|Starting process-scoped login'
        Test-Path $resultPath | Should -Be $false
    }
    It 'resolves fixture settings and artifacts from <Location> with <Configuration> config' -TestCases @(
        @{ Location = 'root'; Configuration = 'discovered' }
        @{ Location = 'module'; Configuration = 'discovered' }
        @{ Location = 'root'; Configuration = 'explicit relative' }
        @{ Location = 'module'; Configuration = 'explicit relative' }
    ) {
        param($Location, $Configuration)
        $directory = if ($Location -eq 'root') { $fixture } else { $source }
        $relativeRunner = if ($Location -eq 'root') {
            Join-Path '.' 'src' 'EdgeAction' 'tools' 'TestScripts' 'Test-EdgeAction.ps1'
        } else {
            Join-Path '..' 'tools' 'TestScripts' 'Test-EdgeAction.ps1'
        }
        $arguments = @()
        if ($Configuration -eq 'explicit relative') {
            Move-Item (Join-Path $scripts 'TestSettings.local.psd1') (Join-Path $directory 'selected.psd1')
            "@{ Unknown = 'must not read the sibling override' }" |
                Set-Content (Join-Path $scripts 'TestSettings.local.psd1')
            $arguments = @('-ConfigPath', (Join-Path '.' 'selected.psd1'))
        } else {
            "@{ Unknown = 'must not discover settings in the caller directory' }" |
                Set-Content (Join-Path $directory 'TestSettings.local.psd1')
        }
        @'
param([switch]$NotIsolated, [switch]$Playback)
if (-not $NotIsolated -or -not $Playback) { exit 8 }
if ((Get-Location).Path -ne $PSScriptRoot) { throw 'Harness must run from the artifact directory' }
'<test-results failures="0" errors="0"><test-case executed="True" success="True" /></test-results>' |
    Set-Content (Join-Path $PSScriptRoot 'test' 'Az.EdgeAction-TestResults.xml')
exit 0
'@ | Set-Content $harness
        Push-Location $directory
        try {
            & $pwsh -NoProfile -File $relativeRunner @arguments | Out-Null
            $LASTEXITCODE | Should -Be 0
            (Get-Location).Path | Should -Be $directory
        } finally {
            Pop-Location
        }
        Test-Path $resultPath | Should -Be $true
        Test-Path (Join-Path $fixture 'artifacts' 'edgeaction-test-runs') | Should -Be $false
    }
    It 'ignores stale caller root variables when invoked from the module directory' {
        $wrongRoot = Join-Path $fixture 'other-checkout'
        $null = New-Item -ItemType Directory -Path $wrongRoot
        @'
param([switch]$NotIsolated, [switch]$Playback)
if (-not $NotIsolated -or -not $Playback) { exit 8 }
'<test-results failures="0" errors="0"><test-case executed="True" success="True" /></test-results>' |
    Set-Content (Join-Path $PSScriptRoot 'test' 'Az.EdgeAction-TestResults.xml')
exit 0
'@ | Set-Content $harness
        $command = @'
$ErrorActionPreference = 'Stop'
$repoRoot = '__WRONG__'
$source = '__WRONG__'
$env:RepoRoot = '__WRONG__'
$env:REPO_ROOT = '__WRONG__'
$before = (Get-Location).Path
& (Join-Path '..' 'tools' 'TestScripts' 'Test-EdgeAction.ps1')
if ((Get-Location).Path -ne $before -or $repoRoot -ne '__WRONG__') { exit 9 }
'@
        Push-Location $source
        try {
            & $pwsh -NoProfile -Command $command.Replace('__WRONG__', $wrongRoot.Replace("'", "''")) | Out-Null
            $LASTEXITCODE | Should -Be 0
            (Get-Location).Path | Should -Be $source
        } finally {
            Pop-Location
        }
        Test-Path $resultPath | Should -Be $true
        Test-Path (Join-Path $wrongRoot 'artifacts') | Should -Be $false
        Test-Path (Join-Path $fixture 'artifacts' 'edgeaction-test-runs') | Should -Be $false
    }
    It 'loads only artifact assemblies when the caller source directory contains another DLL' {
        $sourceBin = Join-Path $source 'bin'
        $artifactBin = Join-Path $artifact 'bin'
        $null = New-Item $sourceBin, $artifactBin -ItemType Directory -Force
        $typeSuffix = [guid]::NewGuid().ToString('N')
        Add-Type -TypeDefinition "public class Source$typeSuffix { }" -OutputAssembly (Join-Path $sourceBin 'Fixture.private.dll')
        Add-Type -TypeDefinition "public class Artifact$typeSuffix { }" -OutputAssembly (Join-Path $artifactBin 'Fixture.private.dll')
        "@{ RootModule='Fixture.psm1'; ModuleVersion='1.0.0'; RequiredAssemblies='./bin/Fixture.private.dll' }" |
            Set-Content (Join-Path $artifact 'Fixture.psd1')
        '$null = Import-Module (Join-Path $PSScriptRoot ''bin'' ''Fixture.private.dll'')' |
            Set-Content (Join-Path $artifact 'Fixture.psm1')
        @'
Import-Module (Join-Path $PSScriptRoot 'Fixture.psd1')
$loaded = @([AppDomain]::CurrentDomain.GetAssemblies() | Where-Object { $_.Location -like '*Fixture.private.dll' })
if ($loaded.Count -ne 1 -or $loaded[0].Location -ne (Join-Path $PSScriptRoot 'bin' 'Fixture.private.dll')) {
    throw 'A source assembly was loaded instead of only the artifact assembly'
}
'<test-results failures="0" errors="0"><test-case executed="True" success="True" /></test-results>' |
    Set-Content (Join-Path $PSScriptRoot 'test' 'Az.EdgeAction-TestResults.xml')
'@ | Set-Content $harness
        Push-Location $source
        try {
            & $pwsh -NoProfile -File $runner | Out-Null
            $LASTEXITCODE | Should -Be 0
            (Get-Location).Path | Should -Be $source
        } finally { Pop-Location }
        Test-Path $resultPath | Should -Be $true
    }
    It 'contains Pester EnableExit and leaves recordings in the harness directory without backups' {
        @'
param([switch]$NotIsolated, [switch]$Playback, [string[]]$TestName)
if (-not $NotIsolated -or -not $Playback -or $TestName.Count -ne 2) { exit 8 }
# Match the upstream dependency check, path adjustment and unqualified import.
if (-not (Get-Module -ListAvailable Pester | Where-Object Version -EQ '4.10.1')) { throw 'Dependency helper would download Pester' }
$env:PSModulePath = (Join-Path $PSScriptRoot 'generated' 'modules') + [IO.Path]::PathSeparator + $env:PSModulePath
Import-Module -Name Pester
if ((Get-Command Invoke-Pester).Module.Version -ne [version]'4.10.1') { throw 'Wrong Pester loaded by name' }
(Get-Command Invoke-Pester).Module.ModuleBase | Set-Content (Join-Path $PSScriptRoot 'test' 'pester-path.txt')
'fixture recording' | Set-Content (Join-Path $PSScriptRoot 'test' 'fixture.Recording.json')
Invoke-Pester -Script (Join-Path $PSScriptRoot 'test' 'fixture.Tests.ps1') -EnableExit -OutputFile (Join-Path $PSScriptRoot 'test' 'Az.EdgeAction-TestResults.xml')
'@ | Set-Content $harness
        "Describe 'fixture' { It 'passes' { 1 | Should -Be 1 } }" |
            Set-Content (Join-Path $artifact 'test' 'fixture.Tests.ps1')
        # Use a command to pass an actual array through the public wrapper.
        $command = "& '$($runner.Replace("'", "''"))' -TestName 'one','two'"
        $messages = @(& $pwsh -NoProfile -Command $command)
        $LASTEXITCODE | Should -Be 0
        $markers = @($messages | Where-Object { $_ -match '^(Starting|Completed) ' })
        ($markers -join '|') | Should -Be (@(
            'Starting test configuration validation.'
            'Completed test configuration validation.'
            'Starting test dependency validation and loading.'
            'Completed test dependency validation and loading.'
            'Starting Playback scenario harness.'
            'Starting fresh test-result validation.'
            'Completed fresh test-result validation.'
            'Completed Playback scenario harness; tests passed.'
        ) -join '|')
        Test-Path $resultPath | Should -Be $true
        Get-Content (Join-Path $artifact 'test' 'fixture.Recording.json') | Should -Be 'fixture recording'
        Test-Path (Join-Path $fixture 'artifacts' 'edgeaction-test-runs') | Should -Be $false
        $stagedPester = Get-Content (Join-Path $artifact 'test' 'pester-path.txt')
        Test-Path (Split-Path $stagedPester) | Should -Be $false
    }
    It 'imports Pester by name with newer installed versions using <Selection>' -TestCases @(
        @{ Selection = 'discovery' }
        @{ Selection = 'explicit manifest' }
    ) {
        param($Selection)
        $moduleRoot = Join-Path $fixture 'installed'
        $pesterRoot = Join-Path $moduleRoot 'Pester'
        $null = New-Item $pesterRoot -ItemType Directory -Force
        Copy-Item (Split-Path $pester) (Join-Path $pesterRoot '4.10.1') -Recurse
        $newer = Join-Path $pesterRoot '99.0.0'
        $null = New-Item $newer -ItemType Directory
        "@{ ModuleVersion='99.0.0'; RootModule='Pester.psm1' }" | Set-Content (Join-Path $newer 'Pester.psd1')
        "throw 'Newer Pester must not be imported'" | Set-Content (Join-Path $newer 'Pester.psm1')
        $configPath = Join-Path $scripts 'TestSettings.local.psd1'
        if ($Selection -eq 'discovery') {
            '@{}' | Set-Content $configPath
        } else {
            $selected = (Join-Path $pesterRoot '4.10.1' 'Pester.psd1').Replace("'", "''")
            "@{ PesterPath='$selected' }" | Set-Content $configPath
        }
        @'
if (@(Get-Module -ListAvailable Pester).Count -ne 1) { throw 'Pester discovery is not isolated' }
Remove-Module Pester -Force
Import-Module -Name Pester
if ((Get-Command Invoke-Pester).Module.Version -ne [version]'4.10.1') { throw 'Wrong version imported by name' }
(Get-Command Invoke-Pester).Module.ModuleBase | Set-Content (Join-Path $PSScriptRoot 'test' 'pester-path.txt')
'<test-results failures="0" errors="0"><test-case executed="True" success="True" /></test-results>' |
    Set-Content (Join-Path $PSScriptRoot 'test' 'Az.EdgeAction-TestResults.xml')
exit 0
'@ | Set-Content $harness
        $oldModulePath = $env:PSModulePath
        try {
            $env:PSModulePath = $moduleRoot + [IO.Path]::PathSeparator + $env:PSModulePath
            & $pwsh -NoProfile -File $runner | Out-Null
            $LASTEXITCODE | Should -Be 0
        } finally { $env:PSModulePath = $oldModulePath }
        Test-Path (Join-Path $newer 'Pester.psd1') | Should -Be $true
        $stagedPester = Get-Content (Join-Path $artifact 'test' 'pester-path.txt')
        Test-Path (Split-Path $stagedPester) | Should -Be $false
    }
    It 'rejects fresh failures with a zero exit without backing up results' {
        '<previous />' | Set-Content $resultPath
        @'
'<test-results failures="1" errors="0"><test-case executed="True" success="False" /></test-results>' |
    Set-Content (Join-Path $PSScriptRoot 'test' 'Az.EdgeAction-TestResults.xml')
exit 0
'@ | Set-Content $harness
        $messages = @(& $pwsh -NoProfile -File $runner 2>$null)
        $LASTEXITCODE | Should -Not -Be 0
        ($messages -join "`n") | Should -Match 'Starting fresh test-result validation\.'
        ($messages -join "`n") | Should -Not -Match 'Completed fresh test-result validation\.|Completed Playback scenario harness'
        ([xml](Get-Content $resultPath -Raw)).'test-results'.failures | Should -Be '1'
        Test-Path (Join-Path $fixture 'artifacts' 'edgeaction-test-runs') | Should -Be $false
    }
    It 'leaves existing recordings and old snapshot directories untouched after a child failure' {
        $recording = Join-Path $artifact 'test' 'existing.Recording.json'
        Set-Content $recording 'existing recording'
        $oldSnapshot = Join-Path $fixture 'artifacts' 'edgeaction-test-runs' 'existing'
        $null = New-Item $oldSnapshot -ItemType Directory -Force
        $oldFile = Join-Path $oldSnapshot 'old.Recording.json'
        Set-Content $oldFile 'old snapshot'
        $recordingHash = (Get-FileHash $recording).Hash
        $oldHash = (Get-FileHash $oldFile).Hash
        @'
(Get-Command Invoke-Pester).Module.ModuleBase | Set-Content (Join-Path $PSScriptRoot 'test' 'pester-path.txt')
'partial recording' | Set-Content (Join-Path $PSScriptRoot 'test' 'partial.Recording.json')
exit 7
'@ | Set-Content $harness
        & $pwsh -NoProfile -File $runner 2>$null | Out-Null
        $LASTEXITCODE | Should -Not -Be 0
        (Get-FileHash $recording).Hash | Should -Be $recordingHash
        (Get-FileHash $oldFile).Hash | Should -Be $oldHash
        Get-Content (Join-Path $artifact 'test' 'partial.Recording.json') | Should -Be 'partial recording'
        @(Get-ChildItem (Split-Path $oldSnapshot) -Directory).Count | Should -Be 1
        $stagedPester = Get-Content (Join-Path $artifact 'test' 'pester-path.txt')
        Test-Path (Split-Path $stagedPester) | Should -Be $false
    }
    It 'does not accept an old XML when the child produces no result' {
        '<test-results failures="0" errors="0"><test-case executed="True" success="True" /></test-results>' | Set-Content $resultPath
        'exit 0' | Set-Content $harness
        & $pwsh -NoProfile -File $runner 2>$null | Out-Null
        $LASTEXITCODE | Should -Not -Be 0
        Test-Path $resultPath | Should -Be $false
    }
    It 'accepts an explicit config outside the script directory' {
        $selectedConfig = Join-Path $fixture 'artifacts' 'selected-test-settings.psd1'
        Move-Item (Join-Path $scripts 'TestSettings.local.psd1') $selectedConfig
        @'
'<test-results failures="0" errors="0"><test-case executed="True" success="True" /></test-results>' |
    Set-Content (Join-Path $PSScriptRoot 'test' 'Az.EdgeAction-TestResults.xml')
exit 0
'@ | Set-Content $harness
        & $pwsh -NoProfile -File $runner -ConfigPath $selectedConfig | Out-Null
        $LASTEXITCODE | Should -Be 0
        Test-Path $resultPath | Should -Be $true
    }
}

Describe 'Real Accounts context types without authentication' {
    $accounts = Join-Path $PSScriptRoot '..' '..' '..' '..' '..' 'artifacts' 'Debug' 'Az.Accounts' 'Az.Accounts.psd1'
    It 'validates concrete Accounts environment properties and reports missing endpoints' -Skip:(-not (Test-Path $accounts)) {
        $runnerModule = (Resolve-Path (Join-Path $PSScriptRoot '..' 'EdgeAction.TestRunner.psm1')).Path
        $command = @'
$ErrorActionPreference = 'Stop'
Import-Module '__ACCOUNTS__'
$runner = Import-Module '__RUNNER__' -PassThru
$environment = [Microsoft.Azure.Commands.Profile.Models.PSAzureEnvironment]::new()
$environment.Name = 'Brazilus'
$environment.ResourceManagerUrl = 'https://brazilus.management.azure.com/'
$environment.ActiveDirectoryServiceEndpointResourceId = 'https://management.core.windows.net/'
$context = [Microsoft.Azure.Commands.Profile.Models.Core.PSAzureContext]::new()
$context.Environment = $environment
$context.Subscription = [Microsoft.Azure.Commands.Profile.Models.PSAzureSubscription]::new()
$context.Subscription.Id = '00000000-0000-0000-0000-000000000001'
$config = @{
    SubscriptionId = $context.Subscription.Id
    EnvironmentName = 'Brazilus'
    ResourceManagerUrl = 'https://brazilus.management.azure.com/'
    Audience = 'https://management.core.windows.net/'
}
& $runner { param($Config, $Context) Assert-EdgeActionContext $Config $Context } $config $context
$environment.ResourceManagerUrl = $null
$message = try {
    & $runner { param($Config, $Context) Assert-EdgeActionContext $Config $Context } $config $context
} catch { $_.Exception.Message }
if ($message -notlike "*Azure context environment does not match: ResourceManagerUrl expected*actual '<missing>'*") {
    throw "Unexpected concrete-type diagnostic: $message"
}
$message = try {
    & $runner { param($Config) Assert-EdgeActionEnvironmentMatch $Config $null 'Registered Azure environment' } $config
} catch { $_.Exception.Message }
if ($message -notlike "*Registered Azure environment*is missing*fresh pwsh -NoProfile*") {
    throw "Unexpected registration diagnostic: $message"
}
'Real Accounts type checks passed.'
'@
        $command = $command.Replace('__ACCOUNTS__', (Resolve-Path $accounts).Path.Replace("'", "''")).Replace('__RUNNER__', $runnerModule.Replace("'", "''"))
        $output = & ([Environment]::ProcessPath) -NoProfile -Command $command
        $LASTEXITCODE | Should -Be 0
        ($output -join "`n") | Should -Match 'Real Accounts type checks passed'
    }
}
