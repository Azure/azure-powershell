if(($null -eq $TestName) -or ($TestName -contains 'AzEventGridNamespace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzEventGridNamespace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzEventGridNamespace' {
    It 'New-AzEventGridNamespace' {
        {
            $config = New-AzEventGridNamespace -Name $env.namespace2 -ResourceGroupName $env.resourceGroup -Location $env.location -TopicSpaceConfigurationState Enabled
            $config.Name | Should -Be $env.namespace2
            $config.Location | Should -Be $env.location
            $config.TopicSpaceConfigurationState | Should -Be "Enabled"
        } | Should -Not -Throw
    }

    It 'New-AzEventGridNamespaceKey' {
        {
            $config = New-AzEventGridNamespaceKey -NamespaceName $env.namespace2 -ResourceGroupName $env.resourceGroup -KeyName key1
            $config.Key1 | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'New-AzEventGridNamespaceTopic' {
        {
            $config = New-AzEventGridNamespaceTopic -NamespaceName $env.namespace2 -ResourceGroupName $env.resourceGroup -TopicName $env.namespaceTopic -PublisherType Custom -EventRetentionInDay 1 -InputSchema CloudEventSchemaV1_0
            $config.Name | Should -Be $env.namespaceTopic
        } | Should -Not -Throw
    }

    It 'New-AzEventGridNamespaceTopicEventSubscription' {
        {
            $TimeSpan = New-TimeSpan -Hours 1 -Minutes 25
            $config = New-AzEventGridNamespaceTopicEventSubscription -EventSubscriptionName $env.namespaceTopicEventSub -NamespaceName $env.namespace2 -ResourceGroupName $env.resourceGroup -TopicName $env.namespaceTopic -DeliveryConfigurationDeliveryMode Queue -QueueReceiveLockDurationInSecond 60 -QueueMaxDeliveryCount 4 -QueueEventTimeToLive $TimeSpan -EventDeliverySchema CloudEventSchemaV1_0
            $config.Name | Should -Be $env.namespaceTopicEventSub
        } | Should -Not -Throw
    }

    It 'New-AzEventGridNamespaceTopicKey' {
        {
            $config = New-AzEventGridNamespaceTopicKey -NamespaceName $env.namespace2 -ResourceGroupName $env.resourceGroup -TopicName $env.namespaceTopic -KeyName key1
            $config.Key1 | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridNamespace' {
        {
            $config = Get-AzEventGridNamespace -ResourceGroupName $env.resourceGroup -Name $env.namespace2
            $config.Name | Should -Be $env.namespace2
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridNamespaceKey' {
        {
            $config = Get-AzEventGridNamespaceKey -ResourceGroupName $env.resourceGroup -Name $env.namespace2
            $config.Key1 | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridNamespaceTopic' {
        {
            $config = Get-AzEventGridNamespaceTopic -NamespaceName $env.namespace2 -ResourceGroupName $env.resourceGroup -TopicName $env.namespaceTopic
            $config.Name | Should -Be $env.namespaceTopic
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridNamespaceTopicEventSubscription' {
        {
            $config = Get-AzEventGridNamespaceTopicEventSubscription -NamespaceName $env.namespace2 -ResourceGroupName $env.resourceGroup -TopicName $env.namespaceTopic -EventSubscriptionName $env.namespaceTopicEventSub
            $config.Name | Should -Be $env.namespaceTopicEventSub
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridNamespaceTopicKey' {
        {
            $config = Get-AzEventGridNamespaceTopicKey -NamespaceName $env.namespace2 -ResourceGroupName $env.resourceGroup -TopicName $env.namespaceTopic
            $config.Key1 | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridNamespace' {
        {
            $config = Update-AzEventGridNamespace -Name $env.namespace2 -ResourceGroupName $env.resourceGroup -TopicSpaceConfigurationState Enabled -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.namespace2
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridNamespaceTopic' {
        {
            $config = Update-AzEventGridNamespaceTopic -NamespaceName $env.namespace2 -ResourceGroupName $env.resourceGroup -TopicName $env.namespaceTopic -EventRetentionInDay 1
            $config.Name | Should -Be $env.namespaceTopic
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridNamespaceTopicEventSubscription' {
        {
            $config = Update-AzEventGridNamespaceTopicEventSubscription -EventSubscriptionName $env.namespaceTopicEventSub -NamespaceName $env.namespace2 -ResourceGroupName $env.resourceGroup -TopicName $env.namespaceTopic -DeliveryConfigurationDeliveryMode Queue -EventDeliverySchema CloudEventSchemaV1_0
            $config.Name | Should -Be $env.namespaceTopicEventSub
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridNamespaceTopicEventSubscription' {
        {
            Remove-AzEventGridNamespaceTopicEventSubscription -EventSubscriptionName $env.namespaceTopicEventSub -NamespaceName $env.namespace2 -ResourceGroupName $env.resourceGroup -TopicName $env.namespaceTopic
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridNamespaceTopic' {
        {
            Remove-AzEventGridNamespaceTopic -NamespaceName $env.namespace2 -ResourceGroupName $env.resourceGroup -TopicName $env.namespaceTopic
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridNamespace' {
        {
            Remove-AzEventGridNamespace -Name $env.namespace2 -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}
