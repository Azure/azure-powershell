$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$utilsPath = Join-Path $PSScriptRoot '..\utils.ps1'
. ($loadEnvPath)
. ($utilsPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMariaDbFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

$firewallName01 = 'fr-' + (RandomString -allChars $false -len 6)
$endIPAddress = '0.0.0.125'
$startIPAddress = '0.0.0.1'
$serverName = $env.rstr01
Add-AzMariaDbFirewallRule -Name $firewallName01 -ResourceGroupName $env.ResourceGroupGet -ServerName $serverName -EndIPAddress $endIPAddress -StartIPAddress $startIPAddress
Describe 'Update-AzMariaDbFirewallRule' {
    It 'UpdateExpanded' {
        $newEndIPAddress = '0.0.255.125'
        $newStartIPAddress = '0.0.255.1'
        Update-AzMariaDbFirewallRule -Name $firewallName01 -ResourceGroupName $env.ResourceGroupGet -ServerName $serverName -EndIPAddress $newEndIPAddress -StartIPAddress $newnewStartIPAddress
        $newfirewallRule = Get-AzMariaDbFirewallRule -Name $firewallName01 -ResourceGroupName $env.ResourceGroupGet -ServerName $serverName
        $newfirewallRule.EndIPAddress | Should -Be $newEndIPAddress
        $newfirewallRule.StartIPAddress | Should -Be $newStartIPAddress
    }

    It 'UpdateViaIdentityExpanded' -Skip {
        $mariadb = Get-AzMariaDbServer -Name $mariadb.Name -ResourceGroupName $env.ResourceGroupGet
        $newEndIPAddress = '0.0.0.125'
        $newStartIPAddress = '0.0.0.1'
        Update-AzMariaDbFirewallRule -InputObject $mariadb  -EndIPAddress $newEndIPAddress -StartIPAddress $newStartIPAddress
        $newfirewallRule = Get-AzMariaDbFirewallRule -Name $firewallName01 -ResourceGroupName $env.ResourceGroupGet -ServerName $serverName
        $newfirewallRule.EndIPAddress | Should -Be $newEndIPAddress
        $newfirewallRule.StartIPAddress | Should -Be $newStartIPAddress
    }
}
