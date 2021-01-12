$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMySqlFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzMySqlFirewallRule' {
    It 'Delete' {
        { 
            New-AzMySqlFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
            Remove-AzMySqlFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName 
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { 
            New-AzMySqlFirewallRule -Name $env.firewallRuleName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForMySQL/servers/$($env.serverName)/firewallRules/$($env.firewallRuleName)"
            Remove-AzMySqlFirewallRule -InputObject $ID 
        } | Should -Not -Throw
    }
}
