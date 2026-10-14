if(($null -eq $TestName) -or ($TestName -contains 'Start-AzCdnEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzCdnEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzCdnEndpoint' {
    BeforeAll {
        $script:endpointName = 'e-clipstest310-start'
        $script:origin = @{ Name = 'origin1'; HostName = 'host1.hello.com' }
        New-AzCdnEndpoint -Name $script:endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location 'westus' -Origin $script:origin | Out-Null
        Stop-AzCdnEndpoint -Name $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName | Out-Null
    }

    AfterAll {
        Remove-AzCdnEndpoint -Name $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'Start' {
        Start-AzCdnEndpoint -Name $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $endpoint = Get-AzCdnEndpoint -Name $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $endpoint.ResourceState | Should -Be 'Running'
    }

    It 'StartViaIdentityProfile' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StartViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
