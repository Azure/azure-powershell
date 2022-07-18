if(($null -eq $TestName) -or ($TestName -contains 'New-AzSentinelBookmark'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSentinelBookmark.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSentinelBookmark' {
    It 'CreateExpanded' {
        $bookmark = New-AzSentinelBookmark -Id ((New-Guid).Guid) -ResourceGroupName $env.resourceGroupName `
            -WorkspaceName $env.workspaceName -DisplayName "NewBookmarkPSTest" -Query "SecurityEvent | take 1" `
            -QueryStartTime (get-date).AddDays(-1).ToUniversalTime() -QueryEndTime (get-date).ToUniversalTime() -EventTime (get-date).ToUniversalTime()
        $bookmark.DisplayName | Should -Be "NewBookmarkPSTest"
    }
}
