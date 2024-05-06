---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/new-azhdinsightonakscluster
schema: 2.0.0
---

# New-AzHdInsightOnAksCluster

## SYNOPSIS
Create a cluster.

## SYNTAX

### CreateExpanded (Default)
```
New-AzHdInsightOnAksCluster -Name <String> -PoolName <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-ApplicationLogStdErrorEnabled] [-ApplicationLogStdOutEnabled]
 [-AssignedIdentityClientId <String>] [-AssignedIdentityObjectId <String>]
 [-AssignedIdentityResourceId <String>] [-AuthorizationGroupId <String[]>] [-AuthorizationUserId <String[]>]
 [-AutoscaleProfileAutoscaleType <String>] [-AutoscaleProfileEnabled]
 [-AutoscaleProfileGracefulDecommissionTimeout <Int32>] [-ClusterAccessProfileEnableInternalIngress]
 [-ClusterType <String>] [-ClusterVersion <String>] [-ComputeProfileNode <INodeProfile[]>]
 [-CoordinatorDebugEnable] [-CoordinatorDebugPort <Int32>] [-CoordinatorDebugSuspend]
 [-CoordinatorHighAvailabilityEnabled] [-DatabaseHost <String>] [-DatabaseName <String>]
 [-DatabasePasswordSecretRef <String>] [-DatabaseUsername <String>] [-DiskStorageDataDiskSize <Int32>]
 [-DiskStorageDataDiskType <String>] [-EnableLogAnalytics] [-FlinkHiveCatalogDbConnectionUrl <String>]
 [-FlinkHiveCatalogDbPasswordSecretName <String>] [-FlinkHiveCatalogDbUserName <String>]
 [-FlinkProfileDeploymentMode <String>] [-FlinkStorageUrl <String>] [-FlinkTaskManagerReplicaCount <Int32>]
 [-HistoryServerCpu <Single>] [-HistoryServerMemory <Int64>]
 [-HiveMetastoreDbConnectionAuthenticationMode <String>] [-JobManagerCpu <Single>] [-JobManagerMemory <Int64>]
 [-JobSpecArg <String>] [-JobSpecEntryClass <String>] [-JobSpecJarName <String>]
 [-JobSpecJobJarDirectory <String>] [-JobSpecSavePointName <String>] [-JobSpecUpgradeMode <String>]
 [-KafkaProfileEnableKRaft] [-KafkaProfileEnablePublicEndpoint] [-KafkaProfileRemoteStorageUri <String>]
 [-KeyVaultResourceId <String>] [-LlapProfile <Hashtable>] [-LoadBasedConfigCooldownPeriod <Int32>]
 [-LoadBasedConfigMaxNode <Int32>] [-LoadBasedConfigMinNode <Int32>] [-LoadBasedConfigPollInterval <Int32>]
 [-LoadBasedConfigScalingRule <IScalingRule[]>] [-LogAnalyticProfileMetricsEnabled]
 [-MetastoreSpecDbConnectionAuthenticationMode <String>] [-OssVersion <String>] [-PrometheuProfileEnabled]
 [-RangerAdmin <String[]>] [-RangerAuditStorageAccount <String>] [-RangerPluginProfileEnabled]
 [-RangerUsersyncEnabled] [-RangerUsersyncGroup <String[]>] [-RangerUsersyncMode <String>]
 [-RangerUsersyncUser <String[]>] [-RangerUsersyncUserMappingLocation <String>]
 [-ScheduleBasedConfigDefaultCount <Int32>] [-ScheduleBasedConfigSchedule <ISchedule[]>]
 [-ScheduleBasedConfigTimeZone <String>] [-ScriptActionProfile <IScriptActionProfile[]>]
 [-SecretReference <ISecretReference[]>] [-ServiceConfigsProfile <IClusterServiceConfigsProfile[]>]
 [-SparkHiveCatalogDbName <String>] [-SparkHiveCatalogDbPasswordSecretName <String>]
 [-SparkHiveCatalogDbServerName <String>] [-SparkHiveCatalogDbUserName <String>]
 [-SparkHiveCatalogKeyVaultId <String>] [-SparkStorageUrl <String>] [-SparkThriftUrl <String>]
 [-SshProfileCount <Int32>] [-StorageHivecatalogName <String>] [-StorageHivecatalogSchema <String>]
 [-StoragePartitionRetentionInDay <Int32>] [-StoragePath <String>] [-StubProfile <Hashtable>]
 [-Tag <Hashtable>] [-TaskManagerCpu <Single>] [-TaskManagerMemory <Int64>]
 [-TrinoHiveCatalog <IHiveCatalogOption[]>] [-TrinoProfileUserPluginsSpecPlugin <ITrinoUserPlugin[]>]
 [-WorkerDebugEnable] [-WorkerDebugPort <Int32>] [-WorkerDebugSuspend] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzHdInsightOnAksCluster -Name <String> -PoolName <String> -ResourceGroupName <String>
 -HdInsightOnAksCluster <ICluster> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzHdInsightOnAksCluster -InputObject <IHdInsightOnAksIdentity> -HdInsightOnAksCluster <ICluster>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityClusterpool
```
New-AzHdInsightOnAksCluster -ClusterpoolInputObject <IHdInsightOnAksIdentity> -Name <String>
 -HdInsightOnAksCluster <ICluster> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityClusterpoolExpanded
