if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzPrometheusRuleGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzPrometheusRuleGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzPrometheusRuleGroup' {
    It 'Delete' {
        {Remove-AzPrometheusRuleGroup -ResourceGroupName $env.resourceGroup  -RuleGroupName $env.testRuleGroup} | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {  
           $rule= new-AzPrometheusRuleObject -Alert "Billing_Processing_Very_Slow" -Expression "job_type:billing_jobs_duration_seconds:99p5m > 30" -Severity 2 -For PT5M
           $rulegroup = New-AzPrometheusRuleGroup -ResourceGroupName  $env.resourceGroup  -RuleGroupName "newRuleGroup" -Location "East Us" -Rule $rule -Scope $env.scope 
           Remove-AzPrometheusRuleGroup -InputObject $rulegroup
         } | Should -Not -Throw
    }
}
