if(($null -eq $TestName) -or ($TestName -contains 'New-AzPolicyAssignment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPolicyAssignment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzPolicyAssignment' {
    It 'Default' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SetParameterObject' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SetParameterString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ParameterObject' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ParameterString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityExpanded1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateExpanded1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
