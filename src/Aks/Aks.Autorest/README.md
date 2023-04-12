<!-- region Generated -->
# Az.Aks
This directory contains the PowerShell module for the Aks service.

---
## Status
[![Az.Aks](https://img.shields.io/powershellgallery/v/Az.Aks.svg?style=flat-square&label=Az.Aks "Az.Aks")](https://www.powershellgallery.com/packages/Az.Aks/)

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
For information on how to develop for `Az.Aks`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 6031674c73a95ffd60f58b5cdd633c94b3360467
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/containerservice/resource-manager/Microsoft.ContainerService/aks/stable/2023-02-01/managedClusters.json
  - $(repo)/specification/containerservice/resource-manager/Microsoft.ContainerService/aks/stable/2019-08-01/location.json

title: Aks
module-version: 0.1.0
subject-prefix: $(service-name)
identity-correction-for-post: true

directive:
  - where:
      subject: ^AgentPool$|^AgentPoolAvailableAgentPoolVersion$|^ManagedClusterAccessProfile$|^ManagedClusterAdminCredentials$|^ManagedClusterMonitoringUserCredentials$|^ManagedClusterUserCredentials$|^PrivateEndpointConnection$|^PrivateLinkResource$|^ResolvePrivateLinkServiceId$|^RotateManagedClusterCertificate$|^ManagedClusterAadProfile$|^ManagedClusterServicePrincipalProfile$|^AgentPoolNodeImageVersion$|^ManagedClusterTag$
    remove: true
  - where:
      subject: ^ManagedCluster$
      verb: Get|New|Set|Remove
    remove: true
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^Run$|^RunViaIdentity$
      subject: ^MaintenanceConfiguration$|^Snapshot$|^ManagedClusterCommand$|^SnapshotTag$
    remove: true
  - where:  
      subject: ^MaintenanceConfiguration$|^Snapshot$
      verb: Set
    remove: true
# this API (Update SnapshotTag) is defined in swagger but not supported by RP
  - where:  
      subject: ^SnapshotTag$
      verb: Update
    remove: true
  - model-cmdlet:
    - TimeSpan
    - TimeInWeek
  - where:
      subject: ^ManagedCluster$
      parameter-name: ResourceName
    set:
      parameter-name: Name
      alias: ClusterName
  - where:
      subject: ManagedCluster
    set:
      subject: Cluster
  - where:
      subject: AgentPoolUpgradeProfile
    set:
      subject: NodePoolUpgradeProfile
  - where:
      subject: NodePoolUpgradeProfile
      parameter-name: ResourceName
    set:
      parameter-name: ClusterName
  - where:
      subject: NodePoolUpgradeProfile
      parameter-name: AgentPoolName
    set:
      parameter-name: NodePoolName
      alias: AgentPoolName
  - where:
      subject: ManagedClusterUpgradeProfile
      verb: Get
    set:
      subject: UpgradeProfile
      alias: Get-AzAksClusterUpgradeProfile
  - where:
      subject: UpgradeProfile
      parameter-name: ResourceName
    set:
      parameter-name: ClusterName
      alias: Name
  - from: swagger-document
    where: $.definitions.ContainerServiceMasterProfile.properties.count
    transform: >-
      return {
          "type": "integer",
          "format": "int32",
          "enum": [
            1,
            3,
            5
          ],
          "description": "Number of masters (VMs) in the container service cluster. Allowed values are 1, 3, and 5. The default value is 1.",
          "default": 1
        }
  - where:
      subject: ContainerServiceOrchestrator
    hide: true
```
