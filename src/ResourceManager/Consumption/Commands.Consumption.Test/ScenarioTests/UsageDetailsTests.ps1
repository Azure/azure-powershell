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
    $usageDetails = Get-AzureRmConsumptionUsageDetail -Top 10
	Assert-NotNull $usageDetails
    Assert-AreEqual 10 $usageDetails.Count
	Foreach($usage in $usageDetails)
	{
		Assert-NotNull $usage.AccountName
		Assert-Null $usage.AdditionalProperties
		Assert-Null $usage.BillableQuantity
		Assert-NotNull $usage.BillingPeriodId
		Assert-NotNull $usage.ConsumedService
		Assert-NotNull $usage.CostCenter
		Assert-NotNull $usage.Currency
		Assert-NotNull $usage.DepartmentName
		Assert-NotNull $usage.Id
		Assert-NotNull $usage.InstanceId
		Assert-NotNull $usage.InstanceLocation
		Assert-NotNull $usage.InstanceName
		Assert-Null $usage.InvoiceId
		Assert-NotNull $usage.IsEstimated
		Assert-Null $usage.MeterDetails
		Assert-NotNull $usage.MeterId
		Assert-NotNull $usage.Name
		Assert-NotNull $usage.PretaxCost
		Assert-NotNull $usage.Product
		Assert-NotNull $usage.SubscriptionGuid
		Assert-NotNull $usage.SubscriptionName	
		Assert-NotNull $usage.Type
		Assert-NotNull $usage.UsageEnd
		Assert-NotNull $usage.UsageQuantity
		Assert-NotNull $usage.UsageStart
	}
}

<#
.SYNOPSIS
List usage details with Expand on Meter Details
#>
function Test-ListUsageDetailsWithMeterDetailsExpand
{
    $usageDetails = Get-AzureRmConsumptionUsageDetail -Expand MeterDetails -Top 10

	Foreach($usage in $usageDetails)
	{
		Assert-NotNull $usage.AccountName
		Assert-Null $usage.AdditionalProperties
		Assert-Null $usage.BillableQuantity
		Assert-NotNull $usage.BillingPeriodId
		Assert-NotNull $usage.ConsumedService
		Assert-NotNull $usage.CostCenter
		Assert-NotNull $usage.Currency
		Assert-NotNull $usage.DepartmentName
		Assert-NotNull $usage.Id
		Assert-NotNull $usage.InstanceId
		Assert-NotNull $usage.InstanceLocation
		Assert-NotNull $usage.InstanceName
		Assert-Null $usage.InvoiceId
		Assert-NotNull $usage.IsEstimated
		Assert-NotNull $usage.MeterDetails
		Assert-NotNull $usage.MeterId
		Assert-NotNull $usage.Name
		Assert-NotNull $usage.PretaxCost
		Assert-NotNull $usage.Product
		Assert-NotNull $usage.SubscriptionGuid
		Assert-NotNull $usage.SubscriptionName	
		Assert-NotNull $usage.Type
		Assert-NotNull $usage.UsageEnd
		Assert-NotNull $usage.UsageQuantity
		Assert-NotNull $usage.UsageStart
	}
}

<#
.SYNOPSIS
List usage details with Filter on Dates
#>
function Test-ListUsageDetailsWithDateFilter
{
    $usageDetails = Get-AzureRmConsumptionUsageDetail -StartDate 2017-10-02 -EndDate 2017-10-05 -Top 10

    Assert-AreEqual 10 $usageDetails.Count
	Foreach($usage in $usageDetails)
	{
		Assert-NotNull $usage.AccountName
		Assert-Null $usage.AdditionalProperties
		Assert-Null $usage.BillableQuantity
		Assert-NotNull $usage.BillingPeriodId
		Assert-NotNull $usage.ConsumedService
		Assert-NotNull $usage.CostCenter
		Assert-NotNull $usage.Currency
		Assert-NotNull $usage.DepartmentName
		Assert-NotNull $usage.Id
		Assert-NotNull $usage.InstanceId
		Assert-NotNull $usage.InstanceLocation
		Assert-NotNull $usage.InstanceName
		Assert-Null $usage.InvoiceId
		Assert-NotNull $usage.IsEstimated
		Assert-Null $usage.MeterDetails
		Assert-NotNull $usage.MeterId
		Assert-NotNull $usage.Name
		Assert-NotNull $usage.PretaxCost
		Assert-NotNull $usage.Product
		Assert-NotNull $usage.SubscriptionGuid
		Assert-NotNull $usage.SubscriptionName	
		Assert-NotNull $usage.Type
		Assert-NotNull $usage.UsageEnd
		Assert-NotNull $usage.UsageQuantity
		Assert-NotNull $usage.UsageStart
	}
}

