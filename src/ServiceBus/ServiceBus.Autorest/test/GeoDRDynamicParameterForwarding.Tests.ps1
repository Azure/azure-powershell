class ServiceBusTestDynamicParameters : System.Management.Automation.IDynamicParameters {
    [object] GetDynamicParameters() {
        $parameters = [System.Management.Automation.RuntimeDefinedParameterDictionary]::new()
        foreach ($name in 'AcquirePolicyToken', 'ChangeReference', 'FutureDynamic', 'InputObject', 'Name', 'NamespaceName', 'ResourceGroupName', 'SubscriptionId') {
            $attributes = [System.Collections.ObjectModel.Collection[System.Attribute]]::new()
            $parameters.Add($name, [System.Management.Automation.RuntimeDefinedParameter]::new($name, [object], $attributes))
        }
        return $parameters
    }
}

$helperPath = Join-Path $PSScriptRoot '..\custom\Add-AzServiceBusBoundDynamicParameter.ps1'
$helperSource = Get-Content -Path $helperPath -Raw
$helperSource = $helperSource -replace '(?m)^\s*\[Microsoft\.Azure\.PowerShell\.Cmdlets\.ServiceBus\.DoNotExportAttribute\(\)\]\r?\n', ''
. ([scriptblock]::Create($helperSource))

Describe 'ServiceBus GeoDR via-identity dynamic parameter forwarding' {
    Mock Get-Command {
        [pscustomobject]@{
            CommandType = [System.Management.Automation.CommandTypes]::Cmdlet
            ImplementingType = [ServiceBusTestDynamicParameters]
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

        Add-AzServiceBusBoundDynamicParameter -CommandName 'Az.ServiceBus.private\Test-Target' -BoundParameters $boundParameters -TargetParameters $environmentParameters -ExcludedParameter InputObject, Name, NamespaceName, ResourceGroupName, SubscriptionId

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

        Add-AzServiceBusBoundDynamicParameter -CommandName 'Az.ServiceBus.private\Test-Target' -BoundParameters @{ FutureDynamic = 'future-value' } -TargetParameters $environmentParameters

        $environmentParameters.FutureDynamic | Should Be 'future-value'
        $environmentParameters.ContainsKey('AcquirePolicyToken') | Should Be $false
        $environmentParameters.ContainsKey('ChangeReference') | Should Be $false
    }

    It 'accepts the PSBoundParameters dictionary used by custom cmdlets' {
        function Invoke-ServiceBusTestForwarding {
            param(
                [string] $ChangeReference
            )

            $environmentParameters = @{}
            Add-AzServiceBusBoundDynamicParameter -CommandName 'Az.ServiceBus.private\Test-Target' -BoundParameters $PSBoundParameters -TargetParameters $environmentParameters
            return $environmentParameters
        }

        $environmentParameters = Invoke-ServiceBusTestForwarding -ChangeReference 'change-123'

        $environmentParameters.ChangeReference | Should Be 'change-123'
    }

    It 'uses exact target metadata and environment splats in both via-identity branches' {
        $cases = @(
            @{
                File = 'Set-AzServiceBusGeoDRConfigurationBreakPair.ps1'
                Command = 'Az.ServiceBus.private\Invoke-AzServiceBusBreakDisasterRecoveryConfigPairing_Break'
            },
            @{
                File = 'Set-AzServiceBusGeoDRConfigurationFailOver.ps1'
                Command = 'Az.ServiceBus.private\Invoke-AzServiceBusFailDisasterRecoveryConfigOver_FailExpanded'
            }
        )

        foreach ($case in $cases) {
            $source = Get-Content -Path (Join-Path $PSScriptRoot "..\custom\$($case.File)") -Raw
            $escapedCommand = [regex]::Escape($case.Command)

            $source | Should Match "Add-AzServiceBusBoundDynamicParameter -CommandName '$escapedCommand' -BoundParameters \`$PSBoundParameters -TargetParameters \`$EnvPSBoundParameters"
            $source | Should Match "$escapedCommand .+@EnvPSBoundParameters"
        }
    }
}
