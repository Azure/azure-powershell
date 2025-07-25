if(($null -eq $TestName) -or ($TestName -contains 'Test-AzSupportTicketNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzSupportTicketNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzSupportTicketNameAvailability' {
    It 'CheckExpandedSupportTicketTrue' {
        $supportTicketResult = Test-AzSupportTicketNameAvailability -Name $env.NameForCheck -Type "Microsoft.Support/supportTickets"-SubscriptionId $env.SubscriptionId
        $supportTicketResult.NameAvailable | Should -Be $true
    }

    It 'CheckExpandedSupportTicketFalse' {
        $supportTicketResult = Test-AzSupportTicketNameAvailability -Name $env.Name-Type "Microsoft.Support/supportTickets"-SubscriptionId $env.SubscriptionId
        $supportTicketResult.NameAvailable | Should -Be $false
    }

    It 'CheckExpandedFileWorkspaceTrue' {
        $fileWorkspaceResult = Test-AzSupportTicketNameAvailability -Name $env.FileWorkspaceNameSubscriptionForCheckName -Type "Microsoft.Support/fileWorkspaces" -SubscriptionId $env.SubscriptionId
        $fileWorkspaceResult.NameAvailable | Should -Be $true
    }

    It 'CheckExpandedFileWorkspaceFalse' {
        $fileWorkspaceResult = Test-AzSupportTicketNameAvailability -Name $env.FileWorkspaceNameSubscription -Type "Microsoft.Support/fileWorkspaces" -SubscriptionId $env.SubscriptionId
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
