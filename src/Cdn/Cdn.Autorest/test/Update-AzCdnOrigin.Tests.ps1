if(($null -eq $TestName) -or ($TestName -contains 'Update-AzCdnOrigin'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzCdnOrigin.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzCdnOrigin' {
    BeforeAll {
        $script:endpointName = 'e-clipstest-origin-upd'
        $origin = @{ Name = 'origin1'; HostName = 'host1.hello.com' }
        New-AzCdnEndpoint -Name $script:endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location 'westus' -Origin $origin | Out-Null
    }

    AfterAll {
        Remove-AzCdnEndpoint -Name $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'UpdateExpanded' {
        $u = Update-AzCdnOrigin -Name 'origin1' -EndpointName $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -HostName 'www.azure.com' -HttpPort 456 -HttpsPort 789
        $u.HostName | Should -Be 'www.azure.com'
        $u.HttpPort | Should -Be 456
        $u.HttpsPort | Should -Be 789
    }

    It 'UpdateViaIdentityExpanded' {
        $o = Get-AzCdnOrigin -Name 'origin1' -EndpointName $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $u = Update-AzCdnOrigin -HostName 'www.azure.com' -HttpPort 123 -HttpsPort 666 -InputObject $o
        $u.HttpPort | Should -Be 123
        $u.HttpsPort | Should -Be 666
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityProfileExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityProfile' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityEndpointExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityEndpoint' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
