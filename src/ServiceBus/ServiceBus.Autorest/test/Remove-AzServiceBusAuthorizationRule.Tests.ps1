if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzServiceBusAuthorizationRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzServiceBusAuthorizationRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzServiceBusAuthorizationRule' {
    $namespaceAuthRules = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
    $queueAuthRules = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1
    $topicAuthRules = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1

    $namespaceAuthRules.Count | Should -Be 4
    $queueAuthRules.Count | Should -Be 3
    $topicAuthRules.Count | Should -Be 3

    It 'RemoveExpandedNamespace' {
        Remove-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule3
        { Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule3 -ErrorAction Stop } | Should -Throw
        $namespaceAuthRules = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
        $namespaceAuthRules.Count | Should -Be 3
    }

    It 'RemoveExpandedTopic'  {
        Remove-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name topicAuthRule3
        { Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name topicAuthRule3 -ErrorAction Stop } | Should -Throw
        $topicAuthRules = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 
        $topicAuthRules.Count | Should -Be 2
    }

    It 'RemoveExpandedQueue' {
        Remove-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1 -Name queueAuthRule3
        { Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1 -Name queueAuthRule3 -ErrorAction Stop } | Should -Throw
        $queueAuthRules = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1 
        $queueAuthRules.Count | Should -Be 2
    }

    It 'RemoveViaIdentityExpanded'   {
        $authRule = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule2
        Remove-AzServiceBusAuthorizationRule -InputObject $authRule
        { Get-AzServiceBusAuthorizationRule -InputObject $authRule -ErrorAction Stop } | Should -Throw
        $namespaceAuthRules = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
        $namespaceAuthRules.Count | Should -Be 2

        $authRule = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1 -Name queueAuthRule2
        Remove-AzServiceBusAuthorizationRule -InputObject $authRule
        { Get-AzServiceBusAuthorizationRule -InputObject $authRule -ErrorAction Stop } | Should -Throw
        $queueAuthRules = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1
        $queueAuthRules.Count | Should -Be 1

        $authRule = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name topicAuthRule2
        Remove-AzServiceBusAuthorizationRule -InputObject $authRule
        { Get-AzServiceBusAuthorizationRule -InputObject $authRule -ErrorAction Stop } | Should -Throw
        $topicAuthRules = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1
        $topicAuthRules.Count | Should -Be 1
    }
}
