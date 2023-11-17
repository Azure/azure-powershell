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

Describe 'Get-AzFrontDoorCdnSecret'  {
    BeforeAll {
        $subId = $env.SubscriptionId
        Write-Host -ForegroundColor Green "Use SubscriptionId : $($subId)"

        $secretName = "se-psName010"
        Write-Host -ForegroundColor Green "Use secretName : $($secretName)"

        $parameter = New-AzFrontDoorCdnSecretCustomerCertificateParametersObject -UseLatestVersion $true -SubjectAlternativeName @() -Type "CustomerCertificate"`
        -SecretSourceId "/subscriptions/$subId/resourceGroups/powershelltest/providers/Microsoft.KeyVault/vaults/cdn-ps-kv/secrets/testps"
        
        New-AzFrontDoorCdnSecret -Name $secretName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Parameter $parameter
    }

    It 'List' {
        $rules = Get-AzFrontDoorCdnSecret -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $rules.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $secret = Get-AzFrontDoorCdnSecret -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $secretName
        $secret.Name | Should -Be $secretName
    }

    It 'GetViaIdentity' {
        $secretObject = Get-AzFrontDoorCdnSecret -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $secretName
        $secret = Get-AzFrontDoorCdnSecret -InputObject $secretObject
        $secret.Name | Should -Be $secretName
    }
}
