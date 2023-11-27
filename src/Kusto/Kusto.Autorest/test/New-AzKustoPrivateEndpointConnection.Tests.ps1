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
        $clusterName = $env.kustoClusterName
        $ResourceGroupName = $env.resourceGroupName

        # Set-AzContext -SubscriptionId $env.networkClustersTestsSubscriptionId

        $privateEndpointConnection = Get-AzKustoPrivateEndpointConnection -ClusterName $clusterName -ResourceGroupName $ResourceGroupName -SubscriptionId $env.subscriptionId
        $privateEndpointConnectionName = $privateEndpointConnection.Name

        $privateEndpointConnection.PrivateLinkServiceConnectionStateStatus = "Rejected"
        $privateEndpointConnection = New-AzKustoPrivateEndpointConnection -ClusterName $clusterName -ResourceGroupName $ResourceGroupName -SubscriptionId $env.subscriptionId -Parameter $privateEndpointConnection -Name $privateEndpointConnectionName
        $privateEndpointConnection = Get-AzKustoPrivateEndpointConnection -ClusterName $clusterName -ResourceGroupName $ResourceGroupName -SubscriptionId $env.subscriptionId
        $privateEndpointConnection.PrivateLinkServiceConnectionStateStatus | Should -Be "Rejected"

        $clusterName = $env.kustoClusterName
        $ResourceGroupName = $env.resourceGroupName
        Remove-AzKustoPrivateEndpointConnection -ClusterName $clusterName -ResourceGroupName $ResourceGroupName -SubscriptionId $env.subscriptionId -Name $privateEndpointConnectionName

        # Set-AzContext -SubscriptionId $env.SubscriptionId
    }

    It 'Create' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
