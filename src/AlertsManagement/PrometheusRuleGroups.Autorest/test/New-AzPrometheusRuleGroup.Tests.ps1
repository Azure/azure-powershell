if(($null -eq $TestName) -or ($TestName -contains 'New-AzPrometheusRuleGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPrometheusRuleGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzPrometheusRuleGroup' {
    It 'CreateExpanded' {
        $rule1 = New-AzPrometheusRuleObject -Record "job_type:billing_jobs_duration_seconds:99p5m" -Expression 'histogram_quantile(0.99, sum(rate(jobs_duration_seconds_bucket{service="billing-processing"}[5m])) by (job_type))'
        $actiongroup = get-AzActionGroup -Name $env.rstr1 -ResourceGroupName $env.resourceGroup
        $actiongroup
        $actiongroup.id
        $action =  New-AzPrometheusRuleGroupActionObject -ActionGroupId $actiongroup.Id -ActionProperty @{"key1" = "value1"}
        $Timespan = New-TimeSpan -Minutes 15
        $rule2 = New-AzPrometheusRuleObject -Alert Billing_Processing_Very_Slow -Expression "job_type:billing_jobs_duration_seconds:99p5m > 30" -Enabled $false -Severity 3 -For $Timespan -Label @{"team"="prod"} -Annotation @{"annotation" = "value"} -ResolveConfigurationAutoResolved $true -ResolveConfigurationTimeToResolve $Timespan -Action $action
        $rules = @($rule1, $rule2)
        $scope = "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/lnxtest/providers/microsoft.monitor/accounts/lnxmonitorworkspace"
        {New-AzPrometheusRuleGroup -ResourceGroupName $env.resourceGroup -RuleGroupName $env.rstr2 -Location eastus -Rule $rule1 -Scope $scope -Enabled } | Should -Not -Throw
    }
}
