if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFrontDoorCdnRuleSetResourceUsage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFrontDoorCdnRuleSetResourceUsage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFrontDoorCdnRuleSetResourceUsage' -Tag 'LiveOnly' {
    It 'List' {
        { 
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

                $frontDoorCdnProfileName = 'fdp-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

                $profileSku = "Standard_AzureFrontDoor";
                New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global

                $rulesetName = 'rs' + (RandomString -allChars $false -len 6);
                New-AzFrontDoorCdnRuleSet -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Name $rulesetName
                $rulesetUsage = Get-AzFrontDoorCdnRuleSetResourceUsage -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -RuleSetName $rulesetName
                $rulesetUsage | Should -not -BeNullOrEmpty 
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }
}
