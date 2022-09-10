if(($null -eq $TestName) -or ($TestName -contains 'Set-AzServiceBusQueue'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzServiceBusQueue.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

function AssertQueueUpdates{
    param([Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbQueue]$expectedQueue,[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbQueue]$actualQueue)
    $expectedQueue.Name | Should -Be $actualQueue.Name
    $expectedQueue.ResourceGroupName | Should -Be $actualQueue.ResourceGroupName
    $expectedQueue.LockDuration | Should -Be $actualQueue.LockDuration
    $expectedQueue.DuplicateDetectionHistoryTimeWindow | Should -Be $actualQueue.DuplicateDetectionHistoryTimeWindow
    $expectedQueue.DefaultMessageTimeToLive | Should -Be $actualQueue.DefaultMessageTimeToLive
    $expectedQueue.MaxSizeInMegabytes | Should -Be $actualQueue.MaxSizeInMegabytes
    $expectedQueue.RequiresDuplicateDetection | Should -Be $actualQueue.RequiresDuplicateDetection
    $expectedQueue.DeadLetteringOnMessageExpiration | Should -Be $actualQueue.DeadLetteringOnMessageExpiration
    $expectedQueue.MaxDeliveryCount | Should -Be $actualQueue.MaxDeliveryCount
    $expectedQueue.EnableBatchedOperations | Should -Be $actualQueue.EnableBatchedOperations
    $expectedQueue.ForwardTo | Should -Be $actualQueue.ForwardTo
    $expectedQueue.ForwardDeadLetteredMessagesTo | Should -Be $actualQueue.ForwardDeadLetteredMessagesTo
    $expectedQueue.MaxMessageSizeInKilobytes | Should -Be $actualQueue.MaxMessageSizeInKilobytes
    $expectedQueue.EnablePartitioning | Should -Be $actualQueue.EnablePartitioning
    $expectedQueue.EnableExpress | Should -Be $actualQueue.EnableExpress
    $expectedQueue.RequiresSession | Should -Be $actualQueue.RequiresSession
    $expectedQueue.AutoDeleteOnIdle | Should -Be $actualQueue.AutoDeleteOnIdle
}

Describe 'Set-AzServiceBusQueue' {
    It 'SetExpanded' {
        $currentQueue = Get-AzServiceBusQueue -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name queue2
        
        $updatedQueue = Set-AzServiceBusQueue -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name queue2 -AutoDeleteOnIdle (New-TimeSpan -Days 1 -Minutes 3 -Seconds 4)
        $currentQueue.AutoDeleteOnIdle = (New-TimeSpan -Days 1 -Minutes 3 -Seconds 4)
        AssertQueueUpdates $currentQueue $updatedQueue
        $currentQueue = $updatedQueue

        $updatedQueue = Set-AzServiceBusQueue -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name queue2 -EnableExpress:$false
        $currentQueue.EnableExpress = $false
        AssertQueueUpdates $currentQueue $updatedQueue
        $currentQueue = $updatedQueue

        $updatedQueue = Set-AzServiceBusQueue -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name queue2 -EnableExpress
        $currentQueue.EnableExpress = $true
        AssertQueueUpdates $currentQueue $updatedQueue
        $currentQueue = $updatedQueue

        $updatedQueue = Set-AzServiceBusQueue -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name queue2 -Status ReceiveDisabled
        $currentQueue.Status = "ReceiveDisabled"
        AssertQueueUpdates $currentQueue $updatedQueue
        $currentQueue = $updatedQueue
    }

    It 'SetViaIdentityExpanded' {
        $currentQueue = Get-AzServiceBusQueue -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name queue1
        
        $updatedQueue = Set-AzServiceBusQueue -InputObject $currentQueue -LockDuration (New-TimeSpan -Minutes 2)
        $currentQueue.LockDuration = (New-TimeSpan -Minutes 2)
        AssertQueueUpdates $currentQueue $updatedQueue
        $currentQueue = $updatedQueue

        $updatedQueue = Set-AzServiceBusQueue -InputObject $currentQueue -DefaultMessageTimeToLive (New-TimeSpan -Days 1 -Minutes 3 -Seconds 4)
        $currentQueue.DefaultMessageTimeToLive = (New-TimeSpan -Days 1 -Minutes 3 -Seconds 4)
        AssertQueueUpdates $currentQueue $updatedQueue
        $currentQueue = $updatedQueue

        $updatedQueue = Set-AzServiceBusQueue -InputObject $currentQueue -MaxSizeInMegabytes 2048
        $currentQueue.MaxSizeInMegabytes = 2048
        AssertQueueUpdates $currentQueue $updatedQueue
        $currentQueue = $updatedQueue

        $updatedQueue = Set-AzServiceBusQueue -InputObject $currentQueue -EnableBatchedOperations
        $currentQueue.EnableBatchedOperations = $true
        AssertQueueUpdates $currentQueue $updatedQueue
        $currentQueue = $updatedQueue

        $updatedQueue = Set-AzServiceBusQueue -InputObject $currentQueue -EnableBatchedOperations:$false
        $currentQueue.EnableBatchedOperations = $false
        AssertQueueUpdates $currentQueue $updatedQueue
        $currentQueue = $updatedQueue

        $updatedQueue = Set-AzServiceBusQueue -InputObject $currentQueue -DuplicateDetectionHistoryTimeWindow (New-TimeSpan -Minutes 8)
        $currentQueue.DuplicateDetectionHistoryTimeWindow = (New-TimeSpan -Minutes 8)
        AssertQueueUpdates $currentQueue $updatedQueue
        $currentQueue = $updatedQueue

        $updatedQueue = Set-AzServiceBusQueue -InputObject $currentQueue -DeadLetteringOnMessageExpiration:$false
        $currentQueue.DeadLetteringOnMessageExpiration = $false
        AssertQueueUpdates $currentQueue $updatedQueue
        $currentQueue = $updatedQueue

        $updatedQueue = Set-AzServiceBusQueue -InputObject $currentQueue -MaxDeliveryCount 15
        $currentQueue.MaxDeliveryCount = 15
        AssertQueueUpdates $currentQueue $updatedQueue
        $currentQueue = $updatedQueue

        $updatedQueue = Set-AzServiceBusQueue -InputObject $currentQueue -ForwardTo $env.topic
        $currentQueue.ForwardTo = $env.topic
        AssertQueueUpdates $currentQueue $updatedQueue
        $currentQueue = $updatedQueue

        $updatedQueue = Set-AzServiceBusQueue -InputObject $currentQueue -ForwardDeadLetteredMessagesTo $env.topic
        $currentQueue.ForwardDeadLetteredMessagesTo = $env.topic
        AssertQueueUpdates $currentQueue $updatedQueue
        $currentQueue = $updatedQueue

        $updatedQueue = Set-AzServiceBusQueue -InputObject $currentQueue -Status SendDisabled
        $currentQueue.Status = "SendDisabled"
        AssertQueueUpdates $currentQueue $updatedQueue
        $currentQueue = $updatedQueue
    }
}
