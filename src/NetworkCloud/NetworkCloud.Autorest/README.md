<!-- region Generated -->
# Az.NetworkCloud
This directory contains the PowerShell module for the NetworkCloud service.

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
For information on how to develop for `Az.NetworkCloud`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name : https://github.com/Azure/azure-rest-api-specs/
# the 2025-02-01 stable in a commit: 08973141b0d31a7e75d4dc43a5224a1814a0994f
commit: 08973141b0d31a7e75d4dc43a5224a1814a0994f
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/networkcloud/resource-manager/readme.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/networkcloud/resource-manager/Microsoft.NetworkCloud/stable/2025-02-01/networkcloud.json

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: NetworkCloud
service-name: NetworkCloud
subject-prefix: NetworkCloud

directive:
  # Fix model definition line break replacement issue
  - from: swagger-document
    where: $.definitions.L3NetworkProperties.properties.ipv4ConnectedPrefix
    transform: $['description'] = 'The IPV4 prefix (CIDR) assigned to this L3 network. Required when the IP allocation type is IPV4 or DualStack.'
  - from: swagger-document
    where: $.definitions.L3NetworkProperties.properties.ipv6ConnectedPrefix
    transform: $['description'] = 'The IPV6 prefix (CIDR) assigned to this L3 network. Required when the IP allocation type is IPV6 or DualStack.'
  - from: swagger-document
    where: $.definitions.BareMetalMachinePatchProperties.properties.machineDetails
    transform: $['description'] = 'The details provided by the customer during the creation of rack manifests that allows for custom data to be associated with this machine.'
  - from: swagger-document
    where: $.definitions.ClusterProperties.properties.computeRackDefinitions
    transform: $['description'] = 'The list of rack definitions for the compute racks in a multi-rack cluster, or an empty list in a single-rack cluster.'
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^(Create|Update|Cordon|Deploy|Enable|Replace|Run|PowerOff)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentityExpanded$
    remove: true
  - where:
      subject: KuberneteClusterNode
      variant: ^(Restart)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  # Swagger has location/Azure-AsyncOperation headers defined in 201/202 response which actually leads to the errors while
  # generating the modules using `pwsh build-module.ps1`. The API review board rejected the change to remove it.
  # The directives below removes those headers on the fly when generating the code.
  - from: networkcloud.json
    where: $.paths..responses.202
    transform: delete $.headers
  - from: networkcloud.json
    where: $.paths..responses.201
    transform: delete $.headers
  # All async operations will return 201 or 202, and while polling will return 200 from the GET operation status response. This directive prevents the powershell test framework from erroring out upon receiving that 200.
  - from: networkcloud.json
    where: $.paths..post.responses
    transform: >-
      $["200"] = {
          "description": "OK",
      }
  - from: networkcloud.json
    where: $.paths..delete.responses
    transform: >-
      $["200"] = {
          "description": "OK",
      }
  # This is a known issue related to singularizing. To workaround the issue, please rename the cmdlet by following https://github.com/Azure/autorest.powershell/blob/main/docs/directives.md#Cmdlet-Rename
  - where:
      verb: Get
      subject: CloudServiceNetwork
    set:
      subject: CloudServicesNetwork
  - where:
      verb: New
      subject: CloudServiceNetwork
    set:
      subject: CloudServicesNetwork
  - where:
      verb: Get
      subject: MetricConfiguration
    set:
      subject: MetricsConfiguration
  - where:
      verb: New
      subject: MetricConfiguration
    set:
      subject: MetricsConfiguration
  - where:
      verb: Get
      subject: KuberneteCluster
    set:
      subject: KubernetesCluster
  - where:
      verb: New
      subject: KuberneteCluster
    set:
      subject: KubernetesCluster
  - where:
      verb: Restart
      subject: KuberneteClusterNode
    set:
      subject: KubernetesClusterNode
  - where:
      verb: New
      subject: KuberneteClusterFeature
    set:
      subject: KubernetesClusterFeature
  - where:
      verb: Get
      subject: KuberneteClusterFeature
    set:
      subject: KubernetesClusterFeature
  # Remove New/Remove cmdlets for hydrated resources as the explicit creation and deletion is not allowed
  - where:
      verb: New
      subject: Rack
    remove: true
  - where:
      verb: Remove
      subject: Rack
    remove: true
  - where:
      verb: New
      subject: BareMetalMachine
    remove: true
  - where:
      verb: Remove
      subject: BareMetalMachine
    remove: true
  - where:
      verb: New
      subject: StorageAppliance
    remove: true
  - where:
      verb: Remove
      subject: StorageAppliance
    remove: true
  # Normalize names for unknown or miscategorized cmdlets
  - where:
      subject: ^VirtualMachine$
      variant: ^Reimage$|^ReimageViaIdentity$
    set:
      subject: VirtualMachineReimage
      verb: Invoke
  - where:
      subject: ^BareMetalMachine$
      variant: ^Reimage|^ReimageViaIdentity$
    set:
      subject: BareMetalMachineReimage
      verb: Invoke
  - where:
      subject: ^BareMetalMachine$
      variant: ^Replace|^ReplaceViaIdentity$
    set:
      subject: BareMetalMachineReplace
      verb: Invoke
  - where:
      subject: ^CordonBareMetalMachine$
      variant: ^Cordon|^CordonViaIdentity$
    set:
      subject: BareMetalMachineCordon
      verb: Invoke
  - where:
      subject: ^UncordonBareMetalMachine$
      variant: ^Uncordon|^UncordonViaIdentity$
    set:
      subject: BareMetalMachineUncordon
      verb: Invoke
  - where:
      subject: ^BareMetalMachineCommand$
      variant: ^Run|^RunViaIdentity$
    set:
      subject: BareMetalMachineRunCommand
      verb: Invoke
  - where:
      subject: ^BareMetalMachineReadCommand$
      variant: ^Run|^RunViaIdentity$
    set:
      subject: BareMetalMachineRunReadCommand
      verb: Invoke
  - where:
      subject: ^BareMetalMachineDataExtract
      variant: ^Run|^RunViaIdentity$
    set:
      subject: BareMetalMachineDataExtract
      verb: Invoke
  - where:
      subject: ^ClusterVersion$
      variant: ^Update|^UpdateExpanded$
    set:
      subject: ClusterVersionUpdate
      verb: Invoke
  - where:
      subject: ^ContinueClusterUpdateVersion$
      verb: Invoke
    set:
      subject: ClusterContinueVersionUpdate
      verb: Invoke
  # rename parameter with duplicate or long names to shorted names
  # For. e.g, in cmdlet "New-AzNetworkCloudKubernetesCluster", the parameter "ControlPlaneNodeConfigurationAdministratorConfigurationAdminUsername" is long and
  # and contains duplicate word "Configuration".
  - where:
     parameter-name: ControlPlaneNodeConfigurationAdministratorConfigurationAdminUsername
    set:
      parameter-name: ControlPlaneNodeConfigurationAdminUsername
  - where:
     parameter-name: ControlPlaneNodeConfigurationAdministratorConfigurationSshPublicKey
    set:
      parameter-name: ControlPlaneNodeConfigurationAdminPublicKey
  - where:
      parameter-name: AggregatorOrSingleRackDefinitionBareMetalMachineConfigurationData
    set:
      parameter-name: AggregatorOrSingleRackDefinitionBareMetalMachineConfiguration
  - where:
      parameter-name: AggregatorOrSingleRackDefinitionStorageApplianceConfigurationData
    set:
      parameter-name: AggregatorOrSingleRackDefinitionStorageApplianceConfiguration
  - where:
      parameter-name: BgpServiceLoadBalancerConfigurationBgpAdvertisement
    set:
      parameter-name: BgpAdvertisement
  - where:
      parameter-name: BgpServiceLoadBalancerConfigurationBgpPeer
    set:
      parameter-name: BgpPeer
  - where:
      parameter-name: BgpServiceLoadBalancerConfigurationIPAddressPool
    set:
      parameter-name: BgpIPAddressPool
  - where:
      parameter-name: CommandOutputSettingsAssociatedIdentityType
    set:
      parameter-name: AssociatedIdentityType
      parameter-description: The type of associated identity for CommandOutputSettings.
  - where:
      parameter-name: CommandOutputSettingsAssociatedIdentityUserAssignedIdentityResourceId
    set:
      parameter-name: AssociatedIdentityUserAssignedIdentityResourceId
      parameter-description: The resource ID of the user assigned identity for CommandOutputSettings.
  # property renames
  - where:
      model-name: Cluster
      property-name: CommandOutputSettingsAssociatedIdentityType
    set:
      property-name: AssociatedIdentityType
  - where:
      model-name: Cluster
      property-name: CommandOutputSettingsAssociatedIdentityUserAssignedIdentityResourceId
    set:
      property-name: AssociatedIdentityUserAssignedIdentityResourceId

  # define password parameters as `password` type, which generates it as "SecureString"
  - from: swagger-document
    where: $.definitions.AdministrativeCredentials.properties.password
    transform: $.format = "password"
  - from: swagger-document
    where: $.definitions.ImageRepositoryCredentials.properties.password
    transform: $.format = "password"
  - from: swagger-document
    where: $.definitions.ServicePrincipalInformation.properties.password
    transform: $.format = "password"
  # Fix required property missing mutability
  - from: swagger-document
    where: $.definitions.BgpAdvertisement.properties.ipAddressPools
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document
    where: $.definitions.ControlPlaneNodeConfiguration.properties.vmSkuName
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document
    where: $.definitions.InitialAgentPoolConfiguration.properties.count
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document
    where: $.definitions.InitialAgentPoolConfiguration.properties.mode
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document
    where: $.definitions.InitialAgentPoolConfiguration.properties.vmSkuName
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document
    where: $.definitions.InitialAgentPoolConfiguration.properties.name
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document
    where: $.definitions.IpAddressPool.properties.name
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document
    where: $.definitions.L3NetworkAttachmentConfiguration.properties.networkId
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document
    where: $.definitions.NetworkAttachment.properties.attachedNetworkId
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document
    where: $.definitions.NetworkAttachment.properties.ipAllocationMethod
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document
    where: $.definitions.ServiceLoadBalancerBgpPeer.properties.name
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document
    where: $.definitions.ServiceLoadBalancerBgpPeer.properties.peerAddress
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document
    where: $.definitions.ServiceLoadBalancerBgpPeer.properties.peerAsn
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document
    where: $.definitions.VirtualMachinePlacementHint.properties.hintType
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document
    where: $.definitions.VirtualMachinePlacementHint.properties.schedulingExecution
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document
    where: $.definitions.VirtualMachinePlacementHint.properties.resourceId
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document
    where: $.definitions.VirtualMachinePlacementHint.properties.scope
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  
  # Add model-cmdlet for any properties/sub-properties of complex type
  - model-cmdlet:
    - model-name: BareMetalMachineConfigurationData
    - model-name: BgpAdvertisement
    - model-name: BgpServiceLoadBalancerConfiguration
    - model-name: ControlPlaneNodeConfiguration
    - model-name: EgressEndpoint
    - model-name: EndpointDependency
    - model-name: InitialAgentPoolConfiguration
    - model-name: IpAddressPool
    - model-name: KeySetUser
    - model-name: L3NetworkAttachmentConfiguration
    - model-name: NetworkAttachment
    - model-name: RackDefinition
    - model-name: ServiceLoadBalancerBgpPeer
    - model-name: StorageApplianceConfigurationData
    - model-name: VirtualMachinePlacementHint
```
