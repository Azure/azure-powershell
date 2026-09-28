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

Set-Alias -Name Get-AzServiceBusReadTestResourceAlias -Value Get-AzServiceBusReadTestResource

Describe 'ServiceBus inline read parameter forwarding' {
    It 'filters write-only parameters using aliased read command metadata without changing target parameters' {
        $targetParameters = @{
            Name = 'queue'
            DefaultProfile = 'profile'
            ErrorAction = 'Stop'
            AcquirePolicyToken = $true
            ChangeReference = 'change-123'
            SyntheticWriteOnly = 'future-value'
        }

        $readCommand = @(Get-Command -Name 'Get-AzServiceBusReadTestResourceAlias' -ErrorAction Stop)[0]
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
        Get-AzServiceBusReadTestResource @readParameters
        Set-AzServiceBusReadTestResource @targetParameters

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

    It 'inlines metadata filtering with separate read and target parameters in every affected wrapper' {
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
        $source = Get-Content -Path (Join-Path $PSScriptRoot '..\custom\Set-AzServiceBusAuthorizationRule.ps1') -Raw

        $source | Should Match "Get-Command -Name 'Az.ServiceBus.private\\Get-AzServiceBusQueueAuthorizationRule_Get'"
        $source | Should Match "Get-Command -Name 'Az.ServiceBus.private\\Get-AzServiceBusTopicAuthorizationRule_GetViaIdentity'"
        $source | Should Match "Get-Command -Name 'Az.ServiceBus.private\\Get-AzServiceBusNamespaceAuthorizationRule_GetViaIdentity'"
    }

    It 'has no helper source and retains the regeneration trigger' {
        $helperPath = Join-Path $PSScriptRoot '..\custom\Get-AzServiceBusReadParameters.ps1'
        $generation = Get-Content -Path (Join-Path $PSScriptRoot '..\generate-info.json') -Raw | ConvertFrom-Json

        Test-Path -Path $helperPath | Should Be $false
        { [guid]::Parse($generation.generate_Id) } | Should Not Throw
        $generation.generate_Id | Should Not Be 'd42664e3-3ae4-4daf-a410-fba6f9958c4e'
    }
}
