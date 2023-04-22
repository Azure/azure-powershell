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
    BeforeAll {
        $customDomainHostName = 'aa-powershell-20230421-oigr9w.cdne2e.azfdtest.xyz'
        $customDomainName = 'cd-' + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Create customDomain : $($customDomainName), endpointName : $($env.ClassicEndpointName)"
        New-AzCdnCustomDomain -EndpointName $env.ClassicEndpointName -Name $customDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -HostName $customDomainHostName | Out-Null

    }
    
    It 'Enable'  {
        $httpsParameter = New-AzCdnUserManagedHttpsParametersObject -CertificateSource "AzureKeyVault" `
                            -CertificateSourceParameterResourceGroupName $env.ResourceGroupName -CertificateSourceParameterSecretName "wildcard-cdne2e-azfdtest-xyz" `
                            -CertificateSourceParameterSubscriptionId $subId -CertificateSourceParameterVaultName "huaiyizkvtest" `
                            -ProtocolType "ServerNameIndication"
        $customDomain = Enable-AzCdnCustomDomainCustomHttps -CustomDomainName $env.ClassicCustomDomainName -EndpointName $env.ClassicEndpointName `
                            -ProfileName $cdnProfileName -ResourceGroupName $env.ResourceGroupName -CustomDomainHttpsParameter $httpsParameter -SubscriptionId $subId
        
        $customDomain.CustomHttpsProvisioningState | Should -Not -Be "Disabled"
        }

    It 'EnableViaIdentity'  {
        $PSDefaultParameterValues['Disabled'] = $true
        $httpsParameter = New-AzCdnManagedHttpsParametersObject -CertificateSource "Cdn" -CertificateSourceParameterCertificateType "Dedicated" -ProtocolType "ServerNameIndication"
        $customDomain = $customDomain | Enable-AzCdnCustomDomainCustomHttps -CustomDomainHttpsParameter $httpsParameter
        
        $customDomain.CustomHttpsProvisioningState | Should -Not -Be "Disabled"
    }
}
