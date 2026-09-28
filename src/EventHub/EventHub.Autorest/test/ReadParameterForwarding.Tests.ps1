$helperPath = Join-Path $PSScriptRoot '..\custom\Get-AzEventHubReadParameters.ps1'
$helperSource = Get-Content -Path $helperPath -Raw
$helperSource = $helperSource -replace '(?m)^\s*\[Microsoft\.Azure\.PowerShell\.Cmdlets\.EventHub\.DoNotExportAttribute\(\)\]\r?\n', ''
. ([scriptblock]::Create($helperSource))

function Get-AzEventHubReadTestResource {
    [CmdletBinding()]
    param(
        [Alias('ResourceName')]
        [string] $Name,
        [object] $DefaultProfile
    )

    $script:eventHubReadParameters = @{} + $PSBoundParameters
}

function Set-AzEventHubReadTestResource {
    [CmdletBinding()]
    param(
        [string] $Name,
        [object] $DefaultProfile,
        [switch] $AcquirePolicyToken,
        [string] $ChangeReference,
        [string] $SyntheticWriteOnly
    )

    $script:eventHubWriteParameters = @{} + $PSBoundParameters
}

Set-Alias -Name Get-AzEventHubReadTestAlias -Value Get-AzEventHubReadTestResource

Describe 'EventHub read parameter forwarding' {
    It 'filters write-only parameters using read command metadata without changing target parameters' {
        $targetParameters = @{
            Name = 'eventhub'
            DefaultProfile = 'profile'
            ErrorAction = 'Stop'
            AcquirePolicyToken = $true
            ChangeReference = 'change-123'
            SyntheticWriteOnly = 'future-value'
        }

        $readParameters = Get-AzEventHubReadParameters -CommandName 'Get-AzEventHubReadTestAlias' -BoundParameters $targetParameters
        Get-AzEventHubReadTestResource @readParameters
        Set-AzEventHubReadTestResource @targetParameters

        $script:eventHubReadParameters.Name | Should Be 'eventhub'
        $script:eventHubReadParameters.DefaultProfile | Should Be 'profile'
        $script:eventHubReadParameters.ErrorAction | Should Be 'Stop'
        $script:eventHubReadParameters.ContainsKey('AcquirePolicyToken') | Should Be $false
        $script:eventHubReadParameters.ContainsKey('ChangeReference') | Should Be $false
        $script:eventHubReadParameters.ContainsKey('SyntheticWriteOnly') | Should Be $false
        $script:eventHubWriteParameters.AcquirePolicyToken | Should Be $true
        $script:eventHubWriteParameters.ChangeReference | Should Be 'change-123'
        $script:eventHubWriteParameters.SyntheticWriteOnly | Should Be 'future-value'
    }

    It 'recognizes read parameter aliases' {
        $readParameters = Get-AzEventHubReadParameters -CommandName 'Get-AzEventHubReadTestResource' -BoundParameters @{ ResourceName = 'eventhub' }

        $readParameters.ResourceName | Should Be 'eventhub'
    }

    It 'uses separate read and target parameter groups in every affected wrapper' {
        $wrappers = @(
            'Approve-AzEventHubPrivateEndpointConnection.ps1',
            'Deny-AzEventHubPrivateEndpointConnection.ps1',
            'Set-AzEventHub.ps1',
            'Set-AzEventHubApplicationGroup.ps1',
            'Set-AzEventHubAuthorizationRule.ps1',
            'Set-AzEventHubCluster.ps1',
            'Set-AzEventHubConsumerGroup.ps1',
            'Set-AzEventHubGeoDRConfigurationBreakPair.ps1',
            'Set-AzEventHubGeoDRConfigurationFailOver.ps1',
            'Set-AzEventHubNamespace.ps1',
            'Set-AzEventHubNetworkRuleSet.ps1'
        )

        foreach ($wrapper in $wrappers) {
            $source = Get-Content -Path (Join-Path $PSScriptRoot "..\custom\$wrapper") -Raw
            $source | Should Match '\$targetParameters\s*=\s*@\{\}\s*\+\s*\$PSBoundParameters'
            $source | Should Match 'Get-AzEventHubReadParameters\s+-CommandName'
            $source | Should Match '@readParameters'
            $source | Should Match '@targetParameters'
        }
    }

    It 'keeps exact expanded and via-identity read variants for authorization rules' {
        $source = Get-Content -Path (Join-Path $PSScriptRoot '..\custom\Set-AzEventHubAuthorizationRule.ps1') -Raw

        $source | Should Match "CommandName 'Az\.EventHub\.private\\Get-AzEventHubAuthorizationRule_Get'"
        $source | Should Match "CommandName 'Az\.EventHub\.private\\Get-AzEventHubAuthorizationRule_GetViaIdentity'"
        $source | Should Match "CommandName 'Az\.EventHub\.private\\Get-AzEventHubNamespaceAuthorizationRule_GetViaIdentity'"
    }

    It 'packages the internal helper and triggers regeneration' {
        $customPath = Join-Path $PSScriptRoot '..\custom'
        $helperPath = Join-Path $customPath 'Get-AzEventHubReadParameters.ps1'
        $moduleSource = Get-Content -Path (Join-Path $customPath 'Az.EventHub.custom.psm1') -Raw
        $helperSource = Get-Content -Path $helperPath -Raw
        $generation = Get-Content -Path (Join-Path $PSScriptRoot '..\generate-info.json') -Raw | ConvertFrom-Json

        Test-Path -Path $helperPath | Should Be $true
        $helperSource | Should Match '\[Microsoft\.Azure\.PowerShell\.Cmdlets\.EventHub\.DoNotExportAttribute\(\)\]'
        $moduleSource | Should Match "Get-ChildItem\s+-Path\s+\`$PSScriptRoot\s+-Recurse\s+-Include\s+'\*\.ps1'"
        { [guid]::Parse($generation.generate_Id) } | Should Not Throw
        $generation.generate_Id | Should Not Be '37e57dcc-9680-41ff-a019-ec549669f7b0'
    }
}
