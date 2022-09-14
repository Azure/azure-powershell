if(($null -eq $TestName) -or ($TestName -contains 'Set-AzEventHubConsumerGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzEventHubConsumerGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzEventHubConsumerGroup' {
    It 'SetExpanded' {
        $consumerGroup = Set-AzEventHubConsumerGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name $env.consumerGroup -UserMetadata "Second Metadata"
        $consumerGroup.Name | Should -Be $env.consumerGroup
        $consumerGroup.ResourceGroupName | Should -Be $env.resourceGroup
        $consumerGroup.UserMetadata | Should -Be "Second Metadata"
    }

    It 'SetViaIdentityExpanded' {
        $consumerGroup = Get-AzEventHubConsumerGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name $env.consumerGroup
        $consumerGroup = Set-AzEventHubConsumerGroup -InputObject $consumerGroup -UserMetadata "Third Metadata"
        $consumerGroup.Name | Should -Be $env.consumerGroup
        $consumerGroup.ResourceGroupName | Should -Be $env.resourceGroup
        $consumerGroup.UserMetadata | Should -Be "Third Metadata"
    }
}
