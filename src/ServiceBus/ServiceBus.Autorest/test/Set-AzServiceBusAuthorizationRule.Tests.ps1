if(($null -eq $TestName) -or ($TestName -contains 'Set-AzServiceBusAuthorizationRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzServiceBusAuthorizationRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzServiceBusAuthorizationRule' {
    It 'SetExpandedNamespace' {
        $authRule = Set-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule1 -Rights @("Send","Listen","Manage")
        $authRule.Name | Should -Be "namespaceAuthRule1"
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 3
    }

    It 'SetExpandedQueue' {
        $authRule = Set-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1 -Name queueAuthRule1 -Rights @("Send")
        $authRule.Name | Should -Be "queueAuthRule1"
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 1
    }

    It 'SetExpandedTopic' {
        $authRule = Set-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name topicAuthRule1 -Rights @("Listen")
        $authRule.Name | Should -Be "topicAuthRule1"
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 1
    }

    It 'SetViaIdentityExpanded' {
        $authRule = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule1
        $authRule = Set-AzServiceBusAuthorizationRule -InputObject $authRule -Rights @('Send')
        $authRule.Name | Should -Be "namespaceAuthRule1"
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 1

        $authRule = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1 -Name queueAuthRule1
        $authRule = Set-AzServiceBusAuthorizationRule -InputObject $authRule -Rights @('Listen','Manage','Send')
        $authRule.Name | Should -Be "queueAuthRule1"
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 3

        New-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name topicAuthRule1 -Rights @('Send')
        $authRule = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name topicAuthRule1
        $authRule = Set-AzServiceBusAuthorizationRule -InputObject $authRule -Rights @('Listen','Manage','Send')
        $authRule.Name | Should -Be "topicAuthRule1"
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 3
    }
}
