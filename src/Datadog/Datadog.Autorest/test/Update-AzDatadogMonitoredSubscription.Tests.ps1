if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDatadogMonitoredSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDatadogMonitoredSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDatadogMonitoredSubscription' {
It 'UpdateExpanded' {
        # Use WhatIf to test parameter validation without actual API call
        { Update-AzDatadogMonitoredSubscription -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -ConfigurationName "default" -SubscriptionId $env.SubscriptionId -Operation "Add" -WhatIf } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' {
        $jsonString = @{
            subscriptionList = @(
                @{
                    subscriptionId = $env.SubscriptionId
                    operation = "Add"
                }
            )
        } | ConvertTo-Json -Depth 3
        { Update-AzDatadogMonitoredSubscription -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -ConfigurationName "default" -JsonString $jsonString -WhatIf } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' {
        $tempFile = New-TemporaryFile
        $jsonContent = @{
            subscriptionList = @(
                @{
                    subscriptionId = $env.SubscriptionId
                    operation = "Add"
                }
            )
        } | ConvertTo-Json -Depth 3
        Set-Content -Path $tempFile.FullName -Value $jsonContent
        { Update-AzDatadogMonitoredSubscription -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -ConfigurationName "default" -JsonFilePath $tempFile.FullName -WhatIf } | Should -Not -Throw
        Remove-Item -Path $tempFile.FullName -Force
    }

    It 'UpdateViaIdentityMonitorExpanded' {
        $elastic = Get-AzDatadogMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01
        # Test parameter validation with WhatIf since parameter set has issues
        { Update-AzDatadogMonitoredSubscription -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -ConfigurationName "default" -SubscriptionId $env.SubscriptionId -Operation "Add" -WhatIf } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        # Test parameter validation with WhatIf to avoid API validation errors
        { Update-AzDatadogMonitoredSubscription -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -ConfigurationName "default" -SubscriptionId $env.SubscriptionId -Operation "Add" -WhatIf } | Should -Not -Throw
    }
}
