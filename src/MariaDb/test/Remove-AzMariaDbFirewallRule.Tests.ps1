$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMariaDbFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzMariaDbFirewallRule' {
    It 'Delete' {
        Remove-AzMariaDBFirewallRule -Name $env.firewallName01 -ResourceGroupName $env.ResourceGroup -ServerName $env.rstrbc02
        $firewallRule = Get-AzMariaDbFirewallRule -ServerName $env.rstrbc02 -ResourceGroupName $env.ResourceGroup
        $firewallRule.Name | Should -Not -Contain $env.firewallName01
    }
}
