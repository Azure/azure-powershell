if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEventHubConsumerGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEventHubConsumerGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEventHubConsumerGroup' {
    It 'List' {
        $listOfConsumerGroup = Get-AzEventHubConsumerGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub
        $listOfConsumerGroup.Count | Should -Be 1
        $listOfConsumerGroup[0].Name | Should -Be $env.consumerGroup
    }

    It 'Get' {
        $consumerGroup = Get-AzEventHubConsumerGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name $env.consumerGroup
        $consumerGroup.ResourceGroupName | Should -Be $env.resourceGroup
        $consumerGroup.Name | Should -Be $env.consumerGroup
    }

    It 'GetViaIdentity' {
        $consumerGroup = Get-AzEventHubConsumerGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name $env.consumerGroup
        
        $consumerGroup = Get-AzEventHubConsumerGroup -InputObject $consumerGroup
        $consumerGroup.ResourceGroupName | Should -Be $env.resourceGroup
        $consumerGroup.Name | Should -Be $env.consumerGroup

        $consumerGroup = Get-AzEventHubConsumerGroup -InputObject $consumerGroup.Id
        $consumerGroup.ResourceGroupName | Should -Be $env.resourceGroup
        $consumerGroup.Name | Should -Be $env.consumerGroup
    }
}
