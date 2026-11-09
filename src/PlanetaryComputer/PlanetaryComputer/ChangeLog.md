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
* Updated GeoCatalog cmdlets to API version 2026-10-01.
* Added cmdlets to manage GeoCatalog private endpoint connections and discover private link resources.
* Added public network access and read-only lifecycle properties.
* Added explicit None and UserAssigned identity selection. GeoCatalogs do not support Premium tier configuration or system-assigned identities.

## Version 0.1.0
* First release for module Az.PlanetaryComputer
* Added `Get-AzPlanetaryComputerGeoCatalog`, `New-AzPlanetaryComputerGeoCatalog`, `Update-AzPlanetaryComputerGeoCatalog`, and `Remove-AzPlanetaryComputerGeoCatalog` cmdlets for GeoCatalog CRUD operations.
