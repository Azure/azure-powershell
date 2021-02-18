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
Gets private stores that were defined in tenant level 
#>
function Test-GetAzMarketplacePrivateStore
{
	$propertiesCount=6
	$AvailabilityValue="enabled"
	$PrivateStoreIdValue="a70d384d-ec34-47dd-9d38-ec6df452cba1"

	$queryResult = Get-AzMarketplacePrivateStore
	
	Assert-NotNull  $queryResult
	Assert-AreEqual $queryResult.Count 1

	for ($i = 0; $i -lt $queryResult.Count; $i++)
    {
		Assert-PropertiesCount $queryResult[$i] $propertiesCount
		Assert-AreEqual $queryResult[$i].Availability $AvailabilityValue
		Assert-AreEqual $queryResult[$i].PrivateStoreId $PrivateStoreIdValue
    }
}

<#
.SYNOPSIS
Gets private store offers that were defined in tenant level 
#>
function Test-GetAzMarketplacePrivateStoreOffers
{
	$propertiesCount=11
	$PrivateStoreIdValue="a70d384d-ec34-47dd-9d38-ec6df452cba1"

	$queryResult = Get-AzMarketplacePrivateStoreOffer -PrivateStoreId $PrivateStoreIdValue
	
	Assert-NotNull  $queryResult
	Assert-AreEqual $queryResult.Count 3

	for ($i = 0; $i -lt $queryResult.Count; $i++)
    {
		Assert-PropertiesCount $queryResult[$i] $propertiesCount
		Assert-AreEqual $queryResult[$i].PrivateStoreId $PrivateStoreIdValue
    }
}

<#
.SYNOPSIS
Gets private store offers that were defined in tenant level 
#>
function Test-GetAzMarketplacePrivateStoreOffer
{
	$propertiesCount=11
	$PrivateStoreIdValue="a70d384d-ec34-47dd-9d38-ec6df452cba1"
	$OfferIdValue="altamira-corporation.lumify"

	$queryResult = Get-AzMarketplacePrivateStoreOffer -PrivateStoreId $PrivateStoreIdValue -OfferId $OfferIdValue
	
	Assert-NotNull  $queryResult
	Assert-AreEqual $queryResult.Count 1

	for ($i = 0; $i -lt $queryResult.Count; $i++)
    {
		Assert-PropertiesCount $queryResult[$i] $propertiesCount
		Assert-AreEqual $queryResult[$i].PrivateStoreId $PrivateStoreIdValue
		Assert-AreEqual $queryResult[$i].UniqueOfferId $OfferIdValue
    }
}

<#
.SYNOPSIS
Deletes private store offer that was defined in tenant level 
#>
function Test-RemoveAzMarketplacePrivateStoreOffer
{
	$PrivateStoreIdValue="a70d384d-ec34-47dd-9d38-ec6df452cba1"
	$OfferIdValue="altamira-corporation.lumify"

	$queryResult = Remove-AzMarketplacePrivateStoreOffer -PrivateStoreId $PrivateStoreIdValue -OfferId $OfferIdValue -PassThru
    
	Assert-AreEqual true $queryResult
	
}

<#
.SYNOPSIS
Creates private store offer that was defined in tenant level 
#>
function Test-CreateAzMarketplacePrivateStoreOffer
{
	$propertiesCount=11
	$PrivateStoreIdValue="a70d384d-ec34-47dd-9d38-ec6df452cba1"
	$OfferIdValue="altamira-corporation.lumify"
	$SpecificPlanIdsLimitationValue= @("lumify","0001")

	$queryResult = Set-AzMarketplacePrivateStoreOffer -PrivateStoreId $PrivateStoreIdValue -OfferId $OfferIdValue -SpecificPlanIdsLimitation $SpecificPlanIdsLimitationValue
    
	Assert-NotNull  $queryResult
	Assert-AreEqual $queryResult.Count 1

	for ($i = 0; $i -lt $queryResult.Count; $i++)
    {
		Assert-PropertiesCount $queryResult[$i] $propertiesCount
		Assert-AreEqual $queryResult[$i].PrivateStoreId $PrivateStoreIdValue
		Assert-AreEqual $queryResult[$i].UniqueOfferId $OfferIdValue
    }
}

