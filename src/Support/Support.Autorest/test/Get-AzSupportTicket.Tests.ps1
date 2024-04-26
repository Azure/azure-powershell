if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSupportTicket'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSupportTicket.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSupportTicket' {
    It 'List' {
        $supportTickets = Get-AzSupportTicket -SubscriptionId $env.SubscriptionId -Top 10
        $supportTickets.Count | Should -BeGreaterThan 0
    }

    It 'Get' {
        $supportTicket = Get-AzSupportTicket -SupportTicketName $env.Name -SubscriptionId $env.SubscriptionId
        $supportTicket.Description | Should -Be "test ticket - please ignore and close"
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
