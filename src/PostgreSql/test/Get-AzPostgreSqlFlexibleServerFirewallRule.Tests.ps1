$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPostgreSqlFlexibleServerFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzPostgreSqlFlexibleServerFirewallRule' {
    It 'List' {
        { 
            New-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
            $rule = Get-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName 
            $rule.Count | Should -Be 1 
        } | Should -Not -Throw
    }

    It 'Get' {
        { 
            $rule = Get-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $rule.StartIPAddress | Should -Be 0.0.0.0
            $rule.EndIPAddress | Should -Be 0.0.0.1 
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { 
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSql/flexibleServers/$($env.flexibleServerName)/firewallRules/$($env.firewallRuleName)"
            $rule = Get-AzPostgreSqlFlexibleServerFirewallRule -InputObject $ID
            $rule.StartIPAddress | Should -Be 0.0.0.0
            $rule.EndIPAddress | Should -Be 0.0.0.1
            Remove-AzPostgreSqlFlexibleServerFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName 
        } | Should -Not -Throw
    }
}
