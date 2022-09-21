if(($null -eq $TestName) -or ($TestName -contains 'New-AzServiceBusAuthorizationRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceBusAuthorizationRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzServiceBusAuthorizationRule' {
    It 'NewExpandedNamespace' {
        $authRule = New-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule3 -Rights @("Send", "Manage", "Listen")
        $authRule.Name | Should -Be "namespaceAuthRule3"
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 3

        $listOfAuthRules = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
        $listOfAuthRules.Count | Should -Be 4
    }

    It 'NewExpandedQueue' {
        $authRule = New-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1 -Name queueAuthRule3 -Rights @("Listen")
        $authRule.Name | Should -Be "queueAuthRule3"
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 1

        $listOfAuthRules = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1
        $listOfAuthRules.Count | Should -Be 3
    }

    It 'NewExpandedTopic' {
        $authRule = New-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name topicAuthRule3 -Rights @("Send")
        $authRule.Name | Should -Be "topicAuthRule3"
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 1

        $listOfAuthRules = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1
        $listOfAuthRules.Count | Should -Be 3
    }
}
