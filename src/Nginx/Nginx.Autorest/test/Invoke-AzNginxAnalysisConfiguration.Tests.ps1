if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzNginxAnalysisConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzNginxAnalysisConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzNginxAnalysisConfiguration' {
    It 'AnalysisExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AnalysisViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AnalysisViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AnalysisViaIdentityNginxDeploymentExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AnalysisViaIdentityNginxDeployment' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Analysis' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AnalysisViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AnalysisViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
