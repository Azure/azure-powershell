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

function Assert-InlineReadCommandsInvoked {
    param([string] $Source)

    $lookupPattern = "(?ms)\`$readCommand\s*=\s*@\(Get-Command -Name '([^']+)'[^\r\n]*\)\[0\](?<Block>.*?)(?=\`$readCommand\s*=\s*@\(Get-Command -Name|\z)"
    $lookups = [regex]::Matches($Source, $lookupPattern)
    if ($lookups.Count -eq 0) {
        return $false
    }

    foreach ($lookup in $lookups) {
        $commandName = $lookup.Groups[1].Value
        $invocationPattern = '(?m)^\s*(?:\$\w+\s*=\s*)?' + [regex]::Escape($commandName) + '\s+@readParameters\s*$'
        if (-not [regex]::IsMatch($lookup.Groups['Block'].Value, $invocationPattern)) {
            return $false
        }
    }

    return $true
}

Set-Alias -Name Get-AzNetworkSecurityPerimeterReadTestResourceAlias -Value Get-AzNetworkSecurityPerimeterReadTestResource

Describe 'NetworkSecurityPerimeter inline read parameter forwarding' {
    It 'filters write-only parameters using aliased read command metadata without changing target parameters' {
        $targetParameters = @{
            Name = 'access-rule'
            DefaultProfile = 'profile'
            ErrorAction = 'Stop'
            AcquirePolicyToken = $true
            ChangeReference = 'change-123'
            SyntheticWriteOnly = 'future-value'
        }

        $readCommand = @(Get-Command -Name 'Get-AzNetworkSecurityPerimeterReadTestResourceAlias' -ErrorAction Stop)[0]
        while ($readCommand.CommandType -eq [System.Management.Automation.CommandTypes]::Alias) {
            $readCommand = Get-Command -Name $readCommand.ResolvedCommandName -ErrorAction Stop
        }
        $readParameterNames = @($readCommand.Parameters.Keys)
        $readParameterNames += @($readCommand.Parameters.Values | ForEach-Object { $_.Aliases })
        $readParameters = @{}
        foreach ($parameter in $targetParameters.GetEnumerator()) {
            if ($parameter.Key -in $readParameterNames) {
                $readParameters[$parameter.Key] = $parameter.Value
            }
        }

        ($readParameterNames -contains 'ResourceName') | Should Be $true
        Get-AzNetworkSecurityPerimeterReadTestResource @readParameters
        Set-AzNetworkSecurityPerimeterReadTestResource @targetParameters

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

    It 'inlines metadata filtering with separate read and target parameters in every affected wrapper' {
        $wrappers = @(
            'Update-AzNetworkSecurityPerimeterAccessRule.ps1',
            'Update-AzNetworkSecurityPerimeterAssociation.ps1',
            'Update-AzNetworkSecurityPerimeterLink.ps1',
            'Update-AzNetworkSecurityPerimeterLoggingConfiguration.ps1'
        )

        foreach ($wrapper in $wrappers) {
            $source = Get-Content -Path (Join-Path $PSScriptRoot "..\custom\$wrapper") -Raw
            $source | Should Match '\$targetParameters\s*=\s*@\{\}\s*\+\s*\$PSBoundParameters'
            $source | Should Match '\$readCommand\s*=\s*@\(Get-Command -Name'
            $source | Should Match '\$readCommand\.CommandType.+CommandTypes\]::Alias'
            $source | Should Match '\$readCommand\.Parameters\.Values.+\$_.Aliases'
            $source | Should Match '\$readParameters\s*=\s*@\{\}'
            $source | Should Match '@readParameters'
            $source | Should Match '@targetParameters'
            $source | Should Not Match 'Get-Az(?:EventHub|ServiceBus|NetworkSecurityPerimeter)ReadParameters'
            (Assert-InlineReadCommandsInvoked -Source $source) | Should Be $true
        }
    }

    It 'rejects a lookup followed by invocation of a different read command' {
        $source = @'
$readCommand = @(Get-Command -Name 'Get-AzExpectedResource' -ErrorAction Stop)[0]
$readParameters = @{}
$resource = Get-AzDifferentResource @readParameters
'@

        (Assert-InlineReadCommandsInvoked -Source $source) | Should Be $false
    }

    It 'has no helper source and retains the regeneration trigger' {
        $helperPath = Join-Path $PSScriptRoot '..\custom\Get-AzNetworkSecurityPerimeterReadParameters.ps1'
        $generation = Get-Content -Path (Join-Path $PSScriptRoot '..\generate-info.json') -Raw | ConvertFrom-Json

        Test-Path -Path $helperPath | Should Be $false
        { [guid]::Parse($generation.generate_Id) } | Should Not Throw
        $generation.generate_Id | Should Not Be '22876a3f-6f36-449b-a291-2b1c423db247'
    }
}
