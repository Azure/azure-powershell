if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMetricsMetric'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMetricsMetric.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMetricsMetric' {
    It 'ListExpanded' {
        {
            Get-AzMetricsMetric -Region $env.Location -Aggregation count -AutoAdjustTimegrain -Filter "LUN eq '0' and Microsoft.ResourceId eq '*'" `
            -Interval "PT6H" -Name "Data Disk Max Burst IOPS" -Namespace "microsoft.compute/virtualmachines" -Orderby "count desc" -Rollupby "LUN" `
            -Timespan "2023-12-18T19:00:00Z/2023-12-19T01:00:00Z" -Top 10
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $resourceURI = $env.resourceId+'/blobServices/default'
            Get-AzMetricsMetric -ResourceUri $resourceURI -Aggregation "average,minimum,maximum" -AutoAdjustTimegrain `
            -Filter "Tier eq '*'" -Interval "PT6H" -Name "BlobCount,BlobCapacity" -Namespace "Microsoft.Storage/storageAccounts/blobServices" `
            -Orderby "average asc" -Timespan "2023-12-19T03:00:00Z/2023-12-19T04:00:00Z" -Top 5
        } | Should -Not -Throw
    }
}
