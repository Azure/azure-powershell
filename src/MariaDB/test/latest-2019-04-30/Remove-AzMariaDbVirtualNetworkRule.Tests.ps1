$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$helperPath = Join-Path $PSScriptRoot '..\helper.ps1'
. ($loadEnvPath)
. ($helperPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMariaDbVirtualNetworkRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

$mariaDbParam01 = @{SkuName='GP_Gen5_4'}
$mariadbTest01 = GetOrCreateMariaDb -mariaDb $mariaDbParam01 -ResourceGroup $env.resourceGroup
$vnetResourceGroup = 'lucas-vnet'
$vnetName = 'vnet-01'
$vnetobj = Get-AzVirtualNetwork -ResourceGroupName $vnetResourceGroup -Name $vnetName
$vnetRuleName01 = 'vnetrule-' + (RandomLetters -len 6)
$serverName = $mariadbTest01.Name
New-AzMariaDbVirtualNetworkRule -ServerName $serverName -ResourceGroupName $env.ResourceGroup -Name $vnetRuleName01 -SubnetId $vnetobj.Subnets[1].id -IgnoreMissingVnetServiceEndpoint

Describe 'Remove-AzMariaDbVirtualNetworkRule' {
    It 'Delete' {
        Remove-AzMariaDbVirtualNetworkRule -ServerName $serverName -ResourceGroupName $env.ResourceGroup -Name $vnetRuleName01
        $mariaDbVnet = Get-AzMariaDbVirtualNetworkRule -ResourceGroupName $env.ResourceGroup -ServerName $serverName
        $mariaDbVnet.Name | Should -Not -Contain $vnetRuleName01
    }
}

