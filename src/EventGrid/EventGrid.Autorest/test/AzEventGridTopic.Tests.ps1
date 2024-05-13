if(($null -eq $TestName) -or ($TestName -contains 'AzEventGridTopic'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzEventGridTopic.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzEventGridTopic' {
    It 'New-AzEventGridTopic'{
        {
            $inboundIpRule = New-AzEventGridInboundIPRuleObject -Action Allow -IPMask "12.18.176.1"
            $config = New-AzEventGridTopic -Name $env.topic -ResourceGroupName $env.resourceGroup -Location $env.location -PublicNetworkAccess Enabled -InboundIPRule $inboundIpRule
            $config.Name | Should -Be $env.topic
        } | Should -Not -Throw
    }

    It 'New-AzEventGridTopicEventSubscription'{
        {
            $obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl $env.EndpointUrl
            $config = New-AzEventGridTopicEventSubscription -EventSubscriptionName $env.TopicEventSub -ResourceGroupName $env.resourceGroup -TopicName $env.topic -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -EventDeliverySchema CloudEventSchemaV1_0 -Destination $obj
            $config.Name | Should -Be $env.TopicEventSub
        } | Should -Not -Throw
    }

    It 'New-AzEventGridTopicKey'{
        {
            $config = New-AzEventGridTopicKey -ResourceGroupName $env.resourceGroup -TopicName $env.topic -KeyName key1
            $config.key1 | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'New-AzEventGridTopicSpace'{
        {
            $config = New-AzEventGridTopicSpace -Name $env.topicSpace -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup -TopicTemplate "filter1"
            $config.Name | Should -Be $env.topicSpace
        } | Should -Not -Throw
    }

    It 'New-AzEventGridPermissionBinding' {
        {
            $config = New-AzEventGridClientGroup -Name $env.clientGroup -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup -Query "attributes.b IN ['a', 'b', 'c']"
            $config.Name | Should -Be $env.clientGroup

            $config = New-AzEventGridPermissionBinding -Name $env.permissionBind -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup -ClientGroupName $env.clientGroup -Permission Publisher -TopicSpaceName $env.topicSpace
            $config.Name | Should -Be $env.permissionBind
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridTopic'{
        {
            $config = Get-AzEventGridTopic -ResourceGroupName $env.resourceGroup -Name $env.topic
            $config.Name | Should -Be $env.topic
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridTopicEventSubscription'{
        {
            $config = Get-AzEventGridTopicEventSubscription -ResourceGroupName $env.resourceGroup -TopicName $env.topic -EventSubscriptionName $env.TopicEventSub
            $config.Name | Should -Be $env.TopicEventSub
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridTopicEventSubscriptionDeliveryAttribute'{
        {
            $config = Get-AzEventGridTopicEventSubscriptionDeliveryAttribute -ResourceGroupName $env.resourceGroup -EventSubscriptionName $env.TopicEventSub -TopicName $env.topic
            $config.Count | Should -Be 0
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridTopicEventSubscriptionFullUrl'{
        {
            $config = Get-AzEventGridTopicEventSubscriptionFullUrl -ResourceGroupName $env.resourceGroup -EventSubscriptionName $env.TopicEventSub -TopicName $env.topic
            $config.EndpointUrl | Should -Be $env.EndpointUrl
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridTopicEventType'{
        {
            $config = Get-AzEventGridTopicEventType -ProviderNamespace "Microsoft.EventGrid" -ResourceGroupName $env.resourceGroup -ResourceName $env.topic -ResourceTypeName "topics"
            $config.Count | Should -Be 0
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridTopicKey'{
        {
            $config = Get-AzEventGridTopicKey -ResourceGroupName $env.resourceGroup -TopicName $env.topic
            $config.key1 | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridTopicSpace'{
        {
            $config = Get-AzEventGridTopicSpace -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup -Name $env.topicSpace
            $config.Name | Should -Be $env.topicSpace
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridTopicType'{
        {
            $config = Get-AzEventGridTopicType -Name Microsoft.EventGrid.Namespaces
            $config.Count | Should -Be 1
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridTopicTypeEventType'{
        {
            $config = Get-AzEventGridTopicTypeEventType -TopicTypeName Microsoft.Eventhub.Namespaces
            $config.Count | Should -Be 1
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridPermissionBinding' {
        {
            $config = Get-AzEventGridPermissionBinding -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.permissionBind
            $config.Name | Should -Be $env.permissionBind
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridTopic'{
        {
            $inboundIpRule = New-AzEventGridInboundIPRuleObject -Action Allow -IPMask "12.18.176.1"
            $config = Update-AzEventGridTopic -Name $env.topic -ResourceGroupName $env.resourceGroup -PublicNetworkAccess Enabled -InboundIPRule $inboundIpRule
            $config.Name | Should -Be $env.topic
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridTopicEventSubscription'{
        {
            $obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl $env.EndpointUrl
            $config = Update-AzEventGridTopicEventSubscription -EventSubscriptionName $env.TopicEventSub -ResourceGroupName $env.resourceGroup -TopicName $env.topic -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -EventDeliverySchema CloudEventSchemaV1_0 -Destination $obj
            $config.Name | Should -Be $env.TopicEventSub
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridTopicSpace'{
        {
            $config = Update-AzEventGridTopicSpace -Name $env.topicSpace -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup -TopicTemplate "filter1"
            $config.Name | Should -Be $env.topicSpace
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridPermissionBinding' {
        {
            $config = Update-AzEventGridPermissionBinding -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.permissionBind -ClientGroupName $env.clientGroup -Permission Publisher -TopicSpaceName $env.topicSpace
            $config.Name | Should -Be $env.permissionBind
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridPermissionBinding' {
        {
            Remove-AzEventGridPermissionBinding -Name $env.permissionBind -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup

            Remove-AzEventGridClientGroup -Name $env.clientGroup -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridTopicSpace'{
        {
            Remove-AzEventGridTopicSpace -Name $env.topicSpace -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridTopicEventSubscription'{
        {
            Remove-AzEventGridTopicEventSubscription -EventSubscriptionName $env.TopicEventSub -ResourceGroupName $env.resourceGroup -TopicName $env.topic
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridTopic'{
        {
            Remove-AzEventGridTopic -Name $env.topic -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}
