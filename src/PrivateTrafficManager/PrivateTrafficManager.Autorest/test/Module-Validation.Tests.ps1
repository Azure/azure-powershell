Describe 'Az.PrivateTrafficManager Module Validation' {

    BeforeAll {
        $modulePath = Join-Path $PSScriptRoot '..' 'Az.PrivateTrafficManager.psd1'
        if (-not (Test-Path $modulePath)) {
            $modulePath = Join-Path $PSScriptRoot '../../../../artifacts/Debug/Az.PrivateTrafficManager/PrivateTrafficManager.Autorest/Az.PrivateTrafficManager.psd1'
        }
        Import-Module $modulePath -Force -ErrorAction Stop
    }

    $expectedCmdlets = @(
        'Get-AzPrivateTrafficManagerEndpoint',
        'Get-AzPrivateTrafficManagerHealthPolicy',
        'Get-AzPrivateTrafficManagerProfile',
        'Get-AzPrivateTrafficManagerProfileProbingGateway',
        'Get-AzPrivateTrafficManagerSite',
        'Get-AzPrivateTrafficManagerTopologyMap',
        'New-AzPrivateTrafficManagerEndpoint',
        'New-AzPrivateTrafficManagerHealthPolicy',
        'New-AzPrivateTrafficManagerProfile',
        'New-AzPrivateTrafficManagerProfileProbingGateway',
        'New-AzPrivateTrafficManagerSite',
        'New-AzPrivateTrafficManagerTopologyMap',
        'Remove-AzPrivateTrafficManagerEndpoint',
        'Remove-AzPrivateTrafficManagerHealthPolicy',
        'Remove-AzPrivateTrafficManagerProfile',
        'Remove-AzPrivateTrafficManagerProfileProbingGateway',
        'Remove-AzPrivateTrafficManagerSite',
        'Remove-AzPrivateTrafficManagerTopologyMap',
        'Update-AzPrivateTrafficManagerEndpoint',
        'Update-AzPrivateTrafficManagerHealthPolicy',
        'Update-AzPrivateTrafficManagerProfile',
        'Update-AzPrivateTrafficManagerProfileProbingGateway',
        'Update-AzPrivateTrafficManagerSite',
        'Update-AzPrivateTrafficManagerTopologyMap'
    )

    It 'Module should load and export 24 cmdlets' {
        $commands = Get-Command -Module Az.PrivateTrafficManager
        $commands.Count | Should -Be 24
    }

    It 'Should have cmdlet <cmdlet>' -TestCases @($expectedCmdlets | ForEach-Object { @{ cmdlet = $_ } }) {
        param($cmdlet)
        Get-Command $cmdlet -Module Az.PrivateTrafficManager -ErrorAction SilentlyContinue | Should -Not -BeNullOrEmpty
    }

    It 'Should not have any Set-* cmdlets' {
        $setCmdlets = Get-Command -Module Az.PrivateTrafficManager | Where-Object { $_.Name -like 'Set-*' }
        $setCmdlets | Should -BeNullOrEmpty
    }

    It 'New-AzPrivateTrafficManagerProfile should have CreateExpanded parameter set' {
        $sets = (Get-Command New-AzPrivateTrafficManagerProfile).ParameterSets | Select-Object -ExpandProperty Name
        $sets -contains 'CreateExpanded' | Should -Be $true
    }

    It 'Get-AzPrivateTrafficManagerProfile should have List and Get parameter sets' {
        $sets = (Get-Command Get-AzPrivateTrafficManagerProfile).ParameterSets | Select-Object -ExpandProperty Name
        ($sets -contains 'List') | Should -Be $true
        ($sets -contains 'Get') | Should -Be $true
    }

    It 'Child resource Endpoint should support parent identity lookup' {
        $sets = (Get-Command Get-AzPrivateTrafficManagerEndpoint).ParameterSets | Select-Object -ExpandProperty Name
        ($sets -contains 'GetViaIdentityPrivateTrafficManagerProfile') | Should -Be $true
    }

    It 'Child resource Site should support parent identity lookup' {
        $sets = (Get-Command Get-AzPrivateTrafficManagerSite).ParameterSets | Select-Object -ExpandProperty Name
        ($sets -contains 'GetViaIdentityTopologyMap') | Should -Be $true
    }

    It 'Gateway associations should support named and parent identity creation' {
        $command = Get-Command New-AzPrivateTrafficManagerProfileProbingGateway
        $command.Parameters.Keys | Should -Contain 'ProbingGatewayId'
        $command.ParameterSets.Name | Should -Contain 'CreateExpanded'
        $command.ParameterSets.Name | Should -Contain 'CreateViaIdentityPrivateTrafficManagerProfileExpanded'
    }

    It 'Profiles should expose the current topology mode and routing method' {
        $command = Get-Command New-AzPrivateTrafficManagerProfile
        $command.Parameters.Keys | Should -Contain 'CustomTopologyMapMode'
        $command.Parameters.Keys | Should -Not -Contain 'CustomTopologyMap'
        $command.Parameters.Keys | Should -Contain 'TrafficRoutingMethod'
    }

    It 'Endpoint create and update should accept virtual network assignments' {
        (Get-Command New-AzPrivateTrafficManagerEndpoint).Parameters.Keys | Should -Contain 'VirtualNetworkId'
        (Get-Command Update-AzPrivateTrafficManagerEndpoint).Parameters.Keys | Should -Contain 'VirtualNetworkId'
    }

    It 'Health policy create and update should expose expanded probe configuration' {
        foreach ($verb in @('New', 'Update')) {
            $parameters = (Get-Command "$verb-AzPrivateTrafficManagerHealthPolicy").Parameters.Keys
            foreach ($name in @('ProbeConfigProtocol', 'ProbeConfigPort', 'ProbeConfigPath', 'ProbeConfigCustomHeader', 'ProbeConfigExpectedStatusCodeRange')) {
                $parameters | Should -Contain $name
            }
        }
    }

    It 'Topology map PATCH should expose tags and catch-all but not inline sites' {
        $parameters = (Get-Command Update-AzPrivateTrafficManagerTopologyMap).Parameters.Keys
        $parameters | Should -Contain 'Tag'
        $parameters | Should -Contain 'CatchAllSiteName'
        $parameters | Should -Not -Contain 'Site'
    }
}