<!-- region Generated -->
# Az.MachineLearningServices
This directory contains the PowerShell module for the MachineLearningServices service.

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
For information on how to develop for `Az.MachineLearningServices`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: d4782cf23e78d441b42d06defad8116fc85d8459
require:
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/machinelearningservices/resource-manager/readme.md
# input-file:
#   - $(repo)/specification/machinelearningservices/resource-manager/Microsoft.MachineLearningServices/stable/2024-04-01/machineLearningServices.json
#   - $(repo)/specification/machinelearningservices/resource-manager/Microsoft.MachineLearningServices/stable/2024-04-01/mfe.json
#   - $(repo)/specification/machinelearningservices/resource-manager/Microsoft.MachineLearningServices/stable/2024-04-01/workspaceFeatures.json
#   - $(repo)/specification/machinelearningservices/resource-manager/Microsoft.MachineLearningServices/stable/2024-04-01/registries.json

subject-prefix: MLWorkspace
title: MachineLearningServices
inlining-threshold: 200
resourcegroup-append: true
nested-object-to-string: true
identity-correction-for-post: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  # Fix URL type in autorest v3
  - from: swagger-document
    where: $.definitions.WorkspaceConnectionOAuth2.properties.authUrl
    transform: >-
      return {
          "description": "Required by Concur connection category",
          "type": "string"
      }
  # Add Workspace type enum
  - from: swagger-document
    where: $.definitions.Workspace.properties.kind
    transform: >-
      return {
        "type": "string",
        "description": "Type of workspace. Possible values: Default, Hub, Project, FeatureStore.",
        "enum": [
            "Default",
            "Hub",
            "Project",
            "FeatureStore"
          ],
        "x-ms-enum": {
          "name": "WorkspaceType",
          "modelAsString": true
        }
      }
  - from: swagger-document
    where: $.definitions.ComponentVersion.properties.componentSpec
    transform: >-
      return {
          "type": "object",
          "additionalProperties": true,
          "description": "Defines Component definition details.\r\n<see href=\"https://learn.microsoft.com/en-us/azure/machine-learning/reference-yaml-component-command\" />"
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/connections/{connectionName}"].put
    transform: >-
      $["description"] = "Creating or updating a new workspace connection"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/connections/{connectionName}"].get
    transform: >-
      $["description"] = "Get a new workspace connection"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/connections/{connectionName}"].delete
    transform: >-
      $["description"] = "Remove a new workspace connection"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/computes/{computeName}/start"].post.responses
    transform: >-
      return {
            "200": {
              "description": "Success."
            },
            "202": {
              "description": "Success."
            },
            "default": {
              "description": "Error response describing why the operation failed.",
              "schema": {
                "$ref": "../../../../../common-types/resource-management/v3/types.json#/definitions/ErrorResponse"
              }
            }
          }

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/computes/{computeName}/stop"].post.responses
    transform: >-
      return {
            "200": {
              "description": "Success."
            },
            "202": {
              "description": "Success."
            },
            "default": {
              "description": "Error response describing why the operation failed.",
              "schema": {
                "$ref": "../../../../../common-types/resource-management/v3/types.json#/definitions/ErrorResponse"
              }
            }
          }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/computes/{computeName}/restart"].post.responses
    transform: >-
      return {
            "200": {
              "description": "Success."
            },
            "202": {
              "description": "Success."
            },
            "default": {
              "description": "Error response describing why the operation failed.",
              "schema": {
                "$ref": "../../../../../common-types/resource-management/v3/types.json#/definitions/ErrorResponse"
              }
            }
          }
  # Fix the parameter 'Name' has multiple parameter types [String, String[]] defined, which is not supported.
  - where:
      verb: Get
      subject: Datastore
      variant: ^List$
      parameter-name: Name
    set:
      parameter-name: SearchName

  # All root resources except workspace will use AzMLService as noun prefix.
  - where:
      subject: Usage
    set:
      subject-prefix: MLService

  - where:
      subject: Quota
    set:
      subject-prefix: MLService

  - where:
      subject: VirtualMachineSize
    set:
      subject-prefix: MLService
      subject: VMSize
  - where:
      subject-prefix: MlWorkspace
    set:
      subject-prefix: MLWorkspace
  - where:
      subject-prefix: Ml
    set:
      subject-prefix: ML
  # Fix double name for name of Feature
  - where:
      parameter-name: FeatureName
    set:
      parameter-name: Name
    # Fix double name for feature of cmdlet "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/featuresets/{featuresetName}/versions/{featuresetVersion}/features"
  - where:
      verb: Get
      subject: Feature
    # set:
    #   subject: FeatureWithVersion
    remove: true

  - where:
      verb: Invoke
      subject: ResyncWorkspaceKey
    set:
      verb: Sync
      subject: Key

  - where:
      subject: DiagnoseWorkspace
    set:
      subject: Diagnose
      
  - where:
      subject: PrepareWorkspaceNotebook
    set:
      subject: Notebook

  # Following are common directives which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required
  - where:
      # variant: ^(Create|Update)(?!.*?Expanded)
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true

  # Custom workspace connect
  - where:
      subject: WorkspaceConnection
      verb: New
    hide: true

  # Remove private cmdlets. it been supported in the Az.Network.
  - where:
      subject: PrivateEndpointConnection|PrivateLinkResource
    remove: true
  # Remove Set cmdlets
  - where:
      verb: Set
    remove: true

  # Remove unnecessary variant of the environment
  - where:
      verb: Get
      subject: OnlineDeploymentLog
      variant: ^Get$|^GetViaIdentity$|^GetViaIdentityExpanded$
    remove: true
  # Remove unexpanded variant of Diagnose
  - where:
      verb: Invoke
      subject: Diagnose
      variant: ^Diagnose$|^DiagnoseViaIdentity$
    remove: true
  # Remove unexpanded variant of online endpoint key
  - where:
      verb: New
      subject: OnlineEndpointKey
      variant: ^Regenerate$|^RegenerateViaIdentity$|^RegenerateViaIdentityExpanded$
    remove: true
  # Unsupported Get and New operations.
  - where:
      subject: ^CodeContainer$
    hide: true
  #  InternalServerError
  - where:
      verb: New
      subject: ^EnvironmentContainer$
    hide: true

  # List unsupported
  - where:
      verb: Get
      subject: CodeVersion
      variant: ^List$
    hide: true
  # ListKeys is not supported
  - where:
      subject: BatchEndpointKey
    hide: true

  # Hide unnecessary cmdlet
  - where:
      subject: ConnectionSecret|CodeVersionStartPendingUpload|Featureset(.*)|Featurestore(.*)|Registry(.*)
    hide: true
  - where:
      subject: Schedule|ServerlessEndpoint|ServerlessEndpointKey|ManagedNetworkSettingsRule|MarketplaceSubscription
    hide: true
  - where:
      subject: ManagedNetworkProvisionManagedNetwork|ManagedNetworkSettingRule
      verb: New
    hide: true
  - where:
      subject: CodeVersion|ComponentVersion|DataVersion|EnvironmentVersion|ModelVersion
      verb: Publish
    hide: true
  # rename parameters
  - where:
      subject: BatchEndpoint
      parameter-name: EndpointPropertiesBaseProperty
    set:
      parameter-name: EndpointProperties
  - where:
      subject: BatchDeployment
      parameter-name: EndpointDeploymentPropertiesBaseProperty
    set:
      parameter-name: EndpointDeploymentProperties

  - where:
      subject: WorkspaceConnection
      parameter-name: ConnectionName
    set:
      parameter-name: Name

  - where:
      verb: Invoke
      subject: Diagnose
      parameter-name: Value(.*)
    set:
      parameter-name: $1
  - where:
      verb: Invoke
      subject: Diagnose
      parameter-name: ApplicationInsight
    set:
      parameter-name: ApplicationInsightId 

  - where:
      verb: Invoke
      subject: Diagnose
      parameter-name: ContainerRegistry
    set:
      parameter-name: ContainerRegistryId

  - where:
      verb: Invoke
      subject: Diagnose
      parameter-name: KeyVault
    set:
      parameter-name: KeyVaultId 

  - where:
      verb: Invoke
      subject: Diagnose
      parameter-name: KeyVault
    set:
      parameter-name: StorageAccountId 

  - where:
      verb: New
      subject: Datastore
      parameter-name: Property
    set:
      parameter-name: Datastore

  - where:
      verb: New
      subject: Compute
      parameter-name: Property
    set:
      parameter-name: Compute
  - where:
      verb: New|Update
      subject: ""
      parameter-name: ApplicationInsight
    set:
      parameter-name: ApplicationInsightId

  - where:
      verb: New|Update
      subject: ""
      parameter-name: ContainerRegistry
    set:
      parameter-name: ContainerRegistryId

  - where:
      verb: New|Update
      subject: Workspace
      parameter-name: KeyVault
    set:
      parameter-name: KeyVaultId

  - where:
      verb: New|Update
      subject: Workspace
      parameter-name: KeyVaultPropertyIdentityClientId
    set:
      parameter-name: KeyVaultIdentityClientId
  - where:
      verb: New|Update
      subject: Workspace
      parameter-name: KeyVaultPropertyKeyIdentifier
    set:
      parameter-name: KeyVaultKeyIdentifier
  - where:
      verb: New|Update
      subject: Workspace
      parameter-name: KeyVaultPropertyKeyVaultArmId
    set:
      parameter-name: KeyVaultArmId

  - where:
      verb: New|Update
      subject: Workspace
      parameter-name: PropertiesEncryptionIdentityUserAssignedIdentity
    set:
      parameter-name: EncryptionUserAssignedIdentity

  - where:
      verb: New|Update
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: IdentityUserAssigned

  - where:
      verb: New|Update
      parameter-name: StorageAccount
    set:
      parameter-name: StorageAccountId

  - where:
      subject: ComputeKey|ComputeNode
      parameter-name: ComputeName
    set:
      parameter-name: Name
  - where:
      subject: Compute
      parameter-name: ScaleSetting(.*)
    set:
      parameter-name: $1

  - where:
      subject: Job
      parameter-name: Id
    set:
      parameter-name: Name
  - where:
      subject: Job
      parameter-name: Property
    set:
      parameter-name: Job

  - where:
      subject: OnlineDeployment|OnlineDeploymentLog|DeploymentSku|BatchDeployment
      parameter-name: DeploymentName
    set:
      parameter-name: Name

  - where:
      subject: OnlineDeployment|BatchDeployment
      parameter-name: CodeConfigurationCodeId
    set:
      parameter-name: CodeId

  - where:
      subject: OnlineDeployment|BatchDeployment
      parameter-name: CodeConfigurationScoringScript
    set:
      parameter-name: CodeScoringScript

  - where:
      subject: OnlineDeployment
      parameter-name: RequestSettingMaxConcurrentRequestsPerInstance
    set:
      parameter-name: RequestMaxConcurrentPerInstance

  - where:
      subject: OnlineDeployment
      parameter-name: RequestSettingMaxQueueWait
    set:
      parameter-name: RequestMaxQueueWait

  - where:
      subject: OnlineDeployment
      parameter-name: RequestSettingRequestTimeout
    set:
      parameter-name: RequestTimeout

  - where:
      subject: OnlineDeployment
      parameter-name: ScaleSettingScaleType
    set:
      parameter-name: ScaleType

  - where:
      subject: BatchDeployment
      parameter-name: RetrySettingMaxRetry
    set:
      parameter-name: RetryMax
  - where:
      subject: BatchDeployment
      parameter-name: RetrySettingTimeout
    set:
      parameter-name: RetryTimeout
  - where:
      subject: BatchDeployment
      parameter-name: Compute
    set:
      parameter-name: ComputeId

  - where:
      subject: OnlineEndpoint|OnlineEndpointKey|OnlineEndpointToken|BatchEndpoint
      parameter-name: EndpointName
    set:
      parameter-name: Name
  
  - where:
      subject: BatchEndpoint
      parameter-name: KeyPrimaryKey
    set:
      parameter-name: PrimaryKey

  - where:
      subject: BatchEndpoint
      parameter-name: KeySecondaryKey
    set:
      parameter-name: SecondaryKey

  - where:
      subject: ^WorkspaceKey$|^WorkspaceFeature$|^Diagnose$|^WorkspaceStorageAccountKey$|^Key$
      parameter-name: WorkspaceName
    set:
      parameter-name: Name

  - where:
      subject: ^Diagnose$
      parameter-name: Others
    set:
      parameter-name: Other
#   # Bug: https://github.com/Azure/autorest.powershell/issues/952
#   - from: source-file-csharp
#     where: $
#     transform: $ = $.replace(/\(await response\)\.SecretsType/g, '\(await response\)')

  - no-inline:
# Datastore
    - Datastore
    - DatastoreCredentials
    - AccountKeyDatastoreCredentials
    - CertificateDatastoreCredentials
    - NoneDatastoreCredentials
    - SasDatastoreCredentials
    - ServicePrincipalDatastoreCredentials
# Compute
    - Compute
# Job
    - JobBase
# Model
    - AssetReferenceBase
# Connection
    - WorkspaceConnectionPropertiesV2
    - WorkspaceConnectionPropertiesV2BasicResource
  - model-cmdlet:
# Compute type: 'AKS', 'Kubernetes', 'AmlCompute', 'ComputeInstance','DataFactory', 'VirtualMachine', 'HDInsight', 'Databricks', 'DataLakeAnalytics', 'SynapseSpark'
    # New-AzMLWorkspaceAmlComputeObject
    # - AmlCompute
    # - ComputeInstance
    # cmdlet-name: New-AzMLWorkspaceComputeInstanceObject
    # - Aks 
    # cmdlet-name: New-AzMLWorkspaceAksObject
    # - Kubernetes
    #cmdlet-name: New-AzMLWorkspaceKubernetesObject
    # - VirtualMachine
    # cmdlet-name: New-AzMLWorkspaceVirtualMachineObject
    # - HDInsight 
    # cmdlet-name: New-AzMLWorkspaceHDInsightObject
    # - DataFactory
    # cmdlet-name: New-AzMLWorkspaceDataFactoryObject
    # - Databricks
    # cmdlet-name: New-AzMLWorkspaceDatabricksObject
    # - DataLakeAnalytics
    # cmdlet-name: New-AzMLWorkspaceDataLakeAnalyticsObject
    # - SynapseSpark
    # cmdlet-name: New-AzMLWorkspaceSynapseSparkObject
    - ComputeStartStopSchedule
# Datastore
    # Datastore Type
    # - AzureBlobDatastore 
    # cmdlet-name: New-AzMLWorkspaceDatastoreBlobObject
    # - AzureDataLakeGen1Datastore 
    # cmdlet-name: New-AzMLWorkspaceDatastoreDataLakeGen1Object
    # - AzureDataLakeGen2Datastore 
    # cmdlet-name: New-AzMLWorkspaceDatastoreDataLakeGen2Object
    # - AzureFileDatastore 
    # cmdlet-name: New-AzMLWorkspaceDatastoreFileObject
    # Credentials Type: 'AccountKey', 'Certificate', 'None', 'Sas', 'ServicePrincipal'
    # - AccountKeyDatastoreCredentials 
    # cmdlet-name: New-AzMLWorkspaceDatastoreKeyCredentialObject
    # - CertificateDatastoreCredentials
    # cmdlet-name: New-AzMLWorkspaceDatastoreCredentialsObject
    # - NoneDatastoreCredentials
    # cmdlet-name: New-AzMLWorkspaceDatastoreNoneCredentialsObject
    # - SasDatastoreCredentials
    # cmdlet-name: New-AzMLWorkspaceDatastoreSasCredentialsObject
    # - ServicePrincipalDatastoreCredentials
    # cmdlet-name: New-AzMLWorkspaceDatastoreServicePrincipalCredentialsObject
  # Job type
    # - CommandJob
    # -> New-AzMLWorkspaceCommandJobObject
    # - PipelineJob
    # cmdlet-name: New-AzMLWorkspacePipelineJobObject
    # - SweepJob
    # cmdlet-name: New-AzMLWorkspaceSweepJobObject
  # Job input and output
    - CustomModelJobInput
    - CustomModelJobOutput
    - LiteralJobInput
    - MLFlowModelJobInput
    - MLFlowModelJobOutput
    - MLTableJobInput
    - MLTableJobOutput
    - TritonModelJobInput
    - TritonModelJobOutput
    - UriFileJobInput
    - UriFileJobOutput
    - UriFolderJobInput
    - UriFolderJobOutput
    - JobService
    - SharedPrivateLinkResource
    # - QuotaBaseProperties
    # cmdlet-name: New-AzMLWorkspaceQuotaPropertiesObject
  # Model
    # - DataPathAssetReference
    # - IdAssetReference
    # - OutputPathAssetReference
  # Connection
    # - WorkspaceConnectionPropertiesV2Metadata #additionalProperties
    # - AadAuthTypeWorkspaceConnectionProperties
    # - AccessKeyAuthTypeWorkspaceConnectionProperties
    # - AccountKeyAuthTypeWorkspaceConnectionProperties
    # - ApiKeyAuthWorkspaceConnectionProperties
    # - CustomKeysWorkspaceConnectionProperties
    # - ManagedIdentityAuthTypeWorkspaceConnectionProperties
    # - NoneAuthTypeWorkspaceConnectionProperties
    # - OAuth2AuthTypeWorkspaceConnectionProperties
    # - PatAuthTypeWorkspaceConnectionProperties
    # - SasAuthTypeWorkspaceConnectionProperties
    # - ServicePrincipalAuthTypeWorkspaceConnectionProperties
    # - UsernamePasswordAuthTypeWorkspaceConnectionProperties
```
