if(($null -eq $TestName) -or ($TestName -contains 'Expand-AzSentinelBookmark'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Expand-AzSentinelBookmark.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Expand-AzSentinelBookmark' {
    It 'ExpandExpanded'  {
        $startTime = (get-date).AddDays(-1).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:mm:00:000Z"
        $endTime = (get-date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:mm:00:000Z"
        $bookmarkExpansion = Expand-AzSentinelBookmark -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.ExpandBookmarkId -StartTime $startTime -EndTime $endTime
        $bookmarkExpansion | Should -Not -BeNull
    }
}
 