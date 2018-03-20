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
Tests ExpressRouteCrossConnection Get and Update.
#>
function Test-ExpressRouteCrossConnectionGetAndUpdate
{
	 # Setup
    $rgname = 'ccTestCircuitRG'
    $circuitName = ccTestCircuit
    $rglocation = "brazilSouth"
    $resourceTypeParent = "Microsoft.Network/expressRouteCircuits"
    $location = "brazilSouth"

	# Circuit specific consts
	$providerName = "equinix"
	$peeringLocation = "Silicon Valley"
	$bandwidth = 500

	# Peering specific consts
	$peeringType = MicrosoftPeering
	$peerAsn = 33
	$primaryPeerAddressPrefix = "192.171.1.0/30"
	$secondaryPeerAddressPrefix "192.171.2.0/30"
	$vlanId 224
	$microsoftConfigAdvertisedPublicPrefixes = @("11.2.3.4/30", "12.2.3.4/30")
	$microsoftConfigCustomerAsn 1000
	$microsoftConfigRoutingRegistryName AFRINIC

    try 
    {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation
      
      # Create the ExpressRouteCircuit
	  $peering = New-AzureRmExpressRouteCircuitPeeringConfig -Name MicrosoftPeering -PeeringType MicrosoftPeering -PeerASN 33 -PrimaryPeerAddressPrefix $primaryPeerAddressPrefix -SecondaryPeerAddressPrefix $secondaryPeerAddressPrefix -VlanId $vlanId -MicrosoftConfigAdvertisedPublicPrefixes $microsoftConfigAdvertisedPublicPrefixes -MicrosoftConfigCustomerAsn $microsoftConfigCustomerAsn -MicrosoftConfigRoutingRegistryName $microsoftConfigRoutingRegistryName -LegacyMode $true 
	  $job = New-AzureRmExpressRouteCircuit -Name $circuitName -Location $location -ResourceGroupName $rgname -SkuTier Premium -SkuFamily MeteredData  -ServiceProviderName $providerName -PeeringLocation $peeringLocation -BandwidthInMbps $bandwidth -AsJob
	  $job | Wait-Job
	  $circuit = $job | Receive-Job

      # Verify that an associated cross connection is created
	  $crossConnectionName = $circuit.ServiceKey
	  $crossConnectionResourceGroupName = "CrossConnection-SiliconValley"
      $crossConnection = Get-AzureRMExpressRouteCrossConnection -Name $crossConnectionName -ResourceGroupName $crossConnectionResourceGroupName
	 
	 # Verify Get cmdlet returns the right values for the CrossConnection resource
	 Assert-AreEqual $circuit.PrimaryAzurePort $crossConnection.PrimaryAzurePort
	 Assert-AreEqual $circuit.SecondaryAzurePort $crossConnection.SecondaryAzurePort
	 Assert-AreEqual $circuit.SecondaryAzurePort $crossConnection.STag $circuit.STag
	 Assert-AreEqual $circuit.ServiceProviderProperties.PeeringLocation $crossConnection.PeeringLocation 
	 Assert-AreEqual $circuit.ServiceProviderProperties.BandwidthInMbps$crossConnection.BandwidthInMbps
	 Assert-AreEqual $circuit.ServiceProviderProvisioningState $crossConnection.ServiceProviderProvisioningState
	 Assert-AreEqual $circuit.ServiceProviderNotes $crossConnection.ServiceProviderNotes
	 Assert-AreEqual 1 $crossConnection.Peerings.Count

	 # Verify peering properties returned by the Get cmdlet
	 Assert-AreEqual $circuit.Peerings[0].PeeringType $crossConnection.Peerings[0].PeeringType
	 Assert-AreEqual $circuit.Peerings[0].State $crossConnection.Peerings[0].State
	 Assert-AreEqual $crossConnection.Peerings[0].AzureASN $circuit.Peerings[0].AzureASN
	 Assert-AreEqual $circuit.Peerings[0].PeerASN $crossconnection.Peerings[0].PeerASN
	 Assert-AreEqual $crossConnection.Peerings[0].PrimaryPeerAddressPrefix $primaryPeerAddressPrefix
	 Assert-AreEqual $crossconnection.Peerings[0].SecondaryPeerAddressPrefix $crossConnection.Peerings[0].SecondaryPeerAddressPrefix 
	 Assert-AreEqual $circuit.Peerings[0].PrimaryAzurePort $crossConnection.Peerings[0].PrimaryAzurePort
	 Assert-AreEqual $circuit.Peerings[0].SecondaryAzurePort $crossConnection.Peerings[0].SecondaryAzurePort
	 Assert-AreEqual $circuit.Peerings[0].SharedKey $crossConnection.Peerings[0].SharedKey
	 Assert-AreEqual $circuit.Peerings[0].VlanId $crossConnection.Peerings[0].VlanId
	 Assert-AreEqual $circuit.Peerings[0].GatewayManagerEtag $crossConnection.Peerings[0].GatewayManagerEtag
	 Assert-AreEqual $circuit.Peerings[0].LastModifiedBy $crossConnection.Peerings[0].LastModifiedBy
	 Assert-AreEqual $circuit.Peerings[0].SharedKey $crossConnection.Peerings[0].SharedKey
	 Assert-AreEqual $circuit.Peerings[0].Name $crossConnection.Peerings[0].Name

	Assert-NotNull $crossConnection.Peerings[0].MicrosoftPeeringConfig
	Assert-AreEqual $microsoftConfigCustomerAsn $crossConnection.Peerings[0].MicrosoftPeeringConfig.CustomerASN
	Assert-AreEqual $microsoftConfigRoutingRegistryName $crossConnection.Peerings[0].MicrosoftPeeringConfig.RoutingRegistryName
	Assert-AreEqual 2 @($crossConnection.Peerings[0].MicrosoftPeeringConfig.AdvertisedPublicPrefixes).Count
	Assert-NotNull $crossConnection.Peerings[0].MicrosoftPeeringConfig.AdvertisedPublicPrefixesState
	Assert-Null $crossConnection.Peerings[0].RouteFilter

	# Update the provisioning state
	$updatedState = "Provisioned
	$note = "Test Note"
	$crossConnection.Properties.ServiceProviderProvisioningState = $updatedState
	$crossConnection.Properties.ServiceProviderNotes = $note
	$crossConnectionUpdated = Set-AzureRMExpressRouteCrossConnection -ExpressRouteCrossConnection $crossConnection
	$circuitUpdated = Get-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname

	# Verify the updated fields are reflected on the circuit and cross connection
	Assert-AreEqual $updatedState $crossConnectionUpdated.Properties.ServiceProviderProvisioningState
	Assert-AreEqual $note $crossConnectionUpdated.Properties.ServiceProviderNotes
	Assert-AreEqual $note $circuitUpdated.Properties.ServiceProviderNotes
	}
	finally
	{
	# Cleanup
	# Delete Circuit
	  $job = Remove-AzureRmExpressRouteCircuit -ResourceGroupName $rgname -name $circuitName -PassThru -Force -AsJob
	  $job | Wait-Job
	  $delete = $job | Receive-Job
      Assert-AreEqual true $delete
	}
}

