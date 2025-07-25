if(($null -eq $TestName) -or ($TestName -contains 'Update-AzActionGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzActionGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzActionGroup' {
    It 'UpdateExpanded' {
        {
            $enventhub = New-AzActionGroupEventHubReceiverObject -EventHubName $env.eventHubName -EventHubNameSpace $env.EventHubNamespaceName -Name "sample eventhub" -SubscriptionId $env.subscriptionId
            Update-AzActionGroup -Name $env.actiongroupname -ResourceGroupName $env.resourceGroup -EventHubReceiver $enventhub
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $ag = Get-AzActionGroup -Name $env.actiongroupname -ResourceGroupName $env.resourceGroup
            Update-AzActionGroup -InputObject $ag -EventHubReceiver $null
        } | Should -Not -Throw
    }
}
