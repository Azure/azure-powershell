if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzDatadogLinkDatadogMonitorResourceSaaS'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzDatadogLinkDatadogMonitorResourceSaaS.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzDatadogLinkDatadogMonitorResourceSaaS' {
    It 'LinkExpanded' {
        $saaSResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.SaaS/resources/$($env.monitorName01)SaaS"
        { Invoke-AzDatadogLinkDatadogMonitorResourceSaaS -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -SubscriptionId $env.SubscriptionId -SaaSResourceId $saaSResourceId -WhatIf } | Should -Not -Throw
    }

    It 'LinkViaJsonString' {
        $saaSResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.SaaS/resources/$($env.monitorName01)SaaS"
        $jsonString = @{ saaSResourceId = $saaSResourceId } | ConvertTo-Json
        { Invoke-AzDatadogLinkDatadogMonitorResourceSaaS -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -JsonString $jsonString -WhatIf } | Should -Not -Throw
    }

    It 'LinkViaJsonFilePath' {
        $saaSResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.SaaS/resources/$($env.monitorName01)SaaS"
        $tempFile = New-TemporaryFile
        @{ saaSResourceId = $saaSResourceId } | ConvertTo-Json | Set-Content -Path $tempFile.FullName
        { Invoke-AzDatadogLinkDatadogMonitorResourceSaaS -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -JsonFilePath $tempFile.FullName -WhatIf } | Should -Not -Throw
        Remove-Item -Path $tempFile.FullName -Force
    }

    It 'Link' {
        $saaSResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.SaaS/resources/$($env.monitorName01)SaaS"
        { Invoke-AzDatadogLinkDatadogMonitorResourceSaaS -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -SubscriptionId $env.SubscriptionId -Body @{ saaSResourceId = $saaSResourceId } -WhatIf } | Should -Not -Throw
    }

    It 'LinkViaIdentityExpanded' {
        $saaSResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.SaaS/resources/$($env.monitorName01)SaaS"
        $monitor = Get-AzDatadogMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01
        { Invoke-AzDatadogLinkDatadogMonitorResourceSaaS -InputObject $monitor -SaaSResourceId $saaSResourceId -WhatIf } | Should -Not -Throw
    }

    It 'LinkViaIdentity' {
        $saaSResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.SaaS/resources/$($env.monitorName01)SaaS"
        $monitor = Get-AzDatadogMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01
        { Invoke-AzDatadogLinkDatadogMonitorResourceSaaS -InputObject $monitor -Body @{ saaSResourceId = $saaSResourceId } -WhatIf } | Should -Not -Throw
    }
}
