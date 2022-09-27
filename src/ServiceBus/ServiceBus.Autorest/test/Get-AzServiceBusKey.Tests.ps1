if(($null -eq $TestName) -or ($TestName -contains 'Get-AzServiceBusKey'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzServiceBusKey.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzServiceBusKey' {
    It 'GetExpandedNamespace' {
        $namespaceKeys = Get-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule1
        $namespaceKeys.PrimaryKey | Should -Not -Be $null
        $namespaceKeys.SecondaryKey | Should -Not -Be $null
    }

    It 'GetExpandedQueue' {
        $queueKeys = Get-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1 -Name queueAuthRule1
        $queueKeys.PrimaryKey | Should -Not -Be $null
        $queueKeys.SecondaryKey | Should -Not -Be $null
    }

    It 'GetExpandedTopic' {
        $topicKeys = Get-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name topicAuthRule1
        $topicKeys.PrimaryKey | Should -Not -Be $null
        $topicKeys.SecondaryKey | Should -Not -Be $null
    }
}
