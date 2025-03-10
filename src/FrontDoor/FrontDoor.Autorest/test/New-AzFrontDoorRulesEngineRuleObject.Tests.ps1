if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorRulesEngineRuleObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorRulesEngineRuleObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorRulesEngineRuleObject' {
    It '__AllParameterSets' -skip {
        $headerActions = New-AzFrontDoorHeaderActionObject -HeaderActionType "Append" -HeaderName "X-Content-Type-Options" -Value "nosniff"
        $ruleEngineResponseHeaderAction = New-AzFrontDoorRulesEngineActionObject -ResponseHeaderAction $headerActions	
        $ruleEngineResponseHeaderRule = New-AzFrontDoorRulesEngineRuleObject -Name rule101 -Priority 1 -Action $ruleEngineResponseHeaderAction -MatchCondition $conditions
        $ruleEngineResponseHeaderRule.Name | Should -Be "rule101"
        $ruleEngineResponseHeaderRule.Priority | Should -Be 1
        $ruleEngineResponseHeaderRule.Action.GetType() | Should -Be "Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.RulesEngineAction"
        $ruleEngineResponseHeaderRule.Action.ActionRequestHeaderAction | Should -Be $null
        $ruleEngineResponseHeaderRule.Action.ActionResponseHeaderAction | Should -Be $headerActions
        $ruleEngineResponseHeaderRule.MatchCondition.GetType() | Should -Be "Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.RulesEngineMatchCondition[]"
        $ruleEngineResponseHeaderRule.MatchCondition | Should -Be $conditions
        $ruleEngineResponseHeaderRule.MatchProcessingBehavior | Should -Be $null
    }
}
