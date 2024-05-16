if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzFrontDoorCdnSecret'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzFrontDoorCdnSecret.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzFrontDoorCdnSecret'  {
    It 'Delete'  {
        $subId = $env.SubscriptionId
        Write-Host -ForegroundColor Green "Use SubscriptionId : $($subId)"

        $secretName = "kvsecret-test03"
        Write-Host -ForegroundColor Green "Use secretName : $($secretName)"

        $parameter = New-AzFrontDoorCdnSecretCustomerCertificateParametersObject -UseLatestVersion $true -SubjectAlternativeName @() -Type "CustomerCertificate"`
        -SecretSourceId "/subscriptions/$subId/resourceGroups/huaiyiz/providers/Microsoft.KeyVault/vaults/huaiyizkvtest/secrets/wildcard-huaiyiz-azfdtest-xyz"
        
        New-AzFrontDoorCdnSecret -Name $secretName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Parameter $parameter
        Remove-AzFrontDoorCdnSecret -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $secretName -SubscriptionId $subId
    }

    It 'DeleteViaIdentity' {
        $subId = $env.SubscriptionId
        Write-Host -ForegroundColor Green "Use SubscriptionId : $($subId)"

        $secretName = "kvsecret-test04"
        Write-Host -ForegroundColor Green "Use secretName : $($secretName)"

        $parameter = New-AzFrontDoorCdnSecretCustomerCertificateParametersObject -UseLatestVersion $true -SubjectAlternativeName @() -Type "CustomerCertificate"`
        -SecretSourceId "/subscriptions/$subId/resourceGroups/huaiyiz/providers/Microsoft.KeyVault/vaults/huaiyizkvtest/secrets/wildcard-huaiyiz-azfdtest-xyz"
        
        New-AzFrontDoorCdnSecret -Name $secretName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Parameter $parameter
        $secretObject = Get-AzFrontDoorCdnSecret -SubscriptionId $subId -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $secretName
        Remove-AzFrontDoorCdnSecret -InputObject $secretObject
    }
}
