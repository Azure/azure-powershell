if(($null -eq $TestName) -or ($TestName -contains 'AzEventGridSystemTopic'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzEventGridSystemTopic.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzEventGridSystemTopic' {
    It 'New-AzEventGridSystemTopic' {
        {
            $config = New-AzEventGridSystemTopic -Name $env.sysTopic -ResourceGroupName $env.resourceGroup -Location $env.location -Source "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.resourceGroup)/providers/Microsoft.Storage/storageAccounts/$($env.StorageAccount)" -TopicType "microsoft.storage.storageaccounts"
            $config.Name | Should -Be $env.sysTopic
        } | Should -Not -Throw
    }

    It 'New-AzEventGridSystemTopicEventSubscription' {
        {
            $obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl $env.EndpointUrl
            $config = New-AzEventGridSystemTopicEventSubscription -EventSubscriptionName $env.sysTopicEventSub -ResourceGroupName $env.resourceGroup -SystemTopicName $env.sysTopic -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -Destination $obj
            $config.Name | Should -Be $env.sysTopicEventSub
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridSystemTopic' {
        {
            $config = Get-AzEventGridSystemTopic -ResourceGroupName $env.resourceGroup -Name $env.sysTopic
            $config.Name | Should -Be $env.sysTopic
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridSystemTopicEventSubscription' {
        {
            $config = Get-AzEventGridSystemTopicEventSubscription -ResourceGroupName $env.resourceGroup -SystemTopicName $env.sysTopic -EventSubscriptionName $env.sysTopicEventSub
            $config.Name | Should -Be $env.sysTopicEventSub
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridSystemTopicEventSubscriptionDeliveryAttribute' {
        {
            $config = Get-AzEventGridSystemTopicEventSubscriptionDeliveryAttribute -EventSubscriptionName $env.sysTopicEventSub -ResourceGroupName $env.resourceGroup -SystemTopicName $env.sysTopic
            $config.Count | Should -Be 0
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridFullUrlForSystemTopicEventSubscription' {
        {
            $config = Get-AzEventGridFullUrlForSystemTopicEventSubscription -ResourceGroupName $env.resourceGroup -SystemTopicName $env.sysTopic -EventSubscriptionName $env.sysTopicEventSub
            $config.EndpointUrl | Should -Be $env.EndpointUrl
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridSystemTopic' {
        {
            $config = Update-AzEventGridSystemTopic -Name $env.sysTopic -ResourceGroupName $env.resourceGroup -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.sysTopic
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridSystemTopicEventSubscription' {
        {
            $obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl $env.EndpointUrl
            $config = Update-AzEventGridSystemTopicEventSubscription -EventSubscriptionName $env.sysTopicEventSub -ResourceGroupName $env.resourceGroup -SystemTopicName $env.sysTopic -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -Destination $obj
            $config.Name | Should -Be $env.sysTopicEventSub
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridSystemTopicEventSubscription' {
        {
            Remove-AzEventGridSystemTopicEventSubscription -EventSubscriptionName $env.sysTopicEventSub -ResourceGroupName $env.resourceGroup -SystemTopicName $env.sysTopic
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridSystemTopic' {
        {
            Remove-AzEventGridSystemTopic -Name $env.sysTopic -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}
