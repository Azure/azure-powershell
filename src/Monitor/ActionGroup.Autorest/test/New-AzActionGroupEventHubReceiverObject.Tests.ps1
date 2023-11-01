if(($null -eq $TestName) -or ($TestName -contains 'New-AzActionGroupEventHubReceiverObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzActionGroupEventHubReceiverObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzActionGroupEventHubReceiverObject' {
    It '__AllParameterSets' {
        {
            New-AzActionGroupEventHubReceiverObject -EventHubName "testEventHub" -EventHubNameSpace "actiongrouptest" -Name "sample eventhub" -SubscriptionId 9e223dbe-3399-4e19-88eb-0975f02ac87f
        } | Should -Not -Throw
    }
}
