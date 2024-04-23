<!-- region Generated -->
# Az.SpringCloud
This directory contains the PowerShell module for the SpringCloud service.

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
For information on how to develop for `Az.SpringCloud`, see [how-to.md](how-to.md).
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
commit: 0ae34dbf19d039effd9d366e6c12df38ca4c1c2a
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/appplatform/resource-manager/Microsoft.AppPlatform/stable/2022-04-01/appplatform.json
    
title: SpringCloud
module-version: 0.1.0
resourcegroup-append: true
nested-object-to-string: true
identity-correction-for-post: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

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
      subject: AppActiveDeployment

  - where:
      verb: Set
    remove: true
  # First rename parameter of the Get-AzSpringCloudService, then rename cmdlet to Get-AzSpringCloud.
  - where: 
      subject: ^Service$
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true

  - where: 
      subject: ^Service$
      variant: ^Update$|^UpdateViaIdentity$
    remove: true

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
  # Customization for add default locatio value when not pass location parameter
  - where:
      verb: New
      subject: ^Service$
    hide: true
  - where:
      subject: ^Service(.*)
    set:
      subject: $1
#------------------------------------------------------------------------------
# rename subject
  - where:
      subject: ^Binding$
    set:
      subject: AppBinding

  - where:
      subject: ^Deployment$
    set:
      subject: AppDeployment

  - where:
      subject: ^CustomDomain$
    set:
      subject: AppCustomDomain

  - where:
      subject: ^DeploymentLogFileUrl$
    set:
      subject: AppDeploymentLogFileUrl

  - where:
      subject: ^DeploymentHeapDump$
    set:
      subject: AppDeploymentHeapDump

  - where:
      subject: ^DeploymentThreadDump$
    set:
      subject: AppDeploymentThreadDump

  - where:
      subject: ^DeploymentJfr$
    set:
      subject: AppDeploymentJfr

  - where:
      verb: Update
      subject: ^ConfigServerPatch$
    set:
      subject: ConfigServer

  - where:
      verb: Update
      subject: ^MonitoringSettingPatch$
    set:
      subject: MonitoringSetting

  - where:
      verb: Test
      subject: ^AppDomain$
    set:
      subject: AppCustomDomain
      
# remove cmdlet
  - where:
      subject: AppDeploymentHeapDump
    remove: true
  - where:
      subject: AppDeploymentThreadDump
    remove: true
# remove variant
# |Certificate|ConfigurationService
  - where: 
      subject: ^App$|^AppBinding$|^AppDeployment$|^AppCustomDomain$|^|BuildpackBinding$|^BuildServiceBuild$|^BuildServiceBuilder$
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true
  - where: 
      subject: ^AppDeploymentHeapDump$|^AppDeploymentThreadDump$|^TestKey$
      variant: ^Generate$|^GenerateViaIdentity$|^GenerateViaIdentityExpanded$
    remove: true
  
  - where:
      verb: Get
      subject: BuildServiceBuildResultLog
      variant: GetViaIdentity
    remove: true

  - where:
      verb: Get
      subject: ^Registry$|^BuildService$|^BuildServiceAgentPool$|^ConfigurationService$
      variant: List
    remove: true
    

  - where: 
      subject: ^TestKey$
      variant: ^Regenerate$|^RegenerateViaIdentity$|^RegenerateViaIdentityExpanded$
    remove: true

  - where: 
      subject: ^AppActiveDeployment$
      variant: ^SetViaIdentity$|^Set$
    remove: true

  - where: 
      subject: ^DeploymentJfr$
      variant: ^Start$|^StartViaIdentity$
    remove: true

  - where:
      verb: Test 
      subject: ^AppCustomDomain$
      variant: ^Validate$|^ValidateViaIdentity$
    remove: true

  - where:
      verb: Test 
      subject: ^ConfigServer$|^ConfigurationService$
      variant: ^Validate$|^ValidateViaIdentity$
    remove: true

  - where:
      verb: Test 
      subject: ^NameAvailability$
      variant: ^Check$|^CheckViaIdentity$|^CheckViaIdentityExpanded$
    remove: true

  - where:
      subject: ^AppDeploymentJfr$
      variant: ^Start$|^StartViaIdentity$
    remove: true

  - where: 
      subject: ^App$|^AppBinding$|^AppDeployment$|^AppCustomDomain$|^ConfigServer$|^MonitoringSetting$|^BuildServiceAgentPool$
      variant: ^Update$|^UpdateViaIdentity$
    remove: true

# rename parameter
  - where:
      subject: ^AppDeployment$
      parameter-name: ^DeploymentSetting(.*)
    set:
      parameter-name: $1

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
      subject: ^BuildService$|^BuildServiceAgentPool$|^ConfigurationService$|^Registry$
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

  # Returns a random value of RelativePath after each execution of Get-AzSpringCloudAppResourceUploadUrl
  - where:
      verb: Get
      subject: ^AppResourceUploadUrl$
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

  # Customization for add default locatio value when not pass location parameter
  - where:
      verb: New
      subject: ^App$
    hide: true
  - where:
      verb: Remove
      subject: ^Registry$
    hide: true

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

  - model-cmdlet:
      # - BuildpacksGroupProperties
      # - BuildpackProperties
      - ConfigurationServiceGitRepository
      - GitPatternRepository
      # - KeyVaultCertificateProperties
      # - ContentCertificateProperties
    # - LoadedCertificate
    # --> rename  New-AzSpringCloudLoadedCertificateObject New-AzSpringCloudAppLoadedCertificateObject
    # - JarUploadedUserSourceInfo
    # --> rename New-AzSpringCloudDeploymentJarUploadedObject --> New-AzSpringCloudAppDeploymentJarUploadedObject
    # - NetCoreZipUploadedUserSourceInfo
    # --> rename New-AzSpringCloudDeploymentNetCoreZipUploadedObject --> New-AzSpringCloudAppDeploymentNetCoreZipUploadedObject
    # - SourceUploadedUserSourceInfo
    # --> rename New-AzSpringCloudDeploymentSourceUploadedObject --> New-AzSpringCloudAppDeploymentSourceUploadedObject
      # - BuildResultUserSourceInfo --> New-AzSpringCloudAppDeploymentBuildResultObject

  - where:
      subject-prefix: SpringCloud
    set:
      preview-message: Az.SpringCloud last version update, Az.SpringCloud will be renamed to Az.Spring.
```
