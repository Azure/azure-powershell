$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzPostgreSqlFlexibleServerCreateWithVnet.Recording.json'
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

Describe 'AzPostgreSqlFlexibleServerCreateWithVnet' {

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

    It 'NoArgumentsScenario' {
        If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
            {
                $Server = New-AzPostgreSqlFlexibleServer
                $Splits = $Server.Id -Split "/" 
                $ResourceGroupName = $Splits[4]
                $SubnetName = 'Subnet' + $Server.Name
                $VnetName = 'VNET' + $Server.Name
                $Vnet = Get-AzVirtualNetwork -Name $VnetName -ResourceGroupName $ResourceGroupName
                $Subnet = Get-AzVirtualNetworkSubnetConfig -Name $SubnetName -VirtualNetwork $Vnet

                $Server.SkuName | Should -Be "Standard_D2s_v3"
                $Server.SkuTier | Should -Be "GeneralPurpose"
                $Server.StorageProfileStorageMb | Should -Be 131072
                $Server.StorageProfileBackupRetentionDay | Should -Be 7
                $Server.Location | Should -Be "East US"

                $Vnet = Get-AzVirtualNetwork -Name $VNetName -ResourceGroupName $ResourceGroupName
                $Subnet = Get-AzVirtualNetworkSubnetConfig -Name $SubnetName -VirtualNetwork $Vnet
                    
                $Server.DelegatedSubnetArgumentSubnetArmResourceId | Should -Be $Subnet.Id
                $Delegation = Get-AzDelegation -Name $DELEGATION_SERVICE_NAME -Subnet $Subnet
                $Delegation.ServiceName | Should -Be $DELEGATION_SERVICE_NAME
                Remove-AzPostgreSqlFlexibleServer -ResourceGroupName $ResourceGroupName -Name $Server.Name
                WaitServerDelete
                Remove-AzVirtualNetwork -Name $Vnet.Name -ResourceGroupName $ResourceGroupName -Force
                Remove-AzResourceGroup -Name $ResourceGroupName
            } | Should -Not -Throw
        }
    }

    It 'VnetNameScenario-ValidVnet' {
        If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
            {
                # valid vnet name and the vnet exists
                $Vnet = New-AzVirtualNetwork -Name $env.VNetName -ResourceGroupName $env.resourceGroup -Location $env.location -AddressPrefix $DEFAULT_VNET_PREFIX -Force
                $Server = New-AzPostgreSqlFlexibleServer -Location $env.location -Name $env.flexibleServerName2 -ResourceGroupName $env.resourceGroup -Vnet $Vnet.Name
                
                $SubnetName = 'Subnet' + $Server.Name
                ValidateSubnetVnet $Server $env.VNetName $SubnetName
                RemoveServerVnet $env.flexibleServerName2 $env.VNetName $SubnetName
            } | Should -Not -Throw
        }
    }

    It 'VnetNameScenario-ValidVnetNotExist' {
        If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
            {
                # valid vnet name but the vnet doesn't exist
                $Server = New-AzPostgreSqlFlexibleServer -Location $env.location -Name $env.flexibleServerName3 -ResourceGroupName $env.resourceGroup -Vnet nonexistingvnetforpowershelltest
                
                $SubnetName = 'Subnet' + $Server.Name
                ValidateSubnetVnet $Server nonexistingvnetforpowershelltest $SubnetName
                RemoveServerVnet $env.flexibleServerName3 nonexistingvnetforpowershelltest $SubnetName
            } | Should -Not -Throw
        }
    }

    It 'VnetNameScenario-InvalidVnet' {
        If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
            {
                # invalid vnet name
                $InvalidName = "hi/df!@$@#$@"
                New-AzPostgreSqlFlexibleServer -Location $env.location -Name $env.flexibleServerName3 -ResourceGroupName $env.resourceGroup -Vnet $InvalidName
            } | Should -Throw
        }
    }

    It 'VnetIdScenario-ValidVnet' {
        If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
            {           
                # valid vnet Id but the vnet doesn't exist
                $VnetId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/nonexistingvnetforpowershelltest"
                $Server = New-AzPostgreSqlFlexibleServer -Location $env.location -Name $env.flexibleServerName2 -ResourceGroupName $env.resourceGroup -Vnet $VnetId

                $SubnetName = 'Subnet' + $Server.Name
                ValidateSubnetVnet $Server nonexistingvnetforpowershelltest $SubnetName
                RemoveServerVnet $env.flexibleServerName2 nonexistingvnetforpowershelltest $SubnetName
            } | Should -Not -Throw
        }
    }

    It 'VnetIdScenario-ValidVnetNotExist' {
        If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
            {
                # valid vnet Id and the vnet exists (subnet does not exist) 
                $Vnet = New-AzVirtualNetwork -Name $env.VNetName -ResourceGroupName $env.resourceGroup -Location $env.Location -AddressPrefix $DEFAULT_VNET_PREFIX -Force
                $Server = New-AzPostgreSqlFlexibleServer -Location $env.location -Name $env.flexibleServerName3 -ResourceGroupName $env.resourceGroup -Vnet $Vnet.Id
                
                $SubnetName = 'Subnet' + $Server.Name
                ValidateSubnetVnet $Server $env.VNetName $SubnetName
                RemoveServerVnet $env.flexibleServerName3 $env.VNetName $SubnetName
            } | Should -Not -Throw
        }
    }

    It 'VnetIdScenario-InvalidVnet' {
        If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
            {
                # invalid vnet Id
                $VnetId = "/subscriptions/00000-000-000000000000/resourceGroups/providers/Microsoft.Network/virtualNetworks/Vnet/Wrong/Vnet/itis"
                New-AzPostgreSqlFlexibleServer -Location $env.location -Name $env.flexibleServerName3 -ResourceGroupName $env.resourceGroup -Vnet $VnetId
            } | Should -Throw
        }
    }
    
    It 'SubnetIdScenario-ValidSubnet' {
        If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
            {
                # valid subnet Id and the subnet exists without delegation
                $Subnet = New-AzVirtualNetworkSubnetConfig -Name $env.SubnetName -AddressPrefix $DEFAULT_SUBNET_PREFIX
                New-AzVirtualNetwork -Name $env.VNetName -ResourceGroupName $env.resourceGroup -Location $env.location -AddressPrefix $DEFAULT_VNET_PREFIX -Subnet $Subnet -Force
                $SubnetId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/$($env.VNetName)" + "/subnets/$($env.SubnetName)"
                $Server = New-AzPostgreSqlFlexibleServer -Location $env.location -Name $env.flexibleServerName2 -ResourceGroupName $env.resourceGroup -Subnet $SubnetId
                
                ValidateSubnetVnet $Server $env.VNetName $env.SubnetName
                RemoveServerVnet $env.flexibleServerName2 $env.VNetName $env.SubnetName
            } | Should -Not -Throw
        }
    }

    It 'SubnetIdScenario-ValidSubnetDifferentRg' {
        If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
            {
                # valid subnet Id and the subnet exists without delegation, different resource group
                New-AzResourceGroup -Name PostgreSqlTest2 -Location $env.location -Force
                $Subnet = New-AzVirtualNetworkSubnetConfig -Name $env.SubnetName -AddressPrefix $DEFAULT_SUBNET_PREFIX
                $Vnet = New-AzVirtualNetwork -Name $env.VNetName -ResourceGroupName PostgreSqlTest2 -Location $env.location -AddressPrefix $DEFAULT_VNET_PREFIX -Subnet $Subnet -Force
                $Subnet = Get-AzVirtualNetworkSubnetConfig -Name $env.SubnetName -VirtualNetwork $Vnet
                $Server = New-AzPostgreSqlFlexibleServer -Location $env.location -Name $env.flexibleServerName3 -ResourceGroupName $env.resourceGroup -Subnet $Subnet.Id
                
                $Vnet = Get-AzVirtualNetwork -Name $env.VNetName -ResourceGroupName PostgreSqlTest2
                $Subnet = Get-AzVirtualNetworkSubnetConfig -Name $env.SubnetName -VirtualNetwork $Vnet
                    
                $Server.DelegatedSubnetArgumentSubnetArmResourceId | Should -Be $Subnet.Id
                $Delegation = Get-AzDelegation -Name Microsoft.DBforPostgreSql/flexibleServers -Subnet $Subnet
                $Delegation.ServiceName | Should -Be $DELEGATION_SERVICE_NAME            
                
                Remove-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName3
                WaitServerDelete
                Remove-AzVirtualNetwork -Name $Vnet.Name -ResourceGroupName PostgreSqlTest2 -Force
            } | Should -Not -Throw
        }
    }

    It 'SubnetIdScenario-ValidSubnetDelegation' {
        If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
            {
                # valid subnet Id and the subnet exists with delegation
                $Subnet = New-AzVirtualNetworkSubnetConfig -Name $env.SubnetName -AddressPrefix $DEFAULT_SUBNET_PREFIX
                $Vnet = New-AzVirtualNetwork -Name $env.VNetName -ResourceGroupName $env.resourceGroup -Location $env.location -AddressPrefix $DEFAULT_VNET_PREFIX -Subnet $Subnet -Force
                $Subnet = Add-AzDelegation -Name $DELEGATION_SERVICE_NAME -ServiceName $DELEGATION_SERVICE_NAME -Subnet $Subnet
                $Vnet | Set-AzVirtualNetwork
                $Subnet = Get-AzVirtualNetworkSubnetConfig -Name $env.SubnetName -VirtualNetwork $Vnet
                $Server = New-AzPostgreSqlFlexibleServer -Location $env.location -Name $env.flexibleServerName2 -ResourceGroupName $env.resourceGroup -Subnet $Subnet.Id
                
                ValidateSubnetVnet $Server $env.VNetName $env.SubnetName
                RemoveServerVnet $env.flexibleServerName2 $env.VNetName $env.SubnetName
            } | Should -Not -Throw
        }
    }

    It 'SubnetIdScenario-ValidSubnetNotExist' {
        If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
            {
                # valid subnet Id but the subnet doesn't exist
                $SubnetId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/nonexistingvnetforpowershelltest/subnets/nonexistingsubnetforpowershelltest"
                $Server = New-AzPostgreSqlFlexibleServer -Location $env.location -Name $env.flexibleServerName3 -ResourceGroupName $env.resourceGroup -Subnet $SubnetId
                
                ValidateSubnetVnet $Server nonexistingvnetforpowershelltest nonexistingsubnetforpowershelltest
                RemoveServerVnet $env.flexibleServerName3 nonexistingvnetforpowershelltest nonexistingsubnetforpowershelltest
            } | Should -Not -Throw
        }
    }

    It 'SubnetIdScenario-InvalidSubnet' {
        If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
            {
                # invalid subnet Id
                $SubnetId = "/subscriptions/00000-000-000000000000/resourceGroups/providers/Microsoft.Network/VirtualNetworks/Wrong/subnetss/wrong"
                New-AzPostgreSqlFlexibleServer -Location $env.location -Name $env.flexibleServerName3 -ResourceGroupName $env.resourceGroup -Subnet $SubnetId
            } | Should -Throw
            {
                # invalid delegation on the subnet
                $Subnet = New-AzVirtualNetworkSubnetConfig -Name $env.SubnetName -AddressPrefix $DEFAULT_SUBNET_PREFIX
                $Vnet = New-AzVirtualNetwork -Name $env.VNetName -ResourceGroupName $env.resourceGroup -Location $env.location -AddressPrefix $DEFAULT_VNET_PREFIX -Subnet $Subnet -Force
                $Subnet = Add-AzDelegation -Name "faultydelegation" -ServiceName "Microsoft.Sql/servers" -Subnet $Subnet
                Set-AzVirtualNetwork -VirtualNetwork $Vnet
                $Subnet = Get-AzVirtualNetworkSubnetConfig -Name $env.SubnetName -VirtualNetwork $Vnet
                New-AzPostgreSqlFlexibleServer -Location $env.location -Name $env.flexibleServerName3 -ResourceGroupName $env.resourceGroup -Subnet $Subnet.Id  | Should -Throw
                Remove-AzDelegation -Name "faultydelegation" -Subnet $Subnet
                Set-AzVirtualNetwork $Vnet
                Remove-AzVirtualNetwork -Name $Vnet.Name -ResourceGroupName $env.resourceGroup
            } | Should -Throw
        } 
    }

    It 'VnetSubnetScenario-ValidVnetSubnetNotExist' {
        If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
            {
                # vnet name and subnet name resource do not exist
                $Server = New-AzPostgreSqlFlexibleServer -Location $env.location -Name $env.flexibleServerName2 -ResourceGroupName $env.resourceGroup -Vnet $env.VNetName -Subnet $env.SubnetName -VnetPrefix $DEFAULT_VNET_PREFIX -SubnetPrefix $DEFAULT_SUBNET_PREFIX
                
                ValidateSubnetVnet $Server $env.VNetName $env.SubnetName
                Remove-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName2
            } | Should -Not -Throw
        }
    }
    It 'VnetSubnetScenario-ValidVnetSubnet' {
        If ($TestMode -eq 'live' -or $TestMode -eq 'record') {
            {
                # vnet name and subnet name, resource exist
                $Server = New-AzPostgreSqlFlexibleServer -Location $env.location -Name $env.flexibleServerName3 -ResourceGroupName $env.resourceGroup -Vnet $env.VNetName -Subnet $env.SubnetName
            
                ValidateSubnetVnet $Server $env.VNetName $env.SubnetName
                RemoveServerVnet $env.flexibleServerName3 $env.VNetName $env.SubnetName
            } | Should -Not -Throw
        }
    }
}
