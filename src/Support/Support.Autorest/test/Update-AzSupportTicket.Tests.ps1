if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSupportTicket'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSupportTicket.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSupportTicket' {

    It 'UpdateExpanded' -skip:($env.HasSubscription -eq $false) {
        $supportTicket = Update-AzSupportTicket -SubscriptionId $env.SubscriptionId -SupportTicketName $env.Name -AdvancedDiagnosticConsent "Yes"
        $supportTicket.AdvancedDiagnosticConsent | Should -Be "Yes"
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