```
New-AzHdInsightOnAksCluster -ClusterpoolInputObject <IHdInsightOnAksIdentity> -Name <String>
 -Location <String> [-ApplicationLogStdErrorEnabled] [-ApplicationLogStdOutEnabled]
 [-AssignedIdentityClientId <String>] [-AssignedIdentityObjectId <String>]
 [-AssignedIdentityResourceId <String>] [-AuthorizationGroupId <String[]>] [-AuthorizationUserId <String[]>]
 [-AutoscaleProfileAutoscaleType <String>] [-AutoscaleProfileEnabled]
 [-AutoscaleProfileGracefulDecommissionTimeout <Int32>] [-ClusterAccessProfileEnableInternalIngress]
 [-ClusterType <String>] [-ClusterVersion <String>] [-ComputeProfileNode <INodeProfile[]>]
 [-CoordinatorDebugEnable] [-CoordinatorDebugPort <Int32>] [-CoordinatorDebugSuspend]
 [-CoordinatorHighAvailabilityEnabled] [-DatabaseHost <String>] [-DatabaseName <String>]
 [-DatabasePasswordSecretRef <String>] [-DatabaseUsername <String>] [-DiskStorageDataDiskSize <Int32>]
 [-DiskStorageDataDiskType <String>] [-EnableLogAnalytics] [-FlinkHiveCatalogDbConnectionUrl <String>]
 [-FlinkHiveCatalogDbPasswordSecretName <String>] [-FlinkHiveCatalogDbUserName <String>]
 [-FlinkProfileDeploymentMode <String>] [-FlinkStorageUrl <String>] [-FlinkTaskManagerReplicaCount <Int32>]
 [-HistoryServerCpu <Single>] [-HistoryServerMemory <Int64>]
 [-HiveMetastoreDbConnectionAuthenticationMode <String>] [-JobManagerCpu <Single>] [-JobManagerMemory <Int64>]
 [-JobSpecArg <String>] [-JobSpecEntryClass <String>] [-JobSpecJarName <String>]
 [-JobSpecJobJarDirectory <String>] [-JobSpecSavePointName <String>] [-JobSpecUpgradeMode <String>]
 [-KafkaProfileEnableKRaft] [-KafkaProfileEnablePublicEndpoint] [-KafkaProfileRemoteStorageUri <String>]
 [-KeyVaultResourceId <String>] [-LlapProfile <Hashtable>] [-LoadBasedConfigCooldownPeriod <Int32>]
 [-LoadBasedConfigMaxNode <Int32>] [-LoadBasedConfigMinNode <Int32>] [-LoadBasedConfigPollInterval <Int32>]
 [-LoadBasedConfigScalingRule <IScalingRule[]>] [-LogAnalyticProfileMetricsEnabled]
 [-MetastoreSpecDbConnectionAuthenticationMode <String>] [-OssVersion <String>] [-PrometheuProfileEnabled]
 [-RangerAdmin <String[]>] [-RangerAuditStorageAccount <String>] [-RangerPluginProfileEnabled]
 [-RangerUsersyncEnabled] [-RangerUsersyncGroup <String[]>] [-RangerUsersyncMode <String>]
 [-RangerUsersyncUser <String[]>] [-RangerUsersyncUserMappingLocation <String>]
 [-ScheduleBasedConfigDefaultCount <Int32>] [-ScheduleBasedConfigSchedule <ISchedule[]>]
 [-ScheduleBasedConfigTimeZone <String>] [-ScriptActionProfile <IScriptActionProfile[]>]
 [-SecretReference <ISecretReference[]>] [-ServiceConfigsProfile <IClusterServiceConfigsProfile[]>]
 [-SparkHiveCatalogDbName <String>] [-SparkHiveCatalogDbPasswordSecretName <String>]
 [-SparkHiveCatalogDbServerName <String>] [-SparkHiveCatalogDbUserName <String>]
 [-SparkHiveCatalogKeyVaultId <String>] [-SparkStorageUrl <String>] [-SparkThriftUrl <String>]
 [-SshProfileCount <Int32>] [-StorageHivecatalogName <String>] [-StorageHivecatalogSchema <String>]
 [-StoragePartitionRetentionInDay <Int32>] [-StoragePath <String>] [-StubProfile <Hashtable>]
 [-Tag <Hashtable>] [-TaskManagerCpu <Single>] [-TaskManagerMemory <Int64>]
 [-TrinoHiveCatalog <IHiveCatalogOption[]>] [-TrinoProfileUserPluginsSpecPlugin <ITrinoUserPlugin[]>]
 [-WorkerDebugEnable] [-WorkerDebugPort <Int32>] [-WorkerDebugSuspend] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzHdInsightOnAksCluster -InputObject <IHdInsightOnAksIdentity> -Location <String>
 [-ApplicationLogStdErrorEnabled] [-ApplicationLogStdOutEnabled] [-AssignedIdentityClientId <String>]
 [-AssignedIdentityObjectId <String>] [-AssignedIdentityResourceId <String>]
 [-AuthorizationGroupId <String[]>] [-AuthorizationUserId <String[]>]
 [-AutoscaleProfileAutoscaleType <String>] [-AutoscaleProfileEnabled]
 [-AutoscaleProfileGracefulDecommissionTimeout <Int32>] [-ClusterAccessProfileEnableInternalIngress]
 [-ClusterType <String>] [-ClusterVersion <String>] [-ComputeProfileNode <INodeProfile[]>]
 [-CoordinatorDebugEnable] [-CoordinatorDebugPort <Int32>] [-CoordinatorDebugSuspend]
 [-CoordinatorHighAvailabilityEnabled] [-DatabaseHost <String>] [-DatabaseName <String>]
 [-DatabasePasswordSecretRef <String>] [-DatabaseUsername <String>] [-DiskStorageDataDiskSize <Int32>]
 [-DiskStorageDataDiskType <String>] [-EnableLogAnalytics] [-FlinkHiveCatalogDbConnectionUrl <String>]
 [-FlinkHiveCatalogDbPasswordSecretName <String>] [-FlinkHiveCatalogDbUserName <String>]
 [-FlinkProfileDeploymentMode <String>] [-FlinkStorageUrl <String>] [-FlinkTaskManagerReplicaCount <Int32>]
 [-HistoryServerCpu <Single>] [-HistoryServerMemory <Int64>]
 [-HiveMetastoreDbConnectionAuthenticationMode <String>] [-JobManagerCpu <Single>] [-JobManagerMemory <Int64>]
 [-JobSpecArg <String>] [-JobSpecEntryClass <String>] [-JobSpecJarName <String>]
 [-JobSpecJobJarDirectory <String>] [-JobSpecSavePointName <String>] [-JobSpecUpgradeMode <String>]
 [-KafkaProfileEnableKRaft] [-KafkaProfileEnablePublicEndpoint] [-KafkaProfileRemoteStorageUri <String>]
 [-KeyVaultResourceId <String>] [-LlapProfile <Hashtable>] [-LoadBasedConfigCooldownPeriod <Int32>]
 [-LoadBasedConfigMaxNode <Int32>] [-LoadBasedConfigMinNode <Int32>] [-LoadBasedConfigPollInterval <Int32>]
 [-LoadBasedConfigScalingRule <IScalingRule[]>] [-LogAnalyticProfileMetricsEnabled]
 [-MetastoreSpecDbConnectionAuthenticationMode <String>] [-OssVersion <String>] [-PrometheuProfileEnabled]
 [-RangerAdmin <String[]>] [-RangerAuditStorageAccount <String>] [-RangerPluginProfileEnabled]
 [-RangerUsersyncEnabled] [-RangerUsersyncGroup <String[]>] [-RangerUsersyncMode <String>]
 [-RangerUsersyncUser <String[]>] [-RangerUsersyncUserMappingLocation <String>]
 [-ScheduleBasedConfigDefaultCount <Int32>] [-ScheduleBasedConfigSchedule <ISchedule[]>]
 [-ScheduleBasedConfigTimeZone <String>] [-ScriptActionProfile <IScriptActionProfile[]>]
 [-SecretReference <ISecretReference[]>] [-ServiceConfigsProfile <IClusterServiceConfigsProfile[]>]
 [-SparkHiveCatalogDbName <String>] [-SparkHiveCatalogDbPasswordSecretName <String>]
 [-SparkHiveCatalogDbServerName <String>] [-SparkHiveCatalogDbUserName <String>]
 [-SparkHiveCatalogKeyVaultId <String>] [-SparkStorageUrl <String>] [-SparkThriftUrl <String>]
 [-SshProfileCount <Int32>] [-StorageHivecatalogName <String>] [-StorageHivecatalogSchema <String>]
 [-StoragePartitionRetentionInDay <Int32>] [-StoragePath <String>] [-StubProfile <Hashtable>]
 [-Tag <Hashtable>] [-TaskManagerCpu <Single>] [-TaskManagerMemory <Int64>]
 [-TrinoHiveCatalog <IHiveCatalogOption[]>] [-TrinoProfileUserPluginsSpecPlugin <ITrinoUserPlugin[]>]
 [-WorkerDebugEnable] [-WorkerDebugPort <Int32>] [-WorkerDebugSuspend] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzHdInsightOnAksCluster -Name <String> -PoolName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzHdInsightOnAksCluster -Name <String> -PoolName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a cluster.

## EXAMPLES

### Example 1: Create simple Trino cluster
```powershell
# Create Simple Trino Cluster
$clusterPoolName="{your cluster pool name}";
$resourceGroupName="{your resource group name}";
$location="West US 2";

