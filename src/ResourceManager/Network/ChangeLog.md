<!--
    Please leave this section at the top of the change log.

    Changes for the current release should go under the section titled "Current Release", and should adhere to the following format:

    ## Current Release
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
## Current Release

## Version 3.0.0
* Add-AzureRmVirtualNetworkPeering
    - Parameter AlloowGatewayTransit renamed to AllowGatewayTransit (an alias for the old parameter was created)
    - Fixed issue where UseRemoteGateway property was not being populated in the request to the server
* Get-AzureRmEffectiveNetworkSecurityGroup
    - Add warning if there is no response from GetEffectiveNSG
* Add Source property to EffectiveRoute