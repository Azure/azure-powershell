<!-- region Generated -->
# Az.Relay
This directory contains the PowerShell module for the Relay service.

---
## Status
[![Az.Relay](https://img.shields.io/powershellgallery/v/Az.Relay.svg?style=flat-square&label=Az.Relay "Az.Relay")](https://www.powershellgallery.com/packages/Az.Relay/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Relay`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 591b17c5a50e7fc0ef09211197279e6d9f7ebc22
require:
  - $(this-folder)/../readme.azure.noprofile.md
  - $(repo)/specification/relay/resource-manager/readme.md

title: Relay

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true
inlining-threshold: 50

directive:
  # Namespace Authorization Rule
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/authorizationRules/{authorizationRuleName}"].put.operationId
    transform: return "AuthorizationRule_CreateOrUpdate"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/authorizationRules/{authorizationRuleName}"].get.operationId
    transform: return "AuthorizationRule_Get"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/authorizationRules].get.operationId
    transform: return "AuthorizationRule_List"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/authorizationRules/{authorizationRuleName}"].delete.operationId
    transform: return "AuthorizationRule_Delete"

  # HybridConnections Authorization Rule
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/hybridConnections/{hybridConnectionName}/authorizationRules/{authorizationRuleName}"].put.operationId
    transform: return "AuthorizationRule_CreateOrUpdate"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/hybridConnections/{hybridConnectionName}/authorizationRules/{authorizationRuleName}"].get.operationId
    transform: return "AuthorizationRule_Get"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/hybridConnections/{hybridConnectionName}/authorizationRules"].get.operationId
    transform: return "AuthorizationRule_List"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/hybridConnections/{hybridConnectionName}/authorizationRules/{authorizationRuleName}"].delete.operationId
    transform: return "AuthorizationRule_Delete"

# WcfRelays Authorization Rule
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/wcfRelays/{relayName}/authorizationRules/{authorizationRuleName}"].put.operationId
    transform: return "AuthorizationRule_CreateOrUpdate"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/wcfRelays/{relayName}/authorizationRules/{authorizationRuleName}"].get.operationId
    transform: return "AuthorizationRule_Get"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/wcfRelays/{relayName}/authorizationRules"].get.operationId
    transform: return "AuthorizationRule_List"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/wcfRelays/{relayName}/authorizationRules/{authorizationRuleName}"].delete.operationId
    transform: return "AuthorizationRule_Delete"

  # Merge Namepsace,HybridConnections, WcfRelays Api 
  # Namespace key
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/authorizationRules/{authorizationRuleName}/regenerateKeys"].post.operationId
    transform: return "Key_RegenerateKeys"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/authorizationRules/{authorizationRuleName}/listKeys"].post.operationId
    transform: return "Key_ListKeys"

  # HybridConnections Key
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/hybridConnections/{hybridConnectionName}/authorizationRules/{authorizationRuleName}/regenerateKeys"].post.operationId
    transform: return "Key_RegenerateKeys"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/hybridConnections/{hybridConnectionName}/authorizationRules/{authorizationRuleName}/listKeys"].post.operationId
    transform: return "Key_ListKeys"

  # WcfRelays Key
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/wcfRelays/{relayName}/authorizationRules/{authorizationRuleName}/regenerateKeys"].post.operationId
    transform: return "Key_RegenerateKeys"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/wcfRelays/{relayName}/authorizationRules/{authorizationRuleName}/listKeys"].post.operationId
    transform: return "Key_ListKeys"

  # Remove cmdlet, Private link related resource should be ignored. 
  - where:
     subject: PrivateEndpointConnection|PrivateLinkResource
    remove: true

  # Custom New-AzRelayNamespaceNetworkRuleSet to Set-AzRelayNamespaceNetworkRuleSet 
  - where:
      verb: New
      subject: ^NamespaceNetworkRuleSet$
    hide: true

  - where:
      verb: New
      subject: ^NamespaceNetworkRuleSet$
      variant: ^Create$
    remove: true

  - where:
      verb: New
      subject: ^NamespaceNetworkRuleSet$
      variant: ^CreateViaIdentity$
    hide: true

  - where:
      verb: Set
      subject: ^NamespaceNetworkRuleSet$
    remove: true

  # Custom Set Wcf Relay UpdateExpanded
  - where:
      verb: Set
      subject: ^WcfRelay$
    hide: true

# Custom Set-AzRelayAuthorizationRule
  - where:
      verb: Set
      subject: ^AuthorizationRule$
    hide: true

# Custom Set-AzRelayHybridConnection
  - where:
      verb: Set
      subject: ^HybridConnection$
    hide: true

  - where:
      verb: Set
      subject: ^Namespace$
    remove: true

  - where:
      verb: Test
      subject: NamespaceNameAvailability
    set:
      subject: Name
  - where:
      subject: ^WcfRelay$
    set:
      subject-prefix: Wcf
      subject: Relay

  - where:
      verb: New
      subject: ^Namespace$
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true

  - where:
      verb: Update
      subject: ^Namespace$
      variant: ^Update$|^UpdateViaIdentity$
    remove: true
    
  - where:
      verb: New
      subject: ^HybridConnection$|^Relay$
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true
    
  - where:
      subject: ^Key$
      variant: ^Regenerate$|^RegenerateViaIdentityExpanded$|^RegenerateViaIdentity$|^Regenerate1$|^RegenerateViaIdentityExpanded1$|^RegenerateViaIdentity1$|^Regenerate2$|^RegenerateViaIdentityExpanded2$|^RegenerateViaIdentity2$
    remove: true

  - where:
      subject: ^AuthorizationRule$
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Create1$|^^CreateViaIdentity1$|^CreateViaIdentityExpanded1$|^Create2$|^^CreateViaIdentity2$|^CreateViaIdentityExpanded2$
    remove: true

  - where:
      verb: Test
      subject: ^Name$
      variant: ^Check$|^CheckViaIdentity$|^CheckViaIdentityExpanded$
    remove: true

  - where:
      subject: ^Namespace$
      parameter-name: PrivateEndpointConnection
    hide: true

  - where:
      verb: Test
      subject: ^Name$
      parameter-name: Name
    set:
      parameter-name: Namespace

  - where:
      subject: ^AuthorizationRule$|^Key$
      parameter-name: NamespaceName
    set:
      parameter-name: Namespace

  - where:
      subject: ^AuthorizationRule$|^Key$
      parameter-name: HybridConnectionName
    set:
      parameter-name: HybridConnection

  - where:
      subject: ^AuthorizationRule$|^Key$
      parameter-name: RelayName
    set:
      parameter-name: WcfRelay

  - where:
      subject: ^Key$
      parameter-name: AuthorizationRuleName
    set:
      parameter-name: Name

  - where:
      subject: ^Key$
      parameter-name: KeyType
    set:
      parameter-name: RegenerateKey

  - where:
      subject: ^Key$
      parameter-name: Key
    set:
      parameter-name: KeyValue

  - where:
      subject: ^HybridConnection$
      parameter-name: NamespaceName
    set:
      parameter-name: Namespace

  - where:
      verb: New|Set
      subject: ^HybridConnection$
      parameter-name: Parameter
    set:
      parameter-name: InputObject

  - where:
      verb: Set
      varinat: ^UpdateExpanded$
      subject: ^HybridConnection$
      parameter-name: RequiresClientAuthorization
    hide: true

  - where:
      verb: New|Set
      subject: ^Relay$
      parameter-name: Parameter
    set:
      parameter-name: InputObject

  - where:
      verb: Set
      subject: ^Relay$
      parameter-name: RequiresClientAuthorization
    hide: true

  - where:
      verb: Set
      subject: ^Relay$
      parameter-name: RequiresTransportSecurity
    hide: true

  - where:
      verb: Set
      subject: ^Relay$
      parameter-name: WcfRelayType
    hide: true

  - where:
      verb: Set
      subject: ^AuthorizationRule$
      parameter-name: Parameter
    set:
      parameter-name: InputObject

  - where:
      subject-prefix: Wcf
      subject: ^Relay$
      parameter-name: NamespaceName
    set:
      parameter-name: Namespace

  - where:
      subject-prefix: Wcf
      subject: ^Relay$
      parameter-name: RelayName
    set:
      parameter-name: Name

  - where:
      subject-prefix: Wcf
      subject: ^Relay$
      parameter-name: RelayType
    set:
      parameter-name: WcfRelayType

  - where:
      verb: Get|Remove
      subject: ^AuthorizationRule$
    hide: true

  # Hide parameter -PublicNetworkAccess from New-AzRelayNamespace and Update-AzRelayNamespace
  - where:
      verb: New|Update
      subject: ^NameSpace$
      parameter-name: PublicNetworkAccess
    hide: true

  # Hide parameter -SkuTier in Update-AzRelayNamespace
  - where:
      verb: Update
      subject: ^NameSpace$
      parameter-name: SkuTier
    hide: true

  # - model-cmdlet:
  #   - NwRuleSetIPRules
    
  - where:
      model-name: RelayNamespace
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - Location
          - Status
          - SkuName
          - ServiceBusEndpoint
  
```
