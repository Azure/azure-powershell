$helperPath = Join-Path $PSScriptRoot '..\custom\Get-AzServiceBusReadParameters.ps1'
$helperSource = Get-Content -Path $helperPath -Raw
$helperSource = $helperSource -replace '(?m)^\s*\[Microsoft\.Azure\.PowerShell\.Cmdlets\.ServiceBus\.DoNotExportAttribute\(\)\]\r?\n', ''
. ([scriptblock]::Create($helperSource))

function Get-AzServiceBusReadTestResource {
    [CmdletBinding()]
    param(
        [Alias('ResourceName')]
        [string] $Name,
        [object] $DefaultProfile
    )

    $script:serviceBusReadParameters = @{} + $PSBoundParameters
}

function Set-AzServiceBusReadTestResource {
    [CmdletBinding()]
    param(
        [string] $Name,
        [object] $DefaultProfile,
        [switch] $AcquirePolicyToken,
        [string] $ChangeReference,
        [string] $SyntheticWriteOnly
    )

    $script:serviceBusWriteParameters = @{} + $PSBoundParameters
}

Set-Alias -Name Get-AzServiceBusReadTestAlias -Value Get-AzServiceBusReadTestResource

Describe 'ServiceBus read parameter forwarding' {
    It 'filters write-only parameters using read command metadata without changing write parameters' {
        $writeParameters = @{
            Name = 'queue'
            DefaultProfile = 'profile'
            ErrorAction = 'Stop'
            AcquirePolicyToken = $true
            ChangeReference = 'change-123'
            SyntheticWriteOnly = 'future-value'
        }

        $readParameters = Get-AzServiceBusReadParameters -CommandName 'Get-AzServiceBusReadTestAlias' -BoundParameters $writeParameters
        Get-AzServiceBusReadTestResource @readParameters
        Set-AzServiceBusReadTestResource @writeParameters

        $script:serviceBusReadParameters.Name | Should Be 'queue'
        $script:serviceBusReadParameters.DefaultProfile | Should Be 'profile'
        $script:serviceBusReadParameters.ErrorAction | Should Be 'Stop'
        $script:serviceBusReadParameters.ContainsKey('AcquirePolicyToken') | Should Be $false
        $script:serviceBusReadParameters.ContainsKey('ChangeReference') | Should Be $false
        $script:serviceBusReadParameters.ContainsKey('SyntheticWriteOnly') | Should Be $false
        $script:serviceBusWriteParameters.AcquirePolicyToken | Should Be $true
        $script:serviceBusWriteParameters.ChangeReference | Should Be 'change-123'
        $script:serviceBusWriteParameters.SyntheticWriteOnly | Should Be 'future-value'
    }

    It 'recognizes read parameter aliases' {
        $readParameters = Get-AzServiceBusReadParameters -CommandName 'Get-AzServiceBusReadTestResource' -BoundParameters @{ ResourceName = 'queue' }

        $readParameters.ResourceName | Should Be 'queue'
    }

    It 'uses read parameters without replacing the original bound parameters in every affected wrapper' {
        $wrappers = @(
            'Approve-AzServiceBusPrivateEndpointConnection.ps1',
            'Deny-AzServiceBusPrivateEndpointConnection.ps1',
            'Set-AzServiceBusAuthorizationRule.ps1',
            'Set-AzServiceBusGeoDRConfigurationBreakPair.ps1',
            'Set-AzServiceBusGeoDRConfigurationFailOver.ps1',
            'Set-AzServiceBusNamespace.ps1',
            'Set-AzServiceBusNetworkRuleSet.ps1',
            'Set-AzServiceBusQueue.ps1',
            'Set-AzServiceBusRule.ps1',
            'Set-AzServiceBusSubscription.ps1',
            'Set-AzServiceBusTopic.ps1'
        )

        foreach ($wrapper in $wrappers) {
            $source = Get-Content -Path (Join-Path $PSScriptRoot "..\custom\$wrapper") -Raw
            $source | Should Not Match '\$targetParameters'
            $source | Should Match 'Get-AzServiceBusReadParameters\s+-CommandName\s+''[^'']+''\s+-BoundParameters\s+\$PSBoundParameters'
            $source | Should Match '@readParameters'
            $source | Should Match '@PSBoundParameters'
        }
    }

    It 'keeps exact expanded and via-identity read variants for authorization rules' {
        $source = Get-Content -Path (Join-Path $PSScriptRoot '..\custom\Set-AzServiceBusAuthorizationRule.ps1') -Raw

        $source | Should Match "CommandName 'Az\.ServiceBus\.private\\Get-AzServiceBusQueueAuthorizationRule_Get'"
        $source | Should Match "CommandName 'Az\.ServiceBus\.private\\Get-AzServiceBusTopicAuthorizationRule_GetViaIdentity'"
        $source | Should Match "CommandName 'Az\.ServiceBus\.private\\Get-AzServiceBusNamespaceAuthorizationRule_GetViaIdentity'"
    }

    It 'packages the internal helper and triggers regeneration' {
        $customPath = Join-Path $PSScriptRoot '..\custom'
        $helperPath = Join-Path $customPath 'Get-AzServiceBusReadParameters.ps1'
        $moduleSource = Get-Content -Path (Join-Path $customPath 'Az.ServiceBus.custom.psm1') -Raw
        $helperSource = Get-Content -Path $helperPath -Raw
        $generation = Get-Content -Path (Join-Path $PSScriptRoot '..\generate-info.json') -Raw | ConvertFrom-Json

        Test-Path -Path $helperPath | Should Be $true
        $helperSource | Should Match '\[Microsoft\.Azure\.PowerShell\.Cmdlets\.ServiceBus\.DoNotExportAttribute\(\)\]'
        $moduleSource | Should Match "Get-ChildItem\s+-Path\s+\`$PSScriptRoot\s+-Recurse\s+-Include\s+'\*\.ps1'"
        { [guid]::Parse($generation.generate_Id) } | Should Not Throw
        $generation.generate_Id | Should Not Be 'd42664e3-3ae4-4daf-a410-fba6f9958c4e'
    }
}
