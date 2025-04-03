if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDevCenterAdminProjectCatalog'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDevCenterAdminProjectCatalog.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDevCenterAdminProjectCatalog' {
    It 'PatchExpanded' {
        $catalog = Update-AzDevCenterAdminProjectCatalog  -ProjectName $env.projectName20 -ResourceGroupName $env.resourceGroupName20 -SubscriptionId $env.SubscriptionId2 -CatalogName $env.catalogNew20 -GitHubPath "testpath"
        $catalog.Name | Should -Be $env.catalogNew20
        $catalog.GitHubBranch | Should -Be $env.gitHubBranch
        $catalog.GitHubPath | Should -Be "testpath"
        $catalog.GitHubUri | Should -Be $env.gitHubUri20
    }
}
