if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorWafManagedRuleSetExceptionObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorWafManagedRuleSetExceptionObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorWafManagedRuleSetExceptionObject' {
    It '__AllParameterSets' {
        $ruleScope = New-AzFrontDoorWafRuleScopeObject -RuleId '942100'
        $groupScope = New-AzFrontDoorWafRuleGroupScopeObject -RuleGroupName 'SQLI' -RuleScope $ruleScope
        $setScope = New-AzFrontDoorWafManagedRuleSetScopeObject -RuleSetType 'Microsoft_DefaultRuleSet' -RuleSetVersion '2.2' -RuleGroupScope $groupScope
        $exception = New-AzFrontDoorWafManagedRuleSetExceptionObject -MatchVariable 'RequestHeaderNames' `
            -SelectorMatchOperator 'Equals' -Selector 'User-Agent' -ValueMatchOperator 'Contains' `
            -MatchValue 'test-agent' -Scope $setScope

        $exception.MatchVariable | Should -Be 'RequestHeaderNames'
        $exception.Selector | Should -Be 'User-Agent'
        $exception.SelectorMatchOperator | Should -Be 'Equals'
        $exception.ValueMatchOperator | Should -Be 'Contains'
        $exception.MatchValue | Should -Be @('test-agent')
        $exception.Scope[0].RuleSetType | Should -Be 'Microsoft_DefaultRuleSet'
        $exception.Scope[0].RuleSetVersion | Should -Be '2.2'
        $exception.Scope[0].RuleGroupScope[0].RuleGroupName | Should -Be 'SQLI'
        $exception.Scope[0].RuleGroupScope[0].RuleScope[0].RuleId | Should -Be '942100'
    }
}
