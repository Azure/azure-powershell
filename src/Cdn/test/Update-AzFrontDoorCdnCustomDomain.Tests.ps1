if(($null -eq $TestName) -or ($TestName -contains 'Update-AzFrontDoorCdnCustomDomain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzFrontDoorCdnCustomDomain.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzFrontDoorCdnCustomDomain' -Tag 'LiveOnly' {
    It 'UpdateExpanded' {
        { 
            $ResourceGroupName = 'powershelltest'
            Write-Host -ForegroundColor Green "Use test group $($ResourceGroupName)"
            $frontDoorCdnProfileName = 'fdp-powershelltest'
            Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"
            $secretName = "se-powershelltest"
            Write-Host -ForegroundColor Green "Use secretName : $($secretName)"

            $customDomainName = "domain-powershelltest"
            Write-Host -ForegroundColor Green "Use custom domain name : $($customDomainName)"

            $secret = Get-AzFrontDoorCdnSecret -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Name $secretName
            $secretResoure = New-AzFrontDoorCdnResourceReferenceObject -Id $secret.Id
            $updateSetting = New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject -CertificateType "CustomerCertificate" -MinimumTlsVersion "TLS10" -Secret $secretResoure

            Update-AzFrontDoorCdnCustomDomain -CustomDomainName $customDomainName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName `
            -TlsSetting $updateSetting
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        { 
            $PSDefaultParameterValues['Disabled'] = $true
            $ResourceGroupName = 'powershelltest'
            Write-Host -ForegroundColor Green "Use test group $($ResourceGroupName)"
            $frontDoorCdnProfileName = 'fdp-powershelltest'
            Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"
            $secretName = "se-powershelltest"
            Write-Host -ForegroundColor Green "Use secretName : $($secretName)"

            $customDomainName = "domain-powershelltest"
            Write-Host -ForegroundColor Green "Use custom domain name : $($customDomainName)"

            $secret = Get-AzFrontDoorCdnSecret -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Name $secretName
            $secretResoure = New-AzFrontDoorCdnResourceReferenceObject -Id $secret.Id
            $updateSetting = New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject -CertificateType "CustomerCertificate" -MinimumTlsVersion "TLS10" -Secret $secretResoure

            Get-AzFrontDoorCdnCustomDomain -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -CustomDomainName $customDomainName `
            | Update-AzFrontDoorCdnCustomDomain -TlsSetting $updateSetting
        } | Should -Not -Throw
    }
}
