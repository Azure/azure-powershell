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

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

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

  #breaking change message
  - where:
      subject: MaintenanceConfiguration
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek]
        deprecated-output-properties:
          - TimeInWeek
        new-output-properties:
          - TimeInWeek
        change-description: The type of property 'TimeInWeek' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IMaintenanceConfiguration' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek]'.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.5.0
        change-effective-date: 2025/05/06
  - where:
      subject: MaintenanceConfiguration
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan]
        deprecated-output-properties:
          - NotAllowedTime
        new-output-properties:
          - NotAllowedTime
        change-description: The type of property 'NotAllowedTime' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IMaintenanceConfiguration' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan]'.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.5.0
        change-effective-date: 2025/05/06
  - where:
      subject: MaintenanceConfiguration
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.Nullable`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.CreatedByType]
        replacement-cmdlet-output-type: System.String
        deprecated-output-properties:
          - SystemDataCreatedByType
          - SystemDataLastModifiedByType
        new-output-properties:
          - SystemDataCreatedByType
          - SystemDataLastModifiedByType
        change-description: The type of property 'SystemDataCreatedByType' and 'SystemDataLastModifiedByType' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IMaintenanceConfiguration' has changed from 'System.Nullable`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.CreatedByType]' to 'System.String'.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.5.0
        change-effective-date: 2025/05/06
  - where:
      subject: MaintenanceConfiguration
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.Int32[]
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[System.Int32]
        deprecated-output-properties:
          - HourSlot
        new-output-properties:
          - HourSlot
        change-description: The type of property 'HourSlot' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.ITimeInWeek' has changed from 'System.Int32[]' to 'System.Collections.Generic.List`1[System.Int32]'.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.5.0
        change-effective-date: 2025/05/06
  - where:
      subject: MaintenanceConfiguration
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.Nullable`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.WeekDay]
        replacement-cmdlet-output-type: System.String
        deprecated-output-properties:
          - Day
        new-output-properties:
          - Day
        change-description: The type of property 'Day' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.ITimeInWeek' has changed from 'System.Nullable`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.WeekDay]' to 'System.String'.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.5.0
        change-effective-date: 2025/05/06

  - where:
      subject: ManagedClusterOSOption
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOSOptionProperty
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOSOptionProperty]
        deprecated-output-properties:
          - OSOptionPropertyList
        new-output-properties:
          - OSOptionPropertyList
        change-description: The type of property 'OSOptionPropertyList' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IOSOptionProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOSOptionProperty' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOSOptionProperty]'.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.5.0
        change-effective-date: 2025/05/06

  - where:
      subject: ManagedClusterOutboundNetworkDependencyEndpoint
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IEndpointDependency
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IEndpointDependency]
        deprecated-output-properties:
          - Endpoint
        new-output-properties:
          - Endpoint
        change-description: The type of property 'Endpoint' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IOutboundEnvironmentEndpoint' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IEndpointDependency' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IEndpointDependency]'.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.5.0
        change-effective-date: 2025/05/06

  - where:
      subject: NodePoolUpgradeProfile
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAgentPoolUpgradeProfilePropertiesUpgradesItem
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAgentPoolUpgradeProfilePropertiesUpgradesItem]
        deprecated-output-properties:
          - Upgrade
        new-output-properties:
          - Upgrade
        change-description: The type of property 'Upgrade' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IAgentPoolUpgradeProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAgentPoolUpgradeProfilePropertiesUpgradesItem' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAgentPoolUpgradeProfilePropertiesUpgradesItem]'.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.5.0
        change-effective-date: 2025/05/06
  - where:
      subject: NodePoolUpgradeProfile
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType
        replacement-cmdlet-output-type: System.String
        deprecated-output-properties:
          - OSType
        new-output-properties:
          - OSType
        change-description: The type of property 'OSType' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IAgentPoolUpgradeProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType' to 'System.String'.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.5.0
        change-effective-date: 2025/05/06

  - where:
      subject: Snapshot
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.Nullable`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Ossku]
        replacement-cmdlet-output-type: System.String
        deprecated-output-properties:
          - OSSku
        new-output-properties:
          - OSSku
        change-description: The type of property 'OSSku' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.ISnapshot' has changed from 'System.Nullable`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Ossku]' to 'System.String'.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.5.0
        change-effective-date: 2025/05/06
  - where:
      subject: Snapshot
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.Nullable`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType]
        replacement-cmdlet-output-type: System.String
        deprecated-output-properties:
          - OSType
        new-output-properties:
          - OSType
        change-description: The type of property 'OSType' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.ISnapshot' has changed from 'System.Nullable`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType]' to 'System.String'.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.5.0
        change-effective-date: 2025/05/06
  - where:
      verb: Get
      subject: Snapshot
    set:
      breaking-change:
        deprecated-cmdlet-output-type: System.Nullable`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.SnapshotType]
        replacement-cmdlet-output-type: System.String
        deprecated-output-properties:
          - SnapshotType
        new-output-properties:
          - SnapshotType
        change-description: The type of property 'SnapshotType' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.ISnapshot' has changed from 'System.Nullable`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.SnapshotType]' to 'System.String'.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.5.0
        change-effective-date: 2025/05/06
  - where:
      verb: New
      subject: Snapshot
      parameter-name: SnapshotType
    set:
      breaking-change:
        change-description: The cmdlet 'New-AzAksSnapshot' no longer supports the type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.SnapshotType' for parameter 'SnapshotType'.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.5.0
        change-effective-date: 2025/05/06

  - where:
      subject: UpgradeProfile
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfile
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfile]
        deprecated-output-properties:
          - AgentPoolProfile
        new-output-properties:
          - AgentPoolProfile
        change-description: The type of property 'AgentPoolProfile' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IManagedClusterUpgradeProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfile' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfile]'.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.5.0
        change-effective-date: 2025/05/06
  - where:
      subject: UpgradeProfile
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfileUpgradesItem
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfileUpgradesItem]
        deprecated-output-properties:
          - ControlPlaneProfileUpgrade
        new-output-properties:
          - ControlPlaneProfileUpgrade
        change-description: The type of property 'ControlPlaneProfileUpgrade' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IManagedClusterUpgradeProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfileUpgradesItem' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfileUpgradesItem]'.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.5.0
        change-effective-date: 2025/05/06
  - where:
      subject: UpgradeProfile
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType
        replacement-cmdlet-output-type: System.String
        deprecated-output-properties:
          - ControlPlaneProfileOSType
        new-output-properties:
          - ControlPlaneProfileOSType
        change-description: The type of property 'ControlPlaneProfileOSType' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IManagedClusterUpgradeProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType' to 'System.String'.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.5.0
        change-effective-date: 2025/05/06

  - where:
      subject: ContainerServiceOrchestrator
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOrchestratorVersionProfile
        replacement-cmdlet-output-type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOrchestratorVersionProfile]
        deprecated-output-properties:
          - Orchestrator
        new-output-properties:
          - Orchestrator
        change-description: The type of property 'Orchestrator' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResult' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOrchestratorVersionProfile' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOrchestratorVersionProfile]'.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.5.0
        change-effective-date: 2025/05/06

  - where:
      subject: TimeInWeek
      parameter-name: HourSlot
    set:
      breaking-change:
        change-description: The type of property 'HourSlot' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.TimeInWeek' has changed from 'System.Int32[]' to 'System.Collections.Generic.List`1[System.Int32]'.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.5.0
        change-effective-date: 2025/05/06
  - where:
      subject: TimeInWeek
      parameter-name: Day
    set:
      breaking-change:
        change-description: The type of property 'Day' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.TimeInWeek' has changed from 'System.Nullable`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.WeekDay]' to 'System.String'.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.5.0
        change-effective-date: 2025/05/06

  - where:
      verb: Start
      subject: ManagedClusterCommand
      parameter-name: __AllParameterSets
    set:
      breaking-change:
        change-description: The parameter set '__AllParameterSets' for cmdlet 'Start-AzAksManagedClusterCommand' has been removed.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.5.0
        change-effective-date: 2025/05/06
```
