if(($null -eq $TestName) -or ($TestName -contains 'Get-AzResiliencyRecoveryPlan'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $ROScenarioEnvironmentDirectory = Join-Path $PSScriptRoot 'RecoveryPlans\Historical'
  $env = Get-ROScenarioEnvironment $ROScenarioEnvironmentDirectory
  $PSDefaultParameterValues['*:Tenant'] = $env.Tenant
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzResiliencyRecoveryPlan.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzResiliencyRecoveryPlan' {
    It 'List' {
        $fixtureEnv = $env
        if ($TestMode -eq 'playback' -and $env.priorPassingSetup) { $fixtureEnv = $env.priorPassingSetup }
        $plans = @(Get-AzResiliencyRecoveryPlan -ServiceGroupName $fixtureEnv.recoveryServiceGroupName -ErrorAction Stop)
        if ($TestMode -eq 'playback') { $plans.Count | Should -Be @($fixtureEnv.initialPlanNames).Count }
        @($plans | Select-Object -ExpandProperty Id -Unique).Count | Should -Be $plans.Count
        @($plans | Select-Object -ExpandProperty Name -Unique).Count | Should -Be $plans.Count
        foreach ($plan in $plans) {
            $plan.Name | Should -Not -BeNullOrEmpty
            $plan.Id | Should -Be "/providers/Microsoft.Management/serviceGroups/$($fixtureEnv.recoveryServiceGroupName)/providers/Microsoft.AzureResilienceManagement/recoveryPlans/$($plan.Name)"
            $plan.PlanType | Should -BeIn @('Zonal', 'Regional')
            $plan.ProvisioningState | Should -Not -BeNullOrEmpty
        }
    }
}
