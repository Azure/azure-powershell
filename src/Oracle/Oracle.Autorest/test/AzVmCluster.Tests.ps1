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
            $sshPublicKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQDKJkePl4prXTs6cZ77AS9kGs5TO1EdfDdQZAtD7cfBVJ8X4wN+aOvLhk+u74D3qXad2OdQ/ij5q+xVzoXLXNBIZFQjB8JqWpgvOrOCAakFGc0OatJhSVlmJKW7JboQcUu7AzABfu+Ciso1QQTqlc2+awoZzPhfP9sgDMN6zI15Q9wSuxERor8oMSc78NW652wMzl97zO+bYdO9vIjBu27/WYZN/OpFJ0Ss4AzW/V9r2h6FFCkG+GXzhZArk3NeEstCSO2bjv3vO40+M0vfRD2jQrOSKhaLolk+crLGamaclY0YYCVB23rk6gCimWbVuvpHn+x1QSvN2d19xAmrIsHdTv/1lCEJetMA96pBq/jbljPwVKPFfVkyC8Ivt5rkbYizmUlYAbDMksGMUR4ncjScY7o/S0JKs14HihOnCoSGVXhH1dDgc8AsI+Ujs+GGR4U8IXJGEpZmhdnLa6mDymvr1tLWdQaI2y5FuWxsy4diKjEsPxCrnqfxlZxFBbQ29AU= generated-by-azure"

            $exaInfra = Get-AzOracleCloudExadataInfrastructure -Name $env.exaInfraName -ResourceGroupName $env.resourceGroup
            $exaInfraId = $exaInfra.Id
            
            # Get Db Server Ocids
            $dbServerList = Get-AzOracleDbServer -Cloudexadatainfrastructurename $env.exaInfraName -ResourceGroupName $env.resourceGroup
            $dbServerOcid1 = $dbServerList[0].Ocid
            $dbServerOcid2 = $dbServerList[1].Ocid

            $vmCluster = New-AzOracleCloudVMCluster -Name $env.vmClusterName -ResourceGroupName $env.resourceGroup -Location $env.location -DisplayName $env.vmClusterName -HostName $env.vmClusterHostName -CpuCoreCount $env.vmClusterCpuCoreCount -CloudExadataInfrastructureId $exaInfraId -SshPublicKey $sshPublicKey -VnetId $env.vnetId -GiVersion $env.vmClusterGiVersion -SubnetId $env.subnetId -LicenseModel $env.vmClusterLicenseModel -ClusterName $env.vmClusterClusterName -MemorySizeInGb $env.vmClusterMemorySizeInGb -DbNodeStorageSizeInGb $env.vmClusterDbNodeStorageSizeInGb -DataStorageSizeInTb $env.vmClusterDataStorageSizeInTb -DataStoragePercentage $env.vmClusterDataStoragePercentage -TimeZone $env.vmClusterTimeZone -DbServer @($dbServerOcid1, $dbServerOcid2)
            $vmCluster.Name | Should -Be $env.vmClusterName
        } | Should -Not -Throw
    }
    It 'GetVmCluster' {
        {
            $vmCluster = Get-AzOracleCloudVMCluster -Name $env.vmClusterName -ResourceGroupName $env.resourceGroup
            $vmCluster.Name | Should -Be $env.vmClusterName
        } | Should -Not -Throw
    }
    It 'ListVmClusters' {
        {
            $vmClusterList = Get-AzOracleCloudVMCluster
            $vmClusterList.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
    It 'UpdateVmCluster' {
        {
            $tagHashTable = @{'tagName'="tagValue"}
            Update-AzOracleCloudVMCluster -Name $env.vmClusterName -ResourceGroupName $env.resourceGroup -Tag $tagHashTable
            $exaInfra = Get-AzOracleCloudVMCluster -Name $env.vmClusterName -ResourceGroupName $env.resourceGroup
            $exaInfra.Tag.Get_Item("tagName") | Should -Be "tagValue"
        } | Should -Not -Throw
    }
    It 'StopVm' {
        {
            $stopActionName = "Stop"
            
            # Get Db Node Ocids
            $dbNodeList = Get-AzOracleDbNode -Cloudvmclustername $env.vmClusterName -ResourceGroupName $env.resourceGroup
            $dbNodeOcid1 = $dbNodeList[0].Name
            
            Invoke-AzOracleActionDbNode -Cloudvmclustername $env.vmClusterName -Dbnodeocid $dbNodeOcid1 -ResourceGroupName $env.resourceGroup -Action $stopActionName
        } | Should -Not -Throw
    }
    It 'StartVm' {
        {
            $startActionName = "Start"
            
            # Get Db Node Ocids
            $dbNodeList = Get-AzOracleDbNode -Cloudvmclustername $env.vmClusterName -ResourceGroupName $env.resourceGroup
            $dbNodeOcid1 = $dbNodeList[0].Name
            
            Invoke-AzOracleActionDbNode -Cloudvmclustername $env.vmClusterName -Dbnodeocid $dbNodeOcid1 -ResourceGroupName $env.resourceGroup -Action $startActionName
        } | Should -Not -Throw
    }
    It 'DeleteVmCluster' {
        {
            Remove-AzOracleCloudVMCluster -NoWait -Name $env.vmClusterName -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}
