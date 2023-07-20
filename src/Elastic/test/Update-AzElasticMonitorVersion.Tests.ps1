if(($null -eq $TestName) -or ($TestName -contains 'Update-AzElasticMonitorVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzElasticMonitorVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzElasticMonitorVersion' {
    It 'UpgradeExpanded' {
        {
            Update-AzElasticMonitorVersion -ResourceGroupName $env.resourceGroup -Name $env.monitorName02 -Version 8.8.2
        } | Should -Not -Throw
    }

    It 'UpgradeViaJsonString' {
        {
            $versionProps = @{
                version = "8.8.2"
            }
            $versionPropsJson = ConvertTo-Json -InputObject $versionProps
            Update-AzElasticMonitorVersion -ResourceGroupName $env.resourceGroup -Name $env.monitorName02 -JsonString $versionPropsJson
        } | Should -Not -Throw
    }

    It 'UpgradeViaJsonFilePath' -Skip {

    }

    It 'UpgradeViaIdentityExpanded' -skip {
        {
            $monitor = Get-AzElasticMonitor -ResourceGroupName env.resourceGroup -Name $env.monitorName02
            Update-AzElasticMonitorVersion -InputObject $monitor -Version 8.8.2
        } | Should -Not -Throw
    }
}
