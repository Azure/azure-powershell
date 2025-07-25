<!-- region Generated -->
# Az.ArcGateway
This directory contains the PowerShell module for the ArcGateway service.

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
For information on how to develop for `Az.ArcGateway`, see [how-to.md](how-to.md).
<!-- endregion -->

 
<!-- region Generated -->
# Az.ArcGateway
This directory contains the PowerShell module for Hybrid Compute.
 
---
## Run Generation
In this directory, run AutoRest:
> `autorest`
 
---
### AutoRest Configuration
> see https://aka.ms/autorest
 
``` yaml
commit: a9980ec5181a161dd26c5277f7651722b60503ea
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/hybridcompute/resource-manager/Microsoft.HybridCompute/preview/2024-07-31-preview/HybridCompute.json
  - $(repo)/specification/hybridcompute/resource-manager/Microsoft.HybridCompute/preview/2024-07-31-preview/privateLinkScopes.json
 
module-version: 0.1.0
title: ArcGateway
subject-prefix: 'Arc'
# because autorest.powershell is unable to transform IdentityType as the best practice design if it uses managed identity
# we hide the original cmdlet and custom it under /custom folder
disable-transform-identity-type-for-operation:
  - Machines_Update

directive:
  # Removing all cmlets except gateway/settings related cmdlets
  - where:
      subject: PrivateEndpointConnection
    remove: true
  - where:
      subject: PrivateLinkResource
    remove: true
  - where:
      verb: Get
      subject: PrivateLinkScopeValidationDetail
    remove: true
  - where:
      subject: NetworkProfile
    remove: true
  - where:
      subject: AgentVersion
    remove: true
  - where:
      subject: HybridIdentityMetadata
    remove: true
  - where:
      subject: MachineRunCommand
      verb: Set
    remove: true
  - where:
      subject: LicenseProfile
    remove: true
  - where:
      subject: Extension
    remove: true
  - where:
      subject: License
    remove: true
  - where:
      subject: NetworkConfiguration
    remove: true
  - where:
      subject: ExtensionMetadata
    remove: true
  - where:
      subject: Machine
    remove: true
  - where:
      subject: MachineExtension
    remove: true
  - where:
      subject: MachineRunCommand
    remove: true
  - where:
      subject: NetworkSecurityPerimeterConfiguration
    remove: true
  - where:
      subject: Operation
    remove: true
  - where:
      subject: PrivateLinkScope
    remove: true
  - where:
      subject: MachinePatch
    remove: true
  - where:
      subject: AssessMachinePatch
    remove: true
  - where:
      subject: ReconcileNetworkSecurityPerimeterConfiguration
    remove: true
  - where:
      subject: PrivateLinkScopeTag
    remove: true
  - where:
      subject: Gateway
      verb: Set
    remove: true
  - where:
      subject: Gateway
      verb: Update
    remove: true
  - where:
      subject: Setting
      verb: Get
    remove: true
  # Remove PUT and keep Update-AzArcSetting (PATCH)
  - where:
      subject: Setting
      verb: Set
    remove: true

  # Rename parameter names in Update-AzArcSetting
  - where:
      subject: Setting
      parameter-name: GatewayPropertyGatewayResourceId
    set:
      parameter-name: GatewayResourceId

  # Hide cmdlet for customization
  - where:
      subject: Gateway
      verb: New
    hide: true
  - where:
      subject: Setting
      verb: Update
    hide: true

```
