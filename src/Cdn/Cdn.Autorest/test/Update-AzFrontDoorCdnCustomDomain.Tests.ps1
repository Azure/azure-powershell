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

Describe 'Update-AzFrontDoorCdnCustomDomain'  {
    BeforeAll {
        $subId = $env.SubscriptionId
        Write-Host -ForegroundColor Green "Use SubscriptionId : $($subId)"
    }
    It 'UpdateExpanded' {
        {
            $customDomainName = "domain-Name030" 
            Write-Host -ForegroundColor Green "Use customDomainName : $($customDomainName)"
            $hostName = "pstestrefresh3.dev.cdn.azure.cn"
            $customDomain = New-AzFrontDoorCdnCustomDomain -CustomDomainName $customDomainName -ProfileName $env.FrontDoorEndpointName -ResourceGroupName $env.ResourceGroupName `
            -HostName $hostName
            Write-Host -ForegroundColor Green "Use customDomain token : $($customDomain.ValidationPropertyValidationTokenex)"
            
            $secretName = "se-psName050"
            Write-Host -ForegroundColor Green "Use secretName : $($secretName)"

            $parameter = New-AzFrontDoorCdnSecretCustomerCertificateParametersObject -UseLatestVersion $true -SubjectAlternativeName @() -Type "CustomerCertificate"`
            -SecretSourceId "/subscriptions/$subId/resourceGroups/powershelltest/providers/Microsoft.KeyVault/vaults/cdn-ps-kv/secrets/testps"

            $secret = New-AzFrontDoorCdnSecret -Name $secretName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Parameter $parameter
            $secretResoure = New-AzFrontDoorCdnResourceReferenceObject -Id $secret.Id

            $updateSetting = New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject -CertificateType "CustomerCertificate" -MinimumTlsVersion "TLS10" -Secret $secretResoure

            Update-AzFrontDoorCdnCustomDomain -CustomDomainName $customDomainName -ProfileName $env.FrontDoorEndpointName -ResourceGroupName $env.ResourceGroupName `
            -TlsSetting $updateSetting
        }
    }

    It 'UpdateViaIdentityExpanded' -SKip {
        { 
            $customDomainName = "domain-Name031"
            Write-Host -ForegroundColor Green "Use customDomainName : $($customDomainName)"
            $hostName = "pstestrefresh2.dev.cdn.azure.cn"
            $customDomain = New-AzFrontDoorCdnCustomDomain -CustomDomainName $customDomainName -ProfileName $env.FrontDoorEndpointName -ResourceGroupName $env.ResourceGroupName `
            -HostName $hostName
            Write-Host -ForegroundColor Green "Use customDomain token : $($customDomain.ValidationPropertyValidationTokenex)"

            $secretName = "se-psName051"
            Write-Host -ForegroundColor Green "Use secretName : $($secretName)"
    
            $parameter = New-AzFrontDoorCdnSecretCustomerCertificateParametersObject -UseLatestVersion $true -SubjectAlternativeName @() -Type "CustomerCertificate"`
            -SecretSourceId "/subscriptions/$subId/resourceGroups/powershelltest/providers/Microsoft.KeyVault/vaults/cdn-ps-kv/secrets/testps"
    
            $secret = New-AzFrontDoorCdnSecret -Name $secretName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Parameter $parameter
            $secretResoure = New-AzFrontDoorCdnResourceReferenceObject -Id $secret.Id
    
            $updateSetting = New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject -CertificateType "CustomerCertificate" -MinimumTlsVersion "TLS10" -Secret $secretResoure

            $domainObject = Get-AzFrontDoorCdnCustomDomain -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorEndpointName -CustomDomainName $customDomain
            Update-AzFrontDoorCdnCustomDomain -TlsSetting $updateSetting -InputObject $domainObject
        } 
    }
}
