if(($null -eq $TestName) -or ($TestName -contains 'Update-AzFrontDoorWafPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzFrontDoorWafPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzFrontDoorWafPolicy' {
    It 'UpdateExpanded' {
        $matchCondition1 = New-AzFrontDoorWafMatchConditionObject -MatchVariable "RequestHeader" -OperatorProperty "Contains" -Selector "UserAgent" -MatchValue "WINDOWS" -Transform "Uppercase"
        $customRule2 = New-AzFrontDoorWafCustomRuleObject -Name "Rule2" -RuleType "MatchRule" -MatchCondition $matchCondition1 -Action "Log" -Priority 2
        # Create an empty LogScrubbingSetting to test removal
        $emptyLogScrubbingSetting = New-AzFrontDoorWafLogScrubbingSettingObject -State "Disabled"
        $updatedPolicy = Update-AzFrontDoorWafPolicy -Name $env.WafPolicyName -ResourceGroupName $env.ResourceGroupName -Customrule $customRule2 -LogScrubbingSetting $emptyLogScrubbingSetting
        $updatedPolicy.CustomRule[0].Name | Should -Be "Rule2"
        $updatedPolicy.CustomRule[0].RuleType | Should -Be "MatchRule"
        $updatedPolicy.CustomRule[0].MatchCondition[0].MatchVariable | Should -Be "RequestHeader"
        $updatedPolicy.CustomRule[0].MatchCondition[0].OperatorProperty | Should -Be "Contains"
        $updatedPolicy.CustomRule[0].MatchCondition[0].Selector | Should -Be "UserAgent"
        $updatedPolicy.CustomRule[0].MatchCondition[0].MatchValue | Should -Be "WINDOWS"
        $updatedPolicy.CustomRule[0].MatchCondition[0].Transform | Should -Be "Uppercase"
        $updatedPolicy.CustomRule[0].Action | Should -Be "Log"
        $updatedPolicy.CustomRule[0].Priority | Should -Be 2
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
