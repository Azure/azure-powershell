<!-- region Generated -->
# Az.Aks
This directory contains the PowerShell module for the Aks service.

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
For information on how to develop for `Az.Aks`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 6031674c73a95ffd60f58b5cdd633c94b3360467
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
  - where:  
      subject: ^MaintenanceConfiguration$
      verb: Update
    remove: true
# this API (Update SnapshotTag) is defined in swagger but not supported by RP
  - where:  
      subject: ^SnapshotTag$
      verb: Update
    remove: true
  - model-cmdlet:
      - model-name: TimeSpan
        cmdlet-name: New-AzAksTimeSpanObject
      - model-name: TimeInWeek
        cmdlet-name: New-AzAksTimeInWeekObject
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

  #breaking change message
  - where:
      verb: Get|New
      subject: MaintenanceConfiguration
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IMaintenanceConfiguration
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IMaintenanceConfiguration
        deprecated-output-properties:
          - TimeInWeek Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek
          - NotAllowedTime Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan
        new-output-properties:
          - TimeInWeek System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek]
          - NotAllowedTime System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan]
        change-description: 
          - The type of property 'TimeInWeek' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IMaintenanceConfiguration' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek[]' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek]'
          - The type of property 'NotAllowedTime' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IMaintenanceConfiguration' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan]'
        deprecated-by-version: 7.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/05/19

  - where:
      verb: Get
      subject: ManagedClusterOSOption
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IOSOptionProfile
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOSOptionProfile
        deprecated-output-properties:
          - OSOptionPropertyList Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOSOptionProperty
        new-output-properties:
          - OSOptionPropertyList System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOSOptionProperty]
        change-description: 
          - The type of property 'OSOptionPropertyList' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IOSOptionProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOSOptionProperty' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOSOptionProperty]'.
        deprecated-by-version: 7.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/05/19

  - where:
      verb: Get
      subject: ManagedClusterOutboundNetworkDependencyEndpoint
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IOutboundEnvironmentEndpoint
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOutboundEnvironmentEndpoint
        deprecated-output-properties:
          - Endpoint Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IEndpointDependency
        new-output-properties:
          - Endpoint System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IEndpointDependency]
        change-description: 
          - The type of property 'Endpoint' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IOutboundEnvironmentEndpoint' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IEndpointDependency' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IEndpointDependency]'.
        deprecated-by-version: 7.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/05/19

  - where:
      verb: Get
      subject: NodePoolUpgradeProfile
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IAgentPoolUpgradeProfile
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAgentPoolUpgradeProfile
        deprecated-output-properties:
          - Upgrade Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAgentPoolUpgradeProfilePropertiesUpgradesItem
        new-output-properties:
          - Upgrade System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAgentPoolUpgradeProfilePropertiesUpgradesItem]
        change-description: 
          - The type of property 'Upgrade' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IAgentPoolUpgradeProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAgentPoolUpgradeProfilePropertiesUpgradesItem' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAgentPoolUpgradeProfilePropertiesUpgradesItem]'.
        deprecated-by-version: 7.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/05/19

  - where:
      verb: Get
      subject: UpgradeProfile
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IManagedClusterUpgradeProfile
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterUpgradeProfile
        deprecated-output-properties:
          - AgentPoolProfile Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfile
          - ControlPlaneProfileUpgrade Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfileUpgradesItem
        new-output-properties:
          - AgentPoolProfile System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfile]
          - ControlPlaneProfileUpgrade System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfileUpgradesItem]
        change-description: 
          - The type of property 'AgentPoolProfile' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IManagedClusterUpgradeProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfile' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfile]'.
          - The type of property 'ControlPlaneProfileUpgrade' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IManagedClusterUpgradeProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfileUpgradesItem' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfileUpgradesItem]'.
        deprecated-by-version: 7.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/05/19
```
