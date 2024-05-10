if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSupportCommunicationsNoSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSupportCommunicationsNoSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSupportCommunicationsNoSubscription' {
    It 'List' {
        $supportMessages = Get-AzSupportCommunicationsNoSubscription -SupportTicketName $env.Name 
        $supportMessages.Count | Should -BeGreaterThan 0
    }
    It 'Get' {
        $supportMessage = Get-AzSupportCommunicationsNoSubscription -CommunicationName $env.CommunicationName -SupportTicketName $env.Name
        $supportMessage.Body.ToString() |  Should -Match $env.Body
    }

    It 'GetViaIdentitySupportTicket' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
