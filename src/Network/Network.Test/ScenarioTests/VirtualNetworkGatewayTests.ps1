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
    $rglocation = Get-ProviderLocation ResourceManagement "West Central US"
    $resourceTypeParent = "Microsoft.Network/virtualNetworkGateways"
    $location = Get-ProviderLocation $resourceTypeParent "West Central US"
    
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
	 
      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create & Get virtualnetworkgateway
      $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet

      $actual = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType ExpressRoute -GatewaySku UltraPerformance -VpnType RouteBased -VpnGatewayGeneration None -Force 
      $expected = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $expected.Name $actual.Name	
      Assert-AreEqual "ExpressRoute" $expected.GatewayType
	  Assert-AreEqual "None" $expected.VpnGatewayGeneration
      
      # List virtualNetworkGateways
      $list = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count
      Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $list[0].Name $actual.Name	
      Assert-AreEqual $list[0].Location $actual.Location

      $list = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -Name "*"
      Assert-True { $list.Count -ge 0 }
      
      # Delete virtualNetworkGateway
      $delete = Remove-AzVirtualNetworkGateway -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force
      Assert-AreEqual true $delete
      
      $list = Get-AzVirtualNetworkGateway -ResourceGroupName $actual.ResourceGroupName
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
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create & Get virtualnetworkgateway
      $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
      $ipconfigurationId = $vnetIpConfig.id
      $addresslist = @('169.254.21.25')
      $gw1ipconfBgp = New-AzIpConfigurationBgpPeeringAddressObject -IpConfigurationId $ipconfigurationId -CustomAddress $addresslist
      $job = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -IpConfigurationBgpPeeringAddresses $gw1ipconfBgp -GatewayType Vpn -VpnType RouteBased -EnableBgp $false -DisableIPsecProtection $false -AsJob
	  $job | Wait-Job
	  $actual = $job | Receive-Job
      $expected = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $expected.Name $actual.Name	
      Assert-AreEqual "Vpn" $expected.GatewayType
      Assert-AreEqual "RouteBased" $expected.VpnType
      Assert-AreEqual 1 @($expected.BgpSettings.BGPPeeringAddresses).Count
      Assert-AreEqual $expected.DisableIPsecProtection $actual.DisableIPsecProtection

	  # List virtualNetworkGateways
      $list = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count
      Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $list[0].Name $actual.Name	
      Assert-AreEqual $list[0].Location $actual.Location
      
      # Reset/Reboot virtualNetworkGateway primary
      $job = Reset-AzVirtualNetworkGateway -VirtualNetworkGateway $expected -AsJob
	  $job | Wait-Job
	  $actual = $job | Receive-Job
      $list = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count

	  # Reset/Reboot virtualNetworkGateway by passing gateway vip
	  $publicipAddress = Get-AzPublicIpAddress -Name $publicip.Name -ResourceGroupName $publicip.ResourceGroupName
	  $actual = Reset-AzVirtualNetworkGateway -VirtualNetworkGateway $expected -GatewayVip $publicipAddress.IpAddress
	  $list = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count

      # Delete virtualNetworkGateway
      $job = Remove-AzVirtualNetworkGateway -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force -AsJob
	  $job | Wait-Job
	  $delete = $job | Receive-Job
      Assert-AreEqual true $delete
      
      $list = Get-AzVirtualNetworkGateway -ResourceGroupName $actual.ResourceGroupName
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
function Test-VirtualNetworkGatewayDisableIPsecProtection
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
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create & Get virtualnetworkgateway
      $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
      $ipconfigurationId = $vnetIpConfig.id
      $addresslist = @('169.254.21.25')
      $gw1ipconfBgp = New-AzIpConfigurationBgpPeeringAddressObject -IpConfigurationId $ipconfigurationId -CustomAddress $addresslist
      $job = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -IpConfigurationBgpPeeringAddresses $gw1ipconfBgp -GatewayType Vpn -VpnType RouteBased -EnableBgp $false -DisableIPsecProtection $true -AsJob
	  $job | Wait-Job
	  $actual = $job | Receive-Job
      $expected = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.DisableIPsecProtection $actual.DisableIPsecProtection

      # Delete virtualNetworkGateway
      $job = Remove-AzVirtualNetworkGateway -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force -AsJob
	  $job | Wait-Job
	  $delete = $job | Receive-Job
      Assert-AreEqual true $delete
      
      $list = Get-AzVirtualNetworkGateway -ResourceGroupName $actual.ResourceGroupName
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
function Test-VirtualNetworkGatewayGenerateVpnProfile
{
param 
    ( 
        $basedir = ".\" 
    )

    # Setup
    $rgname = Get-ResourceName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $vnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworkGateways"
    $location = Get-ProviderLocation $resourceTypeParent
	$vpnclientAuthMethod = "EAPTLS"
    
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

      #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
      $samplePublicCertData = "MIIC5zCCAc+gAwIBAgIQFzWsg2N5PItGfI8al3SfETANBgkqhkiG9w0BAQsFADAW MRQwEgYDVQQDDAtQMlNSb290Q2VydDAeFw0yMDEwMjgxODM1MDRaFw0yMTEwMjgx ODU1MDRaMBYxFDASBgNVBAMMC1AyU1Jvb3RDZXJ0MIIBIjANBgkqhkiG9w0BAQEF AAOCAQ8AMIIBCgKCAQEArZqDDCWiXAsrqgYYKDzDgzMKUjgVXgXpfaWltAFJR5rv KFpMJCJldq4YCdpkKT3n0STUz1PJii3cj/o8J9D2XTwdEY+gACOKNn5tRLE+Qz4N r77nfCzTyBNVcgllxoVZgyDhItVoo2JZ2G6+3ywDignfve20Wpj0YGGslanqQsmq o/OeSDNUXGmir4KLwlGjR6+os51y1X3nrqkMpE10K/uIPMe4+WFNrx7g4nOEz+cF vNmi0qdWDpwTg3/JxyhnZVL1TPdeM0zyclnveIvhhseSd3oW5L9OC3eSpPbjD70S UD4vDXrQuUV6SfYAX6aqhNeit/fqrI6ToT86mKwDhQIDAQABozEwLzAOBgNVHQ8B Af8EBAMCAgQwHQYDVR0OBBYEFJ7OyTGgBHVeDBZNKDnenAdlNTfwMA0GCSqGSIb3 DQEBCwUAA4IBAQAWopX5Gj2HslQnVAFzrteg9uIT+q503Zi8FTnGA4hN6I1xq9uo ETNAbQCrHf3R18lL37aP8Z//NVLcx5o+ZD0PMWhb5bhh1FeQ4QCVM0/CJKJqHLZU HCgc7FTiSAtpcGCdmSLM3Uq9Xpn3h5INB5Wekyk1SvyJYuoHqDRMZHKoxqnkYf7x QkThECnubbeFgdA+S/FpMa1+zMDPApcIFQ6/5vOcAEk/iRSv4dZZRyphgy+LlSdM rFKPtpeeEK/OeblVW0mBGIcQyz6sndHwk98u0Is46zlnGFeL7BHEvVSw/QBM6Hcq COZV52zKr851DjkNbHFttGXiwGMsSGdMnjzk"
      $clientRootCertName = "BrkLiteTestMSFTRootCA.cer"
      $rootCert = New-AzVpnClientRootCertificate -Name $clientRootCertName -PublicCertData $samplePublicCertData

      $aadTenant = "https://login.microsoftonline.com/0ab2c4f4-81e6-44cc-a0b2-b3a47a1443f4"
      $aadIssuer = "https://sts.windows.net/0ab2c4f4-81e6-44cc-a0b2-b3a47a1443f4/"
      $aadAudience = "a21fce82-76af-45e6-8583-a08cb3b956f9"

      #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
      $Secure_String_Pwd = ConvertTo-SecureString "radiuspd" -AsPlainText -Force
      $RadiusIP = "1.2.3.4"
      # Create & Get virtualnetworkgateway
      $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
      $actual = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false -GatewaySku VpnGw2 -VpnClientAddressPool 201.169.0.0/16 -VpnAuthenticationType Certificate,Radius,AAD -RadiusServerAddress "1.2.3.4" -RadiusServerSecret $Secure_String_Pwd -VpnClientRootCertificates $rootCert -AadTenantUri $aadTenant -AadAudienceId $aadAudience -AadIssuerUri $aadIssuer -VpnClientProtocol OpenVPN
      $expected = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $expected.Name $actual.Name	
      Assert-AreEqual "Vpn" $expected.GatewayType
      Assert-AreEqual "RouteBased" $expected.VpnType
      Assert-NotNull $expected.VpnClientConfiguration
      $authTypes = $expected.VpnClientConfiguration.VpnAuthenticationTypes
      Assert-NotNull $authTypes
      Assert-AreEqual 3 @($authTypes).Count

      $radiusCertFilePath = $basedir + "\ScenarioTests\Data\ApplicationGatewayAuthCert.cer"
      $vpnProfilePackageUrl = New-AzVpnClientConfiguration -ResourceGroupName $rgname -name $rname -AuthenticationMethod $vpnclientAuthMethod -RadiusRootCertificateFile $radiusCertFilePath
      Assert-NotNull $vpnProfilePackageUrl
      Assert-NotNull $vpnProfilePackageUrl.VpnProfileSASUrl

      $vpnProfilePackageUrl = Get-AzVpnClientConfiguration -ResourceGroupName $rgname -name $rname
      Assert-NotNull $vpnProfilePackageUrl
      Assert-NotNull $vpnProfilePackageUrl.VpnProfileSASUrl
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
    $location = Get-ProviderLocation $resourceTypeParent "East US"
    
    try 
    {
      # Create the resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create & Get virtualnetworkgateway
      $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
      New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false -GatewaySku Standard
      $gateway = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname

	  # default site - put a local network gateway and set it as the default site
	  $lng = New-AzLocalNetworkGateway -ResourceGroupName $rgname -Name $lngName -Location $location -GatewayIpAddress "1.2.3.4" -AddressPrefix "172.16.1.0/24"
	  $job = Set-AzVirtualNetworkGateway -VirtualNetworkGateway $gateway -GatewayDefaultSite $lng -AsJob
	  $job | Wait-Job
	  $gateway = $job | Receive-Job
	  Assert-AreEqual $lng.Id $gateway.GatewayDefaultSite.Id 

	  # VPN client things
	  $vpnClientAddressSpace = "192.168.1.0/24"
	  $gateway = Set-AzVirtualNetworkGateway -VirtualNetworkGateway $gateway -VpnClientAddressPool $vpnClientAddressSpace
	  Assert-AreEqual $vpnClientAddressSpace $gateway.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes

	  # BGP settings
	  $asn = 1337
	  $peerweight = 5
	  $gateway = Set-AzVirtualNetworkGateway -VirtualNetworkGateway $gateway -Asn $asn -PeerWeight $peerweight
	  Assert-AreEqual $asn $gateway.BgpSettings.Asn 
	  Assert-AreEqual $peerWeight $gateway.BgpSettings.PeerWeight

      # BGPPeeringAddresses
      $ipconfigurationId1 = $gateway.ipconfigurations[0].id
      $addresslist1 = @('169.254.21.10')
      $gw1ipconfBgp1 = New-AzIpConfigurationBgpPeeringAddressObject -IpConfigurationId $ipconfigurationId1 -CustomAddress $addresslist1
      $gateway = Set-AzVirtualNetworkGateway -VirtualNetworkGateway $gateway -IpConfigurationBgpPeeringAddresses $gw1ipconfBgp1
       Assert-AreEqual $ipconfigurationId1 $gateway.BgpSettings.BGPPeeringAddresses[0].IpConfigurationId
      
	  # Tags
	  $gateway = Set-AzVirtualNetworkGateway -VirtualNetworkGateway $gateway -Tag @{ testtagKey="SomeTagKey"; testtagValue="SomeKeyValue" }
	  Assert-AreEqual 2 $gateway.Tag.Count
	  Assert-AreEqual $true $gateway.Tag.Contains("testtagKey")
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
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }
      
      # Create & Get LocalNetworkGateway      
      $actual = New-AzLocalNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -AddressPrefix 192.168.0.0/16 -GatewayIpAddress 192.168.4.5
      $localnetGateway = Get-AzLocalNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $localnetGateway.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $localnetGateway.Name $actual.Name	
      Assert-AreEqual "192.168.4.5" $localnetGateway.GatewayIpAddress
      Assert-AreEqual "192.168.0.0/16" $localnetGateway.LocalNetworkAddressSpace.AddressPrefixes[0]

      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

      $clientRootCertName = "BrkLiteTestMSFTRootCA.cer"
      #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
      $samplePublicCertData =  "MIIC5zCCAc+gAwIBAgIQFzWsg2N5PItGfI8al3SfETANBgkqhkiG9w0BAQsFADAW MRQwEgYDVQQDDAtQMlNSb290Q2VydDAeFw0yMDEwMjgxODM1MDRaFw0yMTEwMjgx ODU1MDRaMBYxFDASBgNVBAMMC1AyU1Jvb3RDZXJ0MIIBIjANBgkqhkiG9w0BAQEF AAOCAQ8AMIIBCgKCAQEArZqDDCWiXAsrqgYYKDzDgzMKUjgVXgXpfaWltAFJR5rv KFpMJCJldq4YCdpkKT3n0STUz1PJii3cj/o8J9D2XTwdEY+gACOKNn5tRLE+Qz4N r77nfCzTyBNVcgllxoVZgyDhItVoo2JZ2G6+3ywDignfve20Wpj0YGGslanqQsmq o/OeSDNUXGmir4KLwlGjR6+os51y1X3nrqkMpE10K/uIPMe4+WFNrx7g4nOEz+cF vNmi0qdWDpwTg3/JxyhnZVL1TPdeM0zyclnveIvhhseSd3oW5L9OC3eSpPbjD70S UD4vDXrQuUV6SfYAX6aqhNeit/fqrI6ToT86mKwDhQIDAQABozEwLzAOBgNVHQ8B Af8EBAMCAgQwHQYDVR0OBBYEFJ7OyTGgBHVeDBZNKDnenAdlNTfwMA0GCSqGSIb3 DQEBCwUAA4IBAQAWopX5Gj2HslQnVAFzrteg9uIT+q503Zi8FTnGA4hN6I1xq9uo ETNAbQCrHf3R18lL37aP8Z//NVLcx5o+ZD0PMWhb5bhh1FeQ4QCVM0/CJKJqHLZU HCgc7FTiSAtpcGCdmSLM3Uq9Xpn3h5INB5Wekyk1SvyJYuoHqDRMZHKoxqnkYf7x QkThECnubbeFgdA+S/FpMa1+zMDPApcIFQ6/5vOcAEk/iRSv4dZZRyphgy+LlSdM rFKPtpeeEK/OeblVW0mBGIcQyz6sndHwk98u0Is46zlnGFeL7BHEvVSw/QBM6Hcq COZV52zKr851DjkNbHFttGXiwGMsSGdMnjzk"
      $sampleClientCertName = "sampleClientCert.cer"
      $sampleClinentCertThumbprint = "5405D9A8AB2A303D4E772C444BC88C3B97F55F78"

      # Create & Get virtualnetworkgateway
      $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
      $rootCert = New-AzVpnClientRootCertificate -Name $clientRootCertName -PublicCertData $samplePublicCertData
      $clientCert = New-AzVpnClientRevokedCertificate -Name $sampleClientCertName -Thumbprint $sampleClinentCertThumbprint
      
      $actual = New-AzVirtualNetworkGateway -GatewayDefaultSite $localnetGateway -ResourceGroupName $rgname -Name $rname -Location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false -GatewaySku VpnGw1 -VpnClientAddressPool "201.169.0.0/16" -VpnClientProtocol SSTP -VpnClientRootCertificates $rootCert -VpnClientRevokedCertificates $clientCert
      $expected = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $expected.Name $actual.Name	
      Assert-AreEqual "Vpn" $expected.GatewayType
      Assert-AreEqual "RouteBased" $expected.VpnType
      Assert-AreEqual "VpnGw1" $expected.Sku.Tier
      Assert-AreEqual $localnetGateway.Id $expected.GatewayDefaultSite.Id
      Assert-AreEqual "201.169.0.0/16" $expected.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes[0]
      Assert-AreEqual $sampleClientCertName $expected.VpnClientConfiguration.VpnClientRevokedCertificates[0].name
      Assert-AreEqual $clientRootCertName $expected.VpnClientConfiguration.VpnClientRootCertificates[0].name

      # Remove default site set for force tunneling
      $actual = Remove-AzVirtualNetworkGatewayDefaultSite -VirtualNetworkGateway $expected
	  $expected = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-Null $expected.GatewayDefaultSite

      # Set default site for force tunneling
      Set-AzVirtualNetworkGatewayDefaultSite -VirtualNetworkGateway $expected -GatewayDefaultSite $localnetGateway
      $expected = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $localnetGateway.Id $expected.GatewayDefaultSite.Id

	  # Resize the virtual network gateway from 'VpnGw1' to 'VpnGw2' SKU
	  $actual = Resize-AzVirtualNetworkGateway -VirtualNetworkGateway $expected -GatewaySku VpnGw2
      Assert-AreEqual "Succeeded" $actual.ProvisioningState
	  $expected = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname	  
      Assert-AreEqual "VpnGw2" $expected.Sku.Tier

     # Get, list client Root certificates
     $rootCert = Get-AzVpnClientRootCertificate -VpnClientRootCertificateName $clientRootCertName -VirtualNetworkGatewayName $expected.Name -ResourceGroupName $expected.ResourceGroupName
     Assert-AreEqual $clientRootCertName $rootCert.Name

     $rootCerts = Get-AzVpnClientRootCertificate -VirtualNetworkGatewayName $expected.Name -ResourceGroupName $expected.ResourceGroupName
     Assert-AreEqual 1 @($rootCerts).Count
     
     # Generate P2S Vpnclient package
     $packageUrl = Get-AzVpnClientPackage -ResourceGroupName $expected.ResourceGroupName -VirtualNetworkGatewayName $expected.Name -ProcessorArchitecture Amd64
	 #Assert-NotNull $packageUrl

     # Delete client Root certificate
     $delete = Remove-AzVpnClientRootCertificate -VpnClientRootCertificateName $clientRootCertName -VirtualNetworkGatewayName $expected.Name -ResourceGroupName $expected.ResourceGroupName -PublicCertData $samplePublicCertData
	 Assert-AreEqual True $delete
     $rootCerts = Get-AzVpnClientRootCertificate -VirtualNetworkGatewayName $expected.Name -ResourceGroupName $expected.ResourceGroupName
     Assert-AreEqual 0 @($rootCerts).Count
     
     # Add client Root certificate
     $rootCerts = Add-AzVpnClientRootCertificate -VpnClientRootCertificateName $clientRootCertName -VirtualNetworkGatewayName $expected.Name -ResourceGroupName $expected.ResourceGroupName -PublicCertData $samplePublicCertData
	 Assert-AreEqual 1 @($rootCerts).Count

     # Get, list Vpn client revoked certificates
     $revokedCerts = Get-AzVpnClientRevokedCertificate -VirtualNetworkGatewayName $expected.Name -ResourceGroupName $expected.ResourceGroupName
     Assert-AreEqual 1 @($revokedCerts).Count

     # Unrevoke previously revoked Vpn client certificate
     $delete = Remove-AzVpnClientRevokedCertificate -VpnClientRevokedCertificateName $sampleClientCertName -VirtualNetworkGatewayName $expected.Name -ResourceGroupName $expected.ResourceGroupName -Thumbprint $sampleClinentCertThumbprint
	 Assert-AreEqual True $delete
     $revokedCerts = Get-AzVpnClientRevokedCertificate -VirtualNetworkGatewayName $expected.Name -ResourceGroupName $expected.ResourceGroupName
     Assert-AreEqual 0 @($revokedCerts).Count

     # Revoke Vpn client certificate
     $revokedCerts = Add-AzVpnClientRevokedCertificate -VpnClientRevokedCertificateName $sampleClientCertName -VirtualNetworkGatewayName $expected.Name -ResourceGroupName $expected.ResourceGroupName -Thumbprint $sampleClinentCertThumbprint
	 Assert-AreEqual 1 @($revokedCerts).Count
     $revokedCert = Get-AzVpnClientRevokedCertificate -VpnClientRevokedCertificateName $sampleClientCertName -VirtualNetworkGatewayName $expected.Name -ResourceGroupName $expected.ResourceGroupName
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
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create Active-Active feature enabled virtualnetworkgateway & Get virtualnetworkgateway
      $publicip1 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName1 -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel1   
      $vnetIpConfig1 = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName1 -PublicIpAddress $publicip1 -Subnet $subnet

      $publicip2 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName2 -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel2
      $vnetIpConfig2 = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName2 -PublicIpAddress $publicip2 -Subnet $subnet

      $actual = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -Location $location -IpConfigurations $vnetIpConfig1,$vnetIpConfig2 -GatewayType Vpn -VpnType RouteBased -EnableBgp $false -GatewaySku VpnGw1 -EnableActiveActiveFeature
      $expected = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $expected.Name $actual.Name	
      Assert-AreEqual "Vpn" $expected.GatewayType
      Assert-AreEqual "RouteBased" $expected.VpnType
      Assert-AreEqual true $expected.ActiveActive
      Assert-AreEqual 2 @($expected.IpConfigurations).Count

      # Update virtualNetworkGateway from Active-Active to Active-Standby
      $gw = Get-AzVirtualNetworkGateway -Name $rname -ResourceGroupName $rgname
      Remove-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName2 -VirtualNetworkGateway $gw 
      $expected = Set-AzVirtualNetworkGateway -VirtualNetworkGateway $gw -GatewaySku VpnGw2 -DisableActiveActiveFeature
      $expected = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual false $expected.ActiveActive
      Assert-AreEqual 1 @($expected.IpConfigurations).Count

      # Update virtualNetworkGateway from Active-Standby to Active-Active
      $gw = Get-AzVirtualNetworkGateway -Name $rname -ResourceGroupName $rgname
      Add-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName2 -VirtualNetworkGateway $gw -PublicIpAddress $publicip2 -Subnet $subnet
      $expected = Set-AzVirtualNetworkGateway -VirtualNetworkGateway $gw -GatewaySku VpnGw3 -EnableActiveActiveFeature
      $expected = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual true $expected.ActiveActive
      Assert-AreEqual 2 @($expected.IpConfigurations).Count
     }
     finally
     {
        # Cleanup
        Clean-ResourceGroup $rgname
     }
}

