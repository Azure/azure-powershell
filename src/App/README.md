<!-- region Generated -->
# Az.App
This directory contains the PowerShell module for the App service.

---
## Status
[![Az.App](https://img.shields.io/powershellgallery/v/Az.App.svg?style=flat-square&label=Az.App "Az.App")](https://www.powershellgallery.com/packages/Az.App/)

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
For information on how to develop for `Az.App`, see [how-to.md](how-to.md).
<!-- endregion -->

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: eb2b882ef0a4aa5956ca38cfa566fc4d7cfb3fb0
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2022-03-01/AuthConfigs.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2022-03-01/CommonDefinitions.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2022-03-01/ContainerApps.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2022-03-01/ContainerAppsRevisions.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2022-03-01/DaprComponents.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2022-03-01/Global.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2022-03-01/ManagedEnvironments.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2022-03-01/ManagedEnvironmentsStorages.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2022-03-01/SourceControls.json

title: App
module-version: 0.1.0
subject-prefix: ''

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

directive:
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Set|Test
    remove: true
  - where:
      subject: ContainerAppCustomHostnameAnalysis
    set:
      subject: ContainerAppCustomHostName
  - where:
      verb: Initialize
      subject: ContainerAppRevision
    set:
      verb: Enable
      subject: ContainerAppRevision
  - where:
      verb: Invoke
      subject: DeactivateContainerAppRevision
    set:
      verb: Disable
      subject: ContainerAppRevision
  - where:
      verb: Remove
      subject: ContainerAppsAuthConfig
    set:
      subject: ContainerAppAuthConfig
  - where:
      verb: Remove
      subject: ContainerAppsSourceControl
    set:
      subject: ContainerAppSourceControl
  - where:
      subject: DaprComponent
    set:
      subject: AppManagedEnvDapr
  - where:
      subject: DaprComponentSecret
    set:
      subject: AppManagedEnvDaprSecret
  - where:
      subject: Certificate
    set:
      subject: AppManagedEnvCert
  - where:
      subject: ManagedEnvironment
    set:
      subject: AppManagedEnv
  - where:
      subject: ManagedEnvironmentsStorage
    set:
      subject: AppManagedEnvStorage
  - where:
      subject: ManagedEnvironmentStorage
    set:
      subject: AppManagedEnvStorage
  # Re-name and custom it
  # - model-cmdlet:
  #     - EnvironmentVar
  #     - ContainerAppProbe
  #     - VolumeMount
  #     - ScaleRuleAuth
  #     - CustomScaleRuleMetadata
  #     - HttpScaleRuleMetadata
  #     - AppIdentity
  #     - RegistryCredentials
  #     - DaprMetadata
  #     - Secret
  #     - CustomDomain
  #     - TrafficWeight
  #     - ScaleRule
  #     - Container
  #     - Volume
  #     - IdentityProviders
  #     - IdentityProvidersCustomOpenIdConnectProviders
  - where:
      parameter-name: ComponentName
    set:
      parameter-name: DaprName
  - where:
      parameter-name: EnvironmentName
    set:
      parameter-name: EnvName
```
