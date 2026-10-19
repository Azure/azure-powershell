$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Switch-AzCloudService.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Switch-AzCloudService' {
    It 'CloudServiceName' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CloudService' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    InModuleScope 'Az.CloudService.custom' {
        Context 'Change Safety forwarding' {
            BeforeEach {
                $script:subscriptionId = '00000000-0000-0000-0000-000000000001'
                $script:sourceId = "/subscriptions/$script:subscriptionId/resourceGroups/change-safety/providers/Microsoft.Compute/cloudServices/source"
                $script:source = [pscustomobject]@{
                    Name = 'source'
                    Location = 'westus'
                    NetworkProfile = @{
                        SwappableCloudService = @{ Id = $script:sourceId.Replace('/source', '/target') }
                        LoadBalancerConfiguration = @(@{
                            Name = 'source-lb'
                            FrontendIPConfiguration = @(@{ PublicIPAddressId = '/publicIPAddresses/source' })
                        })
                    }
                }
                $script:target = [pscustomobject]@{
                    Name = 'target'
                    NetworkProfile = @{
                        LoadBalancerConfiguration = @(@{
                            Name = 'target-lb'
                            FrontendIPConfiguration = @(@{ PublicIPAddressId = '/publicIPAddresses/target' })
                        })
                    }
                }
                $script:restCalls = @()
                $script:response = [System.Net.Http.HttpResponseMessage]::new()
                $script:response.Headers.Add('Azure-AsyncOperation', 'https://management.azure.com/operations/change-safety')
                # Preserve native metadata before Pester replaces the REST command with a function.
                $script:restCommand = Get-Command 'Az.Accounts\Invoke-AzRestMethod' -ErrorAction Stop

                Mock Get-Command { $script:restCommand } -ParameterFilter { $Name -eq 'Az.Accounts\Invoke-AzRestMethod' }
                Mock Get-AzCloudService {
                    if ($Name -eq 'source') { return $script:source }
                    return $script:target
                }
                Mock Invoke-AzRestMethod {
                    param($Method, $Path, $Payload, $AcquirePolicyToken, $ChangeReference)
                    $parameters = @{}
                    foreach ($entry in $PSBoundParameters.GetEnumerator()) {
                        $parameters[$entry.Key] = $entry.Value
                    }
                    $script:restCalls += @{ Method = $Method; Parameters = $parameters }
                    if ($Method -eq 'POST') {
                        return @{ StatusCode = 202; Headers = $script:response.Headers }
                    }
                    if ($Path -like '*/loadBalancers/*') {
                        return @{
                            StatusCode = 200
                            Content = '{"properties":{"frontendIPConfigurations":[{"id":"/frontendIPConfigurations/test"}]}}'
                        }
                    }
                    return @{ StatusCode = 200; Content = '{"status":"Succeeded"}' }
                }
                Mock Write-Host {}
            }

            AfterEach {
                $script:response.Dispose()
            }

            $testCases = foreach ($parameterSet in 'CloudServiceName', 'CloudService') {
                foreach ($scenario in @(
                    @{ Name = 'unbound parameters'; Parameters = @{} }
                    @{ Name = 'policy token'; Parameters = @{ AcquirePolicyToken = $true } }
                    @{ Name = 'explicitly disabled policy token'; Parameters = @{ AcquirePolicyToken = $false } }
                    @{ Name = 'change reference'; Parameters = @{ ChangeReference = 'change-safety-test' } }
                    @{ Name = 'both parameters'; Parameters = @{ AcquirePolicyToken = $true; ChangeReference = 'change-safety-test' } }
                )) {
                    @{ ParameterSet = $parameterSet; Scenario = $scenario.Name; ChangeSafety = $scenario.Parameters }
                }
            }

            It 'forwards <Scenario> only to POST through <ParameterSet>' -TestCases $testCases {
                param($ParameterSet, $Scenario, $ChangeSafety)
                $parameters = @{ SubscriptionId = $script:subscriptionId; Confirm = $false }
                if ($ParameterSet -eq 'CloudService') {
                    $parameters.CloudService = [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.CloudService]@{
                        Id = $script:sourceId
                        Name = 'source'
                    }
                } else {
                    $parameters.ResourceGroupName = 'change-safety'
                    $parameters.CloudServiceName = 'source'
                }
                foreach ($entry in $ChangeSafety.GetEnumerator()) {
                    $parameters[$entry.Key] = $entry.Value
                }

                Switch-AzCloudService @parameters | Out-Null

                $writes = @($script:restCalls | Where-Object Method -eq 'POST')
                $reads = @($script:restCalls | Where-Object Method -eq 'GET')
                $writes.Count | Should -Be 1
                $reads.Count | Should -Be 3
                foreach ($name in 'AcquirePolicyToken', 'ChangeReference') {
                    $writes[0].Parameters.ContainsKey($name) | Should -Be ($ChangeSafety.ContainsKey($name))
                    if ($ChangeSafety.ContainsKey($name)) {
                        $writes[0].Parameters[$name] | Should -Be $ChangeSafety[$name]
                    }
                    foreach ($read in $reads) {
                        $read.Parameters.ContainsKey($name) | Should -Be $false
                    }
                }
            }

            It 'does not write when WhatIf is supplied with Change Safety parameters' {
                Switch-AzCloudService -SubscriptionId $script:subscriptionId -ResourceGroupName 'change-safety' `
                    -CloudServiceName 'source' -AcquirePolicyToken -ChangeReference 'change-safety-test' -WhatIf

                @($script:restCalls | Where-Object Method -eq 'POST').Count | Should -Be 0
            }

            It 'forwards Change Safety parameters through the public <ParameterSet> proxy' -TestCases @(
                @{ ParameterSet = 'CloudServiceName' }
                @{ ParameterSet = 'CloudService' }
            ) {
                param($ParameterSet)
                Mock Get-AzContext { [pscustomobject]@{ Subscription = @{ Id = $script:subscriptionId } } } -ModuleName Az.CloudService
                $parameters = @{
                    SubscriptionId = $script:subscriptionId
                    AcquirePolicyToken = $false
                    ChangeReference = 'change-safety-test'
                    Async = $true
                    Confirm = $false
                }
                if ($ParameterSet -eq 'CloudService') {
                    $parameters.CloudService = [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.CloudService]@{
                        Id = $script:sourceId
                        Name = 'source'
                    }
                } else {
                    $parameters.ResourceGroupName = 'change-safety'
                    $parameters.CloudServiceName = 'source'
                }

                Az.CloudService\Switch-AzCloudService @parameters | Out-Null

                $writes = @($script:restCalls | Where-Object Method -eq 'POST')
                $writes.Count | Should -Be 1
                $writes[0].Parameters.ContainsKey('AcquirePolicyToken') | Should -Be $true
                $writes[0].Parameters.AcquirePolicyToken | Should -Be $false
                $writes[0].Parameters.ChangeReference | Should -Be 'change-safety-test'
                @($script:restCalls | Where-Object Method -eq 'GET').Count | Should -Be 2
            }

            It 'does not expose Change Safety parameters when the REST command does not support them' {
                Mock Get-Command {
                    [pscustomobject]@{
                        ImplementingType = [System.Management.Automation.PSCmdlet]
                        Parameters = @{}
                    }
                } -ParameterFilter { $Name -eq 'Az.Accounts\Invoke-AzRestMethod' }

                {
                    Switch-AzCloudService -SubscriptionId $script:subscriptionId -ResourceGroupName 'change-safety' `
                        -CloudServiceName 'source' -AcquirePolicyToken -Confirm:$false
                } | Should -Throw 'AcquirePolicyToken'

                Switch-AzCloudService -SubscriptionId $script:subscriptionId -ResourceGroupName 'change-safety' `
                    -CloudServiceName 'source' -Confirm:$false | Out-Null
                @($script:restCalls | Where-Object Method -eq 'POST').Count | Should -Be 1
            }
        }
    }
}
