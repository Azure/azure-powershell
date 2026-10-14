if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCdnOrigin'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCdnOrigin.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCdnOrigin' {
    BeforeAll {
        $script:endpointName = 'e-clipstest-origin-get'
        $origin = @{ Name = 'origin1'; HostName = 'host1.hello.com' }
        New-AzCdnEndpoint -Name $script:endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location 'westus' -Origin $origin | Out-Null
    }

    AfterAll {
        Remove-AzCdnEndpoint -Name $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'List' {
        $origins = Get-AzCdnOrigin -EndpointName $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $origins.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $o = Get-AzCdnOrigin -Name 'origin1' -EndpointName $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $o.Name | Should -Be 'origin1'
        $o.HostName | Should -Be 'host1.hello.com'
    }

    It 'GetViaIdentity' {
        $o = Get-AzCdnOrigin -Name 'origin1' -EndpointName $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $o2 = Get-AzCdnOrigin -InputObject $o
        $o2.Name | Should -Be 'origin1'
    }

    It 'GetViaIdentityProfile' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityEndpoint' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
