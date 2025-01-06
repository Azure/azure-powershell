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

## Version 1.2.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 1.2.0
* Renamed `*-AzFederatedIdentityCredentials` to `*-AzFederatedIdentityCredential`, and kept `*-AzFederatedIdentityCredentials` as an alias.

## Version 1.1.1
* Upgraded to API version 2023-01-31.
* Federated identity credentials GA version is available now.

## Version 1.1.0
* Supported Create/Get/Update/Remove Federated Identity Credentials on a User Assigned Managed Identity
  * `Get-AzFederatedIdentityCredentials`
  * `New-AzFederatedIdentityCredentials`
  * `Remove-AzFederatedIdentityCredentials`
  * `Update-AzFederatedIdentityCredentials`
* Supported List Associated Resources on a User Assigned Managed Identity
  * `Get-AzUserAssignedIdentityAssociatedResource`

## Version 1.0.0
* General availability of `Az.ManagedServiceIdentity`

## Version 0.8.0
* Bumped API Version to 2018-11-30
* Added new cmdlets `Get-AzSystemAssignedIdentity` and `Update-AzUserAssignedIdentity`

## Version 0.7.3
* Update references in .psd1 to use relative path

## Version 0.7.2
* Fixed miscellaneous typos across module

## Version 0.7.1
* Update release with latest service features and serialization fixes
