$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzPostgreSqlVirtualNetworkRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzPostgreSqlVirtualNetworkRule' {
    It 'Delete' {
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/PostgreSqlVnet/subnets/MysqlSubnet1"
        New-AzPostgreSqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -SubnetId $ID
        {
            Remove-AzPostgreSqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup-ServerName $env.serverName
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -Skip {
        $VnetID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/PostgreSqlVnet/subnets/MysqlSubnet1"
        New-AzPostgreSqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -SubnetId $VnetID
        $RuleID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforPostgreSQL/servers/$($env.serverName)/virtualNetworkRules/$($env.VNetName)"
        {
            Remove-AzPostgreSqlVirtualNetworkRule -InputObject $RuleID
        } | Should -Not -Throw
    }
}
