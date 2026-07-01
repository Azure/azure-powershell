Describe 'Az.PrivateTrafficManager Module Validation' {

    BeforeAll {
        $modulePath = Join-Path $PSScriptRoot '..' 'Az.PrivateTrafficManager.psd1'
        Import-Module $modulePath -Force
    }

    $expectedCmdlets = @(
        'Get-AzPrivateTrafficManagerEndpoint',
        'Get-AzPrivateTrafficManagerHealthPolicy',
        'Get-AzPrivateTrafficManagerProfile',
        'Get-AzPrivateTrafficManagerSite',
        'Get-AzPrivateTrafficManagerTopologyMap',
        'New-AzPrivateTrafficManagerEndpoint',
        'New-AzPrivateTrafficManagerHealthPolicy',
        'New-AzPrivateTrafficManagerProfile',
        'New-AzPrivateTrafficManagerSite',
        'New-AzPrivateTrafficManagerTopologyMap',
        'Remove-AzPrivateTrafficManagerEndpoint',
        'Remove-AzPrivateTrafficManagerHealthPolicy',
        'Remove-AzPrivateTrafficManagerProfile',
        'Remove-AzPrivateTrafficManagerSite',
        'Remove-AzPrivateTrafficManagerTopologyMap',
        'Update-AzPrivateTrafficManagerEndpoint',
        'Update-AzPrivateTrafficManagerHealthPolicy',
        'Update-AzPrivateTrafficManagerProfile',
        'Update-AzPrivateTrafficManagerSite',
        'Update-AzPrivateTrafficManagerTopologyMap'
    )

    It 'Module should load and export 20 cmdlets' {
        $commands = Get-Command -Module Az.PrivateTrafficManager
        $commands.Count | Should Be 20
    }

    foreach ($cmdlet in $expectedCmdlets) {
        It "Should have cmdlet $cmdlet" {
            Get-Command $cmdlet -Module Az.PrivateTrafficManager -ErrorAction SilentlyContinue | Should Not BeNullOrEmpty
        }
    }

    It 'Should not have any Set-* cmdlets' {
        $setCmdlets = Get-Command -Module Az.PrivateTrafficManager | Where-Object { $_.Name -like 'Set-*' }
        $setCmdlets | Should BeNullOrEmpty
    }

    It 'New-AzPrivateTrafficManagerProfile should have CreateExpanded parameter set' {
        $sets = (Get-Command New-AzPrivateTrafficManagerProfile).ParameterSets | Select-Object -ExpandProperty Name
        $sets -contains 'CreateExpanded' | Should Be $true
    }

    It 'Get-AzPrivateTrafficManagerProfile should have List and Get parameter sets' {
        $sets = (Get-Command Get-AzPrivateTrafficManagerProfile).ParameterSets | Select-Object -ExpandProperty Name
        ($sets -contains 'List') | Should Be $true
        ($sets -contains 'Get') | Should Be $true
    }

    It 'Child resource Endpoint should support parent identity lookup' {
        $sets = (Get-Command Get-AzPrivateTrafficManagerEndpoint).ParameterSets | Select-Object -ExpandProperty Name
        ($sets -contains 'GetViaIdentityPrivateTrafficManagerProfile') | Should Be $true
    }

    It 'Child resource Site should support parent identity lookup' {
        $sets = (Get-Command Get-AzPrivateTrafficManagerSite).ParameterSets | Select-Object -ExpandProperty Name
        ($sets -contains 'GetViaIdentityTopologyMap') | Should Be $true
    }
}