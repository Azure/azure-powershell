$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzPostgreSqlFlexibleServerFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzPostgreSqlFlexibleServerFirewallRule' {
        It 'Delete' {
        New-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
        Remove-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName 
    }

    It 'DeleteViaIdentity' {
        New-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSql/flexibleServers/$($env.flexibleServerName)/firewallRules/$($env.firewallRuleName)"
        Remove-AzPostgreSqlFlexibleServerFirewallRule -InputObject $ID 
    }
}
