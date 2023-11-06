if(($null -eq $TestName) -or ($TestName -contains 'New-AzActionGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzActionGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzActionGroup' {
    It 'CreateExpanded' {
        {
            $enventhub = New-AzActionGroupEventHubReceiverObject -EventHubName $env.eventHubName -EventHubNameSpace $env.EventHubNamespaceName -Name "sample eventhub" -SubscriptionId $env.subscriptionId
            New-AzActionGroup -Name $env.actiongroup1 -ResourceGroupName $env.resourceGroup -Location $env.region -GroupShortName 'ag1' -EventHubReceiver $enventhub
        } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
