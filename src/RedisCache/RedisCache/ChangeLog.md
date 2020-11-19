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

## Version 1.4.0
* Made `New-AzRedisCache` and `Set-AzRedisCache` cmdlets not fail because of permission issue related to registering Microsoft.Cache RP

## Version 1.2.1
* Update references in .psd1 to use relative path

## Version 1.2.0
* Added `MinimumTlsVersion` parameter in `New-AzRedisCache` and `Set-AzRedisCache` cmdlets. Also, added `MinimumTlsVersion` in the output of `Get-AzRedisCache` cmdlet.
* Added validation on `-Size` parameter for `Set-AzRedisCache` and `New-AzRedisCache` cmdlets

## Version 1.1.1
* Updated `Set-AzRedisCache` reference documentation to include missing values for `-Size` parameter

## Version 1.1.0
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

## Version 1.0.0
* General availability of `Az.RedisCache` module
