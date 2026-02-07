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

directive:
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
  
  # fix required parameter in model
  - from: swagger-document #mfe.json
    where: $.definitions.AzureDataLakeGen1Datastore.properties.storeName
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document #mfe.json
    where: $.definitions.AzureDataLakeGen2Datastore.properties.accountName
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document #mfe.json
    where: $.definitions.AzureDataLakeGen2Datastore.properties.filesystem
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document #mfe.json
    where: $.definitions.AzureFileDatastore.properties.accountName
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document #mfe.json
    where: $.definitions.AzureFileDatastore.properties.fileShareName
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document #mfe.json
    where: $.definitions.CommandJob.properties.EnvironmentId
    transform: $['x-ms-mutability'] = ["read", "update", "create"]
  - from: swagger-document #mfe.json
    where: $.definitions.TrialComponent.properties.command
    transform: $['x-ms-mutability'] = ["read", "update", "create"]

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
      subject: Usage|Quota
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
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))|^CreateViaIdentityExpanded$
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
      variant: Get(?!.*?Expanded)
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
    remove: true
  - where:
      variant: GetViaIdentityCode|CreateViaIdentityCodeExpanded|UpdateViaIdentityCodeExpanded
    remove: true
  #  InternalServerError
  - where:
      verb: New
      subject: ^EnvironmentContainer$
    remove: true
  # Remove unsupported v4 update cmdlets
  - where:
      subject: Datastore|EnvironmentContainer
      verb: update
    remove: true

  # List unsupported
  - where:
      verb: Get
      subject: CodeVersion
      variant: ^List$
    remove: true
  # ListKeys is not supported
  - where:
      subject: BatchEndpointKey
    remove: true

  # Hide unnecessary cmdlet
  - where:
      subject: ConnectionSecret|CodeVersionStartPendingUpload|Featureset(.*)|Featurestore(.*)|Registry(.*)
    remove: true
  - where:
      subject: Schedule|ServerlessEndpoint|ServerlessEndpointKey|ManagedNetworkSettingsRule|MarketplaceSubscription
    remove: true
  - where:
      subject: ManagedNetworkProvisionManagedNetwork|ManagedNetworkSettingRule
      verb: New
    remove: true
  - where:
      subject: CodeVersion|ComponentVersion|DataVersion|EnvironmentVersion|ModelVersion
      verb: Publish
    remove: true
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
    # - model-name: Aks #Custom parameter names
    # - model-name: AmlCompute
    - model-name: ComputeInstance
    # cmdlet-name: New-AzMLWorkspaceComputeInstanceObject
    # - model-name: Kubernetes #Custom parameter logic, remind you sync parameters
    # cmdlet-name: New-AzMLWorkspaceKubernetesObject
    - model-name: VirtualMachine
    - model-name: HDInsight 
    - model-name: DataFactory
    - model-name: Databricks
    - model-name: DataLakeAnalytics
    - model-name: SynapseSpark
    - model-name: ComputeStartStopSchedule
