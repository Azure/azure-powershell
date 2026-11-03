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
* First preview release of Az.PrivateTrafficManager module (API version 2026-10-01-preview)
    - `New/Get/Update/Remove-AzPrivateTrafficManagerProfile` - Manage PTM (Private Traffic Manager) profiles
    - `New/Get/Update/Remove-AzPrivateTrafficManagerEndpoint` - Manage endpoints
    - `New/Get/Update/Remove-AzPrivateTrafficManagerHealthPolicy` - Manage health policies
    - `New/Get/Update/Remove-AzPrivateTrafficManagerTopologyMap` - Manage topology maps
    - `New/Get/Update/Remove-AzPrivateTrafficManagerSite` - Manage sites
    - `New/Get/Update/Remove-AzPrivateTrafficManagerProfileProbingGateway` - Manage profile associations with existing probing gateways in Basic mode
    - Support VNet (virtual network) routing and endpoint virtual network assignments
    - Expose probe configuration parameters when creating and updating health policies
    - Restrict topology map updates to tags and the catch-all site, with sites managed through site cmdlets
* Changed the preview profile parameter `CustomTopologyMap` to `CustomTopologyMapMode`, accepting `Enabled` or `Disabled` instead of `Enable` or `Disable`

