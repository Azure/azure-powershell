if(($null -eq $TestName) -or ($TestName -contains 'Update-AzPrometheusRuleGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzPrometheusRuleGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzPrometheusRuleGroup' {
    It 'UpdateExpanded' {
        { Update-AzPrometheusRuleGroup -ResourceGroupName $env.resourceGroup -RuleGroupName $env.rstr1 -Enabled} | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        $obj = Get-AzPrometheusRuleGroup -ResourceGroupName $env.resourceGroup -RuleGroupName $env.rstr1
        {Update-AzPrometheusRuleGroup -InputObject $obj -Enabled } | Should -Not -Throw
    }
}