# Datastore
    # Datastore Type
    - model-name: AzureBlobDatastore 
      cmdlet-name: New-AzMLWorkspaceDatastoreBlobObject
    - model-name: AzureDataLakeGen1Datastore 
      cmdlet-name: New-AzMLWorkspaceDatastoreDataLakeGen1Object
    - model-name: AzureDataLakeGen2Datastore 
      cmdlet-name: New-AzMLWorkspaceDatastoreDataLakeGen2Object
    - model-name: AzureFileDatastore 
      cmdlet-name: New-AzMLWorkspaceDatastoreFileObject
    # Credentials Type: 'AccountKey', 'Certificate', 'None', 'Sas', 'ServicePrincipal'
    # - model-name: AccountKeyDatastoreCredentials # Custom, to expand Key parameter of Secret
    #   cmdlet-name: New-AzMLWorkspaceDatastoreKeyCredentialObject
    # - model-name: CertificateDatastoreCredentials # Custom, to expand Certificate parameter of Secret
    #   cmdlet-name: New-AzMLWorkspaceDatastoreCredentialObject
    - model-name: NoneDatastoreCredentials
      cmdlet-name: New-AzMLWorkspaceDatastoreNoneCredentialObject
    # - model-name: SasDatastoreCredentials #Custom, to expand SasToken parameter of Secret
    #   cmdlet-name: New-AzMLWorkspaceDatastoreSasCredentialObject
    # - model-name: ServicePrincipalDatastoreCredentials #Custom, to expand ClientSecret parameter of Secret
    #   cmdlet-name: New-AzMLWorkspaceDatastoreServicePrincipalCredentialObject
  # Job type
    # - model-name: CommandJob #Custom parameter logic, remind you sync parameters
    # - model-name: PipelineJob #Custom parameter logic, remind you sync parameters
    # - model-name: SweepJob #Custom parameter logic, remind you sync parameters
  # Job input and output
    - model-name: CustomModelJobInput
    - model-name: CustomModelJobOutput
    - model-name: LiteralJobInput
    - model-name: MLFlowModelJobInput
    - model-name: MLFlowModelJobOutput
    - model-name: MLTableJobInput
    - model-name: MLTableJobOutput
    - model-name: TritonModelJobInput
    - model-name: TritonModelJobOutput
    - model-name: UriFileJobInput
    - model-name: UriFileJobOutput
    - model-name: UriFolderJobInput
    - model-name: UriFolderJobOutput
    - model-name: JobService
    - model-name: SharedPrivateLinkResource
    - model-name: QuotaBaseProperties
      cmdlet-name: New-AzMLWorkspaceQuotaPropertiesObject
  # Model
    - model-name: DataPathAssetReference
    - model-name: IdAssetReference
    - model-name: OutputPathAssetReference
  # Connection
    # - model-name: WorkspaceConnectionPropertiesV2Metadata #additionalProperties non-need
    - model-name: AadAuthTypeWorkspaceConnectionProperties
    - model-name: AccessKeyAuthTypeWorkspaceConnectionProperties
    - model-name: AccountKeyAuthTypeWorkspaceConnectionProperties
    - model-name: ApiKeyAuthWorkspaceConnectionProperties
    - model-name: CustomKeysWorkspaceConnectionProperties
    - model-name: ManagedIdentityAuthTypeWorkspaceConnectionProperties
    - model-name: NoneAuthTypeWorkspaceConnectionProperties
    - model-name: OAuth2AuthTypeWorkspaceConnectionProperties
    - model-name: PatAuthTypeWorkspaceConnectionProperties
    - model-name: SasAuthTypeWorkspaceConnectionProperties
    - model-name: ServicePrincipalAuthTypeWorkspaceConnectionProperties
    - model-name: UsernamePasswordAuthTypeWorkspaceConnectionProperties

  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/\\r\\nFor create case, the Tags in the definition passed in will replace Tags in the existing/g, 'For update case, the Tags in the definition passed in will replace Tags in the existing')
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/and executes a Job./g, 'and execute a Job.')
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
  # Breaking change
  - where:
      verb: Get|New|Update
      subject: ^Workspace$|WorkspaceConnection|Job|OnlineDeployment
    set:
      preview-announcement:
        preview-message: "*****************************************************************************************\\r\\n* This cmdlet will undergo a breaking change in Az v16.0.0, to be released in May 2026.           *\\r\\n* At least one change applies to this cmdlet.                                            *\\r\\n* See all possible breaking changes at https://go.microsoft.com/fwlink/?linkid=2333486            *\\r\\n**************************************************************************************************"
  - where:
      verb: New|Update
      subject: BatchEndpoint|OnlineEndpoint|Compute
    set:
      preview-announcement:
        preview-message: "*****************************************************************************************\\r\\n* This cmdlet will undergo a breaking change in Az v16.0.0, to be released in May 2026.          *\\r\\n* EnableSystemAssignedIdentity will replace IdentityType applies to this cmdlet.                 *\\r\\n* See all possible breaking changes at https://go.microsoft.com/fwlink/?linkid=2333486           *\\r\\n**************************************************************************************************"
  - where:
      verb: Get
      subject: Datastore|WorkspaceOutboundNetworkDependencyEndpoint
    set:
      preview-announcement:
        preview-message: "*****************************************************************************************\\r\\n* This cmdlet will undergo a breaking change in Az v16.0.0, to be released in May 2026.           *\\r\\n* At least one change applies to this cmdlet.                                                    *\\r\\n* See all possible breaking changes at https://go.microsoft.com/fwlink/?linkid=2333486            *\\r\\n**************************************************************************************************"
  - where:
      verb: Invoke
      subject: Diagnose
    set:
      preview-announcement:
        preview-message: "*****************************************************************************************\\r\\n* This cmdlet will undergo a breaking change in Az v16.0.0, to be released in May 2026.           *\\r\\n* At least one change applies to this cmdlet.                                                    *\\r\\n* See all possible breaking changes at https://go.microsoft.com/fwlink/?linkid=2333486            *\\r\\n**************************************************************************************************"
```
