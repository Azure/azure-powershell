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


# Legacy invoicing tests
<#
.SYNOPSIS
List invoices
#>
function Test-ListInvoices
{
    $billingInvoices = Get-AzBillingInvoice -PeriodStartDate 2020-01-01 -PeriodEndDate 2020-06-30

    Assert-NotNull $billingInvoices
    Assert-NotNull $billingInvoices.Name
    Assert-NotNull $billingInvoices.Status
    Assert-NotNull $billingInvoices.BillingProfileDisplayName
    Assert-NotNull $billingInvoices.InvoiceDate
    Assert-Null $billingInvoices.BillingProfileId
}

<#
.SYNOPSIS
List invoices with DownloadUrl
#>
function Test-ListInvoicesWithDownloadUrl
{
    $billingInvoices = Get-AzBillingInvoice -GenerateDownloadUrl -PeriodStartDate 2020-01-01 -PeriodEndDate 2020-06-30

    Assert-NotNull $billingInvoices
    Assert-NotNull $billingInvoices.DownloadUrl
    Assert-NotNull $billingInvoices.Name
    Assert-NotNull $billingInvoices.Status
    Assert-NotNull $billingInvoices.BillingProfileDisplayName
    Assert-NotNull $billingInvoices.InvoiceDate
}

<#
.SYNOPSIS
List invoices with MaxCount
#>
function Test-ListInvoicesWithMaxCount
{
    $billingInvoices = Get-AzBillingInvoice -GenerateDownloadUrl -MaxCount 1 -PeriodStartDate 2020-01-01 -PeriodEndDate 2020-06-30

    Assert-NotNull $billingInvoices
    Assert-True {$billingInvoices.Count -eq 1}
    Assert-NotNull $billingInvoices.DownloadUrl
    Assert-NotNull $billingInvoices.Name
    Assert-NotNull $billingInvoices.Status
    Assert-NotNull $billingInvoices.BillingProfileDisplayName
    Assert-NotNull $billingInvoices.InvoiceDate
}

<#
.SYNOPSIS
Get latest invoice
#>
function Test-GetLatestInvoice
{
    $billingInvoice = Get-AzBillingInvoice -Latest -GenerateDownloadUrl -PeriodStartDate 2020-01-01 -PeriodEndDate 2020-06-30

	Assert-NotNull $billingInvoice	
    Assert-NotNull $billingInvoice.Name
    Assert-NotNull $billingInvoice.Status
    Assert-NotNull $billingInvoice.BillingProfileDisplayName
    Assert-NotNull $billingInvoice.InvoiceDate
}

<#
.SYNOPSIS
Get invoice with specified name with GenerateDownloadUrl
#>
function Test-GetInvoiceByNameWithDownloadUrl
{
	$billingInvoices = Get-AzBillingInvoice -Name T000512627 -GenerateDownloadUrl -PeriodStartDate 2020-01-01 -PeriodEndDate 2020-06-30

	Assert-NotNull $billingInvoices
	Assert-NotNull $billingInvoices.Name
    Assert-AreEqual $billingInvoices.Name T000512627
}

# Modern Invoicing Tests
<#
.SYNOPSIS
Get modern invoice by InvoiceName
#>
function Test-GetModernInvoiceByName
{
    $billingInvoices = Get-AzBillingInvoice -Name T000512627

    Assert-NotNull $billingInvoices
    Assert-NotNull $billingInvoices.Name
    Assert-NotNull $billingInvoices.Status
    Assert-NotNull $billingInvoices.BillingProfileDisplayName
    Assert-NotNull $billingInvoices.InvoiceDate
    Assert-Null $billingInvoices.DownloadUrl
}

<#
.SYNOPSIS
List invoices by billingAccountName
#>
function Test-ListModernInvoicesByBillingAccountName
{
    $billingInvoices = Get-AzBillingInvoice -BillingAccountName db038d21-b0d2-463c-942f-b09127c6f4e4:7c9c4a38-593e-479e-8958-9a338a0d8d02_2019-05-31 -PeriodStartDate 2020-01-01 -PeriodEndDate 2020-06-30

    Assert-NotNull $billingInvoices
    Assert-NotNull $billingInvoices.Name
    Assert-NotNull $billingInvoices.Status
    Assert-NotNull $billingInvoices.BillingProfileDisplayName
    Assert-NotNull $billingInvoices.InvoiceDate
    Assert-Null $billingInvoices.DownloadUrl
}

