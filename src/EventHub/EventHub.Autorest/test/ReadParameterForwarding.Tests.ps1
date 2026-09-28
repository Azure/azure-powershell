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

Set-Alias -Name Get-AzEventHubReadTestResourceAlias -Value Get-AzEventHubReadTestResource

Describe 'EventHub inline read parameter forwarding' {
    It 'filters write-only parameters using aliased read command metadata without changing target parameters' {
        $targetParameters = @{
            Name = 'eventhub'
            DefaultProfile = 'profile'
            ErrorAction = 'Stop'
            AcquirePolicyToken = $true
            ChangeReference = 'change-123'
            SyntheticWriteOnly = 'future-value'
        }

        $readCommand = @(Get-Command -Name 'Get-AzEventHubReadTestResourceAlias' -ErrorAction Stop)[0]
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

    It 'inlines metadata filtering with separate read and target parameters in every affected wrapper' {
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

    It 'keeps exact expanded and via-identity read variants for authorization rules' {
        $source = Get-Content -Path (Join-Path $PSScriptRoot '..\custom\Set-AzEventHubAuthorizationRule.ps1') -Raw

        $source | Should Match "Get-Command -Name 'Az.EventHub.private\\Get-AzEventHubAuthorizationRule_Get'"
        $source | Should Match "Get-Command -Name 'Az.EventHub.private\\Get-AzEventHubAuthorizationRule_GetViaIdentity'"
        $source | Should Match "Get-Command -Name 'Az.EventHub.private\\Get-AzEventHubNamespaceAuthorizationRule_GetViaIdentity'"
    }

    It 'has no helper source and retains the regeneration trigger' {
        $helperPath = Join-Path $PSScriptRoot '..\custom\Get-AzEventHubReadParameters.ps1'
        $generation = Get-Content -Path (Join-Path $PSScriptRoot '..\generate-info.json') -Raw | ConvertFrom-Json

        Test-Path -Path $helperPath | Should Be $false
        { [guid]::Parse($generation.generate_Id) } | Should Not Throw
        $generation.generate_Id | Should Not Be '37e57dcc-9680-41ff-a019-ec549669f7b0'
    }
}
