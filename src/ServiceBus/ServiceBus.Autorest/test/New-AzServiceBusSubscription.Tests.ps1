if(($null -eq $TestName) -or ($TestName -contains 'New-AzServiceBusSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceBusSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzServiceBusSubscription' {
    It 'CreateExpanded' {
        $sub = New-AzServiceBusSubscription -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name subscription2 -LockDuration (New-TimeSpan -Minutes 3) -DeadLetteringOnMessageExpiration -MaxDeliveryCount 12 -Status Active -EnableBatchedOperations -ForwardTo queue1 -ForwardDeadLetteredMessagesTo queue1 -DefaultMessageTimeToLive (New-TimeSpan -Days 428 -Hours 3 -Minutes 11 -Seconds 10)
        $sub.Name | Should -Be "subscription2"
        $sub.ResourceGroupName | Should -Be $env.resourceGroup
        $sub.LockDuration | Should -Be (New-TimeSpan -Minutes 3)
        $sub.DeadLetteringOnMessageExpiration | Should -Be $true
        $sub.MaxDeliveryCount | Should -Be 12
        $sub.Status | Should -Be "Active"
        $sub.EnableBatchedOperations | Should -Be $true
        $sub.DefaultMessageTimeToLive | Should -Be (New-TimeSpan -Days 428 -Hours 3 -Minutes 11 -Seconds 10)
        $sub.ForwardTo | Should -Be "queue1"
        $sub.ForwardDeadLetteredMessagesTo | Should -Be "queue1"

        $sub = New-AzServiceBusSubscription -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name 'subscription3$$D' -RequiresSession -AutoDeleteOnIdle (New-TimeSpan -Days 7) -DeadLetteringOnFilterEvaluationException -IsClientAffine -ClientId clientid -IsShared -IsDurable
        $sub.Name | Should -Be 'subscription3$$D'
        $sub.ResourceGroupName | Should -Be $env.resourceGroup
        $sub.AutoDeleteOnIdle | Should -Be (New-TimeSpan -Days 7)
        $sub.DeadLetteringOnFilterEvaluationException | Should -Be $true
        $sub.IsClientAffine | Should -Be $true
        $sub.ClientId | Should -Be "clientid"
        $sub.IsShared | Should -Be $true
        $sub.IsDurable | Should -Be $true

        $listOfSubscription = Get-AzServiceBusSubscription -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1
        $listOfSubscription.Count | Should -Be 3
    }
}
