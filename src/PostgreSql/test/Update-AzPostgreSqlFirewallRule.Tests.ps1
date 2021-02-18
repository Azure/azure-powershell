$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzPostgreSqlFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzPostgreSqlFirewallRule' {
    It 'ClientIPAddress' {
        New-AzPostgreSqlFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
        $rule = Update-AzPostgreSqlFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -ClientIPAddress 0.0.0.2
        $rule.StartIPAddress | Should -Be 0.0.0.2
        $rule.EndIPAddress | Should -Be 0.0.0.2
        Remove-AzPostgreSqlFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
    }

    It 'UpdateViaIdentityExpanded' {
        New-AzPostgreSqlFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSQL/servers/$($env.serverName)/firewallRules/$($env.firewallRuleName)"
        $rule = Update-AzPostgreSqlFirewallRule -InputObject $ID -EndIPAddress 0.0.0.3 -StartIPAddress 0.0.0.2
        $rule.StartIPAddress | Should -Be 0.0.0.2
        $rule.EndIPAddress | Should -Be 0.0.0.3
        Remove-AzPostgreSqlFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
    }
}
