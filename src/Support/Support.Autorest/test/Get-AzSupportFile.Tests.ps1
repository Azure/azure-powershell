if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSupportFile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSupportFile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSupportFile' {
    It 'List' {
        $files = Get-AzSupportFile -WorkspaceName $env.FileWorkspaceNameSubscription -SubscriptionId $env.SubscriptionId
        $files | Should -Not -BeNullOrEmpty
        $files.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentityFileWorkspace' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' {
        $file = Get-AzSupportFile -Name "test2.txt" -WorkspaceName $env.FileWorkspaceNameSubscription -SubscriptionId $env.SubscriptionId
        $file | Should -Not -BeNullOrEmpty
        $file.Name | Should -Be "test2.txt"
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
