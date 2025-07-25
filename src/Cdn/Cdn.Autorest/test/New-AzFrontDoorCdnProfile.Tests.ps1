if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorCdnProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorCdnProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorCdnProfile'  {
    BeforeAll {
        $profileSku = "Standard_AzureFrontDoor"
    }

    It 'CreateExpanded' {
        $frontDoorCdnProfileName = 'fdp-pstest010'
        Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

        $frontDoorCdnProfile = New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global
        
        $frontDoorCdnProfile.Name | Should -Be $frontDoorCdnProfileName
        $frontDoorCdnProfile.SkuName | Should -Be $profileSku
        $frontDoorCdnProfile.Location | Should -Be "Global"
    }

    It 'CreateExpanded' {
        $frontDoorCdnProfileName = 'fdp-pstest011'
        Write-Host -ForegroundColor Green "New AzFrontDoorCdnProfile: $($frontDoorCdnProfileName), with using profile logScrubbing"

        $rule1 = New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable RequestIPAddress -State Enabled 
        $rule2 = New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable QueryStringArgNames -State Enabled
        $rules = New-AzFrontDoorCdnProfileLogScrubbingObject -ScrubbingRule @($rule1, $rule2) -State Enabled

        $frontDoorCdnProfile = New-AzFrontDoorCdnProfile -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -LogScrubbingRule $rules.ScrubbingRule -LogScrubbingState Enabled -Location Global  -SkuName $profileSku

        $frontDoorCdnProfile.LogScrubbingState | Should -Be "Enabled"
        $frontDoorCdnProfile.LogScrubbingRule.Count | Should -Be 2
        $frontDoorCdnProfile.LogScrubbingRule[0].MatchVariable | Should -Be 'RequestIPAddress'
        $frontDoorCdnProfile.LogScrubbingRule[1].MatchVariable | Should -Be 'QueryStringArgNames'
    }
}
