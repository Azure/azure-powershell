if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSupportChatTranscript'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSupportChatTranscript.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Chat functionality is unavailable for support tickets created outside the portal
Describe 'Get-AzSupportChatTranscript' {
    It 'List' {
        Mock Get-AzSupportChatTranscript{ New-MockObject -Type "Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ChatTranscriptDetails"}
        Get-AzSupportChatTranscript -SupportTicketName $env.Name -SubscriptionId $env.SubscriptionId
        Assert-MockCalled Get-AzSupportChatTranscript -Exactly 1 
    }

    It 'GetViaIdentitySupportTicket' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' {
        Mock Get-AzSupportChatTranscript{ New-MockObject -Type "Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ChatTranscriptDetails"}
        Get-AzSupportChatTranscript -SupportTicketName $env.Name -Name "testChat" -SubscriptionId $env.SubscriptionId
        Assert-MockCalled Get-AzSupportChatTranscript -Exactly 2
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
