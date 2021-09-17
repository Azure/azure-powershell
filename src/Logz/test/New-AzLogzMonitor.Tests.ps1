if(($null -eq $TestName) -or ($TestName -contains 'New-AzLogzMonitor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzLogzMonitor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzLogzMonitor' {
    It 'CRUCase' {
        # New case
        $monitor = New-AzLogzMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName03 -Location $env.location -PlanBillingCycle 'Monthly' -PlanUsageType 'PAYG' -PlanDetail '100gb14days' -PlanEffectiveDate (Get-Date -AsUTC) `
                            -UserInfoEmailAddress $env.userEmail -UserInfoPhoneNumber $env.userPhone -UserInfoFirstName  $env.userLastName -UserInfoLastName $env.userFirstName
        $monitor.Name | Should -Be $env.monitorName03

        # Update case
        $monitor = Update-AzLogzMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName03 -Tag @{'key01'=1;'key02'=2;'key03'=3}
        $monitor.Tag.Count | Should -Be 3

        # Remove case
        Remove-AzLogzMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName03

        $monitorList = Get-AzLogzMonitor -ResourceGroupName $env.resourceGroup
        $monitorList.Name | Should -Not -Contain $env.monitorName03
    }

    It 'CRUViaIdentityCase' {
        # New case
        $monitor = New-AzLogzMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName04 -Location $env.location -PlanBillingCycle 'Monthly' -PlanUsageType 'PAYG' -PlanDetail '100gb14days' -PlanEffectiveDate (Get-Date -AsUTC) `
                            -UserInfoEmailAddress $env.userEmail -UserInfoPhoneNumber $env.userPhone -UserInfoFirstName  $env.userLastName -UserInfoLastName $env.userFirstName
        $monitor.Name | Should -Be $env.monitorName04

        # Update case
        $monitor = Update-AzLogzMonitor -InputObject $monitor -Tag @{'key01'=1;'key02'=2;'key03'=3}
        $monitor.Tag.Count | Should -Be 3
        
        # Remove case
        Remove-AzLogzMonitor -InputObject $monitor

        $monitorList = Get-AzLogzMonitor -ResourceGroupName $env.resourceGroup
        $monitorList.Name | Should -Not -Contain $env.monitorName04
    }
}
