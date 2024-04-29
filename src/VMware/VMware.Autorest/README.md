<!-- region Generated -->
# Az.VMware
This directory contains the PowerShell module for the VMware service.

---
## Status
[![Az.VMware](https://img.shields.io/powershellgallery/v/Az.VMware.svg?style=flat-square&label=Az.VMware "Az.VMware")](https://www.powershellgallery.com/packages/Az.VMware/)

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
For information on how to develop for `Az.VMware`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@beta`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 0baf811c3c76c87b3c127d098519bd97141222dd
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/vmware/resource-manager/Microsoft.AVS/stable/2023-03-01/vmware.json

module-version: 0.4.0
title: VMware
subject-prefix: $(service-name)
disable-transform-identity-type: true
flatten-userassignedidentity: false

support-json-input: false

directive:
  - from: swagger-document
    where: $.definitions.AdminCredentials.properties.nsxtPassword
    transform: >-
      return {
          "description": "NSX-T Manager password",
          "type": "string",
          "readOnly": true,
          "x-ms-secret": true,
          "format": "password"
      }
  - from: swagger-document
    where: $.definitions.AdminCredentials.properties.vcenterPassword
    transform: >-
      return {
          "description": "vCenter admin password",
          "type": "string",
          "readOnly": true,
          "x-ms-secret": true,
          "format": "password"
      }
  - where:
      variant: ^(Create|Update)(?!.*?Expanded)
    remove: true
  - where:
      variant: ^Restrict$|^RestrictViaIdentity$
    remove: true
  - where:
      verb: Set
    remove: true
  - where:
      verb: Get|New|Remove
      subject: Addon
    hide: true
  - where:
      verb: New|Remove
      subject: PrivateCloud
    hide: true
  - where:
      verb: Get
      subject: ScriptCmdlet|ScriptExecutionLog|ScriptPackage|WorkloadNetworkGateway|WorkloadNetworkVirtualMachine
    hide: true
  - where:
      verb: Get|New|Remove
      subject: ScriptExecution|WorkloadNetworkPublicIP
    hide: true
  - where:
      verb: Lock
      subject: VirtualMachineMovement
    hide: true
  - where:
      verb: Get|New|Update|Remove
      subject: WorkloadNetworkDhcp|WorkloadNetworkDnsService|WorkloadNetworkDnsZone|WorkloadNetworkPortMirroring|WorkloadNetworkSegment|WorkloadNetworkVMGroup
    hide: true
  - where:
      verb: New|Get|Remove
      subject: HcxEnterpriseSite
    remove: true
  - where:
      verb: Test
      subject: ^LocationQuotaAvailability$
      variant: ^CheckViaIdentity$
    remove: true
  # Remove v4 variant
  - where:
      verb: Test
      subject: ^LocationTrialAvailability$
      variant: ^Check$|CheckViaIdentity
    remove: true
  - where:
      verb: New
      subject: PrivateCloud
      variant: CreateViaIdentityExpanded
    remove: true
  # custom set SKU Name optional
  # - where:
  #     verb: Test
  #     subject: ^LocationTrialAvailability$
  #   hide: true
  # Remove the list variant as the workloadNetwork only have one enum value
  - where:
      verb: Get
      subject: WorkloadNetwork
  #   variant: List
    hide: true
  # Hide parent object variant to fix 'multiple types define RestrictMovement [string, IVirtualMachineRestrictMovement]'
  - where:
      verb: Lock
      subject: VirtualMachineMovement
      variant: ^RestrictViaIdentityCluster$|^RestrictViaIdentityPrivateCloud$
    remove: true
  # Hide HcxEnterpriseSite, ScriptExecution, Addon update
  - where:
      verb: Update
      subject: HcxEnterpriseSite|ScriptExecution|Addon
    remove: true
  - no-inline:
      - AddonProperties
      - PlacementPolicyProperties
  - model-cmdlet:
    - model-name: IdentitySource
  # Re-name and custom it
  # - model-cmdlet:
  #     - VMPlacementPolicyProperties
  #     - VmHostPlacementPolicyProperties
  #     - ScriptSecureStringExecutionParameter
  #     - ScriptStringExecutionParameter
  #     - PSCredentialExecutionParameter
  #     - AddonSrmProperties
  #     - AddonVrProperties
  - where:
      verb: Get
      subject: ^PrivateCloudAdminCredentials$
    set:
      subject: PrivateCloudAdminCredential
  - where:
      verb: Invoke
      subject: ^RotatePrivateCloudNsxtPassword$
    set:
      verb: New
      subject: PrivateCloudNsxtPassword
  - where:
      verb: Invoke
      subject: ^RotatePrivateCloudVcenterPassword$
    set:
      verb: New
      subject: PrivateCloudVcenterPassword
  - where:
      verb: Get
      subject: ^WorkloadNetworkVirtualMachine$
    set:
      subject: WorkloadNetworkVM
  - where:
      verb: New|Get|Update|Remove
      subject: ^WorkloadNetworkDhcp$
      parameter-name: DhcpId
    set:
      parameter-name: DhcpName
  - where:
      verb: New|Get|Update|Remove
      subject: ^WorkloadNetworkDnsService$
      parameter-name: DnsServiceId
    set:
      parameter-name: DnsServiceName
  - where:
      subject: ^Cluster$
      parameter-name: PropertiesHosts
    set:
      parameter-name: PropertiesHost
  - where:
      verb: New|Get|Update|Remove
      subject: ^WorkloadNetworkDnsZone$
      parameter-name: DnsZoneId
    set:
      parameter-name: DnsZoneName
  - where:
      verb: Get
      subject: ^WorkloadNetworkGateway$
      parameter-name: GatewayId
    set:
      parameter-name: GatewayName
  - where:
      verb: New|Get|Update|Remove
      subject: ^WorkloadNetworkPortMirroring$
      parameter-name: PortMirroringId
    set:
      parameter-name: PortMirroringName
  - where:
      verb: New|Get|Remove
      subject: ^WorkloadNetworkPublicIP$
      parameter-name: PublicIPId
    set:
      parameter-name: PublicIPName
  - where:
      verb: New|Get|Update|Remove
      subject: ^WorkloadNetworkSegment$
      parameter-name: SegmentId
    set:
      parameter-name: SegmentName
  - where:
      verb: New|Get|Update|Remove
      subject: ^WorkloadNetworkVMGroup$
      parameter-name: VMGroupId
    set:
      parameter-name: VMGroupName
  - where:
      verb: New
      subject: ^GlobalReachConnection$
      parameter-name: PeerExpressRouteCircuit
    set:
      parameter-name: PeerExpressRouteResourceId
  - where:
      model-name: Datastore
    set:
      format-table:
        properties:
          - Name
          - Status
          - ProvisioningState
          - ResourceGroupName
```
