if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorCdnSecret'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorCdnSecret.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorCdnSecret' {
    It 'CreateExpanded' {
        $subId = $env.SubscriptionId
        $secretName = "kvsecret-test02"
        Write-Host -ForegroundColor Green "Use secretName : $($secretName)"

        $parameter = New-AzFrontDoorCdnSecretCustomerCertificateParametersObject -UseLatestVersion $true -Type "CustomerCertificate" `
            -SecretSourceId "/subscriptions/$subId/resourceGroups/testps-rg-cdn-debug/providers/Microsoft.KeyVault/vaults/jingnanxukvtest/secrets/wildcard-azfdtest-xyz"

        # New
        $secretInfo = New-AzFrontDoorCdnSecret -Name $secretName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Parameter $parameter
        $secretInfo.Name | Should -Be $secretName

        # Get - List / by name / ViaIdentity
        $secrets = Get-AzFrontDoorCdnSecret -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $secrets.Count | Should -BeGreaterOrEqual 1
        $getSecret = Get-AzFrontDoorCdnSecret -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $secretName
        $getSecret.Name | Should -Be $secretName
        $getSecret2 = Get-AzFrontDoorCdnSecret -InputObject $getSecret
        $getSecret2.Name | Should -Be $secretName

        # Remove
        Write-Host -ForegroundColor Green "Remove Secret: $($secretName)"
        Remove-AzFrontDoorCdnSecret -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $secretName -SubscriptionId $subId
    }
}
