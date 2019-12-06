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
    $billingPeriods = Get-AzBillingPeriod

    Assert-Null $billingPeriods
}

<#
.SYNOPSIS
List billing periods with MaxCount
#>
function Test-ListBillingPeriodsWithMaxCount
{
    $billingPeriods = Get-AzBillingPeriod -MaxCount 1

    Assert-Null $billingPeriods
}

<#
.SYNOPSIS
Get billing period with specified name
#>
function Test-GetBillingPeriodWithName
{
    $billingPeriod = Get-AzBillingPeriod -Name 201912

	Assert-NotNull $billingPeriod
	Assert-Null $billingPeriod.Name
}

<#
.SYNOPSIS
Get billing period with specified names
#>
function Test-GetBillingPeriodWithNames
{
    $billingPeriods = Get-AzBillingPeriod -Name 201911,201912
    
	Assert-NotNull $billingPeriods
	Assert-AreEqual 2 $billingPeriods.Count
}