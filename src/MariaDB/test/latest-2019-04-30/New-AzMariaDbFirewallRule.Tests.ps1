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

$mariaDbParam01 = @{SkuName='B_Gen5_1'}
$mariadbTest01 = GetOrCreateMariaDb -mariaDb $mariaDbParam01 -ResourceGroup $env.resourceGroup

Describe 'New-AzMariaDbFirewallRule' {
    It 'CreateExpanded' {
       $firewallName = 'fr-test01'
       $endIPAddress = '0.0.2.125'
       $startIPAddress = '0.0.2.1'
       New-AzMariaDbFirewallRule -Name $firewallName -ResourceGroupName $env.ResourceGroup -ServerName $mariadbTest01.Name -EndIPAddress $endIPAddress -StartIPAddress $startIPAddress
       $mariaDbFirewall = Get-AzMariaDbFirewallRule -Name $firewallName -ResourceGroupName $env.ResourceGroup -ServerName $mariadbTest01.Name
       $mariaDbFirewall.Name | Should -Be $firewallName 
    }
}
