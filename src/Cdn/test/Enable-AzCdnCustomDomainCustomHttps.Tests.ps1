if(($null -eq $TestName) -or ($TestName -contains 'Enable-AzCdnCustomDomainCustomHttps'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Enable-AzCdnCustomDomainCustomHttps.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Enable-AzCdnCustomDomainCustomHttps'  {
    It 'Enable'  {
        $httpsParameter = New-AzCdnManagedHttpsParametersObject -CertificateSource "Cdn" -CertificateSourceParameterCertificateType "Dedicated" -ProtocolType "ServerNameIndication"

        $customDomain = Enable-AzCdnCustomDomainCustomHttps -CustomDomainName $env.ClassicCustomDomainName -EndpointName $env.ClassicEndpointName `
                            -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -CustomDomainHttpsParameter $httpsParameter
        $customDomain.CustomHttpsProvisioningState | Should -Not -Be "Disabled"
        }
}
