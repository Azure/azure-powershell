Describe 'TestEnvironment.Unit' {
    function Remove-AzResourceGroup {
        [CmdletBinding()]
        param([string]$Name, [switch]$Force)

        throw 'Remove-AzResourceGroup must be mocked in environment unit tests.'
    }

    BeforeEach {
        $script:savedDefaults = $PSDefaultParameterValues
        $TestMode = 'record'
        $UsePreviousConfigForRecord = $false
        . (Join-Path $PSScriptRoot 'utils.ps1')
        Mock Remove-AzResourceGroup {}
    }

    AfterEach {
        $PSDefaultParameterValues = $script:savedDefaults
    }

    It 'Resolves the existing Classic profile without changing the AFD resource group' {
        Mock Get-Content {
            '{"SubscriptionId":"offline","ResourceGroupName":"afd-tests","ClassicCdnProfileName":"old","ClassicCdnProfileResourceId":"/subscriptions/offline/resourceGroups/classic-existing/providers/Microsoft.Cdn/profiles/existing","EdgeActionResourceId":"/subscriptions/offline/resourceGroups/edge-existing/providers/Microsoft.Cdn/edgeActions/existing"}'
        }
        . (Join-Path $PSScriptRoot 'loadCdnEnv.ps1')
        $env.ClassicCdnProfileName | Should -Be 'existing'
        $env.ClassicCdnResourceGroupName | Should -Be 'classic-existing'
        $env.ResourceGroupName | Should -Be 'afd-tests'
        $env.EdgeActionResourceId | Should -Be '/subscriptions/offline/resourceGroups/edge-existing/providers/Microsoft.Cdn/edgeActions/existing'
    }

    It 'Rejects a Classic profile in another subscription' {
        Mock Get-Content {
            '{"SubscriptionId":"offline","ResourceGroupName":"afd-tests","ClassicCdnProfileResourceId":"/subscriptions/other/resourceGroups/classic-existing/providers/Microsoft.Cdn/profiles/existing"}'
        }
        { . (Join-Path $PSScriptRoot 'loadCdnEnv.ps1') } | Should -Throw 'ClassicCdnProfileResourceId must belong to the configured test subscription.'
    }

    It 'Rejects a resource ID that does not identify a CDN profile' {
        Mock Get-Content {
            '{"SubscriptionId":"offline","ResourceGroupName":"afd-tests","ClassicCdnProfileResourceId":"/subscriptions/offline/resourceGroups/classic-existing/providers/Microsoft.Cdn/edgeActions/existing"}'
        }
        { . (Join-Path $PSScriptRoot 'loadCdnEnv.ps1') } | Should -Throw 'ClassicCdnProfileResourceId must identify an existing Microsoft.Cdn/profiles resource.'
    }

    It 'Uses the configured resource group when no existing Classic profile ID is provided' {
        Mock Get-Content {
            '{"SubscriptionId":"offline","ResourceGroupName":"shared-tests","ClassicCdnProfileName":"classic-tests"}'
        }
        . (Join-Path $PSScriptRoot 'loadCdnEnv.ps1')
        $env.ClassicCdnResourceGroupName | Should -Be 'shared-tests'
        $env.ClassicCdnProfileName | Should -Be 'classic-tests'
    }

    It 'Preserves a resource group reused by setup' {
        $env.ResourceGroupName = 'existing-tests'
        cleanupEnv
        Assert-MockCalled Remove-AzResourceGroup -Times 0 -Exactly
    }

    It 'Never deletes the configured Classic profile resource group' {
        $script:cdnTestResourceGroupCreated = $true
        $env.ResourceGroupName = 'classic-existing'
        $env.ClassicCdnResourceGroupName = 'classic-existing'
        cleanupEnv
        Assert-MockCalled Remove-AzResourceGroup -Times 0 -Exactly
    }

    It 'Deletes a separate test resource group created by this setup' {
        $script:cdnTestResourceGroupCreated = $true
        $env.ResourceGroupName = 'new-tests'
        $env.ClassicCdnResourceGroupName = 'classic-existing'
        cleanupEnv
        Assert-MockCalled Remove-AzResourceGroup -Times 1 -Exactly -ParameterFilter {
            $Name -eq 'new-tests' -and $Force
        }
    }
}

Describe 'TestEnvironmentConfiguration.Unit' {
    It 'Selects <ExpectedConfigurationFile> for <Scenario>' -TestCases @(
        @{ Scenario = 'fresh Live'; InitialTestMode = $null; LiveSwitch = $true; RecordSwitch = $false; UsePreviousConfigForRecord = $false; ExpectedConfigurationFile = 'localEnv.json' }
        @{ Scenario = 'fresh Record'; InitialTestMode = $null; LiveSwitch = $false; RecordSwitch = $true; UsePreviousConfigForRecord = $false; ExpectedConfigurationFile = 'env.json' }
        @{ Scenario = 'default Playback'; InitialTestMode = $null; LiveSwitch = $false; RecordSwitch = $false; UsePreviousConfigForRecord = $false; ExpectedConfigurationFile = 'env.json' }
        @{ Scenario = 'Record overriding Live'; InitialTestMode = $null; LiveSwitch = $true; RecordSwitch = $true; UsePreviousConfigForRecord = $false; ExpectedConfigurationFile = 'env.json' }
        @{ Scenario = 'initialized Live mode'; InitialTestMode = 'live'; LiveSwitch = $false; RecordSwitch = $false; UsePreviousConfigForRecord = $false; ExpectedConfigurationFile = 'localEnv.json' }
        @{ Scenario = 'Live reusing configuration'; InitialTestMode = $null; LiveSwitch = $true; RecordSwitch = $false; UsePreviousConfigForRecord = $true; ExpectedConfigurationFile = 'localEnv.json' }
    ) {
        param($InitialTestMode, $LiveSwitch, $RecordSwitch, $UsePreviousConfigForRecord, $ExpectedConfigurationFile)

        # The dot-sourced utility inherits the runner's mode and switches.
        Set-Variable -Name TestMode -Value $InitialTestMode
        Set-Variable -Name Live -Value ([switch]$LiveSwitch)
        Set-Variable -Name Record -Value ([switch]$RecordSwitch)
        Mock Test-Path { $true } -ParameterFilter {
            [System.IO.Path]::GetFileName($Path) -in @('env.json', 'localEnv.json')
        }
        Mock Get-Content {
            $fileName = [System.IO.Path]::GetFileName($Path)
            @{
                ClassicCdnProfileResourceId = 'classic-' + $fileName
                EdgeActionResourceId = 'edge-' + $fileName
                ResourceGroupName = 'previous-tests'
            } | ConvertTo-Json
        } -ParameterFilter {
            [System.IO.Path]::GetFileName($Path) -in @('env.json', 'localEnv.json')
        }

        . (Join-Path $PSScriptRoot 'utils.ps1')

        $env.ClassicCdnProfileResourceId | Should -Be ('classic-' + $ExpectedConfigurationFile)
        $env.EdgeActionResourceId | Should -Be ('edge-' + $ExpectedConfigurationFile)
        $env.ContainsKey('ResourceGroupName') | Should -Be $UsePreviousConfigForRecord
    }
}
