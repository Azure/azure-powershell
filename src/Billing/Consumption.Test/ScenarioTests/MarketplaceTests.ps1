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
# Recording of marketplace tests requires a subscription with marketplace usage. 
# You can create some resources through Azure Marketplace, so that marketplace usage 
# will show consumption data from those resources. For any recording question, 
# please contact Prem.Prakash@microsoft.com

<#
.SYNOPSIS
List marketplaces
#>
function Test-ListMarketplaces
{
    $marketplaces = Get-AzureRmConsumptionMarketplace -Top 10
	Assert-NotNull $marketplaces
    Assert-AreEqual 10 $marketplaces.Count
	Foreach($mkp in $marketplaces)
	{
		Assert-NotNull $mkp.BillingPeriodId
		Assert-NotNull $mkp.ConsumedQuantity
		Assert-NotNull $mkp.Currency
		Assert-NotNull $mkp.Id
		Assert-NotNull $mkp.InstanceId
		Assert-NotNull $mkp.InstanceName
		Assert-NotNull $mkp.IsEstimated
		Assert-NotNull $mkp.Name
		Assert-NotNull $mkp.OrderNumber
		Assert-NotNull $mkp.PretaxCost
		Assert-NotNull $mkp.ResourceRate
		Assert-NotNull $mkp.SubscriptionGuid
		Assert-NotNull $mkp.Type
		Assert-NotNull $mkp.UsageEnd
		Assert-NotNull $mkp.UsageStart
	}
}

<#
.SYNOPSIS
List marketplaces with Filter on Dates
#>
function Test-ListMarketplacesWithDateFilter
{
    $marketplaces = Get-AzureRmConsumptionMarketplace -StartDate 2018-01-03 -EndDate 2018-01-20 -Top 10
	Assert-NotNull $marketplaces
    Assert-AreEqual 10 $marketplaces.Count
	Foreach($mkp in $marketplaces)
	{
		Assert-NotNull $mkp.BillingPeriodId
		Assert-NotNull $mkp.ConsumedQuantity
		Assert-NotNull $mkp.Currency
		Assert-NotNull $mkp.Id
		Assert-NotNull $mkp.InstanceId
		Assert-NotNull $mkp.InstanceName
		Assert-NotNull $mkp.IsEstimated
		Assert-NotNull $mkp.Name
		Assert-NotNull $mkp.OrderNumber
		Assert-NotNull $mkp.PretaxCost
		Assert-NotNull $mkp.ResourceRate
		Assert-NotNull $mkp.SubscriptionGuid
		Assert-NotNull $mkp.Type
		Assert-NotNull $mkp.UsageEnd
		Assert-NotNull $mkp.UsageStart
	}
}

<#
.SYNOPSIS
List marketplaces in billing period
#>
function Test-ListBillingPeriodMarketplaces
{
    $marketplaces = Get-AzureRmConsumptionMarketplace -BillingPeriodName 201801-1 -Top 10
	Assert-NotNull $marketplaces
    Assert-AreEqual 10 $marketplaces.Count
	Foreach($mkp in $marketplaces)
	{
		Assert-NotNull $mkp.BillingPeriodId
		Assert-NotNull $mkp.ConsumedQuantity
		Assert-NotNull $mkp.Currency
		Assert-NotNull $mkp.Id
		Assert-NotNull $mkp.InstanceId
		Assert-NotNull $mkp.InstanceName
		Assert-NotNull $mkp.IsEstimated
		Assert-NotNull $mkp.Name
		Assert-NotNull $mkp.OrderNumber
		Assert-NotNull $mkp.PretaxCost
		Assert-NotNull $mkp.ResourceRate
		Assert-NotNull $mkp.SubscriptionGuid
		Assert-NotNull $mkp.Type
		Assert-NotNull $mkp.UsageEnd
		Assert-NotNull $mkp.UsageStart
	}
}

<#
.SYNOPSIS
List marketplaces with Filter on Instance Name
#>
function Test-ListMarketplacesWithFilterOnInstanceName
{
    $marketplaces = Get-AzureRmConsumptionMarketplace -InstanceName TestVM -Top 10
	Assert-NotNull $marketplaces
    Assert-AreEqual 10 $marketplaces.Count
	Foreach($mkp in $marketplaces)
	{
		Assert-NotNull $mkp.BillingPeriodId
		Assert-NotNull $mkp.ConsumedQuantity
		Assert-NotNull $mkp.Currency
		Assert-NotNull $mkp.Id
		Assert-NotNull $mkp.InstanceId
		Assert-NotNull $mkp.InstanceName
		Assert-NotNull $mkp.IsEstimated
		Assert-NotNull $mkp.Name
		Assert-NotNull $mkp.OrderNumber
		Assert-NotNull $mkp.PretaxCost
		Assert-NotNull $mkp.ResourceRate
		Assert-NotNull $mkp.SubscriptionGuid
		Assert-NotNull $mkp.Type
		Assert-NotNull $mkp.UsageEnd
		Assert-NotNull $mkp.UsageStart
	}
}