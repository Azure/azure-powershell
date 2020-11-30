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

Describe 'New-AzMySqlFlexibleServer' {
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
            
    #         $Subnet = Get-AzVirtualNetwork -Name Vnet + $Server.Name -ResourceGroupName $ResourceGroupName  | Get-AzVirtualNetworkSubnetConfig -Name Subnet + $Server.Name 
    #         $Delegation = Get-AzDelegation -Name Microsoft.DBforMySQL/flexibleServers -Subnet $subnet

    #         $Server.SkuName | Should -Be "Standard_B1ms"
    #         $Server.SkuTier | Should -Be "Burstable"
    #         $Server.StorageProfileStorageMb | Should -Be 10240
    #         $Server.StorageProfileBackupRetentionDay | Should -Be 7
    #         $Server.Location | Should -Be "West US 2"

    #         $Server.DelegatedSubnetArgumentsSubnetArmResourceId | Should -BeLike "\/subscriptions\/[0-9A-Fa-f]{8}-([0-9A-Fa-f]{4}-){3}[0-9A-Fa-f]{12}\/resourceGroups/[-\w\._\(\)]+\/providers\/Microsoft.Network\/VirtualNetworks\/Vnet$([regex]::escape($Server.Name))\/subnets\/Subnet$([regex]::escape($Server.Name))$"
    #         $Delegation.ServiceName | Should -Be $DELEGATION_SERVICE_NAME

    #         Get-AzMySqlFlexibleServerDatabase -ResourceGroupName $ResourceGroupName -Name $DEFAULT_DB_NAME -ServerName $Server.Name
    #     } | Should -Not -Throw
    # }

    It 'VnetIdScenario' {
        {
            # valid vnet Id and the vnet exists 
            # New-AzMySqlFlexibleServer
            # New-AzMySqlFlexibleServer -ResourceGroupName group4475111595 -Subnet /subscriptions/7fec3109-5b78-4a24-b834-5d47d63e2596/resourceGroups/group4475111595/providers/Microsoft.Network/virtualNetworks/mysqlvnet2/subnets/Subnetserver8139643265
            # New-AzMySqlFlexibleServer -ResourceGroupName group4475111595 -Vnet /subscriptions/7fec3109-5b78-4a24-b834-5d47d63e2596/resourceGroups/group4475111595/providers/Microsoft.Network/virtualNetworks/mysqlvnet2
            
            # $Vnet = New-AzVirtualNetwork -Name mysqltestvnet3 -ResourceGroupName group4475111595 -Location $env.Location -AddressPrefix $DEFAULT_VNET_PREFIX
            # New-AzMySqlFlexibleServer -ResourceGroupName group4475111595 -Vnet mysqltestvnet3
            
            New-AzMySqlFlexibleServer -ResourceGroupName group4475111595 -Vnet mysqltestvnet2 -Subnet mysqltestsubnet2 -VnetPrefix 12.0.0.0/16 -SubnetPrefix 12.0.0.0/24
            
            # $Vnet = New-AzVirtualNetwork -Name $env.VNetName -ResourceGroupName $env.resourceGroup -Location $env.Location -AddressPrefix $DEFAULT_VNET_PREFIX
            # $Server = New-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Vnet $Vnet.Id
            # $Server.DelegatedSubnetArgumentsSubnetArmResourceId | Should -BeLike "\/subscriptions\/[0-9A-Fa-f]{8}-([0-9A-Fa-f]{4}-){3}[0-9A-Fa-f]{12}\/resourceGroups/[-\w\._\(\)]+\/providers\/Microsoft.Network\/VirtualNetworks\/Vnet$([regex]::escape($Server.Name))\/subnets\/Subnet$([regex]::escape($Server.Name))$"
            # $Delegation = Get-AzDelegation -Name Microsoft.DBforMySQL/flexibleServers -Subnet $subnet
            # $Delegation.ServiceName | Should -Be $DELEGATION_SERVICE_NAME

            # valid vnet Id but the vnet doesn't exist


            # invalid vnet Id


        } | Should -Not -Throw
    }

    It 'SubnetIdScenario' {
        {
            # valid subnet Id and the subnet exists


            # valid subnet Id but the subnet doesn't exist


            # invalid subnet Id



        } | Should -Not -Throw
    }

    It 'VnetNameScenario' {
        {
            # valid vnet name and the vnet exists


            # valid vnet name but the vnet doesn't exist


            # invalid vnet Id


        } | Should -Not -Throw
    }

    It 'SubnetNameScenario' {
        {
            # valid subnet name and the subnet exists


            # valid subnet name but the subnet doesn't exist


            # invalid subnet name


        } | Should -Not -Throw
    }


    It 'VnetSubnetScenario' {
        {
            # valid subnet name and the subnet exists


            # valid subnet name but the subnet doesn't exist


            # invalid subnet name


        } | Should -Not -Throw
    }
    
}
