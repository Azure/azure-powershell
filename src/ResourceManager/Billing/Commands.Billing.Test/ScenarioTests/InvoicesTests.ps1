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
List invoices
#>
function Test-ListInvoices
{
    $billingInvoices = Get-AzureRmBillingInvoice

    Assert-True {$billingInvoices.Count -ge 1}
	Assert-NotNull $billingInvoices[0].Name
	Assert-NotNull $billingInvoices[0].Id
	Assert-NotNull $billingInvoices[0].Type
	Assert-NotNull $billingInvoices[0].InvoicePeriodStartDate
	Assert-NotNull $billingInvoices[0].InvoicePeriodEndDate
	Assert-Null $billingInvoices[0].DownloadUrl
	Assert-Null $billingInvoices[0].DownloadUrlExpiry
}

<#
.SYNOPSIS
List invoices with DownloadUrl
#>
function Test-ListInvoicesWithDownloadUrl
{
    $billingInvoices = Get-AzureRmBillingInvoice -GenerateDownloadUrl

    Assert-True {$billingInvoices.Count -ge 1}
	Assert-NotNull $billingInvoices[0].Name
	Assert-NotNull $billingInvoices[0].Id
	Assert-NotNull $billingInvoices[0].Type
	Assert-NotNull $billingInvoices[0].InvoicePeriodStartDate
	Assert-NotNull $billingInvoices[0].InvoicePeriodEndDate
	Assert-NotNull $billingInvoices[0].DownloadUrl
	Assert-NotNull $billingInvoices[0].DownloadUrlExpiry
}

<#
.SYNOPSIS
List invoices with MaxCount
#>
function Test-ListInvoicesWithMaxCount
{
    $billingInvoices = Get-AzureRmBillingInvoice -GenerateDownloadUrl -MaxCount 1

    Assert-True {$billingInvoices.Count -eq 1}
	Assert-NotNull $billingInvoices[0].Name
	Assert-NotNull $billingInvoices[0].Id
	Assert-NotNull $billingInvoices[0].Type
	Assert-NotNull $billingInvoices[0].InvoicePeriodStartDate
	Assert-NotNull $billingInvoices[0].InvoicePeriodEndDate
	Assert-NotNull $billingInvoices[0].DownloadUrl
	Assert-NotNull $billingInvoices[0].DownloadUrlExpiry
}

<#
.SYNOPSIS
Get latest invoice
#>
function Test-GetLatestInvoice
{
    $invoice = Get-AzureRmBillingInvoice -Latest

	Assert-NotNull $invoice.Name
	Assert-NotNull $invoice.Id
	Assert-NotNull $invoice.Type
	Assert-NotNull $invoice.InvoicePeriodStartDate
	Assert-NotNull $invoice.InvoicePeriodEndDate
	Assert-NotNull $invoice.DownloadUrl
	Assert-NotNull $invoice.DownloadUrlExpiry
}

<#
.SYNOPSIS
Get invoice with specified name
#>
function Test-GetInvoiceWithName
{
    $sampleInvoices = Get-AzureRmBillingInvoice
    Assert-True { $sampleInvoices.Count -ge 1 }

	$invoice = Get-AzureRmBillingInvoice -Name $sampleInvoices[0].Name

	Assert-AreEqual $invoice.Id $sampleInvoices[0].Id
}

<#
.SYNOPSIS
Get invoice with specified names
#>
function Test-GetInvoiceWithNames
{
	$sampleInvoices = Get-AzureRmBillingInvoice
    Assert-True { $sampleInvoices.Count -gt 1 }

    $billingInvoices = Get-AzureRmBillingInvoice -Name $sampleInvoices.Name

    Assert-AreEqual $sampleInvoices.Count $billingInvoices.Count
}