<#
.SYNOPSIS
Virtual network gateway BGP route API test
#>
function Test-VirtualNetworkGatewayBgpRouteApi
{
	# Setup
	$rgname = Get-ResourceGroupName
	$gwname = Get-ResourceName
	$domainNameLabel = Get-ResourceName
	$vnetName = Get-ResourceName
	$publicIpName = Get-ResourceName
	$vnetGatewayConfigName = Get-ResourceName
	$rgLocation = Get-ProviderLocation ResourceManagement
	$resourceTypeParent = "Microsoft.Network/virtualNetworkGateways"
	$location = Get-ProviderLocation $resourceTypeParent

	$gwname1 = Get-ResourceName
	$vnetName1 = Get-ResourceName
	$publicIpName1 = Get-ResourceName
	$domainNameLabel1 = Get-ResourceName
	$vnetGatewayConfigName1 = Get-ResourceName

	$connectionName = Get-ResourceName
	$connectionName1 = Get-ResourceName

	try 
	{
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation
		$subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel
		$vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
		$gw = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $gwname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -GatewaySku Standard
		$gw = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $gwname

		$subnet1 = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.1.0.0/24
		$vnet1 = New-AzVirtualNetwork -Name $vnetName1 -ResourceGroupName $rgname -Location $location -AddressPrefix 10.1.0.0/16  -Subnet $subnet1
		$vnet1 = Get-AzVirtualNetwork -Name $vnetName1 -ResourceGroupName $rgname
		$subnet1 = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet1
		$publicip1 = New-AzPublicIpAddress -Name $publicIpName1 -ResourceGroupName $rgname -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel1
		$vnetIpConfig1 = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName1 -PublicIpAddress $publicip1 -Subnet $subnet1
		$gw1 = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $gwname1 -location $location -IpConfigurations $vnetIpConfig1 -GatewayType Vpn -VpnType RouteBased -GatewaySku Standard -Asn 1337
		$gw1 = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $gwname1

		New-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $connectionName -location $location -VirtualNetworkGateway1 $gw -VirtualNetworkGateway2 $gw1 -ConnectionType Vnet2Vnet -SharedKey chocolate -EnableBgp $true
		New-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $connectionName1 -location $location -VirtualNetworkGateway1 $gw1 -VirtualNetworkGateway2 $gw -ConnectionType Vnet2Vnet -SharedKey chocolate -EnableBgp $true

		$job = Get-AzVirtualNetworkGatewayBGPPeerStatus -ResourceGroupName $rgname -VirtualNetworkGatewayName $gwname -AsJob
		$job | Wait-Job
		$bgpPeerStatus = $job | Receive-Job

		$job = Get-AzVirtualNetworkGatewayLearnedRoute -ResourceGroupName $rgname -VirtualNetworkGatewayName $gwname -AsJob
		$job | Wait-Job
		$bgpLearnedRoutes = $job | Receive-Job

        if($bgpLearnedRoutes -and $bgpLearnedRoutes.Length -gt 0)
        {
            forEach($route in $bgpLearnedRoutes)
            {
                if($route.Origin -eq "EBgp")
                {
                    Assert-True { $vnet1.AddressSpace.AddressPrefixes -contains $route.Network }
                }
            }
        }

        if($bgpPeerStatus -and $bgpPeerStatus.Length -gt 0)
        {
            $job = Get-AzVirtualNetworkGatewayAdvertisedRoute -ResourceGroupName $rgname -VirtualNetworkGatewayName $gwname -Peer $bgpPeerStatus[0].Neighbor -AsJob
            $job | Wait-Job
            $bgpAdvertisedRoutes = $job | Receive-Job
            Assert-True { $vnet.AddressSpace.AddressPrefixes -contains $bgpAdvertisedRoutes[0].Network }
        }
	}
	finally 
	{
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Virtual network gateway P2S API test
#>
function Test-VirtualNetworkGatewayIkeV2
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
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }
	
		# create the client root cert
		$clientRootCertName = "BrkLiteTestMSFTRootCA.cer"
		#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
		$samplePublicCertData = "MIIC5zCCAc+gAwIBAgIQFzWsg2N5PItGfI8al3SfETANBgkqhkiG9w0BAQsFADAW MRQwEgYDVQQDDAtQMlNSb290Q2VydDAeFw0yMDEwMjgxODM1MDRaFw0yMTEwMjgx ODU1MDRaMBYxFDASBgNVBAMMC1AyU1Jvb3RDZXJ0MIIBIjANBgkqhkiG9w0BAQEF AAOCAQ8AMIIBCgKCAQEArZqDDCWiXAsrqgYYKDzDgzMKUjgVXgXpfaWltAFJR5rv KFpMJCJldq4YCdpkKT3n0STUz1PJii3cj/o8J9D2XTwdEY+gACOKNn5tRLE+Qz4N r77nfCzTyBNVcgllxoVZgyDhItVoo2JZ2G6+3ywDignfve20Wpj0YGGslanqQsmq o/OeSDNUXGmir4KLwlGjR6+os51y1X3nrqkMpE10K/uIPMe4+WFNrx7g4nOEz+cF vNmi0qdWDpwTg3/JxyhnZVL1TPdeM0zyclnveIvhhseSd3oW5L9OC3eSpPbjD70S UD4vDXrQuUV6SfYAX6aqhNeit/fqrI6ToT86mKwDhQIDAQABozEwLzAOBgNVHQ8B Af8EBAMCAgQwHQYDVR0OBBYEFJ7OyTGgBHVeDBZNKDnenAdlNTfwMA0GCSqGSIb3 DQEBCwUAA4IBAQAWopX5Gj2HslQnVAFzrteg9uIT+q503Zi8FTnGA4hN6I1xq9uo ETNAbQCrHf3R18lL37aP8Z//NVLcx5o+ZD0PMWhb5bhh1FeQ4QCVM0/CJKJqHLZU HCgc7FTiSAtpcGCdmSLM3Uq9Xpn3h5INB5Wekyk1SvyJYuoHqDRMZHKoxqnkYf7x QkThECnubbeFgdA+S/FpMa1+zMDPApcIFQ6/5vOcAEk/iRSv4dZZRyphgy+LlSdM rFKPtpeeEK/OeblVW0mBGIcQyz6sndHwk98u0Is46zlnGFeL7BHEvVSw/QBM6Hcq COZV52zKr851DjkNbHFttGXiwGMsSGdMnjzk"
        $rootCert = New-AzVpnClientRootCertificate -Name $clientRootCertName -PublicCertData $samplePublicCertData

		# Create the Virtual Network
		$subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname      
		$subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

		# Create the IP config
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel
		$vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
      
		# Create & Get IkeV2 + SSTP virtualnetworkgateway
		New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false -GatewaySku VpnGw1 -VpnClientAddressPool 201.169.0.0/16 -VpnClientRootCertificates $rootCert -CustomRoute 192.168.0.0/24 -VpnClientProtocol "SSTP","IkeV2"
		$actual = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
		Assert-AreEqual "VpnGw1" $actual.Sku.Tier
		$protocols = $actual.VpnClientConfiguration.VpnClientProtocols
		Assert-AreEqual 2 @($protocols).Count
		Assert-AreEqual "SSTP" $protocols[0]
		Assert-AreEqual "IkeV2" $protocols[1]
		Assert-AreEqual "201.169.0.0/16" $actual.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes
        Assert-AreEqual "192.168.0.0/24" $actual.CustomRoutes.AddressPrefixes

		# Update gateway to IkeV2 only and update Custom routes
		Set-AzVirtualNetworkGateway -VirtualNetworkGateway $actual -VpnClientProtocol IkeV2 -CustomRoute 192.168.1.0/24
		$actual = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
		$protocols = $actual.VpnClientConfiguration.VpnClientProtocols
		Assert-AreEqual 1 @($protocols).Count
		Assert-AreEqual "IkeV2" $protocols[0]
        Assert-AreEqual "192.168.1.0/24" $actual.CustomRoutes.AddressPrefixes
		 
		# Update gateway to remove the Custom routes
        Set-AzVirtualNetworkGateway -VirtualNetworkGateway $actual -VpnClientProtocol IkeV2 -CustomRoute @()
        $actual = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
        Assert-Null  $actual.CustomRoutes.AddressPrefixes
	}
	finally
    {
		# Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Virtual network gateway P2S radius API test
#>
function Test-VirtualNetworkGatewayRadius
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
        # Create the multiple radius servers settings
        #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
        $radiuspd = ConvertTo-SecureString -String "radiuspd" -AsPlainText -Force
        $radiusServer1 = New-AzRadiusServer -RadiusServerAddress 10.1.0.1 -RadiusServerSecret $radiuspd -RadiusServerScore 30
        $radiusServer2 = New-AzRadiusServer -RadiusServerAddress 10.1.0.2 -RadiusServerSecret $radiuspd -RadiusServerScore 1
        $radiusServer3 = New-AzRadiusServer -RadiusServerAddress 10.1.0.3 -RadiusServerSecret $radiuspd -RadiusServerScore 15
        $radiusServers = @( $radiusServer1, $radiusServer2 )

		# Create the resource group
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }
	
		# Create the Virtual Network
		$subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname      
		$subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

		# Create the IP config
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel
		$vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet

		# Create & Get virtualnetworkgateway
		New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false -GatewaySku VpnGw1 -VpnClientAddressPool 201.169.0.0/16 -VpnClientProtocol "IkeV2" -RadiusServerList $radiusServers
		$actual = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
        Assert-AreEqual $actual.VpnClientConfiguration.RadiusServers.Count 2 
		Assert-AreEqual $actual.VpnClientConfiguration.RadiusServers[0].RadiusServerAddress $radiusServer1.RadiusServerAddress
		Assert-AreEqual $actual.VpnClientConfiguration.RadiusServers[0].RadiusServerScore $radiusServer1.RadiusServerScore
		Assert-AreEqual $actual.VpnClientConfiguration.RadiusServers[1].RadiusServerAddress $radiusServer2.RadiusServerAddress
		Assert-AreEqual $actual.VpnClientConfiguration.RadiusServers[1].RadiusServerScore $radiusServer2.RadiusServerScore
		 
		# Update gateway to singular radius
        Set-AzVirtualNetworkGateway -VirtualNetworkGateway $actual -VpnClientAddressPool 201.169.0.0/16 -VpnClientProtocol "IkeV2" -RadiusServerAddress 10.1.0.2 -RadiusServerSecret $radiuspd
        $actual = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
        Assert-Null  $actual.VpnClientConfiguration.RadiusServers
        Assert-AreEqual $actual.VpnClientConfiguration.RadiusServerAddress 10.1.0.2

		# Update gateway radius settings
        $radiusServers = @($radiusServer3, $radiusServer1)
		Set-AzVirtualNetworkGateway -VirtualNetworkGateway $actual -VpnClientAddressPool 201.169.0.0/16 -VpnClientProtocol "IkeV2" -RadiusServerList $radiusServers
		$actual = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
        Assert-Null  $actual.VpnClientConfiguration.RadiusServerAddress
        Assert-AreEqual $actual.VpnClientConfiguration.RadiusServers.Count 2 
		Assert-AreEqual $actual.VpnClientConfiguration.RadiusServers[0].RadiusServerAddress $radiusServer3.RadiusServerAddress
		Assert-AreEqual $actual.VpnClientConfiguration.RadiusServers[0].RadiusServerScore $radiusServer3.RadiusServerScore
		Assert-AreEqual $actual.VpnClientConfiguration.RadiusServers[1].RadiusServerAddress $radiusServer1.RadiusServerAddress
		Assert-AreEqual $actual.VpnClientConfiguration.RadiusServers[1].RadiusServerScore $radiusServer1.RadiusServerScore
	}
    finally
    {
		# Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Virtual network gateway P2S OpenVPN API test
#>
function Test-VirtualNetworkGatewayOpenVPN
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
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }
	
		# create the client root cert
		$clientRootCertName = "BrkLiteTestMSFTRootCA.cer"
		#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
		$samplePublicCertData = "MIIC5zCCAc+gAwIBAgIQFzWsg2N5PItGfI8al3SfETANBgkqhkiG9w0BAQsFADAW MRQwEgYDVQQDDAtQMlNSb290Q2VydDAeFw0yMDEwMjgxODM1MDRaFw0yMTEwMjgx ODU1MDRaMBYxFDASBgNVBAMMC1AyU1Jvb3RDZXJ0MIIBIjANBgkqhkiG9w0BAQEF AAOCAQ8AMIIBCgKCAQEArZqDDCWiXAsrqgYYKDzDgzMKUjgVXgXpfaWltAFJR5rv KFpMJCJldq4YCdpkKT3n0STUz1PJii3cj/o8J9D2XTwdEY+gACOKNn5tRLE+Qz4N r77nfCzTyBNVcgllxoVZgyDhItVoo2JZ2G6+3ywDignfve20Wpj0YGGslanqQsmq o/OeSDNUXGmir4KLwlGjR6+os51y1X3nrqkMpE10K/uIPMe4+WFNrx7g4nOEz+cF vNmi0qdWDpwTg3/JxyhnZVL1TPdeM0zyclnveIvhhseSd3oW5L9OC3eSpPbjD70S UD4vDXrQuUV6SfYAX6aqhNeit/fqrI6ToT86mKwDhQIDAQABozEwLzAOBgNVHQ8B Af8EBAMCAgQwHQYDVR0OBBYEFJ7OyTGgBHVeDBZNKDnenAdlNTfwMA0GCSqGSIb3 DQEBCwUAA4IBAQAWopX5Gj2HslQnVAFzrteg9uIT+q503Zi8FTnGA4hN6I1xq9uo ETNAbQCrHf3R18lL37aP8Z//NVLcx5o+ZD0PMWhb5bhh1FeQ4QCVM0/CJKJqHLZU HCgc7FTiSAtpcGCdmSLM3Uq9Xpn3h5INB5Wekyk1SvyJYuoHqDRMZHKoxqnkYf7x QkThECnubbeFgdA+S/FpMa1+zMDPApcIFQ6/5vOcAEk/iRSv4dZZRyphgy+LlSdM rFKPtpeeEK/OeblVW0mBGIcQyz6sndHwk98u0Is46zlnGFeL7BHEvVSw/QBM6Hcq COZV52zKr851DjkNbHFttGXiwGMsSGdMnjzk"
        $rootCert = New-AzVpnClientRootCertificate -Name $clientRootCertName -PublicCertData $samplePublicCertData
        #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
        $Secure_String_Pwd = ConvertTo-SecureString "radiuspd" -AsPlainText -Force
        $aadTenant = "https://login.microsoftonline.com/0ab2c4f4-81e6-44cc-a0b2-b3a47a1443f4"
        $aadIssuer = "https://sts.windows.net/0ab2c4f4-81e6-44cc-a0b2-b3a47a1443f4/"
        $aadAudience = "a21fce82-76af-45e6-8583-a08cb3b956f9"

		# Create the Virtual Network
		$subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname      
		$subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

		# Create the IP config
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel
		$vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
      
		# Create & Get OpenVPN virtualnetworkgateway
		New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false -GatewaySku VpnGw1 -VpnClientAddressPool 201.169.0.0/16 -VpnAuthenticationType Certificate,Radius -RadiusServerAddress "1.2.3.4" -RadiusServerSecret $Secure_String_Pwd -VpnClientRootCertificates $rootCert  
		$actual = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
		Set-AzVirtualNetworkGateway -VirtualNetworkGateway $actual -VpnClientProtocol OpenVPN  -VpnAuthenticationType Certificate,Radius,AAD -AadTenantUri $aadTenant -AadAudienceId $aadAudience -AadIssuerUri $aadIssuer
		$actual = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname

		Assert-AreEqual "VpnGw1" $actual.Sku.Tier
		$protocols = $actual.VpnClientConfiguration.VpnClientProtocols
        $authTypes = $actual.VpnClientConfiguration.VpnAuthenticationTypes
		Assert-AreEqual 1 @($protocols).Count
		Assert-AreEqual "OpenVPN" $protocols[0]
		Assert-AreEqual "201.169.0.0/16" $actual.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes
        Assert-AreEqual 3 @($authTypes).Count

        Set-AzVirtualNetworkGateway -VirtualNetworkGateway $actual -VpnAuthenticationType Certificate
		$actual = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
        $authTypes = $actual.VpnClientConfiguration.VpnAuthenticationTypes
        Assert-AreEqual 1 @($authTypes).Count
        Assert-AreEqual "" $actual.VpnClientConfiguration.AadAudience
        Assert-AreEqual "" $actual.VpnClientConfiguration.RadiusServerAddress

        Set-AzVirtualNetworkGateway -VirtualNetworkGateway $actual -VpnClientProtocol OpenVPN  -VpnAuthenticationType Certificate,Radius,AAD -AadTenantUri $aadTenant -AadAudienceId $aadAudience -AadIssuerUri $aadIssuer -RadiusServerAddress "1.2.3.4" -RadiusServerSecret $Secure_String_Pwd
		$actual = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
        $authTypes = $actual.VpnClientConfiguration.VpnAuthenticationTypes
        Assert-AreEqual 3 @($authTypes).Count
        Assert-AreEqual $aadAudience $actual.VpnClientConfiguration.AadAudience
        Assert-AreEqual "1.2.3.4" $actual.VpnClientConfiguration.RadiusServerAddress
        Assert-NotNull $actual.VpnClientConfiguration.VpnClientRootCertificates
	}
	finally
    {
		# Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Virtual network gateway P2S OpenVPN AAD authentication API test
#>
function Test-VirtualNetworkGatewayOpenVPNAADAuth
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
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }
	
		# AAD authentication configurations
		$aadTenant = "https://login.microsoftonline.com/0ab2c4f4-81e6-44cc-a0b2-b3a47a1443f4"
		$aadIssuer = "https://sts.windows.net/0ab2c4f4-81e6-44cc-a0b2-b3a47a1443f4/"
		$aadAudience = "a21fce82-76af-45e6-8583-a08cb3b956f9"
		$aadAudienceNew = "a21fce82-76af-45e6-8583-a08cb3b956g9"

		# Create the Virtual Network
		$subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname      
		$subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

		# Create the IP config
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel
		$vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
      
		# Create & Get P2S OpenVPN AAD authentication on virtualnetworkgateway
		New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -VpnClientProtocol OpenVPN -EnableBgp $false -GatewaySku VpnGw1 -VpnClientAddressPool 201.169.0.0/16 #-AadTenantUri $aadTenant -AadIssuerUri $aadIssuer -AadAudienceId $aadAudience
		$actual = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
		$protocols = $actual.VpnClientConfiguration.VpnClientProtocols
		Assert-AreEqual 1 @($protocols).Count
		Assert-AreEqual "OpenVPN" $protocols[0]
		Assert-AreEqual "201.169.0.0/16" $actual.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes
		#Assert-AreEqual $aadTenant $actual.VpnClientConfiguration.AadTenant
		#Assert-AreEqual $aadIssuer $actual.VpnClientConfiguration.AadIssuer
		#Assert-AreEqual $aadAudience $actual.VpnClientConfiguration.AadAudience

		# Set an existing virtualnetworkgateway with updated AAD authentication configuration.
		Set-AzVirtualNetworkGateway -VirtualNetworkGateway $actual -AadTenantUri $aadTenant -AadIssuerUri $aadIssuer -AadAudienceId $aadAudienceNew
		$actual = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname

		Assert-AreEqual "VpnGw1" $actual.Sku.Tier
		$protocols = $actual.VpnClientConfiguration.VpnClientProtocols
		Assert-AreEqual 1 @($protocols).Count
		Assert-AreEqual "OpenVPN" $protocols[0]
		Assert-AreEqual "201.169.0.0/16" $actual.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes
		Assert-AreEqual $aadTenant $actual.VpnClientConfiguration.AadTenant
		Assert-AreEqual $aadIssuer $actual.VpnClientConfiguration.AadIssuer
		Assert-AreEqual $aadAudienceNew $actual.VpnClientConfiguration.AadAudience

		# create the client root cert
		$clientRootCertName = "BrkLiteTestMSFTRootCA.cer"
		#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
		$samplePublicCertData = "MIIDUzCCAj+gAwIBAgIQRggGmrpGj4pCblTanQRNUjAJBgUrDgMCHQUAMDQxEjAQBgNVBAoTCU1pY3Jvc29mdDEeMBwGA1UEAxMVQnJrIExpdGUgVGVzdCBSb290IENBMB4XDTEzMDExOTAwMjQxOFoXDTIxMDExOTAwMjQxN1owNDESMBAGA1UEChMJTWljcm9zb2Z0MR4wHAYDVQQDExVCcmsgTGl0ZSBUZXN0IFJvb3QgQ0EwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQC7SmE+iPULK0Rs7mQBO/6a6B6/G9BaMxHgDGzAmSG0Qsyt5e08aqgFnPdkMl3zRJw3lPKGha/JCvHRNrO8UpeAfc4IXWaqxx2iBipHjwmHPHh7+VB8lU0EJcUe7WBAI2n/sgfCwc+xKtuyRVlOhT6qw/nAi8e5don/iHPU6q7GCcnqoqtceQ/pJ8m66cvAnxwJlBFOTninhb2VjtvOfMQ07zPP+ZuYDPxvX5v3nd6yDa98yW4dZPuiGO2s6zJAfOPT2BrtyvLekItnSgAw3U5C0bOb+8XVKaDZQXbGEtOw6NZvD4L2yLd47nGkN2QXloiPLGyetrj3Z2pZYcrZBo8hAgMBAAGjaTBnMGUGA1UdAQReMFyAEOncRAPNcvJDoe4WP/gH2U+hNjA0MRIwEAYDVQQKEwlNaWNyb3NvZnQxHjAcBgNVBAMTFUJyayBMaXRlIFRlc3QgUm9vdCBDQYIQRggGmrpGj4pCblTanQRNUjAJBgUrDgMCHQUAA4IBAQCGyHhMdygS0g2tEUtRT4KFM+qqUY5HBpbIXNAav1a1dmXpHQCziuuxxzu3iq4XwnWUF1OabdDE2cpxNDOWxSsIxfEBf9ifaoz/O1ToJ0K757q2Rm2NWqQ7bNN8ArhvkNWa95S9gk9ZHZLUcjqanf0F8taJCYgzcbUSp+VBe9DcN89sJpYvfiBiAsMVqGPc/fHJgTScK+8QYrTRMubtFmXHbzBSO/KTAP5rBTxse88EGjK5F8wcedvge2Ksk6XjL3sZ19+Oj8KTQ72wihN900p1WQldHrrnbixSpmHBXbHr9U0NQigrJp5NphfuU5j81C8ixvfUdwyLmTv7rNA7GTAD";
		$rootCert = New-AzVpnClientRootCertificate -Name $clientRootCertName -PublicCertData $samplePublicCertData

		# remove AAD authentication configuration.
		#Set-AzVirtualNetworkGateway -VirtualNetworkGateway $actual -VpnClientRootCertificates $rootCert -RemoveAadAuthentication
		$actual = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname

		Assert-AreEqual "VpnGw1" $actual.Sku.Tier
		$protocols = $actual.VpnClientConfiguration.VpnClientProtocols
		Assert-AreEqual 1 @($protocols).Count
		Assert-AreEqual "OpenVPN" $protocols[0]
		Assert-AreEqual "201.169.0.0/16" $actual.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes
		#Assert-Null $actual.VpnClientConfiguration.AadTenant
		#Assert-Null $actual.VpnClientConfiguration.AadIssuer
		#Assert-Null $actual.VpnClientConfiguration.AadAudience
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
function Test-VirtualNetworkGatewayVpnCustomIpsecPolicySet
{
	param 
    ( 
        $basedir = ".\" 
    )

    # Setup
    $rgname = Get-ResourceName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $vnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworkGateways"
    $location = Get-ProviderLocation $resourceTypeParent
	$vpnclientAuthMethod = "EAPTLS"
    
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
	  # create the client root cert
	  $clientRootCertName = "BrkLiteTestMSFTRootCA.cer"
	  #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
	  $samplePublicCertData = "MIIC5zCCAc+gAwIBAgIQFzWsg2N5PItGfI8al3SfETANBgkqhkiG9w0BAQsFADAW MRQwEgYDVQQDDAtQMlNSb290Q2VydDAeFw0yMDEwMjgxODM1MDRaFw0yMTEwMjgx ODU1MDRaMBYxFDASBgNVBAMMC1AyU1Jvb3RDZXJ0MIIBIjANBgkqhkiG9w0BAQEF AAOCAQ8AMIIBCgKCAQEArZqDDCWiXAsrqgYYKDzDgzMKUjgVXgXpfaWltAFJR5rv KFpMJCJldq4YCdpkKT3n0STUz1PJii3cj/o8J9D2XTwdEY+gACOKNn5tRLE+Qz4N r77nfCzTyBNVcgllxoVZgyDhItVoo2JZ2G6+3ywDignfve20Wpj0YGGslanqQsmq o/OeSDNUXGmir4KLwlGjR6+os51y1X3nrqkMpE10K/uIPMe4+WFNrx7g4nOEz+cF vNmi0qdWDpwTg3/JxyhnZVL1TPdeM0zyclnveIvhhseSd3oW5L9OC3eSpPbjD70S UD4vDXrQuUV6SfYAX6aqhNeit/fqrI6ToT86mKwDhQIDAQABozEwLzAOBgNVHQ8B Af8EBAMCAgQwHQYDVR0OBBYEFJ7OyTGgBHVeDBZNKDnenAdlNTfwMA0GCSqGSIb3 DQEBCwUAA4IBAQAWopX5Gj2HslQnVAFzrteg9uIT+q503Zi8FTnGA4hN6I1xq9uo ETNAbQCrHf3R18lL37aP8Z//NVLcx5o+ZD0PMWhb5bhh1FeQ4QCVM0/CJKJqHLZU HCgc7FTiSAtpcGCdmSLM3Uq9Xpn3h5INB5Wekyk1SvyJYuoHqDRMZHKoxqnkYf7x QkThECnubbeFgdA+S/FpMa1+zMDPApcIFQ6/5vOcAEk/iRSv4dZZRyphgy+LlSdM rFKPtpeeEK/OeblVW0mBGIcQyz6sndHwk98u0Is46zlnGFeL7BHEvVSw/QBM6Hcq COZV52zKr851DjkNbHFttGXiwGMsSGdMnjzk"
      $rootCert = New-AzVpnClientRootCertificate -Name $clientRootCertName -PublicCertData $samplePublicCertData

      # Create the Virtual Network
	  $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
	  $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
	  $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname      
	  $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

	  # Create the IP config
	  $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel
	  $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet

      # Create IkeV2 virtualnetworkgateway with custom Ipsec policy specified
	  $vpnclientipsecpolicy1 = New-AzVpnClientIpsecPolicy -IpsecEncryption AES256 -IpsecIntegrity SHA256 -SALifeTime 86471 -SADataSize 429496 -IkeEncryption AES256 -IkeIntegrity SHA384 -DhGroup DHGroup2 -PfsGroup PFS2
      $actual = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false -GatewaySku VpnGw1 -VpnClientProtocol IkeV2 -VpnClientAddressPool 201.169.0.0/16 -VpnClientRootCertificates $rootCert -VpnClientIpsecPolicy $vpnclientipsecpolicy1

	  # Get virtualnetworkgateway
      $expected = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
	  $protocols = $expected.VpnClientConfiguration.VpnClientProtocols
	  Assert-AreEqual 1 @($protocols).Count
	  Assert-AreEqual "IkeV2" $protocols[0]
	  Assert-AreEqual 1 @($expected.VpnClientConfiguration.VpnClientIpsecPolicies).Count
      Assert-AreEqual $expected.VpnClientConfiguration.VpnClientIpsecPolicies[0].SALifeTimeSeconds $actual.VpnClientConfiguration.VpnClientIpsecPolicies[0].SALifeTimeSeconds
	  Assert-AreEqual $expected.VpnClientConfiguration.VpnClientIpsecPolicies[0].SADataSizeKilobytes $actual.VpnClientConfiguration.VpnClientIpsecPolicies[0].SADataSizeKilobytes
	  Assert-AreEqual $expected.VpnClientConfiguration.VpnClientIpsecPolicies[0].IpsecEncryption $actual.VpnClientConfiguration.VpnClientIpsecPolicies[0].IpsecEncryption
	  Assert-AreEqual $expected.VpnClientConfiguration.VpnClientIpsecPolicies[0].IpsecIntegrity $actual.VpnClientConfiguration.VpnClientIpsecPolicies[0].IpsecIntegrity
	  Assert-AreEqual $expected.VpnClientConfiguration.VpnClientIpsecPolicies[0].IkeEncryption $actual.VpnClientConfiguration.VpnClientIpsecPolicies[0].IkeEncryption
	  Assert-AreEqual $expected.VpnClientConfiguration.VpnClientIpsecPolicies[0].IkeIntegrity $actual.VpnClientConfiguration.VpnClientIpsecPolicies[0].IkeIntegrity
	  Assert-AreEqual $expected.VpnClientConfiguration.VpnClientIpsecPolicies[0].DhGroup $actual.VpnClientConfiguration.VpnClientIpsecPolicies[0].DhGroup
	  Assert-AreEqual $expected.VpnClientConfiguration.VpnClientIpsecPolicies[0].PfsGroup $actual.VpnClientConfiguration.VpnClientIpsecPolicies[0].PfsGroup
            
      # Update P2S VPNClient Configuration :- custom Ipsec policy
	  $vpnclientipsecpolicy2 = New-AzVpnClientIpsecPolicy -IpsecEncryption AES256 -IpsecIntegrity SHA256 -SALifeTime 86472 -SADataSize 429497 -IkeEncryption AES256 -IkeIntegrity SHA256 -DhGroup DHGroup2 -PfsGroup None
	  $gateway = Set-AzVirtualNetworkGateway -VirtualNetworkGateway $expected -VpnClientIpsecPolicy $vpnclientipsecpolicy2
	  Assert-AreEqual $vpnclientipsecpolicy2.SALifeTimeSeconds $gateway.VpnClientConfiguration.VpnClientIpsecPolicies[0].SALifeTimeSeconds
	  Assert-AreEqual $vpnclientipsecpolicy2.SADataSizeKilobytes $gateway.VpnClientConfiguration.VpnClientIpsecPolicies[0].SADataSizeKilobytes
	  Assert-AreEqual $vpnclientipsecpolicy2.IpsecEncryption $gateway.VpnClientConfiguration.VpnClientIpsecPolicies[0].IpsecEncryption
	  Assert-AreEqual $vpnclientipsecpolicy2.IpsecIntegrity $gateway.VpnClientConfiguration.VpnClientIpsecPolicies[0].IpsecIntegrity
	  Assert-AreEqual $vpnclientipsecpolicy2.IkeEncryption $gateway.VpnClientConfiguration.VpnClientIpsecPolicies[0].IkeEncryption
	  Assert-AreEqual $vpnclientipsecpolicy2.IkeIntegrity $gateway.VpnClientConfiguration.VpnClientIpsecPolicies[0].IkeIntegrity
	  Assert-AreEqual $vpnclientipsecpolicy2.DhGroup $gateway.VpnClientConfiguration.VpnClientIpsecPolicies[0].DhGroup
	  Assert-AreEqual $vpnclientipsecpolicy2.PfsGroup $gateway.VpnClientConfiguration.VpnClientIpsecPolicies[0].PfsGroup
	  
	  # Update P2S VPNClient Configuration :- custom Ipsec policy by using new API:- Set-AzVpnClientIpsecParameter
	  $vpnclientipsecparams1 = New-AzVpnClientIpsecParameter -IpsecEncryption AES256 -IpsecIntegrity SHA256 -SALifeTime 86473 -SADataSize 429498 -IkeEncryption AES256 -IkeIntegrity SHA384 -DhGroup DHGroup2 -PfsGroup PFS2
	  $setvpnIpsecParams = Set-AzVpnClientIpsecParameter -VirtualNetworkGatewayName $rname -ResourceGroupName $rgname -VpnClientIPsecParameter $vpnclientipsecparams1
	  
	  # Get P2S VPNClient Configuration :- set custom Ipsec policy using new API:- Get-AzVpnClientIpsecParameter
	  $vpnIpsecParams = Get-AzVpnClientIpsecParameter -Name $rname -ResourceGroupName $rgname
	  Assert-AreEqual $vpnclientipsecparams1.SALifeTimeSeconds $vpnIpsecParams.SALifeTimeSeconds
	  Assert-AreEqual $vpnclientipsecparams1.SADataSizeKilobytes $vpnIpsecParams.SADataSizeKilobytes
	  Assert-AreEqual $vpnclientipsecparams1.IpsecEncryption $vpnIpsecParams.IpsecEncryption
	  Assert-AreEqual $vpnclientipsecparams1.IpsecIntegrity $vpnIpsecParams.IpsecIntegrity
	  Assert-AreEqual $vpnclientipsecparams1.IkeEncryption $vpnIpsecParams.IkeEncryption
	  Assert-AreEqual $vpnclientipsecparams1.IkeIntegrity $vpnIpsecParams.IkeIntegrity
	  Assert-AreEqual $vpnclientipsecparams1.DhGroup $vpnIpsecParams.DhGroup
	  Assert-AreEqual $vpnclientipsecparams1.PfsGroup $vpnIpsecParams.PfsGroup

	  $expected = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
	  Assert-AreEqual 1 @($expected.VpnClientConfiguration.VpnClientIpsecPolicies).Count
	  Assert-AreEqual $expected.VpnClientConfiguration.VpnClientIpsecPolicies[0].SALifeTimeSeconds $vpnIpsecParams.SALifeTimeSeconds
	  Assert-AreEqual $expected.VpnClientConfiguration.VpnClientIpsecPolicies[0].SADataSizeKilobytes $vpnIpsecParams.SADataSizeKilobytes
	  Assert-AreEqual $expected.VpnClientConfiguration.VpnClientIpsecPolicies[0].IpsecEncryption $vpnIpsecParams.IpsecEncryption
	  Assert-AreEqual $expected.VpnClientConfiguration.VpnClientIpsecPolicies[0].IpsecIntegrity $vpnIpsecParams.IpsecIntegrity
	  Assert-AreEqual $expected.VpnClientConfiguration.VpnClientIpsecPolicies[0].IkeEncryption $vpnIpsecParams.IkeEncryption
	  Assert-AreEqual $expected.VpnClientConfiguration.VpnClientIpsecPolicies[0].IkeIntegrity $vpnIpsecParams.IkeIntegrity
	  Assert-AreEqual $expected.VpnClientConfiguration.VpnClientIpsecPolicies[0].DhGroup $vpnIpsecParams.DhGroup
	  Assert-AreEqual $expected.VpnClientConfiguration.VpnClientIpsecPolicies[0].PfsGroup $vpnIpsecParams.PfsGroup

	  # Remove custom Ipsec policy set from P2S VPNClient Configuration using new API:- Remove-AzVpnClientIpsecParameter
	  $delete = Remove-AzVpnClientIpsecParameter -ResourceGroupName $rgname -VirtualNetworkGatewayName $rname
	  Assert-AreEqual $True $delete
	  $expected = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
	  Assert-AreEqual 0 @($expected.VpnClientConfiguration.VpnClientIpsecPolicies).Count
	  
     }
     finally
     {
        # Cleanup
        Clean-ResourceGroup $rgname
     }
}

