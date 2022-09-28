if(($null -eq $TestName) -or ($TestName -contains 'New-AzEventHubConsumerGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzEventHubConsumerGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzEventHubConsumerGroup' {
    It 'CreateExpanded' {
        # Testing creation of consumer group
        $consumerGroup = New-AzEventHubConsumerGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name $env.consumerGroup2 -UserMetadata "Test Metadata"
        $consumerGroup.Name | Should -Be $env.consumerGroup2
        $consumerGroup.ResourceGroupName | Should -Be $env.resourceGroup
        $consumerGroup.UserMetadata | Should -Be "Test Metadata"

        # Creating another consumer group to test Remove-AzEventHubConsumerGroup
        $consumerGroup = New-AzEventHubConsumerGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name $env.consumerGroup3 -UserMetadata "Test Metadata"
    }
}
