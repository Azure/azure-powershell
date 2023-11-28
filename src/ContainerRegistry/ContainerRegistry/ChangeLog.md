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

## Version 4.1.2
* Upgraded Azure.Core to 1.35.0.

## Version 4.1.1
* Updated Azure.Core to 1.34.0.

## Version 4.1.0
* Updated Azure.Core to 1.33.0.
* Added new cmdlet `New-AzContainerRegistryCredentials`

## Version 4.0.0
* Updated module to autorest based
## Version 3.0.4
* Updated Azure.Core to 1.31.0.

## Version 3.0.3
* Added breaking change attributes for cmdlets

## Version 3.0.2
* Updated Azure.Core to 1.28.0.

## Version 3.0.1
* Fixed bug in `Get-AzContainerRegistryTag` to show correct tags [#20528]

## Version 3.0.0
* Updated parameter types from bool to bool? for `Update-AzContainerRegistryRepository` [#17857]
    - `ReadEnabled`
    - `ListEnabled`
    - `WriteEnabled`
    - `DeleteEnabled`

## Version 2.2.3
* Fixed username and password issue in `Import-AzContainerRegistryImage` [#14971]
* Fixed data plane operations (repository, tag, manifest) failed cross registry in single Powershell session [#14849]

## Version 2.2.2
* Fixed bug in `Get-AzContainerRegistryManifest` showing incorrect image name 

## Version 2.2.1
* Fixed authentication for `Connect-AzContainerRegistry`

## Version 2.2.0
* Added cmdlets to supported repository, manifest, and tag operations:
    - `Get-AzContainerRegistryRepository`
    - `Update-AzContainerRegistryRepository`
    - `Remove-AzContainerRegistryRepository`
    - `Get-AzContainerRegistryManifest`
    - `Update-AzContainerRegistryManifest`
    - `Remove-AzContainerRegistryManifest`
    - `Get-AzContainerRegistryTag`
    - `Update-AzContainerRegistryTag`
    - `Remove-AzContainerRegistryTag`

## Version 2.1.0
* Supported parameter `Name` for and value from pipeline input for `Get-AzContainerRegistryUsage` [#13605]
* Polished exceptions for `Connect-AzContainerRegistry`

## Version 2.0.0
* [Breaking Change] Updates API version to 2019-05-01
* [Breaking Change] Removed SKU "Classic" and parameter `StorageAccountName` from `New-AzContainerRegistry`
* Added New cmdlets: `Connect-AzContainerRegistry`, `Import-AzContainerRegistry`, `Get-AzContainerRegistryUsage`, `New-AzContainerRegistryNetworkRule`, `Set-AzContainerRegistryNetworkRule`
* Added new parameter `NetworkRuleSet` to `Update-AzContainerRegistry`


## Version 1.1.1
* Update references in .psd1 to use relative path

## Version 1.1.0
* Fix typo in Remove-AzContainerRegistryReplication for Replication parameter
    - More information here https://github.com/Azure/azure-powershell/issues/9633

## Version 1.0.1
* Update incorrect online help URLs

## Version 1.0.0
* General availability of `Az.ContainerRegistry` module
