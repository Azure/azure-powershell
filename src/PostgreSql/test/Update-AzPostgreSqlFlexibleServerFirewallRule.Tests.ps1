$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzPostgreSqlFlexibleServerFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzPostgreSqlFlexibleServerFirewallRule' {
    It 'UpdateExpanded' {
        New-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
        $rule = Update-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -EndIPAddress 0.0.0.3 -StartIPAddress 0.0.0.2
        $rule.StartIPAddress | Should -Be 0.0.0.2
        $rule.EndIPAddress | Should -Be 0.0.0.3
    }

    It 'ClientIPAddress' {
        $rule = Update-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -ClientIPAddress 0.0.0.2
        $rule.StartIPAddress | Should -Be 0.0.0.2
        $rule.EndIPAddress | Should -Be 0.0.0.2
    }

    It 'UpdateViaIdentityExpanded' {
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSql/flexibleServers/$($env.flexibleServerName)/firewallRules/$($env.firewallRuleName)"
        $rule = Update-AzPostgreSqlFlexibleServerFirewallRule -InputObject $ID -EndIPAddress 0.0.0.5 -StartIPAddress 0.0.0.4
        $rule.StartIPAddress | Should -Be 0.0.0.4
        $rule.EndIPAddress | Should -Be 0.0.0.5
    }

    It 'ClientIPAddressViaIdentity' {
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSql/flexibleServers/$($env.flexibleServerName)/firewallRules/$($env.firewallRuleName)"
        $rule = Update-AzPostgreSqlFlexibleServerFirewallRule -InputObject $ID -ClientIPAddress 0.0.0.9
        $rule.StartIPAddress | Should -Be 0.0.0.9
        $rule.EndIPAddress | Should -Be 0.0.0.9
    }
}
