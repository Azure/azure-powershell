$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzMySqlFlexibleServerCreateWithFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName


$DEFAULT_DB_NAME = 'flexibleserverdb'
$DELEGATION_SERVICE_NAME = "Microsoft.DBforMySQL/flexibleServers"
$DEFAULT_VNET_PREFIX = '10.0.0.0/16'
$DEFAULT_SUBNET_PREFIX = '10.0.0.0/24'

Describe 'AzMySqlFlexibleServerCreateWithFirewallRule' {

    # It 'PublicAccessScenario-NoInput' {
    #     If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
    #         {
    #             # Public Access All
    #             New-AzMySqlFlexibleServer -Location $env.location -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName2
    #             $Server = Get-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName2
    #             $Server.NetworkPublicNetworkAccess | Should -Be "Enabled"
    #             Remove-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName2
    #         } | Should -Not -Throw
    #     }
    # }

    # It 'PublicAccessScenario-None' {
    #     If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
    #         {
    #             # Public Access All
    #             New-AzMySqlFlexibleServer -Location $env.location -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName3 -PublicAccess None
    #             $Server = Get-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName3
    #             $Server.NetworkPublicNetworkAccess | Should -Be "Enabled"
    #             Remove-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName3
    #         } | Should -Not -Throw
    #     }
    # }

    It 'PublicAccessScenario-AllowAll' {
        If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
            {
                # Public Access All
                New-AzMySqlFlexibleServer -Location $env.location -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName2 -PublicAccess All
                $FirewallRules = Get-AzMySqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName2
                $FirewallRules[0].Name | Should -BeLike "AllowAll*"
                $FirewallRules[0].StartIPAddress | Should -Be "0.0.0.0"
                $FirewallRules[0].EndIPAddress | Should -Be "255.255.255.255"
                Remove-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName2
            } | Should -Not -Throw
        }
    }

    It 'PublicAccessScenario-FirewallRule' {
        {
            if ($TestMode -eq 'live' -or $TestMode -eq 'record') {
                # Public Access 10.10.10.10-10.10.10.12
                New-AzMySqlFlexibleServer -Location $env.location -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName3 -PublicAccess 10.10.10.10
                $FirewallRules = Get-AzMySqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName3
                $FirewallRules[0].Name | Should -BeLike "FirewallIPAddress*"
                $FirewallRules[0].StartIPAddress | Should -Be "10.10.10.10"
                $FirewallRules[0].EndIPAddress | Should -Be "10.10.10.10"
                Remove-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName3
            }
        } | Should -Not -Throw
    }
}