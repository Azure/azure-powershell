if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelEntityTimeline'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelEntityTimeline.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelEntityTimeline' {
    It 'ListExpanded' {
        $startTime = (get-date).AddDays(-1).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
        $endTime = (get-date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
        $entities = Get-AzSentinelentity -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName 
        $entityTimeline = Get-AzSentinelEntityTimeline -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -EntityId $entities[0].Name -startTime $startTime -EndTime $endTime
        $entityTimeline | Should -Not -Be $null
    } 
}
