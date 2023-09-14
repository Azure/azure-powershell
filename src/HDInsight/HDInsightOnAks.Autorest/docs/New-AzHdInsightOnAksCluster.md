---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/new-azhdinsightonakscluster
schema: 2.0.0
---

# New-AzHdInsightOnAksCluster

## SYNOPSIS
Creates a cluster.

## SYNTAX

### CreateExpanded (Default)
```
New-AzHdInsightOnAksCluster -Name <String> -PoolName <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-ApplicationLogStdErrorEnabled] [-ApplicationLogStdOutEnabled]
 [-AssignedIdentityClientId <String>] [-AssignedIdentityObjectId <String>]
 [-AssignedIdentityResourceId <String>] [-AuthorizationGroupId <String[]>] [-AuthorizationUserId <String[]>]
 [-AutoscaleProfileAutoscaleType <AutoscaleType>] [-AutoscaleProfileEnabled]
 [-AutoscaleProfileGracefulDecommissionTimeout <Int32>] [-ClusterType <String>] [-ClusterVersion <String>]
 [-ComputeProfileNode <INodeProfile[]>] [-CoordinatorDebugEnable] [-CoordinatorDebugPort <Int32>]
 [-CoordinatorDebugSuspend] [-CoordinatorHighAvailabilityEnabled] [-EnableLogAnalytics]
 [-FlinkHiveCatalogDbConnectionUrl <String>] [-FlinkHiveCatalogDbPasswordSecretName <String>]
 [-FlinkHiveCatalogDbUserName <String>] [-FlinkStorageUrl <String>] [-FlinkTaskManagerReplicaCount <Int32>]
 [-HistoryServerCpu <Single>] [-HistoryServerMemory <Int64>] [-JobManagerCpu <Single>]
 [-JobManagerMemory <Int64>] [-KafkaProfile <Hashtable>] [-KeyVaultResourceId <String>]
 [-LlapProfile <Hashtable>] [-LoadBasedConfigCooldownPeriod <Int32>] [-LoadBasedConfigMaxNode <Int32>]
 [-LoadBasedConfigMinNode <Int32>] [-LoadBasedConfigPollInterval <Int32>]
 [-LoadBasedConfigScalingRule <IScalingRule[]>] [-LogAnalyticProfileMetricsEnabled] [-OssVersion <String>]
 [-PrometheuProfileEnabled] [-ScheduleBasedConfigDefaultCount <Int32>]
 [-ScheduleBasedConfigSchedule <ISchedule[]>] [-ScheduleBasedConfigTimeZone <String>]
 [-ScriptActionProfile <IScriptActionProfile[]>] [-SecretReference <ISecretReference[]>]
 [-ServiceConfigsProfile <IClusterServiceConfigsProfile[]>] [-SparkHiveCatalogDbName <String>]
 [-SparkHiveCatalogDbPasswordSecretName <String>] [-SparkHiveCatalogDbServerName <String>]
 [-SparkHiveCatalogDbUserName <String>] [-SparkHiveCatalogKeyVaultId <String>] [-SparkStorageUrl <String>]
 [-SparkThriftUrl <String>] [-SshProfileCount <Int32>] [-StorageHivecatalogName <String>]
 [-StorageHivecatalogSchema <String>] [-StoragePartitionRetentionInDay <Int32>] [-StoragePath <String>]
 [-StubProfile <Hashtable>] [-Tag <Hashtable>] [-TaskManagerCpu <Single>] [-TaskManagerMemory <Int64>]
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

### CreateViaIdentityExpanded
```
New-AzHdInsightOnAksCluster -InputObject <IHdInsightOnAksIdentity> -Location <String>
 [-ApplicationLogStdErrorEnabled] [-ApplicationLogStdOutEnabled] [-AssignedIdentityClientId <String>]
 [-AssignedIdentityObjectId <String>] [-AssignedIdentityResourceId <String>]
 [-AuthorizationGroupId <String[]>] [-AuthorizationUserId <String[]>]
 [-AutoscaleProfileAutoscaleType <AutoscaleType>] [-AutoscaleProfileEnabled]
 [-AutoscaleProfileGracefulDecommissionTimeout <Int32>] [-ClusterType <String>] [-ClusterVersion <String>]
 [-ComputeProfileNode <INodeProfile[]>] [-CoordinatorDebugEnable] [-CoordinatorDebugPort <Int32>]
 [-CoordinatorDebugSuspend] [-CoordinatorHighAvailabilityEnabled] [-EnableLogAnalytics]
 [-FlinkHiveCatalogDbConnectionUrl <String>] [-FlinkHiveCatalogDbPasswordSecretName <String>]
 [-FlinkHiveCatalogDbUserName <String>] [-FlinkStorageUrl <String>] [-FlinkTaskManagerReplicaCount <Int32>]
 [-HistoryServerCpu <Single>] [-HistoryServerMemory <Int64>] [-JobManagerCpu <Single>]
 [-JobManagerMemory <Int64>] [-KafkaProfile <Hashtable>] [-KeyVaultResourceId <String>]
 [-LlapProfile <Hashtable>] [-LoadBasedConfigCooldownPeriod <Int32>] [-LoadBasedConfigMaxNode <Int32>]
 [-LoadBasedConfigMinNode <Int32>] [-LoadBasedConfigPollInterval <Int32>]
 [-LoadBasedConfigScalingRule <IScalingRule[]>] [-LogAnalyticProfileMetricsEnabled] [-OssVersion <String>]
 [-PrometheuProfileEnabled] [-ScheduleBasedConfigDefaultCount <Int32>]
 [-ScheduleBasedConfigSchedule <ISchedule[]>] [-ScheduleBasedConfigTimeZone <String>]
 [-ScriptActionProfile <IScriptActionProfile[]>] [-SecretReference <ISecretReference[]>]
 [-ServiceConfigsProfile <IClusterServiceConfigsProfile[]>] [-SparkHiveCatalogDbName <String>]
 [-SparkHiveCatalogDbPasswordSecretName <String>] [-SparkHiveCatalogDbServerName <String>]
 [-SparkHiveCatalogDbUserName <String>] [-SparkHiveCatalogKeyVaultId <String>] [-SparkStorageUrl <String>]
 [-SparkThriftUrl <String>] [-SshProfileCount <Int32>] [-StorageHivecatalogName <String>]
 [-StorageHivecatalogSchema <String>] [-StoragePartitionRetentionInDay <Int32>] [-StoragePath <String>]
 [-StubProfile <Hashtable>] [-Tag <Hashtable>] [-TaskManagerCpu <Single>] [-TaskManagerMemory <Int64>]
 [-TrinoHiveCatalog <IHiveCatalogOption[]>] [-TrinoProfileUserPluginsSpecPlugin <ITrinoUserPlugin[]>]
 [-WorkerDebugEnable] [-WorkerDebugPort <Int32>] [-WorkerDebugSuspend] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a cluster.

