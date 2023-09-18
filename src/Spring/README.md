<!-- region Generated -->
# Az.SpringApps
This directory contains the PowerShell module for the SpringApps service.

---
## Status
[![Az.SpringApps](https://img.shields.io/powershellgallery/v/Az.SpringApps.svg?style=flat-square&label=Az.SpringApps "Az.SpringApps")](https://www.powershellgallery.com/packages/Az.SpringApps/)

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
For information on how to develop for `Az.SpringApps`, see [how-to.md](how-to.md).
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
branch: 0b6eab579426b030aa84996b9c1b35ce137a7f9f
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/appplatform/resource-manager/Microsoft.AppPlatform/stable/2022-12-01/appplatform.json
    
title: SpringApps
module-version: 0.1.0
subject-prefix: Spring

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true
enable-parent-pipeline-input-for-list: false
auto-switch-view: false

directive:
  - where:
      verb: Set
      subject: BuildServiceAgentPoolPut
    set:
      verb: New
      subject: BuildServiceAgentPool

  - where:
      verb: Set
      subject: AppActiveDeployment
    set:
      verb: Update

  - where:
      subject: ServiceRegistry
      variant: Create
    set:
      variant: CreateRegistryExpanded

  - where:
      variant: ^(Create|Update).*(?<!Expanded|JsonFilePath|JsonString)$
    remove: true

  - where:
      verb: Set
    remove: true

  # rename subject
  - where:
      subject: ^Binding$
    remove: true

  # rename subject
  - where:
      subject: ^ConfigServerPatch$
    set:
      subject: ConfigServer

  - where:
      subject: ^MonitoringSettingPatch$
    set:
      subject: MonitoringSetting
  - where:
      subject: ^AppDomain$
    set:
      subject: CustomDomain

  - where:
      verb: Test
      subject: CustomDomain
    set:
      subject: CustomDomainNameAvailability

# remove cmdlet
  - where:
      subject: ^DeploymentHeapDump$
    set:
      subject: AppDeploymentHeapDump
  - where:
      subject: AppDeploymentHeapDump
    remove: true

  - where:
      subject: ^DeploymentThreadDump$
    set:
      subject: AppDeploymentThreadDump
  - where:
      subject: AppDeploymentThreadDump
    remove: true
  - where:
      verb: Update
      subject: BuildpackBinding
    remove: true

  # ReName parameter
  - where: 
      subject: ^Service$
      parameter-name: NetworkProfileAppNetworkResourceGroup
    set:
      parameter-name: NetworkProfileResourceGroup

  - where: 
      subject: ^Service$
      parameter-name: NetworkProfileAppSubnetId
    set:
      parameter-name: NetworkProfileSubnetId

  - where: 
      subject: ^Service$
      parameter-name: NetworkProfileServiceRuntimeNetworkResourceGroup
    set:
      parameter-name: NetworkProfileServiceResourceGroup

  - where: 
      subject: ^Service$
      parameter-name: NetworkProfileServiceRuntimeSubnetId
    set:
      parameter-name: NetworkProfileServiceSubnetId

  - where:
      subject: ^AppDeploymentHeapDump$|^AppDeploymentThreadDump$|^AppDeploymentJfr$
      parameter-name: DeploymentName
    set:
      parameter-name: Name

  - where:
      subject: ^BuildpackBinding$
      parameter-name: LaunchPropertySecret
    set:
      parameter-name: LaunchSecret

  - where:
      subject: ^ConfigurationService$
      parameter-name: GitPropertyRepository
    set:
      parameter-name: GitRepository

  - where:
      subject: ^ConfigServer$
      parameter-name: ServiceName
    set:
      parameter-name: Name

  - where:
      subject: ^TestEndpoint$
      parameter-name: ServiceName
    set:
      parameter-name: Name

  - where:
      subject: ^AppResourceUploadUrl$
      parameter-name: AppName
    set:
      parameter-name: Name

  - where:
      subject: ^BuildServiceAgentPool$
      parameter-name: AgentPoolName
    set:
      parameter-name: Name

  - where:
      subject: ^BuildServiceBuild$|^BuildServiceBuildResult$|^BuildServiceBuildResultLog$
      parameter-name: BuildName
    set:
      parameter-name: Name

  - where:
      subject: ^BuildServiceBuilder$
      parameter-name: BuilderName
    set:
      parameter-name: Name

  - where:
      subject: ^BuildServiceResourceUploadUrl$
      parameter-name: BuildServiceName
    set:
      parameter-name: Name

  - where:
      subject: ^BuildServiceSupportedBuildpack$
      parameter-name: BuildpackName
    set:
      parameter-name: Name

  - where:
      subject: ^BuildServiceSupportedStack$
      parameter-name: StackName
    set:
      parameter-name: Name

  - where:
      subject: ^AppCustomDomain$
      parameter-name: DomainName
    set:
      parameter-name: Name

  - where:
      subject: ^AppDeploymentLogFileUrl$
      parameter-name: DeploymentName
    set:
      parameter-name: Name

  - where:
      subject: ^MonitoringSetting$|^TestKey$
      parameter-name: ServiceName
    set:
      parameter-name: Name

  - where:
      subject: ^ConfigServer$
      parameter-name: (^GitProperty)(.*)
    set:
      parameter-name: Git$2
  - where:
      subject: BuildServiceBuildResult|BuildServiceBuildResultLog
      parameter-name: Name
    set:
      parameter-name: BuildName

  - where:
      subject: BuildServiceBuildResult|BuildServiceBuildResultLog
      parameter-name: BuildResultName
    set:
      parameter-name: Name

  - where:
      subject: BuildServiceBuild
      parameter-name: Builder
    set:
      parameter-name: BuilderId

  - where:
      subject: BuildServiceBuild
      parameter-name: AgentPool
    set:
      parameter-name: AgentPoolId

  - where:
      subject: AppActiveDeployment
      parameter-name: AppName
    set:
      parameter-name: Name

  - where:
      subject: AppActiveDeployment
      parameter-name: AppName
    set:
      parameter-name: Name

  - where:
      subject: AppActiveDeployment
      parameter-name: ActiveDeploymentName
    set:
      parameter-name: DeploymentName

  # Only support default value
  - where:
      subject: ^BuildService$|^BuildServiceAgentPool$|^ConfigurationService$|^ServiceRegistry$
      parameter-name: Name
    hide: true
    set:
      default:
        script: "'default'"

  - where:
      subject: ^BuildServiceAgentPool$|^BuildServiceBuilder$|^BuildServiceSupportedBuildpack$|^BuildServiceSupportedStack$|^BuildpackBinding$
      parameter-name: BuildServiceName
    hide: true
    set:
      default:
        script: "'default'"

  # Returns a random value of RelativePath after each execution of Get-AzSpringResourceUploadUrl
  - where:
      verb: Get
      subject: ^ResourceUploadUrl$
    hide: true

  - where:
      verb: Get
      subject: ^BuildServiceResourceUploadUrl$
    hide: true

  - where:
      subject: ^BuildServiceBuild$
    hide: true
  - where:
      subject: ^BuildServiceBuildResult$
    hide: true
  - where:
      subject: ^BuildServiceBuildResultLog$
    hide: true

  - where:
      model-name: ServiceResource
    set:
      format-table:
        properties:
          - Location
          - Name
          - ProvisioningState
          - SkuName
          - SkuTier
          - ResourceGroupName

  - where:
      model-name: AppResource
    set:
      format-table:
        properties:
          - Location
          - Name
          - ProvisioningState
          - ResourceGroupName

  - where:
      model-name: BindingResource
    set:
      format-table:
        properties:
          - ResourceName
          - Name
          - ResourceGroupName
          - ResourceType

  - where:
      model-name: CertificateResource
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - Type

  - where:
      model-name: BuildService
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - ProvisioningState
          - KPackVersion
          - ResourceRequestCpu
          - ResourceRequestMemory

  - where:
      model-name: BuildServiceAgentPoolResource
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - ProvisioningState
          - PoolSizeCpu
          - PoolSizeMemory
          - PoolSizeName

  - where:
      model-name: BuilderResource
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - ProvisioningState
          - StackId
          - StackVersion

  - where:
      model-name: SupportedBuildpackResource
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - BuildpackId

  - where:
      model-name: SupportedStackResource
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - StackId
          - Version

  - where:
      model-name: ConfigServerResource
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - ProvisioningState

  - where:
      model-name: CustomDomainResource
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - ProvisioningState
          - AppName

  - where:
      model-name: MonitoringSettingResource
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - ProvisioningState
          - TraceEnabled

  - no-inline:
    - UserSourceInfo
    - CertificateProperties

  # Modifications were made to the command
  - model-cmdlet:
    - model-name: DeploymentSettingsEnvironmentVariables
      cmdlet-name: New-AzSpringDeploymentSettingsEnvVariableObject
    - model-name: DeploymentSettingsAddonConfigs
      cmdlet-name: New-AzSpringDeploymentSettingAddonConfigObject
    - model-name: UserSourceInfo
    - model-name: ActiveDeploymentCollection
    - model-name: GatewayApiRoute
    - model-name: CustomPersistentDiskResource
    - model-name: BuildpacksGroupProperties
    - model-name: ConfigurationServiceGitRepository
    - model-name: GitPatternRepository
    - model-name: LoadedCertificate
      cmdlet-name: New-AzSpringBuildpacksGroupObject
    - model-name: BuildpackProperties
      cmdlet-name: New-AzSpringBuildpackObject
    - model-name: DeploymentSettings
      cmdlet-name: New-AzSpringDeploymentSettingObject
    - model-name: KeyVaultCertificateProperties
      cmdlet-name: New-AzSpringKeyVaultCertificateObject
    - model-name: ContentCertificateProperties
      cmdlet-name: New-AzSpringContentCertificateObject
    - model-name: JarUploadedUserSourceInfo
      cmdlet-name: New-AzSpringDeploymentJarUploadedObject
    - model-name: NetCoreZipUploadedUserSourceInfo
      cmdlet-name: New-AzSpringDeploymentNetCoreZipUploadedObject
    - model-name: SourceUploadedUserSourceInfo
      cmdlet-name: New-AzSpringDeploymentSourceUploadedObject
    - model-name: BuildResultUserSourceInfo
      cmdlet-name: New-AzSpringDeploymentBuildResultObject
```
