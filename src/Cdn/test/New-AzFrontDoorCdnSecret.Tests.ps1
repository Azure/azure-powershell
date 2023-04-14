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

Describe 'New-AzFrontDoorCdnSecret'  {
    It 'CreateExpanded' {
        $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
        try
        {
            $subId = "27cafca8-b9a4-4264-b399-45d0c9cca1ab"
            Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
            New-AzResourceGroup -Name $ResourceGroupName -Location $env.location -SubscriptionId $subId

            $frontDoorCdnProfileName = 'fdp-' + (RandomString -allChars $false -len 6);
            Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

            $profileSku = "Standard_AzureFrontDoor";
            New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global -SubscriptionId $subId

            $secretName = "se-" + (RandomString -allChars $false -len 6);
            Write-Host -ForegroundColor Green "Use secretName : $($secretName)"

            $parameter = New-AzFrontDoorCdnSecretCustomerCertificateParametersObject -UseLatestVersion $true -SubjectAlternativeName @() -Type "CustomerCertificate"`
            -SecretSourceId "/subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups/powershelltest/providers/Microsoft.KeyVault/vaults/cdn-ps-kv/secrets/testps"
            
            New-AzFrontDoorCdnSecret -Name $secretName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Parameter $parameter -SubscriptionId $subId
        } Finally
        {
            Remove-AzResourceGroup -Name $ResourceGroupName -NoWait -SubscriptionId $subId
        }
    }
}
