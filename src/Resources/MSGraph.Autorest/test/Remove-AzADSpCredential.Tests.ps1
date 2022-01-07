if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzADSpCredential'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzADSpCredential.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzADSpCredential' {
    It 'ObjectIdWithKeyIdParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SPNWithKeyIdParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DisplayNameWithKeyIdParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ServicePrincipalObjectParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
