$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$utilsPath = Join-Path $PSScriptRoot '..\utils.ps1'
. ($loadEnvPath)
. ($utilsPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMariaDbFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

$firewallName01 = 'fr-' + (RandomString -allChars $false -len 6)
$firewallName02 = 'fr-' + (RandomString -allChars $false -len 6)
$endIPAddress = '0.0.0.125'
$startIPAddress = '0.0.0.1'
$serverName = $env.rstr01
Add-AzMariaDbFirewallRule -Name $firewallName01 -ResourceGroupName $env.ResourceGroupGet -ServerName $serverName -EndIPAddress $endIPAddress -StartIPAddress $startIPAddress
Add-AzMariaDbFirewallRule -Name $firewallName02 -ResourceGroupName $env.ResourceGroupGet -ServerName $serverName -EndIPAddress $endIPAddress -StartIPAddress $startIPAddress
Describe 'Remove-AzMariaDbFirewallRule' {
    It 'Delete' -skip {
        Remove-AzMariaDBFirewallRule -Name $firewallName01 -ResourceGroupName $env.ResourceGroupGet -ServerName $serverName
        $firewallRule = Get-AzMariaDbFirewallRule -ServerName $serverName -ResourceGroupName $env.ResourceGroupGet
        $firewallRule.Name | Should -Not -Contain $firewallName01
    }

    It 'DeleteViaIdentity' -skip {
        $mariaDb = Get-AzMariaDbServer -Name $serverName -ResourceGroupName $env.ResourceGroupGet
        Remove-AzMariaDbFirewallRule -InputObject $mariaDb
        $firewallRule = Get-AzMariaDbFirewallRule -ServerName $serverName -ResourceGroupName $env.ResourceGroupGet
        $firewallRule.Name | Should -BeNullOrEmpty
    }
}
