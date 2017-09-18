<#
.SYNOPSIS
Tests creating a new website.
#>
function Test-CreateNewAzureRmAppServiceEnvironment
{
	# Setup
	$rgname = Get-ResourceGroupName
	$asename = Get-WebsiteName
	$location = Get-Location

    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"

	try
	{
		#Setup
		New-AzureRmResourceGroup -Name $rgname -Location $location

        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $actual = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -DnsServer 8.8.8.8 -Subnet $subnet
        $expected = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		
		# Create new web app
		$actual = New-AzureRmAppServiceEnvironment -ResourceGroupName $rgname -Name $asename -Location $location -VNet $vnetName -Subnet $subnet
		
		# Assert
		Assert-AreEqual $wname $actual.Name
		Assert-AreEqual $serverFarm.Id $actual.ServerFarmId

	}
	finally
	{

	}
}