function New-TestDeployment
{
    param(
        $rgName,
        $location,
        $virtualMachineName,
        $storageAccountName,
        $routeTableName,
        $networkInterfaceName,
        $networkSecurityGroupName,
        $virtualNetworkName
    )

    $templateFile = "${PsScriptRoot}/../../TestData/Deployment.json";
    $paramFile = "${PsScriptRoot}/../../TestData/NrpGenerateTestDeploymentParameters.json";
    $diagnosticsStorageAccountName = (Get-ResourceName "psnrp") + "teststorage";

    $paramContent =
@"
{
  "rgName": {
    "value": "$rgName"
  },
  "location": {
    "value": "$location"
  },
  "virtualMachineName": {
    "value": "$virtualMachineName"
  },
  "virtualMachineSize": {
    "value": "Standard_DS1_v2"
  },
  "adminUsername": {
    "value": "netanaytics12"
  },
  "adminPassword": {
    "value": "netanalytics-32${resourceGroupName}"
  },
  "storageAccountName": {
    "value": "$storageAccountName"
  },
  "storageAccountType": {
    "value": "Premium_LRS"
  },
  "diagnosticsStorageAccountName": {
    "value": "$diagnosticsStorageAccountName"
  },
  "diagnosticsStorageAccountId": {
    "value": "Microsoft.Storage/storageAccounts/${diagnosticsStorageAccountName}"
  },
  "diagnosticsStorageAccountType": {
    "value": "Standard_LRS"
  },
  "routeTableName": {
    "value": "$routeTableName"
  },
  "networkInterfaceName": {
    "value": "$networkInterfaceName"
  },
  "networkSecurityGroupName": {
    "value": "$networkSecurityGroupName"
  },
  "virtualNetworkName": {
    "value": "$virtualNetworkName"
  },
  "addressPrefix": {
    "value": "10.17.3.0/24"
  },
  "subnetName": {
    "value": "default"
  },
  "subnetPrefix": {
    "value": "10.17.3.0/24"
  },
  "publicIpAddressName": {
    "value": "${virtualMachineName}-ip"
  },
  "publicIpAddressType": {
    "value": "Dynamic"
  }
}
"@;

    Set-Content -Path $paramFile -Value $paramContent -Force | Out-Null;

    New-AzResourceGroupDeployment -Name $rgName -ResourceGroupName $rgName -TemplateFile $templateFile -TemplateParameterFile $paramFile | Out-Null;

    Remove-Item -Path $paramFile -Force | Out-Null;
}

function Get-TestDeployment
{
    param(
        $rgName,
        $location,
        $virtualMachineName,
        $storageAccountName,
        $routeTableName,
        $networkInterfaceName,
        $networkSecurityGroupName,
        $virtualNetworkName
    )

    $envContents = @{};

    New-TestDeployment $rgName $location $virtualMachineName $storageAccountName $routeTableName $networkInterfaceName $networkSecurityGroupName $virtualNetworkName | Out-Null;

    $envContents.targetResourceGroupName = $rgName;

    $vm = Get-AzVM -ResourceGroupName $rgName -Name $virtualMachineName;
    $envContents.virtualMachineId = $vm.Id;
    $envContents.virtualMachineName = $vm.Name;

    $storage = Get-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName;
    $envContents.storageId = $storage.Id;
    $envContents.storageName = $storage.Name;

    $nic = Get-AzNetworkInterface -ResourceGroupName $rgName -Name $networkInterfaceName;
    $envContents.networkInterfaceId = $nic.Id;
    $envContents.networkInterfaceName = $nic.Name;
    $envContents.localIpAddress = $nic.IpConfigurations[0].PrivateIpAddress;

    $nsg = Get-AzNetworkSecurityGroup -ResourceGroupName $rgName -Name $networkSecurityGroupName;
    $envContents.networkSecurityGroupId = $nsg.Id;
    $envContents.networkSecurityGroupName = $nsg.Name;

    return $envContents;
}

function Get-TestWatcherDeployment
{
    param(
        $rgName,
        $location,
        $virtualMachineName,
        $storageAccountName,
        $routeTableName,
        $networkInterfaceName,
        $networkSecurityGroupName,
        $virtualNetworkName
    )

    $envContents = Get-TestDeployment $rgName $location $virtualMachineName $storageAccountName $routeTableName $networkInterfaceName $networkSecurityGroupName $virtualNetworkName;

    Set-AzVMExtension -ResourceGroupName $rgName -Location $location -VMName $virtualMachineName -Name "MyNetworkWatcherAgent" -Type "NetworkWatcherAgentWindows" -TypeHandlerVersion "1.4" -Publisher "Microsoft.Azure.NetworkWatcher" | Out-Null;

    return $envContents;
}

function Get-TestDeploymentWithVpnGateway
{
    param(
        $rgName,
        $location,
        $virtualMachineName,
        $storageAccountName,
        $routeTableName,
        $networkInterfaceName,
        $networkSecurityGroupName,
        $virtualNetworkName,
        $vpnGatewayName
    )

    $envContents = Get-TestDeployment $rgName $location $virtualMachineName $storageAccountName $routeTableName $networkInterfaceName $networkSecurityGroupName $virtualNetworkName;

    $vnetName = Get-ResourceName;
    $publicIpName = Get-ResourceName;
    $vpnIpCfgName = Get-ResourceName;

    $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix "10.0.1.0/24";
    $vnet = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Location $location -Subnet $subnet -AddressPrefix "10.0.0.0/8";
    $publicIp = New-AzPublicIpAddress -ResourceGroupName $rgName -Name $publicIpName -Location $location -AllocationMethod "Dynamic";

    $ipConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vpnIpCfgName -SubnetId $vnet.Subnets[0].Id -PublicIpAddressId $publicIp.Id;
    $vpn = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -Name $vpnGatewayName -Location $location -IpConfigurations $ipConfig -VpnType "RouteBased";

    $envContents.vpnGatewayId = $vpn.Id;
    $envContents.vpnGatewayName = $vpn.Name;

    return $envContents;
}
