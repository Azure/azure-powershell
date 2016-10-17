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
Virtual network express route gateway tests
#>
function Test-VirtualNetworkExpressRouteGatewayCRUD
{
 # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $vnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $rglocation = "eastus"
    $resourceTypeParent = "Microsoft.Network/virtualNetworkGateways"
    $location = "eastus"
    
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
	 
      # Create the Virtual Network
      $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create & Get virtualnetworkgateway
      $vnetIpConfig = New-AzureRmVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet

      $actual = New-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType ExpressRoute -GatewaySku UltraPerformance -Force 
      $expected = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $expected.Name $actual.Name	
      #Assert-AreEqual "ExpressRoute" $expected.GatewayType
      
      # List virtualNetworkGateways
      $list = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count
      Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $list[0].Name $actual.Name	
      Assert-AreEqual $list[0].Location $actual.Location
      
      # Delete virtualNetworkGateway
      $delete = Remove-AzureRmVirtualNetworkGateway -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force
      Assert-AreEqual true $delete
      
      $list = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual 0 @($list).Count

     }
     finally
     {
        # Cleanup
        Clean-ResourceGroup $rgname
     }
}

<#
.SYNOPSIS
Virtual network gateway tests
#>
function Test-VirtualNetworkGatewayCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $vnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworkGateways"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      # Create the Virtual Network
      $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create & Get virtualnetworkgateway
      $vnetIpConfig = New-AzureRmVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet

      $actual = New-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false
      $expected = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $expected.Name $actual.Name	
      #Assert-AreEqual "Vpn" $expected.GatewayType
      #Assert-AreEqual "RouteBased" $expected.VpnType
      
      # List virtualNetworkGateways
      $list = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count
      Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $list[0].Name $actual.Name	
      Assert-AreEqual $list[0].Location $actual.Location
      
      # Reset/Reboot virtualNetworkGateway primary
      $actual = Reset-AzureRmVirtualNetworkGateway -VirtualNetworkGateway $expected
      $list = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count

      # Delete virtualNetworkGateway
      $delete = Remove-AzureRmVirtualNetworkGateway -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force
      Assert-AreEqual true $delete
      
      $list = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual 0 @($list).Count
     }
     finally
     {
        # Cleanup
        Clean-ResourceGroup $rgname
     }
}

