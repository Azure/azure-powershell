if(($null -eq $TestName) -or ($TestName -contains 'New-AzNewRelicMonitor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNewRelicMonitor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNewRelicMonitor' -Tag 'LiveOnly' {
    It 'CreateExpanded' {
        {
            New-AzResourceGroup -Name $env.resourceGroup -Location $env.region # $rgName = $rg.ResourceGroupName

            $monitor = New-AzNewRelicMonitor -Name $env.NewMonitorName -ResourceGroupName $env.resourceGroup -Location $env.region -PlanDataPlanDetail $env.planDetails -PlanDataBillingCycle $env.billingCycle -PlanDataUsageType $env.usageType -PlanDataEffectiveDate (Get-Date -DisplayHint DateTime) -UserInfoEmailAddress $env.testerEmail -UserInfoFirstName $env.testerFirstName -UserInfoLastName $env.testerLastName
            $monitor.Name | Should -Be $env.NewMonitorName
            $monitor.ResourceGroup | Should -Be $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
