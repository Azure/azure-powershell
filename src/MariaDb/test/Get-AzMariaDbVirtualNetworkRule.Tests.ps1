$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMariaDbVirtualNetworkRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMariaDbVirtualNetworkRule' {
    It 'List' {
        $mariaDbVnet = Get-AzMariaDbVirtualNetworkRule -ResourceGroupName $env.ResourceGroup -ServerName $env.rstrgp02
        $mariaDbVnet.Count | Should -Be 2
    }

    It 'Get' {
        $mariaDbVnet = Get-AzMariaDbVirtualNetworkRule -Name $env.vnetRuleName01 -ResourceGroupName $env.ResourceGroup -ServerName $env.rstrgp02
        $mariaDbVnet.Name | Should -Be $env.vnetRuleName01
    }
}
