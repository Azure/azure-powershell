$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPostgreSqlFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzPostgreSqlFirewallRule' {
    It 'List' {
        New-AzPostgreSqlFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
        $rule = Get-AzPostgreSqlFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.serverName 
        $rule.Count | Should -Be 1
        Remove-AzPostgreSqlFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
    }

    It 'Get' {
        New-AzPostgreSqlFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
        $rule = Get-AzPostgreSqlFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
        $rule.StartIPAddress | Should -Be 0.0.0.0
        $rule.EndIPAddress | Should -Be 0.0.0.1
        Remove-AzPostgreSqlFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
    }

    It 'GetViaIdentity' -Skip {
        New-AzPostgreSqlFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforPostgreSQL/servers/$($env.serverName)/firewallRules/$($env.firewallRuleName)"
        $rule = Get-AzPostgreSqlFirewallRule -InputObject $ID
        $rule.StartIPAddress | Should -Be 0.0.0.0
        $rule.EndIPAddress | Should -Be 0.0.0.1
        Remove-AzPostgreSqlFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
    }
}
