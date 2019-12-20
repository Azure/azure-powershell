<!-- region Generated -->
# Az.Billing
This directory contains the PowerShell module for the Billing service.

---
## Status
[![Az.Billing](https://img.shields.io/powershellgallery/v/Az.Billing.svg?style=flat-square&label=Az.Billing "Az.Billing")](https://www.powershellgallery.com/packages/Az.Billing/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.6.0 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Billing`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@beta`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../readme.azure.md
  - $(repo)/specification/billing/resource-manager/readme.md
  - $(repo)/specification/commerce/resource-manager/readme.md
  - $(repo)/specification/consumption/resource-manager/readme.md

module-version: 4.0.2
title: Billing
subject-prefix: ''

directive:
  - where:
      subject: Agreement|Department|Invoice.*|PaymentMethod|RecipientTransfer|Transaction|Transfer
    set:
      alias: ${verb}-AzBilling${subject}
  - where:
      subject: AggregatedCost|Balance|Budget|Charge.*|CostTag|Forecast|Marketplace|PriceSheet|Reservation.*|UsageDetail
    set:
      alias: ${verb}-AzConsumption${subject}
  - where:
      subject: Policy|Product
    set:
      subject-prefix: Billing
  - where:
      subject: Tag|Tenant
    set:
      subject-prefix: Consumption
  - where:
      subject: AvailableBalance
    set:
      subject: AvailableCreditBalance
  - where:
      subject: CreditSummary.*
    set:
      subject: CreditSummary
      alias: ${verb}-AzConsumptionCreditSummary
  - where:
      subject: ConsumptionEventsByBillingProfile
    set:
      subject: ConsumptionEvent
  - where:
      subject: Invoice
      parameter-name: Top
    set:
      alias: MaxCount
  - where:
      verb: Get
      subject: InvoiceLatest
    hide: true
  - where:
      subject: BillingPeriod
      parameter-name: Top
    set:
      alias: MaxCount
  - where:
      subject: UsageDetail
      parameter-name: Top
    set:
      alias: MaxCount
  - where:
      subject: EnrollmentAccount
      parameter-name: Name
    set:
      alias: ObjectId
  - where:
      subject: UsageAggregate
      parameter-name: ShowDetail
    set:
      alias: ShowDetails
  - where:
      subject: BillingProfile
      parameter-name: EnabledAzureSkU
    set:
      parameter-name: EnabledAzureSku
  - where:
      subject: BillingProfile
      parameter-name: PoNumber
    set:
      parameter-name: PurchaseOrderNumber
  - where:
      verb: Get
      subject: UsageAggregate
    set:
      alias: Get-UsageAggregates
  # The below directive hides any cmdlet not currently shipped with Az.Billing
  - where:
      subject: ^(?!^BillingPeriod$)(?!^Budget$)(?!^EnrollmentAccount$)(?!^Invoice$)(?!^Marketplace$)(?!^PriceSheet$)(?!^ReservationDetail$)(?!^ReservationSummary$)(?!^UsageAggregate$)(?!^UsageDetail$).*$
    hide: true
# Fix the name of the module in the nuspec
  - from: Az.Billing.nuspec
    where: $
    transform: $ = $.replace(/Microsoft Azure PowerShell(.) \$\(service-name\) cmdlets/, 'Microsoft Azure PowerShell - Billing service cmdlets for Azure Resource Manager in Windows PowerShell and PowerShell Core.\n\nFor information on Billing, please visit the following$1 https://docs.microsoft.com/azure/billing/');

# Add release notes
  - from: Az.Billing.nuspec
    where: $
    transform: $ = $.replace('<releaseNotes></releaseNotes>', '<releaseNotes>Initial release of preview Billing cmdlets - see https://aka.ms/azps4doc for more information.</releaseNotes>');
# Add a better description
  - from: Az.Billing.nuspec
    where: $
    transform: $ = $.replace(/\$\(service-name\)/g,  'Billing');
# Make the nuget package a preview
  - from: Az.Billing.nuspec
    where: $
    transform: $ = $.replace(/<version>(\d+\.\d+\.\d+)<\/version>/, '<version>$1-preview</version>');
# Update the psd1 description
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/sb.AppendLine\(\$@\"\{Indent\}Description = \'\{\"Microsoft Azure PowerShell(.) Billing cmdlets\"\}\'\"\);/, 'sb.AppendLine\(\$@\"\{Indent\}Description = \'\{\"Microsoft Azure PowerShell - Billing service cmdlets for Azure Resource Manager in Windows PowerShell and PowerShell Core.\\n\\nFor information on Billing, please visit the following$1 https://docs.microsoft.com/azure/billing/\"\}\'\"\);');
# Make this a preview module
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}ReleaseNotes = \'\'\"\);', 'sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}ReleaseNotes = \'Initial release of preview Billing cmdlets - see https://aka.ms/azps4doc for more information.\'\"\);\n            sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}Prerelease = \'preview\'\"\);' );
```