<#
.SYNOPSIS
Virtual network gateway Vpn Client Connection Health
#>
function Test-VirtualNetworkGatewayVpnClientConnectionHealth
{
	param 
    ( 
        $basedir = ".\" 
    )

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
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }
	
		# create the client root cert
		$clientRootCertName = "BrkLiteTestMSFTRootCA.cer"
		#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
		$samplePublicCertData = "MIIC5zCCAc+gAwIBAgIQFzWsg2N5PItGfI8al3SfETANBgkqhkiG9w0BAQsFADAW MRQwEgYDVQQDDAtQMlNSb290Q2VydDAeFw0yMDEwMjgxODM1MDRaFw0yMTEwMjgx ODU1MDRaMBYxFDASBgNVBAMMC1AyU1Jvb3RDZXJ0MIIBIjANBgkqhkiG9w0BAQEF AAOCAQ8AMIIBCgKCAQEArZqDDCWiXAsrqgYYKDzDgzMKUjgVXgXpfaWltAFJR5rv KFpMJCJldq4YCdpkKT3n0STUz1PJii3cj/o8J9D2XTwdEY+gACOKNn5tRLE+Qz4N r77nfCzTyBNVcgllxoVZgyDhItVoo2JZ2G6+3ywDignfve20Wpj0YGGslanqQsmq o/OeSDNUXGmir4KLwlGjR6+os51y1X3nrqkMpE10K/uIPMe4+WFNrx7g4nOEz+cF vNmi0qdWDpwTg3/JxyhnZVL1TPdeM0zyclnveIvhhseSd3oW5L9OC3eSpPbjD70S UD4vDXrQuUV6SfYAX6aqhNeit/fqrI6ToT86mKwDhQIDAQABozEwLzAOBgNVHQ8B Af8EBAMCAgQwHQYDVR0OBBYEFJ7OyTGgBHVeDBZNKDnenAdlNTfwMA0GCSqGSIb3 DQEBCwUAA4IBAQAWopX5Gj2HslQnVAFzrteg9uIT+q503Zi8FTnGA4hN6I1xq9uo ETNAbQCrHf3R18lL37aP8Z//NVLcx5o+ZD0PMWhb5bhh1FeQ4QCVM0/CJKJqHLZU HCgc7FTiSAtpcGCdmSLM3Uq9Xpn3h5INB5Wekyk1SvyJYuoHqDRMZHKoxqnkYf7x QkThECnubbeFgdA+S/FpMa1+zMDPApcIFQ6/5vOcAEk/iRSv4dZZRyphgy+LlSdM rFKPtpeeEK/OeblVW0mBGIcQyz6sndHwk98u0Is46zlnGFeL7BHEvVSw/QBM6Hcq COZV52zKr851DjkNbHFttGXiwGMsSGdMnjzk"
        $rootCert = New-AzVpnClientRootCertificate -Name $clientRootCertName -PublicCertData $samplePublicCertData

		# Create the Virtual Network
		$subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname      
		$subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

		# Create the IP config
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel
		$vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
      
		# Create & Get P2S virtualnetworkgateway
		New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false -GatewaySku VpnGw1 -VpnClientAddressPool 201.169.0.0/16 -VpnClientRootCertificates $rootCert
		$actual = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
		Assert-AreEqual "VpnGw1" $actual.Sku.Tier
		$protocols = $actual.VpnClientConfiguration.VpnClientProtocols
		Assert-AreEqual 2 @($protocols).Count
		Assert-AreEqual "201.169.0.0/16" $actual.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes 
		
		$vpnclientHealthDetails = Get-AzVirtualNetworkGatewayVpnClientConnectionHealth -ResourceGroupName $rgname -ResourceName $rname
		Assert-AreEqual 0 @($vpnclientHealthDetails).Count
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
function Test-VirtualNetworKGatewayPacketCapture
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $vnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "WestCentralUS"
    $resourceTypeParent = "Microsoft.Network/virtualNetworkGateways"
    $location = Get-ProviderLocation $resourceTypeParent "WestCentralUS"
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      #create SAS URL
	  if ((Get-NetworkTestMode) -ne 'Playback')
	  {
	       $storetype = 'Standard_GRS'
           $containerName = "testcontainer"
           $storeName = 'sto' + $rgname;
           New-AzStorageAccount -ResourceGroupName $rgname -Name $storeName -Location $location -Type $storetype
           $key = Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $storeName
           $context = New-AzStorageContext -StorageAccountName $storeName -StorageAccountKey $key[0].Value
           New-AzStorageContainer -Name $containerName -Context $context
           $container = Get-AzStorageContainer -Name $containerName -Context $context
           $now=get-date
           $sasurl = New-AzureStorageContainerSASToken -Name $containerName -Context $context -Permission "rwd" -StartTime $now.AddHours(-1) -ExpiryTime $now.AddDays(1) -FullUri
	  }
	  else
	  {
	       $sasurl = "https://storage/test123?sp=racwdl&stvigopKcy"
	  }

      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create & Get virtualnetworkgateway
      $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
      $job = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false -AsJob
      $job | Wait-Job
      $actual = $job | Receive-Job
      $gateway = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $gateway.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $gateway.Name $actual.Name	
      Assert-AreEqual "Vpn" $gateway.GatewayType
      Assert-AreEqual "RouteBased" $gateway.VpnType

      #StartPacketCapture on gateway with Name parameter
      $output = Start-AzVirtualnetworkGatewayPacketCapture -ResourceGroupName  $rgname -Name $rname
      Assert-AreEqual $gateway.ResourceGroupName $output.ResourceGroupName	
      Assert-AreEqual $gateway.Name $output.Name
      Assert-AreEqual $gateway.ResourceGroupName $output.ResourceGroupName	
      Assert-AreEqual $gateway.Location $output.Location
      Assert-AreEqual $output.Code "Succeeded"

      #StopPacketCapture on gateway with Name parameter
      $output = Stop-AzVirtualnetworkGatewayPacketCapture -ResourceGroupName  $rgname -Name $rname -SasUrl $sasurl
      Assert-AreEqual $gateway.ResourceGroupName $output.ResourceGroupName	
      Assert-AreEqual $gateway.Name $output.Name
      Assert-AreEqual $gateway.ResourceGroupName $output.ResourceGroupName	
      Assert-AreEqual $gateway.Location $output.Location
      Assert-AreEqual $output.Code "Succeeded"

      #StartPacketCapture on gateway object
	  $a="{`"TracingFlags`":11,`"MaxPacketBufferSize`":120,`"MaxFileSize`":500,`"Filters`":[{`"SourceSubnets`":[`"10.19.0.4/32`",`"10.20.0.4/32`"],`"DestinationSubnets`":[`"10.20.0.4/32`",`"10.19.0.4/32`"],`"IpSubnetValueAsAny`":true,`"TcpFlags`":-1,`"PortValueAsAny`":true,`"CaptureSingleDirectionTrafficOnly`":true}]}"
      $output = Start-AzVirtualnetworkGatewayPacketCapture -InputObject $gateway -FilterData $a
      Assert-AreEqual $gateway.ResourceGroupName $output.ResourceGroupName	
      Assert-AreEqual $gateway.Name $output.Name
      Assert-AreEqual $gateway.ResourceGroupName $output.ResourceGroupName	
      Assert-AreEqual $gateway.Location $output.Location
      Assert-AreEqual $output.Code "Succeeded"

      #StopPacketCapture on gateway object
      $output = Stop-AzVirtualnetworkGatewayPacketCapture -InputObject $gateway -SasUrl $sasurl
      Assert-AreEqual $gateway.ResourceGroupName $output.ResourceGroupName	
      Assert-AreEqual $gateway.Name $output.Name
      Assert-AreEqual $gateway.ResourceGroupName $output.ResourceGroupName	
      Assert-AreEqual $gateway.Location $output.Location
      Assert-AreEqual $output.Code "Succeeded"

      # Delete virtualNetworkGateway
      $job = Remove-AzVirtualNetworkGateway -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force -AsJob
      $job | Wait-Job
      $delete = $job | Receive-Job
      Assert-AreEqual true $delete
      
      $list = Get-AzVirtualNetworkGateway -ResourceGroupName $actual.ResourceGroupName
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
Disconnect Virtual network gateway Vpn Client Connection
#>
function Test-DisconnectVNGVpnConnection
{
	param 
    ( 
        $basedir = ".\" 
    )

	# Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $vnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $rglocation = "East US"
    $location = $rglocation

	try 
	{
		# Create the resource group
		New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }
	
		# create the client root cert
		$clientRootCertName = "BrkLiteTestMSFTRootCA.cer"
		#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
		$samplePublicCertData = "MIIDUzCCAj+gAwIBAgIQRggGmrpGj4pCblTanQRNUjAJBgUrDgMCHQUAMDQxEjAQBgNVBAoTCU1pY3Jvc29mdDEeMBwGA1UEAxMVQnJrIExpdGUgVGVzdCBSb290IENBMB4XDTEzMDExOTAwMjQxOFoXDTIxMDExOTAwMjQxN1owNDESMBAGA1UEChMJTWljcm9zb2Z0MR4wHAYDVQQDExVCcmsgTGl0ZSBUZXN0IFJvb3QgQ0EwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQC7SmE+iPULK0Rs7mQBO/6a6B6/G9BaMxHgDGzAmSG0Qsyt5e08aqgFnPdkMl3zRJw3lPKGha/JCvHRNrO8UpeAfc4IXWaqxx2iBipHjwmHPHh7+VB8lU0EJcUe7WBAI2n/sgfCwc+xKtuyRVlOhT6qw/nAi8e5don/iHPU6q7GCcnqoqtceQ/pJ8m66cvAnxwJlBFOTninhb2VjtvOfMQ07zPP+ZuYDPxvX5v3nd6yDa98yW4dZPuiGO2s6zJAfOPT2BrtyvLekItnSgAw3U5C0bOb+8XVKaDZQXbGEtOw6NZvD4L2yLd47nGkN2QXloiPLGyetrj3Z2pZYcrZBo8hAgMBAAGjaTBnMGUGA1UdAQReMFyAEOncRAPNcvJDoe4WP/gH2U+hNjA0MRIwEAYDVQQKEwlNaWNyb3NvZnQxHjAcBgNVBAMTFUJyayBMaXRlIFRlc3QgUm9vdCBDQYIQRggGmrpGj4pCblTanQRNUjAJBgUrDgMCHQUAA4IBAQCGyHhMdygS0g2tEUtRT4KFM+qqUY5HBpbIXNAav1a1dmXpHQCziuuxxzu3iq4XwnWUF1OabdDE2cpxNDOWxSsIxfEBf9ifaoz/O1ToJ0K757q2Rm2NWqQ7bNN8ArhvkNWa95S9gk9ZHZLUcjqanf0F8taJCYgzcbUSp+VBe9DcN89sJpYvfiBiAsMVqGPc/fHJgTScK+8QYrTRMubtFmXHbzBSO/KTAP5rBTxse88EGjK5F8wcedvge2Ksk6XjL3sZ19+Oj8KTQ72wihN900p1WQldHrrnbixSpmHBXbHr9U0NQigrJp5NphfuU5j81C8ixvfUdwyLmTv7rNA7GTAD";
		$rootCert = New-AzVpnClientRootCertificate -Name $clientRootCertName -PublicCertData $samplePublicCertData

		# Create the Virtual Network
		$subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

		# Create the IP config
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel
		$vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
      
		# Create & Get P2S virtualnetworkgateway
		New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false -GatewaySku VpnGw1 -VpnClientAddressPool 201.169.0.0/16 -VpnClientRootCertificates $rootCert
		$actual = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
		Assert-AreEqual "Succeeded" $actual.ProvisioningState
		
        $expected = Disconnect-AzVirtualNetworkGatewayVpnConnection -ResourceGroupName $rgname -ResourceName $rname -VpnConnectionId @("IKEv2_1e1cfe59-5c7c-4315-a876-b11fbfdfeed4")
        Assert-AreEqual $expected.Name $actual.Name
	}
	finally
    {
		# Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Virtual network gateway NatRule tests
#>
function Test-VirtualNetworkGatewayNatRuleCRUD
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
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create & Get virtualnetworkgateway with NatRules
      $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
      $ipconfigurationId = $vnetIpConfig.id
      $natRule = New-AzVirtualNetworkGatewayNatRule -Name "natRule1" -Type "Static" -Mode "IngressSnat" -InternalMapping @("25.0.0.0/16") -ExternalMapping @("30.0.0.0/16") -InternalPortRange @("100-100") -ExternalPortRange @("200-200")
      $job = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -GatewaySku VpnGw2 -NatRule $natRule -EnableBgpRouteTranslationForNat -AsJob
	  $job | Wait-Job
	  $actual = $job | Receive-Job
      $expected = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $expected.Name $actual.Name	
      Assert-AreEqual "Vpn" $expected.GatewayType
      Assert-AreEqual "RouteBased" $expected.VpnType
      Assert-AreEqual 1 @($expected.NatRules).Count

      # Updates & Get virtualnetworkgateway with NatRules
      $gateway = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      $vngNatRules = $gateway.NatRules
      $natRule = New-AzVirtualNetworkGatewayNatRule -Name "natRule2" -Type "Static" -Mode "EgressSnat" -InternalMapping @("20.0.0.0/16") -ExternalMapping @("50.0.0.0/16") -InternalPortRange @("300-300") -ExternalPortRange @("400-400")
      $vngNatRules.Add($natrule)
      $updatedGateway = Set-AzVirtualNetworkGateway -VirtualNetworkGateway $gateway -NatRule $vngNatRules
      Assert-AreEqual 2 @($updatedGateway.NatRules).Count
      Assert-AreEqual "20.0.0.0/16" $updatedGateway.NatRules[1].InternalMappings[0].AddressSpace 
      Assert-AreEqual "50.0.0.0/16" $updatedGateway.NatRules[1].ExternalMappings[0].AddressSpace
      Assert-AreEqual "300-300" $updatedGateway.NatRules[1].InternalMappings[0].PortRange 
      Assert-AreEqual "400-400" $updatedGateway.NatRules[1].ExternalMappings[0].PortRange

	  # List virtualNetworkGateways NatRules
      $list = Get-AzVirtualNetworkGatewayNatRule -ResourceGroupName $rgname -ParentResourceName $rname
      Assert-AreEqual 2 @($list).Count

      # update virtualNetworkGateways NatRule
      $natrule = Get-AzVirtualNetworkGatewayNatRule -ResourceGroupName $rgname -ParentResourceName $rname -Name "natRule2"
      Assert-AreEqual "20.0.0.0/16" $natrule.InternalMappings[0].AddressSpace 
      Assert-AreEqual "50.0.0.0/16" $natrule.ExternalMappings[0].AddressSpace
      Assert-AreEqual "300-300" $natrule.InternalMappings[0].PortRange 
      Assert-AreEqual "400-400" $natrule.ExternalMappings[0].PortRange

      $updatedNatRule = Update-AzVirtualNetworkGatewayNatRule -InputObject $natrule -ExternalMapping @("40.0.0.0/16") -ExternalPortRange @("500-500")
      Assert-AreEqual "Succeeded" $updatedNatRule.ProvisioningState
      Assert-AreEqual "20.0.0.0/16" $updatedNatRule.InternalMappings[0].AddressSpace 
      Assert-AreEqual "40.0.0.0/16" $updatedNatRule.ExternalMappings[0].AddressSpace 
      Assert-AreEqual "300-300" $updatedNatRule.InternalMappings[0].PortRange 
      Assert-AreEqual "500-500" $updatedNatRule.ExternalMappings[0].PortRange

      # Delete virtualNetworkGatewayNatRules
      $delete = Remove-AzVirtualNetworkGatewayNatRule -ResourceGroupName $rgname -ParentResourceName $rname -Name natRule1 -PassThru -Force
      Assert-AreEqual $True $delete

      # Delete virtualNetworkGateway
      $job = Remove-AzVirtualNetworkGateway -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force -AsJob
	  $job | Wait-Job
	  $delete = $job | Receive-Job
      Assert-AreEqual true $delete
      
      $list = Get-AzVirtualNetworkGateway -ResourceGroupName $actual.ResourceGroupName
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
function Test-VirtualNetworkGatewayPolicyGroupCRUD
{
param 
    ( 
        $basedir = ".\" 
    )

    # Setup
    $rgname = Get-ResourceName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $vnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworkGateways"
    $location = Get-ProviderLocation $resourceTypeParent
	$vpnclientAuthMethod = "EAPTLS"
    
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

      #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
      $samplePublicCertData = "MIIC8TCCAdmgAwIBAgIQEqoni9yN+Y5Jdmfm9iieSzANBgkqhkiG9w0BAQsFADAbMRkwFwYDVQQDDBBCVlRNdWx0aXBvb2xSb290MB4XDTIyMDMwODIxMjM0M1oXDTIzMDMwODIxNDM0M1owGzEZMBcGA1UEAwwQQlZUTXVsdGlwb29sUm9vdDCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAMNgZH9pjOkayYfPbd1HnFosUtpRluaP0tFsb8MKOSlah5LNIjxT0SEY1r3RpdV9JSlyEe75leWRXrUqiSEUATza8tLW3kyBY8C7fO2ppBFbpALYdnTSnO2MzA5R6oqDKENCinfvL+nExSP48CRDYTtqPajFsBtCA0g55dKiEll9Ov/QRhWbWhehDbDULKd0JMuycbS6P8UFYii7HPKDTbWj8wBETvkc2HO8FOQCMQ14PNAhXuBXVZkuPrlyNpaEqWwGXNNm4SLKiWt9Yat2LYnUvdx/8J1N3Qt7K7S///fHmYMfNH+A+xOeAKhS+IwFRlVbycZ001f0252yvfBmhPUCAwEAAaMxMC8wDgYDVR0PAQH/BAQDAgIEMB0GA1UdDgQWBBRGU/KC4/phW9thGt5yAli1sWxNwTANBgkqhkiG9w0BAQsFAAOCAQEAlO1P/4FKu0n+BRRT9dKx+nTZtIDhFg1GauI9bYvBsc7Wm1opA/+CCXNo5ChNWvrSmDxGInVrGmHwlaB0PEL5W0u5W65UIZlb8ew0vzPmm+Dn/D/9DiqbSt+6yP6RBd6w26og2eh/daMIR90T2ehMsShzlgjmiTeola6EXA15lokfEOaNroj/wFWs26Yz9pvlL+R/nu+QPrnvQQWz/sSYuabmlOzF6rwS2vTae0Q8Y3JvWpEmGeCUMvFYDaK+Wqy1SmMyFLK1QOFz2e/D0PIk1eljoq16p2gd0h6iwsqKstEBXULi0BF9ZhFLBZ1d0ispMdp00huccSektXZiVBpBdQ=="
      $clientRootCertName = "BrkLiteTestMSFTRootCA.cer"
      $rootCert = New-AzVpnClientRootCertificate -Name $clientRootCertName -PublicCertData $samplePublicCertData

      $aadTenant = "https://login.microsoftonline.com/0ab2c4f4-81e6-44cc-a0b2-b3a47a1443f4"
      $aadIssuer = "https://sts.windows.net/0ab2c4f4-81e6-44cc-a0b2-b3a47a1443f4/"
      $aadAudience = "a21fce82-76af-45e6-8583-a08cb3b956f9"
      
      #create the policy group and connection client configuration
      $member1=New-AzVirtualNetworkGatewayPolicyGroupMember -Name "member1" -AttributeType "CertificateGroupId" -AttributeValue "ab"
      $member2=New-AzVirtualNetworkGatewayPolicyGroupMember -Name "member2" -AttributeType "CertificateGroupId" -AttributeValue "cd"
      $policyGroup1=New-AzVirtualNetworkGatewayPolicyGroup -Name "policyGroup1" -Priority 0 -DefaultPolicyGroup  -PolicyMember $member1
      $policyGroup2=New-AzVirtualNetworkGatewayPolicyGroup -Name "policyGroup2" -Priority 10 -PolicyMember $member2
      $vngconnectionConfig=New-AzVpnClientConnectionConfiguration -Name "coonfig1" -VirtualNetworkGatewayPolicyGroup $policyGroup1 -VpnClientAddressPool "192.168.10.0/24" 
      $vngconnectionConfig2=New-AzVpnClientConnectionConfiguration -Name "coonfig2" -VirtualNetworkGatewayPolicyGroup $policyGroup2 -VpnClientAddressPool "192.168.20.0/24" 

      #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
      $Secure_String_Pwd = ConvertTo-SecureString "radiuspd" -AsPlainText -Force
      $RadiusIP = "1.2.3.4"
      # Create & Get virtualnetworkgateway
      $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
      $actual = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false -GatewaySku VpnGw2 -VpnClientAddressPool 201.169.0.0/16 -VpnAuthenticationType Certificate,Radius,AAD -RadiusServerAddress "1.2.3.4" -RadiusServerSecret $Secure_String_Pwd -VpnClientRootCertificates $rootCert -AadTenantUri $aadTenant -AadAudienceId $aadAudience -AadIssuerUri $aadIssuer -VpnClientProtocol OpenVPN -VirtualNetworkGatewayPolicyGroup $policyGroup1,$policyGroup2 -ClientConnectionConfiguration $vngconnectionConfig,$vngconnectionConfig2
      $expected = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $expected.Name $actual.Name	
      Assert-NotNull  $actual.VpnClientConfiguration.ClientConnectionConfigurations
      Assert-NotNull  $actual.VirtualNetworkGatewayPolicyGroups
      Assert-AreEqual "Vpn" $expected.GatewayType
      Assert-AreEqual "RouteBased" $expected.VpnType
      Assert-NotNull $expected.VpnClientConfiguration
      $authTypes = $expected.VpnClientConfiguration.VpnAuthenticationTypes
      Assert-NotNull $authTypes
      Assert-AreEqual 3 @($authTypes).Count

      $member1=New-AzVirtualNetworkGatewayPolicyGroupMember -Name "member1" -AttributeType "CertificateGroupId" -AttributeValue "bj"
      $member2=New-AzVirtualNetworkGatewayPolicyGroupMember -Name "member2" -AttributeType "CertificateGroupId" -AttributeValue "cd"
      $policyGroup1=New-AzVirtualNetworkGatewayPolicyGroup -Name "policyGroup1" -Priority 0 -DefaultPolicyGroup  -PolicyMember $member1
      $policyGroup2=New-AzVirtualNetworkGatewayPolicyGroup -Name "policyGroup2" -Priority 10 -PolicyMember $member2
      $vngconnectionConfig=New-AzVpnClientConnectionConfiguration -Name "coonfig1" -VirtualNetworkGatewayPolicyGroup $policyGroup1 -VpnClientAddressPool "192.168.10.0/24" 
      $vngconnectionConfig2=New-AzVpnClientConnectionConfiguration -Name "coonfig2" -VirtualNetworkGatewayPolicyGroup $policyGroup2 -VpnClientAddressPool "192.168.20.0/24" 

      $actual = Set-AzVirtualNetworkGateway -VirtualNetworkGateway $expected -VirtualNetworkGatewayPolicyGroup $policyGroup1,$policyGroup2 -ClientConnectionConfiguration $vngconnectionConfig,$vngconnectionConfig2
      $expected = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual "bj" $expected.VirtualNetworkGatewayPolicyGroups[0].PolicyMembers[0].AttributeValue
    }
     finally
     {
        # Cleanup
        Clean-ResourceGroup $rgname
     }
}

