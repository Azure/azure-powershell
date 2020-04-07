$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMariaDbFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzMariaDbFirewallRule' {
    It 'UpdateExpanded' {
        $newEndIPAddress = '0.0.255.125'
        $newStartIPAddress = '0.0.255.1'
        Update-AzMariaDbFirewallRule -Name $env.firewallName01 -ResourceGroupName $env.ResourceGroup -ServerName $env.rstrbc02 -EndIPAddress $newEndIPAddress -StartIPAddress $newStartIPAddress
        $newfirewallRule = Get-AzMariaDbFirewallRule -Name $env.firewallName01 -ResourceGroupName $env.ResourceGroup -ServerName $env.rstrbc02
        $newfirewallRule.EndIPAddress | Should -Be $newEndIPAddress
        $newfirewallRule.StartIPAddress | Should -Be $newStartIPAddress
    }
}
