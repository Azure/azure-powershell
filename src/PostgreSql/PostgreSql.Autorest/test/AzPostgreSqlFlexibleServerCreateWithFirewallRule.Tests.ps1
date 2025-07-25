$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzPostgreSqlFlexibleServerCreateWithFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzPostgreSqlFlexibleServerCreateWithFirewallRule' {

    It 'PublicAccessScenario-NoInput' {
        If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
            {
                # Public Access All
                New-AzPostgreSqlFlexibleServer -Location $env.location -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName2
                $Server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName2
                $Server.NetworkPublicNetworkAccess | Should -Be "Enabled"
                Remove-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName2
            } | Should -Not -Throw
        }
    }

    It 'PublicAccessScenario-None' {
        If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
            {
                # Public Access All
                New-AzPostgreSqlFlexibleServer -Location $env.location -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName3 -PublicAccess None
                $Server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName3
                $Server.NetworkPublicNetworkAccess | Should -Be "Enabled"
                Remove-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName3
            } | Should -Not -Throw
        }
    }

    It 'PublicAccessScenario-AllowAll' {
        If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
            {
                # Public Access All
                New-AzPostgreSqlFlexibleServer -Location $env.location -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName2 -PublicAccess All
                $FirewallRules = Get-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName2
                $FirewallRules[0].Name | Should -BeLike "AllowAll*"
                $FirewallRules[0].StartIPAddress | Should -Be "0.0.0.0"
                $FirewallRules[0].EndIPAddress | Should -Be "255.255.255.255"
                Remove-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName2
            } | Should -Not -Throw
        }
    }

    It 'PublicAccessScenario-FirewallRule' {
        {
            if ($TestMode -eq 'live' -or $TestMode -eq 'record') {
                # Public Access 10.10.10.10-10.10.10.12
                New-AzPostgreSqlFlexibleServer -Location $env.location -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName3 -PublicAccess 10.10.10.10-10.10.10.12
                $FirewallRules = Get-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName3
                $FirewallRules[0].Name | Should -BeLike "FirewallIPAddress*"
                $FirewallRules[0].StartIPAddress | Should -Be "10.10.10.10"
                $FirewallRules[0].EndIPAddress | Should -Be "10.10.10.12"
                Remove-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName3
            }
        } | Should -Not -Throw
    }

}