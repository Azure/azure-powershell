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

Describe 'New-AzFrontDoorCdnCustomDomain'  {
    It 'CreateExpanded' {
        $subId = $env.SubscriptionId
        $secretName = "se-" + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Use secretName : $($secretName)"

        $parameter = New-AzFrontDoorCdnSecretCustomerCertificateParametersObject -UseLatestVersion $true -SubjectAlternativeName @() -Type "CustomerCertificate"`
        -SecretSourceId "/subscriptions/$subId/resourceGroups/powershelltest/providers/Microsoft.KeyVault/vaults/cdn-ps-kv/certificates/cdndevcn2022-0329"
        
        $secret = New-AzFrontDoorCdnSecret -Name $secretName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Parameter $parameter
        Write-Host -ForegroundColor Green "Use secret id : $($secret.Id)"
        $secretResoure = New-AzFrontDoorCdnResourceReferenceObject -Id $secret.Id
        $tlsSetting = New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject -CertificateType "CustomerCertificate" -MinimumTlsVersion "TLS12" -Secret $secretResoure

        $customDomainName = "domain-" + (RandomString -allChars $false -len 6);
        $hostName = "pstestnew.dev.cdn.azure.cn"
        New-AzFrontDoorCdnCustomDomain -CustomDomainName $customDomainName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName `
        -HostName $hostName -TlsSetting $tlsSetting
    }
}
