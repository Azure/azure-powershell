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

########################################################################### Gateway tests ###################################################################

<#
.SYNOPSIS
    Tests for local network gateway right now
#>

function Test-LocalNetworkGateway
{
    # Setup
	$lngname = getAssetName
    $location="West US"

    $subscription = Get-AzureSubscription -Current
    Set-AzureSubscription -SubscriptionId $subscription.SubscriptionId
        
	# Create a local network gateway
	$ipAddr = "1.2.3.4"
	$addrSpace = "10.0.0.0/8"
    New-AzureLocalNetworkGateway -GatewayName $lngname -IpAddress $ipAddr -AddressSpace $addrSpace

	# Retrieve a list of local network gateways, and get the one created above by name
	$lnglist = Get-AzureLocalNetworkGateway
	$lng = $lnglist | Where-Object { $_.GatewayName -eq $lngname }
	Assert-AreEqual $lng.IpAddress $ipAddr
	Assert-AreEqual $lng.AddressSpace $addrSpace

	# Retrieve the local network gateway by ID
	$lng = Get-AzureLocalNetworkGateway -GatewayId $lng.GatewayId
	Assert-AreEqual $lng.IpAddress $ipAddr
	Assert-AreEqual $lng.AddressSpace $addrSpace
	
	# Delete the local network gateway
    Remove-AzureLocalNetworkGateway -GatewayId $lng.GatewayId
}

function Test-LocalNetworkGatewayBgp
{
# Setup
	$lngname = getAssetName
    $location="West US"

    $subscription = Get-AzureSubscription -Current
    Set-AzureSubscription -SubscriptionId $subscription.SubscriptionId
        
	# Create a local network gateway
	$ipAddr = "1.2.3.4"
	$addrSpace = "10.0.0.0/8"
	$asn = "1234"
	$bgpaddr = "10.0.0.1"
    New-AzureLocalNetworkGateway -GatewayName $lngname -IpAddress $ipAddr -AddressSpace $addrSpace -Asn $asn -BgpPeeringAddress $bgpaddr

	# Retrieve a list of local network gateways, and get the one created above by name
	$lnglist = Get-AzureLocalNetworkGateway
	$lng = $lnglist | Where-Object { $_.GatewayName -eq $lngname }
	Assert-AreEqual $lng.IpAddress $ipAddr
	Assert-AreEqual $lng.AddressSpace $addrSpace
	Assert-AreEqual $lng.Asn $asn
	Assert-AreEqual $lng.BgpPeeringAddress $bgpaddr

	# Retrieve the local network gateway by ID
	$lng = Get-AzureLocalNetworkGateway -GatewayId $lng.GatewayId
	Assert-AreEqual $lng.IpAddress $ipAddr
	Assert-AreEqual $lng.AddressSpace $addrSpace
	Assert-AreEqual $lng.Asn $asn
	Assert-AreEqual $lng.BgpPeeringAddress $bgpaddr
	
	# Delete the local network gateway
    Remove-AzureLocalNetworkGateway -GatewayId $lng.GatewayId
}
