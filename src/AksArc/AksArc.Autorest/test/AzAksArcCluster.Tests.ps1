if(($null -eq $TestName) -or ($TestName -contains 'New-AzAksArcCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzAksArcCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzAksArc' {
    It 'CreateCluster' -skip {
        { 
            $config = New-AzAksArcCluster -ClusterName $env.clusterName1 -ResourceGroupName $env.ResourceGroupName1 -CustomLocationName $env.customLocationId1 -VnetId $env.lnetId1 -ControlPlaneIP $env.controlPlaneIP1 -KubernetesVersion 1.28.3
            $config.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'GetCluster' {
        { 
            $config = Get-AzAksArcCluster -ClusterName $env.clusterName1 -ResourceGroupName $env.ResourceGroupName1
            $config.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'UpgradeCluster' -skip {
        { 
            $config = Invoke-AzAksArcClusterUpgrade -ClusterName $env.clusterName1 -ResourceGroupName $env.ResourceGroupName1
            $config.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'UpdateCluster' {
        { 
            $config = Update-AzAksArcCluster -ClusterName $env.clusterName1 -ResourceGroupName $env.ResourceGroupName1 -ControlPlaneCount 3
            $config.ProvisioningState | Should -Be 'Succeeded'
            $config.ControlPlaneCount | Should -Be 3
        } | Should -Not -Throw
    }

    It 'GetKubernetesVersion' {
        { 
            $config = Get-AzAksArcKubernetesVersion -CustomLocationName $env.customLocationId1
        } | Should -Not -Throw
    }

    It 'GetVMSku' {
        { 
            $config = Get-AzAksArcVMSku -CustomLocationName $env.customLocationId1
        } | Should -Not -Throw
    }

    It 'GetUpgrades' {
        { 
            $config = Get-AzAksArcClusterUpgrade -ClusterName $env.clusterName1 -ResourceGroupName $env.ResourceGroupName1
        } | Should -Not -Throw
    }

    It 'GetUserKubeConfig' {
        { 
            $config = Get-AzAksArcClusterUserKubeconfig -ClusterName $env.clusterName1 -ResourceGroupName $env.ResourceGroupName1
        } | Should -Not -Throw
    }

    It 'GetAdminKubeConfig' {
        { 
            $config = Get-AzAksArcClusterAdminKubeconfig -ClusterName $env.clusterName1 -ResourceGroupName $env.ResourceGroupName1
        } | Should -Not -Throw
    }

    It 'CreateNodepool' -skip {
        { 
            $config = New-AzAksArcNodepool -ClusterName $env.clusterName1 -ResourceGroupName $env.ResourceGroupName1 -Name $env.NodepoolName1
            $config.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'ListNodepools' {
        { 
            $config = Get-AzAksArcNodepool -ClusterName $env.clusterName1 -ResourceGroupName $env.ResourceGroupName1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetNodepool' {
        { 
            $config = Get-AzAksArcNodepool -ClusterName $env.clusterName1 -ResourceGroupName $env.ResourceGroupName1 -Name $env.NodepoolName1
        } | Should -Not -Throw
    }

    It 'UpdateNodepool' {
        { 
            $config = Update-AzAksArcNodepool -ClusterName $env.clusterName1 -ResourceGroupName $env.ResourceGroupName1 -Name $env.NodepoolName1 -Count 3
            $config.ProvisioningState | Should -Be 'Succeeded'
            $config.Count | Should -Be 3
        } | Should -Not -Throw
    }

    It 'RemoveCluster' -skip {
        { 
            $config = Remove-AzAksArcCluster -ClusterName $env.clusterName1 -ResourceGroupName $env.ResourceGroupName1
        } | Should -Not -Throw
    }
}
