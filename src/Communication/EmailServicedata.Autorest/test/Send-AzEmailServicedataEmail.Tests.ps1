if(($null -eq $TestName) -or ($TestName -contains 'Send-AzEmailServicedataEmail'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Send-AzEmailServicedataEmail.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Send-AzEmailServicedataEmail' {
    It 'Send' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SendExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SendViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SendViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
