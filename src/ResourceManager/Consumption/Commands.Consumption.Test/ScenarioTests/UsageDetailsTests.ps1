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
List usage details
#>
function Test-ListUsageDetails
{
    $usageDetails = Get-AzureRmConsumptionUsageDetail -MaxCount 10

    Assert-AreEqual 10 $usageDetails.Count
	Foreach($usage in $usageDetails)
	{
		Assert-NotNull $usage.Name
		Assert-NotNull $usage.Id
		Assert-NotNull $usage.Type
		Assert-NotNull $usage.UsageStart
		Assert-NotNull $usage.UsageEnd
		Assert-NotNull $usage.BillingPeriodName
		Assert-NotNull $usage.InstanceName
		Assert-NotNull $usage.InstanceLocation
		Assert-NotNull $usage.Currency
		Assert-NotNull $usage.UsageQuantity
		Assert-NotNull $usage.BillableQuantity
		Assert-NotNull $usage.PretaxCost
		Assert-NotNull $usage.IsEstimated
		Assert-NotNull $usage.MeterId
		Assert-Null $usage.MeterDetails
		Assert-Null $usage.AdditionalProperties
	}
}

<#
.SYNOPSIS
List usage details with MeterDetails
#>
function Test-ListUsageDetailsWithExpand
{
    $usageDetails = Get-AzureRmConsumptionUsageDetail -IncludeMeterDetails -MaxCount 10

	Foreach($usage in $usageDetails)
	{
		Assert-NotNull $usage.Name
		Assert-NotNull $usage.Id
		Assert-NotNull $usage.Type
		Assert-NotNull $usage.UsageStart
		Assert-NotNull $usage.UsageEnd
		Assert-NotNull $usage.BillingPeriodName
		Assert-NotNull $usage.InstanceName
		Assert-NotNull $usage.InstanceLocation
		Assert-NotNull $usage.Currency
		Assert-NotNull $usage.UsageQuantity
		Assert-NotNull $usage.BillableQuantity
		Assert-NotNull $usage.PretaxCost
		Assert-NotNull $usage.IsEstimated
		Assert-NotNull $usage.MeterId
		Assert-NotNull $usage.MeterDetails
		Assert-NotNull $usage.MeterDetails.MeterName
		Assert-Null $usage.AdditionalProperties
	}
}

<#
.SYNOPSIS
List usage details with Filter
#>
function Test-ListUsageDetailsWithFilter
{
    $usageDetails = Get-AzureRmConsumptionUsageDetail -StartDate 2017-01-17 -EndDate 2017-01-19 -MaxCount 10

    Assert-AreEqual 10 $usageDetails.Count
	Foreach($usage in $usageDetails)
	{
		Assert-NotNull $usage.Name
		Assert-NotNull $usage.Id
		Assert-NotNull $usage.Type
		Assert-NotNull $usage.UsageStart
		Assert-NotNull $usage.UsageEnd
		Assert-NotNull $usage.BillingPeriodName
		Assert-NotNull $usage.InstanceName
		Assert-NotNull $usage.InstanceLocation
		Assert-NotNull $usage.Currency
		Assert-NotNull $usage.UsageQuantity
		Assert-NotNull $usage.BillableQuantity
		Assert-NotNull $usage.PretaxCost
		Assert-NotNull $usage.IsEstimated
		Assert-NotNull $usage.MeterId
		Assert-Null $usage.MeterDetails
		Assert-Null $usage.AdditionalProperties
	}
}

<#
.SYNOPSIS
List usage details of Invoice
#>
function Test-ListInvoiceUsageDetails
{
    $usageDetails = Get-AzureRmConsumptionUsageDetail -InvoiceName 201704-117283130069214 -MaxCount 10

    Assert-AreEqual 10 $usageDetails.Count
	Foreach($usage in $usageDetails)
	{
		Assert-NotNull $usage.Name
		Assert-NotNull $usage.Id
		Assert-NotNull $usage.Type
		Assert-NotNull $usage.UsageStart
		Assert-NotNull $usage.UsageEnd
		Assert-NotNull $usage.BillingPeriodName
		Assert-NotNull $usage.InvoiceName
		Assert-NotNull $usage.InstanceName
		Assert-NotNull $usage.InstanceLocation
		Assert-NotNull $usage.Currency
		Assert-NotNull $usage.UsageQuantity
		Assert-NotNull $usage.BillableQuantity
		Assert-NotNull $usage.PretaxCost
		Assert-NotNull $usage.IsEstimated
		Assert-NotNull $usage.MeterId
		Assert-Null $usage.MeterDetails
		Assert-Null $usage.AdditionalProperties
	}
}

<#
.SYNOPSIS
List usage details with MeterDetails of Invoice
#>
function Test-ListInvoiceUsageDetailsWithExpand
{
    $usageDetails = Get-AzureRmConsumptionUsageDetail -InvoiceName 201704-117283130069214 -IncludeMeterDetails -IncludeAdditionalProperties -MaxCount 10

	Foreach($usage in $usageDetails)
	{
		Assert-NotNull $usage.Name
		Assert-NotNull $usage.Id
		Assert-NotNull $usage.Type
		Assert-NotNull $usage.UsageStart
		Assert-NotNull $usage.UsageEnd
		Assert-NotNull $usage.BillingPeriodName
		Assert-NotNull $usage.InvoiceName
		Assert-NotNull $usage.InstanceName
		Assert-NotNull $usage.InstanceLocation
		Assert-NotNull $usage.Currency
		Assert-NotNull $usage.UsageQuantity
		Assert-NotNull $usage.BillableQuantity
		Assert-NotNull $usage.PretaxCost
		Assert-NotNull $usage.IsEstimated
		Assert-NotNull $usage.MeterId
		Assert-NotNull $usage.MeterDetails
		Assert-NotNull $usage.MeterDetails.MeterName
	}
}

