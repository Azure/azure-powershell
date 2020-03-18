$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$helperPath = Join-Path $PSScriptRoot '..\helper.ps1'
. ($loadEnvPath)
. ($helperPath)
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
$rstr01 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
$administratorLoginPassword =  ConvertTo-SecureString $env.AdminLoginPassword -AsPlainText -Force 
$mariadb = New-AzMariaDBServer -Name $rstr01 -ResourceGroupName $env.ResourceGroup -AdministratorLogin $env.AdminLogin -AdministratorLoginPassword $administratorLoginPassword -Location $env.Location
New-AzMariaDbFirewallRule -Name $firewallName01 -ResourceGroupName $env.ResourceGroup -ServerName $rstr01 -EndIPAddress $endIPAddress -StartIPAddress $startIPAddress
New-AzMariaDbFirewallRule -Name $firewallName02 -ResourceGroupName $env.ResourceGroup -ServerName $rstr01 -EndIPAddress $endIPAddress -StartIPAddress $startIPAddress

Describe 'Get-AzMariaDbFirewallRule' {
    It 'List' {
        $mariaDbFirewall = Get-AzMariaDbFirewallRule -ResourceGroupName $env.ResourceGroup -ServerName $rstr01
        $mariaDbFirewall.Count | Should -Be 2   
    }

    It 'Get' {
        $mariaDbFirewall = Get-AzMariaDbFirewallRule -Name $firewallName01 -ResourceGroupName $env.ResourceGroup -ServerName $rstr01
        $mariaDbFirewall.Name | Should -Be $firewallName01
    }
}