## EXAMPLES

### Example 1: Create simple Trino cluster
```powershell
# Create Simple Trino Cluster
$clusterPoolName="{your cluster pool name}";
$resourceGroupName="{your resource group name}";
$location="West US 2";

$clusterType="Trino"
# Get available cluster version based the command Get-AzHdInsightOnAksAvailableClusterVersion
$clusterVersion= (Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | where-object {$_.ClusterType -eq $clusterType})[0]

$msiResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/{your resource group name}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{your msi}";
$msiClientId="00000000-0000-0000-0000-000000000000";
$msiObjectId="00000000-0000-0000-0000-000000000000";

$userId="00000000-0000-0000-0000-000000000000";

# create node profile
$vmSize="Standard_E8ads_v5";
$workerCount=5;

$nodeProfile = New-AzHdInsightOnAksNodeProfile -Type Worker -Count $workerCount -VMSize $vmSize

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
{{ Add output here }}
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
$clusterVersion= (Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | where-object {$_.ClusterType -eq $clusterType})[0]

# user msi related parameters
$msiResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/{your resource group name}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{your msi}";
$msiClientId="00000000-0000-0000-0000-000000000000";
$msiObjectId="00000000-0000-0000-0000-000000000000";

# cluster authorization information
$userId="00000000-0000-0000-0000-000000000000";

# create node profile
$vmSize="Standard_E8ads_v5";
$workerCount=5;

$nodeProfile = New-AzHdInsightOnAksNodeProfile -Type Worker -Count $workerCount -VMSize $vmSize

$keyVaultResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/{your resource group name}/providers/Microsoft.KeyVault/vaults/{your vault name}";
$secretName="{your secret name}"
$referenceName="{your secret reference name}";

$secretReference=New-AzHdInsightOnAksSecretReference -SecretName $secretName -ReferenceName $referenceName

#hive catalog configuration

$catalogName="{your catalog name}"
$metastoreDbConnectionURL="jdbc:sqlserver://{your sql server url};database={your db name};encrypt=true;trustServerCertificate=true;loginTimeout=30;";
$metastoreDbUserName="{your db user name}";
$metastoreDbPasswordSecret=$secretName;
$metastoreWarehouseDir="abfs://{your container name}@{your adls gen2 endpoint}/{your path}";

$trinoHiveCatalogOption=New-AzHdInsightOnAksTrinoHiveCatalog -CatalogName $catalogName -MetastoreDbConnectionUrl $metastoreDbConnectionURL -MetastoreDbConnectionUserName $metastoreDbUserName -MetastoreDbConnectionPasswordSecret $metastore{your secret name}Secret -MetastoreWarehouseDir $metastoreWarehouseDir

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
{{ Add output here }}
```

