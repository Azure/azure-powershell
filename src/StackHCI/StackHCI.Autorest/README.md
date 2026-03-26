<!-- region Generated -->
# Az.StackHCI
This directory contains the PowerShell module for the StackHci service.

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
For information on how to develop for `Az.StackHCI`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@autorest`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest-beta`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 96fedf433c6c0ee9fccde4ec6698c75ac118c3d0
require:
  - $(this-folder)/../../readme.azure.noprofile.md
# lock the commit
input-file:
  - $(repo)/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/StackHCI/stable/2024-04-01/arcSettings.json
  - $(repo)/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/StackHCI/stable/2024-04-01/clusters.json
  - $(repo)/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/StackHCI/stable/2024-04-01/extensions.json
  - $(repo)/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/StackHCI/stable/2024-04-01/deploymentSettings.json
  - $(repo)/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/StackHCI/stable/2024-04-01/edgeDevices.json
  - $(repo)/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/StackHCI/stable/2024-04-01/securitySettings.json
  - $(repo)/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/StackHCI/stable/2024-04-01/updateRuns.json
  - $(repo)/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/StackHCI/stable/2024-04-01/updateSummaries.json
  - $(repo)/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/StackHCI/stable/2024-04-01/updates.json

module-version: 1.2.0
title: StackHCI
service-name: StackHCI
subject-prefix: $(service-name)

inlining-threshold: 50