<#
.SYNOPSIS
Updates private store offer that was defined in tenant level 
#>
function Test-UpdateAzMarketplacePrivateStoreOffer
{
	$propertiesCount=11
	$PrivateStoreIdValue="a70d384d-ec34-47dd-9d38-ec6df452cba1"
	$OfferIdValue="altamira-corporation.lumify"
	$SpecificPlanIdsLimitationValue= @("lumify")
	$EtagValue ="020032e7-0000-0100-0000-5ee629440000"

	$queryResult = Set-AzMarketplacePrivateStoreOffer -PrivateStoreId $PrivateStoreIdValue -OfferId $OfferIdValue -SpecificPlanIdsLimitation $SpecificPlanIdsLimitationValue -ETag $EtagValue
    
	Assert-NotNull  $queryResult
	Assert-AreEqual $queryResult.Count 1

	for ($i = 0; $i -lt $queryResult.Count; $i++)
    {
		Assert-PropertiesCount $queryResult[$i] $propertiesCount
		Assert-AreEqual $queryResult[$i].PrivateStoreId $PrivateStoreIdValue
		Assert-AreEqual $queryResult[$i].UniqueOfferId $OfferIdValue
		Assert-AreEqual $queryResult[$i].SpecificPlanIdsLimitation.Count 1
    }
}

<#
.SYNOPSIS
Updates private store private offer that was defined in subscription level 
#>
function Test-UpdateAzMarketplacePrivateStorePrivateOffer
{
	$propertiesCount=11
	$PrivateStoreIdValue="a70d384d-ec34-47dd-9d38-ec6df452cba1"
	$OfferIdValue="test_test_pmc2pc1.test-managed-app-private-indirect-gov"
	$SpecificPlanIdsLimitationValue= @("test-managed-app")
	$SubscriptionId="bc17bb69-1264-4f90-a9f6-0e51e29d5281"

	$queryResult = Set-AzMarketplacePrivateStoreOffer -PrivateStoreId $PrivateStoreIdValue -OfferId $OfferIdValue -SpecificPlanIdsLimitation $SpecificPlanIdsLimitationValue -SubscriptionId $SubscriptionId
    
	Assert-NotNull  $queryResult
	Assert-AreEqual $queryResult.Count 1

	for ($i = 0; $i -lt $queryResult.Count; $i++)
    {
		Assert-PropertiesCount $queryResult[$i] $propertiesCount
		Assert-AreEqual $queryResult[$i].PrivateStoreId $PrivateStoreIdValue
		Assert-AreEqual $queryResult[$i].UniqueOfferId $OfferIdValue
		Assert-AreEqual $queryResult[$i].SpecificPlanIdsLimitation.Count 1
    }
}

<#
.SYNOPSIS
Gets private store private offers that were defined in subscription level 
#>
function Test-GetAzMarketplacePrivateStorePrivateOffers
{
	$propertiesCount=11
	$PrivateStoreIdValue="a70d384d-ec34-47dd-9d38-ec6df452cba1"
	$SubscriptionId="bc17bb69-1264-4f90-a9f6-0e51e29d5281"
	$OfferIdValue="test_test_pmc2pc1.test-managed-app-private-indirect-gov"

	$queryResult = Get-AzMarketplacePrivateStoreOffer -PrivateStoreId $PrivateStoreIdValue
	
	Assert-NotNull  $queryResult
	Assert-AreEqual $queryResult.Count 2

	for ($i = 0; $i -lt $queryResult.Count; $i++)
    {
		Assert-PropertiesCount $queryResult[$i] $propertiesCount
		Assert-AreEqual $queryResult[$i].PrivateStoreId $PrivateStoreIdValue
    }

	$queryResult = Get-AzMarketplacePrivateStoreOffer -PrivateStoreId $PrivateStoreIdValue -SubscriptionId $SubscriptionId
	
	Assert-NotNull  $queryResult
	Assert-AreEqual $queryResult.Count 1

	for ($i = 0; $i -lt $queryResult.Count; $i++)
    {
		Assert-PropertiesCount $queryResult[$i] $propertiesCount
		Assert-AreEqual $queryResult[$i].PrivateStoreId $PrivateStoreIdValue
		Assert-AreEqual $queryResult[$i].UniqueOfferId $OfferIdValue
    }
}