$clusterType="Trino"
# Get available cluster version based the command Get-AzHdInsightOnAksAvailableClusterVersion
$clusterVersion= (Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | Where-Object {$_.ClusterType -eq $clusterType})[0]

$msiResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/{your resource group name}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{your msi}";
$msiClientId="00000000-0000-0000-0000-000000000000";
$msiObjectId="00000000-0000-0000-0000-000000000000";

$userId="00000000-0000-0000-0000-000000000000";

# create node profile
$vmSize="Standard_E8ads_v5";
$workerCount=5;

$nodeProfile = New-AzHdInsightOnAksNodeProfileObject -Type Worker -Count $workerCount -VMSize $vmSize

$clusterName="{your cluster name}";


New-AzHdInsightOnAksCluster -Name $clusterName `
                            -PoolName $clusterPoolName `
                            -ResourceGroupName $resourceGroupName `
                            -Location $location `
                            -ClusterType $clusterType `
                            -ClusterVersion $clusterVersion.ClusterVersionValue `
                            -OssVersion $clusterVersion.OssVersion `
                            -AssignedIdentityResourceId $msiResourceId `
                            -AssignedIdentityClientId $msiClientId `
                            -AssignedIdentityObjectId $msiObjectId `
                            -ComputeProfileNode $nodeProfile `
                            -AuthorizationUserId $userId
```

