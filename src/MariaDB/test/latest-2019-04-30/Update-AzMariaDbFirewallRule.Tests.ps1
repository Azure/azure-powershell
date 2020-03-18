$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$helperPath = Join-Path $PSScriptRoot '..\helper.ps1'
. ($loadEnvPath)
. ($helperPath)
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
$rstr01 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
$administratorLoginPassword =  ConvertTo-SecureString $env.AdminLoginPassword -AsPlainText -Force 
$mariadb = New-AzMariaDBServer -Name $rstr01 -ResourceGroupName $env.ResourceGroup -AdministratorLogin $env.AdminLogin -AdministratorLoginPassword $administratorLoginPassword -Location $env.Location
New-AzMariaDbFirewallRule -Name $firewallName01 -ResourceGroupName $env.ResourceGroup -ServerName $rstr01 -EndIPAddress $endIPAddress -StartIPAddress $startIPAddress

Describe 'Update-AzMariaDbFirewallRule' {
    It 'UpdateExpanded' {
        $newEndIPAddress = '0.0.255.125'
        $newStartIPAddress = '0.0.255.1'
        Update-AzMariaDbFirewallRule -Name $firewallName01 -ResourceGroupName $env.ResourceGroup -ServerName $rstr01 -EndIPAddress $newEndIPAddress -StartIPAddress $newStartIPAddress
        $newfirewallRule = Get-AzMariaDbFirewallRule -Name $firewallName01 -ResourceGroupName $env.ResourceGroup -ServerName $rstr01
        $newfirewallRule.EndIPAddress | Should -Be $newEndIPAddress
        $newfirewallRule.StartIPAddress | Should -Be $newStartIPAddress
    }
}
