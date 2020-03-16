$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Add-AzMariaDbFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Add-AzMariaDbFirewallRule' {
    It 'CreateExpanded' {
       $firewallName = 'fr-test01'
       $endIPAddress = '0.0.0.125'
       $startIPAddress = '0.0.0.1'
       Add-AzMariaDbFirewallRule -Name $firewallName -ResourceGroupName $env.ResourceGroupGet -ServerName $env.rstr01 -EndIPAddress $endIPAddress -StartIPAddress $startIPAddress
       $mariaDbFirewall = Get-AzMariaDbFirewallRule -Name $firewallName -ResourceGroupName $env.ResourceGroupGet -ServerName $env.rstr01
       $mariaDbFirewall.Name | Should -Be $firewallName 
    }
}
