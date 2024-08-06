<!-- region Generated -->
# Az.HdInsightOnAks
This directory contains the PowerShell module for the HdInsightOnAks service.

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
For information on how to develop for `Az.HdInsightOnAks`, see [how-to.md](how-to.md).
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
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

### General settings
> Values
``` yaml
tag: package-preview-2024-05
commit: c766bb559e93067acf5a852e63f7edcee75a2f5b
require:
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/hdinsight/resource-manager/Microsoft.HDInsight/HDInsightOnAks/readme.md
inlining-threshold: 200
```

> Names
``` yaml
module-version: 0.1.0
title: HdInsightOnAks
subject-prefix: "$(service-name)"
```

> Exclude some properties in table view
``` yaml
# For a specific module, we could override this configuration by setting default-exclude-tableview-properties to false in readme.md of that module.
default-exclude-tableview-properties: true
```

> Directives
``` yaml
identity-correction-for-post: true
directive:
  - model-cmdlet:
    - model-name: ManagedIdentitySpec
      cmdlet-name: New-AzHdInsightOnAksManagedIdentityObject
    - model-name: ClusterPoolAksPatchVersionUpgradeProperties
      cmdlet-name: New-AzHdInsightOnAksClusterPoolAksPatchVersionUpgradeObject
    - model-name: NodeProfile
      cmdlet-name: New-AzHdInsightOnAksNodeProfileObject
    - model-name: SecretReference
      cmdlet-name: New-AzHdInsightOnAksSecretReferenceObject
    - model-name: HiveCatalogOption
      cmdlet-name: New-AzHdInsightOnAksTrinoHiveCatalogObject
    - model-name: ClusterConfigFile
      cmdlet-name: New-AzHdInsightOnAksClusterConfigFileObject
    - model-name: ClusterServiceConfig
      cmdlet-name: New-AzHdInsightOnAksClusterServiceConfigObject
    - model-name: ClusterServiceConfigsProfile
      cmdlet-name: New-AzHdInsightOnAksClusterServiceConfigsProfileObject
  - from: swagger-document
    where: $.paths..responses.202
    transform: delete $.headers
  - where:
      parameter-name: SubscriptionId
    set:
      default:
        name: SubscriptionId Default
        description: Gets the SubscriptionId from the current context.
        script: '(Get-AzContext).Subscription.Id'    
  - where:
      model-name: ClusterPoolListResult
    set:
      suppress-format: true
  - where:
      model-name: ClusterPool
    set:
      suppress-format: true
  - where:
      model-name: Cluster
    set:
      suppress-format: true
  - where:
      model-name: ClusterInstanceViewResult
    set:
      suppress-format: true
  - where:
      model-name: ClusterOfferingVersions
    set:
      suppress-format: true
  - where:
      model-name: ClusterServiceConfig
    set:
      suppress-format: true
  - where:
      model-name: ClusterPoolVersion
    set:
      suppress-format: true
  - where:
      model-name: ClusterPoolVersion
      property-name: PropertiesClusterPoolVersion
    set:
      property-name: ClusterPoolVersionValue
  - where:
      model-name: ClusterVersion
    set:
      suppress-format: true
  - where:
      model-name: ClusterVersion
      property-name: PropertiesClusterVersion
    set:
      property-name: ClusterVersionValue
  - where:
      model-name: SecretReference
      property-name: KeyVaultObjectName
    set:
      property-name: SecretName   
  - where:
      model-name: ClusterServiceConfig
      property-name: Component
    set:
      property-name: ComponentName  
# the below is cmdlet part      
  - where:
      verb: New|Set
      subject: [Cluster|ClusterPool]
      parameter-name: LogAnalyticProfileEnabled
    set:
      parameter-name: EnableLogAnalytics
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: HdInsightCluster
    set:
      parameter-name: HdInsightOnAksCluster
  - where:
      verb: New|Set
      subject: [Cluster|ClusterPool]
      parameter-name: LogAnalyticProfileWorkspaceId
    set:
      parameter-name: LogAnalyticWorkspaceResourceId
  - where:
      verb: New|Set
      subject: [Cluster|ClusterPool]
      parameter-name: NetworkProfileSubnetId
    set:
      parameter-name: SubnetId     
  - where:
      verb: New|Set
      subject: [ClusterPool]
      parameter-name: ClusterPoolProfileClusterPoolVersion
    set:
      parameter-name: ClusterPoolVersion
  - where:
      verb: New|Set
      subject: [ClusterPool]
      parameter-name: ComputeProfileVMSize
    set:
      parameter-name: VmSize
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: ComputeProfileCount
    set:
      parameter-name: ClusterNodeCount
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: ComputeProfileVMSize
    set:
      parameter-name: ClusterNodeSize
  - where:
      verb: New|Set
      subject: Cluster
      parameter-name: (^AuthorizationProfile)(.*)
    set:
      parameter-name: Authorization$2
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: (^ClusterProfile)(.*)
    set:
      parameter-name: $2
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: IdentityProfileMsiClientId
    set:
      parameter-name: AssignedIdentityClientId
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: IdentityProfileMsiResourceId
    set:
      parameter-name: AssignedIdentityResourceId
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: IdentityProfileMsiObjectId
    set:
      parameter-name: AssignedIdentityObjectId
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: SecretProfileKeyVaultResourceId
    set:
      parameter-name: KeyVaultResourceId
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: SecretProfileSecret
    set:
      parameter-name: SecretReference
# Spark profile related
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: SparkProfileDefaultStorageUrl
    set:
      parameter-name: SparkStorageUrl
# Spark metastore spec related      
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: MetastoreSpecDbName
    set:
      parameter-name: SparkHiveCatalogDbName
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: MetastoreSpecDbServerHost
    set:
      parameter-name: SparkHiveCatalogDbServerName
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: MetastoreSpecDbUserName
    set:
      parameter-name: SparkHiveCatalogDbUserName
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: MetastoreSpecDbPasswordSecretName
    set:
      parameter-name: SparkHiveCatalogDbPasswordSecretName
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: MetastoreSpecKeyVaultId
    set:
      parameter-name: SparkHiveCatalogKeyVaultId
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: MetastoreSpecThriftUrl
    set:
      parameter-name: SparkThriftUrl
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: SparkProfileUserPluginsSpecPlugin
    hide: true
#TrinoProfileCatalogOptionsHive
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: TrinoProfileCatalogOptionsHive
    set:
      parameter-name: TrinoHiveCatalog
# Trino Telemetry
      
# Flink side
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: StorageUri
    set:
      parameter-name: FlinkStorageUrl
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: StorageStoragekey
    hide: true
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: FlinkProfileNumReplica
    set:
      parameter-name: FlinkTaskManagerReplicaCount
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: HiveMetastoreDbConnectionPasswordSecret
    set:
      parameter-name: FlinkHiveCatalogDbPasswordSecretName
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: HiveMetastoreDbConnectionUrl
    set:
      parameter-name: FlinkHiveCatalogDbConnectionUrl
  - where:
      verb: New|Set
      subject: [Cluster]
      parameter-name: HiveMetastoreDbConnectionUserName
    set:
      parameter-name: FlinkHiveCatalogDbUserName
# The below customize the output model   
  - where:
      verb: Update
      subject: [Cluster] 
      variant: [Upgrade|UpgradeExpanded|UpgradeViaIdentity|UpgradeViaIdentityExpanded|UpgradeViaJsonFilePath|UpgradeViaJsonString]
    set:
      verb: Invoke
      subject: ClusterUpgrade
  - where:
      verb: Update
      subject: [ClusterManualRollback] 
      variant: [Upgrade|UpgradeExpanded|UpgradeViaIdentity|UpgradeViaIdentityExpanded|UpgradeViaJsonFilePath|UpgradeViaJsonString]
    set:
      verb: Invoke
  - where:
      verb: Update
      subject: [ClusterPool] 
      variant: [Upgrade|UpgradeExpanded|UpgradeViaIdentity|UpgradeViaIdentityExpanded|UpgradeViaJsonFilePath|UpgradeViaJsonString]
    set:
      verb: Invoke
      subject: ClusterPoolUpgrade
```