Create Trino cluster with hive catalog feature.

### Example 3: Create simple spark cluster
```powershell
$clusterPoolName="{your cluster pool name}";
$resourceGroupName="{your resource group name}";
$location="West US 2";

$clusterType="Spark"
# Get available cluster version based the command Get-AzHdInsightOnAksAvailableClusterVersion
$clusterVersion= (Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | where-object {$_.ClusterType -eq $clusterType})[0]

$msiResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/{your resource group name}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{your msi}";
$msiClientId="00000000-0000-0000-0000-000000000000";
$msiObjectId="00000000-0000-0000-0000-000000000000";

$userId="00000000-0000-0000-0000-000000000000";

# create node profile
$vmSize="Standard_E8d_v5";
$workerCount=5;

$nodeProfile = New-AzHdInsightOnAksNodeProfile -Type Worker -Count $workerCount -VMSize $vmSize

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
{{ Add output here }}
```

Create Spark cluster with least parameters.

### Example 4: Create Spark cluster with hive catalog
```powershell
$clusterPoolName="{your cluster pool name}";
$resourceGroupName="{your resource group name}";
$location="West US 2";

$clusterType="Spark"
# Get available cluster version based the command Get-AzHdInsightOnAksAvailableClusterVersion
$clusterVersion= (Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | where-object {$_.ClusterType -eq $clusterType})[0]

$msiResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/{your resource group name}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{your msi}";
$msiClientId="00000000-0000-0000-0000-000000000000";
$msiObjectId="00000000-0000-0000-0000-000000000000";

$userId="00000000-0000-0000-0000-000000000000";

# create node profile
$vmSize="Standard_E8s_v3";
$workerCount=5;
$nodeProfile = New-AzHdInsightOnAksNodeProfile -Type Worker -Count $workerCount -VMSize $vmSize

# secret profile
$keyVaultResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/{your resource group name}/providers/Microsoft.KeyVault/vaults/{your vault name}";
$secretName="{your secret name}"
$referenceName="{your secret reference name}";

$secretReference=New-AzHdInsightOnAksSecretReference -SecretName $secretName -ReferenceName $referenceName

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
{{ Add output here }}
```

Create Spark cluster with hive catalog feature.

