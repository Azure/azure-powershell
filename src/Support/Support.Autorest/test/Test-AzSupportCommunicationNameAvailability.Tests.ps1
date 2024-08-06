if(($null -eq $TestName) -or ($TestName -contains 'Test-AzSupportCommunicationNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzSupportCommunicationNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzSupportCommunicationNameAvailability' {
    It 'CheckExpandedTrue' { 
        $communicationResult = Test-AzSupportCommunicationNameAvailability -SubscriptionId $env.SubscriptionId -SupportTicketName $env.Name -Name $env.CommunicationNameForCheck -Type "Microsoft.Support/communications"
        $communicationResult.NameAvailable | Should -Be $true
    }

    It 'CheckExpandedFalse' { 
        $communicationResult = Test-AzSupportCommunicationNameAvailability -SubscriptionId $env.SubscriptionId -SupportTicketName $env.Name -Name $env.CommunicationName-Type "Microsoft.Support/communications"
        $communicationResult.NameAvailable | Should -Be $false
    }

    It 'CheckViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CheckViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Check' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CheckViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CheckViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
