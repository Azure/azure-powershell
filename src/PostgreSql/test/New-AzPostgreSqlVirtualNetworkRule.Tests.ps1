$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPostgreSqlVirtualNetworkRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzPostgreSqlVirtualNetworkRule' {
    It 'CreateExpanded' {
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/PostgreSqlVnet/subnets/MysqlSubnet1"
        $vnetRule = New-AzPostgreSqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -SubnetId $ID
        $vnetRule.VirtualNetworkSubnetId | Should -Be $ID
        $vnetRule.Name | Should -Be $env.VNetName
        Remove-AzPostgreSqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup-ServerName $env.serverName 
    }
}