### Example 5: Create simple Flink cluster
```powershell
$clusterPoolName="{your cluster pool name}";
$resourceGroupName="{your resource group name}";
$location="West US 2";

$clusterType="Flink"
# Get available cluster version based the command Get-AzHdInsightOnAksAvailableClusterVersion
$clusterVersion= (Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | where-object {$_.ClusterType -eq $clusterType})[0]

$msiResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/{your resource group name}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{your msi}";
$msiClientId="00000000-0000-0000-0000-000000000000";
$msiObjectId="00000000-0000-0000-0000-000000000000";

$userId="00000000-0000-0000-0000-000000000000";

# create node profile
$vmSize="Standard_E8d_v5";
$workerCount=5;

$nodeProfile = New-AzHdInsightOnAksNodeProfile -Type Worker -Count $workerCount -VMSize $vmSize

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
{{ Add output here }}
```

Create Flink cluster with least parameters.

### Example 6: Create Flink cluster with hive catalog
```powershell
$clusterPoolName="{your cluster pool name}";
$resourceGroupName="{your resource group name}";
$location="West US 2";

$clusterType="Flink"
# Get available cluster version based the command Get-AzHdInsightOnAksAvailableClusterVersion
$clusterVersion= (Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | where-object {$_.ClusterType -eq $clusterType})[0]

$msiResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/{your resource group name}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{your msi}";
$msiClientId="00000000-0000-0000-0000-000000000000";
$msiObjectId="00000000-0000-0000-0000-000000000000";

$userId="00000000-0000-0000-0000-000000000000";

# create node profile
$vmSize="Standard_E8d_v5";
$workerCount=5;

$nodeProfile = New-AzHdInsightOnAksNodeProfile -Type Worker -Count $workerCount -VMSize $vmSize

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

$secretReference=New-AzHdInsightOnAksSecretReference -SecretName $secretName -ReferenceName $referenceName

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
{{ Add output here }}
```

Create Flink cluster with hive catalog feature.

## PARAMETERS

