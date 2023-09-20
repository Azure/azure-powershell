if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSentinelBookmark'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSentinelBookmark.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSentinelBookmark' {
    It 'UpdateExpanded' {
        Get-AzSentinelBookmark -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.UpdateBookmarkId
        $bookmark = Update-AzSentinelBookmark -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Id $env.UpdateBookmarkId -DisplayName "Update Bookmark PS Test"
        $bookmark.DisplayName | Should -Be "Update Bookmark PS Test"
    }

    It 'UpdateViaIdentityExpanded' {
        $bookmark = Get-AzSentinelBookmark -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Id $env.UpdateBookmarkId
        $bookmarkUpdate = Update-AzSentinelBookmark -InputObject $bookmark -DisplayName "Update Bookmark PS Test viaIdenetity"
        $bookmarkUpdate.DisplayName | Should -Be "Update Bookmark PS Test viaIdenetity"
    }
}
