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
* Added client side parameter validation logic for `New-AzAksCluster`, `Set-AzAksCluster` and `New-AzAksNodePool`.
* Added parameter `GenerateSshKey` for `New-AzAksCluster`.
* Updated api version to 2020-06-01.

## Version 1.2.0
* Removed `ClientIdAndSecret` to `ServicePrincipalIdAndSecret` and set `ClientIdAndSecret` as an alias [#12381].
* Removed `Get-AzAks`/`New-AzAks`/`Remove-AzAks`/`Set-AzAks` to `Get-AzAksCluster`/`New-AzAksCluster`/`Remove-AzAksCluster`/`Set-AzAksCluster` and set the original ones as alias [#12373].

## Version 1.1.3
* Fixed bug `Get-AzAks` doesn't get all clusters [#12296]

## Version 1.1.2

* Replaced usage of old [AccessProfile API](https://docs.microsoft.com/rest/api/aks/managedclusters/getaccessprofile) with calls to [ListClusterAdmin](https://docs.microsoft.com/rest/api/aks/managedclusters/listclusteradmincredentials) and [ListClusterUser](https://docs.microsoft.com/rest/api/aks/managedclusters/listclusterusercredentials) APIs

## Version 1.1.1
* Upgraded API Version to 2019-10-01
* Supported to create AKS using Windows container
* Provided new cmdlets: `New-AzAksNodePool`, `Update-AzAksNodePool`, `Remove-AzAksNodePool`,
         `Get-AzAksNodePool`, `Install-AzAksKubectl`, `Get-AzAksVersion`

## Version 1.1.0-preview
* Upgrade to API Version 2019-10-01

## Version 1.0.3
* Update references in .psd1 to use relative path

## Version 1.0.2
* Fixed miscellaneous typos across module
* Fix issue with output for `Get-AzAks`
    * More information here: https://github.com/Azure/azure-powershell/issues/9847

## Version 1.0.1
* Update incorrect online help URLs

## Version 1.0.0
* General availability of `Az.Aks` module
