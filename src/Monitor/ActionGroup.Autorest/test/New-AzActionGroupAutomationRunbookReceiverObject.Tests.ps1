if(($null -eq $TestName) -or ($TestName -contains 'New-AzActionGroupAutomationRunbookReceiverObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzActionGroupAutomationRunbookReceiverObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzActionGroupAutomationRunbookReceiverObject' {
    It '__AllParameterSets' {
        {
            New-AzActionGroupAutomationRunbookReceiverObject -AutomationAccountId "/subscriptions/187f412d-1758-44d9-b052-169e2564721d/resourceGroups/runbookTest/providers/Microsoft.Automation/automationAccounts/runbooktest" -RunbookName "sample runbook" -WebhookResourceId "/subscriptions/187f412d-1758-44d9-b052-169e2564721d/resourceGroups/runbookTest/providers/Microsoft.Automation/automationAccounts/runbooktest/webhooks/Alert1510184037084" -Name "testRunbook" -UseCommonAlertSchema $true -IsGlobalRunbook $false
        } | Should -Not -Throw
    }
}
