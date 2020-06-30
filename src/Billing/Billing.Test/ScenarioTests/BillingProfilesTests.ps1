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
List billing profiles
#>
function Test-ListBillingProfiles
{
    $billingProfiles = Get-AzBillingProfile -BillingAccountName c017063b-18ad-5e26-f4af-a4d7eff204cb:171df24e-c924-4c58-9daa-a0bdb1686fef_2019-05-31

    Assert-True {$billingProfiles.Count -ge 1}
	Assert-NotNull $billingProfiles[0].Name
	Assert-NotNull $billingProfiles[0].Id
	Assert-NotNull $billingProfiles[0].Type
	Assert-NotNull $billingProfiles[0].DisplayName
	Assert-NotNull $billingProfiles[0].BillTo
	Assert-NotNull $billingProfiles[0].BillTo.Country
	Assert-NotNull $billingProfiles[0].BillTo.PostalCode
	Assert-NotNull $billingProfiles[0].Currency
	Assert-AreEqual 5 $billingProfiles[0].InvoiceDay
	Assert-Null $billingProfiles[0].invoiceSections
}

<#
.SYNOPSIS
Get billing profile with specified name
#>
function Test-GetBillingProfileWithName
{
    $sampleBillingProfiles = Get-AzBillingProfile -BillingAccountName c017063b-18ad-5e26-f4af-a4d7eff204cb:171df24e-c924-4c58-9daa-a0bdb1686fef_2019-05-31
	Assert-True {$sampleBillingProfiles.Count -ge 1}

	$billingProfile = Get-AzBillingProfile -BillingAccountName c017063b-18ad-5e26-f4af-a4d7eff204cb:171df24e-c924-4c58-9daa-a0bdb1686fef_2019-05-31 -Name $sampleBillingProfiles[0].Name

	Assert-AreEqual $billingProfile.Id $sampleBillingProfiles[0].Id
	Assert-NotNull $billingProfile.Name
	Assert-NotNull $billingProfile.Type
	Assert-NotNull $billingProfile.DisplayName
	Assert-NotNull $billingProfile.BillTo
	Assert-NotNull $billingProfile.BillTo.Country
	Assert-NotNull $billingProfile.BillTo.PostalCode
	Assert-NotNull $billingProfile.Currency
	Assert-AreEqual 5 $billingProfile.InvoiceDay
	Assert-Null $billingProfile.invoiceSections
}

<#
.SYNOPSIS
Get billing profiles and include invoice sections
#>
function Test-GetBillingProfileWithInvoiceSections
{
	$billingProfiles = Get-AzBillingProfile -BillingAccountName c017063b-18ad-5e26-f4af-a4d7eff204cb:171df24e-c924-4c58-9daa-a0bdb1686fef_2019-05-31 -ExpandInvoiceSection

    Assert-True {$billingProfiles.Count -ge 1}
	Assert-NotNull $billingProfiles[0].Name
	Assert-NotNull $billingProfiles[0].Id
	Assert-NotNull $billingProfiles[0].Type
	Assert-NotNull $billingProfiles[0].DisplayName
	Assert-NotNull $billingProfiles[0].BillTo
	Assert-NotNull $billingProfiles[0].BillTo.Country
	Assert-NotNull $billingProfiles[0].BillTo.PostalCode
	Assert-NotNull $billingProfiles[0].Currency
	Assert-AreEqual 5 $billingProfiles[0].InvoiceDay
	Assert-NotNull $billingProfiles[0].EnabledAzurePlans
	Assert-NotNull $billingProfiles[0].invoiceSections
	Assert-True {$billingProfiles[0].invoiceSections.Count -ge 1}
	Assert-NotNull $billingProfiles[0].invoiceSections[0].Id
	Assert-NotNull $billingProfiles[0].invoiceSections[0].Name
}

<#
.SYNOPSIS
Get billing profile by name and include invoice sections
#>
function Test-GetBillingProfileByNameWithInvoiceSections
{
	$sampleBillingProfiles = Get-AzBillingProfile -BillingAccountName c017063b-18ad-5e26-f4af-a4d7eff204cb:171df24e-c924-4c58-9daa-a0bdb1686fef_2019-05-31
	Assert-True {$sampleBillingProfiles.Count -ge 1}

	$billingProfile = Get-AzBillingProfile -BillingAccountName c017063b-18ad-5e26-f4af-a4d7eff204cb:171df24e-c924-4c58-9daa-a0bdb1686fef_2019-05-31 -Name $sampleBillingProfiles[0].Name -ExpandInvoiceSection

	Assert-NotNull $billingProfile.Name
	Assert-NotNull $billingProfile.Id
	Assert-NotNull $billingProfile.Type
	Assert-NotNull $billingProfile.DisplayName
	Assert-NotNull $billingProfile.BillTo
	Assert-NotNull $billingProfile.BillTo.Country
	Assert-NotNull $billingProfile.BillTo.PostalCode
	Assert-NotNull $billingProfile.Currency
	Assert-AreEqual 5 $billingProfile.InvoiceDay
	Assert-NotNull $billingProfile.EnabledAzurePlans
	Assert-NotNull $billingProfile.invoiceSections
	Assert-True {$billingProfile.invoiceSections.Count -ge 1}
	Assert-NotNull $billingProfile.invoiceSections[0].Id
	Assert-NotNull $billingProfile.invoiceSections[0].Name
}