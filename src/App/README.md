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
branch: 5b51ccefb0ba7799bbeac5e5460d9eec84ce55fa
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2023-05-01/AuthConfigs.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2023-05-01/AvailableWorkloadProfiles.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2023-05-01/BillingMeters.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2023-05-01/CommonDefinitions.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2023-05-01/ConnectedEnvironments.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2023-05-01/ConnectedEnvironmentsCertificates.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2023-05-01/ConnectedEnvironmentsDaprComponents.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2023-05-01/ConnectedEnvironmentsStorages.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2023-05-01/ContainerApps.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2023-05-01/ContainerAppsRevisions.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2023-05-01/Diagnostics.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2023-05-01/Global.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2023-05-01/Jobs.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2023-05-01/ManagedEnvironments.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2023-05-01/ManagedEnvironmentsDaprComponents.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2023-05-01/ManagedEnvironmentsStorages.json
  - $(repo)/specification/app/resource-manager/Microsoft.App/stable/2023-05-01/SourceControls.json

title: App
module-version: 0.2.0
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true
auto-switch-view: false

directive:
  - from: swagger-document 
    where: $.definitions.Certificate.properties.properties.properties.password
    transform: >-
      return {
        "description": "Certificate password.",
        "type": "string",
        "x-ms-mutability": [
          "create"
        ],
        "format": "password",
        "x-ms-secret": true
      }
  - where:
      verb: Update
      subject: ConnectedEnvironment
      variant: Update
    set:
      variant: UpdateExpanded
  - where:
      verb: Update
      subject: ConnectedEnvironment
      variant: UpdateViaIdentity
    set:
      variant: UpdateViaIdentityExpanded
  - where:
      variant: ^(Create|Update).*(?<!Expanded|JsonFilePath|JsonString)$
    remove: true
  - where:
      verb: Set
    remove: true

  - where:
      subject: ContainerAppCustomHostnameAnalysis
    set:
      subject: ContainerAppCustomHostName

  - where:
      verb: Initialize
      subject: ContainerAppsRevision
    set:
      verb: Enable
      subject: ContainerAppRevision
  - where:
      verb: Invoke
      subject: DeactivateContainerAppsRevision
    set:
      verb: Disable
      subject: ContainerAppRevision
  - where:
      subject: ContainerAppsRevision
    set:
      subject: ContainerAppRevision

  - where:
      subject: ContainerAppsAuthConfig
    set:
      subject: ContainerAppAuthConfig

  - where:
      subject: ContainerAppsDiagnosticDetector
    set:
      subject: ContainerAppDiagnosticDetector
  - where:
      subject: ContainerAppsDiagnosticRevision
    set:
      subject: ContainerAppDiagnosticRevision
  - where:
      subject: ContainerAppsDiagnosticRoot
    set:
      subject: ContainerAppDiagnosticRoot

  - where:
      subject: ContainerAppsRevision
    set:
      subject: ContainerAppRevision
  - where:
      subject: ContainerAppsRevisionReplica
    set:
      subject: ContainerAppRevisionReplica

  - where:
      subject: ContainerAppsSourceControl
    set:
      subject: ContainerAppSourceControl

  - where:
      subject: DaprComponent
    set:
      subject: ContainerAppManagedEnvDapr
  - where:
      subject: DaprComponentSecret
    set:
      subject: ContainerAppManagedEnvDaprSecret
  - where:
      subject: Certificate
    set:
      subject: ContainerAppManagedEnvCert
  - where:
      subject: ManagedEnvironment
    set:
      subject: ContainerAppManagedEnv
  - where:
      subject: ManagedEnvironmentsStorage
    set:
      subject: ContainerAppManagedEnvStorage

  - where:
      subject: ConnectedEnvironment
    set:
      subject: ConnectedEnv
  - where:
      subject: ConnectedEnvironmentsCertificate
    set:
      subject: ConnectedEnvCert
  - where:
      subject: ConnectedEnvironmentsDaprComponent
    set:
      subject: ConnectedEnvDapr
  - where:
      subject: ConnectedEnvironmentsDaprComponentSecret
    set:
      subject: ConnectedEnvDaprSecret
  - where:
      subject: ConnectedEnvironmentsStorage
    set:
      subject: ConnectedEnvStorage
  - where:
      subject: ManagedCertificate
    set:
      subject: ManagedCert
  - where:
      subject: ManagedEnvironmentAuthToken
    set:
      subject: ManagedEnvAuthToken
  - where:
      subject: ManagedEnvironmentDiagnosticDetector
    set:
      subject: ManagedEnvDiagnosticDetector
  - where:
      subject: ManagedEnvironmentsDiagnosticRoot
    set:
      subject: ManagedEnvDiagnosticRoot
  - where:
      subject: ManagedEnvironmentWorkloadProfileState
    set:
      subject: ManagedEnvWorkloadProfileState
  - where:
      subject: ConnectedEnvironmentNameAvailability
    set:
      subject: ConnectedEnvNameAvailability
  - where:
      subject: NamespaceNameAvailability
    set:
      subject: NamespaceAvailability

  # Modifications were made to the command
  # - model-cmdlet:
  #   - model-name: RegistryCredentials
  #   - model-name: Secret
  #   - model-name: JobScaleRule
  #   - model-name: Container
  #   - model-name: InitContainer
  #   - model-name: Volume
  #   - model-name: DaprMetadata
  #   - model-name: WorkloadProfile
  #   - model-name: IdentityProviders
  #   - model-name: Configuration
  #   - model-name: ScaleRule
  #   - model-name: ServiceBind
  #   - model-name: DaprMetadata
  #   - model-name: JobExecutionContainer
  #   - model-name: CustomDomain
  #   - model-name: IPSecurityRestrictionRule
  #   - model-name: TrafficWeight
  #   - model-name: ContainerAppProbe
  #   - model-name: EnvironmentVar
  #   - model-name: VolumeMount
  #   - model-name: ScaleRuleAuth
  #   - model-name: SecretVolumeItem
  #   - model-name: ContainerAppProbeHttpGetHttpHeadersItem

  - where:
      parameter-name: ComponentName
    set:
      parameter-name: DaprName
  - where:
      parameter-name: EnvironmentName
    set:
      parameter-name: EnvName

  - where:
      model-name: ManagedEnvironment
    set:
      format-table:
        properties:
          - Location
          - Name
          - ResourceGroupName
  - where:
      model-name: ContainerApp
    set:
      format-table:
        properties:
          - Location
          - Name
          - ResourceGroupName
  - where:
      model-name: Revision
    set:
      format-table:
        properties:
          - Name
          - Active
          - TrafficWeight
          - ProvisioningState
          - ResourceGroupName
  - where:
      model-name: DaprComponent
    set:
      format-table:
        properties:
          - Name
          - ComponentType
          - IgnoreError
          - InitTimeout
          - ResourceGroupName
          - Version
  - where:
      model-name: ManagedEnvironmentStorage
    set:
      format-table:
        properties:
          - Name
          - AzureFileAccessMode
          - AzureFileAccountName
          - AzureFileShareName
          - ResourceGroupName
  - where:
      model-name: Certificate
    set:
      format-table:
        properties:
          - Name
          - Location
          - Issuer
          - ProvisioningState
          - SubjectName
          - Thumbprint
          - ResourceGroupName
  - where:
      model-name: AuthConfig
    set:
      format-table:
        properties:
          - Name
          - PlatformEnabled
          - ResourceGroupName

  # - where:
  #     subject: ContainerAppSourceControl
  #   remove: true
  # - where:
  #     verb: Update
  #     subject: ContainerAppManagedEnv
  #   remove: true
  # - where:
  #     subject: ContainerAppRevisionReplica
  #   remove: true
  # - where:
  #     subject: ContainerAppCustomHostName
  #   remove: true
```