<#
.SYNOPSIS
List usage details with Filter of Invoice
#>
function Test-ListInvoiceUsageDetailsWithFilter
{
    $usageDetails = Get-AzureRmConsumptionUsageDetail -InvoiceName 201704-117283130069214 -IncludeMeterDetails -EndDate 2017-01-19 -MaxCount 10

    Assert-AreEqual 10 $usageDetails.Count
	Foreach($usage in $usageDetails)
	{
		Assert-NotNull $usage.Name
		Assert-NotNull $usage.Id
		Assert-NotNull $usage.Type
		Assert-NotNull $usage.UsageStart
		Assert-NotNull $usage.UsageEnd
		Assert-NotNull $usage.BillingPeriodName
		Assert-NotNull $usage.InvoiceName
		Assert-NotNull $usage.InstanceName
		Assert-NotNull $usage.InstanceLocation
		Assert-NotNull $usage.Currency
		Assert-NotNull $usage.UsageQuantity
		Assert-NotNull $usage.BillableQuantity
		Assert-NotNull $usage.PretaxCost
		Assert-NotNull $usage.IsEstimated
		Assert-NotNull $usage.MeterId
		Assert-NotNull $usage.MeterId
		Assert-NotNull $usage.MeterDetails
		Assert-Null $usage.AdditionalProperties
	}
}


<#
.SYNOPSIS
List usage details of Billing Period
#>
function Test-ListBillingPeriodUsageDetails
{
    $usageDetails = Get-AzureRmConsumptionUsageDetail -BillingPeriodName 201704-1 -MaxCount 10

    Assert-AreEqual 10 $usageDetails.Count
	Foreach($usage in $usageDetails)
	{
		Assert-NotNull $usage.Name
		Assert-NotNull $usage.Id
		Assert-NotNull $usage.Type
		Assert-NotNull $usage.UsageStart
		Assert-NotNull $usage.UsageEnd
		Assert-NotNull $usage.BillingPeriodName
		Assert-NotNull $usage.InvoiceName
		Assert-NotNull $usage.InstanceName
		Assert-NotNull $usage.InstanceLocation
		Assert-NotNull $usage.Currency
		Assert-NotNull $usage.UsageQuantity
		Assert-NotNull $usage.BillableQuantity
		Assert-NotNull $usage.PretaxCost
		Assert-NotNull $usage.IsEstimated
		Assert-NotNull $usage.MeterId
		Assert-Null $usage.MeterDetails
		Assert-Null $usage.AdditionalProperties
	}
}

<#
.SYNOPSIS
List usage details with MeterDetails of Billing Period
#>
function Test-ListBillingPeriodUsageDetailsWithExpand
{
    $usageDetails = Get-AzureRmConsumptionUsageDetail -BillingPeriodName 201704-1 -IncludeMeterDetails -MaxCount 10

	Foreach($usage in $usageDetails)
	{
		Assert-NotNull $usage.Name
		Assert-NotNull $usage.Id
		Assert-NotNull $usage.Type
		Assert-NotNull $usage.UsageStart
		Assert-NotNull $usage.UsageEnd
		Assert-NotNull $usage.BillingPeriodName
		Assert-NotNull $usage.InvoiceName
		Assert-NotNull $usage.InstanceName
		Assert-NotNull $usage.InstanceLocation
		Assert-NotNull $usage.Currency
		Assert-NotNull $usage.UsageQuantity
		Assert-NotNull $usage.BillableQuantity
		Assert-NotNull $usage.PretaxCost
		Assert-NotNull $usage.IsEstimated
		Assert-NotNull $usage.MeterId
		Assert-NotNull $usage.MeterDetails
		Assert-NotNull $usage.MeterDetails.MeterName
		Assert-Null $usage.AdditionalProperties
	}
}

<#
.SYNOPSIS
List usage details with Filter of Billing Period
#>
function Test-ListBillingPeriodUsageDetailsWithFilter
{
    $usageDetails = Get-AzureRmConsumptionUsageDetail -BillingPeriodName 201704-1 -IncludeMeterDetails -IncludeAdditionalProperties -StartDate 2017-01-19 -MaxCount 10

    Assert-AreEqual 10 $usageDetails.Count
	Foreach($usage in $usageDetails)
	{
		Assert-NotNull $usage.Name
		Assert-NotNull $usage.Id
		Assert-NotNull $usage.Type
		Assert-NotNull $usage.UsageStart
		Assert-NotNull $usage.UsageEnd
		Assert-NotNull $usage.BillingPeriodName
		Assert-NotNull $usage.InvoiceName
		Assert-NotNull $usage.InstanceName
		Assert-NotNull $usage.InstanceLocation
		Assert-NotNull $usage.Currency
		Assert-NotNull $usage.UsageQuantity
		Assert-NotNull $usage.BillableQuantity
		Assert-NotNull $usage.PretaxCost
		Assert-NotNull $usage.IsEstimated
		Assert-NotNull $usage.MeterId
		Assert-NotNull $usage.MeterId
		Assert-NotNull $usage.MeterDetails
		Assert-NotNull $usage.MeterDetails.MeterName
	}
}
