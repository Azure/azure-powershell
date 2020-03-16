$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMariaDbVNetRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

$vnetName = $env.VnetName
$vnet = Get-AzVirtualNetwork -ResourceGroupName $env.ResourceGroupGet -Name $vnetName 

Describe 'Update-AzMariaDbVNetRule' {
    It 'UpdateExpanded' {
        $mariadb = Get-AzMariaDbServer -Name $env.rstr03 -ResourceGroupName $env.ResourceGroupGet
        $vnetRuleName = $env.VnetRuleName02
        Update-AzMariaDbVNetRule -ServerName $mariadb.Name -ResourceGroupName $env.ResourceGroupGet -Name vnetRuleName -SubnetId $vnet.Subnets[2].id -IgnoreMissingVnetServiceEndpoint
        $mariaDbVnet = Get-AzMariaDbVNetRule -Name $vnetRuleName -ResourceGroupName $env.ResourceGroup -ServerName $serverName
        $mariadbvnet.VirtualNetworkSubnetId | Should -Be$vnet.Subnets[2].id
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
