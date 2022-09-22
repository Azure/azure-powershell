if(($null -eq $TestName) -or ($TestName -contains 'New-AzADServicePrincipal'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzADServicePrincipal.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzADServicePrincipal' {
    It 'SimpleParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DisplayNameWithPasswordCredentialParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DisplayNameWithKeyCredentialParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DisplayNameWithKeyPlainParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ApplicationWithPasswordCredentialParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ApplicationWithKeyCredentialParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ApplicationWithKeyPlainParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ApplicationObjectWithPasswordPlainParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ApplicationObjectWithKeyPlainParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ApplicationObjectWithKeyCredentialParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ApplicationObjectWithPasswordCredentialParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
