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