```output
ApplicationLogStdErrorEnabled               : False
ApplicationLogStdOutEnabled                 : False
AuthorizationProfileGroupId                 :
AuthorizationProfileUserId                  : {00000000-0000-0000-0000-000000000000}
AutoscaleProfileAutoscaleType               :
AutoscaleProfileEnabled                     : False
AutoscaleProfileGracefulDecommissionTimeout :
ClusterType                                 : Trino
ComputeProfileNode                          : {Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.NodeProfil
                                              e, Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.NodeProf
                                              ile}
ConnectivityProfileSsh                      :
CoordinatorDebugEnable                      :
...
```

Create Trino cluster with least parameters.

### Example 2: Create Trino cluster with hive catalog
```powershell
# Create trino cluster with Hive catalog
$clusterPoolName="{your cluster pool name}";
$resourceGroupName="{your resource group name}";
$location="West US 2";

$clusterType="Trino"
# Get available cluster version based the command Get-AzHdInsightOnAksAvailableClusterVersion
$clusterVersion= (Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | Where-Object {$_.ClusterType -eq $clusterType})[0]

# user msi related parameters
$msiResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/{your resource group name}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{your msi}";
$msiClientId="00000000-0000-0000-0000-000000000000";
$msiObjectId="00000000-0000-0000-0000-000000000000";

# cluster authorization information
$userId="00000000-0000-0000-0000-000000000000";

# create node profile
$vmSize="Standard_E8ads_v5";
$workerCount=5;

$nodeProfile = New-AzHdInsightOnAksNodeProfileObject -Type Worker -Count $workerCount -VMSize $vmSize

$keyVaultResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/{your resource group name}/providers/Microsoft.KeyVault/vaults/{your vault name}";
$secretName="{your secret name}"
$referenceName="{your secret reference name}";

$secretReference=New-AzHdInsightOnAksSecretReferenceObject -SecretName $secretName -ReferenceName $referenceName

#hive catalog configuration

$catalogName="{your catalog name}"
$metastoreDbConnectionURL="jdbc:sqlserver://{your sql server url};database={your db name};encrypt=true;trustServerCertificate=true;loginTimeout=30;";
$metastoreDbUserName="{your db user name}";
$metastoreDbPasswordSecret=$secretName;
$metastoreWarehouseDir="abfs://{your container name}@{your adls gen2 endpoint}/{your path}";

$trinoHiveCatalogOption=New-AzHdInsightOnAksTrinoHiveCatalogObject -CatalogName $catalogName -MetastoreDbConnectionUrl $metastoreDbConnectionURL -MetastoreDbConnectionUserName $metastoreDbUserName -MetastoreDbConnectionPasswordSecret $metastoreDbPasswordSecret -MetastoreWarehouseDir $metastoreWarehouseDir

$clusterName="{your cluster name}";


New-AzHdInsightOnAksCluster -Name $clusterName `
                            -PoolName $clusterPoolName `
                            -ResourceGroupName $resourceGroupName `
                            -Location $location `
                            -ClusterType $clusterType `
                            -ClusterVersion $clusterVersion.ClusterVersionValue `
                            -OssVersion $clusterVersion.OssVersion `
                            -AssignedIdentityResourceId $msiResourceId `
                            -AssignedIdentityClientId $msiClientId `
                            -AssignedIdentityObjectId $msiObjectId `
                            -ComputeProfileNode $nodeProfile `
                            -AuthorizationUserId $userId `
                            -KeyVaultResourceId $keyVaultResourceId `
                            -SecretReference $secretReference `
                            -TrinoHiveCatalog $trinoHiveCatalogOption
```

```output
ApplicationLogStdErrorEnabled               : False
ApplicationLogStdOutEnabled                 : False
AuthorizationProfileGroupId                 :
AuthorizationProfileUserId                  : {00000000-0000-0000-0000-000000000000}
AutoscaleProfileAutoscaleType               :
AutoscaleProfileEnabled                     : False
AutoscaleProfileGracefulDecommissionTimeout :
ClusterType                                 : Trino
ComputeProfileNode                          : {Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.NodeProfil
                                              e, Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.NodeProf
                                              ile}
ConnectivityProfileSsh                      :
CoordinatorDebugEnable                      :
...
```

Create Trino cluster with hive catalog feature.

