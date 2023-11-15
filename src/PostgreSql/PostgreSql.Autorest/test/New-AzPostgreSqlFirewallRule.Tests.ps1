$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPostgreSqlFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzPostgreSqlFirewallRule' {
    It 'CreateExpanded' {
        $rule = New-AzPostgreSqlFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
        $rule.Name | Should -Be $env.firewallRuleName
        $rule.StartIPAddress | Should -Be 0.0.0.0
        $rule.EndIPAddress | Should -Be 0.0.0.1
        Remove-AzPostgreSqlFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
    }
    
    It 'ClientIPAddress' {
        #Use only one parameter when only one IP
        $rule = New-AzPostgreSqlFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -ClientIPAddress 0.0.0.1
        $rule.Name | Should -Be $env.firewallRuleName
        $rule.StartIPAddress | Should -Be 0.0.0.1
        $rule.EndIPAddress | Should -Be 0.0.0.1
        Remove-AzPostgreSqlFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
    }

    It 'AllowAll' {
        $allowAllName = 'AllowAll_2020-08-11_21-28-19'
        $rule = New-AzPostgreSqlFirewallRule -Name $allowAllName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -AllowAll
        $rule.Name | Should -Be $allowAllName
        $rule.StartIPAddress | Should -Be 0.0.0.0
        $rule.EndIPAddress | Should -Be 255.255.255.255
        Remove-AzPostgreSqlFirewallRule -Name $rule.Name -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
    }
}
