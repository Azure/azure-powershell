if(($null -eq $TestName) -or ($TestName -contains 'Get-AzElasticResubscribeOrganization'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzElasticResubscribeOrganization.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzElasticResubscribeOrganization' {
    It 'ResubscribeExpanded' {
        { Get-AzElasticResubscribeOrganization -ResourceGroupName $env.resourceGroup -MonitorName $env.elasticName01 -TargetSubscriptionId $env.SubscriptionId -WhatIf } | Should -Not -Throw
    }

    It 'ResubscribeViaJsonString' {
        $jsonString = @{
            subscriptionId = $env.SubscriptionId
        } | ConvertTo-Json
        { Get-AzElasticResubscribeOrganization -ResourceGroupName $env.resourceGroup -MonitorName $env.elasticName01 -JsonString $jsonString -WhatIf } | Should -Not -Throw
    }

    It 'ResubscribeViaJsonFilePath' {
        $tempFile = New-TemporaryFile
        $jsonContent = @{
            subscriptionId = $env.SubscriptionId
        } | ConvertTo-Json
        Set-Content -Path $tempFile.FullName -Value $jsonContent
        { Get-AzElasticResubscribeOrganization -ResourceGroupName $env.resourceGroup -MonitorName $env.elasticName01 -JsonFilePath $tempFile.FullName -WhatIf } | Should -Not -Throw
        Remove-Item -Path $tempFile.FullName -Force
    }

    It 'Resubscribe' {
        $body = @{
            subscriptionId = $env.SubscriptionId
        }
        { Get-AzElasticResubscribeOrganization -ResourceGroupName $env.resourceGroup -MonitorName $env.elasticName01 -Body $body -WhatIf } | Should -Not -Throw
    }

    It 'ResubscribeViaIdentityExpanded' {
        $elastic = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.elasticName01
        { Get-AzElasticResubscribeOrganization -InputObject $elastic -TargetSubscriptionId $env.SubscriptionId -WhatIf } | Should -Not -Throw
    }

    It 'ResubscribeViaIdentity' {
        $elastic = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.elasticName01
        $body = @{
            subscriptionId = $env.SubscriptionId
        }
        { Get-AzElasticResubscribeOrganization -InputObject $elastic -Body $body -WhatIf } | Should -Not -Throw
    }
}