### Example 3: Create simple spark cluster
```powershell
$clusterPoolName="{your cluster pool name}";
$resourceGroupName="{your resource group name}";
$location="West US 2";

$clusterType="Spark"
# Get available cluster version based the command Get-AzHdInsightOnAksAvailableClusterVersion
$clusterVersion= (Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | Where-Object {$_.ClusterType -eq $clusterType})[0]

$msiResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/{your resource group name}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{your msi}";
$msiClientId="00000000-0000-0000-0000-000000000000";
$msiObjectId="00000000-0000-0000-0000-000000000000";

$userId="00000000-0000-0000-0000-000000000000";

# create node profile
$vmSize="Standard_E8d_v5";
$workerCount=5;

$nodeProfile = New-AzHdInsightOnAksNodeProfileObject -Type Worker -Count $workerCount -VMSize $vmSize

$sparkStorageUrl="abfs://{your container name}@{your adls gen2 endpoint}"

$clusterName="{your cluster name}";


New-AzHdInsightOnAksCluster -Name $clusterName `
                            -PoolName $clusterPoolName `
                            -ResourceGroupName $resourceGroupName `
                            -Location $location `
                            -ClusterType $clusterType `
                            -ClusterVersion $clusterVersion.ClusterVersionValue `
                            -OssVersion $clusterVersion.OssVersion `
                            -AssignedIdentityResourceId $msiResourceId `
                            -AssignedIdentityClientId $msiClientId `
                            -AssignedIdentityObjectId $msiObjectId `
                            -ComputeProfileNode $nodeProfile `
                            -AuthorizationUserId $userId `
                            -SparkStorageUrl $sparkStorageUrl
```

```output
ApplicationLogStdErrorEnabled               : False
ApplicationLogStdOutEnabled                 : False
AuthorizationProfileGroupId                 :
AuthorizationProfileUserId                  : {00000000-0000-0000-0000-000000000000}
AutoscaleProfileAutoscaleType               :
AutoscaleProfileEnabled                     : False
AutoscaleProfileGracefulDecommissionTimeout :
ClusterType                                 : Spark
ComputeProfileNode                          : {Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.NodeProfil
                                              e, Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.NodeProf
                                              ile}
ConnectivityProfileSsh                      :
CoordinatorDebugEnable                      :
...
```

Create Spark cluster with least parameters.

### Example 4: Create Spark cluster with hive catalog
```powershell
$clusterPoolName="{your cluster pool name}";
$resourceGroupName="{your resource group name}";
$location="West US 2";

$clusterType="Spark"
# Get available cluster version based the command Get-AzHdInsightOnAksAvailableClusterVersion
$clusterVersion= (Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | Where-Object {$_.ClusterType -eq $clusterType})[0]

$msiResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/{your resource group name}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{your msi}";
$msiClientId="00000000-0000-0000-0000-000000000000";
$msiObjectId="00000000-0000-0000-0000-000000000000";

$userId="00000000-0000-0000-0000-000000000000";

# create node profile
$vmSize="Standard_E8s_v3";
$workerCount=5;
$nodeProfile = New-AzHdInsightOnAksNodeProfileObject -Type Worker -Count $workerCount -VMSize $vmSize

# secret profile
$keyVaultResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/{your resource group name}/providers/Microsoft.KeyVault/vaults/{your vault name}";
$secretName="{your secret name}"
$referenceName="{your secret reference name}";

$secretReference=New-AzHdInsightOnAksSecretReferenceObject -SecretName $secretName -ReferenceName $referenceName

# Spark config
$sparkStorageUrl="abfs://{your container}@{your adls gen2 endpoint}" # example abfs://container@adlsgen2storage.dfs.core.windows.net

# Spark Hive catalog config
$metastoreDbName="{your db name}"
$metastoreServerName="{your sql server endpoint}" # example: server1.database.windows.net
$metastoreDbUserName="{your db user name}"
$metastoreDbPasswordSecret=$secretName

$clusterName="{your cluster name}";

New-AzHdInsightOnAksCluster -Name $clusterName `
                            -PoolName $clusterPoolName `
                            -ResourceGroupName $resourceGroupName `
                            -Location $location `
                            -ClusterType $clusterType `
                            -ClusterVersion $clusterVersion.ClusterVersionValue `
                            -OssVersion $clusterVersion.OssVersion `
                            -AssignedIdentityResourceId $msiResourceId `
                            -AssignedIdentityClientId $msiClientId `
                            -AssignedIdentityObjectId $msiObjectId `
                            -ComputeProfileNode $nodeProfile `
                            -AuthorizationUserId $userId `
                            -KeyVaultResourceId $keyVaultResourceId `
                            -SecretReference $secretReference `
                            -SparkStorageUrl $sparkStorageUrl `
                            -SparkHiveCatalogDbName $metastoreDbName `
                            -SparkHiveCatalogDbPasswordSecretName $metastoreDbPasswordSecret `
                            -SparkHiveCatalogDbServerName $metastoreServerName `
                            -SparkHiveCatalogDbUserName $metastoreDbUserName `
                            -SparkHiveCatalogKeyVaultId $keyVaultResourceId
```

```output
ApplicationLogStdErrorEnabled               : False
ApplicationLogStdOutEnabled                 : False
AuthorizationProfileGroupId                 :
AuthorizationProfileUserId                  : {00000000-0000-0000-0000-000000000000}
AutoscaleProfileAutoscaleType               :
AutoscaleProfileEnabled                     : False
AutoscaleProfileGracefulDecommissionTimeout :
ClusterType                                 : Spark
ComputeProfileNode                          : {Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.NodeProfil
                                              e, Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.NodeProf
                                              ile}
