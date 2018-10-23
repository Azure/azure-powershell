# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Deployment of resources: VM, storage account, network interface, nsg, virtual network and route table.
#>
function Get-TestResourcesDeployment([string]$rgn)
{
	$virtualMachineName = Get-ResourceName
	$storageAccountName = Get-ResourceName
	$routeTableName = Get-ResourceName
	$virtualNetworkName = Get-ResourceName
	$networkInterfaceName = Get-ResourceName
	$networkSecurityGroupName = Get-ResourceName
	$diagnosticsStorageAccountName = Get-ResourceName
	
		$paramFile = "..\..\TestData\DeploymentParameters.json"
		$paramContent =
@"
{
			"rgName": {
			"value": "$rgn"
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
			"storageAccountName": {
			"value": "$storageAccountName"
			},
			"routeTableName": {
			"value": "$routeTableName"
			},
			"virtualNetworkName": {
			"value": "$virtualNetworkName"
			},
			"networkInterfaceName": {
			"value": "$networkInterfaceName"
			},
			"networkSecurityGroupName": {
			"value": "$networkSecurityGroupName"
			},
			"adminPassword": {
			"value": "netanalytics-32${resourceGroupName}"
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

		$st = Set-Content -Path $paramFile -Value $paramContent -Force;
		AzureRm.Resources\New-AzureRmResourceGroupDeployment -ResourceGroupName "$rgn" -TemplateFile "$templateFile" -TemplateParameterFile $paramFile
}

<#
.SYNOPSIS
Test GetTopology NetworkWatcher API.
#>
function Test-GetTopology
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName
    $nwName = Get-ResourceName
    $location = "West Central US"
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    $nwLocation = Get-ProviderLocation $resourceTypeParent
    $nwRgName = Get-ResourceGroupName
    $templateFile = "..\..\TestData\Deployment.json"
    
    try 
    {
        # Create Resource group
        New-AzureRmResourceGroup -Name $resourceGroupName -Location "$location"
        
        # Deploy resources
        Get-TestResourcesDeployment -rgn "$resourceGroupName"
        
        # Create Resource group for Network Watcher
        New-AzureRmResourceGroup -Name $nwRgName -Location "$location"
        
        # Create Network Watcher
        $nw = New-AzureRmNetworkWatcher -Name $nwName -ResourceGroupName $nwRgName -Location $location
        
        # Get topology in the resource group $resourceGroupName
        $topology = Get-AzureRmNetworkWatcherTopology -NetworkWatcher $nw -TargetResourceGroupName $resourceGroupName

        #Get Vm
        $vm = Get-AzureRmVM -ResourceGroupName $resourceGroupName

        #Get nic
        $nic = Get-AzureRmNetworkInterface -ResourceGroupName $resourceGroupName

        #Verification
        Assert-AreEqual $topology.Resources.Count 9
        Assert-AreEqual $topology.Resources[2].Name $vm.Name
        Assert-AreEqual $topology.Resources[2].Id $vm.Id
        Assert-AreEqual $topology.Resources[2].Associations[0].Name $nic.Name
        Assert-AreEqual $topology.Resources[2].Associations[0].ResourceId $nic.Id
        Assert-AreEqual $topology.Resources[2].Associations[0].AssociationType Contains
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test GetSecurityGroupView NetworkWatcher API.
#>
function Test-GetSecurityGroupView
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName
    $nwName = Get-ResourceName
    $location = "West Central US"
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    $nwLocation = Get-ProviderLocation $resourceTypeParent
    $nwRgName = Get-ResourceGroupName
    $securityRuleName = Get-ResourceName
    $templateFile = "..\..\TestData\Deployment.json"
    
    try 
    {
        # Create Resource group
        New-AzureRmResourceGroup -Name $resourceGroupName -Location "$location"

        # Deploy resources
        Get-TestResourcesDeployment -rgn "$resourceGroupName"
        
        # Create Resource group for Network Watcher
        New-AzureRmResourceGroup -Name $nwRgName -Location "$location"
        
        # Create Network Watcher
        $nw = New-AzureRmNetworkWatcher -Name $nwName -ResourceGroupName $nwRgName -Location $location
        
        #Get Vm
        $vm = Get-AzureRmVM -ResourceGroupName $resourceGroupName
        
        #Get network security group
        $nsg = Get-AzureRmNetworkSecurityGroup -ResourceGroupName $resourceGroupName
        
        # Set security rule
        $nsg[0] | Add-AzureRmNetworkSecurityRuleConfig -Name scr1 -Description "test" -Protocol Tcp -SourcePortRange * -DestinationPortRange 80 -SourceAddressPrefix * -DestinationAddressPrefix * -Access Deny -Priority 122 -Direction Outbound
        $nsg[0] | Set-AzureRmNetworkSecurityGroup

        #Use it when running test in record mode
        #Start-Sleep -s 300

        # Get nsg rules for the target VM
        $job = Get-AzureRmNetworkWatcherSecurityGroupView -NetworkWatcher $nw -Target $vm.Id -AsJob
		$job | Wait-Job
		$nsgView = $job | Receive-Job

        #Verification
        Assert-AreEqual $nsgView.NetworkInterfaces[0].EffectiveSecurityRules[4].Access Deny
        Assert-AreEqual $nsgView.NetworkInterfaces[0].EffectiveSecurityRules[4].DestinationPortRange 80-80
        Assert-AreEqual $nsgView.NetworkInterfaces[0].EffectiveSecurityRules[4].Direction Outbound
        Assert-AreEqual $nsgView.NetworkInterfaces[0].EffectiveSecurityRules[4].Name UserRule_scr1
        Assert-AreEqual $nsgView.NetworkInterfaces[0].EffectiveSecurityRules[4].Protocol TCP
        Assert-AreEqual $nsgView.NetworkInterfaces[0].EffectiveSecurityRules[4].Priority 122
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test GetNextHop NetworkWatcher API.
#>
function Test-GetNextHop
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName
    $nwName = Get-ResourceName
    $location = "West Central US"
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    $nwLocation = Get-ProviderLocation $resourceTypeParent
	$nwRgName = Get-ResourceGroupName
	$securityRuleName = Get-ResourceName
	$templateFile = "..\..\TestData\Deployment.json"
    
    try 
    {
        # Create Resource group
        New-AzureRmResourceGroup -Name $resourceGroupName -Location "$location"

        # Deploy resources
        Get-TestResourcesDeployment -rgn "$resourceGroupName"
        
        # Create Resource group for Network Watcher
        New-AzureRmResourceGroup -Name $nwRgName -Location "$location"
        
        # Create Network Watcher
        $nw = New-AzureRmNetworkWatcher -Name $nwName -ResourceGroupName $nwRgName -Location $location
        
        #Get Vm
        $vm = Get-AzureRmVM -ResourceGroupName $resourceGroupName
        
        #Get pablic IP address
        $address = Get-AzureRmPublicIpAddress -ResourceGroupName $resourceGroupName

        #Get next hop
        $job = Get-AzureRmNetworkWatcherNextHop -NetworkWatcher $nw -TargetVirtualMachineId $vm.Id -DestinationIPAddress 10.1.3.6 -SourceIPAddress $address.IpAddress -AsJob
        $job | Wait-Job
		$nextHop1 = $job | Receive-Job
		$nextHop2 = Get-AzureRmNetworkWatcherNextHop -NetworkWatcher $nw -TargetVirtualMachineId $vm.Id -DestinationIPAddress 12.11.12.14 -SourceIPAddress $address.IpAddress
    
        #Verification
        Assert-AreEqual $nextHop1.NextHopType None
        Assert-AreEqual $nextHop1.NextHopIpAddress 10.0.1.2
        Assert-AreEqual $nextHop2.NextHopType Internet
        Assert-AreEqual $nextHop2.RouteTableId "System Route"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test VerifyIPFlow NetworkWatcher API.
#>
function Test-VerifyIPFlow
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName
    $nwName = Get-ResourceName
    $location = "West Central US"
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    $nwLocation = Get-ProviderLocation $resourceTypeParent
	$nwRgName = Get-ResourceGroupName
	$securityGroupName = Get-ResourceName
	$templateFile = "..\..\TestData\Deployment.json"
    
    try 
    {
        # Create Resource group
        New-AzureRmResourceGroup -Name $resourceGroupName -Location "$location"

        # Deploy resources
        Get-TestResourcesDeployment -rgn "$resourceGroupName"
        
        # Create Resource group for Network Watcher
        New-AzureRmResourceGroup -Name $nwRgName -Location "$location"
        
        # Create Network Watcher
        $nw = New-AzureRmNetworkWatcher -Name $nwName -ResourceGroupName $nwRgName -Location $location
        
        #Get network security group
        $nsg = Get-AzureRmNetworkSecurityGroup -ResourceGroupName $resourceGroupName

        # Set security rules
        $nsg[0] | Add-AzureRmNetworkSecurityRuleConfig -Name scr1 -Description "test1" -Protocol Tcp -SourcePortRange * -DestinationPortRange 80 -SourceAddressPrefix * -DestinationAddressPrefix * -Access Deny -Priority 122 -Direction Outbound
        $nsg[0] | Set-AzureRmNetworkSecurityGroup

        $nsg[0] | Add-AzureRmNetworkSecurityRuleConfig -Name sr2 -Description "test2" -Protocol Tcp -SourcePortRange "23-45" -DestinationPortRange "46-56" -SourceAddressPrefix * -DestinationAddressPrefix * -Access Allow -Priority 123 -Direction Inbound
        $nsg[0] | Set-AzureRmNetworkSecurityGroup

        #Start-Sleep -s 300

        #Get Vm
        $vm = Get-AzureRmVM -ResourceGroupName $resourceGroupName
        
        #Get private Ip address of nic
        $nic = Get-AzureRmNetworkInterface -ResourceGroupName $resourceGroupName
        $address = $nic[0].IpConfigurations[0].PrivateIpAddress

        #Verify IP Flow
        $job = Test-AzureRmNetworkWatcherIPFlow -NetworkWatcher $nw -TargetVirtualMachineId $vm.Id -Direction Inbound -Protocol Tcp -RemoteIPAddress 121.11.12.14 -LocalIPAddress $address -LocalPort 50 -RemotePort 40 -AsJob
        $job | Wait-Job
		$verification1 = $job | Receive-Job
		$verification2 = Test-AzureRmNetworkWatcherIPFlow -NetworkWatcher $nw -TargetVirtualMachineId $vm.Id -Direction Outbound -Protocol Tcp -RemoteIPAddress 12.11.12.14 -LocalIPAddress $address -LocalPort 80 -RemotePort 80

        #Verification
        Assert-AreEqual $verification1.Access Allow
        Assert-AreEqual $verification2.Access Deny
        Assert-AreEqual $verification1.RuleName securityRules/sr2
        Assert-AreEqual $verification2.RuleName securityRules/scr1
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test PacketCapture API.
#>
function Test-PacketCapture
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName
    $nwName = Get-ResourceName
    $location = "westcentralus"
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    $nwLocation = Get-ProviderLocation $resourceTypeParent
    $nwRgName = Get-ResourceGroupName
    $securityGroupName = Get-ResourceName
    $templateFile = "..\..\TestData\Deployment.json"
    $pcName1 = Get-ResourceName
    $pcName2 = Get-ResourceName
    
    try 
    {
        # Create Resource group
        New-AzureRmResourceGroup -Name $resourceGroupName -Location "$location"

        # Deploy resources
        Get-TestResourcesDeployment -rgn "$resourceGroupName"
        
        # Create Resource group for Network Watcher
        New-AzureRmResourceGroup -Name $nwRgName -Location "$location"
        
        # Create Network Watcher
        $nw = New-AzureRmNetworkWatcher -Name $nwName -ResourceGroupName $nwRgName -Location $location

        #Get Vm
        $vm = Get-AzureRmVM -ResourceGroupName $resourceGroupName
        
        #Install networkWatcherAgent on Vm
        Set-AzureRmVMExtension -ResourceGroupName "$resourceGroupName" -Location "$location" -VMName $vm.Name -Name "MyNetworkWatcherAgent" -Type "NetworkWatcherAgentWindows" -TypeHandlerVersion "1.4" -Publisher "Microsoft.Azure.NetworkWatcher" 

        #Create filters for packet capture
        $f1 = New-AzureRmPacketCaptureFilterConfig -Protocol Tcp -RemoteIPAddress 127.0.0.1-127.0.0.255 -LocalPort 80 -RemotePort 80-120
        $f2 = New-AzureRmPacketCaptureFilterConfig -LocalIPAddress 127.0.0.1;127.0.0.5

        #Create packet capture
        $job = New-AzureRmNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName1 -TargetVirtualMachineId $vm.Id -LocalFilePath C:\tmp\Capture.cap -Filter $f1, $f2 -AsJob
		$job | Wait-Job
        New-AzureRmNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName2 -TargetVirtualMachineId $vm.Id -LocalFilePath C:\tmp\Capture.cap -TimeLimitInSeconds 1
        Start-Sleep -s 2

        #Get packet capture
        $job = Get-AzureRmNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName1 -AsJob
        $job | Wait-Job
		$pc1 = $job | Receive-Job
		$pc2 = Get-AzureRmNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName2
        $pcList = Get-AzureRmNetworkWatcherPacketCapture -NetworkWatcher $nw

        #Verification
        Assert-AreEqual $pc1.Name $pcName1
        Assert-AreEqual "Succeeded" $pc1.ProvisioningState
        Assert-AreEqual $pc1.TotalBytesPerSession 1073741824
        Assert-AreEqual $pc1.BytesToCapturePerPacket 0
        Assert-AreEqual $pc1.TimeLimitInSeconds 18000
        Assert-AreEqual $pc1.Filters[0].LocalPort 80
        Assert-AreEqual $pc1.Filters[0].Protocol TCP
        Assert-AreEqual $pc1.Filters[0].RemoteIPAddress 127.0.0.1-127.0.0.255
        Assert-AreEqual $pc1.Filters[1].LocalIPAddress 127.0.0.1;127.0.0.5
        Assert-AreEqual $pc1.StorageLocation.FilePath C:\tmp\Capture.cap
        Assert-AreEqual $pcList.Count 2

        #Stop packet capture
        $job = Stop-AzureRmNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName1 -AsJob
		$job | Wait-Job

        #Get packet capture
        $pc1 = Get-AzureRmNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName1

        #Remove packet capture
        $job = Remove-AzureRmNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName1 -AsJob
		$job | Wait-Job

        #List packet captures
        $pcList = Get-AzureRmNetworkWatcherPacketCapture -NetworkWatcher $nw
        Assert-AreEqual $pcList.Count 1

        #Remove packet capture
        Remove-AzureRmNetworkWatcherPacketCapture -NetworkWatcher $nw -PacketCaptureName $pcName2

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test Troubleshoot API.
#>
function Test-Troubleshoot
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName
    $nwName = Get-ResourceName
    $location = "West Central US"
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    $nwLocation = Get-ProviderLocation $resourceTypeParent
    $nwRgName = Get-ResourceGroupName
    $domainNameLabel = Get-ResourceName
    $vnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $gwName = Get-ResourceName
    
    try 
    {
        # Create Resource group
        New-AzureRmResourceGroup -Name $resourceGroupName -Location "$location"

        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroupName -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroupName
        $subnet = Get-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet
 
        # Create the publicip
        $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $resourceGroupName -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    
 
        # Create & Get virtualnetworkgateway
        $vnetIpConfig = New-AzureRmVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
        $gw = New-AzureRmVirtualNetworkGateway -ResourceGroupName $resourceGroupName -Name $gwName -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false
        
        # Create Resource group for Network Watcher
        New-AzureRmResourceGroup -Name $nwRgName -Location "$location"
        
        # Create Network Watcher
        $nw = New-AzureRmNetworkWatcher -Name $nwName -ResourceGroupName $nwRgName -Location $location

        # Create storage
        $stoname = 'sto' + $resourceGroupName
        $stotype = 'Standard_GRS'
        $containerName = 'cont' + $resourceGroupName

        New-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $stoname -Location $location -Type $stotype;
        $key = Get-AzureRmStorageAccountKey -ResourceGroupName $resourceGroupName -Name $stoname
        $context = New-AzureStorageContext -StorageAccountName $stoname -StorageAccountKey $key[0].Value
        New-AzureStorageContainer -Name $containerName -Context $context
        $container = Get-AzureStorageContainer -Name $containerName -Context $context

        $sto = Get-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $stoname;

        Start-AzureRmNetworkWatcherResourceTroubleshooting -NetworkWatcher $nw -TargetResourceId $gw.Id -StorageId $sto.Id -StoragePath $container.CloudBlobContainer.StorageUri.PrimaryUri.AbsoluteUri;
        Get-AzureRmNetworkWatcherTroubleshootingResult -NetworkWatcher $nw -TargetResourceId $gw.Id
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test Flow log API.
#>
function Test-FlowLog
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName
    $nwName = Get-ResourceName
    $location = "West Central US"
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    $nwLocation = Get-ProviderLocation $resourceTypeParent
    $nwRgName = Get-ResourceGroupName
    $domainNameLabel = Get-ResourceName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $nsgName = Get-ResourceName
    
    try 
    {
        # Create Resource group
        New-AzureRmResourceGroup -Name $resourceGroupName -Location "$location"

        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroupName -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create NetworkSecurityGroup
        $nsg = New-AzureRmNetworkSecurityGroup -name $nsgName -ResourceGroupName $resourceGroupName -Location $location

        # Get NetworkSecurityGroup
        $getNsg = Get-AzureRmNetworkSecurityGroup -name $nsgName -ResourceGroupName $resourceGroupName
        
        # Create Resource group for Network Watcher
        New-AzureRmResourceGroup -Name $nwRgName -Location "$location"
        
        # Create Network Watcher
        $nw = New-AzureRmNetworkWatcher -Name $nwName -ResourceGroupName $nwRgName -Location $location
 
        # Create storage
        $stoname = 'sto' + $resourceGroupName
        $stotype = 'Standard_GRS'
        $containerName = 'cont' + $resourceGroupName

        New-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $stoname -Location $location -Type $stotype;
        $sto = Get-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $stoname;

        $job = Set-AzureRmNetworkWatcherConfigFlowLog -NetworkWatcher $nw -TargetResourceId $getNsg.Id -EnableFlowLog $true -StorageAccountId $sto.Id -AsJob
        $job | Wait-Job
		$config = $job | Receive-Job
		$job = Get-AzureRmNetworkWatcherFlowLogStatus -NetworkWatcher $nw -TargetResourceId $getNsg.Id -AsJob
		$job | Wait-Job
		$status = $job | Receive-Job

        # Validation
        Assert-AreEqual $config.TargetResourceId $getNsg.Id
        Assert-AreEqual $config.StorageId $sto.Id
        Assert-AreEqual $config.Enabled $true
        Assert-AreEqual $config.RetentionPolicy.Days 0
        Assert-AreEqual $config.RetentionPolicy.Enabled $false
        Assert-AreEqual $status.TargetResourceId $getNsg.Id
        Assert-AreEqual $status.StorageId $sto.Id
        Assert-AreEqual $status.Enabled $true
        Assert-AreEqual $status.RetentionPolicy.Days 0
        Assert-AreEqual $status.RetentionPolicy.Enabled $false
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test ConnectivityCheck NetworkWatcher API.
#>
function Test-ConnectivityCheck
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName
    $nwName = Get-ResourceName
    $location = "westcentralus"
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    $nwLocation = Get-ProviderLocation $resourceTypeParent
    $nwRgName = Get-ResourceGroupName
    $securityGroupName = Get-ResourceName
    $templateFile = "..\..\TestData\Deployment.json"
    $pcName1 = Get-ResourceName
    $pcName2 = Get-ResourceName
    
    try 
    {
        # Create Resource group
        New-AzureRmResourceGroup -Name $resourceGroupName -Location "$location"

        # Deploy resources
        Get-TestResourcesDeployment -rgn "$resourceGroupName"
        
        # Create Resource group for Network Watcher
        New-AzureRmResourceGroup -Name $nwRgName -Location "$location"
        
        # Create Network Watcher
        $nw = New-AzureRmNetworkWatcher -Name $nwName -ResourceGroupName $nwRgName -Location $location

        #Get Vm
        $vm = Get-AzureRmVM -ResourceGroupName $resourceGroupName
        
        #Install networkWatcherAgent on Vm
        Set-AzureRmVMExtension -ResourceGroupName "$resourceGroupName" -Location "$location" -VMName $vm.Name -Name "MyNetworkWatcherAgent" -Type "NetworkWatcherAgentWindows" -TypeHandlerVersion "1.4" -Publisher "Microsoft.Azure.NetworkWatcher"

        #Connectivity check
        $job = Test-AzureRmNetworkWatcherConnectivity -NetworkWatcher $nw -SourceId $vm.Id -DestinationAddress "bing.com" -DestinationPort 80 -AsJob
		$job | Wait-Job
		$check = $job | Receive-Job

        #Verification
        Assert-AreEqual $check.ConnectionStatus "Reachable"
        Assert-AreEqual $check.ProbesFailed 0
        Assert-AreEqual $check.Hops.Count 2
        Assert-AreEqual $check.Hops[0].Type "Source"
        Assert-AreEqual $check.Hops[1].Type "Internet"
        Assert-AreEqual $check.Hops[0].Address "10.17.3.4"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}

<#
.SYNOPSIS
Test ReachabilityReport NetworkWatcher API.
#>
function Test-ReachabilityReport
{
    # Setup
    $rgname = Get-ResourceGroupName
    $nwName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    $location = "westcentralus"
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }
        
        # Create the Network Watcher
        $tags = @{"key1" = "value1"; "key2" = "value2"}
        $nw = New-AzureRmNetworkWatcher -Name $nwName -ResourceGroupName $rgname -Location $location -Tag $tags

        $job = Get-AzureRmNetworkWatcherReachabilityReport -NetworkWatcher $nw -Location "West US" -Country "United States" -StartTime "2017-10-05" -EndTime "2017-10-10" -AsJob
        $job | Wait-Job
		$report1 = $job | Receive-Job
		$report2 = Get-AzureRmNetworkWatcherReachabilityReport -NetworkWatcher $nw -Location "West US" -Country "United States" -State "washington" -StartTime "2017-10-05" -EndTime "2017-10-10"
        $report3 = Get-AzureRmNetworkWatcherReachabilityReport -NetworkWatcher $nw -Location "West US" -Country "United States" -State "washington" -City "seattle" -StartTime "2017-10-05" -EndTime "2017-10-10"

        Assert-AreEqual $report1.AggregationLevel "Country"
        Assert-AreEqual $report1.ProviderLocation.Country "United States"
        Assert-AreEqual $report2.AggregationLevel "State"
        Assert-AreEqual $report2.ProviderLocation.Country "United States"
        Assert-AreEqual $report2.ProviderLocation.State "washington"
        Assert-AreEqual $report3.AggregationLevel "City"
        Assert-AreEqual $report3.ProviderLocation.Country "United States"
        Assert-AreEqual $report3.ProviderLocation.State "washington"
        Assert-AreEqual $report3.ProviderLocation.City "seattle"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test ProvidersList NetworkWatcher API.
#>
function Test-ProvidersList
{
    # Setup
    $rgname = Get-ResourceGroupName
    $nwName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    $location = "westcentralus"
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }
        
        # Create the Network Watcher
        $tags = @{"key1" = "value1"; "key2" = "value2"}
        $nw = New-AzureRmNetworkWatcher -Name $nwName -ResourceGroupName $rgname -Location $location -Tag $tags

        $job = Get-AzureRmNetworkWatcherReachabilityProvidersList -NetworkWatcher $nw -Location "West US" -Country "United States" -AsJob
        $job | Wait-Job
		$list1 = $job | Receive-Job
		$list2 = Get-AzureRmNetworkWatcherReachabilityProvidersList -NetworkWatcher $nw -Location "West US" -Country "United States" -State "washington"
        $list3 = Get-AzureRmNetworkWatcherReachabilityProvidersList -NetworkWatcher $nw -Location "West US" -Country "United States" -State "washington" -City "seattle"

        Assert-AreEqual $list1.Countries.CountryName "United States"
        Assert-AreEqual $list2.Countries.CountryName "United States"
        Assert-AreEqual $list2.Countries.States.StateName "washington"
        Assert-AreEqual $list3.Countries.CountryName "United States"
        Assert-AreEqual $list3.Countries.States.StateName "washington"
        Assert-AreEqual $list3.Countries.States.Cities.CityName "seattle"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test ConnectionMonitor APIs.
#>
function Test-ConnectionMonitor
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName
    $nwName = Get-ResourceName
    $location = "centraluseuap"
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    $nwLocation = Get-ProviderLocation $resourceTypeParent
    $nwRgName = Get-ResourceGroupName
    $securityGroupName = Get-ResourceName
    $templateFile = "..\..\TestData\Deployment.json"
    $cmName1 = Get-ResourceName
    $cmName2 = Get-ResourceName
    
    try 
    {
        # Create Resource group
        New-AzureRmResourceGroup -Name $resourceGroupName -Location "$location"

        # Deploy resources
        Get-TestResourcesDeployment -rgn "$resourceGroupName"
        
        # Create Resource group for Network Watcher
        New-AzureRmResourceGroup -Name $nwRgName -Location "$location"
        
        # Create Network Watcher
        $nw = New-AzureRmNetworkWatcher -Name $nwName -ResourceGroupName $nwRgName -Location $location

        #Get Vm
        $vm = Get-AzureRmVM -ResourceGroupName $resourceGroupName
        
        #Install networkWatcherAgent on Vm
        Set-AzureRmVMExtension -ResourceGroupName "$resourceGroupName" -Location "$location" -VMName $vm.Name -Name "MyNetworkWatcherAgent" -Type "NetworkWatcherAgentWindows" -TypeHandlerVersion "1.4" -Publisher "Microsoft.Azure.NetworkWatcher" 

        #Create connection monitor
        $job1 = New-AzureRmNetworkWatcherConnectionMonitor -NetworkWatcher $nw -Name $cmName1 -SourceResourceId $vm.Id -DestinationAddress bing.com -DestinationPort 80 -AsJob
        $job1 | Wait-Job
        $cm1 = $job1 | Receive-Job

        #Validation
        Assert-AreEqual $cm1.Name $cmName1
        Assert-AreEqual $cm1.Source.ResourceId $vm.Id
        Assert-AreEqual $cm1.Destination.Address bing.com
        Assert-AreEqual $cm1.Destination.Port 80

        $job2 = New-AzureRmNetworkWatcherConnectionMonitor -NetworkWatcher $nw -Name $cmName2 -SourceResourceId $vm.Id -DestinationAddress google.com -DestinationPort 80 -AsJob
        $job2 | Wait-Job
        $cm2 = $job2 | Receive-Job

        #Validation
        Assert-AreEqual $cm2.Name $cmName2
        Assert-AreEqual $cm2.Source.ResourceId $vm.Id
        Assert-AreEqual $cm2.Destination.Address google.com
        Assert-AreEqual $cm2.Destination.Port 80
        Assert-AreEqual $cm2.MonitoringStatus Running

        #Stop connection monitor
        Stop-AzureRmNetworkWatcherConnectionMonitor -NetworkWatcher $nw -Name $cmName2

        #Get connection monitor
        $cm2 = Get-AzureRmNetworkWatcherConnectionMonitor -NetworkWatcher $nw -Name $cmName2

        #Validation
        Assert-AreEqual $cm2.MonitoringStatus Stopped

        #Start connection monitor
        Start-AzureRmNetworkWatcherConnectionMonitor -NetworkWatcher $nw -Name $cmName2

        #Get connection monitor
        $cm2 = Get-AzureRmNetworkWatcherConnectionMonitor -NetworkWatcher $nw -Name $cmName2

        #Validation
        Assert-AreEqual $cm2.MonitoringStatus Running

        #Query connection monitor
        Get-AzureRmNetworkWatcherConnectionMonitorReport -NetworkWatcher $nw -Name $cmName1

        #Get connection monitor list
        $cmList = Get-AzureRmNetworkWatcherConnectionMonitor -NetworkWatcher $nw

        #Validation
        Assert-AreEqual $cmList.Count 2

        #Remove connection monitor
        Remove-AzureRmNetworkWatcherConnectionMonitor -NetworkWatcher $nw -Name $cmName1

        #Get connection monitor list
        $cmList = Get-AzureRmNetworkWatcherConnectionMonitor -NetworkWatcher $nw

        #Validation
        Assert-AreEqual $cmList.Count 1
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $nwRgName
    }
}
