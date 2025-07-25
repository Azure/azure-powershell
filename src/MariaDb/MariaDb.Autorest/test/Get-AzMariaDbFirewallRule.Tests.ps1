$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMariaDbFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMariaDbFirewallRule' {
    It 'List' {
        $serverName = $env.rstrbc02
        $mariaDbFirewall = Get-AzMariaDbFirewallRule -ResourceGroupName $env.ResourceGroup -ServerName $serverName
        $mariaDbFirewall.Count | Should -Be 2   
    }

    It 'Get' {
        $serverName = $env.rstrbc02
        $mariaDbFirewall = Get-AzMariaDbFirewallRule -Name $env.firewallName01 -ResourceGroupName $env.ResourceGroup -ServerName $serverName
        $mariaDbFirewall.Name | Should -Be $env.firewallName01
    }
}