ConnectivityProfileSsh                      :
CoordinatorDebugEnable                      :
...
```

Create Spark cluster with hive catalog feature.

### Example 5: Create simple Flink cluster
```powershell
$clusterPoolName="{your cluster pool name}";
$resourceGroupName="{your resource group name}";
$location="West US 2";

$clusterType="Flink"
# Get available cluster version based the command Get-AzHdInsightOnAksAvailableClusterVersion
$clusterVersion= (Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | Where-Object {$_.ClusterType -eq $clusterType})[0]

$msiResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/{your resource group name}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{your msi}";
$msiClientId="00000000-0000-0000-0000-000000000000";
$msiObjectId="00000000-0000-0000-0000-000000000000";

$userId="00000000-0000-0000-0000-000000000000";

# create node profile
$vmSize="Standard_E8d_v5";
$workerCount=5;

$nodeProfile = New-AzHdInsightOnAksNodeProfileObject -Type Worker -Count $workerCount -VMSize $vmSize

# Flink config
$flinkStorageUrl="abfs://{your container}@{your adls gen2 endpoint}" # example abfs://container@adlsgen2storage.dfs.core.windows.net
$taskManagerCpu=1
$taskManagerMemory=4096  # memory in MB

$jobManagerCpu=1
$jobManagerMemory=4096   # memory in MB

$clusterName="{your cluster name}";

New-AzHdInsightOnAksCluster -Name $clusterName `
                            -PoolName $clusterPoolName `
                            -ResourceGroupName $resourceGroupName `
                            -Location $location `
                            -ClusterType $clusterType `
                            -ClusterVersion $clusterVersion.ClusterVersionValue `
                            -OssVersion $clusterVersion.OssVersion `
                            -AssignedIdentityResourceId $msiResourceId `
                            -AssignedIdentityClientId $msiClientId `
                            -AssignedIdentityObjectId $msiObjectId `
                            -ComputeProfileNode $nodeProfile `
                            -AuthorizationUserId $userId `
                            -FlinkStorageUrl $flinkStorageUrl `
                            -JobManagerCpu $jobManagerCpu `
                            -JobManagerMemory $jobManagerMemory `
                            -TaskManagerCpu $taskManagerCpu `
                            -TaskManagerMemory $taskManagerMemory
```

```output
ApplicationLogStdErrorEnabled               : False
ApplicationLogStdOutEnabled                 : False
AuthorizationProfileGroupId                 :
AuthorizationProfileUserId                  : {00000000-0000-0000-0000-000000000000}
AutoscaleProfileAutoscaleType               :
AutoscaleProfileEnabled                     : False
AutoscaleProfileGracefulDecommissionTimeout :
ClusterType                                 : Flink
ComputeProfileNode                          : {Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.NodeProfil
                                              e, Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.NodeProf
                                              ile}
ConnectivityProfileSsh                      :
CoordinatorDebugEnable                      :
...
```

Create Flink cluster with least parameters.

### Example 6: Create Flink cluster with hive catalog
```powershell
$clusterPoolName="{your cluster pool name}";
$resourceGroupName="{your resource group name}";
$location="West US 2";

$clusterType="Flink"
# Get available cluster version based the command Get-AzHdInsightOnAksAvailableClusterVersion
$clusterVersion= (Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | Where-Object {$_.ClusterType -eq $clusterType})[0]

$msiResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/{your resource group name}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{your msi}";
$msiClientId="00000000-0000-0000-0000-000000000000";
$msiObjectId="00000000-0000-0000-0000-000000000000";

$userId="00000000-0000-0000-0000-000000000000";

# create node profile
$vmSize="Standard_E8d_v5";
$workerCount=5;

$nodeProfile = New-AzHdInsightOnAksNodeProfileObject -Type Worker -Count $workerCount -VMSize $vmSize

# Flink config
$flinkStorageUrl="abfs://{your container}@{your adls gen2 endpoint}" # example abfs://container@adlsgen2storage.dfs.core.windows.net
$taskManagerCpu=1
$taskManagerMemory=4096  # memory in MB

$jobManagerCpu=1
$jobManagerMemory=4096   # memory in MB

# secret profile
$keyVaultResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/{your resource group name}/providers/Microsoft.KeyVault/vaults/{your vault name}";
$secretName="{your secret name}"
$referenceName="{your secret reference name}";

$secretReference=New-AzHdInsightOnAksSecretReferenceObject -SecretName $secretName -ReferenceName $referenceName

# Flink hive catalog config
$metastoreDbConnectionUrl="jdbc:sqlserver://{your sql server url};database={your db name};encrypt=true;trustServerCertificate=true;loginTimeout=30;";
$metastoreDbUserName="{your db user name}"
$metastoreDbPasswordSecret=$secretName

$clusterName="{your cluster name}";

