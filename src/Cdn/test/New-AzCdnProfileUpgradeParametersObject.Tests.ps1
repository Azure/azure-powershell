if(($null -eq $TestName) -or ($TestName -contains 'New-AzCdnProfileUpgradeParametersObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCdnProfileUpgradeParametersObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCdnProfileUpgradeParametersObject' {
    It 'Upgrade' {
        $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
        {
            $subId = "27cafca8-b9a4-4264-b399-45d0c9cca1ab"
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)

            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location -SubscriptionId $subId

                $frontDoorCdnProfileName = 'fdp-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

                $profileSku = "Standard_AzureFrontDoor";
                New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global -SubscriptionId $subId

                $wafId1 = "/subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups/AFD/providers/microsoft.network/frontdoorWebApplicationFirewallPolicies/afdxwaf1Premiumtest001"
                $wafId2 = "/subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups/AFD/providers/microsoft.network/frontdoorWebApplicationFirewallPolicies/afdxwaf1Premiumtest002"

                $waf1 = New-AzCdnProfileChangeSkuWafMappingObject -SecurityPolicyName waf1 -ChangeToWafPolicyId $wafId1
                $waf2 = New-AzCdnProfileChangeSkuWafMappingObject -SecurityPolicyName waf2 -ChangeToWafPolicyId $wafId2

                $upgrade = New-AzCdnProfileUpgradeParametersObject -WafMappingList @($waf1, $waf2)

                $updatedProfile = Update-AzFrontDoorCdnProfileSku -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -ProfileUpgradeParameter $upgrade
                $updatedProfile.SkuName | Should -Be "Premium_AzureFrontDoor"
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }
}