<#
.SYNOPSIS
Virtual network gateway P2S multiauth test
#>
function Test-VirtualNetworkGatewayMultiAuth
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
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }
	
		# AAD authentication configurations
		$aadTenant = "https://login.microsoftonline.com/0ab2c4f4-81e6-44cc-a0b2-b3a47a1443f4"
		$aadIssuer = "https://sts.windows.net/0ab2c4f4-81e6-44cc-a0b2-b3a47a1443f4/"
		$aadAudience = "a21fce82-76af-45e6-8583-a08cb3b956f9"

		# Create the Virtual Network
		$subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
		$vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname      
		$subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

		# Create the IP config
		$publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel
		$vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
        
        	# Creating a P2S VPN gateway with AAD without OpenVPN protocol should throw error
        	Assert-ThrowsContains { New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -VpnClientProtocol IkeV2 -EnableBgp $false -GatewaySku VpnGw1 -VpnClientAddressPool 201.169.0.0/16 -AadTenantUri $aadTenant -AadIssuerUri $aadIssuer -AadAudienceId $aadAudience } "Virtual Network Gateway VpnClientProtocol should contain";

        	# Creating a P2S VPN gateway with OpenVPN & IkeV2 with AAD auth only should throw error message
        	Assert-ThrowsContains { New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -VpnClientProtocol "OpenVPN", "IkeV2" -EnableBgp $false -GatewaySku VpnGw1 -VpnClientAddressPool 201.169.0.0/16 -AadTenantUri $aadTenant -AadIssuerUri $aadIssuer -AadAudienceId $aadAudience } "Since AAD is only supported for OpenVPN, please choose one additional auth type or choose only OpenVPN protocol";

        	# Create a P2S VPN gateway with OpenVPN & AAD to be used to test Set-AzVirtualNetworkGateway
		New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -VpnClientProtocol OpenVPN -EnableBgp $false -GatewaySku VpnGw1 -VpnClientAddressPool 201.169.0.0/16 -AadTenantUri $aadTenant -AadIssuerUri $aadIssuer -AadAudienceId $aadAudience
		$actual = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
		$protocols = $actual.VpnClientConfiguration.VpnClientProtocols
		Assert-AreEqual 1 @($protocols).Count
		Assert-AreEqual "OpenVPN" $protocols[0]
		Assert-AreEqual "201.169.0.0/16" $actual.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes
		Assert-AreEqual $aadTenant $actual.VpnClientConfiguration.AadTenant
		Assert-AreEqual $aadIssuer $actual.VpnClientConfiguration.AadIssuer
		Assert-AreEqual $aadAudience $actual.VpnClientConfiguration.AadAudience

		# Set an existing P2S VPN gateway to use AAD without OpenVPN should throw error
		Assert-ThrowsContains { Set-AzVirtualNetworkGateway -VirtualNetworkGateway $actual -VpnClientProtocol IkeV2 -AadAudience $aadAudience -AadTenant $aadTenant -AadIssuer $aadIssuer } "Virtual Network Gateway VpnClientProtocol should contain";
        	# Check gateway protocol was not updated
        	$actual = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
		$protocols = $actual.VpnClientConfiguration.VpnClientProtocols
		Assert-AreEqual 1 @($protocols).Count
		Assert-AreEqual "OpenVPN" $protocols[0]
		Assert-AreEqual "201.169.0.0/16" $actual.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes
		Assert-AreEqual $aadTenant $actual.VpnClientConfiguration.AadTenant
		Assert-AreEqual $aadIssuer $actual.VpnClientConfiguration.AadIssuer
		Assert-AreEqual $aadAudience $actual.VpnClientConfiguration.AadAudience

		# Set an existing P2S VPN gateway to use OpenVPN & IkeV2 with AAD auth only should throw error message
		Assert-ThrowsContains { Set-AzVirtualNetworkGateway -VirtualNetworkGateway $actual -VpnClientProtocol "OpenVPN", "IkeV2" } "Since AAD is only supported for OpenVPN, please choose one additional auth type or choose only OpenVPN protocol";
        	# Check gateway protocol was not updated
        	$actual = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
		$protocols = $actual.VpnClientConfiguration.VpnClientProtocols
		Assert-AreEqual 1 @($protocols).Count
		Assert-AreEqual "OpenVPN" $protocols[0]
		Assert-AreEqual "201.169.0.0/16" $actual.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes
		Assert-AreEqual $aadTenant $actual.VpnClientConfiguration.AadTenant
		Assert-AreEqual $aadIssuer $actual.VpnClientConfiguration.AadIssuer
		Assert-AreEqual $aadAudience $actual.VpnClientConfiguration.AadAudience
	}
	finally
    {
		# Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Virtual network gateway AdminState test
#>
function Test-VirtualNetworkExpressRouteGatewayCRUDwithAdminState
{
 # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rname2 = Get-ResourceName
    $vnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $publicIpName2 = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $vnetGatewayConfigName2 = Get-ResourceName
    $rglocation = "centraluseuap"
    $resourceTypeParent = "Microsoft.Network/virtualNetworkGateways"
    $location = "centraluseuap"
    
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static 

      # Create & Get virtualnetworkgateway
      $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet

      $actual = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType ExpressRoute -GatewaySku UltraPerformance -AdminState "Enabled" 
      $expected = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $expected.Name $actual.Name	
      Assert-AreEqual "ExpressRoute" $expected.GatewayType
	  Assert-AreEqual "Enabled" $expected.AdminState

      # Create a second gateway
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet
      $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName2 -location $location -AllocationMethod Static 
      $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName2 -PublicIpAddress $publicip -Subnet $subnet

      $actual = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname2 -location $location -IpConfigurations $vnetIpConfig -GatewayType ExpressRoute -GatewaySku UltraPerformance -AdminState "Enabled" 
      $expected = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname2
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $expected.Name $actual.Name	
      Assert-AreEqual "ExpressRoute" $expected.GatewayType
	  Assert-AreEqual "Enabled" $expected.AdminState

      # Update second gw to disabled Adminstate
      $vng2 = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname2
      $vng2.Adminstate = "Disabled";
      Set-AzVirtualNetworkGateway -VirtualNetworkGateway $vng2

      $vng2 = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname2	
	  Assert-AreEqual "Disabled" $vng2.AdminState
      
      # Delete both virtualNetworkGateways
      $delete = Remove-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -PassThru -Force
      Assert-AreEqual true $delete

      $delete = Remove-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname2 -PassThru -Force
      Assert-AreEqual true $delete
      
      $list = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname
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
Virtual network gateway traffic block preferences that may be configured by customers
#>
function Test-VirtualNetworkExpressRouteGatewayForDifferentCustomerBlockTrafficPreferences
{
    # Setup
    $rgname = Get-ResourceGroupName
    # return

    $rname = Get-ResourceName
    $vnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $rglocation = "centraluseuap"
    $resourceTypeParent = "Microsoft.Network/virtualNetworkGateways"
    $location = "centraluseuap"

    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create the virtual network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

        # Create the public IP
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static 

        # Create & Get virtual network gateway
        $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet

        $createdGateway = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType ExpressRoute -GatewaySku UltraPerformance
        
        # Brand-new gateway validations
        $retrievedGateway = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
        Assert-AreEqual $retrievedGateway.ResourceGroupName $createdGateway.ResourceGroupName	
        Assert-AreEqual $retrievedGateway.Name $createdGateway.Name	
        Assert-AreEqual "ExpressRoute" $retrievedGateway.GatewayType
        Assert-AreEqual $false $retrievedGateway.AllowRemoteVnetTraffic
        Assert-AreEqual $false $retrievedGateway.AllowVirtualWanTraffic

        # Update vnet-to-vWAN via property
        $retrievedGateway.AllowVirtualWanTraffic = $true
        Set-AzVirtualNetworkGateway -VirtualNetworkGateway $retrievedGateway
        $retrievedGateway = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
        Assert-AreEqual $false $retrievedGateway.AllowRemoteVnetTraffic
        Assert-AreEqual $true $retrievedGateway.AllowVirtualWanTraffic
        $retrievedGateway.AllowVirtualWanTraffic = $false
        Set-AzVirtualNetworkGateway -VirtualNetworkGateway $retrievedGateway
        Assert-AreEqual $false $retrievedGateway.AllowRemoteVnetTraffic
        Assert-AreEqual $false $retrievedGateway.AllowVirtualWanTraffic

        # Update vnet-to-vWAN via switch
        $retrievedGateway = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
        Set-AzVirtualNetworkGateway -VirtualNetworkGateway $retrievedGateway -AllowVirtualWanTraffic $true
        $retrievedGateway = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
        Assert-AreEqual $false $retrievedGateway.AllowRemoteVnetTraffic
        Assert-AreEqual $true $retrievedGateway.AllowVirtualWanTraffic
        Set-AzVirtualNetworkGateway -VirtualNetworkGateway $retrievedGateway -AllowVirtualWanTraffic $false
        $retrievedGateway = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
        Assert-AreEqual $false $retrievedGateway.AllowRemoteVnetTraffic
        Assert-AreEqual $false $retrievedGateway.AllowVirtualWanTraffic

        # Update vnet-to-vnet via property
        $retrievedGateway.AllowRemoteVnetTraffic = $true
        Set-AzVirtualNetworkGateway -VirtualNetworkGateway $retrievedGateway
        $retrievedGateway = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
        Assert-AreEqual $true $retrievedGateway.AllowRemoteVnetTraffic
        Assert-AreEqual $false $retrievedGateway.AllowVirtualWanTraffic
        $retrievedGateway.AllowRemoteVnetTraffic = $false
        Set-AzVirtualNetworkGateway -VirtualNetworkGateway $retrievedGateway
        $retrievedGateway = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
        Assert-AreEqual $false $retrievedGateway.AllowRemoteVnetTraffic
        Assert-AreEqual $false $retrievedGateway.AllowVirtualWanTraffic

        # Update vnet-to-vnet via switch
        $retrievedGateway = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
        Set-AzVirtualNetworkGateway -VirtualNetworkGateway $retrievedGateway -AllowRemoteVnetTraffic $true
        $retrievedGateway = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
        Assert-AreEqual $true $retrievedGateway.AllowRemoteVnetTraffic
        Assert-AreEqual $false $retrievedGateway.AllowVirtualWanTraffic
        Set-AzVirtualNetworkGateway -VirtualNetworkGateway $retrievedGateway -AllowRemoteVnetTraffic $false
        $retrievedGateway = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
        Assert-AreEqual $false $retrievedGateway.AllowRemoteVnetTraffic
        Assert-AreEqual $false $retrievedGateway.AllowVirtualWanTraffic
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Virtual network gateway Resiliency Model test
#>
function Test-VirtualNetworkExpressRouteGatewayCRUDwithResiliencyModel
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rname2 = Get-ResourceName
    $vnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $publicIpName2 = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $rglocation = "centraluseuap"
    $resourceTypeParent = "Microsoft.Network/virtualNetworkGateways"
    $location = "centraluseuap"
    
    try 
    {
      # Create the resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static 

      # Create & Get virtualnetworkgateway
      $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet

      $actual = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType ExpressRoute -GatewaySku UltraPerformance -ResiliencyModel MultiHomed
      $expected = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $expected.Name $actual.Name	
      Assert-AreEqual "ExpressRoute" $expected.GatewayType
	  Assert-AreEqual "Disabled" $expected.AdminState
      Assert-AreEqual "MultiHomed" $expected.ResiliencyModel

     }
     finally
     {
        # Cleanup
        Clean-ResourceGroup $rgname
     }
}