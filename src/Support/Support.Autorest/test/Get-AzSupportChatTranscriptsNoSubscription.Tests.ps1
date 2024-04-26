if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSupportChatTranscriptsNoSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSupportChatTranscriptsNoSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Chat functionality is unavailable for support tickets created outside the portal
Describe 'Get-AzSupportChatTranscriptsNoSubscription' {
    it 'List' {
        Mock Get-AzSupportChatTranscriptsNoSubscription{ New-MockObject -Type "Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ChatTranscriptDetails"}
        Get-AzSupportChatTranscriptsNoSubscription -SupportTicketName $env.Name
        Assert-MockCalled Get-AzSupportChatTranscriptsNoSubscription -Exactly 1
    }

    It 'Get' {
        Mock Get-AzSupportChatTranscriptsNoSubscription{ New-MockObject -Type "Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ChatTranscriptDetails"}
        Get-AzSupportChatTranscriptsNoSubscription -SupportTicketName $env.Name -ChatTranscriptName "testChat"
        Assert-MockCalled Get-AzSupportChatTranscriptsNoSubscription -Exactly 2
    }

    It 'GetViaIdentitySupportTicket' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
