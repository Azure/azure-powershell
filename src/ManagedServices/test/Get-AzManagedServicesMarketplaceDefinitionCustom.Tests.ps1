if(($null -eq $TestName) -or ($TestName -contains 'Get-AzManagedServicesMarketplaceDefinitionCustom'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzManagedServicesMarketplaceDefinitionCustom.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzManagedServicesMarketplaceDefinitionCustom' {
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
