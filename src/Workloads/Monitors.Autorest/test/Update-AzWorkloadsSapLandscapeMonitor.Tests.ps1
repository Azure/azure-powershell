if(($null -eq $TestName) -or ($TestName -contains 'Update-AzWorkloadsSapLandscapeMonitor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWorkloadsSapLandscapeMonitor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzWorkloadsSapLandscapeMonitor' {
    It 'UpdateExpanded' {
        $response = New-AzWorkloadsSapLandscapeMonitor -MonitorName $env.MonitorName -ResourceGroupName $env.MonitorRg -SubscriptionId $env.WaaSSubscriptionId -GroupingLandscape '{"name":"Prod","topSid":["SID1","SID2"]}' -GroupingSapApplication '{"name":"ERP1","topSid":["SID1","SID2"]}' -TopMetricsThreshold '{"name":"Instance Availability","green":90,"yellow":75,"red":50}'
        $response.GroupingLandscape.Name | Should -Be "Prod"

        $response = New-AzWorkloadsSapLandscapeMonitor -MonitorName $env.MonitorName -ResourceGroupName $env.MonitorRg -SubscriptionId $env.WaaSSubscriptionId -GroupingLandscape '{"name":"NonProd","topSid":["SID1","SID2"]}' -GroupingSapApplication '{"name":"ERP1","topSid":["SID1","SID2"]}' -TopMetricsThreshold '{"name":"Instance Availability","green":90,"yellow":75,"red":50}'
        $response.GroupingLandscape.Name | Should -Be "NonProd"
    }

    It 'UpdateViaIdentityExpanded' {
        $response = New-AzWorkloadsSapLandscapeMonitor -MonitorName $env.MonitorName -ResourceGroupName $env.MonitorRg -SubscriptionId $env.WaaSSubscriptionId -GroupingLandscape '{"name":"Prod","topSid":["SID1","SID2"]}' -GroupingSapApplication '{"name":"ERP1","topSid":["SID1","SID2"]}' -TopMetricsThreshold '{"name":"Instance Availability","green":90,"yellow":75,"red":50}'
        $response.GroupingLandscape.Name | Should -Be "Prod"

        $response = New-AzWorkloadsSapLandscapeMonitor -MonitorName $env.MonitorName -ResourceGroupName $env.MonitorRg -SubscriptionId $env.WaaSSubscriptionId -GroupingLandscape '{"name":"NonProd","topSid":["SID1","SID2"]}' -GroupingSapApplication '{"name":"ERP1","topSid":["SID1","SID2"]}' -TopMetricsThreshold '{"name":"Instance Availability","green":90,"yellow":75,"red":50}'
        $response.GroupingLandscape.Name | Should -Be "NonProd"
    }
}
