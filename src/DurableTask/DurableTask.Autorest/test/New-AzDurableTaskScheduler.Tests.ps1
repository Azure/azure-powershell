if(($null -eq $TestName) -or ($TestName -contains 'New-AzDurableTaskScheduler'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDurableTaskScheduler.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDurableTaskScheduler' {
    It 'CreateExpanded' {
        $testSchedulerName = "test-scheduler-create-1277"
        $scheduler = New-AzDurableTaskScheduler -Name $testSchedulerName -ResourceGroupName $env.resourceGroup -Location $env.location -SkuName 'Consumption' -IPAllowlist @('10.0.0.0/8') -PublicNetworkAccess 'Enabled'
        $scheduler.Name | Should -Be $testSchedulerName
        $scheduler.Location | Should -Be $env.location
        Remove-AzDurableTaskScheduler -Name $testSchedulerName -ResourceGroupName $env.resourceGroup
    }

    It 'CreateViaJsonString' {
        $testSchedulerName = "test-scheduler-json-7688"
        $body = @{
            location = $env.location
            properties = @{
                sku = @{
                    name = "Consumption"
                }
                ipAllowlist = @("10.0.0.0/8")
                publicNetworkAccess = "Enabled"
            }
        } | ConvertTo-Json
        $scheduler = New-AzDurableTaskScheduler -Name $testSchedulerName -ResourceGroupName $env.resourceGroup -JsonString $body
        $scheduler.Name | Should -Be $testSchedulerName
        $scheduler.Location | Should -Be $env.location
        $scheduler.SkuName | Should -Be "Consumption"
        $scheduler.IPAllowlist | Should -Contain "10.0.0.0/8"
        $scheduler.PublicNetworkAccess | Should -Be "Enabled"
        Remove-AzDurableTaskScheduler -Name $testSchedulerName -ResourceGroupName $env.resourceGroup
    }

    It 'CreateViaJsonFilePath' {
        $testSchedulerName = "test-scheduler-file-2662"
        $jsonFilePath = Join-Path $TestRecordingFile "..\scheduler-test.json"
        @{
            location = $env.location
            properties = @{
                sku = @{
                    name = "Consumption"
                }
                ipAllowlist = @("10.0.0.0/8")
                publicNetworkAccess = "Enabled"
            }
        } | ConvertTo-Json | Set-Content -Path $jsonFilePath
        $scheduler = New-AzDurableTaskScheduler -Name $testSchedulerName -ResourceGroupName $env.resourceGroup -JsonFilePath $jsonFilePath
        $scheduler.Name | Should -Be $testSchedulerName
        $scheduler.Location | Should -Be $env.location
        $scheduler.SkuName | Should -Be "Consumption"
        $scheduler.IPAllowlist | Should -Contain "10.0.0.0/8"
        $scheduler.PublicNetworkAccess | Should -Be "Enabled"
        Remove-AzDurableTaskScheduler -Name $testSchedulerName -ResourceGroupName $env.resourceGroup
        Remove-Item -Path $jsonFilePath -Force
    }
}
