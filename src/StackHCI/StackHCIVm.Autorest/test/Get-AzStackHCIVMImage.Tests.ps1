if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStackHCIVMImage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStackHCIVMImage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzStackHCIVMImage' {
    It 'BySubscription' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ByName' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ByResourceGroup' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListAllSupportedImages' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListImagesByOffer' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListImagesByPublisher' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListImagesBySku' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ByResourceId' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
