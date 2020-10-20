$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMariaDbFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzMariaDbFirewallRule' {
    It 'CreateExpanded' {
       $firewallName = 'frname-001' 
       $endIPAddress = '0.0.2.125'
       $startIPAddress = '0.0.2.1'
       New-AzMariaDbFirewallRule -Name $firewallName -ResourceGroupName $env.ResourceGroup -ServerName $env.rstrbc02 -EndIPAddress $endIPAddress -StartIPAddress $startIPAddress
       $mariaDbFirewall = Get-AzMariaDbFirewallRule -Name $firewallName -ResourceGroupName $env.ResourceGroup -ServerName $env.rstrbc02
       $mariaDbFirewall.Name | Should -Be $firewallName 
    }
}
