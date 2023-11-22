if(($null -eq $TestName) -or ($TestName -contains 'New-AzPolicyDefinition'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPolicyDefinition.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzPolicyDefinition' {
    It 'Name' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ManagementGroupName' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SubscriptionId' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
