if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelEntityInsight'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelEntityInsight.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelEntityInsight' {
    It 'GetExpanded' {
        $startTime = (get-date).AddDays(-1).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
        $endTime = (get-date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
        $entities = Get-AzSentinelentity -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
        $entityInsight = Get-AzSentinelEntityInsight -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -EntityId $entities[0].Name -StartTime $startTime -EndTime $endTime
        $entityInsight.MetaDataTotalCount | Should -BeGreaterorEqual 1
    }
}
