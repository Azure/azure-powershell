if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzADUser'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzADUser.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzADUser' {
    It 'UPNOrObjectIdParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ObjectIdParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UPNParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DisplayNameParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'InputObjectParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
