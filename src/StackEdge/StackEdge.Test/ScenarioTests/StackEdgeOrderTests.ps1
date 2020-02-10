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

function Get-DeviceForOrder
{
	return getAssetName
}


<#
.SYNOPSIS
Negative test. Get resources from an non-existing empty group.
#>
function Test-GetOrderNonExistent
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceForOrder
	$sku = 'Edge'
	$location = 'westus2'

	# Test
	try
	{
		$newDevice = New-AzStackEdgeDevice $rgname $dfname -Sku $sku -Location $location
		$order = Get-AzStackEdgeOrder $rgname $dfname
		Assert-Null $order "Order should be null, but it isn't"	
	}
	finally
	{
		Remove-AzStackEdgeDevice $rgname $dfname
	}  

}


<#
.SYNOPSIS
Tests Create Order and Validate shipping address and Contact Information
#>
function Test-CreateNewOrder
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceForOrder
	$sku = 'Edge'
	$location = 'westus2'

	$contactPerson = 'John Mcclane'
	$companyName = 'Microsoft'
	$phone = 8004269400
	$email = 'john@microsoft.com'
	$addressLine1 = "Microsoft Corporation"
	$postalCode = 98052
	$city = 'Redmond'
	$state = 'WA'
	$country = "United States"

	# Test
	try
	{
		$newDevice = New-AzStackEdgeDevice $rgname $dfname -Sku $sku -Location $location
		$newOrder = New-AzStackEdgeOrder -ResourceGroupName $rgname -DeviceName $dfname -ContactPerson $contactPerson -CompanyName $companyName -Phone $phone -Email $email -AddressLine1  $addressLine1 -PostalCode $postalCode -City $city -State $state -Country $country
		Assert-AreEqual $newDevice.Name $dfname
		Assert-AreEqual $newOrder.StackEdgeOrder.ContactInformation.ContactPerson $contactPerson
		Assert-AreEqual $newOrder.StackEdgeOrder.ContactInformation.CompanyName $companyName
		Assert-AreEqual $newOrder.StackEdgeOrder.ContactInformation.Phone $phone
		Assert-AreEqual $newOrder.StackEdgeOrder.ContactInformation.EmailList $email

		Assert-AreEqual $newOrder.StackEdgeOrder.ShippingAddress.AddressLine1 $addressLine1
		Assert-AreEqual $newOrder.StackEdgeOrder.ShippingAddress.PostalCode $postalCode
		Assert-AreEqual $newOrder.StackEdgeOrder.ShippingAddress.City $city
		Assert-AreEqual $newOrder.StackEdgeOrder.ShippingAddress.State $state
		Assert-AreEqual $newOrder.StackEdgeOrder.ShippingAddress.Country $country

	}
	finally
	{
		Remove-AzStackEdgeOrder $rgname $dfname
		Remove-AzStackEdgeDevice $rgname $dfname
	}  
}

<#
.SYNOPSIS
Tests Create Order and Validate shipping address and Contact Information
#>
function Test-RemoveOrder
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceForOrder
	$sku = 'Edge'
	$location = 'westus2'

	$contactPerson = 'John Mcclane'
	$companyName = 'Microsoft'
	$phone = 8004269400
	$email = 'john@microsoft.com'
	$addressLine1 = "Microsoft Corporation"
	$postalCode = 98052
	$city = 'Redmond'
	$state = 'WA'
	$country = "United States"

	# Test
	try
	{
		$newDevice = New-AzStackEdgeDevice $rgname $dfname -Sku $sku -Location $location
		$newOrder = New-AzStackEdgeOrder -ResourceGroupName $rgname -DeviceName $dfname -ContactPerson $contactPerson -CompanyName $companyName -Phone $phone -Email $email -AddressLine1  $addressLine1 -PostalCode $postalCode -City $city -State $state -Country $country
		Remove-AzStackEdgeOrder $rgname $dfname
		Assert-Null $order "Order should be null, but it isn't"	
	}
	finally
	{
		Remove-AzStackEdgeDevice $rgname $dfname
	}  
}