<#
.SYNOPSIS
Virtual network gateway tests
#>
function Test-SetVirtualNetworkGatewayCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
	$lngName = Get-ResourceName
	$connName = Get-ResourceName
    $vnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworkGateways"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      # Create the Virtual Network
      $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create & Get virtualnetworkgateway
      $vnetIpConfig = New-AzureRmVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
      New-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false -GatewaySku Standard
      $gateway = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname

	  # test Set-AzureRmVirtualNetworkGateway
	  # resize
	  # $sku = "HighPerformance"
	  # $gateway = Set-AzureRmVirtualNetworkGateway -VirtualNetworkGateway $gateway -GatewaySku $sku
	  # Assert-AreEqual $sku $gateway.Sku.Name 

	  # default site - put a local network gateway and set it as the default site
	  $lng = New-AzureRmLocalNetworkGateway -ResourceGroupName $rgname -Name $lngName -Location $location -GatewayIpAddress "1.2.3.4" -AddressPrefix "172.16.1.0/24"
	  $gateway = Set-AzureRmVirtualNetworkGateway -VirtualNetworkGateway $gateway -GatewayDefaultSite $lng
	  Assert-AreEqual $lng.Id $gateway.GatewayDefaultSite.Id 

	  # VPN client things
	  $vpnClientAddressSpace = "192.168.1.0/24"
	  $gateway = Set-AzureRmVirtualNetworkGateway -VirtualNetworkGateway $gateway -VpnClientAddressPool $vpnClientAddressSpace
	  Assert-AreEqual $vpnClientAddressSpace $gateway.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes

	  # BGP settings
	  $asn = 1337
	  $peerweight = 5
	  $gateway = Set-AzureRmVirtualNetworkGateway -VirtualNetworkGateway $gateway -Asn $asn -PeerWeight $peerweight
	  Assert-AreEqual $asn $gateway.BgpSettings.Asn 
	  Assert-AreEqual $peerWeight $gateway.BgpSettings.PeerWeight 
	}
    finally
    {
      # Cleanup
      Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Virtual network gateway tests
#>
function Test-VirtualNetworkGatewayP2SAndSKU
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $vnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworkGateways"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      # Create & Get LocalNetworkGateway      
      $actual = New-AzureRmLocalNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -AddressPrefix 192.168.0.0/16 -GatewayIpAddress 192.168.4.5
      $localnetGateway = Get-AzureRmLocalNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $localnetGateway.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $localnetGateway.Name $actual.Name	
      Assert-AreEqual "192.168.4.5" $localnetGateway.GatewayIpAddress
      Assert-AreEqual "192.168.0.0/16" $localnetGateway.LocalNetworkAddressSpace.AddressPrefixes[0]
      $localnetGateway.Location = $location

      # Create the Virtual Network
      $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

      $clientRootCertName = "BrkLiteTestMSFTRootCA.cer"
      #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
      $samplePublicCertData = "MIIDUzCCAj+gAwIBAgIQRggGmrpGj4pCblTanQRNUjAJBgUrDgMCHQUAMDQxEjAQBgNVBAoTCU1pY3Jvc29mdDEeMBwGA1UEAxMVQnJrIExpdGUgVGVzdCBSb290IENBMB4XDTEzMDExOTAwMjQxOFoXDTIxMDExOTAwMjQxN1owNDESMBAGA1UEChMJTWljcm9zb2Z0MR4wHAYDVQQDExVCcmsgTGl0ZSBUZXN0IFJvb3QgQ0EwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQC7SmE+iPULK0Rs7mQBO/6a6B6/G9BaMxHgDGzAmSG0Qsyt5e08aqgFnPdkMl3zRJw3lPKGha/JCvHRNrO8UpeAfc4IXWaqxx2iBipHjwmHPHh7+VB8lU0EJcUe7WBAI2n/sgfCwc+xKtuyRVlOhT6qw/nAi8e5don/iHPU6q7GCcnqoqtceQ/pJ8m66cvAnxwJlBFOTninhb2VjtvOfMQ07zPP+ZuYDPxvX5v3nd6yDa98yW4dZPuiGO2s6zJAfOPT2BrtyvLekItnSgAw3U5C0bOb+8XVKaDZQXbGEtOw6NZvD4L2yLd47nGkN2QXloiPLGyetrj3Z2pZYcrZBo8hAgMBAAGjaTBnMGUGA1UdAQReMFyAEOncRAPNcvJDoe4WP/gH2U+hNjA0MRIwEAYDVQQKEwlNaWNyb3NvZnQxHjAcBgNVBAMTFUJyayBMaXRlIFRlc3QgUm9vdCBDQYIQRggGmrpGj4pCblTanQRNUjAJBgUrDgMCHQUAA4IBAQCGyHhMdygS0g2tEUtRT4KFM+qqUY5HBpbIXNAav1a1dmXpHQCziuuxxzu3iq4XwnWUF1OabdDE2cpxNDOWxSsIxfEBf9ifaoz/O1ToJ0K757q2Rm2NWqQ7bNN8ArhvkNWa95S9gk9ZHZLUcjqanf0F8taJCYgzcbUSp+VBe9DcN89sJpYvfiBiAsMVqGPc/fHJgTScK+8QYrTRMubtFmXHbzBSO/KTAP5rBTxse88EGjK5F8wcedvge2Ksk6XjL3sZ19+Oj8KTQ72wihN900p1WQldHrrnbixSpmHBXbHr9U0NQigrJp5NphfuU5j81C8ixvfUdwyLmTv7rNA7GTAD";
      $sampleClientCertName = "sampleClientCert.cer"
      $sampleClinentCertThumbprint = "5405D9A8AB2A303D4E772C444BC88C3B97F55F78"

      # Create & Get virtualnetworkgateway
      $vnetIpConfig = New-AzureRmVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
      $rootCert = New-AzureRmVpnClientRootCertificate -Name $clientRootCertName -PublicCertData $samplePublicCertData
      $clientCert = New-AzureRmVpnClientRevokedCertificate -Name $sampleClientCertName -Thumbprint $sampleClinentCertThumbprint
      
      $actual = New-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false -GatewaySku Basic -GatewayDefaultSite $localnetGateway -VpnClientAddressPool 201.169.0.0/16 -VpnClientRootCertificates $rootCert -VpnClientRevokedCertificates $clientCert
      $expected = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $expected.Name $actual.Name	
      Assert-AreEqual "Vpn" $expected.GatewayType
      Assert-AreEqual "RouteBased" $expected.VpnType
      Assert-AreEqual "Basic" $expected.Sku.Tier
      Assert-AreEqual $localnetGateway.Id $expected.GatewayDefaultSite.Id
      Assert-AreEqual $localnetGateway.LocalNetworkAddressSpace $expected.VpnClientConfiguration.VpnClientAddressPool
      Assert-AreEqual $clientRootCertName $expected.VpnClientConfiguration.VpnClientRevokedCertificates[0].name
      Assert-AreEqual $sampleClientCertName $expected.VpnClientConfiguration.VpnClientRootCertificates[0].name

      # Remove default site set for force tunneling
      $actual = Remove-AzureRmVirtualNetworkGatewayDefaultSite -VirtualNetworkGateway $expected
      $expected = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-Null $expected.GatewayDefaultSite

      # Set default site for force tunneling
      Set-AzureRmVirtualNetworkGatewayDefaultSite -VirtualNetworkGateway $expected -GatewayDefaultSite $localnetGateway
      $expected = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $localnetGateway.Id $expected.GatewayDefaultSite.Id

	  # Resize the virtual network gateway from 'Basic' to 'Standard' SKU
	  $actual = Resize-AzureRmVirtualNetworkGateway -VirtualNetworkGateway $expected -GatewaySku "Standard"
      Assert-AreEqual "Succeeded" $actual.ProvisioningState
	  $expected = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname	  
      Assert-AreEqual "Standard" $expected.Sku.Tier

      # Update P2S VPNClient Address Pool
      Set-AzureRmVirtualNetworkGatewayVpnClientConfig -VirtualNetworkGateway $expected -VpnClientAddressPool 200.168.0.0/16
      $expected = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
	  Assert-AreEqual "200.168.0.0/16" $expected.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes
         
     # Get, list client Root certificates
     $rootCert = Get-AzureRmVpnClientRootCertificate -VpnClientRootCertificateName $clientRootCertName -VirtualNetworkGatewayName $expected.Name -ResourceGroupName $expected.ResourceGroupName
     Assert-AreEqual $clientRootCertName $rootCert.Name

     $rootCerts = Get-AzureRmVpnClientRootCertificate -VirtualNetworkGatewayName $expected.Name -ResourceGroupName $expected.ResourceGroupName
     Assert-AreEqual 1 @($rootCerts).Count
     
     # Generate P2S Vpnclient package
     $packageUrl = Get-AzureRmVpnClientPackage -ResourceGroupName $expected.ResourceGroupName -VirtualNetworkGatewayName $expected.Name -ProcessorArchitecture Amd64
     #Assert-NotNull $packageUrl

     # Delete client Root certificate
     $delete = Remove-AzureRmVpnClientRootCertificate -VpnClientRootCertificateName $clientRootCertName -VirtualNetworkGatewayName $expected.Name -ResourceGroupName $expected.ResourceGroupName -PublicCertData $samplePublicCertData
     Assert-AreEqual True $delete
     $rootCerts = Get-AzureRmVpnClientRootCertificate -VirtualNetworkGatewayName $expected.Name -ResourceGroupName $expected.ResourceGroupName
     Assert-AreEqual 0 @($rootCerts).Count
     
     # Add client Root certificate
     $rootCerts = Add-AzureRmVpnClientRootCertificate -VpnClientRootCertificateName $clientRootCertName -VirtualNetworkGatewayName $expected.Name -ResourceGroupName $expected.ResourceGroupName -PublicCertData $samplePublicCertData
     Assert-AreEqual 1 @(rootCerts).Count

     # Get, list Vpn client revoked certificates
     $revokedCerts = Get-AzureRmVpnClientRevokedCertificate -VirtualNetworkGatewayName $expected.Name -ResourceGroupName $expected.ResourceGroupName
     Assert-AreEqual 1 @($revokedCerts).Count

     # Unrevoke previously revoked Vpn client certificate
     $delete = Remove-AzureRmVpnClientRevokedCertificate -VpnClientRevokedCertificateName $sampleClientCertName -VirtualNetworkGatewayName $expected.Name -ResourceGroupName $expected.ResourceGroupName -Thumbprint $sampleClinentCertThumbprint
     Assert-AreEqual True $delete
     $revokedCerts = Get-AzureRmVpnClientRevokedCertificate -VirtualNetworkGatewayName $expected.Name -ResourceGroupName $expected.ResourceGroupName
     Assert-AreEqual 0 @($revokedCerts).Count

     # Revoke Vpn client certificate
     $revokedCerts = Add-AzureRmVpnClientRevokedCertificate -VpnClientRevokedCertificateName $sampleClientCertName -VirtualNetworkGatewayName $expected.Name -ResourceGroupName $expected.ResourceGroupName -Thumbprint $sampleClinentCertThumbprint   
     Assert-AreEqual 1 @($revokedCerts).Count
     $revokedCert = Get-AzureRmVpnClientRevokedCertificate -VpnClientRevokedCertificateName $sampleClientCertName -VirtualNetworkGatewayName $expected.Name -ResourceGroupName $expected.ResourceGroupName
     Assert-AreEqual $sampleClientCertName $revokedCert.Name               
     }
     finally
     {
        # Cleanup
        Clean-ResourceGroup $rgname
     }
}

