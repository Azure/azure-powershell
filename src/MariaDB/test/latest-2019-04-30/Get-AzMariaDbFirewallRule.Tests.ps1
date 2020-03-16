$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$utilsPath = Join-Path $PSScriptRoot '..\utils.ps1'
. ($loadEnvPath)
. ($utilsPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMariaDbFirewallRule.Recording.json'
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
Add-AzMariaDbFirewallRule -Name $firewallName01 -ResourceGroupName $env.ResourceGroupGet -ServerName $env.rstr02 -EndIPAddress $endIPAddress -StartIPAddress $startIPAddress
Add-AzMariaDbFirewallRule -Name $firewallName02 -ResourceGroupName $env.ResourceGroupGet -ServerName $env.rstr02 -EndIPAddress $endIPAddress -StartIPAddress $startIPAddress

Describe 'Get-AzMariaDbFirewallRule' {
    It 'List' {
        $mariaDbFirewall = Get-AzMariaDbFirewallRule -ResourceGroupName $env.ResourceGroupGet -ServerName $env.rstr02
        $mariaDbFirewall.Count | Should -Be 2   
    }

    It 'Get' {
        $mariaDbFirewall = Get-AzMariaDbFirewallRule -Name $firewallName01 -ResourceGroupName $env.ResourceGroupGet -ServerName $env.rstr02
        $mariaDbFirewall.Name | Should -Be $firewallName01
    }

    It 'GetViaIdentity' -Skip {
        $mariaDb = Get-AzMariaDbServer -Name $env.rstr02 -ResourceGroupName $env.ResourceGroupGet
        $mariaDbFirewall = Get-AzMariaDbFirewallRule -InputObject $mariaDb
        $mariaDbFirewall.Count | Should -Be 2
    }
}
