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
    $billingProfiles = Get-AzBillingProfile -BillingAccountName 723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31

    Assert-True {$billingProfiles.Count -ge 1}
	Assert-NotNull $billingProfiles[0].Name
	Assert-NotNull $billingProfiles[0].Id
	Assert-NotNull $billingProfiles[0].Type
	Assert-NotNull $billingProfiles[0].DisplayName
	Assert-NotNull $billingProfiles[0].Address
	Assert-NotNull $billingProfiles[0].Address.Country
	Assert-NotNull $billingProfiles[0].Address.PostalCode
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
    $sampleBillingProfiles = Get-AzBillingProfile -BillingAccountName 723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31
	Assert-True {$sampleBillingProfiles.Count -ge 1}

	$billingProfile = Get-AzBillingProfile -BillingAccountName 723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31 -Name $sampleBillingProfiles[0].Name

	Assert-AreEqual $billingProfile.Id $sampleBillingProfiles[0].Id
	Assert-NotNull $billingProfile.Name
	Assert-NotNull $billingProfile.Type
	Assert-NotNull $billingProfile.DisplayName
	Assert-NotNull $billingProfile.Address
	Assert-NotNull $billingProfile.Address.Country
	Assert-NotNull $billingProfile.Address.PostalCode
	Assert-NotNull $billingProfile.Currency
	Assert-AreEqual 5 $billingProfile.InvoiceDay
	Assert-Null $billingProfile.invoiceSections
}

<#
.SYNOPSIS
Get billing profiles and include enabled azure plans
#>
function Test-GetBillingProfileWithEnabledAzurePlans
{
	$billingProfiles = Get-AzBillingProfile -BillingAccountName 723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31 -ExpandEnabledAzurePlans

    Assert-True {$billingProfiles.Count -ge 1}
	Assert-NotNull $billingProfiles[0].Name
	Assert-NotNull $billingProfiles[0].Id
	Assert-NotNull $billingProfiles[0].Type
	Assert-NotNull $billingProfiles[0].DisplayName
	Assert-NotNull $billingProfiles[0].Address
	Assert-NotNull $billingProfiles[0].Address.Country
	Assert-NotNull $billingProfiles[0].Address.PostalCode
	Assert-NotNull $billingProfiles[0].Currency
	Assert-AreEqual 5 $billingProfiles[0].InvoiceDay
	Assert-NotNull $billingProfiles[0].EnabledAzurePlans
	Assert-True {$billingProfiles[0].EnabledAzurePlans.Count -ge 1}
	Assert-NotNull $billingProfiles[0].EnabledAzurePlans[0].SkuId
	Assert-NotNull $billingProfiles[0].EnabledAzurePlans[0].SkuDescription
	Assert-Null $billingProfiles[0].invoiceSections
}

<#
.SYNOPSIS
Get billing profiles and include invoice sections
#>
function Test-GetBillingProfileWithInvoiceSections
{
	$billingProfiles = Get-AzBillingProfile -BillingAccountName 723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31 -ExpandInvoiceSections

    Assert-True {$billingProfiles.Count -ge 1}
	Assert-NotNull $billingProfiles[0].Name
	Assert-NotNull $billingProfiles[0].Id
	Assert-NotNull $billingProfiles[0].Type
	Assert-NotNull $billingProfiles[0].DisplayName
	Assert-NotNull $billingProfiles[0].Address
	Assert-NotNull $billingProfiles[0].Address.Country
	Assert-NotNull $billingProfiles[0].Address.PostalCode
	Assert-NotNull $billingProfiles[0].Currency
	Assert-AreEqual 5 $billingProfiles[0].InvoiceDay
	Assert-Null $billingProfiles[0].EnabledAzurePlans
	Assert-NotNull $billingProfiles[0].invoiceSections
	Assert-True {$billingProfiles[0].invoiceSections.Count -ge 1}
	Assert-NotNull $billingProfiles[0].invoiceSections[0].Id
	Assert-NotNull $billingProfiles[0].invoiceSections[0].Name
}


<#
.SYNOPSIS
Get billing profile by name and include enabled azure plans
#>
function Test-GetBillingProfileByNameWithEnabledAzurePlans
{
	$sampleBillingProfiles = Get-AzBillingProfile -BillingAccountName 723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31
	Assert-True {$sampleBillingProfiles.Count -ge 1}

	$billingProfile = Get-AzBillingProfile -BillingAccountName 723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31 -Name $sampleBillingProfiles[0].Name -ExpandEnabledAzurePlans

	Assert-NotNull $billingProfile.Name
	Assert-NotNull $billingProfile.Id
	Assert-NotNull $billingProfile.Type
	Assert-NotNull $billingProfile.DisplayName
	Assert-NotNull $billingProfile.Address
	Assert-NotNull $billingProfile.Address.Country
	Assert-NotNull $billingProfile.Address.PostalCode
	Assert-NotNull $billingProfile.Currency
	Assert-AreEqual 5 $billingProfile.InvoiceDay
	Assert-NotNull $billingProfile.EnabledAzurePlans
	Assert-True {$billingProfile.EnabledAzurePlans.Count -ge 1}
	Assert-NotNull $billingProfile.EnabledAzurePlans[0].SkuId
	Assert-NotNull $billingProfile.EnabledAzurePlans[0].SkuDescription
	Assert-Null $billingProfile.invoiceSections
}

<#
.SYNOPSIS
Get billing profile by name and include invoice sections
#>
function Test-GetBillingProfileByNameWithInvoiceSections
{
	$sampleBillingProfiles = Get-AzBillingProfile -BillingAccountName 723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31
	Assert-True {$sampleBillingProfiles.Count -ge 1}

	$billingProfile = Get-AzBillingProfile -BillingAccountName 723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31 -Name $sampleBillingProfiles[0].Name -ExpandInvoiceSections

	Assert-NotNull $billingProfile.Name
	Assert-NotNull $billingProfile.Id
	Assert-NotNull $billingProfile.Type
	Assert-NotNull $billingProfile.DisplayName
	Assert-NotNull $billingProfile.Address
	Assert-NotNull $billingProfile.Address.Country
	Assert-NotNull $billingProfile.Address.PostalCode
	Assert-NotNull $billingProfile.Currency
	Assert-AreEqual 5 $billingProfile.InvoiceDay
	Assert-Null $billingProfile.EnabledAzurePlans
	Assert-NotNull $billingProfile.invoiceSections
	Assert-True {$billingProfile.invoiceSections.Count -ge 1}
	Assert-NotNull $billingProfile.invoiceSections[0].Id
	Assert-NotNull $billingProfile.invoiceSections[0].Name
}