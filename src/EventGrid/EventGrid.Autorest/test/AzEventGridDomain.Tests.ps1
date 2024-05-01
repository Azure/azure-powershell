if(($null -eq $TestName) -or ($TestName -contains 'AzEventGridDomain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzEventGridDomain.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzEventGridDomain' {
    It 'New-AzEventGridDomain' {
        {
            $inboundIpRule = New-AzEventGridInboundIPRuleObject -Action Allow -IPMask "12.18.176.1"
            $config = New-AzEventGridDomain -Name $env.domain -ResourceGroupName $env.resourceGroup -Location westus2 -PublicNetworkAccess Enabled -InboundIPRule $inboundIpRule
            $config.Name | Should -Be $env.domain
        } | Should -Not -Throw
    }

    It 'New-AzEventGridDomainEventSubscription' {
        {
            $obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl $env.EndpointUrl
            $config = New-AzEventGridDomainEventSubscription -DomainName $env.domain -EventSubscriptionName $env.domainEventSub -ResourceGroupName $env.resourceGroup -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -Destination $obj
            $config.Name | Should -Be $env.domainEventSub
        } | Should -Not -Throw
    }

    It 'New-AzEventGridDomainKey' {
        {
            $config = New-AzEventGridDomainKey -DomainName $env.domain -ResourceGroupName $env.resourceGroup -KeyName key1
            $config.Key1 | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'New-AzEventGridDomainTopic' {
        {
            $config = New-AzEventGridDomainTopic -DomainName $env.domain -ResourceGroupName $env.resourceGroup -Name $env.domainTopic
            $config.Name | Should -Be $env.domainTopic
        } | Should -Not -Throw
    }

    It 'New-AzEventGridDomainTopicEventSubscription' {
        {
            $obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl $env.EndpointUrl
            $config = New-AzEventGridDomainTopicEventSubscription -DomainName $env.domain -EventSubscriptionName $env.domainTopicEventSub -ResourceGroupName $env.resourceGroup -TopicName $env.domainTopic -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -Destination $obj
            $config.Name | Should -Be $env.domainTopicEventSub
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridDomain' {
        {
            $config = Get-AzEventGridDomain -ResourceGroupName $env.resourceGroup -Name $env.domain
            $config.Name | Should -Be $env.domain
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridDomainEventSubscription' {
        {
            $config = Get-AzEventGridDomainEventSubscription -DomainName $env.domain -ResourceGroupName $env.resourceGroup -EventSubscriptionName $env.domainEventSub
            $config.Name | Should -Be $env.domainEventSub
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridDomainEventSubscriptionDeliveryAttribute' {
        {
            $config = Get-AzEventGridDomainEventSubscriptionDeliveryAttribute -ResourceGroupName $env.resourceGroup -DomainName $env.domain -EventSubscriptionName $env.domainEventSub
            $config.Count | Should -Be 0
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridDomainEventSubscriptionFullUrl' {
        {
            $config = Get-AzEventGridDomainEventSubscriptionFullUrl -ResourceGroupName $env.resourceGroup -DomainName $env.domain -EventSubscriptionName $env.domainEventSub
            $config.EndpointUrl | Should -Be $env.EndpointUrl
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridDomainKey' {
        {
            $config = Get-AzEventGridDomainKey -DomainName $env.domain -ResourceGroupName $env.resourceGroup
            $config.Key1 | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridDomainTopic' {
        {
            $config = Get-AzEventGridDomainTopic -DomainName $env.domain -ResourceGroupName $env.resourceGroup -Name $env.domainTopic
            $config.Name | Should -Be $env.domainTopic
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridDomainTopicEventSubscription' {
        {
            $config = Get-AzEventGridDomainTopicEventSubscription -DomainName $env.domain -ResourceGroupName $env.resourceGroup -TopicName $env.domainTopic -EventSubscriptionName $env.domainTopicEventSub
            $config.Name | Should -Be $env.domainTopicEventSub
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridDomainTopicEventSubscriptionDeliveryAttribute' {
        {
            $config = Get-AzEventGridDomainTopicEventSubscriptionDeliveryAttribute -DomainName $env.domain -ResourceGroupName $env.resourceGroup -TopicName $env.domainTopic -EventSubscriptionName $env.domainTopicEventSub
            $config.Count | Should -Be 0
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridDomainTopicEventSubscriptionFullUrl' {
        {
            $config = Get-AzEventGridDomainTopicEventSubscriptionFullUrl -DomainName $env.domain -ResourceGroupName $env.resourceGroup -TopicName $env.domainTopic -EventSubscriptionName $env.domainTopicEventSub
            $config.EndpointUrl | Should -Be $env.EndpointUrl
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridDomain' {
        {
            $inboundIpRule = New-AzEventGridInboundIPRuleObject -Action Allow -IPMask "12.18.176.1"
            $config = Update-AzEventGridDomain -Name $env.domain -ResourceGroupName $env.resourceGroup -PublicNetworkAccess Enabled -InboundIPRule $inboundIpRule
            $config.Name | Should -Be $env.domain
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridDomainEventSubscription' {
        {
            $obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl $env.EndpointUrl
            $config = Update-AzEventGridDomainEventSubscription -DomainName $env.domain -EventSubscriptionName $env.domainEventSub -ResourceGroupName $env.resourceGroup -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -Destination $obj
            $config.Name | Should -Be $env.domainEventSub
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridDomainTopicEventSubscription' {
        {
            $obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl $env.EndpointUrl
            $config = Update-AzEventGridDomainTopicEventSubscription -DomainName $env.domain -EventSubscriptionName $env.domainTopicEventSub -ResourceGroupName $env.resourceGroup -TopicName $env.domainTopic -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -Destination $obj
            $config.Name | Should -Be $env.domainTopicEventSub
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridDomainTopicEventSubscription' {
        {
            Remove-AzEventGridDomainTopicEventSubscription -DomainName $env.domain -EventSubscriptionName $env.domainTopicEventSub -ResourceGroupName $env.resourceGroup -TopicName $env.domainTopic
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridDomainEventSubscription' {
        {
            Remove-AzEventGridDomainEventSubscription -DomainName $env.domain -EventSubscriptionName $env.domainEventSub -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridDomainTopic' {
        {
            Remove-AzEventGridDomainTopic -DomainName $env.domain -ResourceGroupName $env.resourceGroup -Name $env.domainTopic
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridDomain' {
        {
            Remove-AzEventGridDomain -Name $env.domain -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}
