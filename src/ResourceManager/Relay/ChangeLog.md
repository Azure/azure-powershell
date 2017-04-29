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

## Version 0.0.1
* Adds commandlets for the Azure Relay

    - New-AzureRmRelayNamespace
        - Adds a New Relay NameSpace in the existing Resource Group.
    - Get-AzureRmRelayNamespace
        - Gets Relay NameSpace/list of NameSpaces of existing Resource Group.
    - Set-AzureRmRelayNamespace
        - Updates properties of existing Relay NameSpace.
    - Remove-AzureRmRelayNamespace
        - Deletes the existing Relay NameSpace.
    - New-AzureRmRelayNamespaceAuthorizationRule
        - Adds a new AuthorizationRule to the existing Relay NameSpace.
    - Get-AzureRmRelayNamespaceAuthorizationRule
        - Gets AuthorizationRule / List of AuthorizationRules for the existing Relay NameSpace.
    - Set-AzureRmRelayNamespaceAuthorizationRule
        - Updates properties of existing AuthorizationRule of Relay NameSpace.
    - New-AzureRmRelayNamespaceKey
        - Generates a new Primary/Secondary Key for AuthorizationRule of existing Relay NameSpace.
    - Get-AzureRmRelayNamespaceKey
        - Gets Primary/Secondary Key for AuthorizationRule of existing Relay NameSpace.
    - Remove-AzureRmRelayNamespaceAuthorizationRule
        - Deletes the existing AuthorizationRule of Relay NameSpace.
    - New-AzureRmWcfRelay
        - Adds a new WcfRelay to the existing NameSpace.
    - Get-AzureRmWcfRelay
        - Gets existing Queue/ List of WcfRelay of the existing NameSpace.
    - Set-AzureRmWcfRelay
        - Updates properties of existing WcfRelay of NameSpace.
    - Remove-AzureRmWcfRelay
        - Deletes existing WcfRelay of NameSpace.
    - New-AzureRmWcfRelayAuthorizationRule
        - Adds a new AuthorizationRule to the existing WcfRelay of NameSpace.
    - Get-AzureRmWcfRelayAuthorizationRule
        - Gets the AuthorizationRule / List of AuthorizationRules of the WcfRelay. 
    - Set-AzureRmWcfRelayAuthorizationRule
        - Updates the AuthorizationRule of the WcfRelay.
    - New-AzureRmWcfRelayKey
        - Generates a new Primary/Secondary Key for AuthorizationRule of existing WcfRelay.
    - Get-AzureRmWcfRelayKey
        - Gets Primary/Secondary Key for AuthorizationRule of existing WcfRelay.
    - Remove-AzureRmWcfRelayAuthorizationRule
        - Deletes the existing AuthorizationRule of WcfRelay.
    - New-AzureRmRelayHybridConnections
        - Adds a new HybridConnections to the existing NameSpace.
    - Get-AzureRmRelayHybridConnections
        - Gets existing HybridConnections/ List of HybridConnections of the existing NameSpace.
    - Set-AzureRmRelayHybridConnections
        - Updates properties of existing HybridConnections of NameSpace.
    - Remove-AzureRmRelayHybridConnections
        - Deletes existing HybridConnections of NameSpace.
    - New-AzureRmRelayHybridConnectionsAuthorizationRule
        - Adds a new AuthorizationRule to the existing HybridConnections of NameSpace.
    - Get-AzureRmRelayHybridConnectionsAuthorizationRule
        - Gets the AuthorizationRule / List of AuthorizationRules of the HybridConnections. 
    - Set-AzureRmRelayHybridConnectionsAuthorizationRule
        - Updates the AuthorizationRule of the HybridConnections.
    - New-AzureRmRelayHybridConnectionsKey
        - Generates a new Primary/Secondary Key for AuthorizationRule of existing HybridConnections.
    - Get-AzureRmRelayHybridConnectionsKey
        - Gets Primary/Secondary Key for AuthorizationRule of existing HybridConnections.
    - Remove-AzureRmRelayHybridConnectionsAuthorizationRule
        - Deletes the existing AuthorizationRule of HybridConnections.