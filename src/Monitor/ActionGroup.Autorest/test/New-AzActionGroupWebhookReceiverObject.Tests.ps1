if(($null -eq $TestName) -or ($TestName -contains 'New-AzActionGroupWebhookReceiverObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzActionGroupWebhookReceiverObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzActionGroupWebhookReceiverObject' {
    It '__AllParameterSets' {
        {
            New-AzActionGroupWebhookReceiverObject -Name "sample webhook" -ServiceUri "http://www.example.com/webhook1" -IdentifierUri "http://someidentifier/d7811ba3-7996-4a93-99b6-6b2f3f355f8a" -ObjectId "d3bb868c-fe44-452c-aa26-769a6538c808" -TenantId 68a4459a-ccb8-493c-b9da-dd30457d1b84 -UseAadAuth $true -UseCommonAlertSchema $true
        } | Should -Not -Throw
    }
}
