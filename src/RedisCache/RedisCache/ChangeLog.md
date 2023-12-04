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

## Version 1.8.1
* Fixed minor issues

## Version 1.8.0
* Upgraded API version to 2023-04-01

## Version 1.7.1
* Updated `Get-AzRedisCacheLink` and `New-AzRedisCacheLink` to print `PrimaryHostName`, `GeoReplicatedPrimaryHostName`, `ServerRole`, and `LinkedRedisCacheLocation`.

## Version 1.7.0
* Added optional parameter `PreferredDataArchiveAuthMethod` in `Export-AzRedisCache`
* Added optional parameter `PreferredDataArchiveAuthMethod` in `Import-AzRedisCache`
* Added 4 additional properties for a geo replication link: `PrimaryHostName`, `GeoReplicatedPrimaryHostName`, `ServerRole`, and `LinkedRedisCacheLocation`in `Get-AzRedisCacheLink` and `New-AzRedisCacheLink`

## Version 1.6.0
* Added `IdentityType` and `UserAssignedIdentity` parameter in `New-AzRedisCache` and `Set-AzRedisCache` cmdlets.
    - It is used to assign and modify the Identity of Azure Cache for Redis.

## Version 1.5.1
* Created new examples in documentation of `New-AzRedisCache` and `Set-AzRedisCache`.

## Version 1.5.0
* Added `RedisVersion` parameter in `New-AzRedisCache` and `Set-AzRedisCache`

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
