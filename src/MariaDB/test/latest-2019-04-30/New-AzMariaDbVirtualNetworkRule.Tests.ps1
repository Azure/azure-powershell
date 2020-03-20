$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$helperPath = Join-Path $PSScriptRoot '..\helper.ps1'
. ($loadEnvPath)
. ($helperPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMariaDbVirtualNetworkRule.Recording.json'
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
Describe 'New-AzMariaDbVirtualNetworkRule' {
    It 'CreateExpanded' {
        $vnetRuleName = 'vnetrule-' + (RandomLetters -len 6)
        $serverName = $mariadbTest01.Name
        New-AzMariaDbVirtualNetworkRule -ServerName $serverName -ResourceGroupName $env.ResourceGroup -Name $vnetRuleName -SubnetId $vnetobj.Subnets[0].id -IgnoreMissingVnetServiceEndpoint
        $mariaDbVnet = Get-AzMariaDbVirtualNetworkRule -Name $vnetRuleName -ResourceGroupName $env.ResourceGroup -ServerName $serverName
        $mariaDbVnet.Name | Should -Be $vnetRuleName
    }
}

