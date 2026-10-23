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
* Updated Az.StorageDiscovery to use API version 2026-10-01-preview
    - Added parameter `-CapacityDetailStatus` to `New-AzStorageDiscoveryWorkspace` and `Update-AzStorageDiscoveryWorkspace` to enable or disable the capacity details capability
    - Added parameter `-AzureBlobStoragePrefixConfiguration` to `New-AzStorageDiscoveryWorkspace` and `Update-AzStorageDiscoveryWorkspace` to scope capacity details to specific storage accounts, containers, and blob prefixes

## Version 1.0.0
* General availability for module Az.StorageDiscovery

## Version 0.1.0
* First preview release for module Az.StorageDiscovery
