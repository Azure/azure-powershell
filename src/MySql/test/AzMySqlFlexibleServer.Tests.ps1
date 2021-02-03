$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzMySqlFlexibleServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName


$DEFAULT_DB_NAME = 'flexibleserverdb'
$DELEGATION_SERVICE_NAME = "Microsoft.DBforMySQL/flexibleServers"
$DEFAULT_VNET_PREFIX = '10.0.0.0/16'
$DEFAULT_SUBNET_PREFIX = '10.0.0.0/24'

Describe 'AzMySqlFlexibleServer' {
    # It 'List1' {
    #     {
    #         $servers = Get-AzMySqlFlexibleServer
    #         $servers.Count | Should -BeGreaterOrEqual 1  
    #         $servers = Get-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup
    #         $servers.Count | Should -Be 1  
    #     } | Should -Not -Throw
    # }

    # It 'ViaName'  {
    #     {
    #         $servers = Get-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
    #         $servers.Name | Should -Be $env.flexibleServerName
            
    #         $server = Update-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName -BackupRetentionDay 12 
    #         $server.StorageProfileBackupRetentionDay | Should -Be 12
            
    #         Stop-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
            
    #         Start-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
            
    #         Restart-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        
    #         $replica = Get-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName | New-AzMySqlFlexibleServerReplica -Replica $env.replicaName -ResourceGroupName $env.resourceGroup 
    #         $replica.Name | Should -Be $env.replicaName
    #         $replica.SkuName | Should -Be $env.flexibleSku

    #         $replica = Get-AzMySqlFlexibleServerReplica -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
    #         $replica.Count | Should -Be 1

    #         Remove-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.replicaName
        
    #     } | Should -Not -Throw
    # }

    It 'ViaIdentity' {
        {
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForMySql/flexibleServers/$($env.flexibleServerName)"
            $server = Get-AzMySqlFlexibleServer -InputObject $ID
            $server.Name | Should -Be $env.flexibleServerName

            $server = Update-AzMySqlFlexibleServer -InputObject $server -StorageInMb 20480
            $server.StorageProfileStorageMb  | Should -Be 20480

            $server = Update-AzMySqlFlexibleServer -InputObject $server -SkuTier GeneralPurpose -Sku Standard_D2ds_v4
            $server.SkuTier | Should -Be 'GeneralPurpose'
            $server.SkuName | Should -Be 'Standard_D2ds_v4'

    #         $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForMySql/flexibleServers/$($env.flexibleServerName)/stop"
    #         Stop-AzMySqlFlexibleServer -InputObject $ID
            
    #         $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForMySql/flexibleServers/$($env.flexibleServerName)/start"
    #         Start-AzMySqlFlexibleServer -InputObject $ID
            
    #         $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForMySql/flexibleServers/$($env.flexibleServerName)/restart"
    #         Restart-AzMySqlFlexibleServer -InputObject $ID
            
    #         $restorePointInTime = (Get-Date).AddMinutes(-10)
    #         $restoredServer = Restore-AzMySqlFlexibleServer -Name $env.restoreName -ResourceGroupName $env.resourceGroup -RestorePointInTime $restorePointInTime -InputObject $server
            
    #         Remove-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $restoredServer

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

        Remove-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $ServerName
        WaitServerDelete
        $Subnet = Remove-AzDelegation -Name $DELEGATION_SERVICE_NAME -Subnet $Subnet
        Set-AzVirtualNetwork -VirtualNetwork $Vnet
        Remove-AzVirtualNetwork -Name $Vnet.Name -ResourceGroupName $env.resourceGroup -Force
    }

    # It 'NoArgumentsScenario' {
    #     {
    #         if ($TestMode -eq 'live' -or $TestMode -eq 'record') {
    #             $Server = New-AzMySqlFlexibleServer -Location $env.location
    #             $Server | Get-Member
    #             $Splits = $Server.Id -Split "/" 
    #             $ResourceGroupName = $Splits[4]
    #             $SubnetName = 'Subnet' + $Server.Name
    #             $VnetName = 'VNET' + $Server.Name
    #             $Vnet = Get-AzVirtualNetwork -Name $VnetName -ResourceGroupName $ResourceGroupName
    #             $Subnet = Get-AzVirtualNetworkSubnetConfig -Name $SubnetName -VirtualNetwork $Vnet

    #             $Server.SkuName | Should -Be "Standard_B1ms"
    #             $Server.SkuTier | Should -Be "Burstable"
    #             $Server.StorageProfileStorageMb | Should -Be 10240
    #             $Server.StorageProfileBackupRetentionDay | Should -Be 7

    #             $Vnet = Get-AzVirtualNetwork -Name $VNetName -ResourceGroupName $ResourceGroupName
    #             $Subnet = Get-AzVirtualNetworkSubnetConfig -Name $SubnetName -VirtualNetwork $Vnet
                    
    #             $Server.DelegatedSubnetArgumentSubnetArmResourceId | Should -Be $Subnet.Id
    #             $Delegation = Get-AzDelegation -Name Microsoft.DBforMySQL/flexibleServers -Subnet $Subnet
    #             $Delegation.ServiceName | Should -Be $DELEGATION_SERVICE_NAME

    #             Remove-AzMySqlFlexibleServer -ResourceGroupName $ResourceGroupName -Name $Server.Name
    #             WaitServerDelete
    #             $Subnet = Remove-AzDelegation -Name $DELEGATION_SERVICE_NAME -Subnet $Subnet
    #             Set-AzVirtualNetwork -VirtualNetwork $Vnet
    #             Remove-AzVirtualNetwork -Name $Vnet.Name -ResourceGroupName $ResourceGroupName -Force
    #             Remove-AzResourceGroup -Name $ResourceGroupName -Force
    #         }
    #     } | Should -Not -Throw
    # }

    # It 'PublicAccessScenario-FirewallRule' {
    #     {
    #         if ($TestMode -eq 'live' -or $TestMode -eq 'record') {
    #             # Public Access 10.10.10.10-10.10.10.12
    #             New-AzMySqlFlexibleServer -Location $env.location -ResourceGroupName $env.resourceGroup -Name $env.serverName3 -PublicAccess 10.10.10.10-10.10.10.12
    #             $FirewallRules = Get-AzMySqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.serverName3
    #             $FirewallRules[0].Name | Should -BeLike "FirewallIPAddress*"
    #             $FirewallRules[0].StartIPAddress | Should -Be "10.10.10.10"
    #             $FirewallRules[0].EndIPAddress | Should -Be "10.10.10.12"
    #             Remove-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.serverName3
    #             WaitServerDelete
    #         }
    #     } | Should -Not -Throw
    # }

    
    It 'VnetSubnetScenario-ValidVnetSubnetNotExist' {
        {
            if ($TestMode -eq 'live' -or $TestMode -eq 'record') {
                # vnet name and subnet name resource do not exist
                $Server = New-AzMySqlFlexibleServer -Location $env.location -Name $env.serverName3 -ResourceGroupName $env.resourceGroup -Vnet $env.VNetName -Subnet $env.SubnetName -VnetPrefix $DEFAULT_VNET_PREFIX -SubnetPrefix $DEFAULT_SUBNET_PREFIX
                
                ValidateSubnetVnet $Server $env.VNetName $env.SubnetName
                Remove-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.serverName3
            }
        } | Should -Not -Throw
    }

    It 'VnetSubnetScenario-ValidVnetSubnet' {
        {
            if ($TestMode -eq 'live' -or $TestMode -eq 'record') {
                # vnet name and subnet name, resource exist
                $Server = New-AzMySqlFlexibleServer -Location $env.location -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -Vnet $env.VNetName -Subnet $env.SubnetName
            
                ValidateSubnetVnet $Server $env.VNetName $env.SubnetName
                RemoveServerVnet $env.serverName2 $env.VNetName $env.SubnetName
            }
        } | Should -Not -Throw
    }


}
