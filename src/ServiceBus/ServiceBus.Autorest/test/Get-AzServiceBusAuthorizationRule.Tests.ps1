if(($null -eq $TestName) -or ($TestName -contains 'Get-AzServiceBusAuthorizationRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzServiceBusAuthorizationRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzServiceBusAuthorizationRule' {
    $namespaceAuthRule = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule1
    $queueAuthRule = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1 -Name queueAuthRule1
    $topicAuthRule = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name topicAuthRule1
    
    It 'GetExpandedNamespace' {
        $namespaceAuthRule.Name | Should -Be "namespaceAuthRule1"
        $namespaceAuthRule.ResourceGroupName | Should -Be $env.resourceGroup
        $namespaceAuthRule.Rights.Count | Should -Be 3

        $listOfAuthRules = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
        $listOfAuthRules.Count | Should -Be 4
    }

    It 'GetExpandedQueue' {
        $queueAuthRule.Name | Should -Be "queueAuthRule1"
        $queueAuthRule.ResourceGroupName | Should -Be $env.resourceGroup
        $queueAuthRule.Rights.Count | Should -Be 3

        $listOfAuthRules = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1 
        $listOfAuthRules.Count | Should -Be 3
    }

    It 'GetExpandedTopic' {
        $topicAuthRule.Name | Should -Be "topicAuthRule1"
        $topicAuthRule.ResourceGroupName | Should -Be $env.resourceGroup
        $topicAuthRule.Rights.Count | Should -Be 3

        $listOfAuthRules = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 
        $listOfAuthRules.Count | Should -Be 3
    }

    It 'GetViaIdentityExpanded' {
        $namespaceAuthRule = Get-AzServiceBusAuthorizationRule -InputObject $namespaceAuthRule
        $namespaceAuthRule.Name | Should -Be "namespaceAuthRule1"
        $namespaceAuthRule.ResourceGroupName | Should -Be $env.resourceGroup
        $namespaceAuthRule.Rights.Count | Should -Be 3

        $queueAuthRule = Get-AzServiceBusAuthorizationRule -InputObject $queueAuthRule
        $queueAuthRule.Name | Should -Be "queueAuthRule1"
        $queueAuthRule.ResourceGroupName | Should -Be $env.resourceGroup
        $queueAuthRule.Rights.Count | Should -Be 3

        $topicAuthRule = Get-AzServiceBusAuthorizationRule -InputObject $topicAuthRule
        $topicAuthRule.Name | Should -Be "topicAuthRule1"
        $topicAuthRule.ResourceGroupName | Should -Be $env.resourceGroup
        $topicAuthRule.Rights.Count | Should -Be 3
    }
}
