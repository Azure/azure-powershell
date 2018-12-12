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

# Instructions of recording tests
# Recording of price sheet tests requires a subscription with some resources 
# associated. You can create some resources, so that information on Azure pricing
# will be shown from price sheet data. For any recording question, 
# please contact Prem.Prakash@microsoft.com

<#
.SYNOPSIS
List price sheets
#>
function Test-ListPriceSheets
{
    $priceSheets = Get-AzureRmConsumptionPriceSheet -Top 5
	Assert-NotNull $priceSheets
	Assert-NotNull $priceSheets.Id
	Assert-NotNull $priceSheets.Name
	Assert-NotNull $priceSheets.Type	

	$priceSheetProperties = $priceSheets.PriceSheets
	Assert-NotNull $priceSheetProperties
	Assert-AreEqual 5 $priceSheetProperties.Count
	Foreach($psp in $priceSheetProperties)
	{
		Assert-NotNull $psp.BillingPeriodId
		Assert-NotNull $psp.CurrencyCode
		Assert-NotNull $psp.IncludedQuantity
		Assert-Null $psp.MeterDetails
		Assert-NotNull $psp.MeterId
		Assert-NotNull $psp.PartNumber
		Assert-NotNull $psp.UnitOfMeasure
		Assert-NotNull $psp.UnitPrice
	}
}

<#
.SYNOPSIS
List price sheets with Expand on Meter Details
#>
function Test-ListPriceSheetsWithMeterDetailsExpand
{
    $priceSheets = Get-AzureRmConsumptionPriceSheet -ExpandMeterDetail -Top 5
	Assert-NotNull $priceSheets
	Assert-NotNull $priceSheets.Id
	Assert-NotNull $priceSheets.Name
	Assert-NotNull $priceSheets.Type	

	$priceSheetProperties = $priceSheets.PriceSheets
	Assert-NotNull $priceSheetProperties
	Assert-AreEqual 5 $priceSheetProperties.Count
	Foreach($psp in $priceSheetProperties)
	{
		Assert-NotNull $psp.BillingPeriodId
		Assert-NotNull $psp.CurrencyCode
		Assert-NotNull $psp.IncludedQuantity
		Assert-NotNull $psp.MeterDetails
		Assert-NotNull $psp.MeterId
		Assert-NotNull $psp.PartNumber
		Assert-NotNull $psp.UnitOfMeasure
		Assert-NotNull $psp.UnitPrice
	}
}

<#
.SYNOPSIS
List price sheets in Billing Period
#>
function Test-ListBillingPeriodPriceSheets
{
    $priceSheets = Get-AzureRmConsumptionPriceSheet -BillingPeriodName 201712 -Top 5
	Assert-NotNull $priceSheets
	Assert-NotNull $priceSheets.Id
	Assert-NotNull $priceSheets.Name
	Assert-NotNull $priceSheets.Type	

	$priceSheetProperties = $priceSheets.PriceSheets
	Assert-NotNull $priceSheetProperties
	Assert-AreEqual 5 $priceSheetProperties.Count
	Foreach($psp in $priceSheetProperties)
	{
		Assert-NotNull $psp.BillingPeriodId
		Assert-NotNull $psp.CurrencyCode
		Assert-NotNull $psp.IncludedQuantity
		Assert-Null $psp.MeterDetails
		Assert-NotNull $psp.MeterId
		Assert-NotNull $psp.PartNumber
		Assert-NotNull $psp.UnitOfMeasure
		Assert-NotNull $psp.UnitPrice
	}
}