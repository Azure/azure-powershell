$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzPostgreSqlVirtualNetworkRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzPostgreSqlVirtualNetworkRule' {
    It 'UpdateExpanded' {
        $ID1 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/PostgreSqlVnet/subnets/MysqlSubnet1"
        New-AzPostgreSqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -SubnetId $ID1
        $ID2 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/PostgreSqlVnet/subnets/MysqlSubnet2"
        $rule = Update-AzPostgreSqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -SubnetId $ID2
        $rule.VirtualNetworkSubnetId | Should -Be $ID2
        Remove-AzPostgreSqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup-ServerName $env.serverName
    }

    It 'UpdateViaIdentityExpanded' -Skip {
        $SubnetID1 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/PostgreSqlVnet/subnets/MysqlSubnet1"
        New-AzPostgreSqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -SubnetId $SubnetID1
        $SubnetID2 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/PostgreSqlVnet/subnets/MysqlSubnet2"
        $VNetId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforPostgreSQL/servers/$($env.serverName)/virtualNetworkRules/$($env.VNetName)"
        $rule = Update-AzPostgreSqlVirtualNetworkRule -InputObject $VNetId -SubnetId $SubnetID2
        $rule.VirtualNetworkSubnetId | Should -Be $SubnetID2
        Remove-AzPostgreSqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup-ServerName $env.serverName
    }
}
