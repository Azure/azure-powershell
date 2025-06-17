<!-- region Generated -->
# Az.ManagedNetworkFabric
This directory contains the PowerShell module for the ManagedNetworkFabric service.

---
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
For information on how to develop for `Az.ManagedNetworkFabric`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: 2655e1cb46e7cba81e7b0fa0cdd2fbeaa75fd715
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/managednetworkfabric/resource-manager/readme.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/managednetworkfabric/resource-manager/Microsoft.ManagedNetworkFabric/preview/2024-06-15-preview/managednetworkfabric.json

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: ManagedNetworkFabric
service-name: ManagedNetworkFabric
subject-prefix: NetworkFabric
use-extension:
  "@autorest/powershell": "4.x"

# If there are post APIs for some kinds of actions in the RP, you may need to
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true
# resourcegroup-append: true
# nested-object-to-string: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  - where:
      verb: Test
    remove: true
  - where:
      subject: NetworkDeviceSku|NetworkFabricSku
      verb: Get
    remove: true
  # Rename cmdlet
  - where:
      verb: Invoke
      subject: DeprovisionNetworkFabric
    set:
      subject: Deprovision
  - where:
      verb: Invoke
      subject: ArmNetworkFabricConfigurationDiff
    set:
      subject: ArmConfigurationDiff
  - where:
      verb: Invoke
      subject: CommitNetworkFabricBatchStatus
    set:
      subject: CommitBatchStatus
  - where:
      verb: Invoke
      subject: CommitNetworkFabricConfiguration
    set:
      subject: CommitConfiguration
  - where:
      verb: Invoke
      subject: ViewNetworkFabricDeviceConfiguration
    set:
      subject: DeviceConfiguration
  # Normalize names for unknown or miscategorized cmdlets
  - where:
      subject: ^NetworkFabric$
      variant: ^Provision$|^ProvisionViaIdentity$
    set:
      subject: NetworkFabricProvision
      verb: Invoke
  - where:
      subject: NetworkDevice
      verb: Update
      variant: ^UpgradeViaJsonString$|^UpgradeViaJsonFilePath$|^UpgradeExpanded$|^Upgrade$|^UpgradeViaIdentityExpanded$|^UpgradeViaIdentity$
    set:
      subject: DeviceUpgrade
      verb: Invoke
  - where:
      verb: Update
      subject: ExternalNetworkAdministrativeState
    set:
      verb: Invoke
  - where:
      verb: Update
      subject: ExternalNetworkBfdAdministrativeState
    set:
      verb: Invoke
  - where:
      verb: Update
      subject: NetworkToNetworkInterconnectBfdAdministrativeState
    set:
      verb: Invoke
      subject: NniBfdAdministrativeState
  - where:
      verb: Update
      subject: NetworkInterfaceAdministrativeState
    set:
      verb: Invoke
  - where:
      verb: Update
      subject: L2IsolationDomainAdministrativeState
    set:
      verb: Invoke
  - where:
      verb: Update
      subject: L3IsolationDomainAdministrativeState
    set:
      verb: Invoke
  - where:
      verb: Update
      subject: NetworkTapAdministrativeState
    set:
      verb: Invoke
  # Renaming cmdlet https://github.com/Azure/autorest.powershell/blob/main/docs/directives.md#Cmdlet-Rename
  - where:
      verb: Get|New|Remove
      subject: AccessControlList
    set:
      subject: Acl
  - where:
      verb: Get|New|Remove
      subject: L2IsolationDomain
    set:
      subject: L2Domain
  - where:
      verb: Invoke
      subject: L2IsolationDomainAdministrativeState
    set:
      subject: L2DomainUpdateAdminState
  - where:
      verb: Get|New|Remove
      subject: L3IsolationDomain
    set:
      subject: L3Domain
  - where:
      verb: Invoke
      subject: L3IsolationDomainAdministrativeState
    set:
      subject: L3DomainUpdateAdminState
  - where:
      verb: Get|Update|Start|Invoke
      subject: NetworkDevice
    set:
      subject: Device
  - where:
      verb: Get|Remove
      subject: NetworkInterface
    set:
      subject: Interface
  - where:
      verb: Invoke
      subject: NetworkInterfaceAdministrativeState
    set:
      subject: InterfaceUpdateAdminState
  - where:
      verb: Get
      subject: NetworkPacketBroker
    set:
      subject: Npb
  - where:
      verb: Get
      subject: NetworkRack
    set:
      subject: Rack
  - where:
      verb: Get|New|Remove
      subject: NetworkTap
    set:
      subject: Tap
  - where:
      verb: Invoke
      subject: NetworkTapAdministrativeState
    set:
      subject: TapUpdateAdminState
  - where:
      verb: Get|New|Remove
      subject: NetworkTapRule
    set:
      subject: TapRule
  - where:
      verb: Get|New|Remove|Invoke
      subject: NetworkToNetworkInterconnect
    set:
      subject: Nni
  # Remove cmdlets for the resources since the explicit operation is not allowed
  - where:
      verb: Get
      subject: NetworkFabricTopology
    remove: true
  - where:
      verb: Update
      subject: NetworkFabricInfraManagementBfdConfiguration
    remove: true
  - where:
      verb: Update
      subject: NetworkFabricWorkloadManagementBfdConfiguration
    remove: true
  - where:
      verb: Update
      subject: NetworkFabricConfiguration
    remove: true
  - where:
      verb: New|Update|Remove
      subject: NetworkRack
    remove: true
  - where:
      verb: New|Remove|Restart
      subject: NetworkDevice
    remove: true
  - where:
      verb: Update
      subject: NetworkDeviceConfiguration
    remove: true
  - where:
      verb: Update
      subject: NetworkToNetworkInterconnect
    remove: true
  - where:
      verb: Update
      subject: NetworkToNetworkInterconnectAdministrativeState
    remove: true
  - where:
      verb: New|Update
      subject: NetworkInterface
    remove: true
  - where:
      verb: Invoke
      subject: CommitL2IsolationDomainConfiguration
    remove: true
  - where:
      verb: Invoke
      subject: CommitL3IsolationDomainConfiguration
    remove: true
  - where:
      verb: Update
      subject: ExternalNetworkAdministrativeState
    remove: true
  - where:
      verb: Update
      subject: InternalNetworkAdministrativeState
    remove: true
  - where:
      verb: Update
      subject: InternalNetworkBfdAdministrativeState
    remove: true
  - where:
      verb: Update
      subject: InternalNetworkBgpAdministrativeState
    remove: true
  - where:
      verb: Update
      subject: AccessControlListAdministrativeState
    remove: true
  - where:
      verb: Update
      subject: Configuration
    remove: true
  - where:
      verb: Invoke
      subject: ResyncAccessControlList
    remove: true
  - where:
      verb: New|Remove
      subject: InternetGateway
    remove: true
  - where:
      verb: Update
      subject: RoutePolicyAdministrativeState
    remove: true
  - where:
      verb: Invoke
      subject: CommitRoutePolicyConfiguration
    remove: true
  - where:
      verb: New|Update|Remove
      subject: NetworkPacketBroker
    remove: true
  - where:
      verb: Invoke
      subject: ResyncNetworkTap
    remove: true
  - where:
      verb: Invoke
      subject: ResyncNetworkTapRule
    remove: true
  - where:
      verb: Update
      subject: NetworkTapRuleAdministrativeState
    remove: true
  - where:
      verb: Remove
      subject: Interface
    remove: true
  - where:
      verb: Get|New|Remove|Update
      subject: NetworkMonitor
    remove: true
  - where:
      verb: Update
      subject: NetworkMonitorAdministrativeState
    remove: true
  - where:
      verb: New
      parameter-name: OptionAPropertiesBfdConfigurationIntervalInMilliSecond
    set:
      parameter-name: optionAPropertyBfdConfigurationInterval
  - where:
      verb: New
      parameter-name: OptionAPropertiesBfdConfigurationMultiplier
    set:
      parameter-name: OptionAPropertyBfdConfigurationMultiplier
  - where:
      verb: New
      parameter-name: StaticRouteConfigurationBfdConfigurationIntervalInMilliSecond
    set:
      parameter-name: StaticRouteConfigurationBfdConfigurationInterval
  - where:
      verb: New
      parameter-name: BfdConfigurationIntervalInMilliSecond
    set:
      parameter-name: BfdConfigurationInterval   
