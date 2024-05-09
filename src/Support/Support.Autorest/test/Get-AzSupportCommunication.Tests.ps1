if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSupportCommunication'))
{
  Write-Host "in Get-AzSupportCommunication env.HasSubscription: $(($env.HasSubscription -eq $true))"
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSupportCommunication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSupportCommunication' {

    It 'List' {
        $supportMessage = Get-AzSupportCommunication -SupportTicketName $env.Name -SubscriptionId $env.SubscriptionId
        $supportMessage.Count | Should -BeGreaterThan 0
    }

    It 'GetViaIdentitySupportTicket' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' {
        $supportMessage = Get-AzSupportCommunication -CommunicationName $env.CommunicationName -SupportTicketName $env.Name -SubscriptionId $env.SubscriptionId
        $supportMessage.Body.ToString() | Should -Match $env.Body
    } 

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
