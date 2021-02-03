$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzPostgreSqlFlexibleServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName


$DEFAULT_DB_NAME = 'flexibleserverdb'
$DELEGATION_SERVICE_NAME = "Microsoft.DBforPostgreSQL/flexibleServers"
$DEFAULT_VNET_PREFIX = '10.0.0.0/16'
$DEFAULT_SUBNET_PREFIX = '10.0.0.0/24'

Describe 'AzPostgreSqlFlexibleServer' {
    It 'List1' {
        {
            $servers = Get-AzPostgreSqlFlexibleServer
            $servers.Count | Should -BeGreaterOrEqual 1  
            $servers = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup
            $servers.Count | Should -Be 1  
        } | Should -Not -Throw
    }

    It 'ViaName'  {
        {
            $servers = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
            $servers.Name | Should -Be $env.flexibleServerName
            
            $server = Update-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName -BackupRetentionDay 12 
            $server.StorageProfileBackupRetentionDay | Should -Be 12
            
            Stop-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
            
            Start-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
            
            Restart-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        
            $replica = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName | New-AzPostgreSqlFlexibleServerReplica -Replica $env.replicaName -ResourceGroupName $env.resourceGroup 
            $replica.Name | Should -Be $env.replicaName
            $replica.SkuName | Should -Be $env.flexibleSku

            Remove-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.replicaName
        
        } | Should -Not -Throw
    }

    It 'ViaIdentity' {
        {
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSql/flexibleServers/$($env.flexibleServerName)"
            $server = Get-AzPostgreSqlFlexibleServer -InputObject $ID
            $server.Name | Should -Be $env.flexibleServerName

            $server = Update-AzPostgreSqlFlexibleServer -InputObject $server -StorageInMb 20480
            $server.StorageProfileStorageMb  | Should -Be 20480

            $server = Update-AzPostgreSqlFlexibleServer -InputObject $server -SkuTier GeneralPurpose -Sku Standard_D2ds_v4
            $server.SkuTier | Should -Be 'GeneralPurpose'
            $server.SkuName | Should -Be 'Standard_D2ds_v4'

            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSql/flexibleServers/$($env.flexibleServerName)/stop"
            Stop-AzPostgreSqlFlexibleServer -InputObject $ID
            
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSql/flexibleServers/$($env.flexibleServerName)/start"
            Start-AzPostgreSqlFlexibleServer -InputObject $ID
            
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSql/flexibleServers/$($env.flexibleServerName)/restart"
            Restart-AzPostgreSqlFlexibleServer -InputObject $ID
            
            $restorePointInTime = (Get-Date).AddMinutes(-10)
            $restoredServer = Restore-AzPostgreSqlFlexibleServer -SourceServerName $env.flexibleServerName -Location $env.location -Name $env.restoreName -ResourceGroupName $env.resourceGroup -RestorePointInTime $restorePointInTime
            
            Remove-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $restoredServer

        } | Should -Not -Throw
    }
    function WaitServerDelete(){
        if ($TestMode -eq 'live' -or $TestMode -eq 'record') {
            Start-Sleep -Seconds 450
        }
    }
    function ValidateSubnetVnet($Server, $VnetName, $SubnetName){
        $Vnet = Get-AzVirtualNetwork -Name $VNetName -ResourceGroupName $env.resourceGroup
        $Subnet = Get-AzVirtualNetworkSubnetConfig -Name $SubnetName -VirtualNetwork $Vnet
            
        $Server.DelegatedSubnetArgumentSubnetArmResourceId | Should -Be $Subnet.Id
        $Delegation = Get-AzDelegation -Name Microsoft.DBforMySQL/flexibleServers -Subnet $Subnet
        $Delegation.ServiceName | Should -Be $DELEGATION_SERVICE_NAME
    }
    
    function RemoveServerVnet($ServerName, $VnetName, $SubnetName){
        $Vnet = Get-AzVirtualNetwork -Name $VNetName -ResourceGroupName $env.resourceGroup
        $Subnet = Get-AzVirtualNetworkSubnetConfig -Name $SubnetName -VirtualNetwork $Vnet

        Remove-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $ServerName
        WaitServerDelete
        $Subnet = Remove-AzDelegation -Name $DELEGATION_SERVICE_NAME -Subnet $Subnet
        Set-AzVirtualNetwork -VirtualNetwork $Vnet
        Remove-AzVirtualNetwork -Name $Vnet.Name -ResourceGroupName $env.resourceGroup -Force
    }

    It 'NoArgumentsScenario' {
        {
            if ($TestMode -eq 'live' -or $TestMode -eq 'record') {
                $Server = New-AzPostgreSqlFlexibleServer -Location $env.location
                $Server | Get-Member
                $Splits = $Server.Id -Split "/" 
                $ResourceGroupName = $Splits[4]
                $SubnetName = 'Subnet' + $Server.Name
                $VnetName = 'VNET' + $Server.Name
                $Vnet = Get-AzVirtualNetwork -Name $VnetName -ResourceGroupName $ResourceGroupName
                $Subnet = Get-AzVirtualNetworkSubnetConfig -Name $SubnetName -VirtualNetwork $Vnet

                $Server.SkuName | Should -Be "Standard_B1ms"
                $Server.SkuTier | Should -Be "Burstable"
                $Server.StorageProfileStorageMb | Should -Be 10240
                $Server.StorageProfileBackupRetentionDay | Should -Be 7

                $Vnet = Get-AzVirtualNetwork -Name $VNetName -ResourceGroupName $ResourceGroupName
                $Subnet = Get-AzVirtualNetworkSubnetConfig -Name $SubnetName -VirtualNetwork $Vnet
                    
                $Server.DelegatedSubnetArgumentSubnetArmResourceId | Should -Be $Subnet.Id
                $Delegation = Get-AzDelegation -Name Microsoft.DBforMySQL/flexibleServers -Subnet $Subnet
                $Delegation.ServiceName | Should -Be $DELEGATION_SERVICE_NAME

                Remove-AzPostgreSqlFlexibleServer -ResourceGroupName $ResourceGroupName -Name $Server.Name
                WaitServerDelete
                $Subnet = Remove-AzDelegation -Name $DELEGATION_SERVICE_NAME -Subnet $Subnet
                Set-AzVirtualNetwork -VirtualNetwork $Vnet
                Remove-AzVirtualNetwork -Name $Vnet.Name -ResourceGroupName $ResourceGroupName -Force
                Remove-AzResourceGroup -Name $ResourceGroupName -Force
            }
        } | Should -Not -Throw
    }

    It 'PublicAccessScenario-FirewallRule' {
        {
            if ($TestMode -eq 'live' -or $TestMode -eq 'record') {
                # Public Access 10.10.10.10-10.10.10.12
                New-AzPostgreSqlFlexibleServer -Location $env.location -ResourceGroupName $env.resourceGroup -Name $env.serverName3 -PublicAccess 10.10.10.10-10.10.10.12
                $FirewallRules = Get-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.serverName3
                $FirewallRules[0].Name | Should -BeLike "FirewallIPAddress*"
                $FirewallRules[0].StartIPAddress | Should -Be "10.10.10.10"
                $FirewallRules[0].EndIPAddress | Should -Be "10.10.10.12"
                Remove-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.serverName3
                WaitServerDelete
            }
        } | Should -Not -Throw
    }

    
    It 'VnetSubnetScenario-ValidVnetSubnetNotExist' {
        {
            if ($TestMode -eq 'live' -or $TestMode -eq 'record') {
                # vnet name and subnet name resource do not exist
                $Server = New-AzPostgreSqlFlexibleServer -Location $env.location -Name $env.serverName3 -ResourceGroupName $env.resourceGroup -Vnet $env.VNetName -Subnet $env.SubnetName -VnetPrefix $DEFAULT_VNET_PREFIX -SubnetPrefix $DEFAULT_SUBNET_PREFIX
                
                ValidateSubnetVnet $Server $env.VNetName $env.SubnetName
                Remove-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.serverName3
            }
        } | Should -Not -Throw
    }

    It 'VnetSubnetScenario-ValidVnetSubnet' {
        {
            if ($TestMode -eq 'live' -or $TestMode -eq 'record') {
                # vnet name and subnet name, resource exist
                $Server = New-AzPostgreSqlFlexibleServer -Location $env.location -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -Vnet $env.VNetName -Subnet $env.SubnetName
            
                ValidateSubnetVnet $Server $env.VNetName $env.SubnetName
                RemoveServerVnet $env.serverName2 $env.VNetName $env.SubnetName
            }
        } | Should -Not -Throw
    }


}