<#
.SYNOPSIS
List invoices by billingAccountName with DownloadUrl
#>
function Test-ListModernInvoicesByBillingAccountNameWithDownloadUrl
{
    $billingInvoices = Get-AzBillingInvoice -BillingAccountName db038d21-b0d2-463c-942f-b09127c6f4e4:7c9c4a38-593e-479e-8958-9a338a0d8d02_2019-05-31 -GenerateDownloadUrl -PeriodStartDate 2020-01-01 -PeriodEndDate 2020-06-30

    Assert-NotNull $billingInvoices
    Assert-NotNull $billingInvoices.Name
    Assert-NotNull $billingInvoices.Status
    Assert-NotNull $billingInvoices.BillingProfileDisplayName
    Assert-NotNull $billingInvoices.InvoiceDate
    Assert-NotNull $billingInvoices.DownloadUrl
}

<#
.SYNOPSIS
List invoices by billingAccountName
#>
function Test-ListModernInvoicesByBillingAccountNameWithMaxCount
{
    $billingInvoices = Get-AzBillingInvoice -MaxCount 1 -BillingAccountName db038d21-b0d2-463c-942f-b09127c6f4e4:7c9c4a38-593e-479e-8958-9a338a0d8d02_2019-05-31 -PeriodStartDate 2020-01-01 -PeriodEndDate 2020-06-30

    Assert-NotNull $billingInvoices
    Assert-NotNull $billingInvoices.Name
    Assert-NotNull $billingInvoices.Status
    Assert-NotNull $billingInvoices.BillingProfileDisplayName
    Assert-NotNull $billingInvoices.InvoiceDate
    Assert-Null $billingInvoices.DownloadUrl
}

<#
.SYNOPSIS
Get latest invoice by BillingAccountName
#>
function Test-GetLatestModernInvoiceByBillingAccountName
{
    $billingInvoices = Get-AzBillingInvoice -Latest -BillingAccountName db038d21-b0d2-463c-942f-b09127c6f4e4:7c9c4a38-593e-479e-8958-9a338a0d8d02_2019-05-31 -PeriodStartDate 2020-01-01 -PeriodEndDate 2020-06-30

    Assert-NotNull $billingInvoices
    Assert-NotNull $billingInvoices.Name
    Assert-NotNull $billingInvoices.Status
    Assert-NotNull $billingInvoices.BillingProfileDisplayName
    Assert-NotNull $billingInvoices.InvoiceDate
    Assert-Null $billingInvoices.DownloadUrl
}

<#
.SYNOPSIS
Get latest invoice by BillingAccountName with DownloadUrl
#>
function Test-GetLatestModernInvoiceByBillingAccountNameWithDownloadUrl
{
    $billingInvoices = Get-AzBillingInvoice -Latest -BillingAccountName db038d21-b0d2-463c-942f-b09127c6f4e4:7c9c4a38-593e-479e-8958-9a338a0d8d02_2019-05-31 -GenerateDownloadUrl -PeriodStartDate 2020-01-01 -PeriodEndDate 2020-06-30

    Assert-NotNull $billingInvoices
    Assert-NotNull $billingInvoices.Name
    Assert-NotNull $billingInvoices.Status
    Assert-NotNull $billingInvoices.BillingProfileDisplayName
    Assert-NotNull $billingInvoices.InvoiceDate
    Assert-NotNull $billingInvoices.DownloadUrl
}

<#
.SYNOPSIS
Get latest invoice by BillingAccountName and InvoiceName with DownloadUrl
#>
function Test-GetModernInvoiceByBillingAccountNameAndInvoiceNameWithDownloadUrl
{
    $billingInvoices = Get-AzBillingInvoice -Name T000512627 -BillingAccountName db038d21-b0d2-463c-942f-b09127c6f4e4:7c9c4a38-593e-479e-8958-9a338a0d8d02_2019-05-31 -GenerateDownloadUrl -PeriodStartDate 2020-01-01 -PeriodEndDate 2020-06-30

    Assert-NotNull $billingInvoices
    Assert-NotNull $billingInvoices.Name
    Assert-NotNull $billingInvoices.Status
    Assert-NotNull $billingInvoices.BillingProfileDisplayName
    Assert-NotNull $billingInvoices.InvoiceDate
    Assert-NotNull $billingInvoices.DownloadUrl
}

<#
.SYNOPSIS
Get latest invoice by BillingAccountName and InvoiceName and do not generate DownloadUrl
#>
function Test-GetModernInvoiceByBillingAccountNameAndInvoiceName
{
    $billingInvoices = Get-AzBillingInvoice -Name T000512627 -BillingAccountName db038d21-b0d2-463c-942f-b09127c6f4e4:7c9c4a38-593e-479e-8958-9a338a0d8d02_2019-05-31 -PeriodStartDate 2020-01-01 -PeriodEndDate 2020-06-30

    Assert-NotNull $billingInvoices
    Assert-NotNull $billingInvoices.Name
    Assert-NotNull $billingInvoices.Status
    Assert-NotNull $billingInvoices.BillingProfileDisplayName
    Assert-NotNull $billingInvoices.InvoiceDate
    Assert-Null $billingInvoices.DownloadUrl
}

