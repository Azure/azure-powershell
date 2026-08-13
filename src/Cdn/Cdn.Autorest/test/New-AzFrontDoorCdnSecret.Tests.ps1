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
    BeforeAll {
        $script:secretName = 'kvsecret-new'
    }

    AfterAll {
        Remove-AzFrontDoorCdnSecret -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:secretName -ErrorAction SilentlyContinue
    }

    It 'CreateExpanded' {
        $parameter = New-AzFrontDoorCdnSecretCustomerCertificateParametersObject -UseLatestVersion $true -Type 'CustomerCertificate' -SecretSourceId "/subscriptions/$($env.SubscriptionId)/resourceGroups/testps-rg-cdn-debug/providers/Microsoft.KeyVault/vaults/jingnanxukvtest/secrets/wildcard-azfdtest-xyz"
        $s = New-AzFrontDoorCdnSecret -Name $script:secretName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Parameter $parameter
        $s.Name | Should -Be $script:secretName
    }
}
