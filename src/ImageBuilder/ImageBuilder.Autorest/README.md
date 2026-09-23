<!-- region Generated -->
# Az.ImageBuilder
This directory contains the PowerShell module for the ImageBuilder service.

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
For information on how to develop for `Az.ImageBuilder`, see [how-to.md](how-to.md).
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
commit: 4b4bb1021353692578499f43f1aa912964a2b7e2
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/imagebuilder/resource-manager/Microsoft.VirtualMachineImages/stable/2022-07-01/imagebuilder.json

title: ImageBuilder
module-version: 0.1.0
subject-prefix: $(service-name)

directive:
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^(Create)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentityExpanded$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true

  # Rename *-AzImageBuildVirtualMachineImage(.*) -> *-AzImageBuild(.*)
  - where:
      subject: (.*)Image(.*)
    set:
      subject: $2

  # Add required for template
  # - from: swagger-document
  #   where: $.definitions.ImageTemplate
  #   transform: $['required'] = ["identity","properties"]
  # - from: swagger-document
  #   where: $.definitions.ImageTemplateProperties
  #   transform: $['required'] = ["source","distribute","customize"]
  # Customize New-AzImageBuilderTemplate, remove parameter EnableSystemAssignedIdentity
  - where:
      subject: Template
      variant: ^CreateExpanded$
    hide: true

  # To remove update for Trigger since there is no properties
  - where:
      subject: Trigger
      verb: Update
    remove: true
  # Remove Update [Update template not support](https://learn.microsoft.com/en-us/azure/virtual-machines/linux/image-builder-troubleshoot#update-or-upgrade-of-image-templates-is-currently-not-supported)
  - where:
      subject: Template
      verb: Update
    remove: true
  
  # Rename JsonTemplatePath -> JsonFilePath and keep JsonTemplatePath as alias in New-AzImageBuildTemplate
  - where:
      subject: Template
      parameter-name: JsonFilePath
    set:
      alias: JsonTemplatePath

  # Rename ImageTemplateName -> Name and keep ImageTemplateName as alias in *-AzImageBuildTemplate
  - where:
      subject: Template
      parameter-name: ImageTemplateName
    set:
      parameter-name: Name
      alias: ImageTemplateName

  # Rename RunOutputName -> Name and keep RunOutputName as alias in *-AzImageBuildTemplateRunOutput
  - where:
      subject: TemplateRunOutput
      parameter-name: RunOutputName
    set:
      parameter-name: Name
      alias: RunOutputName

  # Rename ValidateInVMValidation to Validator 
  - where:
      parameter-name: ValidateInVMValidation
    set:
      parameter-name: Validator

  # Collapse model with discriminator
  - no-inline:
    - ImageTemplateCustomizer
    - ImageTemplateDistributor
    - ImageTemplateSource
    - ImageTemplateInVMValidator
    - DistributeVersioner

  - where:
      model-name: ImageTemplate
    set:
      format-table:
        properties:
          - Location
          - Name
          - ResourceGroupName
  - where:
      model-name: Trigger
    set:
      format-table:
        properties:
          - Kind
          - Name
          - ProvisioningState
          - ResourceGroupName
  - where:
      model-name: RunOutput
    set:
      format-table:
        properties:
          - Name
          - ProvisioningState
          - ResourceGroupName

  # Generate models and combine them as 1 cmdlet
  - model-cmdlet:
    ########### ImageTemplateCustomizer ############
    # Combine as 1 cmdlet named New-AzImageBuilderTemplateCustomizerObject
    # - model-name: ImageTemplateShellCustomizer
    # - model-name: ImageTemplateRestartCustomizer
    # - model-name: ImageTemplateWindowsUpdateCustomizer
    # - model-name: ImageTemplatePowerShellCustomizer
    # - model-name: ImageTemplateFileCustomizer
    ########## ImageTemplateDistributor ###########
    # Combine as 1 cmdlet named New-AzImageBuilderTemplateDistributorObject
    # - model-name: ImageTemplateManagedImageDistributor
    # - model-name: ImageTemplateSharedImageDistributor
    # - model-name: ImageTemplateVhdDistributor
    ############# ImageTemplateSource ##############
    # Combine as 1 cmdlet named New-AzImageBuilderTemplateSourceObject
    # Note: publisher, offer, sku and version are required
    # - model-name: ImageTemplatePlatformImageSource
    # - model-name: ImageTemplateManagedImageSource
    # - model-name: ImageTemplateSharedImageVersionSource
    ########## ImageTemplateInVMValidator ###########
    # Combine as 1 cmdlet named New-AzImageBuilderTemplateValidatorObject
    # - model-name: ImageTemplateShellValidator
    # - model-name: ImageTemplatePowerShellValidator
    ########## AzImageBuilderTemplateDistributorVersioning parent model name: DistributeVersioner ########### 
    - model-name: DistributeVersionerLatest
      cmdlet-name: New-AzImageBuilderTemplateDistributeVersionerLatestObject
    - model-name: DistributeVersionerSource
      cmdlet-name: New-AzImageBuilderTemplateDistributeVersionerSourceObject
```
