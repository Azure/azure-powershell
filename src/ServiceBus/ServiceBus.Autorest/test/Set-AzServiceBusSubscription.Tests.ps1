if(($null -eq $TestName) -or ($TestName -contains 'Set-AzServiceBusSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzServiceBusSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

function AssertSubscriptionUpdates{
    param([Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbSubscription]$expectedSub,[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbSubscription]$actualSub)
    $expectedSub.Name | Should -Be $actualSub.Name
    $expectedSub.ResourceGroupName | Should -Be $actualSub.ResourceGroupName
    $expectedSub.DeadLetteringOnMessageExpiration | Should -Be $actualSub.DeadLetteringOnMessageExpiration
    $expectedSub.MaxDeliveryCount | Should -Be $actualSub.MaxDeliveryCount
    $expectedSub.Status | Should -Be $actualSub.Status
    $expectedSub.EnableBatchedOperations | Should -Be $actualSub.EnableBatchedOperations
    $expectedSub.ForwardTo | Should -Be $actualSub.ForwardTo
    $expectedSub.ForwardDeadLetteredMessagesTo | Should -Be $actualSub.ForwardDeadLetteredMessagesTo
    $expectedSub.DeadLetteringOnFilterEvaluationException | Should -Be $actualSub.DeadLetteringOnFilterEvaluationException
    $expectedSub.IsClientAffine | Should -Be $actualSub.IsClientAffine
    $expectedSub.ClientId | Should -Be $actualSub.ClientId
    $expectedSub.IsShared | Should -Be $actualSub.IsShared
    $expectedSub.IsDurable | Should -Be $actualSub.IsDurable

    if ($expectedSub.DefaultMessageTimeToLive -gt (New-TimeSpan -Days 10675197)){
        $actualSub.DefaultMessageTimeToLive | Should -BeGreaterOrEqual (New-TimeSpan -Days 10675197)
    }
    else{
        $actualSub.DefaultMessageTimeToLive | Should -Be $expectedSub.DefaultMessageTimeToLive
    }

    if ($expectedSub.DuplicateDetectionHistoryTimeWindow -gt (New-TimeSpan -Days 10675197)){
        $actualSub.DuplicateDetectionHistoryTimeWindow | Should -BeGreaterOrEqual (New-TimeSpan -Days 10675197)
    }
    else{
        $actualSub.DuplicateDetectionHistoryTimeWindow | Should -Be $expectedSub.DuplicateDetectionHistoryTimeWindow
    }

    if ($expectedSub.LockDuration -gt (New-TimeSpan -Days 10675197)){
        $actualSub.LockDuration | Should -BeGreaterOrEqual (New-TimeSpan -Days 10675197)
    }
    else{
        $actualSub.LockDuration | Should -Be $expectedSub.LockDuration
    }

    if ($expectedSub.AutoDeleteOnIdle -gt (New-TimeSpan -Days 10675197)){
        $actualSub.AutoDeleteOnIdle | Should -BeGreaterOrEqual (New-TimeSpan -Days 10675197)
    }
    else{
        $actualSub.AutoDeleteOnIdle | Should -Be $expectedSub.AutoDeleteOnIdle
    }
}

Describe 'Set-AzServiceBusSubscription' {
    It 'SetExpanded' {
        $currentSub = Get-AzServiceBusSubscription -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name 'subscription3$$D'
        $updatedSub = Set-AzServiceBusSubscription -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name 'subscription3$$D' -DeadLetteringOnFilterEvaluationException:$false
        $currentSub.DeadLetteringOnFilterEvaluationException = $false
        AssertSubscriptionUpdates $currentSub $updatedSub
        $currentSub = $updatedSub

        $updatedSub = Set-AzServiceBusSubscription -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name 'subscription3$$D' -DeadLetteringOnFilterEvaluationException
        $currentSub.DeadLetteringOnFilterEvaluationException = $true
        AssertSubscriptionUpdates $currentSub $updatedSub
        $currentSub = $updatedSub
    }

    It 'SetViaIdentityExpanded' {
        $currentSub = Get-AzServiceBusSubscription -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name subscription2
        $updatedSub = Set-AzServiceBusSubscription -InputObject $currentSub -DefaultMessageTimeToLive (New-TimeSpan -Days 1 -Minutes 3 -Seconds 4)
        $currentSub.DefaultMessageTimeToLive = (New-TimeSpan -Days 1 -Minutes 3 -Seconds 4)
        AssertSubscriptionUpdates $currentSub $updatedSub
        $currentSub = $updatedSub

        $updatedSub = Set-AzServiceBusSubscription -InputObject $currentSub -DeadLetteringOnMessageExpiration:$false
        $currentSub.DeadLetteringOnMessageExpiration = $false
        AssertSubscriptionUpdates $currentSub $updatedSub
        $currentSub = $updatedSub

        $updatedSub = Set-AzServiceBusSubscription -InputObject $currentSub -LockDuration (New-TimeSpan -Minutes 1)
        $currentSub.LockDuration = (New-TimeSpan -Minutes 1)
        AssertSubscriptionUpdates $currentSub $updatedSub
        $currentSub = $updatedSub

        $updatedSub = Set-AzServiceBusSubscription -InputObject $currentSub -MaxDeliveryCount 8
        $currentSub.MaxDeliveryCount = 8
        AssertSubscriptionUpdates $currentSub $updatedSub
        $currentSub = $updatedSub

        $updatedSub = Set-AzServiceBusSubscription -InputObject $currentSub -EnableBatchedOperations:$false
        $currentSub.EnableBatchedOperations = $false
        AssertSubscriptionUpdates $currentSub $updatedSub
        $currentSub = $updatedSub

        $updatedSub = Set-AzServiceBusSubscription -InputObject $currentSub -ForwardTo topic1
        $currentSub.ForwardTo = "topic1"
        AssertSubscriptionUpdates $currentSub $updatedSub
        $currentSub = $updatedSub

        $updatedSub = Set-AzServiceBusSubscription -InputObject $currentSub -ForwardDeadLetteredMessagesTo topic1
        $currentSub.ForwardDeadLetteredMessagesTo = "topic1"
        AssertSubscriptionUpdates $currentSub $updatedSub
        $currentSub = $updatedSub

        $updatedSub = Set-AzServiceBusSubscription -InputObject $currentSub -Status ReceiveDisabled
        $currentSub.Status = "ReceiveDisabled"
        AssertSubscriptionUpdates $currentSub $updatedSub
        $currentSub = $updatedSub

        $currentSub = New-AzServiceBusSubscription -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name subscription4
        $updatedSub = Set-AzServiceBusSubscription -InputObject $currentSub -AutoDeleteOnIdle (New-TimeSpan -Days 5)
        $currentSub.AutoDeleteOnIdle = (New-TimeSpan -Days 5)
        AssertSubscriptionUpdates $currentSub $updatedSub
        $currentSub = $updatedSub

        { Set-AzServiceBusSubscription -InputObject $currentSub } | Should -Throw 'Please specify the property you want to update on the -InputObject'
    }
}