New-AzHdInsightOnAksCluster -Name $clusterName `
                            -PoolName $clusterPoolName `
                            -ResourceGroupName $resourceGroupName `
                            -Location $location `
                            -ClusterType $clusterType `
                            -ClusterVersion $clusterVersion.ClusterVersionValue `
                            -OssVersion $clusterVersion.OssVersion `
                            -AssignedIdentityResourceId $msiResourceId `
                            -AssignedIdentityClientId $msiClientId `
                            -AssignedIdentityObjectId $msiObjectId `
                            -ComputeProfileNode $nodeProfile `
                            -AuthorizationUserId $userId `
                            -KeyVaultResourceId $keyVaultResourceId `
                            -SecretReference $secretReference `
                            -FlinkStorageUrl $flinkStorageUrl `
                            -JobManagerCpu $jobManagerCpu `
                            -JobManagerMemory $jobManagerMemory `
                            -TaskManagerCpu $taskManagerCpu `
                            -TaskManagerMemory $taskManagerMemory `
                            -FlinkHiveCatalogDbConnectionUrl $metastoreDbConnectionUrl `
                            -FlinkHiveCatalogDbUserName $metastoreDbUserName `
                            -FlinkHiveCatalogDbPasswordSecretName $metastoreDbPasswordSecret
```

```output
ApplicationLogStdErrorEnabled               : False
ApplicationLogStdOutEnabled                 : False
AuthorizationProfileGroupId                 :
AuthorizationProfileUserId                  : {00000000-0000-0000-0000-000000000000}
AutoscaleProfileAutoscaleType               :
AutoscaleProfileEnabled                     : False
AutoscaleProfileGracefulDecommissionTimeout :
ClusterType                                 : Flink
ComputeProfileNode                          : {Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.NodeProfil
                                              e, Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.NodeProf
                                              ile}
ConnectivityProfileSsh                      :
CoordinatorDebugEnable                      :
...
```

Create Flink cluster with hive catalog feature.

## PARAMETERS

### -ApplicationLogStdErrorEnabled
True if stderror is enabled, otherwise false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationLogStdOutEnabled
True if stdout is enabled, otherwise false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssignedIdentityClientId
ClientId of the MSI.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssignedIdentityObjectId
ObjectId of the MSI.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssignedIdentityResourceId
ResourceId of the MSI.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthorizationGroupId
AAD group Ids authorized for data plane access.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthorizationUserId
AAD user Ids authorized for data plane access.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoscaleProfileAutoscaleType
User to specify which type of Autoscale to be implemented - Scheduled Based or Load Based.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoscaleProfileEnabled
This indicates whether auto scale is enabled on HDInsight on AKS cluster.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoscaleProfileGracefulDecommissionTimeout
This property is for graceful decommission timeout; It has a default setting of 3600 seconds before forced shutdown takes place.
This is the maximal time to wait for running containers and applications to complete before transition a DECOMMISSIONING node into DECOMMISSIONED.
The default value is 3600 seconds.
Negative value (like -1) is handled as infinite timeout.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterAccessProfileEnableInternalIngress
Whether to create cluster using private IP instead of public IP.
This property must be set at create time.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterpoolInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity
Parameter Sets: CreateViaIdentityClusterpool, CreateViaIdentityClusterpoolExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterType
The type of cluster.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterVersion
Version with 3/4 part.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeProfileNode
The nodes definitions.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.INodeProfile[]
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CoordinatorDebugEnable
The flag that if enable debug or not.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CoordinatorDebugPort
The debug port.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CoordinatorDebugSuspend
The flag that if suspend debug or not.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CoordinatorHighAvailabilityEnabled
The flag that if enable coordinator HA, uses multiple coordinator replicas with auto failover, one per each head node.
Default: true.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseHost
The database URL

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseName
The database name

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabasePasswordSecretRef
Reference for the database password

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseUsername
The name of the database user

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskStorageDataDiskSize
Managed Disk size in GB.
The maximum supported disk size for Standard and Premium HDD/SSD is 32TB, except for Premium SSD v2, which supports up to 64TB.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskStorageDataDiskType
Managed Disk Type.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableLogAnalytics
True if log analytics is enabled for the cluster, otherwise false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FlinkHiveCatalogDbConnectionUrl
Connection string for hive metastore database.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FlinkHiveCatalogDbPasswordSecretName
Secret reference name from secretsProfile.secrets containing password for database connection.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FlinkHiveCatalogDbUserName
User name for database connection.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FlinkProfileDeploymentMode
A string property that indicates the deployment mode of Flink cluster.
It can have one of the following enum values =\> Application, Session.
Default value is Session

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FlinkStorageUrl
Storage account uri which is used for savepoint and checkpoint state.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FlinkTaskManagerReplicaCount
The number of task managers.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HdInsightOnAksCluster
The cluster.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ICluster
Parameter Sets: Create, CreateViaIdentity, CreateViaIdentityClusterpool
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -HistoryServerCpu
The required CPU.

