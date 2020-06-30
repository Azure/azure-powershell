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
	Assert-Null $billingAccounts[0].SoldTo
	Assert-Null $billingAccounts[0].BillingProfiles
}

<#
.SYNOPSIS
List billing accounts with SoldTo Address
#>
function Test-ListBillingAccountsWithAddress
{
    $billingAccounts = Get-AzBillingAccount -IncludeAddress

    Assert-True {$billingAccounts.Count -ge 1}
	Assert-NotNull $billingAccounts[0].Name
	Assert-NotNull $billingAccounts[0].Id
	Assert-NotNull $billingAccounts[0].Type
	Assert-NotNull $billingAccounts[0].DisplayName
	Assert-NotNull $billingAccounts[0].AgreementType
	Assert-NotNull $billingAccounts[0].SoldTo
	Assert-NotNull $billingAccounts[0].SoldTo.Country
	Assert-Null $billingAccounts[0].BillingProfiles
}

<#
.SYNOPSIS
List billing accounts with billing profiles
#>
function Test-ListBillingAccountsWithBillingProfiles
{
    $billingAccounts = Get-AzBillingAccount -ExpandBillingProfile

    Assert-True {$billingAccounts.Count -ge 1}
	Assert-NotNull $billingAccounts[0].Name
	Assert-NotNull $billingAccounts[0].Id
	Assert-NotNull $billingAccounts[0].Type
	Assert-NotNull $billingAccounts[0].DisplayName
	Assert-NotNull $billingAccounts[0].AgreementType
	Assert-NotNull $billingAccounts[0].BillingProfiles
	Assert-True {$billingAccounts[0].BillingProfiles.Count -ge 1}
	Assert-NotNull $billingAccounts[0].BillingProfiles[0].BillTo
	Assert-Null $billingAccounts[0].SoldTo
}

<#
.SYNOPSIS
List billing accounts with invoice sections
#>
function Test-ListBillingAccountsWithInvoiceSections
{
    $billingAccounts = Get-AzBillingAccount -ExpandInvoiceSection

    Assert-True {$billingAccounts.Count -ge 1}
	Assert-NotNull $billingAccounts[0].Name
	Assert-NotNull $billingAccounts[0].Id
	Assert-NotNull $billingAccounts[0].Type
	Assert-NotNull $billingAccounts[0].DisplayName
	Assert-NotNull $billingAccounts[0].AgreementType	
	Assert-NotNull $billingAccounts[0].BillingProfiles
	Assert-True {$billingAccounts[0].BillingProfiles.Count -ge 1}
	Assert-NotNull $billingAccounts[0].BillingProfiles[0].InvoiceSections
	Assert-True {$billingAccounts[0].BillingProfiles[0].InvoiceSections.Count -ge 1}
	Assert-Null $billingAccounts[0].SoldTo
}

<#
.SYNOPSIS
Get billing account with specified name
#>
function Test-ListBillingEntitiesToCreateSubscription
{
    $sampleBillingAccounts = Get-AzBillingAccount
    Assert-True { $sampleBillingAccounts.Count -ge 1 }

	$billingEntitiesToCreateSubscription = Get-AzBillingAccount -Name $sampleBillingAccounts[0].Name -ListEntitiesToCreateSubscription		
    Assert-True { $billingEntitiesToCreateSubscription.Count -ge 1 }
	Assert-NotNull $billingEntitiesToCreateSubscription[0].BillingProfileId
	Assert-NotNull $billingEntitiesToCreateSubscription[0].BillingProfileDisplayName
	Assert-NotNull $billingEntitiesToCreateSubscription[0].BillingProfileStatus
	Assert-NotNull $billingEntitiesToCreateSubscription[0].InvoiceSectionId
	Assert-NotNull $billingEntitiesToCreateSubscription[0].InvoiceSectionDisplayName	
	Assert-NotNull $billingEntitiesToCreateSubscription[0].EnabledAzurePlans
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