### -ApplicationLogStdErrorEnabled
True if stderror is enabled, otherwise false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Support.AutoscaleType
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterType
The type of cluster.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeProfileNode
The nodes definitions.
To construct, see NOTES section for COMPUTEPROFILENODE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.INodeProfile[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -EnableLogAnalytics
True if log analytics is enabled for the cluster, otherwise false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HdInsightOnAksCluster
The cluster.
To construct, see NOTES section for HDINSIGHTONAKSCLUSTER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.ICluster
Parameter Sets: Create, CreateViaIdentity
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KafkaProfile
Kafka cluster profile.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBasedConfigScalingRule
The scaling rules.
To construct, see NOTES section for LOADBASEDCONFIGSCALINGRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.IScalingRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleBasedConfigSchedule
This specifies the schedules where scheduled based Autoscale to be enabled, the user has a choice to set multiple rules within the schedule across days and times (start/end).
To construct, see NOTES section for SCHEDULEBASEDCONFIGSCHEDULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.ISchedule[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScriptActionProfile
The script action profile list.
To construct, see NOTES section for SCRIPTACTIONPROFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.IScriptActionProfile[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretReference
Properties of Key Vault secret.
To construct, see NOTES section for SECRETREFERENCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.ISecretReference[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceConfigsProfile
The service configs profiles.
To construct, see NOTES section for SERVICECONFIGSPROFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.IClusterServiceConfigsProfile[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrinoHiveCatalog
hive catalog options.
To construct, see NOTES section for TRINOHIVECATALOG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.IHiveCatalogOption[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrinoProfileUserPluginsSpecPlugin
Trino user plugins.
To construct, see NOTES section for TRINOPROFILEUSERPLUGINSSPECPLUGIN properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.ITrinoUserPlugin[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.ICluster

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.ICluster

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`COMPUTEPROFILENODE <INodeProfile[]>`: The nodes definitions.
  - `Count <Int32>`: The number of virtual machines.
  - `Type <String>`: The node type.
  - `VMSize <String>`: The virtual machine SKU.

`HDINSIGHTONAKSCLUSTER <ICluster>`: The cluster.
  - `Location <String>`: The geo-location where the resource lives
  - `[Tag <ITrackedResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[ApplicationLogStdErrorEnabled <Boolean?>]`: True if stderror is enabled, otherwise false.
  - `[ApplicationLogStdOutEnabled <Boolean?>]`: True if stdout is enabled, otherwise false.
  - `[AuthorizationProfileGroupId <String[]>]`: AAD group Ids authorized for data plane access.
  - `[AuthorizationProfileUserId <String[]>]`: AAD user Ids authorized for data plane access.
  - `[AutoscaleProfileAutoscaleType <AutoscaleType?>]`: User to specify which type of Autoscale to be implemented - Scheduled Based or Load Based.
  - `[AutoscaleProfileEnabled <Boolean?>]`: This indicates whether auto scale is enabled on HDInsight on AKS cluster.
  - `[AutoscaleProfileGracefulDecommissionTimeout <Int32?>]`: This property is for graceful decommission timeout; It has a default setting of 3600 seconds before forced shutdown takes place. This is the maximal time to wait for running containers and applications to complete before transition a DECOMMISSIONING node into DECOMMISSIONED. The default value is 3600 seconds. Negative value (like -1) is handled as infinite timeout.
  - `[ClusterType <String>]`: The type of cluster.
  - `[ComputeProfileNode <INodeProfile[]>]`: The nodes definitions.
    - `Count <Int32>`: The number of virtual machines.
    - `Type <String>`: The node type.
    - `VMSize <String>`: The virtual machine SKU.
  - `[ConnectivityProfileSsh <ISshConnectivityEndpoint[]>]`: List of SSH connectivity endpoints.
    - `Endpoint <String>`: SSH connectivity endpoint.
  - `[CoordinatorDebugEnable <Boolean?>]`: The flag that if enable debug or not.
  - `[CoordinatorDebugPort <Int32?>]`: The debug port.
  - `[CoordinatorDebugSuspend <Boolean?>]`: The flag that if suspend debug or not.
  - `[CoordinatorHighAvailabilityEnabled <Boolean?>]`: The flag that if enable coordinator HA, uses multiple coordinator replicas with auto failover, one per each head node. Default: true.
  - `[FlinkProfileNumReplica <Int32?>]`: The number of task managers.
  - `[HistoryServerCpu <Single?>]`: The required CPU.
  - `[HistoryServerMemory <Int64?>]`: The required memory in MB, Container memory will be 110 percentile
  - `[HiveMetastoreDbConnectionPasswordSecret <String>]`: Secret reference name from secretsProfile.secrets containing password for database connection.
  - `[HiveMetastoreDbConnectionUrl <String>]`: Connection string for hive metastore database.
  - `[HiveMetastoreDbConnectionUserName <String>]`: User name for database connection.
  - `[IdentityProfileMsiClientId <String>]`: ClientId of the MSI.
  - `[IdentityProfileMsiObjectId <String>]`: ObjectId of the MSI.
  - `[IdentityProfileMsiResourceId <String>]`: ResourceId of the MSI.
  - `[JobManagerCpu <Single?>]`: The required CPU.
  - `[JobManagerMemory <Int64?>]`: The required memory in MB, Container memory will be 110 percentile
  - `[LoadBasedConfigCooldownPeriod <Int32?>]`: This is a cool down period, this is a time period in seconds, which determines the amount of time that must elapse between a scaling activity started by a rule and the start of the next scaling activity, regardless of the rule that triggers it. The default value is 300 seconds.
  - `[LoadBasedConfigMaxNode <Int32?>]`: User needs to set the maximum number of nodes for load based scaling, the load based scaling will use this to scale up and scale down between minimum and maximum number of nodes.
  - `[LoadBasedConfigMinNode <Int32?>]`: User needs to set the minimum number of nodes for load based scaling, the load based scaling will use this to scale up and scale down between minimum and maximum number of nodes.
  - `[LoadBasedConfigPollInterval <Int32?>]`: User can specify the poll interval, this is the time period (in seconds) after which scaling metrics are polled for triggering a scaling operation.
  - `[LoadBasedConfigScalingRule <IScalingRule[]>]`: The scaling rules.
    - `ActionType <ScaleActionType>`: The action type.
    - `ComparisonRuleOperator <ComparisonOperator>`: The comparison operator.
    - `ComparisonRuleThreshold <Single>`: Threshold setting.
    - `EvaluationCount <Int32>`: This is an evaluation count for a scaling condition, the number of times a trigger condition should be successful, before scaling activity is triggered.
    - `ScalingMetric <String>`: Metrics name for individual workloads. For example: cpu
  - `[LogAnalyticProfileEnabled <Boolean?>]`: True if log analytics is enabled for the cluster, otherwise false.
  - `[LogAnalyticProfileMetricsEnabled <Boolean?>]`: True if metrics are enabled, otherwise false.
  - `[MetastoreSpecDbName <String>]`: The database name.
  - `[MetastoreSpecDbPasswordSecretName <String>]`: The secret name which contains the database user password.
  - `[MetastoreSpecDbServerHost <String>]`: The database server host.
  - `[MetastoreSpecDbUserName <String>]`: The database user name.
  - `[MetastoreSpecKeyVaultId <String>]`: The key vault resource id.
  - `[MetastoreSpecThriftUrl <String>]`: The thrift url.
  - `[ProfileClusterVersion <String>]`: Version with 3/4 part.
  - `[ProfileKafkaProfile <IClusterProfileKafkaProfile>]`: Kafka cluster profile.
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[ProfileLlapProfile <IClusterProfileLlapProfile>]`: LLAP cluster profile.
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[ProfileOssVersion <String>]`: Version with three part.
  - `[ProfileScriptActionProfile <IScriptActionProfile[]>]`: The script action profile list.
    - `Name <String>`: Script name.
    - `Service <String[]>`: List of services to apply the script action.
    - `Type <String>`: Type of the script action. Supported type is bash scripts.
    - `Url <String>`: Url of the script file.
    - `[Parameter <String>]`: Additional parameters for the script action. It should be space-separated list of arguments required for script execution.
    - `[ShouldPersist <Boolean?>]`: Specify if the script should persist on the cluster.
    - `[TimeoutInMinute <Int32?>]`: Timeout duration for the script action in minutes.
  - `[ProfileServiceConfigsProfile <IClusterServiceConfigsProfile[]>]`: The service configs profiles.
    - `Config <IClusterServiceConfig[]>`: List of service configs.
      - `Component <String>`: Name of the component the config files should apply to.
      - `File <IClusterConfigFile[]>`: List of Config Files.
        - `FileName <String>`: Configuration file name.
        - `[Content <String>]`: Free form content of the entire configuration file.
        - `[Encoding <ContentEncoding?>]`: This property indicates if the content is encoded and is case-insensitive. Please set the value to base64 if the content is base64 encoded. Set it to none or skip it if the content is plain text.
        - `[Path <String>]`: Path of the config file if content is specified.
        - `[Value <IClusterConfigFileValues>]`: List of key value pairs         where key represents a valid service configuration name and value represents the value of the config.
          - `[(Any) <String>]`: This indicates any property can be added to this object.
    - `ServiceName <String>`: Name of the service the configurations should apply to.
  - `[ProfileStubProfile <IClusterProfileStubProfile>]`: Stub cluster profile.
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[PrometheuProfileEnabled <Boolean?>]`: Enable Prometheus for cluster or not.
  - `[ScheduleBasedConfigDefaultCount <Int32?>]`: Setting default node count of current schedule configuration. Default node count specifies the number of nodes which are default when an specified scaling operation is executed (scale up/scale down)
  - `[ScheduleBasedConfigSchedule <ISchedule[]>]`: This specifies the schedules where scheduled based Autoscale to be enabled, the user has a choice to set multiple rules within the schedule across days and times (start/end).
    - `Count <Int32>`: User has to set the node count anticipated at end of the scaling operation of the set current schedule configuration, format is integer.
    - `Day <ScheduleDay[]>`: User has to set the days where schedule has to be set for autoscale operation.
    - `EndTime <String>`: User has to set the end time of current schedule configuration, format like 10:30 (HH:MM).
    - `StartTime <String>`: User has to set the start time of current schedule configuration, format like 10:30 (HH:MM).
  - `[ScheduleBasedConfigTimeZone <String>]`: User has to specify the timezone on which the schedule has to be set for schedule based autoscale configuration.
  - `[SecretProfileKeyVaultResourceId <String>]`: Name of the user Key Vault where all the cluster specific user secrets are stored.
  - `[SecretProfileSecret <ISecretReference[]>]`: Properties of Key Vault secret.
    - `KeyVaultObjectName <String>`: Object identifier name of the secret in key vault.
    - `ReferenceName <String>`: Reference name of the secret to be used in service configs.
    - `Type <KeyVaultObjectType>`: Type of key vault object: secret, key or certificate.
    - `[Version <String>]`: Version of the secret in key vault.
  - `[SparkProfileDefaultStorageUrl <String>]`: The default storage URL.
  - `[SparkProfileUserPluginsSpecPlugin <ISparkUserPlugin[]>]`: Spark user plugins.
    - `Path <String>`: Fully qualified path to the folder containing the plugins.
  - `[SshProfileCount <Int32?>]`: Number of ssh pods per cluster.
  - `[StorageHivecatalogName <String>]`: Hive Catalog name used to mount external tables on the logs written by trino, if not specified there tables are not created.
  - `[StorageHivecatalogSchema <String>]`: Schema of the above catalog to use, to mount query logs as external tables, if not specified tables will be mounted under schema trinologs.
  - `[StoragePartitionRetentionInDay <Int32?>]`: Retention period for query log table partitions, this doesn't have any affect on actual data.
  - `[StoragePath <String>]`: Azure storage location of the blobs.
  - `[StorageStoragekey <String>]`: Storage key is only required for wasb(s) storage.
  - `[StorageUri <String>]`: Storage account uri which is used for savepoint and checkpoint state.
  - `[TaskManagerCpu <Single?>]`: The required CPU.
  - `[TaskManagerMemory <Int64?>]`: The required memory in MB, Container memory will be 110 percentile
  - `[TrinoProfileCatalogOptionsHive <IHiveCatalogOption[]>]`: hive catalog options.
    - `CatalogName <String>`: Name of trino catalog which should use specified hive metastore.
    - `MetastoreDbConnectionPasswordSecret <String>`: Secret reference name from secretsProfile.secrets containing password for database connection.
    - `MetastoreDbConnectionUrl <String>`: Connection string for hive metastore database.
    - `MetastoreDbConnectionUserName <String>`: User name for database connection.
    - `MetastoreWarehouseDir <String>`: Metastore root directory URI, format: abfs[s]://<container>@<account_name>.dfs.core.windows.net/<path>. More details: https://docs.microsoft.com/en-us/azure/storage/blobs/data-lake-storage-introduction-abfs-uri
  - `[TrinoProfileUserPluginsSpecPlugin <ITrinoUserPlugin[]>]`: Trino user plugins.
    - `[Enabled <Boolean?>]`: Denotes whether the plugin is active or not.
    - `[Name <String>]`: This field maps to the sub-directory in trino plugins location, that will contain all the plugins under path.
    - `[Path <String>]`: Fully qualified path to the folder containing the plugins.
  - `[WebFqdn <String>]`: Web connectivity endpoint.
  - `[WorkerDebugEnable <Boolean?>]`: The flag that if enable debug or not.
  - `[WorkerDebugPort <Int32?>]`: The debug port.
  - `[WorkerDebugSuspend <Boolean?>]`: The flag that if suspend debug or not.

`INPUTOBJECT <IHdInsightOnAksIdentity>`: Identity Parameter
  - `[ClusterName <String>]`: The name of the HDInsight cluster.
  - `[ClusterPoolName <String>]`: The name of the cluster pool.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The name of the Azure region.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription. The value must be an UUID.

`LOADBASEDCONFIGSCALINGRULE <IScalingRule[]>`: The scaling rules.
  - `ActionType <ScaleActionType>`: The action type.
  - `ComparisonRuleOperator <ComparisonOperator>`: The comparison operator.
  - `ComparisonRuleThreshold <Single>`: Threshold setting.
  - `EvaluationCount <Int32>`: This is an evaluation count for a scaling condition, the number of times a trigger condition should be successful, before scaling activity is triggered.
  - `ScalingMetric <String>`: Metrics name for individual workloads. For example: cpu

`SCHEDULEBASEDCONFIGSCHEDULE <ISchedule[]>`: This specifies the schedules where scheduled based Autoscale to be enabled, the user has a choice to set multiple rules within the schedule across days and times (start/end).
  - `Count <Int32>`: User has to set the node count anticipated at end of the scaling operation of the set current schedule configuration, format is integer.
  - `Day <ScheduleDay[]>`: User has to set the days where schedule has to be set for autoscale operation.
  - `EndTime <String>`: User has to set the end time of current schedule configuration, format like 10:30 (HH:MM).
  - `StartTime <String>`: User has to set the start time of current schedule configuration, format like 10:30 (HH:MM).

`SCRIPTACTIONPROFILE <IScriptActionProfile[]>`: The script action profile list.
  - `Name <String>`: Script name.
  - `Service <String[]>`: List of services to apply the script action.
  - `Type <String>`: Type of the script action. Supported type is bash scripts.
  - `Url <String>`: Url of the script file.
  - `[Parameter <String>]`: Additional parameters for the script action. It should be space-separated list of arguments required for script execution.
  - `[ShouldPersist <Boolean?>]`: Specify if the script should persist on the cluster.
  - `[TimeoutInMinute <Int32?>]`: Timeout duration for the script action in minutes.

`SECRETREFERENCE <ISecretReference[]>`: Properties of Key Vault secret.
  - `KeyVaultObjectName <String>`: Object identifier name of the secret in key vault.
  - `ReferenceName <String>`: Reference name of the secret to be used in service configs.
  - `Type <KeyVaultObjectType>`: Type of key vault object: secret, key or certificate.
  - `[Version <String>]`: Version of the secret in key vault.

`SERVICECONFIGSPROFILE <IClusterServiceConfigsProfile[]>`: The service configs profiles.
  - `Config <IClusterServiceConfig[]>`: List of service configs.
    - `Component <String>`: Name of the component the config files should apply to.
    - `File <IClusterConfigFile[]>`: List of Config Files.
      - `FileName <String>`: Configuration file name.
      - `[Content <String>]`: Free form content of the entire configuration file.
      - `[Encoding <ContentEncoding?>]`: This property indicates if the content is encoded and is case-insensitive. Please set the value to base64 if the content is base64 encoded. Set it to none or skip it if the content is plain text.
      - `[Path <String>]`: Path of the config file if content is specified.
      - `[Value <IClusterConfigFileValues>]`: List of key value pairs         where key represents a valid service configuration name and value represents the value of the config.
        - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `ServiceName <String>`: Name of the service the configurations should apply to.

`SPARKPROFILEUSERPLUGINSSPECPLUGIN <ISparkUserPlugin[]>`: Spark user plugins.
  - `Path <String>`: Fully qualified path to the folder containing the plugins.

`TRINOHIVECATALOG <IHiveCatalogOption[]>`: hive catalog options.
  - `CatalogName <String>`: Name of trino catalog which should use specified hive metastore.
  - `MetastoreDbConnectionPasswordSecret <String>`: Secret reference name from secretsProfile.secrets containing password for database connection.
  - `MetastoreDbConnectionUrl <String>`: Connection string for hive metastore database.
  - `MetastoreDbConnectionUserName <String>`: User name for database connection.
  - `MetastoreWarehouseDir <String>`: Metastore root directory URI, format: abfs[s]://<container>@<account_name>.dfs.core.windows.net/<path>. More details: https://docs.microsoft.com/en-us/azure/storage/blobs/data-lake-storage-introduction-abfs-uri

`TRINOPROFILEUSERPLUGINSSPECPLUGIN <ITrinoUserPlugin[]>`: Trino user plugins.
  - `[Enabled <Boolean?>]`: Denotes whether the plugin is active or not.
  - `[Name <String>]`: This field maps to the sub-directory in trino plugins location, that will contain all the plugins under path.
  - `[Path <String>]`: Fully qualified path to the folder containing the plugins.

## RELATED LINKS