```yaml
Type: System.Single
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HistoryServerMemory
The required memory in MB, Container memory will be 110 percentile

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HiveMetastoreDbConnectionAuthenticationMode
The authentication mode to connect to your Hive metastore database.
More details: https://learn.microsoft.com/en-us/azure/azure-sql/database/logins-create-manageview=azuresql#authentication-and-authorization

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JobManagerCpu
The required CPU.

```yaml
Type: System.Single
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobManagerMemory
The required memory in MB, Container memory will be 110 percentile

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobSpecArg
A string property representing additional JVM arguments for the Flink job.
It should be space separated value.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobSpecEntryClass
A string property that specifies the entry class for the Flink job.
If not specified, the entry point is auto-detected from the flink job jar package.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobSpecJarName
A string property that represents the name of the job JAR.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobSpecJobJarDirectory
A string property that specifies the directory where the job JAR is located.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobSpecSavePointName
A string property that represents the name of the savepoint for the Flink job

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobSpecUpgradeMode
A string property that indicates the upgrade mode to be performed on the Flink job.
It can have one of the following enum values =\> STATELESS_UPDATE, UPDATE, LAST_STATE_UPDATE.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KafkaProfileEnableKRaft
Expose Kafka cluster in KRaft mode.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KafkaProfileEnablePublicEndpoint
Expose worker nodes as public endpoints.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KafkaProfileRemoteStorageUri
Fully qualified path of Azure Storage container used for Tiered Storage.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultResourceId
Name of the user Key Vault where all the cluster specific user secrets are stored.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LlapProfile
LLAP cluster profile.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBasedConfigCooldownPeriod
This is a cool down period, this is a time period in seconds, which determines the amount of time that must elapse between a scaling activity started by a rule and the start of the next scaling activity, regardless of the rule that triggers it.
The default value is 300 seconds.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBasedConfigMaxNode
User needs to set the maximum number of nodes for load based scaling, the load based scaling will use this to scale up and scale down between minimum and maximum number of nodes.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBasedConfigMinNode
User needs to set the minimum number of nodes for load based scaling, the load based scaling will use this to scale up and scale down between minimum and maximum number of nodes.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBasedConfigPollInterval
User can specify the poll interval, this is the time period (in seconds) after which scaling metrics are polled for triggering a scaling operation.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBasedConfigScalingRule
The scaling rules.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IScalingRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogAnalyticProfileMetricsEnabled
True if metrics are enabled, otherwise false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetastoreSpecDbConnectionAuthenticationMode
The authentication mode to connect to your Hive metastore database.
More details: https://learn.microsoft.com/en-us/azure/azure-sql/database/logins-create-manageview=azuresql#authentication-and-authorization

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the HDInsight cluster.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaIdentityClusterpool, CreateViaIdentityClusterpoolExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases: ClusterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OssVersion
Version with three part.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PoolName
The name of the cluster pool.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases: ClusterPoolName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrometheuProfileEnabled
Enable Prometheus for cluster or not.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RangerAdmin
List of usernames that should be marked as ranger admins.
These usernames should match the user principal name (UPN) of the respective AAD users.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RangerAuditStorageAccount
Azure storage location of the blobs.
MSI should have read/write access to this Storage account.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RangerPluginProfileEnabled
Enable Ranger for cluster or not.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RangerUsersyncEnabled
Denotes whether usersync service should be enabled

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RangerUsersyncGroup
List of groups that should be synced.
These group names should match the object id of the respective AAD groups.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RangerUsersyncMode
User & groups can be synced automatically or via a static list that's refreshed.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RangerUsersyncUser
List of user names that should be synced.
These usernames should match the User principal name of the respective AAD users.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RangerUsersyncUserMappingLocation
Azure storage location of a mapping file that lists user & group associations.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleBasedConfigDefaultCount
Setting default node count of current schedule configuration.
Default node count specifies the number of nodes which are default when an specified scaling operation is executed (scale up/scale down)

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleBasedConfigSchedule
This specifies the schedules where scheduled based Autoscale to be enabled, the user has a choice to set multiple rules within the schedule across days and times (start/end).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ISchedule[]
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleBasedConfigTimeZone
User has to specify the timezone on which the schedule has to be set for schedule based autoscale configuration.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScriptActionProfile
The script action profile list.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IScriptActionProfile[]
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretReference
Properties of Key Vault secret.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ISecretReference[]
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceConfigsProfile
The service configs profiles.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterServiceConfigsProfile[]
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SparkHiveCatalogDbName
The database name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SparkHiveCatalogDbPasswordSecretName
The secret name which contains the database user password.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SparkHiveCatalogDbServerName
The database server host.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SparkHiveCatalogDbUserName
The database user name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SparkHiveCatalogKeyVaultId
The key vault resource id.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SparkStorageUrl
The default storage URL.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SparkThriftUrl
The thrift url.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SshProfileCount
Number of ssh pods per cluster.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageHivecatalogName
Hive Catalog name used to mount external tables on the logs written by trino, if not specified there tables are not created.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageHivecatalogSchema
Schema of the above catalog to use, to mount query logs as external tables, if not specified tables will be mounted under schema trinologs.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StoragePartitionRetentionInDay
Retention period for query log table partitions, this doesn't have any affect on actual data.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StoragePath
Azure storage location of the blobs.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StubProfile
Stub cluster profile.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TaskManagerCpu
The required CPU.

```yaml
Type: System.Single
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TaskManagerMemory
The required memory in MB, Container memory will be 110 percentile

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrinoHiveCatalog
hive catalog options.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHiveCatalogOption[]
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrinoProfileUserPluginsSpecPlugin
Trino user plugins.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ITrinoUserPlugin[]
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkerDebugEnable
The flag that if enable debug or not.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkerDebugPort
The debug port.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkerDebugSuspend
The flag that if suspend debug or not.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityClusterpoolExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ICluster

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ICluster

## NOTES

## RELATED LINKS

