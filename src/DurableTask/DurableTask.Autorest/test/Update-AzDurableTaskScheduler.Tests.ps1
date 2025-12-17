if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDurableTaskScheduler'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDurableTaskScheduler.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDurableTaskScheduler' {
    It 'UpdateExpanded' {
        $scheduler = Update-AzDurableTaskScheduler -Name $env.schedulerName -ResourceGroupName $env.resourceGroup -Tag @{"Environment"="Test"}
        $scheduler.Name | Should -Be $env.schedulerName
        $scheduler.Tag["Environment"] | Should -Be "Test"
    }

    It 'UpdateViaJsonString' {
        $body = @{
            tags = @{
                "Department" = "Engineering"
            }
        } | ConvertTo-Json
        $scheduler = Update-AzDurableTaskScheduler -Name $env.schedulerName -ResourceGroupName $env.resourceGroup -JsonString $body
        $scheduler.Name | Should -Be $env.schedulerName
        $scheduler.Tag["Department"] | Should -Be "Engineering"
    }

    It 'UpdateViaJsonFilePath' {
        $jsonFilePath = Join-Path $TestRecordingFile "..\scheduler-update-test.json"
        @{
            tags = @{
                "Project" = "DurableTask"
            }
        } | ConvertTo-Json | Set-Content -Path $jsonFilePath
        $scheduler = Update-AzDurableTaskScheduler -Name $env.schedulerName -ResourceGroupName $env.resourceGroup -JsonFilePath $jsonFilePath
        $scheduler.Name | Should -Be $env.schedulerName
        $scheduler.Tag["Project"] | Should -Be "DurableTask"
        Remove-Item -Path $jsonFilePath -Force
    }

    It 'UpdateViaIdentityExpanded' {
        $scheduler = Get-AzDurableTaskScheduler -Name $env.schedulerName -ResourceGroupName $env.resourceGroup
        $updatedScheduler = Update-AzDurableTaskScheduler -InputObject $scheduler -Tag @{"Status"="Active"}
        $updatedScheduler.Name | Should -Be $env.schedulerName
        $updatedScheduler.Tag["Status"] | Should -Be "Active"
    }
}
