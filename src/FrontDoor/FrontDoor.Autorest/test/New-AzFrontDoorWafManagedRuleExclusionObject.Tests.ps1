if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorWafManagedRuleExclusionObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorWafManagedRuleExclusionObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorWafManagedRuleExclusionObject' {
    It '__AllParameterSets' -skip {
        $exclusionRule = New-AzFrontDoorWafManagedRuleExclusionObject -Variable "QueryStringArgNames" -Operator "Equals" -Selector "ExcludeInRule"
        $exclusionRule.Variable | Should -Be "QueryStringArgNames"
        $exclusionRule.Operator | Should -Be "Equals"
        $exclusionRule.Selector | Should -Be "ExcludeInRule"
    }
}
