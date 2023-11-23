if(($null -eq $TestName) -or ($TestName -contains 'ClusterCreate_Trino'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'sessionRecords\ClusterCreate_Trino.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'ClusterCreate_Trino' {
    BeforeAll {
        # Cluster configuration info
        $location = "West US 3"
        $clusterResourceGroupName = "PStestGroup"
        $clusterpoolName = "ps-test-pool-operations"
        $clusterType = "Trino"
        $vmSize = "Standard_E4s_v3"
        $clusterVersion= (Get-AzHdInsightOnAksAvailableClusterVersion -Location $location | Where-Object {$_.ClusterType -eq $clusterType})[0]
        $ComputeProfileNode = New-AzHdInsightOnAksNodeProfileObject -Type "Worker" -Count 3 -VMSize "Standard_D8d_v5"
        $keyVaultResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PSGroup/providers/Microsoft.KeyVault/vaults/sqlpass";
        $trinoHiveCatalogOption
        $secretReference
        $secretName="{your secret name on keyVault}"
        $clusterName = "testpstrino"
    }

    It "New-AzHdInsightOnAksSecretReferenceObject"{
        $referenceName="{your secret reference name}";
        $secretReference=New-AzHdInsightOnAksSecretReferenceObject -SecretName $secretName -ReferenceName $referenceName

        [Console]::WriteLine("New-AzHdInsightOnAksSecretReferenceObject done")
    }

    It "New-AzHdInsightOnAksTrinoHiveCatalogObject"{
        $catalogName="{your catalog name}"
        $metastoreDbConnectionURL="jdbc:sqlserver://{your sql server url};database={your db name};encrypt=true;trustServerCertificate=true;loginTimeout=30;";
        $metastoreDbUserName="{your db user name}";
        $metastoreDbPasswordSecret=$secretName;
        $metastoreWarehouseDir="abfs://{your container name}@{your adls gen2 endpoint}/{your path}";
        $trinoHiveCatalogOption=New-AzHdInsightOnAksTrinoHiveCatalogObject -CatalogName $catalogName -MetastoreDbConnectionUrl $metastoreDbConnectionURL -MetastoreDbConnectionUserName $metastoreDbUserName -MetastoreDbConnectionPasswordSecret $metastoreDbPasswordSecret

        [Console]::WriteLine("New-AzHdInsightOnAksTrinoHiveCatalogObject done")
    }

    It "New-AzHdInsightOnAksCluster_Trino"{
        $clusterType = "trino"
        
        {  New-AzHdInsightOnAksCluster -Name $clusterName -PoolName $clusterpoolName `
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

    # AfterAll{
    #     Remove-AzHdInsightOnAksCluster -ResourceGroupName $clusterResourceGroupName -Name $clusterName -PoolName $clusterpoolName
    # }
}
