<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
    * Overview of change #1
        - Additional information about change #1
    * Overview of change #2
        - Additional information about change #2
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1
-->
## Upcoming Release
* upgraded nuget package to signed package.

## Version 2.1.0
* Renamed `Get-UsageAggregates` to `Get-AzUsageAggregate` and added `Get-UsageAggregates` as the alias to avoid breaking change.

## Version 2.0.4
* Removed the outdated deps.json file.

## Version 2.0.3
* Fixed page continuation for Consumption PriceSheet cmdlet

## Version 2.0.2
* Fixed skip token for Consumption PriceSheet cmdlet

## Version 2.0.1
* Fixed pagination for `Get-AzConsumptionPriceSheet` cmdlet

## Version 2.0.0
* Added `Get-AzBillingAccount` cmdlet
* Added `Get-AzBillingProfile` cmdlet
* Added `Get-AzInvoiceSection` cmdlet
* Added new parameters in `Get-AzBillingInvoice` cmdlet
* Removed properties DownloadUrlExpiry, Type, BillingPeriodNames from the response of Get-AzBillingInvoice cmdlet

## Version 1.0.3
* Updated assembly version of consumption cmdlets

## Version 1.0.2
* Update references in .psd1 to use relative path

## Version 1.0.1
* Fixed miscellaneous typos across module

## Version 1.0.0
* General availability of `Az.Billing` module