# Handle 200 status code not exist in swagger spec for DELETE API's
  - from: swagger-document
    where: $.paths..delete.responses
    transform: >-
      $["200"] = {
          "description": "Success",
      }

  - no-inline:
    # Neighbor Group
    - NeighborGroupPatchableProperties
    - NeighborGroupDestination
    # InternetGatewayRule
    - RuleProperties
    # Network Fabric
    - TerminalServerConfiguration
    - TerminalServerPatchableProperties
    - Layer3IpPrefixProperties
    # NNI
    - Layer2Configuration
    - NetworkToNetworkInterconnectPropertiesOptionBLayer3Configuration
    - NpbStaticRouteConfiguration
    - ImportRoutePolicyInformation
    - ExportRoutePolicyInformation
    # L3
    - L3IsolationDomainPatchableProperties
    - AggregateRouteConfiguration
    - AggregateRoute
    - ConnectedSubnetRoutePolicy
    - L3ExportRoutePolicy
    # External Network
    - L3OptionBProperties
    - L3OptionAProperties
    - ExternalNetworkPatchableProperties
    - ImportRoutePolicy
    - ExportRoutePolicy
    # Internal Network
    - InternalNetworkPropertiesBgpConfiguration
    - NeighborAddress
    - StaticRouteConfiguration
    - ExtensionEnumProperty
```