<#
.SYNOPSIS
List usage details in Billing Period
#>
function Test-ListBillingPeriodUsageDetails
{
    $usageDetails = Get-AzureRmConsumptionUsageDetail -BillingPeriodName 201710 -Top 10

    Assert-AreEqual 10 $usageDetails.Count
	Foreach($usage in $usageDetails)
	{
		Assert-NotNull $usage.AccountName
		Assert-Null $usage.AdditionalProperties
		Assert-Null $usage.BillableQuantity
		Assert-NotNull $usage.BillingPeriodId
		Assert-NotNull $usage.ConsumedService
		Assert-NotNull $usage.CostCenter
		Assert-NotNull $usage.Currency
		Assert-NotNull $usage.DepartmentName
		Assert-NotNull $usage.Id
		Assert-NotNull $usage.InstanceId
		Assert-NotNull $usage.InstanceLocation
		Assert-NotNull $usage.InstanceName
		Assert-Null $usage.InvoiceId
		Assert-NotNull $usage.IsEstimated
		Assert-Null $usage.MeterDetails
		Assert-NotNull $usage.MeterId
		Assert-NotNull $usage.Name
		Assert-NotNull $usage.PretaxCost
		Assert-NotNull $usage.Product
		Assert-NotNull $usage.SubscriptionGuid
		Assert-NotNull $usage.SubscriptionName	
		Assert-NotNull $usage.Type
		Assert-NotNull $usage.UsageEnd
		Assert-NotNull $usage.UsageQuantity
		Assert-NotNull $usage.UsageStart
	}
}

<#
.SYNOPSIS
List usage details in Billing Period with Filter on Instance Name 
#>
function Test-ListBillingPeriodUsageDetailsWithFilterOnInstanceName
{
    $usageDetails = Get-AzureRmConsumptionUsageDetail -BillingPeriodName 201710 -InstanceName 1c2052westus -Top 10

	Foreach($usage in $usageDetails)
	{
		Assert-NotNull $usage.AccountName
		Assert-Null $usage.AdditionalProperties
		Assert-Null $usage.BillableQuantity
		Assert-NotNull $usage.BillingPeriodId
		Assert-NotNull $usage.ConsumedService
		Assert-NotNull $usage.CostCenter
		Assert-NotNull $usage.Currency
		Assert-NotNull $usage.DepartmentName
		Assert-NotNull $usage.Id
		Assert-NotNull $usage.InstanceId
		Assert-NotNull $usage.InstanceLocation
		Assert-NotNull $usage.InstanceName
		Assert-AreEqual "1c2052westus" $usage.InstanceName
		Assert-Null $usage.InvoiceId
		Assert-NotNull $usage.IsEstimated
		Assert-Null $usage.MeterDetails
		Assert-NotNull $usage.MeterId
		Assert-NotNull $usage.Name
		Assert-NotNull $usage.PretaxCost
		Assert-NotNull $usage.Product
		Assert-NotNull $usage.SubscriptionGuid
		Assert-NotNull $usage.SubscriptionName	
		Assert-NotNull $usage.Type
		Assert-NotNull $usage.UsageEnd
		Assert-NotNull $usage.UsageQuantity
		Assert-NotNull $usage.UsageStart
	}
}

<#
.SYNOPSIS
List usage details in Billing Period with Date Filter
#>
function Test-ListBillingPeriodUsageDetailsWithDateFilter
{
    $usageDetails = Get-AzureRmConsumptionUsageDetail -BillingPeriodName 201710 -StartDate 2017-10-19 -Top 10

    Assert-AreEqual 10 $usageDetails.Count
	Foreach($usage in $usageDetails)
	{
		Assert-NotNull $usage.AccountName
		Assert-Null $usage.AdditionalProperties
		Assert-Null $usage.BillableQuantity
		Assert-NotNull $usage.BillingPeriodId
		Assert-NotNull $usage.ConsumedService
		Assert-NotNull $usage.CostCenter
		Assert-NotNull $usage.Currency
		Assert-NotNull $usage.DepartmentName
		Assert-NotNull $usage.Id
		Assert-NotNull $usage.InstanceId
		Assert-NotNull $usage.InstanceLocation
		Assert-NotNull $usage.InstanceName
		Assert-Null $usage.InvoiceId
		Assert-NotNull $usage.IsEstimated
		Assert-Null $usage.MeterDetails
		Assert-NotNull $usage.MeterId
		Assert-NotNull $usage.Name
		Assert-NotNull $usage.PretaxCost
		Assert-NotNull $usage.Product
		Assert-NotNull $usage.SubscriptionGuid
		Assert-NotNull $usage.SubscriptionName	
		Assert-NotNull $usage.Type
		Assert-NotNull $usage.UsageEnd
		Assert-NotNull $usage.UsageQuantity
		Assert-NotNull $usage.UsageStart
	}
}
