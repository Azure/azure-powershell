$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$helperPath = Join-Path $PSScriptRoot '..\helper.ps1'
. ($loadEnvPath)
. ($helperPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMariaDbFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

$rstr01 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
$administratorLoginPassword =  ConvertTo-SecureString $env.AdminLoginPassword -AsPlainText -Force 
$mariadb = New-AzMariaDBServer -Name $rstr01 -ResourceGroupName $env.ResourceGroup -AdministratorLogin $env.AdminLogin -AdministratorLoginPassword $administratorLoginPassword -Location $env.Location

Describe 'New-AzMariaDbFirewallRule' {
    It 'CreateExpanded' {
       $firewallName = 'fr-test01'
       $endIPAddress = '0.0.0.125'
       $startIPAddress = '0.0.0.1'
       New-AzMariaDbFirewallRule -Name $firewallName -ResourceGroupName $env.ResourceGroup -ServerName $rstr01 -EndIPAddress $endIPAddress -StartIPAddress $startIPAddress
       $mariaDbFirewall = Get-AzMariaDbFirewallRule -Name $firewallName -ResourceGroupName $env.ResourceGroup -ServerName $rstr01
       $mariaDbFirewall.Name | Should -Be $firewallName 
    }
}
