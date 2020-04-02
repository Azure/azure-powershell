$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMySqlVirtualNetworkRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzMySqlVirtualNetworkRule' {
    It 'UpdateExpanded' -skip {
        $ID1 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/MySqlVNet/subnets/MysqlSubnet1"
        New-AzMySqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -VirtualNetworkSubnetId $ID1
        $ID2 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/MySqlVNet/subnets/MysqlSubnet2"
        $rule = Update-AzMySqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -VirtualNetworkSubnetId $ID2
        $rule.Count | Should Be 1
        Remove-AzMySqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup-ServerName $env.serverName
    }

    It 'UpdateViaIdentityExpanded' -skip {
        $SubnetID1 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/MySqlVNet/subnets/MysqlSubnet1"
        New-AzMySqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -VirtualNetworkSubnetId $SubnetID1
        $SubnetID2 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/MySqlVNet/subnets/MysqlSubnet2"
        $VNetId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforMySQL/servers/$($env.serverName)/virtualNetworkRules/$($env.VNetName)"
        $rule = Update-AzMySqlVirtualNetworkRule -InputObject $VNetId -VirtualNetworkSubnetId $SubnetID2
        $rule.Count | Should Be 1
        Remove-AzMySqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup-ServerName $env.serverName
    }
}
