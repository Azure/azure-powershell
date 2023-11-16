if(($null -eq $TestName) -or ($TestName -contains 'Get-AzManagedServicesMarketplaceDefinition'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzManagedServicesMarketplaceDefinition.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzManagedServicesMarketplaceDefinition' {
    It 'ListWithScope' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetWithScope' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetWithoutScope' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListWithoutScope' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
