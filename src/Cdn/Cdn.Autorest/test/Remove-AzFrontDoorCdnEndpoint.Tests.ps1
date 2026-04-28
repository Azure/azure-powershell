if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzFrontDoorCdnEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzFrontDoorCdnEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzFrontDoorCdnEndpoint' {
    BeforeAll {
        $script:endpointName = 'e-clipstest-rm'
        New-AzFrontDoorCdnEndpoint -EndpointName $script:endpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global | Out-Null
    }

    It 'Delete' {
        Remove-AzFrontDoorCdnEndpoint -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $script:endpointName
        { Get-AzFrontDoorCdnEndpoint -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $script:endpointName -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentityProfile' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
