<!-- region Generated -->
# Az.App
This directory contains the PowerShell module for the App service.

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
For information on how to develop for `Az.App`, see [how-to.md](how-to.md).
<!-- endregion -->

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 5b51ccefb0ba7799bbeac5e5460d9eec84ce55fa
require:
  - $(this-folder)/../../readme.azure.noprofile.md
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
subject-prefix: ''

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true
auto-switch-view: false
disable-transform-identity-type: true
flatten-userassignedidentity: false

use-extension: 
  "@autorest/powershell": "4.x"

directive:
  - from: swagger-document 
    where: $.definitions.Certificate.properties.properties.properties.password
    transform: >-
      return {
        "description": "Certificate password",
        "type": "string",
        "format": "password",
        "x-ms-secret": true
      }
  - from: swagger-document 
    where: $.definitions.CustomDomainConfiguration.properties.certificatePassword
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
  - from: swagger-document 
    where: $.definitions.GithubActionConfiguration.properties.githubPersonalAccessToken
    transform: >-
      return {
        "description": "One time Github PAT to configure github environment",
        "type": "string",
        "x-ms-mutability": [
          "create",
          "update"
        ],
        "format": "password",
        "x-ms-secret": true
      }
  - from: swagger-document 
    where: $.definitions.RegistryInfo.properties.registryPassword
    transform: >-
      return {
        "description": "registry secret.",
        "type": "string",
        "x-ms-mutability": [
          "create",
          "update"
        ],
        "format": "password",
        "x-ms-secret": true
      }
  - from: swagger-document 
    where: $.definitions.AzureCredentials.properties.clientSecret
    transform: >-
      return {
        "description": "Client Secret.",
        "type": "string",
        "x-ms-mutability": [
          "create",
          "update"
        ],
        "format": "password",
        "x-ms-secret": true
      }

  - where:
      variant: ^(Create|Update).*(?<!Expanded|JsonFilePath|JsonString)$
    remove: true
  - where:
      variant: ^CheckViaIdentity$|^CheckViaIdentityExpanded$
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
      subject: ContainerAppConnectedEnv
  - where:
      subject: ConnectedEnvironmentsCertificate
    set:
      subject: ContainerAppConnectedEnvCert
  - where:
      subject: ConnectedEnvironmentsDaprComponent
    set:
      subject: ContainerAppConnectedEnvDapr
  - where:
      subject: ConnectedEnvironmentsDaprComponentSecret
    set:
      subject: ContainerAppConnectedEnvDaprSecret
  - where:
      subject: ConnectedEnvironmentsStorage
    set:
      subject: ContainerAppConnectedEnvStorage
  - where:
      subject: ManagedCertificate
    set:
      subject: ContainerAppManagedCert
  - where:
      subject: ManagedEnvironmentAuthToken
    set:
      subject: ContainerAppManagedEnvAuthToken
  - where:
      subject: ManagedEnvironmentDiagnosticDetector
    set:
      subject: ContainerAppManagedEnvDiagnosticDetector
  - where:
      subject: ManagedEnvironmentsDiagnosticRoot
    set:
      subject: ContainerAppManagedEnvDiagnosticRoot
  - where:
      subject: ManagedEnvironmentWorkloadProfileState
    set:
      subject: ContainerAppManagedEnvWorkloadProfileState
  - where:
      subject: ConnectedEnvironmentNameAvailability
    set:
      subject: ContainerAppConnectedEnvNameAvailability
  - where:
      subject: NamespaceNameAvailability
    set:
      subject: ContainerAppNamespaceAvailability

  - where:
      subject: AvailableWorkloadProfile
    set:
      subject: ContainerAppAvailableWorkloadProfile
  - where:
      subject: BillingMeter
    set:
      subject: ContainerAppBillingMeter
  - where:
      subject: Job
    set:
      subject: ContainerAppJob
  - where:
      subject: JobSecret
    set:
      subject: ContainerAppJobSecret
  - where:
      subject: JobsExecution
    set:
      subject: ContainerAppJobExecution
  - where:
      subject: JobExecution
    set:
      subject: ContainerAppJobExecution
  - where:
      subject: JobMultipleExecution
    set:
      subject: ContainerAppJobMultipleExecution
    remove: true

  - where:
      verb: Get
      subject: ContainerAppJobExecution
    remove: true
  - where:
      verb: Invoke
      subject: ContainerAppJobExecution
    set:
      verb: Get

  # Modifications were made to the command
  - model-cmdlet:
    - model-name: RegistryCredentials
      cmdlet-name: New-AzContainerAppRegistryCredentialObject
    - model-name: Secret
      cmdlet-name: New-AzContainerAppSecretObject
    - model-name: JobScaleRule
      cmdlet-name: New-AzContainerAppJobScaleRuleObject
    - model-name: Container
      cmdlet-name: New-AzContainerAppTemplateObject
    - model-name: InitContainer
      cmdlet-name: New-AzContainerAppInitContainerTemplateObject
    - model-name: Volume
      cmdlet-name: New-AzContainerAppVolumeObject
    - model-name: DaprMetadata
      cmdlet-name: New-AzContainerAppDaprMetadataObject
    - model-name: WorkloadProfile
      cmdlet-name: New-AzContainerAppWorkloadProfileObject
    - model-name: IdentityProviders
      cmdlet-name: New-AzContainerAppIdentityProviderObject
    - model-name: Configuration
      cmdlet-name: New-AzContainerAppConfigurationObject
    - model-name: ScaleRule
      cmdlet-name: New-AzContainerAppScaleRuleObject
    - model-name: ServiceBind
      cmdlet-name: New-AzContainerAppServiceBindObject
    - model-name: JobExecutionContainer
      cmdlet-name: New-AzContainerAppJobExecutionContainerObject
    - model-name: CustomDomain
      cmdlet-name: New-AzContainerAppCustomDomainObject
    - model-name: IPSecurityRestrictionRule
      cmdlet-name: New-AzContainerAppIPSecurityRestrictionRuleObject
    - model-name: TrafficWeight
      cmdlet-name: New-AzContainerAppTrafficWeightObject
    - model-name: ContainerAppProbe
      cmdlet-name: New-AzContainerAppProbeObject
    - model-name: EnvironmentVar
      cmdlet-name: New-AzContainerAppEnvironmentVarObject
    - model-name: VolumeMount
      cmdlet-name: New-AzContainerAppVolumeMountObject
    - model-name: ScaleRuleAuth
      cmdlet-name: New-AzContainerAppScaleRuleAuthObject
    - model-name: SecretVolumeItem
      cmdlet-name: New-AzContainerAppSecretVolumeItemObject
    - model-name: ContainerAppProbeHttpGetHttpHeadersItem
      cmdlet-name: New-AzContainerAppProbeHeaderObject

  - where:
      parameter-name: ComponentName
    set:
      parameter-name: DaprName
  - where:
      parameter-name: EnvironmentName
    set:
      parameter-name: EnvName
  - where:
      parameter-name: AzureCredentialsClientId
    set:
      parameter-name: AzureClientId
  - where:
      parameter-name: AzureCredentialsClientSecret
    set:
      parameter-name: AzureClientSecret
  - where:
      parameter-name: AzureCredentialsTenantId
    set:
      parameter-name: AzureTenantId
  - where:
      parameter-name: AzureCredentialsKind
    set:
      parameter-name: AzureKind
  - where:
      parameter-name: AzureCredentialsSubscriptionId
    set:
      parameter-name: AzureSubscriptionId
  - where:
      parameter-name: AzureCredentialsTenantId
    set:
      parameter-name: AzureTenantId
  - where:
      parameter-name: GithubActionConfigurationContextPath
    set:
      parameter-name: GithubContextPath
  - where:
      parameter-name: GithubActionConfigurationImage
    set:
      parameter-name: GithubConfigurationImage
  - where:
      parameter-name: GithubActionConfigurationGithubPersonalAccessToken
    set:
      parameter-name: GithubAccessToken
  - where:
      parameter-name: GithubActionConfigurationOS
    set:
      parameter-name: GithubOS
  - where:
      parameter-name: GithubActionConfigurationPublishType
    set:
      parameter-name: GithubPublishType
  - where:
      parameter-name: GithubActionConfigurationRuntimeStack
    set:
      parameter-name: GithubRuntimeStack
  - where:
      parameter-name: GithubActionConfigurationRuntimeVersion
    set:
      parameter-name: GithubRuntimeVersion
  - where:
      parameter-name: RegistryInfoRegistryPassword
    set:
      parameter-name: RegistryPassword
  - where:
      parameter-name: RegistryInfoRegistryUrl
    set:
      parameter-name: RegistryUrl
  - where:
      parameter-name: RegistryInfoRegistryUserName
    set:
      parameter-name: RegistryUserName
  - where:
      parameter-name: CustomDomainConfigurationCertificatePassword
    set:
      parameter-name: CustomDomainPassword
  - where:
      subject: ContainerAppConnectedEnvCert
      parameter-name: CertificateName
    set:
      parameter-name: Name
      alias: CertificateName
  - where:
      subject: ContainerAppConnectedEnvDapr
      parameter-name: DaprName
    set:
      parameter-name: Name
      alias: DaprName
  - where:
      subject: ContainerAppConnectedEnvStorage
      parameter-name: StorageName
    set:
      parameter-name: Name
      alias: StorageName
  - where:
      subject: ContainerAppAuthConfig
      parameter-name: AuthConfigName
    set:
      parameter-name: Name
      alias: AuthConfigName
  - where:
      subject: ContainerAppSourceControl
      parameter-name: SourceControlName
    set:
      parameter-name: Name
      alias: SourceControlName
  - where:
      subject: ContainerAppManagedEnv
      parameter-name: EnvName
    set:
      parameter-name: Name
      alias: EnvName
  - where:
      subject: ContainerAppManagedEnvDapr
      parameter-name: DaprName
    set:
      parameter-name: Name
      alias: DaprName
  - where:
      subject: ContainerAppManagedEnvStorage
      parameter-name: StorageName
    set:
      parameter-name: Name
      alias: StorageName
  - where:
      subject: ContainerAppRevision
      parameter-name: RevisionName
    set:
      parameter-name: Name
      alias: RevisionName
  - where:
      subject: ContainerAppRevisionReplica
      parameter-name: ReplicaName
    set:
      parameter-name: Name
      alias: ReplicaName
  - where:
      subject: ContainerAppManagedEnvDiagnosticDetector
      parameter-name: DetectorName
    set:
      parameter-name: Name
      alias: DetectorName

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
  - where:
      model-name: ConnectedEnvironment
    set:
      format-table:
        properties:
          - Location
          - Name
          - ResourceGroupName
  - where:
      model-name: ConnectedEnvironmentStorage
    set:
      format-table:
        properties:
          - Name
          - AzureFileAccessMode
          - AzureFileAccountName
          - AzureFileShareName
          - ResourceGroupName
  - where:
      model-name: Job
    set:
      format-table:
        properties:
          - Location
          - Name
          - ProvisioningState
          - ResourceGroupName
  - where:
      model-name: SourceControl
    set:
      format-table:
        properties:
          - Branch
          - Name
          - RepoUrl
          - RegistryInfoRegistryUserName
          - ResourceGroupName
  - where:
      model-name: ContainerAppAuthToken
    set:
      format-table:
        properties:
          - Location
          - Name
          - ResourceGroupName
  - where:
      model-name: EnvironmentAuthToken
    set:
      format-table:
        properties:
          - Location
          - Name
          - ResourceGroupName
  - where:
      model-name: AvailableWorkloadProfile
    set:
      format-table:
        properties:
          - Name
          - Location
  - where:
      model-name: BillingMeterCollection
    set:
      format-table:
        properties:
          - Name
          - Location
  - where:
      model-name: Diagnostics
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
  - where:
      model-name: Replica
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
  - where:
      model-name: ReplicaCollection
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
  - where:
      model-name: WorkloadProfileStates
    set:
      format-table:
        properties:
          - Name
  - where:
      model-name: ManagedCertificate
    set:
      format-table:
        properties:
          - Name
          - SubjectName
          - Location
          - ResourceGroupName
          - DomainControlValidation

  # This command requires the user to provide the github token, but the command is missing this parameter, 
  # so the command cannot be used normally. Wait for the next version to fix the problem
  - where:
      verb: Remove
      subject: ContainerAppSourceControl
    remove: true

##### announce upcoming MI-related breaking changes
  - where:
      parameter-name: IdentityType
    set:
      breaking-change:
        change-description: IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.0.0
        change-effective-date: 2024/11/19
  - where:
      parameter-name: IdentityUserAssignedIdentity
    set:
      breaking-change:
        old-parameter-type: Hashtable
        new-parameter-type: string[]
        change-description: IdentityUserAssignedIdentity will be renamed to UserAssignedIdentity. And its type will be simplified as string array.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.0.0
        change-effective-date: 2024/11/19
```
