if(($null -eq $TestName) -or ($TestName -contains 'AzVmCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzVmCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzVmCluster' {
    It 'CreateVmCluster' {
        {
            $exaInfra = Get-AzOracleDatabaseCloudExadataInfrastructure -Name $env.exaInfraName -ResourceGroupName $env.resourceGroup
            $exaInfraId = $exaInfra.Id
            
            # Get Db Server Ocids
            $dbServerList = Get-AzOracleDatabaseDbServer -Cloudexadatainfrastructurename $env.exaInfraName -ResourceGroupName $env.resourceGroup
            $dbServerOcid1 = $dbServerList[0].Ocid
            $dbServerOcid2 = $dbServerList[1].Ocid

            $vmCluster = New-AzOracleDatabaseCloudVMCluster -Name $env.vmClusterName -ResourceGroupName $env.resourceGroup -Location $env.location -DisplayName $env.vmClusterName -HostName $env.vmClusterHostName -CpuCoreCount $env.vmClusterCpuCoreCount -CloudExadataInfrastructureId $exaInfraId -SshPublicKey $env.sshPublicKey -VnetId $env.vnetId -GiVersion $env.vmClusterGiVersion -SubnetId $env.subnetId -LicenseModel $env.vmClusterLicenseModel -ClusterName $env.vmClusterCusterName -MemorySizeInGb $env.vmClusterMemorySizeInGb -DbNodeStorageSizeInGb $env.vmClusterDbNodeStorageSizeInGb -DataStorageSizeInTb $env.vmClusterDataStorageSizeInTb -DataStoragePercentage $env.vmClusterDataStoragePercentage -TimeZone $env.vmClusterTimeZone -DbServer @($dbServerOcid1, $dbServerOcid2)
            $vmCluster.Name | Should -Be $env.vmClusterName
        } | Should -Not -Throw
    }
    It 'GetVmCluster' {
        {
            $vmCluster = Get-AzOracleDatabaseCloudVMCluster -Name $env.vmClusterName -ResourceGroupName $env.resourceGroup
            $vmCluster.Name | Should -Be $env.vmClusterName
        } | Should -Not -Throw
    }
    It 'ListVmClusters' {
        {
            $vmClusterList = Get-AzOracleDatabaseCloudVMCluster
            $vmClusterList.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
    It 'StopVm' {
        {
            $stopActionName = "Stop"
            
            # Get Db Node Ocids
            $dbNodeList = Get-AzOracleDatabaseDbNode -Cloudvmclustername $env.vmClusterName -ResourceGroupName $env.resourceGroup
            $dbNodeOcid1 = $dbNodeList[0].Name
            
            Invoke-AzOracleDatabaseActionDbNode -Cloudvmclustername $env.vmClusterName -Dbnodeocid $dbNodeOcid1 -ResourceGroupName $env.resourceGroup -Action $stopActionName
        } | Should -Not -Throw
    }
    It 'StartVm' {
        {
            $startActionName = "Start"
            
            # Get Db Node Ocids
            $dbNodeList = Get-AzOracleDatabaseDbNode -Cloudvmclustername $env.vmClusterName -ResourceGroupName $env.resourceGroup
            $dbNodeOcid1 = $dbNodeList[0].Name
            
            Invoke-AzOracleDatabaseActionDbNode -Cloudvmclustername $env.vmClusterName -Dbnodeocid $dbNodeOcid1 -ResourceGroupName $env.resourceGroup -Action $startActionName
        } | Should -Not -Throw
    }
    It 'DeleteVmCluster' {
        {
            Remove-AzOracleDatabaseCloudVMCluster -NoWait -Name $env.vmClusterName -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}
