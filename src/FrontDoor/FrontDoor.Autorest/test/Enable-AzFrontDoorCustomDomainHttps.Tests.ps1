if(($null -eq $TestName) -or ($TestName -contains 'Enable-AzFrontDoorCustomDomainHttps'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Enable-AzFrontDoorCustomDomainHttps.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Enable-AzFrontDoorCustomDomainHttps' {
    It 'EnableExpanded' -skip {
        {
            $customFrontendEndpointName = "frontendendpoint2"
            Enable-AzFrontDoorCustomDomainHttps -ResourceGroupName $env.ResourceGroupName -FrontDoorName $env.FrontDoorName -FrontendEndpointName $customFrontendEndpointName -MinimumTlsVersion "1.2"
        } | Should -Not -Throw
    }

    It 'EnableViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'EnableViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Enable' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'EnableViaIdentityFrontDoorExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'EnableViaIdentityFrontDoor' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'EnableViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'EnableViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