<#
.SYNOPSIS
List invoices by billingProfileName
#>
function Test-ListModernInvoicesByBillingProfileName
{
    $billingInvoices = Get-AzBillingInvoice -BillingAccountName c017063b-18ad-5e26-f4af-a4d7eff204cb:171df24e-c924-4c58-9daa-a0bdb1686fef_2019-05-31 -BillingProfileName PO6F-IWMU-BG7-TGB -PeriodStartDate 2020-01-01 -PeriodEndDate 2020-06-30

    Assert-NotNull $billingInvoices
    Assert-NotNull $billingInvoices.Name
    Assert-NotNull $billingInvoices.Status
    Assert-NotNull $billingInvoices.BillingProfileDisplayName
    Assert-NotNull $billingInvoices.InvoiceDate
    Assert-Null $billingInvoices.DownloadUrl
}

<#
.SYNOPSIS
List invoices by billingProfileName with DownloadUrl
#>
function Test-ListModernInvoicesByBillingProfileNameWithDownloadUrl
{
    $billingInvoices = Get-AzBillingInvoice -BillingAccountName c017063b-18ad-5e26-f4af-a4d7eff204cb:171df24e-c924-4c58-9daa-a0bdb1686fef_2019-05-31 -BillingProfileName PO6F-IWMU-BG7-TGB -GenerateDownloadUrl -PeriodStartDate 2020-01-01 -PeriodEndDate 2020-06-30

    Assert-NotNull $billingInvoices
    Assert-NotNull $billingInvoices.Name
    Assert-NotNull $billingInvoices.Status
    Assert-NotNull $billingInvoices.BillingProfileDisplayName
    Assert-NotNull $billingInvoices.InvoiceDate
    Assert-NotNull $billingInvoices.DownloadUrl
}

<#
.SYNOPSIS
List invoices by billingProfileName with MaxCount
#>
function Test-ListModernInvoicesByBillingProfileNameMaxCount
{
    $billingInvoices = Get-AzBillingInvoice -BillingAccountName c017063b-18ad-5e26-f4af-a4d7eff204cb:171df24e-c924-4c58-9daa-a0bdb1686fef_2019-05-31 -BillingProfileName PO6F-IWMU-BG7-TGB -MaxCount 1 -PeriodStartDate 2020-01-01 -PeriodEndDate 2020-06-30

    Assert-NotNull $billingInvoices
    Assert-NotNull $billingInvoices.Name
    Assert-NotNull $billingInvoices.Status
    Assert-NotNull $billingInvoices.BillingProfileDisplayName
    Assert-NotNull $billingInvoices.InvoiceDate
    Assert-Null $billingInvoices.DownloadUrl
}

<#
.SYNOPSIS
Get latest invoice by BillingProfileName
#>
function Test-GetLatestInvoicesByBillingProfileName
{
    $billingInvoices = Get-AzBillingInvoice -Latest -BillingAccountName c017063b-18ad-5e26-f4af-a4d7eff204cb:171df24e-c924-4c58-9daa-a0bdb1686fef_2019-05-31 -BillingProfileName PO6F-IWMU-BG7-TGB -PeriodStartDate 2020-01-01 -PeriodEndDate 2020-06-30

    Assert-NotNull $billingInvoices
    Assert-NotNull $billingInvoices.Name
    Assert-NotNull $billingInvoices.Status
    Assert-NotNull $billingInvoices.BillingProfileDisplayName
    Assert-NotNull $billingInvoices.InvoiceDate
    Assert-Null $billingInvoices.DownloadUrl
}

<#
.SYNOPSIS
Get invoices by BillingProfileName with billing period start and end date.
#>
function Test-GetInvoicesByBillingAccountNameBillingProfileNameBillingPeriod
{
    $billingInvoices = Get-AzBillingInvoice -BillingAccountName c017063b-18ad-5e26-f4af-a4d7eff204cb:171df24e-c924-4c58-9daa-a0bdb1686fef_2019-05-31 -BillingProfileName PO6F-IWMU-BG7-TGB -PeriodStartDate 2020-01-01 -PeriodEndDate 2020-06-30

    Assert-NotNull $billingInvoices
    Assert-NotNull $billingInvoices.Name
    Assert-NotNull $billingInvoices.Status
    Assert-NotNull $billingInvoices.BillingProfileDisplayName
    Assert-NotNull $billingInvoices.InvoiceDate

    Assert-Null $billingInvoices.DownloadUrl
}