<#
.SYNOPSIS
Tests ExpressRouteCrossConnectionPeering CRUD.
#>
function Test-ExpressRouteRouteFilters
{
	$rgname = "filter"
    $location = "westus"
    $filterName = "filter"
    $ruleName = "rule"

    try
    {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation
      
      # Create the ExpressRouteCircuit
	  $peering = New-AzureRmExpressRouteCircuitPeeringConfig -Name MicrosoftPeering -PeeringType MicrosoftPeering -PeerASN 33 -PrimaryPeerAddressPrefix $primaryPeerAddressPrefix -SecondaryPeerAddressPrefix $secondaryPeerAddressPrefix -VlanId $vlanId -MicrosoftConfigAdvertisedPublicPrefixes $microsoftConfigAdvertisedPublicPrefixes -MicrosoftConfigCustomerAsn $microsoftConfigCustomerAsn -MicrosoftConfigRoutingRegistryName $microsoftConfigRoutingRegistryName -LegacyMode $true 
	  $job = New-AzureRmExpressRouteCircuit -Name $circuitName -Location $location -ResourceGroupName $rgname -SkuTier Premium -SkuFamily MeteredData  -ServiceProviderName $providerName -PeeringLocation $peeringLocation -BandwidthInMbps $bandwidth -AsJob
	  $job | Wait-Job
	  $circuit = $job | Receive-Job

      # Verify that an associated cross connection is created
	  $crossConnectionName = $circuit.ServiceKey
	  $crossConnectionResourceGroupName = "CrossConnection-SiliconValley"
      $crossConnection = Get-AzureRMExpressRouteCrossConnection -Name $crossConnectionName -ResourceGroupName $crossConnectionResourceGroupName

	  Assert-AreEqual 1 $crossConnection.Peerings.Count

	  # Create a cross connection peering
	  $peering = New-AzureRmExpressRouteCircuitPeeringConfig -Name AzurePrivatePeering -PeeringType AzurePrivatePeering -PeerASN 100 -PrimaryPeerAddressPrefix "192.168.1.0/30" -SecondaryPeerAddressPrefix "192.168.2.0/30" -VlanId 22
	  $crossConnection.Peerings.Add($peering)
	  $crossConnectionUpdated = Set-AzureRMExpressRouteCrossConnection -ExpressRouteCrossConnection $crossConnection
	  $circuitUpdated = Get-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname

	  # Verify that the new peering is added to both cross connection and circuit
	  Assert-AreEqual 2 $crossConnectionUpdated.Peerings.Count
	  Assert-AreEqual 2 $circuitUpdated.Peerings.Count

	  # Update the peering
	  $newVlanId = 100
	  $crossConnectionUpdated.Peerings[0].Vlan = $newVlanId
	  $crossConnectionUpdated = Set-AzureRMExpressRouteCrossConnection -ExpressRouteCrossConnection $crossConnection
	  $circuitUpdated = Get-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname

	  # Verify that the peering update is is reflected in both cross connection and circuit
	  Assert-AreEqual $newVlanId $crossConnectionUpdated.Peerings[0].VlanId
	  Assert-AreEqual $newVlanId $circuitUpdated.Peerings[0].VlanId

	  # Delete peering
	  $crossConnectionUpdated = Remove-AzureRMExpressRouteCrossConnectionPeering -Name AzurePrivatePeering $crossConnectionUpdated
	  $crossConnectionUpdated2 = Set-AzureRMExpressRouteCrossConnection -ExpressRouteCrossConnection $crossConnectionUpdated
	  $crossConnectionUpdated2 = Get-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname

	  # Verify that the peering has been deleted
	  Assert-AreEqual 1 $crossConnectionUpdated2.Peerings.Count
	  Assert-AreEqual 1 $crossConnectionUpdated2.Peerings.Count
    }
    finally
    {
    # Cleanup
      Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests ExpressRouteCrossConnection Peering Stats APIs
#>
function Test-ExpressRouteCircuitStageCRUD
{
    # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation
      
      # Create the ExpressRouteCircuit
	  $peering = New-AzureRmExpressRouteCircuitPeeringConfig -Name MicrosoftPeering -PeeringType MicrosoftPeering -PeerASN 33 -PrimaryPeerAddressPrefix $primaryPeerAddressPrefix -SecondaryPeerAddressPrefix $secondaryPeerAddressPrefix -VlanId $vlanId -MicrosoftConfigAdvertisedPublicPrefixes $microsoftConfigAdvertisedPublicPrefixes -MicrosoftConfigCustomerAsn $microsoftConfigCustomerAsn -MicrosoftConfigRoutingRegistryName $microsoftConfigRoutingRegistryName -LegacyMode $true 
	  $job = New-AzureRmExpressRouteCircuit -Name $circuitName -Location $location -ResourceGroupName $rgname -SkuTier Premium -SkuFamily MeteredData  -ServiceProviderName $providerName -PeeringLocation $peeringLocation -BandwidthInMbps $bandwidth -AsJob
	  $job | Wait-Job
	  $circuit = $job | Receive-Job

      # Verify that an associated cross connection is created
	  $crossConnectionName = $circuit.ServiceKey
	  $crossConnectionResourceGroupName = "CrossConnection-SiliconValley"
      $crossConnection = Get-AzureRMExpressRouteCrossConnection -Name $crossConnectionName -ResourceGroupName $crossConnectionResourceGroupName

	  Assert-AreEqual 1 $crossConnection.Peerings.Count

	  # Create a cross connection peering
	  $peering = New-AzureRmExpressRouteCircuitPeeringConfig -Name AzurePrivatePeering -PeeringType AzurePrivatePeering -PeerASN 100 -PrimaryPeerAddressPrefix "192.168.1.0/30" -SecondaryPeerAddressPrefix "192.168.2.0/30" -VlanId 22
	  $crossConnection.Peerings.Add($peering)
	  $crossConnectionUpdated = Set-AzureRMExpressRouteCrossConnection -ExpressRouteCrossConnection $crossConnection
	  $circuitUpdated = Get-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname

	  Get-AzureRMExpressRouteCrossConnectionArpTable -ResourceGroupName $rgname -CrossConnectionName $crossConnectionUpdated.Name -PeeringType AzurePrivatePeering -DevicePath Primary
	  Get-AzureRMExpressRouteCrossConnectionRouteTable -ResourceGroupName $rgname -CrossConnectionName $crossConnectionUpdated.Name -PeeringType AzurePrivatePeering -DevicePath Primary
	  Get-AzureRMExpressRouteCrossConnectionRouteTableSummary -ResourceGroupName $rgname -CrossConnectionName $crossConnectionUpdated.Name -PeeringType AzurePrivatePeering -DevicePath Primary
    }
    finally
    {
    # Cleanup
      Clean-ResourceGroup $rgname
    }
}

