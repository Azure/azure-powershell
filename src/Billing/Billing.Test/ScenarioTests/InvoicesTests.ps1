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
    $billingInvoices = Get-AzBillingInvoice

    Assert-Null $billingInvoices
}

<#
.SYNOPSIS
List invoices with DownloadUrl
#>
function Test-ListInvoicesWithDownloadUrl
{
    $billingInvoices = Get-AzBillingInvoice -GenerateDownloadUrl

    Assert-Null $billingInvoices
}

<#
.SYNOPSIS
List invoices with MaxCount
#>
function Test-ListInvoicesWithMaxCount
{
    $billingInvoices = Get-AzBillingInvoice -GenerateDownloadUrl -MaxCount 1

    Assert-Null $billingInvoices
}

<#
.SYNOPSIS
Get latest invoice
#>
function Test-GetLatestInvoice
{
    $invoice = Get-AzBillingInvoice -Latest

	Assert-NotNull $invoice
	Assert-Null $invoice.Name
}

<#
.SYNOPSIS
Get invoice with specified name
#>
function Test-GetInvoiceWithName
{
	$invoice = Get-AzBillingInvoice -Name Test

	Assert-NotNull $invoice
	Assert-Null $invoice.Name
}