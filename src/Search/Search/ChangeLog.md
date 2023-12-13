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

## Version 0.10.0
* Added support for semantic search option

## Version 0.9.0
* Added support for RBAC authentication

## Version 0.8.0
* Added support for new networking features
	- Updated dependency for Microsoft.Azure.Management.Search from 3.0.0 to 4.0.0
    - Support for adding IP rules to service
    - Support for disabling public network access to the service (service is only accessible via private endpoints)
    - Support for managing private endpoint connections
    - Support for listing resources for which outbound private endpoints can be created
    - Support for creating outbound private endpoints (shared private link resources) from service to other Azure resources
* Added support for assigning (or removing) system assigned identity for service

## Version 0.7.4
* Update references in .psd1 to use relative path

## Version 0.7.3
* Fixed miscellaneous typos across module

## Version 0.7.2
* Added 2 new SKUs (Storage_Optimized_L1 and Storage_Optimized_L2) and appropriate tests
    - Updated dependency for Microsoft.Azure.Management.Search from 2.0.1 to 3.0.0
    - Updated dependency for Microsoft.Azure.Search to 9.0.0

## Version 0.7.1
* Initial release with Az 1.0.0
