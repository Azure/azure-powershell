if (($null -eq $TestName) -or ($TestName -contains 'ClusterCreate_Catalog')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'sessionRecords\ClusterCreate_Catalog.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'ClusterCreate_Catalog' {
    BeforeAll {
        # Cluster configuration info
        $location = "West US 3"
        $clusterResourceGroupName = "PStestGroup"
        $clusterpoolName = "hilo-pool"
        $clusterType = "Trino"
        $vmSize = "Standard_D4a_v4"
        $ComputeProfileNode = New-AzHdInsightOnAksNodeProfileObject -Type "Worker" -Count 3 -VMSize "Standard_D16a_v4"
        $keyVaultResourceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PSGroup/providers/Microsoft.KeyVault/vaults/sqlpass";
        $trinoHiveCatalogOption
        $secretReference
        $secretName = "sqlpassword"

        $catalogName = "catalog"
        $metastoreDbConnectionURL = "jdbc:sqlserver://sqlserver.database.windows.net;database=data3;encrypt=true;trustServerCertificate=true;create=false;loginTimeout=30";
        $metastoreDbUserName = "hdi";
        $metastoreDbPasswordSecret = $secretName;
        $metastoreWarehouseDir = "abfs://trinops@flinkdemo125stuoi.dfs.core.windows.net";
    }

    It "New-AzHdInsightOnAksSecretReferenceObject" {
        $referenceName = "sqlpassword";
        $secretReference = New-AzHdInsightOnAksSecretReferenceObject -SecretName $secretName -ReferenceName $referenceName -Type Secret

        [Console]::WriteLine("New-AzHdInsightOnAksSecretReferenceObject done")
    }

    It "New-AzHdInsightOnAksTrinoHiveCatalogObject" {
        $trinoHiveCatalogOption = New-AzHdInsightOnAksTrinoHiveCatalogObject -CatalogName $catalogName -MetastoreWarehouseDir $metastoreWarehouseDir -MetastoreDbConnectionUrl $metastoreDbConnectionURL -MetastoreDbConnectionUserName $metastoreDbUserName -MetastoreDbConnectionPasswordSecret $metastoreDbPasswordSecret

        [Console]::WriteLine("New-AzHdInsightOnAksTrinoHiveCatalogObject done")
    }

    It "New-AzHdInsightOnAksCluster_Trino" -Skip{
        $clusterType = "trino"
        $clusterName = "pstrino"
        $clusterVersion = (Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | Where-Object { $_.ClusterType -eq $clusterType })[0]

        { New-AzHdInsightOnAksCluster -Name $clusterName -PoolName $clusterpoolName `
                -ResourceGroupName $clusterResourceGroupName `
                -Location $location `
                -ClusterType $clusterType `
                -ClusterVersion $clusterVersion.ClusterVersionValue `
                -OssVersion $clusterVersion.OssVersion `
                -ComputeProfileNode $ComputeProfileNode `
                -AuthorizationUserId $env.authorizationUserId `
                -AssignedIdentityClientId $env.msiClientId `
                -AssignedIdentityObjectId $env.msiObjectId `
                -AssignedIdentityResourceId $env.identityProfileMsiResourceId `
                -KeyVaultResourceId $keyVaultResourceId `
                -SecretReference $secretReference `
                -TrinoHiveCatalog $trinoHiveCatalogOption } | Should -Not -Throw
        
        [Console]::WriteLine("New-AzHdInsightOnAksCluster_Trino done")
    }

    It "New-AzHdInsightOnAksCluster_Spark" -Skip{
        $clusterType = "Spark"
        $clusterName = "sparkps"
        $StorageUri = "abfs://pscontainer4@hilostorage.dfs.core.windows.net"
        $clusterVersion = (Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | Where-Object { $_.ClusterType -eq $clusterType })[1]

        { New-AzHdInsightOnAksCluster -Name $clusterName -PoolName $clusterpoolName `
                -ResourceGroupName $clusterResourceGroupName `
                -Location $location `
                -ClusterType $clusterType `
                -ClusterVersion $clusterVersion.ClusterVersionValue `
                -OssVersion $clusterVersion.OssVersion `
                -ComputeProfileNode $ComputeProfileNode `
                -AuthorizationUserId $env.authorizationUserId `
                -AssignedIdentityClientId $env.msiClientId `
                -AssignedIdentityObjectId $env.msiObjectId `
                -AssignedIdentityResourceId $env.identityProfileMsiResourceId `
                -SecretReference $secretReference `
                -SparkHiveCatalogDbName  "data3" `
                -SparkHiveCatalogDbPasswordSecretName $secretName `
                -SparkHiveCatalogDbServerName "sqlserver" `
                -SparkHiveCatalogDbUserName $metastoreDbUserName `
                -SparkHiveCatalogKeyVaultId $keyVaultResourceId `
                -SparkStorageUrl $StorageUri
        } | Should -Not -Throw
        
        [Console]::WriteLine("New-AzHdInsightOnAksCluster_Trino done")
    }

    AfterAll {
        # Remove-AzHdInsightOnAksCluster -ResourceGroupName $clusterResourceGroupName -Name $clusterName -PoolName $clusterpoolName
    }
}
