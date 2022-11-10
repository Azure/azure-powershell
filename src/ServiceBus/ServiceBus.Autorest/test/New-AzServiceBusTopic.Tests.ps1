if(($null -eq $TestName) -or ($TestName -contains 'New-AzServiceBusTopic'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceBusTopic.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzServiceBusTopic' {
    It 'CreateExpanded' {
        $topic1 = New-AzServiceBusTopic -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name topic2 -DefaultMessageTimeToLive (New-TimeSpan -Days 365) -RequiresDuplicateDetection -AutoDeleteOnIdle (New-TimeSpan -Days 428 -Hours 3 -Minutes 11 -Seconds 2) -DuplicateDetectionHistoryTimeWindow (New-TimeSpan -Days 1 -Minutes 3 -Seconds 4) -EnableBatchedOperations -SupportOrdering -MaxMessageSizeInKilobytes 102400
        $topic1.Name | Should -Be "topic2"
        $topic1.ResourceGroupName | Should -Be $env.resourceGroup
        $topic1.DefaultMessageTimeToLive | Should -Be (New-TimeSpan -Days 365)
        $topic1.AutoDeleteOnIdle | Should -Be (New-TimeSpan -Days 428 -Hours 3 -Minutes 11 -Seconds 2)
        $topic1.DuplicateDetectionHistoryTimeWindow | Should -Be (New-TimeSpan -Days 1 -Minutes 3 -Seconds 4)
        $topic1.SupportOrdering | Should -Be $true
        $topic1.EnableBatchedOperations | Should -Be $true
        $topic1.EnablePartitioning | Should -Be $false
        $topic1.MaxMessageSizeInKilobytes | Should -Be 102400

        $topic2 = New-AzServiceBusTopic -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name topic3 -MaxSizeInMegabytes 2048
        $topic2.Name | Should -Be "topic3"
        $topic2.ResourceGroupName | Should -Be $env.resourceGroup
        $topic2.MaxSizeInMegabytes | Should -Be 2048

        $listOfTopics = Get-AzServiceBusTopic -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
        $listOfTopics.Count | Should -Be 3

        $topic3 = New-AzServiceBusTopic -ResourceGroupName $env.resourceGroup -NamespaceName $env.standardNamespace -Name topic1 -EnableExpress
        $topic3.EnableExpress | Should -Be $true
    }
}
