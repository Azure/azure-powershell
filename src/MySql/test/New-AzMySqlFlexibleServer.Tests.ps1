$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMySqlFlexibleServer.Recording.json'
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
Import-Module -Name Az.Network -RequiredVersion 3.0.0
Import-Module -Name Az.Resources -RequiredVersion 2.0.1

Describe 'New-AzMySqlFlexibleServer' {
    function ValidateSubnetVnet($Server, $Subnet){
        $Server.DelegatedSubnetArgumentSubnetArmResourceId | Should -Be $Subnet.Id
        $Delegation = Get-AzDelegation -Name Microsoft.DBforMySQL/flexibleServers -Subnet $Subnet
        $Delegation.ServiceName | Should -Be $DELEGATION_SERVICE_NAME
    }
    
    function RemoveServerVnet($Vnet, $Subnet){
        Remove-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.serverName2
        Start-Sleep -Seconds 450
        $Subnet = Remove-AzDelegation -Name $DELEGATION_SERVICE_NAME -Subnet $Subnet
        Set-AzVirtualNetwork -VirtualNetwork $Vnet
        Remove-AzVirtualNetwork -Name $Vnet.Name -ResourceGroupName $env.resourceGroup -Force
    }

    # It 'CreateExpanded' {
    #     {
    #         [SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    #         $password = 'Pasword01!!2020' | ConvertTo-SecureString -AsPlainText -Force
    #         $server = New-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -AdministratorUserName mysql_test -AdministratorLoginPassword $password -Sku Standard_D2ds_v4 -SkuTier GeneralPurpose -BackupRetentionDay 12 -StorageInMb 102400 -Location eastus2
    #         $server.SkuName | Should -Be "Standard_D2ds_v4"
    #         $server.SkuTier | Should -Be "GeneralPurpose"
    #         $server.StorageProfileStorageMb | Should -Be 102400
    #         $server.StorageProfileBackupRetentionDay | Should -Be 12

    #     } | Should -Not -Throw
    # }

    # It 'PublicAccessScenario' {
    #     {
    #         # Public Access 0.0.0.0
    #         New-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.serverName2 -PublicAccess 0.0.0.0
    #         $FirewallRules = Get-AzMySqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.serverName2
    #         $FirewallRules[0].Name | Should -BeLike "AllowAllAzureServicesAndResourcesWithinAzureIps*"
    #         $FirewallRules[0].StartIPAddress | Should -Be "0.0.0.0"
    #         $FirewallRules[0].EndIPAddress | Should -Be "0.0.0.0"
    #         Remove-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.serverName2

    #         # Public Access 10.10.10.10-10.10.10.12
    #         New-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.serverName2 -PublicAccess 10.10.10.10-10.10.10.12
    #         $FirewallRules = Get-AzMySqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.serverName2
    #         $FirewallRules[0].Name | Should -BeLike "FirewallIPAddress*"
    #         $FirewallRules[0].StartIPAddress | Should -Be "10.10.10.10"
    #         $FirewallRules[0].EndIPAddress | Should -Be "10.10.10.12"
    #         Remove-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.serverName2

    #         Public Access All
    #         New-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.serverName2 -PublicAccess All
    #         $FirewallRules = Get-AzMySqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.serverName2
    #         $FirewallRules[0].Name | Should -BeLike "AllowAll*"
    #         $FirewallRules[0].StartIPAddress | Should -Be "0.0.0.0"
    #         $FirewallRules[0].EndIPAddress | Should -Be "255.255.255.255"
    #         Remove-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.serverName2

    #     } | Should -Not -Throw
    # }

    # It 'NoArgumentsScenario' {
    #     {
    #         $Server = New-AzMySqlFlexibleServer
    #         $Splits = $Server.Id -Split "/" 
    #         $ResourceGroupName = $Splits[4]
            
    #         $SubnetName = 'Subnet' + $Server.Name
    #         $Subnet = Get-AzVirtualNetwork -Name Vnet + $Server.Name -ResourceGroupName $ResourceGroupName  | Get-AzVirtualNetworkSubnetConfig -Name $SubnetName

    #         $Server.SkuName | Should -Be "Standard_B1ms"
    #         $Server.SkuTier | Should -Be "Burstable"
    #         $Server.StorageProfileStorageMb | Should -Be 10240
    #         $Server.StorageProfileBackupRetentionDay | Should -Be 7
    #         $Server.Location | Should -Be "West US 2"

    #         ValidateSubnetVnet $Server $Subnet
    #         RemoveServerVnet $Server $Vnet $Subnet

    #     } | Should -Not -Throw
    # }

    It 'VnetIdScenario' {
        {
            # valid vnet Id and the vnet exists (subnet does not exist) 
            # $Vnet = New-AzVirtualNetwork -Name $env.VNetName -ResourceGroupName $env.resourceGroup -Location $env.Location -AddressPrefix $DEFAULT_VNET_PREFIX -Force
            # New-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -Vnet $Vnet.Id
            # $Subnet = Get-AzVirtualNetworkSubnetConfig -ResourceId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/$($env.VNetName)/subnets/Subnet$($env.serverName2)"
            # $Server = Get-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup
            
            # ValidateSubnetVnet $Server $Subnet
            # RemoveServerVnet $Vnet $Subnet
            
            # valid vnet Id but the vnet doesn't exist => Re Record
            $VnetId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/nonexistingvnetforpowershelltest"
            New-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -Vnet $VnetId
            $Server = Get-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup

            $Vnet = Get-AzVirtualNetwork -Name $env.VNetName -ResourceGroupName $env.resourceGroup
            $SubnetId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/nonexistingvnetforpowershelltest" + "/subnets/Subnet$($env.serverName2)"
            $Subnet = Get-AzVirtualNetworkSubnetConfig -ResourceId $SubnetId
            
            ValidateSubnetVnet $Server $Subnet
            RemoveServerVnet $Vnet $Subnet

        } | Should -Not -Throw
        {
            # invalid vnet Id
            $VnetId = "/subscriptions/00000-000-000000000000/resourceGroups/providers/Microsoft.Network/virtualNetworks/Vnet/Wrong/Vnet/itis"
            New-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -Vnet $VnetId
        } | Should -Throw
    }

    It 'SubnetIdScenario' {
        {
            # valid subnet Id and the subnet exists without delegation
            $Subnet = New-AzVirtualNetworkSubnetConfig -Name $env.SubnetName -AddressPrefix $DEFAULT_SUBNET_PREFIX
            $Vnet = New-AzVirtualNetwork -Name $env.VNetName -ResourceGroupName $env.resourceGroup -Location $env.location -AddressPrefix $DEFAULT_VNET_PREFIX -Subnet $Subnet -Force
            New-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -Subnet $Subnet.Id
            $Server = Get-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup
            $Subnet = Get-AzVirtualNetworkSubnetConfig -Name $env.SubnetName -VirtualNetwork $Vnet

            ValidateSubnetVnet $Server $Subnet
            RemoveServerVnet $Vnet $Subnet

            # valid subnet Id and the subnet exists without delegation, different resource group
            $Subnet = New-AzVirtualNetworkSubnetConfig -Name $env.SubnetName -AddressPrefix $DEFAULT_SUBNET_PREFIX
            $Vnet = New-AzVirtualNetwork -Name $env.VNetName -ResourceGroupName MySqlTest2 -Location $env.location -AddressPrefix $DEFAULT_VNET_PREFIX -Subnet $Subnet -Force
            New-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -Vnet $Vnet.Id
            $Server = Get-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup
            $Subnet = Get-AzVirtualNetworkSubnetConfig -Name $env.SubnetName -VirtualNetwork $Vnet

            ValidateSubnetVnet $Server $Subnet
            RemoveServerVnet $Vnet $Subnet

            # valid subnet Id and the subnet exists with delegation
            $Subnet = New-AzVirtualNetworkSubnetConfig -Name $env.SubnetName -AddressPrefix $DEFAULT_SUBNET_PREFIX
            $Vnet = New-AzVirtualNetwork -Name $env.VNetName -ResourceGroupName $env.resourceGroup -Location $env.location -AddressPrefix $DEFAULT_VNET_PREFIX -Subnet $Subnet -Force
            $Subnet = Add-AzDelegation -Name $DELEGATION_SERVICE_NAME -ServiceName $DELEGATION_SERVICE_NAME -Subnet $Subnet -Force
            Set-AzVirtualNetwork -VirtualNetwork $Vnet
            New-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -Subnet $Subnet.Id
            $Server = Get-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup
            $Subnet = Get-AzVirtualNetworkSubnetConfig -Name $env.SubnetName -VirtualNetwork $Vnet

            ValidateSubnetVnet $Server $Subnet
            RemoveServerVnet $Vnet $Subnet

            # valid subnet Id but the subnet doesn't exist
            $SubnetId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks\nonexistingvnetforpowershelltest/subnets/nonexistingsubnetforpowershelltest"
            New-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -Subnet $SubnetId
            $Subnet = Get-AzVirtualNetworkSubnetConfig -ResourceId $SubnetId
            $Server = Get-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup

            ValidateSubnetVnet $Server $Subnet
            RemoveServerVnet $Vnet $Subnet
        } | Should -Not -Throw
        {
            # invalid subnet Id
            $SubnetId = "/subscriptions/00000-000-000000000000/resourceGroups/providers/Microsoft.Network/VirtualNetworks/Wrong/subnetss/wrong"
            New-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -Subnet $SubnetId

        } | Should -Throw
        {
            # invalid delegation on the subnet
            $Subnet = New-AzVirtualNetworkSubnetConfig -Name $env.SubnetName -AddressPrefix $DEFAULT_SUBNET_PREFIX
            $Vnet = New-AzVirtualNetwork -Name $env.VNetName -ResourceGroupName $env.resourceGroup -Location $env.location -AddressPrefix $DEFAULT_VNET_PREFIX -Subnet $Subnet -Force
            $Subnet = Add-AzDelegation -Name "faultydelegation" -ServiceName "Microsoft.Sql/servers" -Subnet $Subnet
            Set-AzVirtualNetwork -VirtualNetwork $Vnet
            New-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -Subnet $Subnet.Id            
        } | Should -Throw
        $Subnet = Remove-AzDelegation -Name "faultydelegation" -Subnet $Subnet
        Set-AzVirtualNetwork $Vnet
        Remove-AzVirtualNetwork -Name $Vnet.Name -ResourceGroupName $env.resourceGroup
    }

    It 'VnetNameScenario' {
        {
            # valid vnet name and the vnet exists
            $Vnet = New-AzVirtualNetwork -Name $env.VNetName -ResourceGroupName $env.resourceGroup -Location $env.location -AddressPrefix $DEFAULT_VNET_PREFIX -Force
            New-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -Vnet $Vnet.Name
            $Server = Get-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup
            
            $Subnet = Get-AzVirtualNetworkSubnetConfig -ResourceId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/$($env.VNetName)/subnets/Subnet$($env.serverName2)"
            ValidateSubnetVnet $Server $Subnet
            RemoveServerVnet $Vnet $Subnet

            # valid vnet name but the vnet doesn't exist
            New-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -Vnet nonexistingvnetforpowershelltest
            $Subnet = Get-AzVirtualNetworkSubnetConfig -ResourceId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/nonexistingvnetforpowershelltest/subnets/Subnet$($env.serverName2)"
            $Server = Get-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup
            
            ValidateSubnetVnet $Server $Subnet
            RemoveServerVnet $Vnet $Subnet
        } | Should -Not -Throw
        {
            # invalid vnet name
            $InvalidName = "hi/df!@$@#$@"
            New-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -Vnet $InvalidName
        } | Should -Throw
    }

    It 'VnetSubnetScenario' {
        {
            # vnet name and subnet name resource do not exist
            New-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -Vnet $env.VNetName -Subnet $env.SubnetName -VnetPrefix $DEFAULT_VNET_PREFIX -SubnetPrefix $DEFAULT_SUBNET_PREFIX
            $Vnet = Get-AzVirtualNetwork -Name $env.VNetName -ResourceGroupName $env.resourceGroup
            $Subnet = Get-AzVirtualNetworkSubnetConfig -Name $env.SubnetName -VirtualNetwork $Vnet
            $Server = Get-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup

            ValidateSubnetVnet $Server $Subnet
            Remove-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.serverName2

            # vnet name and subnet name, resource exist
            New-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -Vnet $env.VNetName -Subnet $env.SubnetName -VnetPrefix $DEFAULT_VNET_PREFIX -SubnetPrefix $DEFAULT_SUBNET_PREFIX
            $Server = Get-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup
            
            ValidateSubnetVnet $Server $Subnet
            RemoveServerVnet $Vnet $Subnet
        } | Should -Not -Throw
    }
}


