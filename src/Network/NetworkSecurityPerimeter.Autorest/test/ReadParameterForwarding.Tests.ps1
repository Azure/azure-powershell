$helperPath = Join-Path $PSScriptRoot '..\custom\Get-AzNetworkSecurityPerimeterReadParameters.ps1'
$helperSource = Get-Content -Path $helperPath -Raw
$helperSource = $helperSource -replace '(?m)^\s*\[Microsoft\.Azure\.PowerShell\.Cmdlets\.NetworkSecurityPerimeter\.DoNotExportAttribute\(\)\]\r?\n', ''
. ([scriptblock]::Create($helperSource))

function Get-AzNetworkSecurityPerimeterReadTestResource {
    [CmdletBinding()]
    param(
        [Alias('ResourceName')]
        [string] $Name,
        [object] $DefaultProfile
    )

    $script:nspReadParameters = @{} + $PSBoundParameters
}

function Set-AzNetworkSecurityPerimeterReadTestResource {
    [CmdletBinding()]
    param(
        [string] $Name,
        [object] $DefaultProfile,
        [switch] $AcquirePolicyToken,
        [string] $ChangeReference,
        [string] $SyntheticWriteOnly
    )

    $script:nspWriteParameters = @{} + $PSBoundParameters
}

Set-Alias -Name Get-AzNetworkSecurityPerimeterReadTestAlias -Value Get-AzNetworkSecurityPerimeterReadTestResource

Describe 'NetworkSecurityPerimeter read parameter forwarding' {
    It 'filters write-only parameters using read command metadata without changing write parameters' {
        $writeParameters = @{
            Name = 'access-rule'
            DefaultProfile = 'profile'
            ErrorAction = 'Stop'
            AcquirePolicyToken = $true
            ChangeReference = 'change-123'
            SyntheticWriteOnly = 'future-value'
        }

        $readParameters = Get-AzNetworkSecurityPerimeterReadParameters -CommandName 'Get-AzNetworkSecurityPerimeterReadTestAlias' -BoundParameters $writeParameters
        Get-AzNetworkSecurityPerimeterReadTestResource @readParameters
        Set-AzNetworkSecurityPerimeterReadTestResource @writeParameters

        $script:nspReadParameters.Name | Should Be 'access-rule'
        $script:nspReadParameters.DefaultProfile | Should Be 'profile'
        $script:nspReadParameters.ErrorAction | Should Be 'Stop'
        $script:nspReadParameters.ContainsKey('AcquirePolicyToken') | Should Be $false
        $script:nspReadParameters.ContainsKey('ChangeReference') | Should Be $false
        $script:nspReadParameters.ContainsKey('SyntheticWriteOnly') | Should Be $false
        $script:nspWriteParameters.AcquirePolicyToken | Should Be $true
        $script:nspWriteParameters.ChangeReference | Should Be 'change-123'
        $script:nspWriteParameters.SyntheticWriteOnly | Should Be 'future-value'
    }

    It 'recognizes read parameter aliases' {
        $readParameters = Get-AzNetworkSecurityPerimeterReadParameters -CommandName 'Get-AzNetworkSecurityPerimeterReadTestResource' -BoundParameters @{ ResourceName = 'access-rule' }

        $readParameters.ResourceName | Should Be 'access-rule'
    }

    It 'uses read parameters without replacing the original bound parameters in every affected wrapper' {
        $wrappers = @(
            'Update-AzNetworkSecurityPerimeterAccessRule.ps1',
            'Update-AzNetworkSecurityPerimeterAssociation.ps1',
            'Update-AzNetworkSecurityPerimeterLink.ps1',
            'Update-AzNetworkSecurityPerimeterLoggingConfiguration.ps1'
        )

        foreach ($wrapper in $wrappers) {
            $source = Get-Content -Path (Join-Path $PSScriptRoot "..\custom\$wrapper") -Raw
            $source | Should Not Match '\$targetParameters'
            $source | Should Match 'Get-AzNetworkSecurityPerimeterReadParameters\s+-CommandName\s+''[^'']+''\s+-BoundParameters\s+\$PSBoundParameters'
            $source | Should Match '@readParameters'
            $source | Should Match '@PSBoundParameters'
        }
    }

    It 'packages the internal helper and triggers regeneration' {
        $customPath = Join-Path $PSScriptRoot '..\custom'
        $helperPath = Join-Path $customPath 'Get-AzNetworkSecurityPerimeterReadParameters.ps1'
        $moduleSource = Get-Content -Path (Join-Path $customPath 'Az.NetworkSecurityPerimeter.custom.psm1') -Raw
        $helperSource = Get-Content -Path $helperPath -Raw
        $generation = Get-Content -Path (Join-Path $PSScriptRoot '..\generate-info.json') -Raw | ConvertFrom-Json

        Test-Path -Path $helperPath | Should Be $true
        $helperSource | Should Match '\[Microsoft\.Azure\.PowerShell\.Cmdlets\.NetworkSecurityPerimeter\.DoNotExportAttribute\(\)\]'
        $moduleSource | Should Match "Get-ChildItem\s+-Path\s+\`$PSScriptRoot\s+-Recurse\s+-Include\s+'\*\.ps1'"
        { [guid]::Parse($generation.generate_Id) } | Should Not Throw
        $generation.generate_Id | Should Not Be '22876a3f-6f36-449b-a291-2b1c423db247'
    }
}
