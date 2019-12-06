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
List invoice sections
#>
function Test-ListInvoiceSections
{
    $invoiceSections = Get-AzInvoiceSection -BillingAccountName 723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31 -BillingProfileName H6RI-TXWC-BG7-PGB

    Assert-True {$invoiceSections.Count -ge 1}
	Assert-NotNull $invoiceSections[0].Name
	Assert-NotNull $invoiceSections[0].Id
	Assert-NotNull $invoiceSections[0].Type
	Assert-NotNull $invoiceSections[0].DisplayName
}

<#
.SYNOPSIS
Get invoice section with specified name
#>
function Test-GetInvoiceSectionWithName
{
    $sampleInvoiceSections = Get-AzInvoiceSection -BillingAccountName 723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31 -BillingProfileName H6RI-TXWC-BG7-PGB
	Assert-True {$sampleInvoiceSections.Count -ge 1}

	$invoiceSection = Get-AzInvoiceSection -BillingAccountName 723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31 -BillingProfileName H6RI-TXWC-BG7-PGB -Name $sampleInvoiceSections[0].Name

	Assert-AreEqual $invoiceSection.Id $sampleInvoiceSections[0].Id
}

<#
.SYNOPSIS
Get billing account with specified names
#>
function Test-GetInvoiceSectionWithNames
{
	$sampleInvoiceSections = Get-AzInvoiceSection -BillingAccountName 723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31 -BillingProfileName H6RI-TXWC-BG7-PGB
	Assert-True {$sampleInvoiceSections.Count -gt 1}

	$invoiceSections = Get-AzInvoiceSection -BillingAccountName 723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31 -BillingProfileName H6RI-TXWC-BG7-PGB -Name $sampleInvoiceSections.Name

    Assert-AreEqual $sampleInvoiceSections.Count $invoiceSections.Count
}