<#
.SYNOPSIS
Virtual network gateway Active-Active feature test
#>
function Test-VirtualNetworkGatewayActiveActiveFeatureOperations
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel1 = Get-ResourceName
    $domainNameLabel2 = Get-ResourceName
    $vnetName = Get-ResourceName
    $publicIpName1 = Get-ResourceName
    $publicIpName2 = Get-ResourceName
    $vnetGatewayConfigName1 = Get-ResourceName
    $vnetGatewayConfigName2 = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworkGateways"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      # Create the Virtual Network
      $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create Active-Active feature enabled virtualnetworkgateway & Get virtualnetworkgateway
      $publicip1 = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName1 -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel1   
      $vnetIpConfig1 = New-AzureRmVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName1 -PublicIpAddress $publicip1 -Subnet $subnet

      $publicip2 = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName2 -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel2
      $vnetIpConfig2 = New-AzureRmVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName2 -PublicIpAddress $publicip2 -Subnet $subnet

      $actual = New-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -Location $location -IpConfigurations $vnetIpConfig1,$vnetIpConfig2 -GatewayType Vpn -VpnType RouteBased -EnableBgp $false -GatewaySku HighPerformance -EnableActiveActiveFeature
      $expected = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $expected.Name $actual.Name	
      #Assert-AreEqual "Vpn" $expected.GatewayType
      #Assert-AreEqual "RouteBased" $expected.VpnType
      Assert-AreEqual true $expected.ActiveActive
      Assert-AreEqual 2 @($expected.IpConfigurations).Count
	  
      <# ToDo:- Enable this validation afterwards
      # Update virtualNetworkGateway from Active-Active to Active-Standby
      $gw = Get-AzureRmVirtualNetworkGateway -Name $rname -ResourceGroupName $rgname
      Remove-AzureRmVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName2 -VirtualNetworkGateway $gw 
      $expected = Set-AzureRmVirtualNetworkGateway -VirtualNetworkGateway $gw -DisableActiveActiveFeature  
      $expected = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual false $expected.ActiveActive
      Assert-AreEqual 1 @($expected.IpConfigurations).Count
	  
      # Update virtualNetworkGateway from Active-Standby to Active-Active
      $gw = Get-AzureRmVirtualNetworkGateway -Name $rname -ResourceGroupName $rgname
      Add-AzureRmVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName2 -VirtualNetworkGateway $gw 
      $expected = Set-AzureRmVirtualNetworkGateway -VirtualNetworkGateway $gw -EnableActiveActiveFeature
      $expected = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual true $expected.ActiveActive
      Assert-AreEqual 2 @($expected.IpConfigurations).Count
      #>
     }
     finally
     {
        # Cleanup
        Clean-ResourceGroup $rgname
     }
}