resourcegroup-append: true 

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  # Rename function
  - where:
      verb: Invoke
      subject: AndArcSetting
    set:
      subject: ConsentAndInstallDefaultExtension
  # Remove the unexpanded parameter set
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Set
      subject: Workspace
    remove: true
  # Remove Update-AzStackHciExtension 
  - where:
      verb: Update
      subject: Extension
    remove: true
  # Remove Start-AzStackHciClusterLogCollection
  - where:
      verb: Start
      subject: ClusterLogCollection
    remove: true
  # Remove Set-AzStackHciClusterRemoteSupport
  - where:
      verb: Set
      subject: ClusterRemoteSupport
    remove: true
  # Remove Invoke-AzStackHciUploadClusterCertificate
  - where:
      verb: Invoke
      subject: UploadClusterCertificate
    remove: true 
  # Remove New-AzStackHciArcSettingPassword
  - where:
      verb: New
      subject: ArcSettingPassword
    remove: true
  # Remove Update-AzStackHciArcSetting
  - where:
      verb: Update
      subject: ArcSetting
    remove: true 
  # Hide aadClientId from Update-AzStackHCICluster
  - where:
      verb: Update
      subject: Cluster
      parameter-name: AadClientId
    hide: true
  # Hide name from arcSettings 
  - where:
      verb: New
      subject: ArcSetting
      parameter-name: Name
    hide: true
    set:
      default:
        script: '"default"'
  # Hide name from edgeDevices 
  - where:
      verb: New
      subject: EdgeDevice
      parameter-name: Name
    hide: true
    set:
      default:
        script: '"default"'
  # Hide name from securitySetting 
  - where:
      verb: New
      subject: SecuritySetting
      parameter-name: SName
    hide: true
    set:
      default:
        script: '"default"'
  - where:
      verb: Invoke
      subject: ConsentAndInstallDefaultExtension
      parameter-name: ArcSettingName
    hide: true
    set:
      default:
        script: '"default"'
  # Set Enable by default 
  - where:
      verb: Invoke
      subject: ExtendClusterSoftwareAssuranceBenefit
      parameter-name: SoftwareAssuranceIntent
    set:
      default:
        script: '"Enable"'
  # Remove Initialize-AzStackHCIArcSettingDisableProcess
  - where:
      verb: Initialize
      subject: ArcSettingDisableProcess
    remove: true 
  # Update ExtensionParameters.settings
  - from: swagger-document
    where: $.definitions.ExtensionParameters.properties.settings
    transform: $["additionalProperties"] = true
  # Update ExtensionParameters.protectedSettings
  - from: swagger-document
    where: $.definitions.ExtensionParameters.properties.protectedSettings
    transform: $["additionalProperties"] = true
  # format tables for models 
  - where:
      model-name: Cluster
    set:
      format-table:
        properties:
          - Location
          - Name
          - ResourceGroupName
        labels:
          ResourceGroupName: Resource Group
  - where:
      model-name: ArcSetting
    set:
      format-table:
        properties:
          - ResourceGroupName
          - AggregateState
        labels:
          ResourceGroupName: Resource Group
  - where:
      model-name: Extension
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
        labels:
          ResourceGroupName: Resource Group
  - where:
      verb: Get|New
      subject: ArcSetting
    set:
      breaking-change:
        deprecated-output-properties:
          - DefaultExtension
          - PerNodeDetail
        new-output-properties:
          - DefaultExtension
          - PerNodeDetail
        change-description: The types of the properties DefaultExtension and PerNodeDetail will be changed from single object or fixed array to 'List'.
        deprecated-by-version: 3.0.0
        deprecated-by-azversion: 15.0.0
        change-effective-date: 2025/11
  - where:
      verb: Get|New
      subject: Extension
    set:
      breaking-change:
        deprecated-output-properties:
          - PerNodeExtensionDetail
        new-output-properties:
          - PerNodeExtensionDetail
        change-description: The type of the property PerNodeExtensionDetail will be changed from single object or fixed array to 'List'.
        deprecated-by-version: 3.0.0
        deprecated-by-azversion: 15.0.0
        change-effective-date: 2025/11
  - where:
      verb: Get|New|Update
      subject: Cluster
    set:
      breaking-change:
        deprecated-output-properties:
          - ReportedPropertyNode
          - LogCollectionPropertyLogCollectionSessionDetail
          - RemoteSupportPropertyRemoteSupportSessionDetail
          - RemoteSupportPropertyRemoteSupportNodeSetting
          - ReportedPropertySupportedCapability
        new-output-properties:
          - ReportedPropertyNode
          - LogCollectionPropertyLogCollectionSessionDetail
          - RemoteSupportPropertyRemoteSupportSessionDetail
          - RemoteSupportPropertyRemoteSupportNodeSetting
          - ReportedPropertySupportedCapability
        change-description: The types of the properties ReportedPropertyNode, LogCollectionPropertyLogCollectionSessionDetail, RemoteSupportPropertyRemoteSupportSessionDetail, RemoteSupportPropertyRemoteSupportNodeSetting and ReportedPropertySupportedCapability will be changed from single object or fixed array to 'List'.
        deprecated-by-version: 3.0.0
        deprecated-by-azversion: 15.0.0
        change-effective-date: 2025/11
  - where:
      verb: Get
      subject: DeploymentSetting
    set:
      breaking-change:
        deprecated-output-properties:
          - DeploymentStatusStep
          - ValidationStatusStep
          - DeploymentConfigurationScaleUnit
          - ArcNodeResourceId
        new-output-properties:
          - DeploymentStatusStep
          - ValidationStatusStep
          - DeploymentConfigurationScaleUnit
          - ArcNodeResourceId
        change-description: The types of the properties DeploymentStatusStep, ValidationStatusStep, DeploymentConfigurationScaleUnit and ArcNodeResourceId will be changed from single object or fixed array to 'List'.
        deprecated-by-version: 3.0.0
        deprecated-by-azversion: 15.0.0
        change-effective-date: 2025/11
  - where:
      verb: New
      subject: DeploymentSetting
    set:
      breaking-change:
        deprecated-output-properties:
          - DeploymentStatusStep
          - ValidationStatusStep
          - DeploymentConfigurationScaleUnit
          - ArcNodeResourceId
          - DeploymentDataSecret
          - DeploymentDataInfrastructureNetwork
          - HostNetworkIntent
          - DeploymentDataPhysicalNode
          - SbePartnerInfoCredentialList
          - SbePartnerInfoPartnerProperty
          - HostNetworkStorageNetwork
        new-output-properties:
          - DeploymentStatusStep
          - ValidationStatusStep
          - DeploymentConfigurationScaleUnit
          - ArcNodeResourceId
          - DeploymentDataSecret
          - DeploymentDataInfrastructureNetwork
          - HostNetworkIntent
          - DeploymentDataPhysicalNode
          - SbePartnerInfoCredentialList
          - SbePartnerInfoPartnerProperty
          - HostNetworkStorageNetwork
        change-description: The types of the properties DeploymentStatusStep, ValidationStatusStep, DeploymentConfigurationScaleUnit and ArcNodeResourceId will be changed from single object or fixed array to 'List'. The type of property DeploymentDataSecret, DeploymentDataInfrastructureNetwork, HostNetworkIntent, DeploymentDataPhysicalNode, SbePartnerInfoCredentialList, SbePartnerInfoPartnerProperty and HostNetworkStorageNetwork of type ScaleUnits will be changed from single object or fixed array to 'List'.
        deprecated-by-version: 3.0.0
        deprecated-by-azversion: 15.0.0
        change-effective-date: 2025/11
  - where:
      verb: Get|Set
      subject: ^Update$
    set:
      breaking-change:
        deprecated-output-properties:
          - ComponentVersion
          - HealthCheckResult
          - Prerequisite
        new-output-properties:
          - ComponentVersion
          - HealthCheckResult
          - Prerequisite
        change-description: The types of the properties ComponentVersion, HealthCheckResult and Prerequisite will be changed from single object or fixed array to 'List'.
        deprecated-by-version: 3.0.0
        deprecated-by-azversion: 15.0.0
        change-effective-date: 2025/11
  - where:
      verb: Get|Set
      subject: UpdateRun
    set:
      breaking-change:
        deprecated-output-properties:
          - ProgressStep
        new-output-properties:
          - ProgressStep
        change-description: The type of the property ProgressStep will be changed from single object or fixed array to 'List'.
        deprecated-by-version: 3.0.0
        deprecated-by-azversion: 15.0.0
        change-effective-date: 2025/11
  - where:
      verb: Get|Set
      subject: UpdateSummary
    set:
      breaking-change:
        deprecated-output-properties:
          - PackageVersion
          - HealthCheckResult
        new-output-properties:
          - PackageVersion
          - HealthCheckResult
        change-description: The types of the properties PackageVersion and HealthCheckResult will be changed from single object or fixed array to 'List'.
        deprecated-by-version: 3.0.0
        deprecated-by-azversion: 15.0.0
        change-effective-date: 2025/11
  - where:
      verb: Test
      subject: EdgeDevice
    set:
      breaking-change:
        deprecated-output-properties:
          - EdgeDeviceId
        new-output-properties:
          - EdgeDeviceId
        change-description: The type of the property EdgeDeviceId will be changed from single object or fixed array to 'List'.
        deprecated-by-version: 3.0.0
        deprecated-by-azversion: 15.0.0
        change-effective-date: 2025/11
  - where:
      verb: Invoke
      subject: ConsentAndInstallDefaultExtension
    set:
      breaking-change:
        deprecated-output-properties:
          - DefaultExtension
          - PerNodeDetail
        new-output-properties:
          - DefaultExtension
          - PerNodeDetail
        change-description: The types of the properties DefaultExtension and PerNodeDetail will be changed from single object or fixed array to 'List'.
        deprecated-by-version: 3.0.0
        deprecated-by-azversion: 15.0.0
        change-effective-date: 2025/11
  - where:
      verb: Invoke
      subject: ExtendClusterSoftwareAssuranceBenefit
    set:
      breaking-change:
        deprecated-output-properties:
          - ReportedPropertyNode
          - LogCollectionPropertyLogCollectionSessionDetail
          - RemoteSupportPropertyRemoteSupportSessionDetail
          - RemoteSupportPropertyRemoteSupportNodeSetting
          - ReportedPropertySupportedCapability
        new-output-properties:
          - ReportedPropertyNode
          - LogCollectionPropertyLogCollectionSessionDetail
          - RemoteSupportPropertyRemoteSupportSessionDetail
          - RemoteSupportPropertyRemoteSupportNodeSetting
          - ReportedPropertySupportedCapability
        change-description: The types of the properties ReportedPropertyNode, LogCollectionPropertyLogCollectionSessionDetail, RemoteSupportPropertyRemoteSupportSessionDetail, RemoteSupportPropertyRemoteSupportNodeSetting and ReportedPropertySupportedCapability will be changed from single object or fixed array to 'List'.
        deprecated-by-version: 3.0.0
        deprecated-by-azversion: 15.0.0
        change-effective-date: 2025/11
  - where:
      verb: Invoke
      subject: ExtendClusterSoftwareAssuranceBenefit
      variant: Extend|ExtendViaIdentity
    set:
      breaking-change:
        deprecated-by-version: 3.0.0
        deprecated-by-azversion: 15.0.0
        change-effective-date: 2025/11
  - where:
      subject: EdgeDevice
      variant: Validate|ValidateViaIdentity
    set:
      breaking-change:
        deprecated-by-version: 3.0.0
        deprecated-by-azversion: 15.0.0
        change-effective-date: 2025/11
  - where:
      parameter-name: IdentityType
    set:
      breaking-change:
        old-parameter-type: string
        new-parameter-type: boolean
        change-description: IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system-assigned identities.
        deprecated-by-version: 3.0.0
        deprecated-by-azversion: 15.0.0
        change-effective-date: 2025/11
  - where:
      parameter-name: UserAssignedIdentity
    set:
      breaking-change:
        old-parameter-type: hashtable
        new-parameter-type: list
        change-description: The type of UserAssignedIdentity will be simplified to an array of strings that is used to specify the user's assigned identity.
        deprecated-by-version: 3.0.0
        deprecated-by-azversion: 15.0.0
        change-effective-date: 2025/11
```
