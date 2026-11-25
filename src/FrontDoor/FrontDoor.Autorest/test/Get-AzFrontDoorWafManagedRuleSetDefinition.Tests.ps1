if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFrontDoorWafManagedRuleSetDefinition'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFrontDoorWafManagedRuleSetDefinition.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFrontDoorWafManagedRuleSetDefinition' {
    It 'List' {
        $ruleSets = @(Get-AzFrontDoorWafManagedRuleSetDefinition -SubscriptionId $env.SubscriptionId)
        $ruleSets | Should -Not -BeNullOrEmpty

        foreach ($ruleSet in $ruleSets) {
            $ruleSet.DisplayName | Should -Not -BeNullOrEmpty
            $ruleSet.Status | Should -Not -BeNullOrEmpty
        }

        $defaultRuleSets = @($ruleSets | Where-Object { $_.RuleSetType -in @('DefaultRuleSet', 'Microsoft_DefaultRuleSet') })
        $defaultRuleSets | Should -Not -BeNullOrEmpty
        foreach ($ruleSet in $defaultRuleSets) {
            $rules = @($ruleSet.RuleGroup.Rule)
            $rules | Should -Not -BeNullOrEmpty
            foreach ($rule in $rules) {
                $rule.ParanoiaLevel | Should -BeIn @('PL1', 'PL2', 'PL3', 'PL4')
            }
        }
    }
}
