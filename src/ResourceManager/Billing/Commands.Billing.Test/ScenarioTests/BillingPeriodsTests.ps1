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
    $billingPeriods = Get-AzureRmBillingPeriod

    Assert-True {$billingPeriods.Count -ge 1}
	Assert-NotNull $billingPeriods[0].Name
	Assert-NotNull $billingPeriods[0].Id
	Assert-NotNull $billingPeriods[0].Type
	Assert-NotNull $billingPeriods[0].BillingPeriodStartDate
	Assert-NotNull $billingPeriods[0].BillingPeriodEndDate
}

<#
.SYNOPSIS
List billing periods with MaxCount
#>
function Test-ListBillingPeriodsWithMaxCount
{
    $billingPeriods = Get-AzureRmBillingPeriod -MaxCount 1

    Assert-True {$billingPeriods.Count -eq 1}
	Assert-NotNull $billingPeriods[0].Name
	Assert-NotNull $billingPeriods[0].Id
	Assert-NotNull $billingPeriods[0].Type
	Assert-NotNull $billingPeriods[0].BillingPeriodStartDate
	Assert-NotNull $billingPeriods[0].BillingPeriodEndDate
}

<#
.SYNOPSIS
Get billing period with specified name
#>
function Test-GetBillingPeriodWithName
{
    $billingPeriods = Get-AzureRmBillingPeriod | where { $_.InvoiceNames.Count -eq 1 }
    Assert-True {$billingPeriods.Count -ge 1}

	$billingPeriodName = $billingPeriods[0].Name
	$billingInvoiceName = $billingPeriods[0].InvoiceNames[0]

    $billingPeriod = Get-AzureRmBillingPeriod -Name $billingPeriodName

	Assert-AreEqual $billingPeriodName $billingPeriod.Name
	Assert-NotNull $billingPeriod.Id
	Assert-NotNull $billingPeriod.Type
	Assert-NotNull $billingPeriod.BillingPeriodStartDate
	Assert-NotNull $billingPeriod.BillingPeriodEndDate
	Assert-NotNull $billingPeriod.InvoiceNames
	Assert-AreEqual 1 $billingPeriod.InvoiceNames.Count
	Assert-AreEqual $billingInvoiceName $billingPeriod.InvoiceNames
}

<#
.SYNOPSIS
Get billing period with specified names
#>
function Test-GetBillingPeriodWithNames
{
    $sampleBillingPeriods = Get-AzureRmBillingPeriod
    Assert-True {$sampleBillingPeriods.Count -gt 1}

	$billingPeriodNames = $sampleBillingPeriods | %{ $_.Name }
    $billingPeriods = Get-AzureRmBillingPeriod -Name $billingPeriodNames

    Assert-AreEqual $sampleBillingPeriods.Count $billingPeriods.Count
	Foreach($billingPeriod in $billingPeriods)
	{
		Assert-NotNull $billingPeriod.Id
		Assert-NotNull $billingPeriod.Type
		Assert-NotNull $billingPeriod.BillingPeriodStartDate
		Assert-NotNull $billingPeriod.BillingPeriodEndDate
	}
}