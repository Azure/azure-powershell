$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPostgreSqlVirtualNetworkRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzPostgreSqlVirtualNetworkRule' {
    It 'List' {
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/PostgreSqlVnet/subnets/MysqlSubnet1"
        New-AzPostgreSqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -SubnetId $ID
        $rule = Get-AzPostgreSqlVirtualNetworkRule -ResourceGroupName $env.resourceGroup -ServerName $env.serverName 
        $rule.Count | Should -Be 1
        Remove-AzPostgreSqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup-ServerName $env.serverName
    }

    It 'Get' {
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/PostgreSqlVnet/subnets/MysqlSubnet1"
        New-AzPostgreSqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -SubnetId $ID
        $rule = Get-AzPostgreSqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
        $rule.VirtualNetworkSubnetId | Should -Be $ID
        Remove-AzPostgreSqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup-ServerName $env.serverName
    }

    It 'GetViaIdentity' -Skip {
        $VnetID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/PostgreSqlVnet/subnets/MysqlSubnet1"
        New-AzPostgreSqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -SubnetId $VnetID
        $RuleID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforPostgreSQL/servers/$($env.serverName)/virtualNetworkRules/$($env.VNetName)"
        $rule = Get-AzPostgreSqlVirtualNetworkRule -InputObject $RuleID
        $rule.VirtualNetworkSubnetId | Should -Be $VnetID
        Remove-AzPostgreSqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup-ServerName $env.serverName
    }
}
