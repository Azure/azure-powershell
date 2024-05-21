if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzEventHubConsumerGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzEventHubConsumerGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzEventHubConsumerGroup' {
    It 'Delete' {
        New-AzEventHubConsumerGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name consumerGroup
        Remove-AzEventHubConsumerGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name consumerGroup
        { Get-AzEventHubConsumerGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name consumerGroup -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity'  {
        $consumerGroup = New-AzEventHubConsumerGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name consumerGroup
        Remove-AzEventHubConsumerGroup -InputObject $consumerGroup
        { Get-AzEventHubConsumerGroup -InputObject $consumerGroup -ErrorAction Stop } | Should -Throw
    }
}
