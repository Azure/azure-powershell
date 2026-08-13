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

Describe 'Remove-AzFrontDoorCdnSecret' {
    BeforeAll {
        $script:secretName = 'kvsecret-rm'
        $parameter = New-AzFrontDoorCdnSecretCustomerCertificateParametersObject -UseLatestVersion $true -Type 'CustomerCertificate' -SecretSourceId "/subscriptions/$($env.SubscriptionId)/resourceGroups/testps-rg-cdn-debug/providers/Microsoft.KeyVault/vaults/jingnanxukvtest/secrets/wildcard-azfdtest-xyz"
        New-AzFrontDoorCdnSecret -Name $script:secretName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Parameter $parameter | Out-Null
    }

    It 'Delete' {
        Remove-AzFrontDoorCdnSecret -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:secretName
        { Get-AzFrontDoorCdnSecret -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:secretName -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentityProfile' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
