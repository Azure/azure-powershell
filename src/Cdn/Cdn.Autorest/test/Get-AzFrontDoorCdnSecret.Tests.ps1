if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFrontDoorCdnSecret'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFrontDoorCdnSecret.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFrontDoorCdnSecret' {
    BeforeAll {
        $script:secretName = 'kvsecret-get'
        $parameter = New-AzFrontDoorCdnSecretCustomerCertificateParametersObject -UseLatestVersion $true -Type 'CustomerCertificate' -SecretSourceId "/subscriptions/$($env.SubscriptionId)/resourceGroups/testps-rg-cdn-debug/providers/Microsoft.KeyVault/vaults/jingnanxukvtest/secrets/wildcard-azfdtest-xyz"
        New-AzFrontDoorCdnSecret -Name $script:secretName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Parameter $parameter | Out-Null
    }

    AfterAll {
        Remove-AzFrontDoorCdnSecret -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:secretName -ErrorAction SilentlyContinue
    }

    It 'List' {
        $ss = Get-AzFrontDoorCdnSecret -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $ss.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $s = Get-AzFrontDoorCdnSecret -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:secretName
        $s.Name | Should -Be $script:secretName
    }

    It 'GetViaIdentity' {
        $s = Get-AzFrontDoorCdnSecret -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:secretName
        $s2 = Get-AzFrontDoorCdnSecret -InputObject $s
        $s2.Name | Should -Be $script:secretName
    }

    It 'GetViaIdentityProfile' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
