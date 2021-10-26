if(($null -eq $TestName) -or ($TestName -contains 'New-AzKustoPrivateEndpointConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzKustoPrivateEndpointConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzKustoPrivateEndpointConnection' {
    It 'CreateExpanded' {
        $clusterName = $env.clusterNetwork
        $ResourceGroupName = $env.resourceGroupNamefordc

        # Set-AzContext -SubscriptionId $env.networkClustersTestsSubscriptionId

        $privateEndpointConnection = Get-AzKustoPrivateEndpointConnection -ClusterName $clusterName -ResourceGroupName $ResourceGroupName -SubscriptionId $env.networkClustersTestsSubscriptionId
        $privateEndpointConnectionName = $privateEndpointConnection.Name

        $privateEndpointConnection.PrivateLinkServiceConnectionStateStatus = $env.rejected
        $privateEndpointConnection = New-AzKustoPrivateEndpointConnection -ClusterName $clusterName -ResourceGroupName $ResourceGroupName -SubscriptionId $env.networkClustersTestsSubscriptionId -Parameter $privateEndpointConnection -Name $privateEndpointConnectionName
        
        Start-Sleep -Seconds 1.5

        $privateEndpointConnection = Get-AzKustoPrivateEndpointConnection -ClusterName $clusterName -ResourceGroupName $ResourceGroupName -SubscriptionId $env.networkClustersTestsSubscriptionId
        $privateEndpointConnection.PrivateLinkServiceConnectionStateStatus | Should -Be $env.rejected

        $clusterName = $env.clusterNetwork
        $ResourceGroupName = $env.resourceGroupNamefordc
        Remove-AzKustoPrivateEndpointConnection -ClusterName $clusterName -ResourceGroupName $ResourceGroupName -SubscriptionId $env.networkClustersTestsSubscriptionId -Name $privateEndpointConnectionName

        # Set-AzContext -SubscriptionId $env.SubscriptionId
    }

    It 'Create' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
