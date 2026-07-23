if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFrontDoorCdnCustomDomain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFrontDoorCdnCustomDomain.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFrontDoorCdnCustomDomain' {
    BeforeAll {
        $script:domainName = 'domain-psName-get'
        $tls = New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject -CertificateType 'ManagedCertificate' -MinimumTlsVersion 'TLS12'
        New-AzFrontDoorCdnCustomDomain -CustomDomainName $script:domainName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -HostName 'pstestget.dev.cdn.azure.cn' -TlsSetting $tls | Out-Null
    }

    AfterAll {
        Remove-AzFrontDoorCdnCustomDomain -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -CustomDomainName $script:domainName -ErrorAction SilentlyContinue
    }

    It 'List' {
        $cds = Get-AzFrontDoorCdnCustomDomain -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName
        $cds.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $cd = Get-AzFrontDoorCdnCustomDomain -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -CustomDomainName $script:domainName
        $cd.Name | Should -Be $script:domainName
    }

    It 'GetViaIdentity' {
        $cd = Get-AzFrontDoorCdnCustomDomain -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -CustomDomainName $script:domainName
        $cd2 = Get-AzFrontDoorCdnCustomDomain -InputObject $cd
        $cd2.Name | Should -Be $script:domainName
    }

    It 'GetViaIdentityProfile' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
