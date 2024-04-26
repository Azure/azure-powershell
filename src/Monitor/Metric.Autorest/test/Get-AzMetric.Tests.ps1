if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMetric'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMetric.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMetric' {
    It 'List1' {
        {
            $resourceURI = $env.resourceId+"/blobServices/default"
            $startTime = "2024-04-09T00:00:00Z"
            $endTime = "2024-04-10T12:00:00Z"
            $metricResourceResult = Get-AzMetric -ResourceUri $resourceURI -Aggregation "average,minimum,maximum" -AutoAdjustTimegrain -Filter "Tier eq '*'"`
            -Interval "PT6H" -MetricName "BlobCount,BlobCapacity" -MetricNamespace "Microsoft.Storage/storageAccounts/blobServices" -Orderby "average asc"`
            -StartTime $startTime -EndTime $endTime -Top 1
            $metricResourceResult.Value[0].NameValue | Should -BeLike "BlobCount"
            $metricResourceResult.Value[1].NameValue | Should -BeLike "BlobCapacity"
        } | Should -Not -Throw
    }

    It 'ListExpanded' {
        {
            $startTime = "2024-04-01T18:00:00Z"
            $endTime = "2024-04-10T06:00:00Z"
            $metricRegionResult = Get-AzMetric -Region $env.Location -Aggregation count -AutoAdjustTimegrain -Filter "LUN eq '0' and Microsoft.ResourceId eq '*'"`
            -Interval "PT6H" -MetricName "Data Disk Max Burst IOPS" -MetricNamespace "microsoft.compute/virtualmachines" -Orderby "count desc" -Rollupby "LUN" `
            -StartTime $startTime -EndTime $endTime -Top 10
            $metricRegionResult.Value[0].NameValue | Should -Be "Data Disk Max Burst IOPS"
            $metricRegionResult.Value[0].unit | Should -Be "Count"
        } | Should -Not -Throw
    }
}
