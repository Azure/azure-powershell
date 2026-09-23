if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMetricsBatch'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMetricsBatch.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMetricsBatch' {
    It 'BatchExpanded' {
        {
            $endpoint = 'https://'+$env.Location+'.metrics.monitor.azure.com'
            #Get-Date -AsUTC
            $start = "2023-12-19T02:00:00.000Z"
            $end = "2023-12-19T02:30:00.000Z"
            $expect = '"name": { "value": "Ingress", "localizedValue": "Ingress" }'
            $a = Get-AzMetricsBatch -Endpoint $endpoint -Name 'ingress','egress' -Namespace "Microsoft.Storage/storageAccounts" `
            -EndTime $end -StartTime $start -ResourceId $env.resourceId
            $a.value.ToString().Contains($expect)
        } | Should -Not -Throw
    }

    It 'BatchViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
