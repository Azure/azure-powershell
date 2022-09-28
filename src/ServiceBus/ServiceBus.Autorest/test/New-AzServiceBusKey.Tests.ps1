if(($null -eq $TestName) -or ($TestName -contains 'New-AzServiceBusKey'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceBusKey.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}


Describe 'New-AzServiceBusKey' {
    It 'NewExpandedNamespace' {
        $currentKeys = Get-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule1
        
        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule1 -KeyType PrimaryKey
        $newKeys.PrimaryKey | Should -Not -Be $currentKeys.PrimaryKey
        $newKeys.SecondaryKey | Should -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys

        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule1 -KeyType SecondaryKey
        $newKeys.PrimaryKey | Should -Be $currentKeys.PrimaryKey
        $newKeys.SecondaryKey | Should -Not -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys

        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule1 -KeyType PrimaryKey -KeyValue $env.namespacePrimaryKey
        $newKeys.PrimaryKey | Should -Be $env.namespacePrimaryKey
        $newKeys.SecondaryKey | Should -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys

        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule1 -KeyType SecondaryKey -KeyValue $env.namespaceSecondaryKey
        $newKeys.PrimaryKey | Should -Be $env.namespacePrimaryKey
        $newKeys.SecondaryKey | Should -Be $env.namespaceSecondaryKey
    }

    It 'NewExpandedQueue' {
        $currentKeys = Get-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1 -Name queueAuthRule1
        
        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1 -Name queueAuthRule1 -KeyType PrimaryKey
        $newKeys.PrimaryKey | Should -Not -Be $currentKeys.PrimaryKey
        $newKeys.SecondaryKey | Should -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys

        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1 -Name queueAuthRule1 -KeyType SecondaryKey
        $newKeys.PrimaryKey | Should -Be $currentKeys.PrimaryKey
        $newKeys.SecondaryKey | Should -Not -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys

        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1 -Name queueAuthRule1 -KeyType PrimaryKey -KeyValue $env.queuePrimaryKey
        $newKeys.PrimaryKey | Should -Be $env.queuePrimaryKey
        $newKeys.SecondaryKey | Should -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys

        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1 -Name queueAuthRule1 -KeyType SecondaryKey -KeyValue $env.queueSecondaryKey
        $newKeys.PrimaryKey | Should -Be $env.queuePrimaryKey
        $newKeys.SecondaryKey | Should -Be $env.queueSecondaryKey
    }

    It 'NewExpandedTopic' {
        $currentKeys = Get-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name topicAuthRule1
        
        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name topicAuthRule1 -KeyType PrimaryKey
        $newKeys.PrimaryKey | Should -Not -Be $currentKeys.PrimaryKey
        $newKeys.SecondaryKey | Should -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys

        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name topicAuthRule1 -KeyType SecondaryKey
        $newKeys.PrimaryKey | Should -Be $currentKeys.PrimaryKey
        $newKeys.SecondaryKey | Should -Not -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys

        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name topicAuthRule1 -KeyType PrimaryKey -KeyValue $env.topicPrimaryKey
        $newKeys.PrimaryKey | Should -Be $env.topicPrimaryKey
        $newKeys.SecondaryKey | Should -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys

        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name topicAuthRule1 -KeyType SecondaryKey -KeyValue $env.topicSecondaryKey
        $newKeys.PrimaryKey | Should -Be $env.topicPrimaryKey
        $newKeys.SecondaryKey | Should -Be $env.topicSecondaryKey
    }
}
