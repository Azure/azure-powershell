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
    $invoiceSections = Get-AzInvoiceSection -BillingAccountName c017063b-18ad-5e26-f4af-a4d7eff204cb:171df24e-c924-4c58-9daa-a0bdb1686fef_2019-05-31 -BillingProfileName PO6F-IWMU-BG7-TGB

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
    $sampleInvoiceSections = Get-AzInvoiceSection -BillingAccountName c017063b-18ad-5e26-f4af-a4d7eff204cb:171df24e-c924-4c58-9daa-a0bdb1686fef_2019-05-31 -BillingProfileName PO6F-IWMU-BG7-TGB
	Assert-True {$sampleInvoiceSections.Count -ge 1}

	$invoiceSection = Get-AzInvoiceSection -BillingAccountName c017063b-18ad-5e26-f4af-a4d7eff204cb:171df24e-c924-4c58-9daa-a0bdb1686fef_2019-05-31 -BillingProfileName PO6F-IWMU-BG7-TGB -Name $sampleInvoiceSections[0].Name

	Assert-AreEqual $invoiceSection.Id $sampleInvoiceSections[0].Id
}

<#
.SYNOPSIS
Get billing account with specified names
#>
function Test-GetInvoiceSectionWithNames
{
	$sampleInvoiceSections = Get-AzInvoiceSection -BillingAccountName c017063b-18ad-5e26-f4af-a4d7eff204cb:171df24e-c924-4c58-9daa-a0bdb1686fef_2019-05-31 -BillingProfileName PO6F-IWMU-BG7-TGB
	Assert-True {$sampleInvoiceSections.Count -gt 1}

	$invoiceSections = Get-AzInvoiceSection -BillingAccountName c017063b-18ad-5e26-f4af-a4d7eff204cb:171df24e-c924-4c58-9daa-a0bdb1686fef_2019-05-31 -BillingProfileName PO6F-IWMU-BG7-TGB -Name $sampleInvoiceSections.Name

    Assert-AreEqual $sampleInvoiceSections.Count $invoiceSections.Count
}