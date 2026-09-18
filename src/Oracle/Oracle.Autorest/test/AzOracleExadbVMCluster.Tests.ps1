if(($null -eq $TestName) -or ($TestName -contains 'AzOracleExadbVMCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzOracleExadbVMCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzOracleExadbVMCluster' {
    It 'CreateOracleExadbVMCluster' {
        {
            $sshPublicKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQDKJkePl4prXTs6cZ77AS9kGs5TO1EdfDdQZAtD7cfBVJ8X4wN+aOvLhk+u74D3qXad2OdQ/ij5q+xVzoXLXNBIZFQjB8JqWpgvOrOCAakFGc0OatJhSVlmJKW7JboQcUu7AzABfu+Ciso1QQTqlc2+awoZzPhfP9sgDMN6zI15Q9wSuxERor8oMSc78NW652wMzl97zO+bYdO9vIjBu27/WYZN/OpFJ0Ss4AzW/V9r2h6FFCkG+GXzhZArk3NeEstCSO2bjv3vO40+M0vfRD2jQrOSKhaLolk+crLGamaclY0YYCVB23rk6gCimWbVuvpHn+x1QSvN2d19xAmrIsHdTv/1lCEJetMA96pBq/jbljPwVKPFfVkyC8Ivt5rkbYizmUlYAbDMksGMUR4ncjScY7o/S0JKs14HihOnCoSGVXhH1dDgc8AsI+Ujs+GGR4U8IXJGEpZmhdnLa6mDymvr1tLWdQaI2y5FuWxsy4diKjEsPxCrnqfxlZxFBbQ29AU= generated-by-azure"

            $dbStorageVault = Get-AzOracleExascaleDbStorageVault -Name $env.oracleExascaleDbStorageVaultName -ResourceGroupName $env.resourceGroup
            $dbStorageVaultId = $dbStorageVault.Id

            $oracleExadbVMCluster = New-AzOracleExadbVMCluster -Name $env.oracleExadbVMClusterName -ResourceGroupName $env.resourceGroup -Location $env.location -Zone $env.zone -ExascaleDbStorageVaultId $dbStorageVaultId -DisplayName $env.oracleExadbVMClusterName -EnabledEcpuCount $env.enabledEcpuCount -GridImageOcid $env.gridImageOcid -HostName $env.vmClusterHostName -NodeCount $env.nodeCount -Shape $env.exaScaleShape -SshPublicKey $sshPublicKey -VnetId $env.vnetId -SubnetId $env.subnetId -TotalEcpuCount $env.totalEcpuCount -VMFileSystemStorage $env.VMFileSystemStorage
            $oracleExadbVMCluster.Name | Should -Be $env.oracleExadbVMClusterName
        } | Should -Not -Throw
    }
    It 'GetOracleExadbVMCluster' {
        {
            $oracleExadbVMCluster = Get-AzOracleExadbVMCluster -Name $env.oracleExadbVMClusterName -ResourceGroupName $env.resourceGroup
            $oracleExadbVMCluster.Name | Should -Be $env.oracleExadbVMClusterName
        } | Should -Not -Throw
    }
    It 'ListOracleExadbVMClusters' {
        {
            $oracleExadbVMClusterList = Get-AzOracleExadbVMCluster
            $oracleExadbVMClusterList.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
    It 'UpdateOracleExadbVMCluster' {
        {
            $tagHashTable = @{'tagName'="tagValue"}
            Update-AzOracleExadbVMCluster -Name $env.oracleExadbVMClusterName -ResourceGroupName $env.resourceGroup -Tag $tagHashTable
            $dbStorageVault = Get-AzOracleExadbVMCluster -Name $env.oracleExadbVMClusterName -ResourceGroupName $env.resourceGroup
            $dbStorageVault.Tag.Get_Item("tagName") | Should -Be "tagValue"
        } | Should -Not -Throw
    }
    It 'StopVm' {
        {
            $stopActionName = "Stop"
            
            # Get Db Node Ocids
            $dbNodeList = Get-AzOracleExascaleDbNode -Exadbvmclustername $env.oracleExadbVMClusterName -ResourceGroupName $env.resourceGroup
            $dbNodeOcid1 = $dbNodeList[0].Name
            
            Invoke-AzOracleActionExascaleDbNode -Exadbvmclustername $env.oracleExadbVMClusterName -ExascaleDbNodeName $dbNodeOcid1 -ResourceGroupName $env.resourceGroup -Action $stopActionName
        } | Should -Not -Throw
    }
    It 'StartVm' {
        {
            $startActionName = "Start"
            
            # Get Db Node Ocids
            $dbNodeList = Get-AzOracleExascaleDbNode -Exadbvmclustername $env.oracleExadbVMClusterName -ResourceGroupName $env.resourceGroup
            $dbNodeOcid1 = $dbNodeList[0].Name
            
            Invoke-AzOracleActionExascaleDbNode -Exadbvmclustername $env.oracleExadbVMClusterName -ExascaleDbNodeName $dbNodeOcid1 -ResourceGroupName $env.resourceGroup -Action $startActionName
        } | Should -Not -Throw
    }
    It 'DeleteOracleExadbVMCluster' {
        {
            Remove-AzOracleExadbVMCluster -NoWait -Name $env.oracleExadbVMClusterName -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}
