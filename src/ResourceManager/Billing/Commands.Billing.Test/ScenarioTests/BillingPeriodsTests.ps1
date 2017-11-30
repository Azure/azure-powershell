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
List billing periods
#>
function Test-ListBillingPeriods
{
    $billingBillingPeriods = Get-AzureRmBillingPeriod

    Assert-True {$billingBillingPeriods.Count -ge 1}
	Assert-NotNull $billingBillingPeriods[0].Name
	Assert-NotNull $billingBillingPeriods[0].Id
	Assert-NotNull $billingBillingPeriods[0].Type
	Assert-NotNull $billingBillingPeriods[0].BillingPeriodStartDate
	Assert-NotNull $billingBillingPeriods[0].BillingPeriodEndDate
}

<#
.SYNOPSIS
List billing periods with MaxCount
#>
function Test-ListBillingPeriodsWithMaxCount
{
    $billingBillingPeriods = Get-AzureRmBillingPeriod -MaxCount 1

    Assert-True {$billingBillingPeriods.Count -eq 1}
	Assert-NotNull $billingBillingPeriods[0].Name
	Assert-NotNull $billingBillingPeriods[0].Id
	Assert-NotNull $billingBillingPeriods[0].Type
	Assert-NotNull $billingBillingPeriods[0].BillingPeriodStartDate
	Assert-NotNull $billingBillingPeriods[0].BillingPeriodEndDate
}

<#
.SYNOPSIS
Get billing period with specified name
#>
function Test-GetBillingPeriodWithName
{
	$billingPeriodName = "201705-1"
    $billingPeriod = Get-AzureRmBillingPeriod -Name $billingPeriodName

	Assert-AreEqual $billingPeriodName $billingPeriod.Name
	Assert-NotNull $billingPeriod.Id
	Assert-NotNull $billingPeriod.Type
	Assert-NotNull $billingPeriod.BillingPeriodStartDate
	Assert-NotNull $billingPeriod.BillingPeriodEndDate
	Assert-NotNull $billingPeriod.InvoiceNames
	Assert-AreEqual 1 $billingPeriod.InvoiceNames.Count
	Assert-AreEqual "201705-217994100075389" $billingPeriod.InvoiceNames
}

<#
.SYNOPSIS
Get billing period with specified names
#>
function Test-GetBillingPeriodWithNames
{
	$billingPeriodNames = "201705-1", "201704-1", "201703-1"
    $billingBillingPeriods = Get-AzureRmBillingPeriod -Name $billingPeriodNames

    Assert-True {$billingBillingPeriods.Count -eq 3}
	Foreach($billingPeriod in $billingBillingPeriods)
	{
		Assert-NotNull $billingPeriod.Id
		Assert-NotNull $billingPeriod.Type
		Assert-NotNull $billingPeriod.BillingPeriodStartDate
		Assert-NotNull $billingPeriod.BillingPeriodEndDate
		Assert-NotNull $billingPeriod.InvoiceNames
		Assert-AreEqual 1 $billingPeriod.InvoiceNames.Count
	}
}