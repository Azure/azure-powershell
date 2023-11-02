if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPolicyAssignment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPolicyAssignment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPolicyAssignment' {
    It 'Default' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Name' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PolicyDefinitionId' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'IncludeDescendent' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Scope' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Id' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
