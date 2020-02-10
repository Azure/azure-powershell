<!-- region Generated -->
# Azs.Fabric.Admin
This directory contains the PowerShell module for the FabricAdmin service.

---
## Status
[![Azs.Fabric.Admin](https://img.shields.io/powershellgallery/v/Azs.Fabric.Admin.svg?style=flat-square&label=Azs.Fabric.Admin "Azs.Fabric.Admin")](https://www.powershellgallery.com/packages/Azs.Fabric.Admin/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.6.0 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Azs.Fabric.Admin`, see [how-to.md](how-to.md).
<!-- endregion -->

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
require:
  - $(this-folder)/../readme.azurestack.md
  - $(repo)/specification/azsadmin/resource-manager/fabric/readme.md

input-file:
  - $(repo)/specification/azsadmin/resource-manager/fabric/Microsoft.Fabric.Admin/preview/2016-05-01/EdgeGateway.json
  - $(repo)/specification/azsadmin/resource-manager/fabric/Microsoft.Fabric.Admin/preview/2016-05-01/EdgeGatewayPool.json
  - $(repo)/specification/azsadmin/resource-manager/fabric/Microsoft.Fabric.Admin/preview/2016-05-01/Fabric.json
  - $(repo)/specification/azsadmin/resource-manager/fabric/Microsoft.Fabric.Admin/preview/2016-05-01/FabricLocation.json
  - $(repo)/specification/azsadmin/resource-manager/fabric/Microsoft.Fabric.Admin/preview/2016-05-01/InfraRole.json
  - $(repo)/specification/azsadmin/resource-manager/fabric/Microsoft.Fabric.Admin/preview/2016-05-01/InfraRoleInstance.json
  - $(repo)/specification/azsadmin/resource-manager/fabric/Microsoft.Fabric.Admin/preview/2016-05-01/IpPool.json
  - $(repo)/specification/azsadmin/resource-manager/fabric/Microsoft.Fabric.Admin/preview/2016-05-01/LogicalNetwork.json
  - $(repo)/specification/azsadmin/resource-manager/fabric/Microsoft.Fabric.Admin/preview/2016-05-01/LogicalSubnet.json
  - $(repo)/specification/azsadmin/resource-manager/fabric/Microsoft.Fabric.Admin/preview/2016-05-01/MacAddressPool.json
  - $(repo)/specification/azsadmin/resource-manager/fabric/Microsoft.Fabric.Admin/preview/2016-05-01/NetworkOperationResults.json
  - $(repo)/specification/azsadmin/resource-manager/fabric/Microsoft.Fabric.Admin/preview/2016-05-01/ScaleUnit.json
  - $(repo)/specification/azsadmin/resource-manager/fabric/Microsoft.Fabric.Admin/preview/2016-05-01/ScaleUnitNode.json
  - $(repo)/specification/azsadmin/resource-manager/fabric/Microsoft.Fabric.Admin/preview/2016-05-01/SlbMuxInstance.json
  - $(repo)/specification/azsadmin/resource-manager/fabric/Microsoft.Fabric.Admin/preview/2016-05-01/StorageOperationResults.json
  - $(repo)/specification/azsadmin/resource-manager/fabric/Microsoft.Fabric.Admin/preview/2016-05-01/StoragePool.json
  - $(repo)/specification/azsadmin/resource-manager/fabric/Microsoft.Fabric.Admin/preview/2016-05-01/StorageSystem.json
  - $(repo)/specification/azsadmin/resource-manager/fabric/Microsoft.Fabric.Admin/preview/2016-05-01/FileShare.json
  - $(repo)/specification/azsadmin/resource-manager/fabric/Microsoft.Fabric.Admin/preview/2018-10-01/StorageSubSystem.json
  - $(repo)/specification/azsadmin/resource-manager/fabric/Microsoft.Fabric.Admin/preview/2019-05-01/Drive.json
  - $(repo)/specification/azsadmin/resource-manager/fabric/Microsoft.Fabric.Admin/preview/2019-05-01/Volume.json
```

### File Renames 
``` yaml
module-name: Azs.Fabric.Admin 
csproj: Azs.Fabric.Admin.csproj 
psd1: Azs.Fabric.Admin.psd1 
psm1: Azs.Fabric.Admin.psm1
```

### Parameter default values
``` yaml
directive:
  - where:
      parameter-name: ResourceGroupName
    set:
      default:
        script: -join("System.",(Get-AzLocation)[0].Location)

  # [EdgeGateway]: Following changes are for EdgeGateway
  # [EdgeGateway] Propertity Rename: change NumberOfConnection to NumberOfConnections
  - where:
      model-name: EdgeGateway
      property-name: NumberOfConnection
    set:
      property-name: NumberOfConnections

  # [EdgeGateway] Rename cmdlet parameter name in EdgeGateway
  - where:
      subject: EdgeGateway
      parameter-name: EdgeGateway
    set:
      parameter-name: Name

  # [EdgeGateway] hide autorest generated cmdlet to use the custom one
  - where:
      verb: Get
      subject: EdgeGateway
    hide: true

  # [LogicalNetwork]: Following changes are for LogicalNetwork
  # [LogicalNetwork] Rename property name in LogicalNetwork
  - where:
      model-name: LogicalNetwork
      property-name: Subnet
    set:
      property-name: Subnets

  # [LogicalNetwork] Rename cmdlet parameter name in LogicalNetwork
  - where:
      subject: LogicalNetwork
      parameter-name: LogicalNetwork
    set:
      parameter-name: Name

  # [LogicalNetwork] hide autorest generated cmdlet to use the custom one
  - where:
      verb: Get
      subject: LogicalNetwork
    hide: true

  # [EdgeGatewayPool]: Following changes are for EdgeGatewayPool
  # [EdgeGateway] Rename cmdlet parameter name in EdgeGatewayPool
  - where:
      subject: EdgeGatewayPool
      parameter-name: EdgeGatewayPool
    set:
      parameter-name: Name

  # [EdgeGatewayPool]: Rename property name NumberOfGateway to NumberOfGateways
  - where:
      model-name: EdgeGatewayPool
      property-name: NumberOfGateway
    set:
      property-name: NumberOfGateways

  # [EdgeGatewayPool] hide autorest generated cmdlet to use the custom one
  - where:
      verb: Get
      subject: EdgeGatewayPool
    hide: true

  # [InfrastructureRole]: Following changes are for InfrastructureRole
  # Rename subject AzsInfraRole to AzsInfrastructureRole
  - where:
      subject: InfraRole
    set:
      subject: InfrastructureRole

  # [InfrastructureRole]: Rename property name Instance to Instances
  - where:
      model-name: InfraRole
      property-name: Instance
    set:
      property-name: Instances

  # [InfrastructureRole] Rename cmdlet parameter name in EdgeGatewayPool
  - where:
      subject: InfrastructureRole
      parameter-name: InfraRole
    set:
      parameter-name: Name

  # [InfrastructureRole] hide autorest generated cmdlet to use the custom one
  - where:
      verb: Get
      subject: InfrastructureRole
    hide: true

  # [IPPool]: Following changes are for IpPool
  # [IPPool]: Rename property name
  - where:
      model-name: IPPool
      property-name: NumberOfAllocatedIPAddress
    set:
      property-name: NumberOfAllocatedIPAddresses

  - where:
      model-name: IPPool
      property-name: NumberOfIPAddress
    set:
      property-name: NumberOfIPAddresses

  # [IPPool] Rename cmdlet parameter name in IPPool
  - where:
      subject: IPPool
      parameter-name: IPPool
    set:
      parameter-name: Name

  # [IPPool] Hide the auto-generated Set-AzsIPPool and expose it through customized one
  - where:
      verb: Set
      subject: IPPool
    hide: true

  # [IPPool] Hide the auto-generated Get-AzsIPPool and expose it through customized one
  - where:
      verb: Get
      subject: IPPool
    hide: true

  # [ScaleUnit]: Following changes are for ScaleUnit
  # [ScaleUnit] Cmdlet parameter rename
  - where:
      subject: ScaleUnit
      parameter-name: ScaleUnit
    set:
      parameter-name: Name

  # [ScaleUnit] Hide auto-generated
  - where:
      verb: Get
      subject: ScaleUnit
    hide: true

  # [ScaleUnitNode]: Following changes are for ScaleUnitNode
  # [ScaleUnitNode] Cmdlet parameter rename
  - where:
      subject: ScaleUnitNode
      parameter-name: ScaleUnitNode
    set:
      parameter-name: Name

  # [ScaleUnitNode] Hide auto-generated
  - where:
      verb: Get
      subject: ScaleUnitNode
    hide: true

  # [ScaleUnitNode]: Rename property name
  - where:
      model-name: ScaleUnitNode
      property-name: Status
    set:
      property-name: ScaleUnitNodeStatus

  # [ScaleUnitNode] Rename Invoke-ScaleUnitOut to Add-AzsScaleUnitNode
  - where:
      verb: Invoke
      subject: ScaleUnitOut
    set:
      verb: Add
      subject: ScaleUnitNode

  # Rename Start-AzsScaleUnitNodeMaintenanceMode to Disable-AzsScaleUnitNode
  - where:
      verb: Start
      subject: ScaleUnitNodeMaintenanceMode
    set:
      verb: Disable
      subject: ScaleUnitNode

  # Rename Stop-AzsScaleUnitNodeMaintenanceMode to Enable-AzsScaleUnitNode
  - where:
      verb: Stop
      subject: ScaleUnitNodeMaintenanceMode
    set:
      verb: Enable
      subject: ScaleUnitNode

  # Rename Get-AzsFabricLocation to Get-AzsInfrastructureLocation
  - where:
      subject: FabricLocation
    set:
      subject: InfrastructureLocation

  # Rename Get-AzsInfraRole to Get-AzsInfrastructureRoleInstance
  - where:
      subject: InfraRoleInstance
    set:
      subject: InfrastructureRoleInstance

  # Rename Get-AzsFileShare to Get-AzsInfrastructureShare
  - where:
      subject: FileShare
    set:
      subject: InfrastructureShare

  # Separate InfraRoleInstance stop operations
  - where:
      verb: Stop
      subject: InfrastructureRoleInstance
      variant: Shutdown.*
    set:
      verb: Disable

  # Rename model property names for StorageSubSystem to match spec
  - where:
      model-name: StorageSubSystem
      property-name: TotalCapacityGb
    set:
      property-name: TotalCapacityGB

  - where:
      model-name: StorageSubSystem
      property-name: RemainingCapacityGb
    set:
      property-name: RemainingCapacityGB
  
  # Rename model property names for Drive to match spec
  - where:
      model-name: Drive
      property-name: CapacityGb
    set:
      property-name: CapacityGB

  # Rename model property names for Volume to match spec
  - where:
      model-name: Volume
      property-name: TotalCapacityGb
    set:
      property-name: TotalCapacityGB

  - where:
      model-name: Volume
      property-name: RemainingCapacityGb
    set:
      property-name: RemainingCapacityGB

  - where:
      model-name: Volume
      property-name: Label
    set:
      property-name: VolumeLabel

  # Rename cmdlet parameter name in InfrastructureShare
  - where:
      subject: InfrastructureShare
      parameter-name: FileShare
    set:
      parameter-name: Name

  # Rename cmdlet parameter name in StorageSubSystem
  - where:
      subject: StorageSubSystem
      parameter-name: StorageSubSystem
    set:
      parameter-name: Name

  # Rename cmdlet parameter name in Drive
  - where:
      subject: Drive
      parameter-name: Drive
    set:
      parameter-name: Name

  # Rename cmdlet parameter name in Volume
  - where:
      subject: Volume
      parameter-name: Volume
    set:
      parameter-name: Name

  # Hide the auto-generated Get-AzsInfrastructureShare and expose it through customized one
  - where:
      verb: Get
      subject: InfrastructureShare
    hide: true

  # Hide the auto-generated Get-AzsStorageSubSystem and expose it through customized one
  - where:
      verb: Get
      subject: StorageSubSystem
    hide: true

  # Hide the auto-generated Get-AzsDrive and expose it through customized one
  - where:
      verb: Get
      subject: Drive
    hide: true

  # Hide the auto-generated Get-AzsVolume and expose it through customized one
  - where:
      verb: Get
      subject: Volume
    hide: true

  # Hide the auto-generated Get-AzsFabricOperation and expose it through customized one
  - where:
      verb: Get
      subject: FabricOperation
    hide: true

  # Hide the auto-generated Get-AzsNetworkOperationResult and expose it through customized one
  - where:
      verb: Get
      subject: NetworkOperationResult
    hide: true

  # Hide the auto-generated Get-AzsStorageOperationResult and expose it through customized one
  - where:
      subject: StorageOperationResult
    hide: true

  # Hide the auto-generated New-AzsScaleUnitFromJson and expose it through customized one
  - where:
      subject: ScaleUnitFromJson
    hide: true

subject-prefix: ''
module-version: 0.0.1
```
