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
    It 'CreateExpanded' {
        $customDomainName = "domain-psName010"
        $hostName = "pstestnew.dev.cdn.azure.cn"
        $tlsSetting = New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject -CertificateType "ManagedCertificate" -MinimumTlsVersion "TLS12"

        # New
        Write-Host -ForegroundColor Green "New CustomDomain: $($customDomainName)"
        $customDomain = New-AzFrontDoorCdnCustomDomain -CustomDomainName $customDomainName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName `
            -HostName $hostName -TlsSetting $tlsSetting
        $customDomain.Name | Should -Be $customDomainName

        # Get - List / by name / ViaIdentity
        $customDomains = Get-AzFrontDoorCdnCustomDomain -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName
        $customDomains.Count | Should -BeGreaterOrEqual 1
        $getDomain = Get-AzFrontDoorCdnCustomDomain -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -CustomDomainName $customDomainName
        $getDomain.Name | Should -Be $customDomainName
        $getDomain2 = Get-AzFrontDoorCdnCustomDomain -InputObject $getDomain
        $getDomain2.Name | Should -Be $customDomainName

        # Remove
        Write-Host -ForegroundColor Green "Remove CustomDomain: $($customDomainName)"
        Remove-AzFrontDoorCdnCustomDomain -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -CustomDomainName $customDomainName
    }
}
