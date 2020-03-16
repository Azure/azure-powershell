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
    It 'CreateExpanded' -Skip {
        $serverName = 'mariadb-test-' + $env.rstr12
        $newfirewallRulleName = $env.rstr12 + '-firewall-test01'
        $endIPAddress = '167.224.225.116'
        $startIPAddress = '167.224.225.0'
        $firewallRulleName = New-AzMariaDbFirewallRule -Name $newfirewallRulleName -ServerName $serverName 
                            -ResourceGroupName $env.ResourceGroup -EndIPAddress $endIPAddress -StartIPAddress $startIPAddress
        $firewallRulleName.Name | Should -Be $newfirewallRulleName
    }
}
