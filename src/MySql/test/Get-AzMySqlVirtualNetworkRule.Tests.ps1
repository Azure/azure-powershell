$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMySqlVirtualNetworkRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMySqlVirtualNetworkRule' {
    It 'List' {
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/MySqlVNet/subnets/MysqlSubnet1"
        New-AzMySqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -SubnetId $ID
        $rule = Get-AzMySqlVirtualNetworkRule -ResourceGroupName $env.resourceGroup -ServerName $env.serverName 
        $rule.Count | Should -Be 1
        Remove-AzMySqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup-ServerName $env.serverName
    }

    It 'Get' {
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/MySqlVNet/subnets/MysqlSubnet1"
        New-AzMySqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -SubnetId $ID
        $rule = Get-AzMySqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
        $rule.VirtualNetworkSubnetId | Should -Be $ID
        Remove-AzMySqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup-ServerName $env.serverName
    }

    It 'GetViaIdentity' {
        $VnetID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/MySqlVNet/subnets/MysqlSubnet1"
        New-AzMySqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -SubnetId $VnetID
        $RuleID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforMySQL/servers/$($env.serverName)/virtualNetworkRules/$($env.VNetName)"
        $rule = Get-AzMySqlVirtualNetworkRule -InputObject $RuleID
        $rule.VirtualNetworkSubnetId | Should -Be $VnetID
        Remove-AzMySqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup-ServerName $env.serverName
    }
}
