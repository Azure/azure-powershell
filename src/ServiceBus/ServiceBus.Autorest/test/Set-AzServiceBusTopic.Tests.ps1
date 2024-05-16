if(($null -eq $TestName) -or ($TestName -contains 'Set-AzServiceBusTopic'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzServiceBusTopic.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

function AssertTopicUpdates{
    param([Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ISbTopic]$expectedTopic,[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ISbTopic]$actualTopic)
    $expectedTopic.Name | Should -Be $actualTopic.Name
    $expectedTopic.ResourceGroupName | Should -Be $actualTopic.ResourceGroupName
    $expectedTopic.MaxSizeInMegabytes | Should -Be $actualTopic.MaxSizeInMegabytes
    $expectedTopic.RequiresDuplicateDetection | Should -Be $actualTopic.RequiresDuplicateDetection
    $expectedTopic.EnableBatchedOperations | Should -Be $actualTopic.EnableBatchedOperations
    $expectedTopic.MaxMessageSizeInKilobytes | Should -Be $actualTopic.MaxMessageSizeInKilobytes
    $expectedTopic.EnablePartitioning | Should -Be $actualTopic.EnablePartitioning
    $expectedTopic.EnableExpress | Should -Be $actualTopic.EnableExpress
    $expectedTopic.SupportOrdering | Should -Be $actualTopic.SupportOrdering
    $expectedTopic.DefaultMessageTimeToLive | Should -Be $actualTopic.DefaultMessageTimeToLive
    $expectedTopic.DuplicateDetectionHistoryTimeWindow | Should -Be $actualTopic.DuplicateDetectionHistoryTimeWindow
    $expectedTopic.AutoDeleteOnIdle | Should -Be $actualTopic.AutoDeleteOnIdle
}

Describe 'Set-AzServiceBusTopic' {
    $currentTopic = New-AzServiceBusTopic -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name topicToUpdate

    It 'SetExpanded' {
        $updatedTopic = Set-AzServiceBusTopic -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name topicToUpdate -DefaultMessageTimeToLive (New-TimeSpan -Days 7)
        $currentTopic.DefaultMessageTimeToLive = (New-TimeSpan -Days 7)
        AssertTopicUpdates $currentTopic $updatedTopic
        $currentTopic = $updatedTopic

        $updatedTopic = Set-AzServiceBusTopic -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name topicToUpdate -EnableBatchedOperations:$false
        $currentTopic.EnableBatchedOperations = $false
        AssertTopicUpdates $currentTopic $updatedTopic
        $currentTopic = $updatedTopic

        $updatedTopic = Set-AzServiceBusTopic -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name topicToUpdate -EnableBatchedOperations
        $currentTopic.EnableBatchedOperations = $true
        AssertTopicUpdates $currentTopic $updatedTopic
        $currentTopic = $updatedTopic
    }

    It 'SetViaIdentityExpanded' {
        $currentTopic = Get-AzServiceBusTopic -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name topicToUpdate

        $updatedTopic = Set-AzServiceBusTopic -InputObject $currentTopic -SupportOrdering
        $currentTopic.SupportOrdering = $true
        AssertTopicUpdates $currentTopic $updatedTopic
        $currentTopic = $updatedTopic

        $updatedTopic = Set-AzServiceBusTopic -InputObject $currentTopic -SupportOrdering:$false
        $currentTopic.SupportOrdering = $false
        AssertTopicUpdates $currentTopic $updatedTopic
        $currentTopic = $updatedTopic

        $updatedTopic = Set-AzServiceBusTopic -InputObject $currentTopic -MaxSizeInMegabytes 2048
        $currentTopic.MaxSizeInMegabytes = 2048
        AssertTopicUpdates $currentTopic $updatedTopic
        $currentTopic = $updatedTopic

        $updatedTopic = Set-AzServiceBusTopic -InputObject $currentTopic -AutoDeleteOnIdle (New-TimeSpan -Days 428 -Hours 3 -Minutes 11 -Seconds 2)
        $currentTopic.AutoDeleteOnIdle = (New-TimeSpan -Days 428 -Hours 3 -Minutes 11 -Seconds 2)
        AssertTopicUpdates $currentTopic $updatedTopic
        $currentTopic = $updatedTopic

        $updatedTopic = Set-AzServiceBusTopic -InputObject $currentTopic -Status SendDisabled
        $currentTopic.Status = "SendDisabled"
        AssertTopicUpdates $currentTopic $updatedTopic
        $currentTopic = $updatedTopic

        $updatedTopic = Set-AzServiceBusTopic -InputObject $currentTopic -DuplicateDetectionHistoryTimeWindow (New-TimeSpan -Minutes 3)
        $currentTopic.DuplicateDetectionHistoryTimeWindow = (New-TimeSpan -Minutes 3)
        AssertTopicUpdates $currentTopic $updatedTopic
        $currentTopic = $updatedTopic

        $currentTopic = Get-AzServiceBusTopic -ResourceGroupName $env.resourceGroup -NamespaceName $env.standardNamespace -Name topic1
        $updatedTopic = Set-AzServiceBusTopic -InputObject $currentTopic -EnableExpress:$false
        $currentTopic.EnableExpress = $false
        AssertTopicUpdates $currentTopic $updatedTopic
        $currentTopic = $updatedTopic

        $updatedTopic = Set-AzServiceBusTopic -InputObject $currentTopic -EnableExpress
        $currentTopic.EnableExpress = $true
        AssertTopicUpdates $currentTopic $updatedTopic
        $currentTopic = $updatedTopic

        { Set-AzServiceBusTopic -InputObject $currentTopic -ErrorAction Stop } | Should -Throw 'Please specify the property you want to update on the -InputObject'
    }
}
