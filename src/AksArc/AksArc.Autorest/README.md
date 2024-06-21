<!-- region Generated -->
# Az.AksArc
This directory contains the PowerShell module for the AksArc service.

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
For information on how to develop for `Az.AksArc`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: 3940cd77b8d74b58d4a8b3a80388ff890052be67
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/hybridaks/resource-manager/readme.md
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-local-readme.md

try-require: 
  - $(repo)/specification/hybridaks/resource-manager/readme.powershell.md

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: AksArc
subject-prefix: $(service-name)

# The next three configurations are exclusive to v3, and in v4, they are activated by default. If you are still using v3, please uncomment them.
# identity-correction-for-post: true
# resourcegroup-append: true
# nested-object-to-string: true

directive:
  # Following are common directives which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required
  # Following two directives are v4 specific
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity.*$
    remove: true
  # Follow directive is v3 specific. If you are using v3, uncomment following directive and comments out two directives above
  #- where:
  #    variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
  #  remove: true

  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true

# Fix Operation ID's
  - from: swagger-document
    where: $.paths["/{customLocationResourceUri}/providers/Microsoft.HybridContainerService/skus/default"].get
    transform: >-
      $["operationId"] = "VMSkus_Get"
  - from: swagger-document
    where: $.paths["/{customLocationResourceUri}/providers/Microsoft.HybridContainerService/skus/default"].put
    transform: >-
      $["operationId"] = "VMSkus_Create"
  - from: swagger-document
    where: $.paths["/{customLocationResourceUri}/providers/Microsoft.HybridContainerService/kubernetesVersions/default"].get
    transform: >-
      $["operationId"] = "KubernetesVersions_Get"
  - from: swagger-document
    where: $.paths["/{customLocationResourceUri}/providers/Microsoft.HybridContainerService/kubernetesVersions/default"].put
    transform: >-
      $["operationId"] = "KubernetesVersions_Create"

# Rename Subjects
  - where:
      subject: AgentPool
    set:
      subject: Nodepool
    hide: true

  - where:
      subject: ProvisionedClusterInstance
    set:
      subject: Cluster
    hide: true

  - where:
      verb: New
      subject: VirtualNetwork
    hide: true

  - where:
      subject: ProvisionedClusterInstanceUpgradeProfile
    set:
      subject: ClusterUpgrade
    hide: true

  - where:
      subject: ProvisionedClusterInstanceAdminKubeconfig
    set:
      subject: ClusterAdminKubeconfig
    hide: true

  - where:
      subject: ProvisionedClusterInstanceUserKubeconfig
    set:
      subject: ClusterUserKubeconfig
    hide: true

  - where:
      subject: KubernetesVersion
    hide: true

  - where:
      subject: VMSku
    hide: true

# Remove unnecessary cmdlets
  - where:
      subject: KuberneteVersion
    remove: true

  - where:
      verb: Remove
      subject: VMSku
    remove: true

  - where:
      verb: Update
      subject: VirtualNetwork
    remove: true

  - where:
      subject: HybridIdentityMetadata
    remove: true

  - where:
      verb: Update
      subject: VMSku
    remove: true

  - where:
      verb: Update
      subject: KubernetesVersion
    remove: true

# Rename parameters
  - where:
      subject: VirtualNetwork
      parameter-name: ExtendedLocationName
    set: 
      parameter-name: CustomLocationID
  
  - where:
      subject: VirtualNetwork
      parameter-name: ExtendedLocationName
    set: 
      parameter-name: CustomLocationID

# Clusters
  - where: 
      parameter-name: ControlPlaneEndpointHostIP
    set: 
      parameter-name: ControlPlaneIP

  - where: 
      parameter-name: NetworkProfilePodCidr
    set: 
      parameter-name: PodCidr

  - where: 
      parameter-name: LoadBalancerProfileCount
    set: 
      parameter-name: LoadBalancerCount

  - where: 
      parameter-name: ClusterVMAccessProfileAuthorizedIprange
    set: 
      parameter-name: SshAuthIp
  
# Networks
  - where: 
      parameter-name: HciMocGroup
    set: 
      parameter-name: MocGroup

  - where: 
      parameter-name: HciMocLocation
    set: 
      parameter-name: MocLocation

  - where: 
      parameter-name: HciMocVnetName
    set: 
      parameter-name: MocVnetName

# VM SKU / Kubernetes Version
  - where:
      verb: New
      subject: VMSku
    hide: true

  - where:
      verb: New
      subject: KubernetesVersion
    hide: true
