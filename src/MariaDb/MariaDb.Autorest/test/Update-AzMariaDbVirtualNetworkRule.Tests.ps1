$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMariaDbVirtualNetworkRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzMariaDbVirtualNetworkRule' {
    It 'UpdateExpanded' {
        $serverName = $env.rstrgp02
        Update-AzMariaDbVirtualNetworkRule -ServerName $serverName -ResourceGroupName $env.ResourceGroup -Name $env.vnetRuleName02 -SubnetId $env.subnet03 -IgnoreMissingVnetServiceEndpoint
        $mariaDbVnet = Get-AzMariaDbVirtualNetworkRule -Name $env.vnetRuleName02 -ResourceGroupName $env.ResourceGroup -ServerName $serverName
        $mariadbvnet.VirtualNetworkSubnetId | Should -Be $env.subnet03
    }
}