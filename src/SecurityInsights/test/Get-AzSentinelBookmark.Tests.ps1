if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelBookmark'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelBookmark.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelBookmark' {
    It 'List' {
        $bookmarks = Get-AzSentinelbookmark -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
        $bookmarks.Count | Should -BeGreaterorEqual 1
    }

    It 'Get' {
        $bookmark = Get-AzSentinelbookmark -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.GetbookmarkId
        $bookmark.Name | Should -Be $env.GetbookmarkId
    }

    It 'GetViaIdentity' {
        $bookmark = Get-AzSentinelbookmark -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.GetbookmarkId
        $bookmarkViaIdentity = Get-AzSentinelbookmark -InputObject $bookmark
        $bookmarkViaIdentity.Name | Should -Be $env.GetbookmarkId
    }
}
