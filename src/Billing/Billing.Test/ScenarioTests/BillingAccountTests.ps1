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
List billing accounts
#>
function Test-ListBillingAccounts
{
    $billingAccounts = Get-AzBillingAccount

    Assert-True {$billingAccounts.Count -ge 1}
	Assert-NotNull $billingAccounts[0].Name
	Assert-NotNull $billingAccounts[0].Id
	Assert-NotNull $billingAccounts[0].Type
	Assert-NotNull $billingAccounts[0].DisplayName
	Assert-NotNull $billingAccounts[0].AgreementType
	Assert-Null $billingAccounts[0].Address
	Assert-Null $billingAccounts[0].BillingProfiles
}

<#
.SYNOPSIS
List billing accounts with Address
#>
function Test-ListBillingAccountsWithAddress
{
    $billingAccounts = Get-AzBillingAccount -PopulateAddress

    Assert-True {$billingAccounts.Count -ge 1}
	Assert-NotNull $billingAccounts[0].Name
	Assert-NotNull $billingAccounts[0].Id
	Assert-NotNull $billingAccounts[0].Type
	Assert-NotNull $billingAccounts[0].DisplayName
	Assert-NotNull $billingAccounts[0].AgreementType
	Assert-NotNull $billingAccounts[0].Address
	Assert-NotNull $billingAccounts[0].Address.Country
	Assert-Null $billingAccounts[0].BillingProfiles
}

<#
.SYNOPSIS
Get billing account with specified name
#>
function Test-GetBillingAccountWithName
{
    $sampleBillingAccounts = Get-AzBillingAccount
    Assert-True { $sampleBillingAccounts.Count -ge 1 }

	$billingAccount = Get-AzBillingAccount -Name $sampleBillingAccounts[0].Name

	Assert-AreEqual $billingAccount.Id $sampleBillingAccounts[0].Id
}

<#
.SYNOPSIS
Get billing account with specified names
#>
function Test-GetBillingAccountWithNames
{
	$sampleBillingAccounts = Get-AzBillingAccount
    Assert-True { $sampleBillingAccounts.Count -ge 1 }

    $billingAccounts = Get-AzBillingAccount -Name $sampleBillingAccounts.Name

    Assert-AreEqual $sampleBillingAccounts.Count $billingAccounts.Count
}