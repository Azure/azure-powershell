$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$helperPath = Join-Path $PSScriptRoot '..\helper.ps1'
. ($loadEnvPath)
. ($helperPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMariaDbFirewallRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

$mariaDbParam01 = @{SkuName='B_Gen5_1'}
$mariadbTest01 = GetOrCreateMariaDb -mariaDb $mariaDbParam01 -ResourceGroup $env.resourceGroup
$firewallName01 = 'fr-' + (RandomString -allChars $false -len 6)
$firewallName02 = 'fr-' + (RandomString -allChars $false -len 6)
$endIPAddress = '0.0.0.125'
$startIPAddress = '0.0.0.1'
New-AzMariaDbFirewallRule -Name $firewallName01 -ResourceGroupName $env.ResourceGroup -ServerName $mariadbTest01.Name -EndIPAddress $endIPAddress -StartIPAddress $startIPAddress
New-AzMariaDbFirewallRule -Name $firewallName02 -ResourceGroupName $env.ResourceGroup -ServerName $mariadbTest01.Name -EndIPAddress $endIPAddress -StartIPAddress $startIPAddress

Describe 'Remove-AzMariaDbFirewallRule' {
    It 'Delete' {
        Remove-AzMariaDBFirewallRule -Name $firewallName01 -ResourceGroupName $env.ResourceGroup -ServerName $mariadbTest01.Name
        $firewallRule = Get-AzMariaDbFirewallRule -ServerName $mariadbTest01.Name -ResourceGroupName $env.ResourceGroup
        $firewallRule.Name | Should -Not -Contain $firewallName01
    }
}
