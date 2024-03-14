if(($null -eq $TestName) -or ($TestName -contains 'Test-AzSupportTicketsNoSubscriptionNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzSupportTicketsNoSubscriptionNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzSupportTicketsNoSubscriptionNameAvailability' {
    It 'CheckExpandedSupportTicketTrue' {
        $supportTicketResult = Test-AzSupportTicketsNoSubscriptionNameAvailability -Name $env.NameForCheck -Type "Microsoft.Support/supportTickets"
        $supportTicketResult.NameAvailable | Should -Be $true
    }

    It 'CheckExpandedSupportTicket' {
        $supportTicketResult = Test-AzSupportTicketsNoSubscriptionNameAvailability -Name $env.Name -Type "Microsoft.Support/supportTickets"
        $supportTicketResult.NameAvailable | Should -Be $false
    }

    It 'CheckExpandedFileWorkspaceTrue' {
        $fileWorkspaceResult = Test-AzSupportTicketsNoSubscriptionNameAvailability -Name $env.FileWorkspaceNameNoSubscriptionForCheckName -Type "Microsoft.Support/fileWorkspaces"
        $fileWorkspaceResult.NameAvailable | Should -Be $true
    }

    It 'CheckExpandedFileWorkspaceFalse' {
        $fileWorkspaceResult = Test-AzSupportTicketsNoSubscriptionNameAvailability -Name $env.fileWorkspaceNameNoSubscription -Type "Microsoft.Support/fileWorkspaces"
        $fileWorkspaceResult.NameAvailable | Should -Be $false
    }

    It 'Check' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CheckViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CheckViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
