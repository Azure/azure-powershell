if(($null -eq $TestName) -or ($TestName -contains 'New-AzServiceBusQueue'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceBusQueue.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzServiceBusQueue' {
    It 'CreateExpanded' {
        $queue = New-AzServiceBusQueue -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name queue2 -LockDuration (New-TimeSpan -Minutes 4) -MaxMessageSizeInKilobytes 102400 -MaxSizeInMegabytes 4096 -RequiresDuplicateDetection -DuplicateDetectionHistoryTimeWindow (New-TimeSpan -Minutes 10) -DeadLetteringOnMessageExpiration -MaxDeliveryCount 8 -Status Active -EnableBatchedOperations:$false -DefaultMessageTimeToLive (New-TimeSpan -Days 428 -Hours 3 -Minutes 11 -Seconds 10) -ForwardTo $env.queue -ForwardDeadLetteredMessagesTo $env.queue
        $queue.Name | Should -Be "queue2"
        $queue.ResourceGroupName | Should -Be $env.resourceGroup
        $queue.LockDuration | Should -Be (New-TimeSpan -Minutes 4)
        $queue.DuplicateDetectionHistoryTimeWindow | Should -Be (New-TimeSpan -Minutes 10)
        $queue.DefaultMessageTimeToLive | Should -Be (New-TimeSpan -Days 428 -Hours 3 -Minutes 11 -Seconds 10)
        $queue.MaxSizeInMegabytes | Should -Be 4096
        $queue.RequiresDuplicateDetection | Should -Be $true
        $queue.DeadLetteringOnMessageExpiration | Should -Be $true
        $queue.MaxDeliveryCount | Should -Be 8
        $queue.EnableBatchedOperations | Should -Be $false
        $queue.ForwardTo | Should -Be $env.queue
        $queue.ForwardDeadLetteredMessagesTo | Should -Be $env.queue
        $queue.MaxMessageSizeInKilobytes | Should -Be 102400

        $queue2 = New-AzServiceBusQueue -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name queue3 -RequiresSession -EnableExpress -EnablePartitioning -AutoDeleteOnIdle (New-Timespan -Days 7)
        $queue2.Name | Should -Be "queue3"
        $queue2.ResourceGroupName | Should -Be $env.resourceGroup
        $queue2.EnablePartitioning | Should -Be $true
        $queue2.EnableExpress | Should -Be $true
        $queue2.RequiresSession | Should -Be $true
        $queue2.AutoDeleteOnIdle | Should -Be (New-TimeSpan -Days 7)

        $listOfQueues = Get-AzServiceBusQueue -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
        $listOfQueues.Count | Should -Be 3
    }
}
