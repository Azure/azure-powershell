if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPrometheusRuleGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPrometheusRuleGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPrometheusRuleGroup' {
    It 'List' {
        {Get-AzPrometheusRuleGroup } | Should -Not -Throw
    }

    It 'List1' {
        {Get-AzPrometheusRuleGroup -ResourceGroupName $env.resourceGroup} | Should -Not -Throw
    }

    It 'Get' {
        {Get-AzPrometheusRuleGroup -ResourceGroupName $env.resourceGroup -RuleGroupName $env.rstr1} | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
