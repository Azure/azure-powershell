if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorCdnCustomDomain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorCdnCustomDomain.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorCdnCustomDomain' {
    BeforeAll {
        $script:domainName = 'domain-psName-new'
    }

    AfterAll {
        Remove-AzFrontDoorCdnCustomDomain -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -CustomDomainName $script:domainName -ErrorAction SilentlyContinue
    }

    It 'CreateExpanded' {
        $tls = New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject -CertificateType 'ManagedCertificate' -MinimumTlsVersion 'TLS12'
        $cd = New-AzFrontDoorCdnCustomDomain -CustomDomainName $script:domainName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -HostName 'pstestnew.dev.cdn.azure.cn' -TlsSetting $tls
        $cd.Name | Should -Be $script:domainName
    }
}
