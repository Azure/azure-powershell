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

## Version 0.1.1
* Made Collector policy a tracked resource (added location property to create and update cmdlet and made it mandatory)
* Changed prefix of cmdlets from "AzureTrafficCollector" to "TrafficCollector"
* Changed operation id of list cmdlets to remove the cmdlets `Get-AzNetworkFunctionAzureTrafficCollectorsByResourceGroup` and `Get-AzNetworkFunctionAzureTrafficCollectorsBySubscription` and call them internally based on parameters provided to the cmdlet `Get-AzNetworkFunctionAzureTrafficCollector_List`

## Version 0.1.0
* First preview release for module Az.NetworkFunction

