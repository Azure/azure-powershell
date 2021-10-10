if(($null -eq $TestName) -or ($TestName -contains 'Update-AzMgServicePrincipal'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMgServicePrincipal.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzMgServicePrincipal' {
    It 'SpObjectIdWithDisplayNameParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SpApplicationIdWithDisplayNameParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'InputObjectWithDisplayNameParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SPNWithDisplayNameParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
