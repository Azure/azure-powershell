if(($null -eq $TestName) -or ($TestName -contains 'New-AzHorizonDbCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzHorizonDbCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzHorizonDbCluster' {
    It 'CreateExpanded' {
        $resourceGroupName = $env.clusterResourceGroup
        $newClusterName = $env.clusterName

        $cluster = New-AzHorizonDbCluster -ResourceGroupName $resourceGroupName -Name $newClusterName -SubscriptionId $env.SubscriptionId -Location $env.location -PostgreSqlVersion '17' -BackupGeoRedundancy 'Disabled' -NetworkPublicAccess 'Disabled' -ErrorAction Stop

        $cluster.Name | Should -Be $newClusterName
        $cluster.ResourceGroupName | Should -Be $resourceGroupName
        $cluster.Location | Should -Be 'indiasouthcentral'
        $cluster.PostgreSqlVersion | Should -Be '17'
        $cluster.BackupGeoRedundancy | Should -Be 'Disabled'
        $cluster.NetworkPublicAccess | Should -Be 'Disabled'
        $cluster.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'Delete' {
        $resourceGroupName = $env.clusterResourceGroup
        $newClusterName = $env.clusterName + '-delete'
        $cluster = New-AzHorizonDbCluster -ResourceGroupName $resourceGroupName -Name $newClusterName -SubscriptionId $env.SubscriptionId -Location $env.location -PostgreSqlVersion '17' -BackupGeoRedundancy 'Disabled' -NetworkPublicAccess 'Disabled' -ErrorAction Stop
        $cluster.Name | Should -Be $newClusterName
        $cluster.ProvisioningState | Should -Be 'Succeeded'

        $removed = Remove-AzHorizonDbCluster -ResourceGroupName $resourceGroupName -Name $newClusterName -SubscriptionId $env.SubscriptionId -PassThru -Confirm:$false -ErrorAction Stop
        $removed | Should -Be $true

        $clusters = @(Get-AzHorizonDbCluster -ResourceGroupName $resourceGroupName -SubscriptionId $env.SubscriptionId -ErrorAction Stop)
        @($clusters | Where-Object { $_.Name -eq $newClusterName }).Count | Should -Be 0
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
