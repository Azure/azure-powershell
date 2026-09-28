class EventHubTestDynamicParameters : System.Management.Automation.IDynamicParameters {
    [object] GetDynamicParameters() {
        $parameters = [System.Management.Automation.RuntimeDefinedParameterDictionary]::new()
        foreach ($name in 'AcquirePolicyToken', 'ChangeReference', 'FutureDynamic', 'InputObject', 'Name', 'NamespaceName', 'ResourceGroupName', 'SubscriptionId') {
            $attributes = [System.Collections.ObjectModel.Collection[System.Attribute]]::new()
            $parameters.Add($name, [System.Management.Automation.RuntimeDefinedParameter]::new($name, [object], $attributes))
        }
        return $parameters
    }
}

$helperPath = Join-Path $PSScriptRoot '..\custom\Add-AzEventHubBoundDynamicParameter.ps1'
$helperSource = Get-Content -Path $helperPath -Raw
$helperSource = $helperSource -replace '(?m)^\s*\[Microsoft\.Azure\.PowerShell\.Cmdlets\.EventHub\.DoNotExportAttribute\(\)\]\r?\n', ''
. ([scriptblock]::Create($helperSource))

Describe 'EventHub GeoDR via-identity dynamic parameter forwarding' {
    Mock Get-Command {
        [pscustomobject]@{
            CommandType = [System.Management.Automation.CommandTypes]::Cmdlet
            ImplementingType = [EventHubTestDynamicParameters]
        }
    }

    It 'adds only bound, non-path dynamic parameters to the environment splat' {
        $boundParameters = @{
            AcquirePolicyToken = $true
            ChangeReference = 'change-123'
            FutureDynamic = 'future-value'
            InputObject = 'identity'
            Name = 'alias'
            NamespaceName = 'namespace'
            ResourceGroupName = 'resource-group'
            SubscriptionId = 'subscription'
        }
        $environmentParameters = @{ Debug = $true }

        Add-AzEventHubBoundDynamicParameter -CommandName 'Az.EventHub.private\Test-Target' -BoundParameters $boundParameters -TargetParameters $environmentParameters -ExcludedParameter InputObject, Name, NamespaceName, ResourceGroupName, SubscriptionId

        $environmentParameters.AcquirePolicyToken | Should Be $true
        $environmentParameters.ChangeReference | Should Be 'change-123'
        $environmentParameters.FutureDynamic | Should Be 'future-value'
        $environmentParameters.Debug | Should Be $true
        $environmentParameters.ContainsKey('InputObject') | Should Be $false
        $environmentParameters.ContainsKey('Name') | Should Be $false
        $environmentParameters.ContainsKey('NamespaceName') | Should Be $false
        $environmentParameters.ContainsKey('ResourceGroupName') | Should Be $false
        $environmentParameters.ContainsKey('SubscriptionId') | Should Be $false
        $environmentParameters.Count | Should Be 4
    }

    It 'does not add supported dynamic parameters that were not bound' {
        $environmentParameters = @{}

        Add-AzEventHubBoundDynamicParameter -CommandName 'Az.EventHub.private\Test-Target' -BoundParameters @{ FutureDynamic = 'future-value' } -TargetParameters $environmentParameters

        $environmentParameters.FutureDynamic | Should Be 'future-value'
        $environmentParameters.ContainsKey('AcquirePolicyToken') | Should Be $false
        $environmentParameters.ContainsKey('ChangeReference') | Should Be $false
    }

    It 'uses exact target metadata and environment splats in both via-identity branches' {
        $cases = @(
            @{
                File = 'Set-AzEventHubGeoDRConfigurationBreakPair.ps1'
                Command = 'Az.EventHub.private\Invoke-AzEventHubBreakDisasterRecoveryConfigPairing_Break'
            },
            @{
                File = 'Set-AzEventHubGeoDRConfigurationFailOver.ps1'
                Command = 'Az.EventHub.private\Invoke-AzEventHubFailDisasterRecoveryConfigOver_Fail'
            }
        )

        foreach ($case in $cases) {
            $source = Get-Content -Path (Join-Path $PSScriptRoot "..\custom\$($case.File)") -Raw
            $escapedCommand = [regex]::Escape($case.Command)

            $source | Should Match "Add-AzEventHubBoundDynamicParameter -CommandName '$escapedCommand' -BoundParameters \`$PSBoundParameters -TargetParameters \`$EnvPSBoundParameters"
            $source | Should Match "$escapedCommand .+@EnvPSBoundParameters"
        }
    }
}
