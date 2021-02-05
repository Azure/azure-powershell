$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPostgreSqlFlexibleServerFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzPostgreSqlFlexibleServerFirewallRule' {
    It 'CreateExpanded' {
        $rule = New-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
        $rule.Name | Should -Be $env.firewallRuleName
        $rule.StartIPAddress | Should -Be 0.0.0.0
        $rule.EndIPAddress | Should -Be 0.0.0.1
        Remove-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName 
    }

    It 'ClientIPAddress' {
        #Use only one parameter when only one IP
        $rule = New-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -ClientIPAddress 0.0.0.1
        $rule.Name | Should -Be $env.firewallRuleName
        $rule.StartIPAddress | Should -Be 0.0.0.1
        $rule.EndIPAddress | Should -Be 0.0.0.1
        Remove-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName 
    }

    It 'AllowAll' {
        $rule = New-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -AllowAll
        $rule.Name | Should -Be $env.firewallRuleName
        $rule.StartIPAddress | Should -Be 0.0.0.0
        $rule.EndIPAddress | Should -Be 255.255.255.255
        Remove-AzPostgreSqlFlexibleServerFirewallRule -Name $rule.Name -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName 
    }
}
